using Capa_Controlador_Graficas_Informes;
using Capa_Controlador_Seguridad;
using Capa_Modelo_Graficas_Informes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;



namespace Capa_Vista_Graficas_Informes
{
    public partial class FrmGraficasI : Form
    {
        private readonly ClsGraficaC Controlador = new ClsGraficaC();
        private readonly Cls_BitacoraControlador ctrlBitacora = new Cls_BitacoraControlador();
        private readonly ErrorProvider Erp_Grafica = new ErrorProvider();


        private const string sNOMBRE_APLICACION = "Graficas";
        private const string sNOMBRE_MODULO = "Informes";
        private const int iID_APLICACION_RESPALDO = 525;   

        private bool _canIngresar, _canConsultar, _canModificar, _canEliminar, _canImprimir;
        private int iIdAplicacion;


        private enum ModoFormulario { Consulta, Nuevo, Edicion }
        private ModoFormulario modoActual = ModoFormulario.Consulta;

        private ClsDatosGraficaM oDatosActuales = null;   
        private int iIdGraficaSeleccionada = 0;         

        public FrmGraficasI()
        {
            InitializeComponent();
        }

        private void FrmGraficasI_Load(object sender, EventArgs e)
        {
            if (!fun_AplicarPermisos())
            {
                this.Close();   
                return;
            }

            fun_CargarProyectos();

            Cbo_Tipo.DataSource = Controlador.fun_Obtener_Tipos();   // barras, pastel, linea
            Cbo_Tipo.SelectedItem = ClsGraficaC.sTIPO_BARRAS;         // por defecto: barras

            fun_ActualizarBotones();
        }

        private bool fun_AplicarPermisos()
        {
            int iIdUsuario = Cls_Usuario_Conectado.iIdUsuario;
            var ctrlUsuario = new Cls_Usuario_Controlador();
            var ctrlPermisoUsuario = new Cls_Permiso_Usuario_Controlador();

            iIdAplicacion = ctrlPermisoUsuario.ObtenerIdAplicacionPorNombre(sNOMBRE_APLICACION);
            if (iIdAplicacion <= 0) iIdAplicacion = iID_APLICACION_RESPALDO;
            int iIdModulo = ctrlPermisoUsuario.ObtenerIdModuloPorNombre(sNOMBRE_MODULO);
            int iIdPerfil = ctrlUsuario.ObtenerIdPerfilDeUsuario(iIdUsuario);

            var permisos = Cls_Aplicacion_Permisos.ObtenerPermisosCombinados(iIdUsuario, iIdAplicacion, iIdModulo, iIdPerfil);

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

        private void fun_ActualizarBotones()
        {
            bool bEditando = modoActual != ModoFormulario.Consulta;
            bool bHaySeleccion = iIdGraficaSeleccionada > 0;
            bool bHayGrafica = oDatosActuales != null;

            bool bCamposEditables = bEditando || (!bHaySeleccion && !bHayGrafica);

            Cbo_Proyecto.Enabled = modoActual != ModoFormulario.Edicion;
            Cbo_Rubrica.Enabled = modoActual != ModoFormulario.Edicion;
            Cbo_Tipo.Enabled = bCamposEditables;
            Txt_Descripcion.ReadOnly = !bCamposEditables;

            Btn_Generar.Enabled = modoActual == ModoFormulario.Edicion ? _canModificar : _canIngresar;
            Btn_Guardar.Enabled = bEditando && bHayGrafica &&
                                  (modoActual == ModoFormulario.Nuevo ? _canIngresar : _canModificar);
            Btn_Modificar.Enabled = !bEditando && bHaySeleccion && _canModificar;
            Btn_Eliminar.Enabled = !bEditando && bHaySeleccion && _canEliminar;
            Btn_Cancelar.Enabled = bEditando;
            Btn_Imprimir.Enabled = !bEditando && bHayGrafica && _canImprimir;

            Dgv_Graficas.Enabled = _canConsultar && !bEditando;
        }

        private void fun_CargarProyectos()
        {
            var resultado = Controlador.fun_Obtener_Proyectos();
            if (!resultado.bExito) { fun_MostrarMensaje(resultado); return; }

            Cbo_Proyecto.DisplayMember = "Proyecto";
            Cbo_Proyecto.ValueMember = "Pk_Id_Proyecto";
            Cbo_Proyecto.DataSource = resultado.dtDatos;
            Cbo_Proyecto.SelectedIndex = -1;
        }

        private void fun_CargarRubricas()
        {
            var resultado = Controlador.fun_Obtener_Rubricas(Cbo_Proyecto.SelectedValue);
            if (!resultado.bExito) { fun_MostrarMensaje(resultado); return; }

            Cbo_Rubrica.DisplayMember = "Cmp_Nombre_Rubrica";
            Cbo_Rubrica.ValueMember = "Pk_Id_Rubrica";
            Cbo_Rubrica.DataSource = resultado.dtDatos;
            Cbo_Rubrica.SelectedIndex = -1;
        }

        private void Cbo_Proyecto_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fun_LimpiarGrafica();
            fun_CargarRubricas();
            fun_CargarGraficasGuardadas();
        }

        private void Cbo_Rubrica_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fun_LimpiarGrafica();
            Dgv_Graficas.ClearSelection();
        }

        private void Cbo_Tipo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (oDatosActuales != null && modoActual != ModoFormulario.Consulta)
                fun_Dibujar(Cbo_Tipo.SelectedItem == null ? null : Cbo_Tipo.SelectedItem.ToString(), oDatosActuales);
        }

        private void Btn_Generar_Click(object sender, EventArgs e)
        {
            Erp_Grafica.Clear();
            var resultado = Controlador.fun_Generar_Datos(Cbo_Proyecto.SelectedValue, Cbo_Rubrica.SelectedValue);

            fun_MostrarErrores(resultado);
            if (!resultado.bExito)
            {
                fun_MostrarMensaje(resultado);
                return;
            }

            if (modoActual == ModoFormulario.Consulta)
            {
                if (iIdGraficaSeleccionada > 0) Txt_Descripcion.Clear(); 
                iIdGraficaSeleccionada = 0;
                Dgv_Graficas.ClearSelection();
                modoActual = ModoFormulario.Nuevo;
            }

            oDatosActuales = Controlador.fun_Construir_Datos(resultado.dtDatos, Cbo_Rubrica.SelectedValue);
            fun_Dibujar(Cbo_Tipo.SelectedItem == null ? null : Cbo_Tipo.SelectedItem.ToString(), oDatosActuales);
            fun_ActualizarBotones();
        }

        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            Erp_Grafica.Clear();
            ClsResultadoGrafica resultado;
            string sAccion;

            if (modoActual == ModoFormulario.Nuevo)
            {
                resultado = Controlador.fun_Guardar(Cbo_Proyecto.SelectedValue, Cbo_Tipo.SelectedItem,
                                                    Txt_Descripcion.Text, oDatosActuales);
                sAccion = "Guardó";
            }
            else if (modoActual == ModoFormulario.Edicion)
            {
                resultado = Controlador.fun_Actualizar(iIdGraficaSeleccionada.ToString(), Cbo_Proyecto.SelectedValue,
                                                       Cbo_Tipo.SelectedItem, Txt_Descripcion.Text, oDatosActuales);
                sAccion = "Modificó";
            }
            else return;

            fun_MostrarErrores(resultado);
            fun_MostrarMensaje(resultado);

            if (resultado.bExito)
            {
                fun_RegistrarBitacora(sAccion + " gráfica (" + Cbo_Tipo.Text + ") de la rúbrica "
                                      + oDatosActuales.Rubrica + " del proyecto: " + Cbo_Proyecto.Text);
                fun_LimpiarGrafica();
                fun_CargarGraficasGuardadas();
            }
        }

        private void Btn_Modificar_Click(object sender, EventArgs e)
        {
            if (iIdGraficaSeleccionada <= 0)
            {
                MessageBox.Show("Seleccione una gráfica de la lista para modificar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (oDatosActuales == null || oDatosActuales.IdRubrica <= 0)
            {
                MessageBox.Show("Esta gráfica es de una versión anterior y no tiene rúbrica asociada.\n" +
                                "Elimínela y genere una nueva.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            modoActual = ModoFormulario.Edicion;
            fun_ActualizarBotones();
            Txt_Descripcion.Focus();
        }

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            fun_LimpiarGrafica();
            Dgv_Graficas.ClearSelection();
        }

        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (iIdGraficaSeleccionada <= 0)
            {
                MessageBox.Show("Seleccione una gráfica de la lista para eliminar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmacion = MessageBox.Show(
                "¿Desea eliminar la gráfica seleccionada?\nEsta acción no se puede deshacer.",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmacion != DialogResult.Yes) return;

            var resultado = Controlador.fun_Eliminar(iIdGraficaSeleccionada.ToString());
            fun_MostrarMensaje(resultado);

            if (resultado.bExito)
            {
                fun_RegistrarBitacora("Eliminó gráfica del proyecto: " + Cbo_Proyecto.Text);
                fun_LimpiarGrafica();
                fun_CargarGraficasGuardadas();
            }
        }

        private void Btn_Imprimir_Click(object sender, EventArgs e)
        {
            if (oDatosActuales == null)
            {
                MessageBox.Show("Primero genere o seleccione una gráfica.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Cht_Grafica.Printing.PrintPreview();   
        }


        private void fun_CargarGraficasGuardadas()
        {
            if (!_canConsultar) return;

            var resultado = Controlador.fun_Obtener_Graficas(Cbo_Proyecto.SelectedValue);
            if (!resultado.bExito) { fun_MostrarMensaje(resultado); return; }

            Dgv_Graficas.DataSource = resultado.dtDatos;

            foreach (var sColumna in new[] { "Fk_id_proyecto", "datos_json_grafica" })
                if (Dgv_Graficas.Columns.Contains(sColumna))
                    Dgv_Graficas.Columns[sColumna].Visible = false;

            if (Dgv_Graficas.Columns.Contains("Pk_id_grafica"))
                Dgv_Graficas.Columns["Pk_id_grafica"].HeaderText = "No.";
            if (Dgv_Graficas.Columns.Contains("tipo_grafica"))
                Dgv_Graficas.Columns["tipo_grafica"].HeaderText = "Tipo";
            if (Dgv_Graficas.Columns.Contains("Rubrica"))
                Dgv_Graficas.Columns["Rubrica"].HeaderText = "Rúbrica";
            if (Dgv_Graficas.Columns.Contains("descripcion"))
                Dgv_Graficas.Columns["descripcion"].HeaderText = "Descripción";

            Dgv_Graficas.ClearSelection();
        }

        private void Dgv_Graficas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || modoActual != ModoFormulario.Consulta) return;
            DataGridViewRow fila = Dgv_Graficas.Rows[e.RowIndex];

            object oJson = fila.Cells["datos_json_grafica"].Value;
            ClsDatosGraficaM oDatos = Controlador.fun_Leer_Datos(oJson == null ? null : oJson.ToString());
            if (oDatos == null)
            {
                MessageBox.Show("Los datos guardados de esta gráfica no se pudieron leer.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            iIdGraficaSeleccionada = Convert.ToInt32(fila.Cells["Pk_id_grafica"].Value);
            object oDesc = fila.Cells["descripcion"].Value;
            Txt_Descripcion.Text = oDesc == null ? "" : oDesc.ToString();

            // Muestra en los combos el tipo y la rúbrica con que se hizo la gráfica
            string sTipo = fila.Cells["tipo_grafica"].Value.ToString();
            Cbo_Tipo.SelectedItem = sTipo;
            if (oDatos.IdRubrica > 0) Cbo_Rubrica.SelectedValue = oDatos.IdRubrica;
            else Cbo_Rubrica.SelectedIndex = -1;   // gráfica de la versión anterior, sin rúbrica

            oDatosActuales = oDatos;
            fun_Dibujar(sTipo, oDatos);
            fun_ActualizarBotones();
        }

        private void fun_Dibujar(string sTipo, ClsDatosGraficaM oDatos)
        {
            Cht_Grafica.Series.Clear();
            Cht_Grafica.Titles.Clear();
            Cht_Grafica.Titles.Add(oDatos.Titulo);

            Series serie = new Series("Calificación");
            switch (sTipo)
            {
                case ClsGraficaC.sTIPO_PASTEL: serie.ChartType = SeriesChartType.Pie; break;
                case ClsGraficaC.sTIPO_LINEA: serie.ChartType = SeriesChartType.Line; break;
                default: serie.ChartType = SeriesChartType.Column; break;   // barras
            }

            for (int i = 0; i < oDatos.Etiquetas.Count; i++)
                serie.Points.AddXY(oDatos.Etiquetas[i], oDatos.Valores[i]);

            serie.IsValueShownAsLabel = true;
            serie.LabelFormat = "0.##'%'";
            Cht_Grafica.Series.Add(serie);

            ChartArea area = Cht_Grafica.ChartAreas[0];
            area.AxisY.Minimum = 0;
            area.AxisY.Maximum = 100;                
            area.AxisY.Interval = 20;              
            area.AxisY.LabelStyle.Format = "0'%'";
            area.AxisX.Interval = 1;                 

            Cht_Grafica.Legends[0].Enabled = serie.ChartType == SeriesChartType.Pie;   
        }

        private void Lbl_Proyecto_Click(object sender, EventArgs e)
        {

        }

        private void fun_LimpiarGrafica()
        {
            Cht_Grafica.Series.Clear();
            Cht_Grafica.Titles.Clear();
            Txt_Descripcion.Clear();
            Erp_Grafica.Clear();
            oDatosActuales = null;
            iIdGraficaSeleccionada = 0;
            modoActual = ModoFormulario.Consulta;
            fun_ActualizarBotones();
        }

        private void fun_RegistrarBitacora(string sAccion)
        {
            try
            {
                ctrlBitacora.RegistrarAccion(Cls_Usuario_Conectado.iIdUsuario, iIdAplicacion, sAccion, true);
            }
            catch (Exception ex)
            {

                MessageBox.Show("La operación se realizó, pero no se pudo registrar en bitácora: " + ex.Message,
                    "Bitácora", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void fun_MostrarErrores(ClsResultadoGrafica resultado)
        {
            var mapa = new Dictionary<string, Control>
            {
                { ClsGraficaC.ClsCamposGrafica.sProyecto,    Cbo_Proyecto },
                { ClsGraficaC.ClsCamposGrafica.sRubrica,     Cbo_Rubrica },
                { ClsGraficaC.ClsCamposGrafica.sTipo,        Cbo_Tipo },
                { ClsGraficaC.ClsCamposGrafica.sDescripcion, Txt_Descripcion }
            };
            foreach (var kv in resultado.dicErrores)
            {
                Control ctrl;
                if (mapa.TryGetValue(kv.Key, out ctrl))
                    Erp_Grafica.SetError(ctrl, kv.Value);
            }
        }

        private void fun_MostrarMensaje(ClsResultadoGrafica resultado)
        {
            MessageBoxIcon icono =
                resultado.Gravedad == GravedadGrafica.Info ? MessageBoxIcon.Information :
                resultado.Gravedad == GravedadGrafica.Advertencia ? MessageBoxIcon.Warning :
                                                                    MessageBoxIcon.Error;
            MessageBox.Show(resultado.sMensaje, resultado.bExito ? "Éxito" : "Aviso",
                MessageBoxButtons.OK, icono);
        }
    }
}