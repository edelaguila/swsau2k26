//Inicio de código de "Nombre del programador" con carné: "No_carné" en la fecha de: "11/11/2026"
using Capa_Controlador_Criterios;
using Capa_Controlador_Seguridad;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Capa_Vista_Criterios
{
    // Formulario transaccional de Criterios (tbl_criterios), aplicación 516.
    // Barra de botones con el mismo juego que el componente Navegador: Ingresar, Modificar, Guardar,
    // Cancelar, Eliminar, Consultar, Imprimir, Refrescar, Inicio, Anterior, Siguiente, Fin, Ayuda y Salir.
    // Los botones se habilitan según los permisos de Seguridad (aplicación 516, módulo 12) y las
    // operaciones de inserción, modificación y eliminación se registran en la bitácora.
    public partial class Frm_Criterio : Form
    {
        private const int I_ID_APLICACION = 516;                                // Código de aplicación (tbl_aplicacion)
        private const int I_ID_MODULO = 12;                                     // Módulo Planificacion y Rubricas

        // MODO PRUEBA: si no hay sesión iniciada (por ejemplo al abrir desde el MDI del Grupo 3 o desde
        // Ejecutable_Criterios), se habilitan todos los botones y se avisa en la barra de título.
        // Con sesión siempre se aplican los permisos reales. Cambiar a false para la entrega final.
        private static readonly bool B_PERMITIR_SIN_SESION = true;
        private const string S_RUTA_AYUDA = "Ayudas\\Ayuda_Criterios.chm";       // Relativa a la carpeta del ejecutable
        private static readonly Color gColorModulo = Color.FromArgb(255, 224, 0);  // Área 3 - Amarillo (ES-01)
        private static readonly Color gColorFilaAlterna = Color.FromArgb(255, 249, 214);

        private readonly Cls_Controlador_Criterio gControlador = new Cls_Controlador_Criterio();
        private int gIdSeleccionado = 0;
        private int gSumaRubrica = 0;        // % ya usado en la rúbrica, sin contar el criterio actual
        private bool gEnEdicion = false;
        private bool gModoNuevo = false;
        private bool gCargando = false;

        // Permisos del usuario conectado sobre la aplicación 516
        private bool gPermisoIngresar = false;
        private bool gPermisoConsultar = false;
        private bool gPermisoModificar = false;
        private bool gPermisoEliminar = false;
        private bool gPermisoImprimir = false;
        private bool gHaySesion = false;

        public Frm_Criterio()
        {
            InitializeComponent();
        }

        // ===================== Carga inicial =====================
        private void pro_frm_criterio_load(object sender, EventArgs e)
        {
            pro_configurar_controles();
            if (!fun_obtener_permisos())
            {
                BeginInvoke(new Action(Close));   // Sin sesión y sin modo prueba: no se permite el acceso
                return;
            }

            pro_cargar_rubricas();
            if (gPermisoConsultar)
            {
                pro_cargar_grilla(0, 0, null);
            }
            else
            {
                pro_limpiar_campos();
                MessageBox.Show("Su usuario no tiene permiso para consultar los criterios.", "Permiso restringido",
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
                Text = I_ID_APLICACION + " - Criterios  [MODO PRUEBA - sin sesión]";
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

        // Registra la acción en la bitácora de Seguridad (solo con sesión real; sin usuario no hay a quién registrar)
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
            Cbo_Importancia.Items.Clear();
            Cbo_Importancia.Items.AddRange(new object[] { "Alta", "Media", "Baja" });
            Nud_Porcentaje.Minimum = 1;
            Nud_Porcentaje.Maximum = 100;

            DataGridView dgvTabla = Dgv_Criterios;
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
            dgvTabla.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID", FillWeight = 7 });
            dgvTabla.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Rubrica", HeaderText = "Rúbrica", FillWeight = 22 });
            dgvTabla.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nombre", HeaderText = "Criterio", FillWeight = 25 });
            dgvTabla.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Porcentaje", HeaderText = "%", FillWeight = 7 });
            dgvTabla.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Importancia", HeaderText = "Importancia", FillWeight = 12 });
            dgvTabla.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Descripcion", HeaderText = "Descripción", FillWeight = 35 });
        }

        private void pro_cargar_rubricas()
        {
            gCargando = true;
            try
            {
                Cbo_Rubrica.DisplayMember = "Cmp_Nombre_Rubrica";
                Cbo_Rubrica.ValueMember = "Pk_Id_Rubrica";
                Cbo_Rubrica.DataSource = gControlador.fun_listar_rubricas();
                Cbo_Rubrica.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar las rúbricas: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { gCargando = false; }
        }

        // Recarga la grilla y deja seleccionado el registro indicado (por id, o por rúbrica + nombre
        // cuando es un registro recién insertado). Si no se encuentra, selecciona el primero.
        private void pro_cargar_grilla(int iIdBuscar, int iIdRubricaBuscar, string sNombreBuscar)
        {
            try
            {
                Dgv_Criterios.DataSource = null;
                Dgv_Criterios.DataSource = gControlador.fun_listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar la lista de criterios: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (Dgv_Criterios.Rows.Count == 0) { pro_limpiar_campos(); return; }

            int iFilaDestino = 0;
            for (int iFila = 0; iFila < Dgv_Criterios.Rows.Count; iFila++)
            {
                DataRow drFila = fun_fila_datos(iFila);
                if (drFila == null) continue;
                bool bCoincideId = iIdBuscar > 0 && Convert.ToInt32(drFila["Id"]) == iIdBuscar;
                bool bCoincideNombre = sNombreBuscar != null && Convert.ToInt32(drFila["IdRubrica"]) == iIdRubricaBuscar
                                       && string.Equals(drFila["Nombre"].ToString(), sNombreBuscar, StringComparison.OrdinalIgnoreCase);
                if (bCoincideId || bCoincideNombre) { iFilaDestino = iFila; break; }
            }
            pro_mostrar_fila(iFilaDestino);
        }

        private DataRow fun_fila_datos(int iFila)
        {
            if (iFila < 0 || iFila >= Dgv_Criterios.Rows.Count) return null;
            DataRowView drvFila = Dgv_Criterios.Rows[iFila].DataBoundItem as DataRowView;
            return drvFila?.Row;
        }

        // Muestra en los campos el registro de la fila indicada
        private void pro_mostrar_fila(int iFila)
        {
            DataRow drFila = fun_fila_datos(iFila);
            if (drFila == null) return;

            Dgv_Criterios.ClearSelection();
            Dgv_Criterios.Rows[iFila].Selected = true;
            Dgv_Criterios.CurrentCell = Dgv_Criterios.Rows[iFila].Cells[0];

            gCargando = true;
            try
            {
                gIdSeleccionado = Convert.ToInt32(drFila["Id"]);
                Cbo_Rubrica.SelectedValue = Convert.ToInt32(drFila["IdRubrica"]);
                Txt_Nombre.Text = drFila["Nombre"].ToString();
                int iPorcentaje = drFila["Porcentaje"] == DBNull.Value ? 1 : Convert.ToInt32(drFila["Porcentaje"]);
                Nud_Porcentaje.Value = Math.Max(Nud_Porcentaje.Minimum, Math.Min(Nud_Porcentaje.Maximum, iPorcentaje));
                string sImportancia = drFila["Importancia"].ToString();
                Cbo_Importancia.SelectedIndex = Cbo_Importancia.Items.IndexOf(sImportancia);
                Txt_Descripcion.Text = drFila["Descripcion"].ToString();
            }
            finally { gCargando = false; }

            pro_recalcular_suma_rubrica();
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
                Nud_Porcentaje.Value = Nud_Porcentaje.Minimum;
                Cbo_Importancia.SelectedIndex = -1;
            }
            finally { gCargando = false; }
            Erp_Validacion.Clear();
            pro_recalcular_suma_rubrica();
        }

        // ===================== Estado de controles =====================
        private void pro_establecer_modo(bool bEdicion)
        {
            gEnEdicion = bEdicion;

            Cbo_Rubrica.Enabled = bEdicion;
            Txt_Nombre.Enabled = bEdicion;
            Nud_Porcentaje.Enabled = bEdicion;
            Cbo_Importancia.Enabled = bEdicion;
            Txt_Descripcion.Enabled = bEdicion;
            Dgv_Criterios.Enabled = !bEdicion;

            if (!bEdicion) Erp_Validacion.Clear();
            pro_actualizar_botones();
        }

        private void pro_actualizar_botones()
        {
            bool bHayRegistro = gIdSeleccionado > 0;
            int iFilaActual = Dgv_Criterios.CurrentRow?.Index ?? -1;
            int iTotalFilas = Dgv_Criterios.Rows.Count;

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

        // ===================== Porcentaje de la rúbrica =====================
        private int fun_obtener_id_rubrica()
        {
            DataRowView drvFila = Cbo_Rubrica.SelectedItem as DataRowView;
            return drvFila == null ? 0 : Convert.ToInt32(drvFila["Pk_Id_Rubrica"]);
        }

        private void pro_recalcular_suma_rubrica()
        {
            gSumaRubrica = gControlador.fun_suma_porcentajes(fun_obtener_id_rubrica(), gIdSeleccionado);
            pro_mostrar_suma();
        }

        // Muestra el uso del 100% de la rúbrica; en rojo si se excede
        private void pro_mostrar_suma()
        {
            if (fun_obtener_id_rubrica() == 0) { Lbl_Suma.Text = ""; return; }

            int iEste = (int)Nud_Porcentaje.Value;
            int iTotal = gSumaRubrica + iEste;
            Lbl_Suma.Text = "Otros criterios de la rúbrica: " + gSumaRubrica + "%   |   Este criterio: " + iEste
                          + "%   |   Total: " + iTotal + "% de 100%" + (iTotal > 100 ? "  (excede el 100%)" : "");
            Lbl_Suma.ForeColor = iTotal > 100 ? Color.Firebrick : Color.DimGray;
        }

        private void pro_cbo_rubrica_cambiado(object sender, EventArgs e)
        {
            if (gCargando) return;
            Erp_Validacion.SetError(Cbo_Rubrica, "");
            pro_recalcular_suma_rubrica();
        }

        private void pro_nud_porcentaje_cambiado(object sender, EventArgs e)
        {
            if (gCargando) return;
            Erp_Validacion.SetError(Nud_Porcentaje, "");
            pro_mostrar_suma();
        }

        // ===================== Validaciones de campos =====================
        private void pro_txt_nombre_keypress(object sender, KeyPressEventArgs e)
        {
            if (!Cls_Controlador_Criterio.fun_caracter_valido_nombre(e.KeyChar))
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

            if (fun_obtener_id_rubrica() == 0)
            {
                Erp_Validacion.SetError(Cbo_Rubrica, "Seleccione una rúbrica.");
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

            if (gSumaRubrica + (int)Nud_Porcentaje.Value > 100)
            {
                Erp_Validacion.SetError(Nud_Porcentaje, "La suma de la rúbrica excede el 100%. Disponible: " + (100 - gSumaRubrica) + "%.");
                bValido = false;
            }

            if (Cbo_Importancia.SelectedIndex < 0)
            {
                Erp_Validacion.SetError(Cbo_Importancia, "Seleccione el nivel de importancia.");
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
            if (!fun_tiene_permiso(gPermisoIngresar, "ingresar criterios")) return;
            gModoNuevo = true;
            Dgv_Criterios.ClearSelection();
            pro_limpiar_campos();                                  // Conserva la rúbrica elegida
            int iDisponible = 100 - gSumaRubrica;
            if (iDisponible >= 1) Nud_Porcentaje.Value = iDisponible;
            pro_establecer_modo(true);
            if (fun_obtener_id_rubrica() == 0) Cbo_Rubrica.Focus(); else Txt_Nombre.Focus();
        }

        private void pro_btn_modificar_click(object sender, EventArgs e)
        {
            if (!fun_tiene_permiso(gPermisoModificar, "modificar criterios")) return;
            if (gIdSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un criterio de la tabla para modificarlo.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            gModoNuevo = false;
            pro_establecer_modo(true);
            Txt_Nombre.Focus();
        }

        private void pro_btn_guardar_click(object sender, EventArgs e)
        {
            if (gModoNuevo ? !fun_tiene_permiso(gPermisoIngresar, "ingresar criterios")
                           : !fun_tiene_permiso(gPermisoModificar, "modificar criterios")) return;
            if (!fun_validar_campos()) return;

            int iIdRubrica = fun_obtener_id_rubrica();
            string sNombre = Txt_Nombre.Text.Trim();
            var rResultado = gControlador.fun_guardar(
                gModoNuevo ? 0 : gIdSeleccionado,
                iIdRubrica,
                sNombre,
                (int)Nud_Porcentaje.Value,
                Cbo_Importancia.SelectedItem as string,
                Txt_Descripcion.Text);

            if (!rResultado.bOk)
            {
                MessageBox.Show(rResultado.sMensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show(rResultado.sMensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            pro_registrar_bitacora(gModoNuevo
                ? "Insertó el criterio '" + sNombre + "' en la rúbrica " + iIdRubrica + " (tbl_criterios)"
                : "Modificó el criterio " + gIdSeleccionado + " '" + sNombre + "' (tbl_criterios)");
            int iIdGuardado = gModoNuevo ? 0 : gIdSeleccionado;
            gEnEdicion = false;
            pro_cargar_grilla(iIdGuardado, iIdRubrica, sNombre);
            pro_establecer_modo(false);
        }

        private void pro_btn_cancelar_click(object sender, EventArgs e)
        {
            gEnEdicion = false;
            int iFila = Dgv_Criterios.CurrentRow?.Index ?? -1;
            if (!gModoNuevo && iFila >= 0) pro_mostrar_fila(iFila);
            else if (Dgv_Criterios.Rows.Count > 0) pro_mostrar_fila(0);
            else pro_limpiar_campos();
            pro_establecer_modo(false);
        }

        private void pro_btn_eliminar_click(object sender, EventArgs e)
        {
            if (gIdSeleccionado == 0) return;
            if (!fun_tiene_permiso(gPermisoEliminar, "eliminar criterios")) return;

            DialogResult drConfirmacion = MessageBox.Show(
                "¿Eliminar el criterio \"" + Txt_Nombre.Text + "\"?\nTambién se eliminarán sus descripciones por nivel.",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (drConfirmacion != DialogResult.Yes) return;

            int iIdEliminado = gIdSeleccionado;
            string sNombreEliminado = Txt_Nombre.Text;
            var rResultado = gControlador.fun_eliminar(iIdEliminado);
            MessageBox.Show(rResultado.sMensaje, rResultado.bOk ? "Información" : "Atención",
                MessageBoxButtons.OK, rResultado.bOk ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            if (rResultado.bOk)
            {
                pro_registrar_bitacora("Eliminó el criterio " + iIdEliminado + " '" + sNombreEliminado + "' (tbl_criterios)");
                pro_cargar_grilla(0, 0, null);
                pro_establecer_modo(false);
            }
        }

        // ===================== Componentes compartidos =====================
        private void pro_btn_consultar_click(object sender, EventArgs e)
        {
            if (!fun_tiene_permiso(gPermisoConsultar, "consultar criterios")) return;
            try
            {
                using (var frmConsulta = new Capa_Vista_Componente_Consultas.Frm_Consulta_Simple(new[] { "tbl_criterios" }))
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
            if (!fun_tiene_permiso(gPermisoImprimir, "imprimir reportes de criterios")) return;
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
            if (!fun_tiene_permiso(gPermisoConsultar, "consultar criterios")) return;
            int iIdActual = gIdSeleccionado;
            pro_cargar_rubricas();
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

        private void pro_frm_criterio_closing(object sender, FormClosingEventArgs e)
        {
            if (!gEnEdicion) return;
            DialogResult drSalir = MessageBox.Show("Hay cambios sin guardar. ¿Desea salir de todas formas?",
                "Confirmar salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (drSalir != DialogResult.Yes) e.Cancel = true;
        }

        // ===================== Navegación =====================
        private void pro_btn_inicio_click(object sender, EventArgs e)
        {
            if (Dgv_Criterios.Rows.Count > 0) pro_mostrar_fila(0);
        }

        private void pro_btn_anterior_click(object sender, EventArgs e)
        {
            int iFila = Dgv_Criterios.CurrentRow?.Index ?? 0;
            if (iFila > 0) pro_mostrar_fila(iFila - 1);
        }

        private void pro_btn_siguiente_click(object sender, EventArgs e)
        {
            int iFila = Dgv_Criterios.CurrentRow?.Index ?? -1;
            if (iFila < Dgv_Criterios.Rows.Count - 1) pro_mostrar_fila(iFila + 1);
        }

        private void pro_btn_fin_click(object sender, EventArgs e)
        {
            if (Dgv_Criterios.Rows.Count > 0) pro_mostrar_fila(Dgv_Criterios.Rows.Count - 1);
        }

        private void pro_dgv_criterios_cellclick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !gEnEdicion) pro_mostrar_fila(e.RowIndex);
        }
    }
}
//Fin del código de "Nombre del programador" con carné: "No_carné" en la fecha de: "11/11/2026"
