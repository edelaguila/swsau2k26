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

        public FrmReportes()
        {
            InitializeComponent();
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
                txtRutaImagenPos.Text = reporte.imagen_aspectos_positivos;
                txtCorreciones.Text = reporte.correcciones;
                txtRutaImagenCorrecion.Text = reporte.imagen_correcciones;
                txtSugerencias.Text = reporte.recomendaciones;
                txtRutaImagenSugerencias.Text = reporte.imagen_recomendaciones;
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

                Cbo_Fk_Informe.SelectedValue = reporte.Fk_id_informe;
                Cbo_Fk_Rubrica.SelectedValue = reporte.Fk_id_actividad_rubrica;
                TxtAspectosPositivos.Text = reporte.aspectos_positivos;
                txtRutaImagenPos.Text = reporte.imagen_aspectos_positivos;
                txtCorreciones.Text = reporte.correcciones;
                txtRutaImagenCorrecion.Text = reporte.imagen_correcciones;
                txtSugerencias.Text = reporte.recomendaciones;
                txtRutaImagenSugerencias.Text = reporte.imagen_recomendaciones;

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
                imagen_aspectos_positivos = txtRutaImagenPos.Text,
                correcciones = txtCorreciones.Text,
                imagen_correcciones = txtRutaImagenCorrecion.Text,
                recomendaciones = txtSugerencias.Text,
                imagen_recomendaciones = txtRutaImagenSugerencias.Text
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

        // Abre el explorador de archivos y coloca la ruta elegida en el textbox recibido
        private void pro_Buscar_Ruta(TextBox txtDestino)
        {
            using (OpenFileDialog ofdImagen = new OpenFileDialog())
            {
                ofdImagen.Title = "Seleccione una imagen";
                ofdImagen.Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (ofdImagen.ShowDialog() == DialogResult.OK)
                    txtDestino.Text = ofdImagen.FileName;
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
                Cbo_Fk_Informe.DataSource = controlador.fun_obtener_informes();
                Cbo_Fk_Informe.DisplayMember = "Informe";
                Cbo_Fk_Informe.ValueMember = "Pk_id_informe";
                Cbo_Fk_Informe.SelectedIndex = -1;

                Cbo_Fk_Rubrica.DataSource = controlador.fun_obtener_actividades();
                Cbo_Fk_Rubrica.DisplayMember = "Actividad";
                Cbo_Fk_Rubrica.ValueMember = "Pk_Id_Actividad_Rubrica";
                Cbo_Fk_Rubrica.SelectedIndex = -1;

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
    }
}
