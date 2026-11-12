// Empieza codigo hecho por Maria Morales 0901-22-1226 el dia 07/10/2026
using Capa_Controlador_Rubrica;
using Capa_Controlador_Seguridad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Vista_Rubrica
{

    public partial class Frm_Rubrica : Form
    {
        private const int I_ID_APLICACION = 515;                                // Código de aplicación (tbl_aplicacion)
        private const int I_ID_MODULO = 12;                                     // Módulo Planificacion y Rubricas

        
        private static readonly bool B_PERMITIR_SIN_SESION = true;
        private const string S_RUTA_AYUDA = "Ayudas\\Ayuda_Rubricas.chm";        // Relativa a la carpeta del ejecutable
        private static readonly Color gColorModulo = Color.FromArgb(255, 224, 0);  // Área 3 - Amarillo (ES-01)
        private static readonly Color gColorFilaAlterna = Color.FromArgb(255, 249, 214);

        private readonly Cls_Controlador_Rubrica gControlador = new Cls_Controlador_Rubrica();
        private int gIdSeleccionado = 0;
        private bool gEnEdicion = false;
        private bool gModoNuevo = false;
        private bool gCargando = false;

        // Permisos del usuario conectado sobre la aplicación 515
        private bool gPermisoIngresar = false;
        private bool gPermisoConsultar = false;
        private bool gPermisoModificar = false;
        private bool gPermisoEliminar = false;
        private bool gPermisoImprimir = false;
        private bool gHaySesion = false;

        public Frm_Rubrica()
        {
            InitializeComponent();
        }

        // ===================== Carga inicial =====================
        private void pro_frm_rubrica_load(object sender, EventArgs e)
        {
            pro_configurar_controles();
            if (!fun_obtener_permisos())
            {
                BeginInvoke(new Action(Close));   // Sin sesión y sin modo prueba: no se permite el acceso
                return;
            }

            pro_cargar_cronogramas();
            if (gPermisoConsultar)
            {
                pro_cargar_grilla(0, 0, null);
            }
            else
            {
                pro_limpiar_campos();
                MessageBox.Show("Su usuario no tiene permiso para consultar las rúbricas.", "Permiso restringido",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            pro_establecer_modo(false);
        }

        // ===================== Seguridad =====================
        // Devuelve false si el formulario no debe abrirse.
        private bool fun_obtener_permisos()
        {
            gHaySesion = Cls_Usuario_Conectado.bLoginEstado && Cls_Usuario_Conectado.iIdUsuario > 0;

            if (!gHaySesion)
            {
                if (!B_PERMITIR_SIN_SESION)
                {
                    MessageBox.Show("No hay una sesión activa. Ingrese al sistema mediante el Login.", "Acceso denegado",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                pro_asignar_permisos(true, true, true, true, true);
                Text = I_ID_APLICACION + " - Rúbricas";
                return true;
            }

            try
            {
                // Combina permisos por usuario y por perfil (igual que el componente Navegador)
                var rPermisos = Cls_Aplicacion_Permisos.ObtenerPermisosCombinados(
                    Cls_Usuario_Conectado.iIdUsuario, I_ID_APLICACION, I_ID_MODULO, Cls_Usuario_Conectado.iIdPerfil);
                pro_asignar_permisos(rPermisos.ingresar, rPermisos.consultar, rPermisos.modificar,
                    rPermisos.eliminar, rPermisos.imprimir);
            }
            catch (Exception ex)
            {
                pro_asignar_permisos(false, false, false, false, false);
                MessageBox.Show("No se pudieron obtener los permisos del usuario: " + ex.Message, "Seguridad",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
        }

        private void pro_asignar_permisos(bool bIngresar, bool bConsultar, bool bModificar, bool bEliminar, bool bImprimir)
        {
            gPermisoIngresar = bIngresar;
            gPermisoConsultar = bConsultar;
            gPermisoModificar = bModificar;
            gPermisoEliminar = bEliminar;
            gPermisoImprimir = bImprimir;
        }

        // Registra la acción en la bitácora de Seguridad (solo con sesión real)
        private void pro_registrar_bitacora(string sAccion)
        {
            if (!gHaySesion) return;
            try
            {
                new Cls_BitacoraControlador().RegistrarAccion(Cls_Usuario_Conectado.iIdUsuario, I_ID_APLICACION, sAccion, true);
            }
            catch (Exception ex)
            {
                // La operación ya se guardó; un fallo de bitácora no debe revertirla
                MessageBox.Show("La operación se realizó, pero no se pudo registrar en la bitácora: " + ex.Message,
                    "Bitácora", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool fun_tiene_permiso(bool bPermiso, string sAccion)
        {
            if (bPermiso) return true;
            MessageBox.Show("No cuenta con permiso para " + sAccion + ".", "Acceso denegado",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        private void pro_configurar_controles()
        {
            DataGridView dgvTabla = Dgv_Rubricas;
            dgvTabla.ReadOnly = true;
            dgvTabla.AllowUserToAddRows = false;
            dgvTabla.AllowUserToDeleteRows = false;
            dgvTabla.AllowUserToResizeRows = false;
            dgvTabla.MultiSelect = false;
            dgvTabla.RowHeadersVisible = false;
            dgvTabla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTabla.AutoGenerateColumns = false;
            dgvTabla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTabla.BackgroundColor = Color.White;
            dgvTabla.BorderStyle = BorderStyle.None;
            dgvTabla.EnableHeadersVisualStyles = false;
            dgvTabla.ColumnHeadersDefaultCellStyle.BackColor = gColorModulo;
            dgvTabla.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvTabla.ColumnHeadersDefaultCellStyle.Font = new Font("Rockwell", 10F, FontStyle.Bold);
            dgvTabla.ColumnHeadersHeight = 32;
            dgvTabla.DefaultCellStyle.Font = new Font("Rockwell", 10F, FontStyle.Regular);
            dgvTabla.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 236, 140);
            dgvTabla.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvTabla.AlternatingRowsDefaultCellStyle.BackColor = gColorFilaAlterna;

            dgvTabla.Columns.Clear();
            dgvTabla.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID", FillWeight = 6 });
            dgvTabla.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Cronograma", HeaderText = "Cronograma", FillWeight = 20 });
            dgvTabla.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nombre", HeaderText = "Rúbrica", FillWeight = 22 });
            dgvTabla.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Descripcion", HeaderText = "Descripción", FillWeight = 26 });
            dgvTabla.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Objetivo", HeaderText = "Objetivo", FillWeight = 26 });
        }

        private void pro_cargar_cronogramas()
        {
            gCargando = true;
            try
            {
                Cbo_Cronograma.DisplayMember = "Texto";
                Cbo_Cronograma.ValueMember = "Id";
                Cbo_Cronograma.DataSource = gControlador.fun_listar_cronogramas();
                Cbo_Cronograma.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los cronogramas: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { gCargando = false; }
            pro_mostrar_info_cronograma();
        }

        // Recarga la grilla y deja seleccionado el registro indicado (por id, o por cronograma + nombre
        // cuando es un registro recién insertado). Si no se encuentra, selecciona el primero.
        private void pro_cargar_grilla(int iIdBuscar, int iIdCronogramaBuscar, string sNombreBuscar)
        {
            try
            {
                Dgv_Rubricas.DataSource = null;
                Dgv_Rubricas.DataSource = gControlador.fun_listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar la lista de rúbricas: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (Dgv_Rubricas.Rows.Count == 0) { pro_limpiar_campos(); pro_actualizar_botones(); return; }

            int iFilaDestino = 0;
            for (int iFila = 0; iFila < Dgv_Rubricas.Rows.Count; iFila++)
            {
                DataRow drFila = fun_fila_datos(iFila);
                if (drFila == null) continue;
                bool bCoincideId = iIdBuscar > 0 && Convert.ToInt32(drFila["Id"]) == iIdBuscar;
                bool bCoincideNombre = sNombreBuscar != null && Convert.ToInt32(drFila["IdCronograma"]) == iIdCronogramaBuscar
                                       && string.Equals(drFila["Nombre"].ToString(), sNombreBuscar, StringComparison.OrdinalIgnoreCase);
                if (bCoincideId || bCoincideNombre) { iFilaDestino = iFila; break; }
            }
            pro_mostrar_fila(iFilaDestino);
        }

        private DataRow fun_fila_datos(int iFila)
        {
            if (iFila < 0 || iFila >= Dgv_Rubricas.Rows.Count) return null;
            DataRowView drvFila = Dgv_Rubricas.Rows[iFila].DataBoundItem as DataRowView;
            return drvFila?.Row;
        }

        // Muestra en los campos el registro de la fila indicada
        private void pro_mostrar_fila(int iFila)
        {
            DataRow drFila = fun_fila_datos(iFila);
            if (drFila == null) return;

            Dgv_Rubricas.ClearSelection();
            Dgv_Rubricas.Rows[iFila].Selected = true;
            Dgv_Rubricas.CurrentCell = Dgv_Rubricas.Rows[iFila].Cells[0];

            gCargando = true;
            try
            {
                gIdSeleccionado = Convert.ToInt32(drFila["Id"]);
                Cbo_Cronograma.SelectedValue = Convert.ToInt32(drFila["IdCronograma"]);
                Txt_Nombre.Text = drFila["Nombre"].ToString();
                Txt_Descripcion.Text = drFila["Descripcion"].ToString();
                Txt_Objetivo.Text = drFila["Objetivo"].ToString();
            }
            finally { gCargando = false; }

            pro_mostrar_info_cronograma();
            pro_actualizar_botones();
        }

        private void pro_limpiar_campos()
        {
            gCargando = true;
            try
            {
                gIdSeleccionado = 0;
                Txt_Nombre.Clear();
                Txt_Descripcion.Clear();
                Txt_Objetivo.Clear();
            }
            finally { gCargando = false; }
            Erp_Validacion.Clear();
            pro_mostrar_info_cronograma();
        }

        // ===================== Estado de controles =====================
        private void pro_establecer_modo(bool bEdicion)
        {
            gEnEdicion = bEdicion;

            Cbo_Cronograma.Enabled = bEdicion;
            Txt_Nombre.Enabled = bEdicion;
            Txt_Descripcion.Enabled = bEdicion;
            Txt_Objetivo.Enabled = bEdicion;
            Dgv_Rubricas.Enabled = !bEdicion;

            if (!bEdicion) Erp_Validacion.Clear();
            pro_actualizar_botones();
        }

        private void pro_actualizar_botones()
        {
            bool bHayRegistro = gIdSeleccionado > 0;
            int iFilaActual = Dgv_Rubricas.CurrentRow?.Index ?? -1;
            int iTotalFilas = Dgv_Rubricas.Rows.Count;

            Btn_Ingresar.Enabled = !gEnEdicion && gPermisoIngresar;
            Btn_Modificar.Enabled = !gEnEdicion && bHayRegistro && gPermisoModificar;
            Btn_Guardar.Enabled = gEnEdicion;
            Btn_Cancelar.Enabled = gEnEdicion;
            Btn_Eliminar.Enabled = !gEnEdicion && bHayRegistro && gPermisoEliminar;
            Btn_Consultar.Enabled = !gEnEdicion && gPermisoConsultar;
            Btn_Imprimir.Enabled = !gEnEdicion && gPermisoImprimir;
            Btn_Refrescar.Enabled = !gEnEdicion && gPermisoConsultar;

            bool bNavegar = !gEnEdicion && iTotalFilas > 0;
            Btn_Inicio.Enabled = bNavegar && iFilaActual > 0;
            Btn_Anterior.Enabled = bNavegar && iFilaActual > 0;
            Btn_Siguiente.Enabled = bNavegar && iFilaActual < iTotalFilas - 1;
            Btn_Fin.Enabled = bNavegar && iFilaActual < iTotalFilas - 1;

            Btn_Ayuda.Enabled = true;
            Btn_Salir.Enabled = true;
        }

        // ===================== Cronograma =====================
        private int fun_obtener_id_cronograma()
        {
            DataRowView drvFila = Cbo_Cronograma.SelectedItem as DataRowView;
            return drvFila == null ? 0 : Convert.ToInt32(drvFila["Id"]);
        }

        // Muestra las fechas y el estado del cronograma elegido debajo del nombre
        private void pro_mostrar_info_cronograma()
        {
            DataRowView drvFila = Cbo_Cronograma.SelectedItem as DataRowView;
            Lbl_InfoCronograma.Text = drvFila == null ? "" : drvFila["Info"].ToString();
        }

        private void pro_cbo_cronograma_cambiado(object sender, EventArgs e)
        {
            if (gCargando) return;
            Erp_Validacion.SetError(Cbo_Cronograma, "");
            pro_mostrar_info_cronograma();
        }

        // ===================== Validaciones de campos =====================
        private void pro_txt_nombre_keypress(object sender, KeyPressEventArgs e)
        {
            if (!Cls_Controlador_Rubrica.fun_caracter_valido_nombre(e.KeyChar))
            {
                e.Handled = true;
                Erp_Validacion.SetError(Txt_Nombre, "Solo se permiten letras, números, espacios y . , - ( ) /");
            }
            else
            {
                Erp_Validacion.SetError(Txt_Nombre, "");
            }
        }

        private bool fun_validar_campos()
        {
            Erp_Validacion.Clear();
            bool bValido = true;

            if (fun_obtener_id_cronograma() == 0)
            {
                Erp_Validacion.SetError(Cbo_Cronograma, "Seleccione un cronograma.");
                bValido = false;
            }

            string sNombre = Txt_Nombre.Text.Trim();
            if (sNombre.Length == 0)
            {
                Erp_Validacion.SetError(Txt_Nombre, "El nombre es obligatorio.");
                bValido = false;
            }
            else if (sNombre.Length < 3)
            {
                Erp_Validacion.SetError(Txt_Nombre, "Mínimo 3 caracteres.");
                bValido = false;
            }

            if (!bValido)
                MessageBox.Show("Revise los campos marcados en rojo.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return bValido;
        }

        // ===================== Botones CRUD =====================
        private void pro_btn_ingresar_click(object sender, EventArgs e)
        {
            if (!fun_tiene_permiso(gPermisoIngresar, "ingresar rúbricas")) return;
            gModoNuevo = true;
            Dgv_Rubricas.ClearSelection();
            pro_limpiar_campos();                                  // Conserva el cronograma elegido
            pro_establecer_modo(true);
            if (fun_obtener_id_cronograma() == 0) Cbo_Cronograma.Focus(); else Txt_Nombre.Focus();
        }

        private void pro_btn_modificar_click(object sender, EventArgs e)
        {
            if (!fun_tiene_permiso(gPermisoModificar, "modificar rúbricas")) return;
            if (gIdSeleccionado == 0)
            {
                MessageBox.Show("Seleccione una rúbrica de la tabla para modificarla.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            gModoNuevo = false;
            pro_establecer_modo(true);
            Txt_Nombre.Focus();
        }

        private void pro_btn_guardar_click(object sender, EventArgs e)
        {
            if (gModoNuevo ? !fun_tiene_permiso(gPermisoIngresar, "ingresar rúbricas")
                           : !fun_tiene_permiso(gPermisoModificar, "modificar rúbricas")) return;
            if (!fun_validar_campos()) return;

            int iIdCronograma = fun_obtener_id_cronograma();
            string sNombre = Txt_Nombre.Text.Trim();
            var rResultado = gControlador.fun_guardar(
                gModoNuevo ? 0 : gIdSeleccionado,
                iIdCronograma,
                sNombre,
                Txt_Descripcion.Text,
                Txt_Objetivo.Text);

            if (!rResultado.bOk)
            {
                MessageBox.Show(rResultado.sMensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show(rResultado.sMensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            pro_registrar_bitacora(gModoNuevo
                ? "Insertó la rúbrica '" + sNombre + "' en el cronograma " + iIdCronograma + " (tbl_rubrica)"
                : "Modificó la rúbrica " + gIdSeleccionado + " '" + sNombre + "' (tbl_rubrica)");
            int iIdGuardado = gModoNuevo ? 0 : gIdSeleccionado;
            gEnEdicion = false;
            pro_cargar_grilla(iIdGuardado, iIdCronograma, sNombre);
            pro_establecer_modo(false);
        }

        private void pro_btn_cancelar_click(object sender, EventArgs e)
        {
            gEnEdicion = false;
            int iFila = Dgv_Rubricas.CurrentRow?.Index ?? -1;
            if (!gModoNuevo && iFila >= 0) pro_mostrar_fila(iFila);
            else if (Dgv_Rubricas.Rows.Count > 0) pro_mostrar_fila(0);
            else pro_limpiar_campos();
            pro_establecer_modo(false);
        }

        private void pro_btn_eliminar_click(object sender, EventArgs e)
        {
            if (gIdSeleccionado == 0) return;
            if (!fun_tiene_permiso(gPermisoEliminar, "eliminar rúbricas")) return;

            DialogResult drConfirmacion = MessageBox.Show(
                "¿Eliminar la rúbrica \"" + Txt_Nombre.Text + "\"?\n" +
                "También se eliminarán sus criterios y sus actividades asociadas.",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (drConfirmacion != DialogResult.Yes) return;

            int iIdEliminado = gIdSeleccionado;
            string sNombreEliminado = Txt_Nombre.Text;
            var rResultado = gControlador.fun_eliminar(iIdEliminado);
            MessageBox.Show(rResultado.sMensaje, rResultado.bOk ? "Información" : "Atención",
                MessageBoxButtons.OK, rResultado.bOk ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            if (rResultado.bOk)
            {
                pro_registrar_bitacora("Eliminó la rúbrica " + iIdEliminado + " '" + sNombreEliminado + "' (tbl_rubrica)");
                pro_cargar_grilla(0, 0, null);
                pro_establecer_modo(false);
            }
        }

        // ===================== Componentes compartidos =====================
        private void pro_btn_consultar_click(object sender, EventArgs e)
        {
            if (!fun_tiene_permiso(gPermisoConsultar, "consultar rúbricas")) return;
            try
            {
                using (var frmConsulta = new Capa_Vista_Componente_Consultas.Frm_Consulta_Simple(new[] { "tbl_rubrica" }))
                {
                    frmConsulta.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo abrir el componente de consultas: " + ex.Message, "Consultas",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pro_btn_imprimir_click(object sender, EventArgs e)
        {
            if (!fun_tiene_permiso(gPermisoImprimir, "imprimir reportes de rúbricas")) return;
            try
            {
                new Capa_Vista_Reporteador.Frm_Reportes().reporteAplicacion(I_ID_APLICACION);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo abrir el reporte de la aplicación " + I_ID_APLICACION + ": " + ex.Message,
                    "Reportes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pro_btn_refrescar_click(object sender, EventArgs e)
        {
            if (!fun_tiene_permiso(gPermisoConsultar, "consultar rúbricas")) return;
            int iIdActual = gIdSeleccionado;
            pro_cargar_cronogramas();
            pro_cargar_grilla(iIdActual, 0, null);
            pro_establecer_modo(false);
        }

        private void pro_btn_ayuda_click(object sender, EventArgs e)
        {
            string sRutaAyuda = Path.Combine(Application.StartupPath, S_RUTA_AYUDA);
            if (File.Exists(sRutaAyuda))
                Help.ShowHelp(this, sRutaAyuda);
            else
                MessageBox.Show("No se encontró el archivo de ayuda:\n" + sRutaAyuda, "Ayuda",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pro_btn_salir_click(object sender, EventArgs e)
        {
            Close();   // La confirmación por cambios sin guardar está en FormClosing
        }

        private void pro_frm_rubrica_closing(object sender, FormClosingEventArgs e)
        {
            if (!gEnEdicion) return;
            DialogResult drSalir = MessageBox.Show("Hay cambios sin guardar. ¿Desea salir de todas formas?",
                "Confirmar salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (drSalir != DialogResult.Yes) e.Cancel = true;
        }

        // ===================== Navegación =====================
        private void pro_btn_inicio_click(object sender, EventArgs e)
        {
            if (Dgv_Rubricas.Rows.Count > 0) pro_mostrar_fila(0);
        }

        private void pro_btn_anterior_click(object sender, EventArgs e)
        {
            int iFila = Dgv_Rubricas.CurrentRow?.Index ?? 0;
            if (iFila > 0) pro_mostrar_fila(iFila - 1);
        }

        private void pro_btn_siguiente_click(object sender, EventArgs e)
        {
            int iFila = Dgv_Rubricas.CurrentRow?.Index ?? -1;
            if (iFila < Dgv_Rubricas.Rows.Count - 1) pro_mostrar_fila(iFila + 1);
        }

        private void pro_btn_fin_click(object sender, EventArgs e)
        {
            if (Dgv_Rubricas.Rows.Count > 0) pro_mostrar_fila(Dgv_Rubricas.Rows.Count - 1);
        }

        private void pro_dgv_rubricas_cellclick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !gEnEdicion) pro_mostrar_fila(e.RowIndex);
        }
    } 
}
// Termina codigo hecho por Maria Morales 0901-22-1226 el dia 07/10/2026