using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Capa_Controlador_Recursos;

//Inicio de código de Nelson Godínez carné 0901-22-3550 en la fecha de: "08/10/2026"
namespace Capa_Vista_Recursos
{

    public partial class Frm_Recursos : Form
    {
        private readonly Cls_Controlador_Recursos gControlador = new Cls_Controlador_Recursos();
        private DataTable gDtsRecursos = new DataTable();
        private int iIdSeleccionado = 0;   // 0 = ningún recurso seleccionado
        private string sModo = "";         // "" = consulta, "N" = nuevo, "E" = edición

        // Ruta del archivo de ayuda, relativa a la raíz del repositorio
        private const string sRUTA_AYUDA = @"ayuda\Grupo 1\Recursos\Ayuda_Recursos.chm";
        private const string sPAGINA_AYUDA = "Ayuda_Recursos.html";

        public Frm_Recursos()
        {
            InitializeComponent();
        }

        private void Frm_Recursos_Load(object sender, EventArgs e)
        {
            pro_cargar_proyectos();
            pro_cargar_recursos();
            pro_limpiar();
            pro_estado_botones();
        }

    
        // Llena el combo con los proyectos existentes
        private void pro_cargar_proyectos()
        {
            try
            {
                Cbo_Proyecto.DataSource = gControlador.fun_listar_proyectos();
                Cbo_Proyecto.DisplayMember = "Cmp_Nombre_Proyecto";
                Cbo_Proyecto.ValueMember = "Pk_Id_Proyecto";
                Cbo_Proyecto.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los proyectos: " + ex.Message,
                    "Recursos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Llena la cuadrícula con los recursos
        private void pro_cargar_recursos()
        {
            try
            {
                gDtsRecursos = gControlador.fun_listar_recursos();
                Dgv_Recursos.DataSource = gDtsRecursos.DefaultView;
                Dgv_Recursos.Columns["Pk_Id_Recurso"].HeaderText = "Id";
                Dgv_Recursos.Columns["Fk_Id_Proyecto"].Visible = false;
                Dgv_Recursos.Columns["Cmp_Nombre_Proyecto"].HeaderText = "Proyecto";
                Dgv_Recursos.Columns["Cmp_Nombre_Recurso"].HeaderText = "Recurso";
                Dgv_Recursos.Columns["Cmp_Tipo_Recurso"].HeaderText = "Tipo";
                Dgv_Recursos.Columns["Cmp_Cantidad_Recurso"].HeaderText = "Cantidad";
                Dgv_Recursos.Columns["Cmp_Fecha_Registro_Recurso"].HeaderText = "Fecha de registro";
                Dgv_Recursos.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los recursos: " + ex.Message,
                    "Recursos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Vacía los campos y quita la selección
        private void pro_limpiar()
        {
            iIdSeleccionado = 0;
            Txt_Id.Text = "";
            Cbo_Proyecto.SelectedIndex = -1;
            Txt_Nombre.Text = "";
            Cbo_Tipo.Text = "";
            Nud_Cantidad.Value = 1;
            Dgv_Recursos.ClearSelection();
        }

        // Habilita campos y botones según el modo, igual que el Navegador:
        // en consulta solo se navega; al ingresar o modificar solo se puede guardar o cancelar
        private void pro_estado_botones()
        {
            bool bEditando = sModo != "";
            bool bSeleccionado = iIdSeleccionado > 0;

            Gpb_Datos.Enabled = bEditando;
            Dgv_Recursos.Enabled = !bEditando;
            Txt_Buscar.Enabled = !bEditando;

            Btn_Ingresar.Enabled = !bEditando;
            Btn_Modificar.Enabled = !bEditando && bSeleccionado;
            Btn_Guardar.Enabled = bEditando;
            Btn_Cancelar.Enabled = bEditando;
            Btn_Eliminar.Enabled = !bEditando && bSeleccionado;
            Btn_Consultar.Enabled = !bEditando;
            Btn_Imprimir.Enabled = !bEditando;
            Btn_Refrescar.Enabled = !bEditando;
            Btn_Ayuda.Enabled = true;
            Btn_Salir.Enabled = true;
        }

        // Pasa los datos de la fila seleccionada a los controles
        private void Dgv_Recursos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || sModo != "") return;

            DataGridViewRow fila = Dgv_Recursos.Rows[e.RowIndex];
            iIdSeleccionado = Convert.ToInt32(fila.Cells["Pk_Id_Recurso"].Value);
            Txt_Id.Text = iIdSeleccionado.ToString();
            Cbo_Proyecto.SelectedValue = Convert.ToInt32(fila.Cells["Fk_Id_Proyecto"].Value);
            Txt_Nombre.Text = Convert.ToString(fila.Cells["Cmp_Nombre_Recurso"].Value);
            Cbo_Tipo.Text = Convert.ToString(fila.Cells["Cmp_Tipo_Recurso"].Value);
            Nud_Cantidad.Value = Convert.ToDecimal(fila.Cells["Cmp_Cantidad_Recurso"].Value);

            pro_estado_botones();
        }

        private int fun_proyecto_seleccionado()
        {
            return Cbo_Proyecto.SelectedValue == null ? 0 : Convert.ToInt32(Cbo_Proyecto.SelectedValue);
        }

        private void Btn_Ingresar_Click(object sender, EventArgs e)
        {
            pro_limpiar();
            sModo = "N";
            pro_estado_botones();
            Cbo_Proyecto.Focus();
        }

        private void Btn_Modificar_Click(object sender, EventArgs e)
        {
            if (iIdSeleccionado <= 0)
            {
                MessageBox.Show("Seleccione un recurso para modificar.", "Recursos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sModo = "E";
            pro_estado_botones();
            Txt_Nombre.Focus();
        }

        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            string sError;
            if (sModo == "N")
            {
                sError = gControlador.fun_guardar_recurso(
                    fun_proyecto_seleccionado(), Txt_Nombre.Text, Cbo_Tipo.Text, (int)Nud_Cantidad.Value);
            }
            else
            {
                sError = gControlador.fun_modificar_recurso(
                    iIdSeleccionado, fun_proyecto_seleccionado(), Txt_Nombre.Text, Cbo_Tipo.Text, (int)Nud_Cantidad.Value);
            }

            if (sError != "")
            {
                MessageBox.Show(sError, "Recursos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show(sModo == "N" ? "Recurso guardado." : "Recurso modificado.",
                "Recursos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            sModo = "";
            pro_cargar_recursos();
            pro_limpiar();
            pro_estado_botones();
        }

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            sModo = "";
            pro_limpiar();
            pro_estado_botones();
        }

        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (iIdSeleccionado <= 0) return;

            DialogResult resultado = MessageBox.Show("¿Eliminar el recurso seleccionado?",
                "Recursos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado != DialogResult.Yes) return;

            string sError = gControlador.fun_eliminar_recurso(iIdSeleccionado);
            if (sError != "")
            {
                MessageBox.Show(sError, "Recursos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            pro_cargar_recursos();
            pro_limpiar();
            pro_estado_botones();
        }

        // Filtra la cuadrícula por proyecto, nombre o tipo con el texto de búsqueda
        private void Btn_Consultar_Click(object sender, EventArgs e)
        {
            string sTexto = Txt_Buscar.Text.Trim();
            if (sTexto == "")
            {
                gDtsRecursos.DefaultView.RowFilter = "";
                Txt_Buscar.Focus();
                return;
            }

            // Escapa los caracteres especiales del filtro de DataView
            string sSeguro = sTexto.Replace("'", "''").Replace("[", "[[]").Replace("*", "[*]").Replace("%", "[%]");
            gDtsRecursos.DefaultView.RowFilter = string.Format(
                "Cmp_Nombre_Proyecto LIKE '%{0}%' OR Cmp_Nombre_Recurso LIKE '%{0}%' OR Cmp_Tipo_Recurso LIKE '%{0}%'",
                sSeguro);

            pro_limpiar();
            pro_estado_botones();
            if (gDtsRecursos.DefaultView.Count == 0)
            {
                MessageBox.Show("No se encontraron recursos con ese texto.", "Recursos",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Txt_Buscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Btn_Consultar_Click(sender, e);
            }
        }

        // Abre el reporte de Crystal Reports
        private void Btn_Imprimir_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_Reporte_Recursos frmReporte = new Frm_Reporte_Recursos();
                frmReporte.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo abrir el reporte: " + ex.Message, "Recursos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Quita el filtro y vuelve a leer los datos de la BD
        private void Btn_Refrescar_Click(object sender, EventArgs e)
        {
            Txt_Buscar.Text = "";
            pro_cargar_proyectos();
            pro_cargar_recursos();
            pro_limpiar();
            pro_estado_botones();
        }

        // Abre la ayuda (.chm) buscando la carpeta "ayuda" hacia arriba desde el ejecutable
        private void Btn_Ayuda_Click(object sender, EventArgs e)
        {
            try
            {
                string sRutaEncontrada = null;
                DirectoryInfo dir = new DirectoryInfo(Application.StartupPath);

                for (int i = 0; i < 10 && dir != null; i++, dir = dir.Parent)
                {
                    string sCandidata = Path.Combine(dir.FullName, sRUTA_AYUDA);
                    if (File.Exists(sCandidata))
                    {
                        sRutaEncontrada = sCandidata;
                        break;
                    }
                }

                if (sRutaEncontrada == null)
                {
                    MessageBox.Show("No se encontró el archivo de ayuda:\n" + sRUTA_AYUDA, "Ayuda",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Help.ShowHelp(this, sRutaEncontrada, HelpNavigator.Topic, sPAGINA_AYUDA);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir la ayuda:\n" + ex.Message, "Ayuda",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
//Fin del código de Nelson Godínez carné: 0901-22-3550 en la fecha de : "08/10/2026"
