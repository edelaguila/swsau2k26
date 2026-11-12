using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Controlador_Reportes;
using Capa_Modelo_Reportes;

namespace Capa_Vista_Reportes
{
    public partial class FrmReportes : Form
    {
        private readonly Cls_Controlador_Reportes controlador = new Cls_Controlador_Reportes();

        // 0 = insertar, 1 = editar
        private int estadoOperacion = 0;
        private int iIdReporteEdicion = 0;

        // Evita recargar actividades mientras se enlaza el combo de informes
        private bool bCargandoInformes = false;

        public FrmReportes()
        {
            InitializeComponent();
            Cbo_Fk_Informe.SelectedIndexChanged += Cbo_Fk_Informe_SelectedIndexChanged;
            pro_Configurar_Campos_Imagen();

            // Vista previa (agregado): al cambiar las rutas se muestran las imagenes
            txtRutaImagenPos.TextChanged += (s, e) => pro_Mostrar_Miniaturas(txtRutaImagenPos, flpImagenesPos);
            txtRutaImagenCorrecion.TextChanged += (s, e) => pro_Mostrar_Miniaturas(txtRutaImagenCorrecion, flpImagenesCorrecion);
            txtRutaImagenSugerencias.TextChanged += (s, e) => pro_Mostrar_Miniaturas(txtRutaImagenSugerencias, flpImagenesSugerencias);
        }

        // ---------------- Vista previa de imagenes (agregado) ----------------
        private readonly ToolTip ttMiniaturas = new ToolTip();

        // Dibuja una miniatura por cada ruta del textbox; clic en la miniatura abre la imagen
        private void pro_Mostrar_Miniaturas(TextBox txtRutas, FlowLayoutPanel flpDestino)
        {
            flpDestino.SuspendLayout();
            try
            {
                // Liberar las miniaturas anteriores para no dejar archivos ni memoria ocupados
                while (flpDestino.Controls.Count > 0)
                {
                    Control ctlAnterior = flpDestino.Controls[0];
                    flpDestino.Controls.RemoveAt(0);
                    if (ctlAnterior is PictureBox pbAnterior && pbAnterior.Image != null)
                        pbAnterior.Image.Dispose();
                    ctlAnterior.Dispose();
                }

                foreach (string sRuta in Cls_Imagenes_Reporte.fun_Separar(txtRutas.Text))
                {
                    string sRutaCompleta = Cls_Imagenes_Reporte.fun_Resolver(sRuta);
                    Image imgMiniatura = sRutaCompleta != null ? fun_Cargar_Imagen(sRutaCompleta) : null;

                    if (imgMiniatura == null)
                    {
                        // No se encontro o no se puede mostrar (ej. .webp): se indica con un recuadro
                        Label lblFalta = new Label
                        {
                            Size = new Size(130, 92),
                            Margin = new Padding(3),
                            BackColor = Color.Gainsboro,
                            TextAlign = ContentAlignment.MiddleCenter,
                            Font = new Font("Rockwell", 8F),
                            Text = (sRutaCompleta == null ? "No encontrada:" : "Sin vista previa:")
                                   + Environment.NewLine + System.IO.Path.GetFileName(sRuta)
                        };
                        ttMiniaturas.SetToolTip(lblFalta, sRuta);
                        flpDestino.Controls.Add(lblFalta);
                        continue;
                    }

                    PictureBox pbImagen = new PictureBox
                    {
                        Size = new Size(130, 92),
                        Margin = new Padding(3),
                        SizeMode = PictureBoxSizeMode.Zoom,
                        BorderStyle = BorderStyle.FixedSingle,
                        BackColor = Color.White,
                        Cursor = Cursors.Hand,
                        Image = imgMiniatura,
                        Tag = sRutaCompleta
                    };
                    pbImagen.Click += (s, e) => pro_Abrir_Imagen((string)pbImagen.Tag);
                    ttMiniaturas.SetToolTip(pbImagen, System.IO.Path.GetFileName(sRuta) + " (clic para abrir)");
                    flpDestino.Controls.Add(pbImagen);
                }
            }
            finally
            {
                flpDestino.ResumeLayout();
            }
        }

        // Carga una copia de la imagen para no dejar bloqueado el archivo
        private Image fun_Cargar_Imagen(string sRutaCompleta)
        {
            try
            {
                using (System.IO.FileStream fsImagen = new System.IO.FileStream(sRutaCompleta, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                using (Image imgOriginal = Image.FromStream(fsImagen))
                {
                    return new Bitmap(imgOriginal);
                }
            }
            catch (Exception)
            {
                // GDI+ no reconoce el formato (ej. webp o un .jpeg que en realidad es webp):
                // se pide la miniatura a Windows
                return fun_Cargar_Imagen_Windows(sRutaCompleta);
            }
        }

        // Pide a Windows la miniatura del archivo (la misma que muestra el Explorador),
        // asi se ven formatos que GDI+ no soporta (webp, etc.). No usa WPF para no
        // cambiar la escala (DPI) de las ventanas del sistema.
        private Image fun_Cargar_Imagen_Windows(string sRutaCompleta)
        {
            IntPtr hBitmap = IntPtr.Zero;
            try
            {
                Guid guidFabrica = typeof(IShellItemImageFactory).GUID;
                IShellItemImageFactory fabrica;
                SHCreateItemFromParsingName(sRutaCompleta, IntPtr.Zero, guidFabrica, out fabrica);

                TamanoNativo tamano = new TamanoNativo { cx = 256, cy = 256 };
                if (fabrica.GetImage(tamano, 0, out hBitmap) != 0 || hBitmap == IntPtr.Zero)
                    return null;

                using (Image imgShell = Image.FromHbitmap(hBitmap))
                {
                    return new Bitmap(imgShell);
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                if (hBitmap != IntPtr.Zero) DeleteObject(hBitmap);
            }
        }

        [System.Runtime.InteropServices.ComImport]
        [System.Runtime.InteropServices.Guid("bcc18b79-ba16-442f-80c4-8a59c30c463b")]
        [System.Runtime.InteropServices.InterfaceType(System.Runtime.InteropServices.ComInterfaceType.InterfaceIsIUnknown)]
        private interface IShellItemImageFactory
        {
            [System.Runtime.InteropServices.PreserveSig]
            int GetImage(TamanoNativo size, int flags, out IntPtr phbm);
        }

        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        private struct TamanoNativo
        {
            public int cx;
            public int cy;
        }

        [System.Runtime.InteropServices.DllImport("shell32.dll", CharSet = System.Runtime.InteropServices.CharSet.Unicode, PreserveSig = false)]
        private static extern void SHCreateItemFromParsingName(
            string pszPath, IntPtr pbc,
            [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPStruct)] Guid riid,
            [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Interface)] out IShellItemImageFactory ppv);

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern bool DeleteObject(IntPtr hObject);

        // Abre la imagen con el visor predeterminado de Windows
        private void pro_Abrir_Imagen(string sRutaCompleta)
        {
            try
            {
                System.Diagnostics.Process.Start(sRutaCompleta);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo abrir la imagen: " + ex.Message, "Reportes",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Al cambiar el informe se cargan solo las actividades de su proyecto
        private void Cbo_Fk_Informe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bCargandoInformes) return;
            pro_Cargar_Actividades(fun_Obtener_Id_Combo(Cbo_Fk_Informe));
        }

        private void pro_Cargar_Actividades(int iIdInforme)
        {
            if (iIdInforme <= 0)
            {
                Cbo_Fk_Rubrica.DataSource = null;
                return;
            }

            try
            {
                DataTable dtActividades = controlador.fun_obtener_actividades(iIdInforme);
                Cbo_Fk_Rubrica.DataSource = dtActividades;
                Cbo_Fk_Rubrica.DisplayMember = "Actividad";
                Cbo_Fk_Rubrica.ValueMember = "Pk_Id_Actividad_Rubrica";
                Cbo_Fk_Rubrica.SelectedIndex = -1;

                if (dtActividades.Rows.Count == 0)
                    MessageBox.Show("El proyecto de este informe no tiene actividades de rúbrica activas.",
                        "Reportes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Cbo_Fk_Rubrica.DataSource = null;
                MessageBox.Show("Error al cargar las actividades: " + ex.Message, "Reportes",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GPB_Aspectos_Positivos_Enter(object sender, EventArgs e)
        {

        }

        private void FrmReportes_Load(object sender, EventArgs e)
        {
            pro_Cargar_Combos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (Cbo_id_reporte.SelectedIndex == -1 || Cbo_id_reporte.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un reporte para buscar.", "Reportes",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int iIdReporte = Convert.ToInt32(Cbo_id_reporte.SelectedValue);
                MDL_Reporte reporte = controlador.fun_obtener_reporte_por_id(iIdReporte);

                if (reporte == null)
                {
                    MessageBox.Show("No se encontró el reporte seleccionado.", "Reportes",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                TxtAspectosPositivos.Text = reporte.aspectos_positivos;
                txtRutaImagenPos.Text = fun_Rutas_A_Lineas(reporte.imagen_aspectos_positivos);
                txtCorreciones.Text = reporte.correcciones;
                txtRutaImagenCorrecion.Text = fun_Rutas_A_Lineas(reporte.imagen_correcciones);
                txtSugerencias.Text = reporte.recomendaciones;
                txtRutaImagenSugerencias.Text = fun_Rutas_A_Lineas(reporte.imagen_recomendaciones);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar el reporte: " + ex.Message, "Reportes",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            pro_Eliminar_Reporte();
        }

        private void pro_Eliminar_Reporte()
        {
            int? iIdReporte = null;
            if (Cbo_id_reporte.SelectedIndex != -1 && Cbo_id_reporte.SelectedValue != null)
                iIdReporte = Convert.ToInt32(Cbo_id_reporte.SelectedValue);

            // Solo se confirma si hay un reporte seleccionado; si no, el controlador devuelve el aviso
            if (iIdReporte != null)
            {
                DialogResult confirmacion = MessageBox.Show(
                    "¿Desea eliminar el reporte seleccionado?", "Reportes",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmacion != DialogResult.Yes)
                    return;
            }

            string sMensaje;
            bool bEliminado = controlador.fun_eliminar_reporte(iIdReporte, out sMensaje);

            if (!bEliminado)
            {
                MessageBox.Show(sMensaje, "Reportes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show(sMensaje, "Reportes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            pro_Limpiar_Textboxes();
            pro_Recargar_Reportes();
        }

        private void Btn_Modificar_Click(object sender, EventArgs e)
        {
            if (Cbo_id_reporte.SelectedIndex == -1 || Cbo_id_reporte.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un reporte para modificar.", "Reportes",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int iIdReporte = Convert.ToInt32(Cbo_id_reporte.SelectedValue);
                MDL_Reporte reporte = controlador.fun_obtener_reporte_por_id(iIdReporte);

                if (reporte == null)
                {
                    MessageBox.Show("No se encontró el reporte seleccionado.", "Reportes",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Al fijar el informe se recargan sus actividades; si la actividad guardada
                // es de otro proyecto, el combo queda vacío para elegir una válida.
                Cbo_Fk_Informe.SelectedValue = reporte.Fk_id_informe;
                Cbo_Fk_Rubrica.SelectedValue = reporte.Fk_id_actividad_rubrica;
                TxtAspectosPositivos.Text = reporte.aspectos_positivos;
                txtRutaImagenPos.Text = fun_Rutas_A_Lineas(reporte.imagen_aspectos_positivos);
                txtCorreciones.Text = reporte.correcciones;
                txtRutaImagenCorrecion.Text = fun_Rutas_A_Lineas(reporte.imagen_correcciones);
                txtSugerencias.Text = reporte.recomendaciones;
                txtRutaImagenSugerencias.Text = fun_Rutas_A_Lineas(reporte.imagen_recomendaciones);

                iIdReporteEdicion = reporte.Pk_id_reporte;
                pro_Cambiar_Estado(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el reporte: " + ex.Message, "Reportes",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            pro_Guardar_Reporte();
        }

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            pro_Cambiar_Estado(0);
            pro_Limpiar_Formulario();
        }

        private void pro_Guardar_Reporte()
        {
            MDL_Reporte reporte = new MDL_Reporte
            {
                Fk_id_informe = fun_Obtener_Id_Combo(Cbo_Fk_Informe),
                Fk_id_actividad_rubrica = fun_Obtener_Id_Combo(Cbo_Fk_Rubrica),
                aspectos_positivos = TxtAspectosPositivos.Text,
                imagen_aspectos_positivos = fun_Lineas_A_Rutas(txtRutaImagenPos.Text),
                correcciones = txtCorreciones.Text,
                imagen_correcciones = fun_Lineas_A_Rutas(txtRutaImagenCorrecion.Text),
                recomendaciones = txtSugerencias.Text,
                imagen_recomendaciones = fun_Lineas_A_Rutas(txtRutaImagenSugerencias.Text)
            };

            string sMensaje;
            bool bGuardado;

            if (estadoOperacion == 0)
            {
                bGuardado = controlador.fun_insertar_reporte(reporte, out sMensaje);
            }
            else
            {
                reporte.Pk_id_reporte = iIdReporteEdicion;
                bGuardado = controlador.fun_modificar_reporte(reporte, out sMensaje);
            }

            // Guarde o no, se regresa al estado de inserción
            pro_Cambiar_Estado(0);

            if (!bGuardado)
            {
                MessageBox.Show(sMensaje, "Reportes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show(sMensaje, "Reportes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            pro_Limpiar_Formulario();
            pro_Recargar_Reportes();
        }

        // Devuelve 0 si el combo no tiene selección
        private int fun_Obtener_Id_Combo(ComboBox cbo)
        {
            if (cbo.SelectedIndex == -1 || cbo.SelectedValue == null)
                return 0;
            return Convert.ToInt32(cbo.SelectedValue);
        }

        private void pro_Cambiar_Estado(int iEstado)
        {
            estadoOperacion = iEstado;
            Btn_Modificar.Enabled = (iEstado == 0);
            if (iEstado == 0)
                iIdReporteEdicion = 0;
        }

        private void pro_Limpiar_Formulario()
        {
            pro_Limpiar_Textboxes();
            Cbo_Fk_Informe.SelectedIndex = -1;
            Cbo_Fk_Rubrica.SelectedIndex = -1;
            Cbo_id_reporte.SelectedIndex = -1;
        }

        private void btn_Rutas_Positivos_Click(object sender, EventArgs e)
        {
            pro_Buscar_Ruta(txtRutaImagenPos);
        }

        private void btn_Rutas_Correciones_Click(object sender, EventArgs e)
        {
            pro_Buscar_Ruta(txtRutaImagenCorrecion);
        }

        private void btn_Rutas_Sugerencias_Click(object sender, EventArgs e)
        {
            pro_Buscar_Ruta(txtRutaImagenSugerencias);
        }

        // Abre el explorador (permite elegir varias imágenes), copia cada una a la carpeta
        // Imagenes_Reportes y agrega su ruta como una línea nueva del textbox.
        // Para quitar una imagen basta con borrar su línea.
        private void pro_Buscar_Ruta(TextBox txtDestino)
        {
            using (OpenFileDialog ofdImagen = new OpenFileDialog())
            {
                ofdImagen.Title = "Seleccione una o varias imágenes";
                ofdImagen.Filter = Cls_Imagenes_Reporte.sFILTRO_DIALOGO;
                ofdImagen.Multiselect = true;

                if (ofdImagen.ShowDialog() != DialogResult.OK)
                    return;

                List<string> lstRutas = Cls_Imagenes_Reporte.fun_Separar(txtDestino.Text);
                List<string> lstErrores = new List<string>();

                foreach (string sArchivo in ofdImagen.FileNames)
                {
                    try
                    {
                        string sRuta = Cls_Imagenes_Reporte.fun_Copiar_A_Carpeta(sArchivo);
                        if (!lstRutas.Any(r => string.Equals(r, sRuta, StringComparison.OrdinalIgnoreCase)))
                            lstRutas.Add(sRuta);
                    }
                    catch (Exception ex)
                    {
                        lstErrores.Add(System.IO.Path.GetFileName(sArchivo) + ": " + ex.Message);
                    }
                }

                txtDestino.Text = string.Join(Environment.NewLine, lstRutas);

                if (lstErrores.Count > 0)
                    MessageBox.Show("No se pudieron agregar algunas imágenes:" + Environment.NewLine +
                        string.Join(Environment.NewLine, lstErrores), "Reportes",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // BD ("a.png|b.png") -> una ruta por línea en el textbox
        private string fun_Rutas_A_Lineas(string sValor)
        {
            return string.Join(Environment.NewLine, Cls_Imagenes_Reporte.fun_Separar(sValor));
        }

        // Textbox (una ruta por línea) -> formato de la BD separado por '|'
        private string fun_Lineas_A_Rutas(string sTexto)
        {
            return Cls_Imagenes_Reporte.fun_Unir(Cls_Imagenes_Reporte.fun_Separar(sTexto));
        }

        // Los textbox de rutas muestran una imagen por línea con barra de desplazamiento
        private void pro_Configurar_Campos_Imagen()
        {
            ToolTip ttAyuda = new ToolTip();
            foreach (TextBox txt in new[] { txtRutaImagenPos, txtRutaImagenCorrecion, txtRutaImagenSugerencias })
            {
                txt.Multiline = true;
                txt.WordWrap = false;
                txt.ScrollBars = ScrollBars.Both;
                ttAyuda.SetToolTip(txt, "Una imagen por línea. Borre una línea para quitar esa imagen.");
            }
            foreach (Button btn in new[] { btn_Rutas_Positivos, btn_Rutas_Correciones, btn_Rutas_Sugerencias })
            {
                btn.Text = "Agregar imágenes";
                ttAyuda.SetToolTip(btn, "Puede seleccionar varias imágenes a la vez (Ctrl + clic).");
            }
        }

        private void pro_Limpiar_Textboxes()
        {
            TxtAspectosPositivos.Clear();
            txtRutaImagenPos.Clear();
            txtCorreciones.Clear();
            txtRutaImagenCorrecion.Clear();
            txtSugerencias.Clear();
            txtRutaImagenSugerencias.Clear();
        }

        private void pro_Recargar_Reportes()
        {
            try
            {
                Cbo_id_reporte.DataSource = controlador.fun_obtener_reportes();
                Cbo_id_reporte.DisplayMember = "Reporte";
                Cbo_id_reporte.ValueMember = "Pk_id_reporte";
                Cbo_id_reporte.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al recargar los reportes: " + ex.Message, "Reportes",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pro_Cargar_Combos()
        {
            try
            {
                bCargandoInformes = true;
                try
                {
                    Cbo_Fk_Informe.DataSource = controlador.fun_obtener_informes();
                    Cbo_Fk_Informe.DisplayMember = "Informe";
                    Cbo_Fk_Informe.ValueMember = "Pk_id_informe";
                    Cbo_Fk_Informe.SelectedIndex = -1;
                }
                finally
                {
                    bCargandoInformes = false;
                }

                // Las actividades se cargan al elegir un informe (solo las de su proyecto)
                Cbo_Fk_Rubrica.DataSource = null;

                Cbo_id_reporte.DataSource = controlador.fun_obtener_reportes();
                Cbo_id_reporte.DisplayMember = "Reporte";
                Cbo_id_reporte.ValueMember = "Pk_id_reporte";
                Cbo_id_reporte.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Reportes",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Boton Salir agregado en la estandarizacion de diseño: solo cierra la ventana
        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
