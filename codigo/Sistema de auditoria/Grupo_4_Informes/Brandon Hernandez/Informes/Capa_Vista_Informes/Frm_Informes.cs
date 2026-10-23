// Brandon Hernandez 0901-22-9663 18/10/2026 - Frm_Informes
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Capa_Controlador_Informes;
using Capa_Controlador_Seguridad;


namespace Capa_Vista_Informes
{
    public partial class Frm_Informes : Form
    {
        private readonly Cls_InformesControlador Controlador = new Cls_InformesControlador();
        private readonly Cls_BitacoraControlador ctrlBitacora = new Cls_BitacoraControlador();
        private readonly ErrorProvider Erp_Informe = new ErrorProvider();

        // ⚠ Ajustar a los nombres/IDs reales registrados en el componente de Seguridad
        private const string sNOMBRE_APLICACION = "Informes";
        private const string sNOMBRE_MODULO = "Informes";
        private const int iID_APLICACION_RESPALDO = 522;   // ID fijo si la búsqueda por nombre falla
        private const int iESTADO_ELIMINADO = 2;         // ID de "Eliminado" en tbl_estado_informe

        private bool _canIngresar, _canConsultar, _canModificar, _canEliminar, _canImprimir;
        private int iIdAplicacion;

        private enum ModoFormulario { Consulta, Nuevo, Edicion }
        private ModoFormulario modoActual = ModoFormulario.Consulta;
        private int iIdInformeSeleccionado = 0;

        public Frm_Informes()
        {
            InitializeComponent();
            this.Load += Frm_Informes_Load;
        }

        private void Frm_Informes_Load(object sender, EventArgs e)
        {
            if (!fun_aplicarPermisos())
            {
                this.Close();   // sin permisos no se abre
                return;
            }

            fun_cargar_Proyectos();
            fun_cargar_Auditores();
            fun_cargar_EstadosInforme();
            if (_canConsultar) fun_cargar_Informes();

            fun_EstablecerModo(ModoFormulario.Consulta);
        }

        // ===================== PERMISOS =====================

        private bool fun_aplicarPermisos()
        {
            int idUsuario = Cls_Usuario_Conectado.iIdUsuario;
            var usuarioCtrl = new Cls_Usuario_Controlador();
            var permisoUsuario = new Cls_Permiso_Usuario_Controlador();

            iIdAplicacion = permisoUsuario.ObtenerIdAplicacionPorNombre(sNOMBRE_APLICACION);
            if (iIdAplicacion <= 0) iIdAplicacion = iID_APLICACION_RESPALDO;
            int idModulo = permisoUsuario.ObtenerIdModuloPorNombre(sNOMBRE_MODULO);
            int idPerfil = usuarioCtrl.ObtenerIdPerfilDeUsuario(idUsuario);

            var permisos = Cls_Aplicacion_Permisos.ObtenerPermisosCombinados(idUsuario, iIdAplicacion, idModulo, idPerfil);

            _canIngresar = permisos.ingresar;
            _canConsultar = permisos.consultar;
            _canModificar = permisos.modificar;
            _canEliminar = permisos.eliminar;
            _canImprimir = permisos.imprimir;

            if (!_canIngresar && !_canConsultar && !_canModificar && !_canEliminar && !_canImprimir)
            {
                MessageBox.Show("El usuario no tiene permisos asignados para esta aplicación.",
                                "Permisos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // ===================== MODO + PERMISOS =====================

        private void fun_EstablecerModo(ModoFormulario modo)
        {
            modoActual = modo;
            bool bEditando = modo != ModoFormulario.Consulta;
            bool bHaySeleccion = iIdInformeSeleccionado > 0;

            // Campos: solo editables en Nuevo/Edición
            Txt_Titulo.Enabled = bEditando;
            Cbo_Proyecto.Enabled = bEditando;
            Cbo_Estado.Enabled = bEditando;
            Cbo_Auditores.Enabled = bEditando;

            // Botones: el modo decide, el permiso limita
            Btn_Guardar.Enabled = bEditando;
            Btn_Insertar.Enabled = !bEditando && _canIngresar;
            Btn_Modificar.Enabled = !bEditando && bHaySeleccion && _canModificar;
            Btn_Eliminar.Enabled = !bEditando && bHaySeleccion && _canEliminar;
            Btn_Consultar.Enabled = !bEditando && _canConsultar;
            Btn_Imprimir.Enabled = !bEditando && _canImprimir;

            Dgv_Informes.Enabled = !bEditando;
        }

        // ===================== BOTONES =====================

        private void Btn_Insertar_Click(object sender, EventArgs e)
        {
            fun_limpiar_campos();
            fun_EstablecerModo(ModoFormulario.Nuevo);
            Txt_Titulo.Focus();
        }

        private void Btn_Modificar_Click(object sender, EventArgs e)
        {
            if (iIdInformeSeleccionado <= 0)
            {
                MessageBox.Show("Seleccione un informe de la lista para modificar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            fun_EstablecerModo(ModoFormulario.Edicion);
            Txt_Titulo.Focus();
        }

        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            Erp_Informe.Clear();
            Cls_ResultadoOperacion resultado;
            string sAccion;

            if (modoActual == ModoFormulario.Nuevo)
            {
                resultado = Controlador.fun_Insertar(Txt_Titulo.Text,
                    Cbo_Proyecto.SelectedValue, Cbo_Estado.SelectedValue, Cbo_Auditores.SelectedValue);
                sAccion = "Guardó informe";
            }
            else if (modoActual == ModoFormulario.Edicion)
            {
                resultado = Controlador.fun_Actualizar(iIdInformeSeleccionado.ToString(), Txt_Titulo.Text,
                    Cbo_Proyecto.SelectedValue, Cbo_Estado.SelectedValue, Cbo_Auditores.SelectedValue);
                sAccion = "Modificó informe";
            }
            
            else return;

            fun_MostrarErrores(resultado);
            fun_MostrarMensaje(resultado);

            if (resultado.bExito)
            {
                fun_RegistrarBitacora($"{sAccion}: {Txt_Titulo.Text.Trim()}");
                fun_RecargarYReiniciar();
            }
        }

        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (iIdInformeSeleccionado <= 0)
            {
                MessageBox.Show("Seleccione un informe de la lista para eliminar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sTitulo = Txt_Titulo.Text.Trim();
            var confirmacion = MessageBox.Show(
                $"¿Desea eliminar el informe \"{sTitulo}\"?\nEl registro se conservará con estado eliminado.",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmacion != DialogResult.Yes) return;

            var resultado = Controlador.fun_Cambiar_Estado(iIdInformeSeleccionado.ToString(), iESTADO_ELIMINADO);
            fun_MostrarMensaje(resultado);

            if (resultado.bExito)
            {
                fun_RegistrarBitacora($"Eliminó informe: {sTitulo}");
                fun_RecargarYReiniciar();
            }
        }

        private void Btn_Consultar_Click(object sender, EventArgs e)
        {
            
        }

        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ===================== GRID =====================

   

        private void fun_cargar_Informes()
        {
            var resultado = Controlador.fun_Obtener_Informes();
            if (!resultado.bExito) { fun_MostrarMensaje(resultado); return; }

            Dgv_Informes.DataSource = resultado.dtDatos;

            foreach (var sColumna in new[] { "Fk_id_proyecto", "Fk_id_estado_informe", "Fk_id_auditor" })
                if (Dgv_Informes.Columns.Contains(sColumna))
                    Dgv_Informes.Columns[sColumna].Visible = false;

            Dgv_Informes.Columns["fecha_creacion"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            Dgv_Informes.Columns["fecha_actualizacion"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
        }

        // ===================== COMBOS =====================

        private void fun_CargarCombo(ComboBox cbo, Cls_ResultadoOperacion resultado,
                                     string sDisplay, string sValue, string sDescripcion)
        {
            if (!resultado.bExito)
            {
                MessageBox.Show(resultado.sMensaje, "Error al cargar " + sDescripcion,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            cbo.DisplayMember = sDisplay;
            cbo.ValueMember = sValue;
            cbo.DataSource = resultado.dtDatos;
            cbo.SelectedIndex = -1;
        }

        private void fun_cargar_Proyectos() =>
            fun_CargarCombo(Cbo_Proyecto, Controlador.fun_Obtener_Proyectos(),
                            "Proyecto", "Pk_id_proyecto", "proyectos");

        private void fun_cargar_Auditores() =>
            fun_CargarCombo(Cbo_Auditores, Controlador.fun_Obtener_Auditores(),
                            "Auditor", "Pk_id_auditor", "auditores");

        private void fun_cargar_EstadosInforme() =>
            fun_CargarCombo(Cbo_Estado, Controlador.fun_Obtener_Estados_Informe(),
                            "Cmp_Nombre_Estado_Informe", "Pk_id_estado_informe", "estados de informe");

        // ===================== AUXILIARES =====================

        private void fun_limpiar_campos()
        {
            iIdInformeSeleccionado = 0;
            Txt_Titulo.Clear();
            Cbo_Auditores.SelectedIndex = -1;
            Cbo_Estado.SelectedIndex = -1;
            Cbo_Proyecto.SelectedIndex = -1;
            Erp_Informe.Clear();
        }

        private void Btn_Imprimir_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Ayuda_Click(object sender, EventArgs e)
        {

        }

        private void Dgv_Informes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || modoActual != ModoFormulario.Consulta) return;

            DataGridViewRow fila = Dgv_Informes.Rows[e.RowIndex];
            iIdInformeSeleccionado = Convert.ToInt32(fila.Cells["Pk_id_informe"].Value);

            Txt_Titulo.Text = fila.Cells["titulo_informe"].Value?.ToString();
            Cbo_Proyecto.SelectedValue = fila.Cells["Fk_id_proyecto"].Value;
            Cbo_Estado.SelectedValue = fila.Cells["Fk_id_estado_informe"].Value;
            Cbo_Auditores.SelectedValue = fila.Cells["Fk_id_auditor"].Value;

            fun_EstablecerModo(ModoFormulario.Consulta);   // reevalúa Modificar/Eliminar
        }

        private void e(object sender, EventArgs e)
        {

        }

        private void fun_RecargarYReiniciar()
        {
            if (_canConsultar) fun_cargar_Informes();
            fun_limpiar_campos();
            fun_EstablecerModo(ModoFormulario.Consulta);
        }

        private void fun_RegistrarBitacora(string sAccion)
        {
            try
            {
                ctrlBitacora.RegistrarAccion(Cls_Usuario_Conectado.iIdUsuario, iIdAplicacion, sAccion, true);
            }
            catch (Exception ex)
            {
                // La operación ya se hizo; solo se avisa que no quedó en bitácora
                MessageBox.Show("La operación se realizó, pero no se pudo registrar en bitácora: " + ex.Message,
                    "Bitácora", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void fun_MostrarErrores(Cls_ResultadoOperacion resultado)
        {
            var mapa = new Dictionary<string, Control>
            {
                { nameof(Cls_InformesControlador.Cls_CamposInforme.sTitulo),     Txt_Titulo },
                { nameof(Cls_InformesControlador.Cls_CamposInforme.sProyecto),      Cbo_Proyecto },
                { nameof(Cls_InformesControlador.Cls_CamposInforme.sEstado), Cbo_Estado },
                { nameof(Cls_InformesControlador.Cls_CamposInforme.sAuditor),       Cbo_Auditores }
            };
            foreach (var kv in resultado.dicErrores)
                if (mapa.TryGetValue(kv.Key, out Control ctrl))
                    Erp_Informe.SetError(ctrl, kv.Value);
        }

        private void fun_MostrarMensaje(Cls_ResultadoOperacion resultado)
        {
            MessageBoxIcon icono =
                resultado.Gravedad == GravedadMensaje.Info ? MessageBoxIcon.Information :
                resultado.Gravedad == GravedadMensaje.Advertencia ? MessageBoxIcon.Warning :
                                                                    MessageBoxIcon.Error;
            MessageBox.Show(resultado.sMensaje, resultado.bExito ? "Éxito" : "Aviso",
                MessageBoxButtons.OK, icono);
        }
    }
}