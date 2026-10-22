using Capa_Controlador_Asignacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Controlador_Seguridad;
using Capa_Modelo_Seguridad;

namespace Capa_Vista_Asignacion
{
    public partial class Frm_Asignacion : Form
    {
        //Inicio de código de Kenph Luna 9959-22-6326 en la fecha 16/10/2026
        // Instancias de controladores requeridos
        private readonly Cls_AsignacionControlador gControladorAsig = new Cls_AsignacionControlador();
        private readonly Cls_PermisosControlador gControladorPermisos = new Cls_PermisosControlador();

        // Código de la aplicación
        private const int I_ID_APLICACION_ASIGNACION = 512;

        // Variables de estado del formulario
        private bool bModoNuevo = false;
        private bool bEnEdicion = false;
        private int iIndiceFilaActual = -1;

        // Variables globales para permisos del usuario autenticado
        private bool bPermisoIngresar = false;
        private bool bPermisoConsultar = false;
        private bool bPermisoModificar = false;
        private bool bPermisoEliminar = false;
        private bool bPermisoImprimir = false;


        public Frm_Asignacion()
        {
            InitializeComponent();
        }

        private void pro_ConfigurarAparienciaEstandar()
        {
            // Resolución mínima obligatoria 850x550
            this.MinimumSize = new Size(850, 550);

            // Tipografía corporativa Rockwell
            Font fntTexto = new Font("Rockwell", 10F, FontStyle.Regular);
            Font fntSubtitulo = new Font("Rockwell", 11F, FontStyle.Bold);

            // Formato de fechas
            Dtp_FechaAsignacion.Format = DateTimePickerFormat.Short;
            Dtp_FechaFinalizacion.Format = DateTimePickerFormat.Short;

            Txt_IdAsignacion.ReadOnly = true;

            Pnl_Titulo.BackColor = Color.FromArgb(0, 170, 255);
            Lbl_Titulo.Font = new Font("Rockwell", 18F, FontStyle.Bold);
            Lbl_Titulo.ForeColor = Color.White;

            // Estilización del DataGridView
            pro_EstilizarDataGridView();
        }

        private void pro_EstilizarDataGridView()
        {
            Dgv_Asignaciones.BackgroundColor = Color.White;
            Dgv_Asignaciones.BorderStyle = BorderStyle.Fixed3D;
            Dgv_Asignaciones.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            Dgv_Asignaciones.RowHeadersVisible = false;
            Dgv_Asignaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Dgv_Asignaciones.MultiSelect = false;
            Dgv_Asignaciones.ReadOnly = true;
            Dgv_Asignaciones.AllowUserToAddRows = false;
            Dgv_Asignaciones.AllowUserToDeleteRows = false;
            Dgv_Asignaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Encabezados con el color representativo
            Dgv_Asignaciones.EnableHeadersVisualStyles = false;
            Dgv_Asignaciones.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 170, 255);
            Dgv_Asignaciones.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            Dgv_Asignaciones.ColumnHeadersDefaultCellStyle.Font = new Font("Rockwell", 10F, FontStyle.Bold);
            Dgv_Asignaciones.ColumnHeadersHeight = 35;

            // Filas alternadas para lectura descansada
            Dgv_Asignaciones.DefaultCellStyle.Font = new Font("Rockwell", 10F, FontStyle.Regular);
            Dgv_Asignaciones.DefaultCellStyle.SelectionBackColor = Color.FromArgb(179, 229, 252);
            Dgv_Asignaciones.DefaultCellStyle.SelectionForeColor = Color.Black;
            Dgv_Asignaciones.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 247, 255);
        }

        private void pro_CentrarPaneles()
        {
            if (Pnl_ContenedorCampos != null && Pnl_CentroCampos != null)
            {
                // Centra el bloque de datos horizontalmente respecto al ancho de la pantalla
                int iPosicionX = (Pnl_ContenedorCampos.ClientSize.Width - Pnl_CentroCampos.Width) / 2;
                if (iPosicionX < 0) iPosicionX = 0;

                Pnl_CentroCampos.Location = new Point(iPosicionX, 5);
            }
        }

        private void Frm_Asignacion_Resize(object sender, EventArgs e)
        {
            pro_CentrarPaneles();
        }

        private void pro_ObtenerPermisosAplicacion()
        {
            // Intento por asignación directa de usuario
            Cls_Permiso_Aplicacion_Usuario permisosUsuario =
                gControladorPermisos.ObtenerPermisosAplicacionUsuarioConectado(I_ID_APLICACION_ASIGNACION);

            if (permisosUsuario != null)
            {
                bPermisoIngresar = permisosUsuario.Cmp_Ingresar_Permiso_Aplicacion_Usuario; 
                bPermisoConsultar = permisosUsuario.Cmp_Consultar_Permiso_Aplicacion_Usuario; 
                bPermisoModificar = permisosUsuario.Cmp_Modificar_Permiso_Aplicacion_Usuario; 
                bPermisoEliminar = permisosUsuario.Cmp_Eliminar_Permiso_Aplicacion_Usuario; 
                bPermisoImprimir = permisosUsuario.Cmp_Imprimir_Permiso_Aplicacion_Usuario; 
            }
            else
            {
                //consulta por el perfil del usuario si no tiene configuración individual
                try
                {
                    Cls_PermisosControlador.Cls_ControladorAsignacionPerfilAplicacion ctrlPerfil =
                    new Cls_PermisosControlador.Cls_ControladorAsignacionPerfilAplicacion(); 

            Cls_Asignacion_Perrmisos_Perfiles permisosPerfil =
                ctrlPerfil.ObtenerPermisosAplicacionPerfil(I_ID_APLICACION_ASIGNACION); 

            if (permisosPerfil != null)
                {
                    bPermisoIngresar = permisosPerfil.bIngresar_permiso_aplicacion_perfil; 
                    bPermisoConsultar = permisosPerfil.bConsultar_permiso_aplicacion_perfil; 
                    bPermisoModificar = permisosPerfil.bModificar_permiso_aplicacion_perfil; 
                    bPermisoEliminar = permisosPerfil.bEliminar_permiso_aplicacion_perfil; 
                    bPermisoImprimir = permisosPerfil.bImprimir_permiso_aplicacion_perfil; 
                }
                    else
                    {
                        bPermisoIngresar = false;
                        bPermisoConsultar = false;
                        bPermisoModificar = false;
                        bPermisoEliminar = false;
                        bPermisoImprimir = false;
                    }
                }
                catch
                {
                    bPermisoIngresar = false;
                    bPermisoConsultar = false;
                    bPermisoModificar = false;
                    bPermisoEliminar = false;
                    bPermisoImprimir = false;
                }
            }
        }

        private void pro_HabilitarControles(bool bActivo)
        {
            bEnEdicion = bActivo;

            // Controles de captura
            Txt_NombreAsignacion.Enabled = bActivo;
            Dtp_FechaAsignacion.Enabled = bActivo;
            Dtp_FechaFinalizacion.Enabled = bActivo;
            Txt_Descripcion.Enabled = bActivo;
            Txt_Observaciones.Enabled = bActivo;
            Cbo_Auditor.Enabled = bActivo;
            Cbo_Auditado.Enabled = bActivo;
            Cbo_EstadoAsignacion.Enabled = bActivo;
            Cbo_ActividadRubrica.Enabled = bActivo;
            Txt_Evidencia.Enabled = bActivo;

            // Botones de acción en formulario
            Btn_Guardar.Enabled = bActivo;
            Btn_Cancelar.Enabled = bActivo;

            // Botones de comando
            Btn_Ingresar.Enabled = !bActivo && bPermisoIngresar;
            Btn_Modificar.Enabled = !bActivo && bPermisoModificar && (Dgv_Asignaciones.Rows.Count > 0);
            Btn_Eliminar.Enabled = !bActivo && bPermisoEliminar && (Dgv_Asignaciones.Rows.Count > 0);
            Btn_Imprimir.Enabled = !bActivo && bPermisoImprimir;
            Dgv_Asignaciones.Enabled = !bActivo;

            pro_ActualizarBotonesNavegacion();
        }

        private void pro_LimpiarCampos()
        {
            Txt_IdAsignacion.Clear();
            Txt_NombreAsignacion.Clear();
            Dtp_FechaAsignacion.Value = DateTime.Now;
            Dtp_FechaFinalizacion.Value = DateTime.Now;
            Txt_Descripcion.Clear();
            Txt_Observaciones.Clear();
            Txt_Evidencia.Clear();

            if (Cbo_Auditor.Items.Count > 0) Cbo_Auditor.SelectedIndex = 0;
            if (Cbo_Auditado.Items.Count > 0) Cbo_Auditado.SelectedIndex = 0;
            if (Cbo_EstadoAsignacion.Items.Count > 0) Cbo_EstadoAsignacion.SelectedIndex = 0;
            if (Cbo_ActividadRubrica.Items.Count > 0) Cbo_ActividadRubrica.SelectedIndex = 0;
        }

        // Cargar Datos
        private void pro_CargarCombosCatalogos()
        {
            try
            {
                // Auditor
                DataTable dtAuditores = gControladorAsig.fun_CargarAuditores();
                Cbo_Auditor.DataSource = dtAuditores;
                Cbo_Auditor.DisplayMember = "Cmp_Nombre_Auditor";
                Cbo_Auditor.ValueMember = "Pk_Id_Auditor";

                // Auditado
                DataTable dtAuditados = gControladorAsig.fun_CargarAuditados();
                Cbo_Auditado.DataSource = dtAuditados;
                Cbo_Auditado.DisplayMember = "Cmp_Nombre_Auditado";
                Cbo_Auditado.ValueMember = "Pk_Id_Auditado";

                // Estado Asignación
                DataTable dtEstados = gControladorAsig.fun_CargarEstados();
                Cbo_EstadoAsignacion.DataSource = dtEstados;
                Cbo_EstadoAsignacion.DisplayMember = "Cmp_Nombre_Estado_Asignacion";
                Cbo_EstadoAsignacion.ValueMember = "Pk_Id_Estado_Asignacion";

                // Actividades de Rúbrica
                DataTable dtActividades = gControladorAsig.fun_CargarActividadesRubrica();
                Cbo_ActividadRubrica.DataSource = dtActividades;
                Cbo_ActividadRubrica.DisplayMember = "Cmp_Detalle_Actividad";
                Cbo_ActividadRubrica.ValueMember = "Pk_Id_Actividad_Rubrica";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los catálogos del sistema: " + ex.Message, "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pro_CargarListadoAsignaciones()
        {
            try
            {
                DataTable dtDatos = gControladorAsig.fun_ConsultarAsignaciones();
                Dgv_Asignaciones.DataSource = dtDatos;

                // Ocultar columnas con IDs foráneos del Grid para mantener la interfaz limpia
                if (Dgv_Asignaciones.Columns.Contains("Fk_Id_Auditor"))
                    Dgv_Asignaciones.Columns["Fk_Id_Auditor"].Visible = false;
                if (Dgv_Asignaciones.Columns.Contains("Fk_Id_Auditado"))
                    Dgv_Asignaciones.Columns["Fk_Id_Auditado"].Visible = false;
                if (Dgv_Asignaciones.Columns.Contains("Fk_Id_Estado_Asignacion"))
                    Dgv_Asignaciones.Columns["Fk_Id_Estado_Asignacion"].Visible = false;
                if (Dgv_Asignaciones.Columns.Contains("Fk_Id_Actividad_Rubrica"))
                    Dgv_Asignaciones.Columns["Fk_Id_Actividad_Rubrica"].Visible = false;

                if (Dgv_Asignaciones.Rows.Count > 0)
                {
                    iIndiceFilaActual = 0;
                    pro_SincronizarFilaConCampos(iIndiceFilaActual);
                }
                else
                {
                    iIndiceFilaActual = -1;
                    pro_LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los registros de asignación: " + ex.Message, "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pro_SincronizarFilaConCampos(int iFila)
        {
            if (iFila < 0 || iFila >= Dgv_Asignaciones.Rows.Count) return;

            DataGridViewRow fila = Dgv_Asignaciones.Rows[iFila];

            Txt_IdAsignacion.Text = fila.Cells["ID"].Value?.ToString();
            Txt_NombreAsignacion.Text = fila.Cells["Asignacion"].Value?.ToString();

            if (DateTime.TryParse(fila.Cells["Fecha Asignada"].Value?.ToString(), out DateTime dInicio))
                Dtp_FechaAsignacion.Value = dInicio;

            if (DateTime.TryParse(fila.Cells["Fecha Limite"].Value?.ToString(), out DateTime dFin))
                Dtp_FechaFinalizacion.Value = dFin;
            else
                Dtp_FechaFinalizacion.Value = DateTime.Now;

            Txt_Descripcion.Text = fila.Cells["Descripcion"].Value?.ToString();
            Txt_Observaciones.Text = fila.Cells["Observaciones"].Value?.ToString();
            Txt_Evidencia.Text = fila.Cells["Evidencia"].Value?.ToString();

            // Sincronización de ComboBoxes mediante ValueMember
            if (fila.Cells["Fk_Id_Auditor"].Value != DBNull.Value)
                Cbo_Auditor.SelectedValue = Convert.ToInt32(fila.Cells["Fk_Id_Auditor"].Value);

            if (fila.Cells["Fk_Id_Auditado"].Value != DBNull.Value)
                Cbo_Auditado.SelectedValue = Convert.ToInt32(fila.Cells["Fk_Id_Auditado"].Value);

            if (fila.Cells["Fk_Id_Estado_Asignacion"].Value != DBNull.Value)
                Cbo_EstadoAsignacion.SelectedValue = Convert.ToInt32(fila.Cells["Fk_Id_Estado_Asignacion"].Value);

            if (fila.Cells["Fk_Id_Actividad_Rubrica"].Value != DBNull.Value)
                Cbo_ActividadRubrica.SelectedValue = Convert.ToInt32(fila.Cells["Fk_Id_Actividad_Rubrica"].Value);

            // Reflejar selección en el control visual
            Dgv_Asignaciones.ClearSelection();
            Dgv_Asignaciones.Rows[iFila].Selected = true;
        }

        //Operaciones CRUD y Botones de Barra

        private void Btn_Ingresar_Click(object sender, EventArgs e)
        {
            if (!bPermisoIngresar)
            {
                MessageBox.Show("No cuenta con permisos para crear registros en este módulo.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bModoNuevo = true;
            pro_LimpiarCampos();
            pro_HabilitarControles(true);
            Txt_NombreAsignacion.Focus();
        }

        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            // Extracción de llaves foráneas
            int iAuditor = Convert.ToInt32(Cbo_Auditor.SelectedValue ?? 0);
            int iAuditado = Convert.ToInt32(Cbo_Auditado.SelectedValue ?? 0);
            int iEstado = Convert.ToInt32(Cbo_EstadoAsignacion.SelectedValue ?? 0);
            int iActividadRubrica = Convert.ToInt32(Cbo_ActividadRubrica.SelectedValue ?? 0);

            string sNombre = Txt_NombreAsignacion.Text;
            DateTime dInicio = Dtp_FechaAsignacion.Value;
            DateTime? dFin = Dtp_FechaFinalizacion.Value;
            string sDescripcion = Txt_Descripcion.Text;
            string sEvidencia = Txt_Evidencia.Text;
            string sObservaciones = Txt_Observaciones.Text;

            bool bExitoOperacion = false;
            string sMensajeRespuesta = string.Empty;

            if (bModoNuevo)
            {
                // Inserción
                (bExitoOperacion, sMensajeRespuesta) = gControladorAsig.fun_RegistrarAsignacion(
                    iAuditor, iAuditado, iEstado, iActividadRubrica,
                    sNombre, dInicio, dFin, sDescripcion, sEvidencia, sObservaciones);
            }
            else
            {
                // Modificación
                int iIdAsignacion = Convert.ToInt32(Txt_IdAsignacion.Text);
                (bExitoOperacion, sMensajeRespuesta) = gControladorAsig.fun_ActualizarAsignacion(
                    iIdAsignacion, iAuditor, iAuditado, iEstado, iActividadRubrica,
                    sNombre, dInicio, dFin, sDescripcion, sEvidencia, sObservaciones);
            }

            if (bExitoOperacion)
            {
                MessageBox.Show(sMensajeRespuesta, "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pro_HabilitarControles(false);
                pro_CargarListadoAsignaciones();
            }
            else
            {
                MessageBox.Show(sMensajeRespuesta, "Validación / Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Btn_Modificar_Click(object sender, EventArgs e)
        {
            if (!bPermisoModificar)
            {
                MessageBox.Show("No cuenta con permisos para modificar registros.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(Txt_IdAsignacion.Text))
            {
                MessageBox.Show("Debe seleccionar un registro de la tabla para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bModoNuevo = false;
            pro_HabilitarControles(true);
            Txt_NombreAsignacion.Focus();
        }

        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (!bPermisoEliminar)
            {
                MessageBox.Show("No cuenta con permisos para eliminar registros.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(Txt_IdAsignacion.Text))
            {
                MessageBox.Show("Seleccione un registro para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult dlgConfirmacion = MessageBox.Show(
                $"¿Está seguro de que desea eliminar la asignación '{Txt_NombreAsignacion.Text}'?",
                "Confirmación de Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dlgConfirmacion == DialogResult.Yes)
            {
                int iIdAsignacion = Convert.ToInt32(Txt_IdAsignacion.Text);
                (bool bExito, string sMensaje) = gControladorAsig.fun_BorrarAsignacion(iIdAsignacion, Txt_NombreAsignacion.Text);

                if (bExito)
                {
                    MessageBox.Show(sMensaje, "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pro_CargarListadoAsignaciones();
                }
                else
                {
                    MessageBox.Show(sMensaje, "Error al Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            pro_HabilitarControles(false);

            if (iIndiceFilaActual >= 0 && Dgv_Asignaciones.Rows.Count > 0)
            {
                pro_SincronizarFilaConCampos(iIndiceFilaActual);
            }
            else
            {
                pro_LimpiarCampos();
            }
        }

        private void Btn_Imprimir_Click(object sender, EventArgs e)
        {
            if (!bPermisoImprimir)
            {
                MessageBox.Show("No cuenta con permisos de impresión o generación de reportes.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Módulo de Reporteador / Crystal Reports preparado para enlace posterior.", "Impresión de Reportes", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Navegacion Botones

        private void pro_ActualizarBotonesNavegacion()
        {
            bool bHayRegistros = Dgv_Asignaciones.Rows.Count > 0 && !bEnEdicion;

            Btn_Inicio.Enabled = bHayRegistros && (iIndiceFilaActual > 0);
            Btn_Anterior.Enabled = bHayRegistros && (iIndiceFilaActual > 0);
            Btn_Siguiente.Enabled = bHayRegistros && (iIndiceFilaActual < Dgv_Asignaciones.Rows.Count - 1);
            Btn_Fin.Enabled = bHayRegistros && (iIndiceFilaActual < Dgv_Asignaciones.Rows.Count - 1);
        }

        private void Btn_Inicio_Click(object sender, EventArgs e)
        {
            if (Dgv_Asignaciones.Rows.Count > 0)
            {
                iIndiceFilaActual = 0;
                pro_SincronizarFilaConCampos(iIndiceFilaActual);
                pro_ActualizarBotonesNavegacion();
            }
        }

        private void Btn_Anterior_Click(object sender, EventArgs e)
        {
            if (iIndiceFilaActual > 0)
            {
                iIndiceFilaActual--;
                pro_SincronizarFilaConCampos(iIndiceFilaActual);
                pro_ActualizarBotonesNavegacion();
            }
        }

        private void Btn_Siguiente_Click(object sender, EventArgs e)
        {
            if (iIndiceFilaActual < Dgv_Asignaciones.Rows.Count - 1)
            {
                iIndiceFilaActual++;
                pro_SincronizarFilaConCampos(iIndiceFilaActual);
                pro_ActualizarBotonesNavegacion();
            }
        }

        private void Btn_Fin_Click(object sender, EventArgs e)
        {
            if (Dgv_Asignaciones.Rows.Count > 0)
            {
                iIndiceFilaActual = Dgv_Asignaciones.Rows.Count - 1;
                pro_SincronizarFilaConCampos(iIndiceFilaActual);
                pro_ActualizarBotonesNavegacion();
            }
        }

        private void Dgv_Asignaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !bEnEdicion)
            {
                iIndiceFilaActual = e.RowIndex;
                pro_SincronizarFilaConCampos(iIndiceFilaActual);
                pro_ActualizarBotonesNavegacion();
            }
        }

        

        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            if (bEnEdicion)
            {
                DialogResult dlgSalir = MessageBox.Show(
                    "Hay cambios sin guardar. ¿Está seguro de salir?",
                    "Confirmación de Salida",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (dlgSalir == DialogResult.No) return;
            }
            this.Close();
        }

        private void Frm_Asignacion_Load(object sender, EventArgs e)
        {
            //Verificación de sesión activa proveniente del Login
            if (!Capa_Controlador_Seguridad.Cls_Usuario_Conectado.bLoginEstado ||
                Capa_Controlador_Seguridad.Cls_Usuario_Conectado.iIdUsuario <= 0)
            {
                MessageBox.Show(
                    "No se ha detectado una sesión de usuario activa. Debe ingresar mediante el formulario de Login.",
                    "Acceso Denegado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                this.BeginInvoke(new Action(() => this.Close()));
                return;
            }

            //Configuración visual, maximizado y estandarización
            pro_ConfigurarAparienciaEstandar();
            pro_CentrarPaneles();

            //Consulta de permisos para el usuario logueado
            pro_ObtenerPermisosAplicacion();

            //Carga de combos de llaves foráneas
            pro_CargarCombosCatalogos();

            //Cargar registros en la tabla solo si cuenta con permiso de consulta
            if (bPermisoConsultar)
            {
                pro_CargarListadoAsignaciones();
            }
            else
            {
                MessageBox.Show(
                    "Su usuario no tiene permisos para consultar los registros de asignaciones.",
                    "Permiso Restringido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            // Estado inicial seguro de controles
            pro_HabilitarControles(false);
            pro_ActualizarBotonesNavegacion();
        }

        private void Dgv_Asignaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Btn_Refrescar_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Recargar los combos por si agregaron nuevos auditores, rubricas o estados
                pro_CargarCombosCatalogos();

                // 2. Recargar el listado completo de la base de datos
                if (bPermisoConsultar)
                {
                    pro_CargarListadoAsignaciones();
                }

                // 3. Devolver los controles al estado seguro de lectura
                pro_HabilitarControles(false);
                pro_ActualizarBotonesNavegacion();

                MessageBox.Show("Datos actualizados correctamente.", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al refrescar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_Ayuda_Click(object sender, EventArgs e)
        {
            try
            {
                // Ayudas compiladas con Html Help Workshop
                string sRutaAyuda = System.IO.Path.Combine(Application.StartupPath, "AyudaAsignaciones.chm");

                if (System.IO.File.Exists(sRutaAyuda))
                {
                    Help.ShowHelp(this, sRutaAyuda);
                }
                else
                {
                    MessageBox.Show("El archivo de ayuda técnica (.chm) se encuentra en desarrollo.", "Ayuda del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar el archivo de ayuda: " + ex.Message, "Error de Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Fin del código de Kenph Luna 9959-22-6326 en la fecha 16/10/2026
    }
}
