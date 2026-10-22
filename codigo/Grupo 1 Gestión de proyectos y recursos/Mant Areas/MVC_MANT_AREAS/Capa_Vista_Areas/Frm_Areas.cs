using Capa_Controlador_Areas;
using System;
using System.Data;
using System.Windows.Forms;

namespace Capa_Vista_Areas
{
    public partial class Frm_Areas : Form
    {
        private Cls_Controlador_Areas cn = new Cls_Controlador_Areas();

        public Frm_Areas()
        {
            InitializeComponent();
        }

        private void Frm_Areas_Load(object sender, EventArgs e)
        {
            funcCargarTabla();
            funcCargarProyectos();
            rdb_activo.Checked = true;
        }

        public void funcCargarTabla()
        {
            DataTable dt = cn.funcObtenerAreas();
            dgv_areas.DataSource = dt;
            dgv_areas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public void funcCargarProyectos()
        {
            DataTable dt = cn.funcObtenerProyectos();
            cbo_proyecto.DataSource = dt;
            cbo_proyecto.DisplayMember = "Cmp_Nombre_Proyecto";
            cbo_proyecto.ValueMember = "Pk_Id_Proyecto";
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_idArea.Text) || string.IsNullOrEmpty(txt_nombreArea.Text))
            {
                MessageBox.Show("Por favor complete los campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idArea = Convert.ToInt32(txt_idArea.Text);
            int idProyecto = Convert.ToInt32(cbo_proyecto.SelectedValue);
            string nombre = txt_nombreArea.Text;
            string descripcion = txt_descripcion.Text;
            string estado = rdb_activo.Checked ? "1" : "0";

            if (cn.funcGuardarArea(idArea, idProyecto, nombre, descripcion, estado))
            {
                MessageBox.Show("Área guardada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                funcCargarTabla();
                funcLimpiarCampos();
            }
            else
            {
                MessageBox.Show("Error al guardar el área.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_idArea.Text))
            {
                MessageBox.Show("Seleccione un registro de la tabla para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idArea = Convert.ToInt32(txt_idArea.Text);
            int idProyecto = Convert.ToInt32(cbo_proyecto.SelectedValue);
            string nombre = txt_nombreArea.Text;
            string descripcion = txt_descripcion.Text;
            string estado = rdb_activo.Checked ? "1" : "0";

            if (cn.funcActualizarArea(idArea, idProyecto, nombre, descripcion, estado))
            {
                MessageBox.Show("Área actualizada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                funcCargarTabla();
                funcLimpiarCampos();
            }
            else
            {
                MessageBox.Show("Error al modificar el área.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_idArea.Text))
            {
                MessageBox.Show("Seleccione un registro para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idArea = Convert.ToInt32(txt_idArea.Text);

            if (MessageBox.Show("¿Está seguro de eliminar esta área?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (cn.funcBorrarArea(idArea))
                {
                    MessageBox.Show("Área eliminada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    funcCargarTabla();
                    funcLimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el área.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            funcLimpiarCampos();
        }

        private void dgv_areas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_areas.Rows[e.RowIndex];
                txt_idArea.Text = row.Cells["Pk_Id_Area"].Value.ToString();
                cbo_proyecto.SelectedValue = row.Cells["Fk_Id_Proyecto"].Value;
                txt_nombreArea.Text = row.Cells["Cmp_Nombre_Area"].Value.ToString();
                txt_descripcion.Text = row.Cells["Cmp_Descripcion_Area"].Value.ToString();

                string estado = row.Cells["Cmp_Estado_Area"].Value.ToString();
                if (estado == "1" || estado == "Habilitado")
                    rdb_activo.Checked = true;
                else
                    rdb_inactivo.Checked = true;
            }
        }

        public void funcLimpiarCampos()
        {
            txt_idArea.Clear();
            txt_nombreArea.Clear();
            txt_descripcion.Clear();
            rdb_activo.Checked = true;
            if (cbo_proyecto.Items.Count > 0)
                cbo_proyecto.SelectedIndex = 0;
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}