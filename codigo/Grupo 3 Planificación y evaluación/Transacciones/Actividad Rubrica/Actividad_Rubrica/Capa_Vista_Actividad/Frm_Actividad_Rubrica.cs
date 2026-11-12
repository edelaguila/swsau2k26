// Codigo empezado por: Maria Morales 0901-22-1226 el día 19/10/2026
using Capa_Controlador_Actividad_Rubrica;
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

namespace Capa_Vista_Actividad_Rubrica
{

    public partial class Frm_Actividad_Rubrica : Form
    {
        private const int I_ID_APLICACION = 519;                                // Código de aplicación (tbl_aplicacion)
        private const int I_ID_MODULO = 12;                                     // Módulo Planificacion y Rubricas


        private static readonly bool B_PERMITIR_SIN_SESION = true;
        private const string S_RUTA_AYUDA = "Ayudas\\Ayuda_Actividad_Rubrica.chm";   // Relativa a la carpeta del ejecutable
        private static readonly Color gColorModulo = Color.FromArgb(255, 224, 0);      // Área 3 - Amarillo (ES-01)
        private static readonly Color gColorFilaAlterna = Color.FromArgb(255, 249, 214);

        private readonly Cls_Controlador_Actividad_Rubrica gControlador = new Cls_Controlador_Actividad_Rubrica();
        private int gIdSeleccionado = 0;
        private bool gEnEdicion = false;
        private bool gModoNuevo = false;
        private bool gCargando = false;

        // Permisos del usuario conectado sobre la aplicación 519
        private bool gPermisoIngresar = false;
        private bool gPermisoConsultar = false;
        private bool gPermisoModificar = false;
        private bool gPermisoEliminar = false;
        private bool gPermisoImprimir = false;
        private bool gHaySesion = false;

        public Frm_Actividad_Rubrica()
        {
            InitializeComponent();
        }

        // ===================== Carga inicial =====================
        private void pro_frm_actividad_rubrica_load(object sender, EventArgs e)
        {
            pro_configurar_controles();
            if (!fun_obtener_permisos())
            {
                BeginInvoke(new Action(Close));   // Sin sesión y sin modo prueba: no se permite el acceso
                return;
            }

            pro_cargar_combos();
            if (gPermisoConsultar)
            {
                pro_cargar_grilla(0, 0, 0);
            }
            else
            {
                pro_limpiar_campos();
                MessageBox.Show("Su usuario no tiene permiso para consultar las actividades por rúbrica.", "Permiso restringido",
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
                Text = I_ID_APLICACION + " - Actividad Rúbrica";
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
            DataGridView dgvTabla = Dgv_Actividad_Rubrica;
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
            dgvTabla.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID", FillWeight = 8 });
            dgvTabla.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Actividad", HeaderText = "Actividad", FillWeight = 40 });
            dgvTabla.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Rubrica", HeaderText = "Rúbrica", FillWeight = 40 });
            dgvTabla.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "EstadoTexto", HeaderText = "Estado", FillWeight = 12 });

            // Las filas inactivas se muestran en gris
            dgvTabla.CellFormatting += pro_dgv_formato_estado;
        }

        private void pro_dgv_formato_estado(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataRow drFila = fun_fila_datos(e.RowIndex);
            if (drFila != null && !Convert.ToBoolean(drFila["Estado"]))
                e.CellStyle.ForeColor = Color.Gray;
        }

        private void pro_cargar_combos()
        {
            gCargando = true;
            try
            {
                Cbo_Actividad.DisplayMember = "Texto";
                Cbo_Actividad.ValueMember = "Id";
                Cbo_Actividad.DataSource = gControlador.fun_listar_actividades();
                Cbo_Actividad.SelectedIndex = -1;

                Cbo_Rubrica.DisplayMember = "Texto";
                Cbo_Rubrica.ValueMember = "Id";
                Cbo_Rubrica.DataSource = gControlador.fun_listar_rubricas();
                Cbo_Rubrica.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar las actividades o rúbricas: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { gCargando = false; }
            pro_mostrar_info();
        }

        // Recarga la grilla y deja seleccionado el registro indicado (por id, o por actividad + rúbrica
        // cuando es un registro recién insertado). Si no se encuentra, selecciona el primero.
        private void pro_cargar_grilla(int iIdBuscar, int iIdActividadBuscar, int iIdRubricaBuscar)
        {
            try
            {
                Dgv_Actividad_Rubrica.DataSource = null;
                Dgv_Actividad_Rubrica.DataSource = gControlador.fun_listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar la lista: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (Dgv_Actividad_Rubrica.Rows.Count == 0) { pro_limpiar_campos(); pro_actualizar_botones(); return; }

            int iFilaDestino = 0;
            for (int iFila = 0; iFila < Dgv_Actividad_Rubrica.Rows.Count; iFila++)
            {
                DataRow drFila = fun_fila_datos(iFila);
                if (drFila == null) continue;
                bool bCoincideId = iIdBuscar > 0 && Convert.ToInt32(drFila["Id"]) == iIdBuscar;
                bool bCoincideCombinacion = iIdActividadBuscar > 0
                                            && Convert.ToInt32(drFila["IdActividad"]) == iIdActividadBuscar
                                            && Convert.ToInt32(drFila["IdRubrica"]) == iIdRubricaBuscar;
                if (bCoincideId || bCoincideCombinacion) { iFilaDestino = iFila; break; }
            }
            pro_mostrar_fila(iFilaDestino);
        }

        private DataRow fun_fila_datos(int iFila)
        {
            if (iFila < 0 || iFila >= Dgv_Actividad_Rubrica.Rows.Count) return null;
            DataRowView drvFila = Dgv_Actividad_Rubrica.Rows[iFila].DataBoundItem as DataRowView;
            return drvFila?.Row;
        }

        // Muestra en los campos el registro de la fila indicada
        private void pro_mostrar_fila(int iFila)
        {
            DataRow drFila = fun_fila_datos(iFila);
            if (drFila == null) return;

            Dgv_Actividad_Rubrica.ClearSelection();
            Dgv_Actividad_Rubrica.Rows[iFila].Selected = true;
            Dgv_Actividad_Rubrica.CurrentCell = Dgv_Actividad_Rubrica.Rows[iFila].Cells[0];

            gCargando = true;
            try
            {
                gIdSeleccionado = Convert.ToInt32(drFila["Id"]);
                Cbo_Actividad.SelectedValue = Convert.ToInt32(drFila["IdActividad"]);
                Cbo_Rubrica.SelectedValue = Convert.ToInt32(drFila["IdRubrica"]);
                Chk_Estado.Checked = Convert.ToBoolean(drFila["Estado"]);
            }
            finally { gCargando = false; }

            pro_mostrar_info();
            pro_actualizar_botones();
        }

        private void pro_limpiar_campos()
        {
            gCargando = true;
            try
            {
                gIdSeleccionado = 0;
                Cbo_Actividad.SelectedIndex = -1;
                Cbo_Rubrica.SelectedIndex = -1;
                Chk_Estado.Checked = true;
            }
            finally { gCargando = false; }
            Erp_Validacion.Clear();
            pro_mostrar_info();
        }

        // ===================== Estado de controles =====================
        private void pro_establecer_modo(bool bEdicion)
        {
            gEnEdicion = bEdicion;

            Cbo_Actividad.Enabled = bEdicion;
            Cbo_Rubrica.Enabled = bEdicion;
            Chk_Estado.Enabled = bEdicion;
            Dgv_Actividad_Rubrica.Enabled = !bEdicion;

            if (!bEdicion) Erp_Validacion.Clear();
            pro_mostrar_info();
            pro_actualizar_botones();
        }

        private void pro_actualizar_botones()
        {
            bool bHayRegistro = gIdSeleccionado > 0;
            int iFilaActual = Dgv_Actividad_Rubrica.CurrentRow?.Index ?? -1;
            int iTotalFilas = Dgv_Actividad_Rubrica.Rows.Count;

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

        // ===================== Combos e información =====================
        private int fun_obtener_id(ComboBox cboCombo)
        {
            DataRowView drvFila = cboCombo.SelectedItem as DataRowView;
            return drvFila == null ? 0 : Convert.ToInt32(drvFila["Id"]);
        }

        private static string fun_info(ComboBox cboCombo)
        {
            DataRowView drvFila = cboCombo.SelectedItem as DataRowView;
            return drvFila == null ? "" : drvFila["Info"].ToString();
        }

        // Muestra el proyecto de la actividad y el cronograma de la rúbrica; en edición avisa si la combinación ya existe
        private void pro_mostrar_info()
        {
            string sActividad = fun_info(Cbo_Actividad);
            string sRubrica = fun_info(Cbo_Rubrica);
            string sTexto = sActividad;
            if (sRubrica.Length > 0) sTexto += (sTexto.Length > 0 ? "\n" : "") + sRubrica;

            bool bDuplicado = gEnEdicion && gControlador.fun_existe_combinacion(
                fun_obtener_id(Cbo_Actividad), fun_obtener_id(Cbo_Rubrica), gModoNuevo ? 0 : gIdSeleccionado);
            if (bDuplicado) sTexto += "\nEsta actividad ya está asignada a esa rúbrica.";

            Lbl_Info.Text = sTexto;
            Lbl_Info.ForeColor = bDuplicado ? Color.Firebrick : Color.DimGray;
        }

        private void pro_cbo_actividad_cambiado(object sender, EventArgs e)
        {
            if (gCargando) return;
            Erp_Validacion.SetError(Cbo_Actividad, "");
            pro_mostrar_info();
        }

        private void pro_cbo_rubrica_cambiado(object sender, EventArgs e)
        {
            if (gCargando) return;
            Erp_Validacion.SetError(Cbo_Rubrica, "");
            pro_mostrar_info();
        }

        // ===================== Validaciones de campos =====================
        private bool fun_validar_campos()
        {
            Erp_Validacion.Clear();
            bool bValido = true;

            if (fun_obtener_id(Cbo_Actividad) == 0)
            {
                Erp_Validacion.SetError(Cbo_Actividad, "Seleccione una actividad.");
                bValido = false;
            }

            if (fun_obtener_id(Cbo_Rubrica) == 0)
            {
                Erp_Validacion.SetError(Cbo_Rubrica, "Seleccione una rúbrica.");
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
            if (!fun_tiene_permiso(gPermisoIngresar, "ingresar actividades por rúbrica")) return;
            gModoNuevo = true;
            Dgv_Actividad_Rubrica.ClearSelection();
            pro_limpiar_campos();
            pro_establecer_modo(true);
            Cbo_Actividad.Focus();
        }

        private void pro_btn_modificar_click(object sender, EventArgs e)
        {
            if (!fun_tiene_permiso(gPermisoModificar, "modificar actividades por rúbrica")) return;
            if (gIdSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un registro de la tabla para modificarlo.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            gModoNuevo = false;
            pro_establecer_modo(true);
            Cbo_Actividad.Focus();
        }

        private void pro_btn_guardar_click(object sender, EventArgs e)
        {
            if (gModoNuevo ? !fun_tiene_permiso(gPermisoIngresar, "ingresar actividades por rúbrica")
                           : !fun_tiene_permiso(gPermisoModificar, "modificar actividades por rúbrica")) return;
            if (!fun_validar_campos()) return;

            int iIdActividad = fun_obtener_id(Cbo_Actividad);
            int iIdRubrica = fun_obtener_id(Cbo_Rubrica);
            bool bActivo = Chk_Estado.Checked;
            var rResultado = gControlador.fun_guardar(gModoNuevo ? 0 : gIdSeleccionado, iIdActividad, iIdRubrica, bActivo);

            if (!rResultado.bOk)
            {
                MessageBox.Show(rResultado.sMensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show(rResultado.sMensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            string sEstado = bActivo ? "Activo" : "Inactivo";
            pro_registrar_bitacora(gModoNuevo
                ? "Asignó la actividad " + iIdActividad + " a la rúbrica " + iIdRubrica + " (" + sEstado + ") (tbl_actividad_rubrica)"
                : "Modificó el registro " + gIdSeleccionado + ": actividad " + iIdActividad + ", rúbrica " + iIdRubrica
                  + " (" + sEstado + ") (tbl_actividad_rubrica)");
            int iIdGuardado = gModoNuevo ? 0 : gIdSeleccionado;
            gEnEdicion = false;
            pro_cargar_grilla(iIdGuardado, iIdActividad, iIdRubrica);
            pro_establecer_modo(false);
        }

        private void pro_btn_cancelar_click(object sender, EventArgs e)
        {
            gEnEdicion = false;
            int iFila = Dgv_Actividad_Rubrica.CurrentRow?.Index ?? -1;
            if (!gModoNuevo && iFila >= 0) pro_mostrar_fila(iFila);
            else if (Dgv_Actividad_Rubrica.Rows.Count > 0) pro_mostrar_fila(0);
            else pro_limpiar_campos();
            pro_establecer_modo(false);
        }

        private void pro_btn_eliminar_click(object sender, EventArgs e)
        {
            if (gIdSeleccionado == 0) return;
            if (!fun_tiene_permiso(gPermisoEliminar, "eliminar actividades por rúbrica")) return;

            DialogResult drConfirmacion = MessageBox.Show(
                "¿Eliminar la asignación de \"" + Cbo_Actividad.Text + "\" a \"" + Cbo_Rubrica.Text + "\"?",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (drConfirmacion != DialogResult.Yes) return;

            int iIdEliminado = gIdSeleccionado;
            var rResultado = gControlador.fun_eliminar(iIdEliminado);
            MessageBox.Show(rResultado.sMensaje, rResultado.bOk ? "Información" : "Atención",
                MessageBoxButtons.OK, rResultado.bOk ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            if (rResultado.bOk)
            {
                pro_registrar_bitacora("Eliminó el registro " + iIdEliminado + " (tbl_actividad_rubrica)");
                pro_cargar_grilla(0, 0, 0);
                pro_establecer_modo(false);
            }
        }

        // ===================== Componentes compartidos =====================
        private void pro_btn_consultar_click(object sender, EventArgs e)
        {
            if (!fun_tiene_permiso(gPermisoConsultar, "consultar actividades por rúbrica")) return;
            try
            {
                using (var frmConsulta = new Capa_Vista_Componente_Consultas.Frm_Consulta_Simple(new[] { "tbl_actividad_rubrica" }))
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
            if (!fun_tiene_permiso(gPermisoImprimir, "imprimir reportes de actividades por rúbrica")) return;
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
            if (!fun_tiene_permiso(gPermisoConsultar, "consultar actividades por rúbrica")) return;
            int iIdActual = gIdSeleccionado;
            pro_cargar_combos();
            pro_cargar_grilla(iIdActual, 0, 0);
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

        private void pro_frm_actividad_rubrica_closing(object sender, FormClosingEventArgs e)
        {
            if (!gEnEdicion) return;
            DialogResult drSalir = MessageBox.Show("Hay cambios sin guardar. ¿Desea salir de todas formas?",
                "Confirmar salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (drSalir != DialogResult.Yes) e.Cancel = true;
        }

        // ===================== Navegación =====================
        private void pro_btn_inicio_click(object sender, EventArgs e)
        {
            if (Dgv_Actividad_Rubrica.Rows.Count > 0) pro_mostrar_fila(0);
        }

        private void pro_btn_anterior_click(object sender, EventArgs e)
        {
            int iFila = Dgv_Actividad_Rubrica.CurrentRow?.Index ?? 0;
            if (iFila > 0) pro_mostrar_fila(iFila - 1);
        }

        private void pro_btn_siguiente_click(object sender, EventArgs e)
        {
            int iFila = Dgv_Actividad_Rubrica.CurrentRow?.Index ?? -1;
            if (iFila < Dgv_Actividad_Rubrica.Rows.Count - 1) pro_mostrar_fila(iFila + 1);
        }

        private void pro_btn_fin_click(object sender, EventArgs e)
        {
            if (Dgv_Actividad_Rubrica.Rows.Count > 0) pro_mostrar_fila(Dgv_Actividad_Rubrica.Rows.Count - 1);
        }

        private void pro_dgv_actividad_rubrica_cellclick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !gEnEdicion) pro_mostrar_fila(e.RowIndex);
        }
    }
}
// Codigo terminado por: Maria Morales 0901-22-1226 el día 19/10/2026