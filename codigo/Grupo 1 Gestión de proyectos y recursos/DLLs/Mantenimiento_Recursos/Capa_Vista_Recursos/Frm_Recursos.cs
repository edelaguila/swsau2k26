using System;
using System.Data;
using System.Windows.Forms;
using Capa_Controlador_Recursos;

//Inicio de código de Nelson Godínez carné 0901-22-3550 en la fecha de: "08/10/2026"
namespace Capa_Vista_Recursos
{
    public partial class Frm_Recursos : Form
    {
        private readonly Cls_Controlador_Recursos gControlador = new Cls_Controlador_Recursos();
        private int iIdSeleccionado = 0; // 0 = ningún recurso seleccionado (modo nuevo)

        public Frm_Recursos()
        {
            InitializeComponent();
        }

        private void Frm_Recursos_Load(object sender, EventArgs e)
        {
            pro_cargar_proyectos();
            pro_cargar_recursos();
            pro_limpiar();
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
                Dgv_Recursos.DataSource = gControlador.fun_listar_recursos();
                Dgv_Recursos.Columns["Pk_Id_Recurso"].HeaderText = "Id";
                Dgv_Recursos.Columns["Fk_Id_Proyecto"].Visible = false;
                Dgv_Recursos.Columns["Cmp_Nombre_Proyecto"].HeaderText = "Proyecto";
                Dgv_Recursos.Columns["Cmp_Nombre_Recurso"].HeaderText = "Recurso";
                Dgv_Recursos.Columns["Cmp_Tipo_Recurso"].HeaderText = "Tipo";
                Dgv_Recursos.Columns["Cmp_Cantidad_Recurso"].HeaderText = "Cantidad";
                Dgv_Recursos.Columns["Cmp_Fecha_Registro_Recurso"].HeaderText = "Fecha de registro";
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los recursos: " + ex.Message,
                    "Recursos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Deja el formulario en modo "nuevo"
        private void pro_limpiar()
        {
            iIdSeleccionado = 0;
            Txt_Id.Text = "";
            Cbo_Proyecto.SelectedIndex = -1;
            Txt_Nombre.Text = "";
            Cbo_Tipo.Text = "";
            Nud_Cantidad.Value = 1;
            Dgv_Recursos.ClearSelection();

            Btn_Guardar.Enabled = true;
            Btn_Modificar.Enabled = false;
            Btn_Eliminar.Enabled = false;
            Cbo_Proyecto.Focus();
        }

        // Pasa los datos de la fila seleccionada a los controles
        private void Dgv_Recursos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = Dgv_Recursos.Rows[e.RowIndex];
            iIdSeleccionado = Convert.ToInt32(fila.Cells["Pk_Id_Recurso"].Value);
            Txt_Id.Text = iIdSeleccionado.ToString();
            Cbo_Proyecto.SelectedValue = Convert.ToInt32(fila.Cells["Fk_Id_Proyecto"].Value);
            Txt_Nombre.Text = Convert.ToString(fila.Cells["Cmp_Nombre_Recurso"].Value);
            Cbo_Tipo.Text = Convert.ToString(fila.Cells["Cmp_Tipo_Recurso"].Value);
            Nud_Cantidad.Value = Convert.ToDecimal(fila.Cells["Cmp_Cantidad_Recurso"].Value);

            Btn_Guardar.Enabled = false;
            Btn_Modificar.Enabled = true;
            Btn_Eliminar.Enabled = true;
        }

        private int fun_proyecto_seleccionado()
        {
            return Cbo_Proyecto.SelectedValue == null ? 0 : Convert.ToInt32(Cbo_Proyecto.SelectedValue);
        }

        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            string sError = gControlador.fun_guardar_recurso(
                fun_proyecto_seleccionado(), Txt_Nombre.Text, Cbo_Tipo.Text, (int)Nud_Cantidad.Value);

            if (sError != "")
            {
                MessageBox.Show(sError, "Recursos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Recurso guardado.", "Recursos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            pro_cargar_recursos();
            pro_limpiar();
        }

        private void Btn_Modificar_Click(object sender, EventArgs e)
        {
            string sError = gControlador.fun_modificar_recurso(
                iIdSeleccionado, fun_proyecto_seleccionado(), Txt_Nombre.Text, Cbo_Tipo.Text, (int)Nud_Cantidad.Value);

            if (sError != "")
            {
                MessageBox.Show(sError, "Recursos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Recurso modificado.", "Recursos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            pro_cargar_recursos();
            pro_limpiar();
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
        }

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            pro_limpiar();
        }
    }
}
//Fin del código de Nelson Godinez carné: 0901-22-3550 en la fecha de : "08/10/2026"