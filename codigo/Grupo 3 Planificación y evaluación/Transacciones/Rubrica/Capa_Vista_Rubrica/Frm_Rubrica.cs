// Empieza codigo hecho por Maria Morales 0901-22-1226 el dia 07/10/2026
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Controlador_Rubrica;

namespace Capa_Vista_Rubrica
{
    public partial class Frm_Rubrica : Form
    {
        private readonly Cls_Controlador_Rubrica controlador = new Cls_Controlador_Rubrica();
        private int idSeleccionado = 0;

        public Frm_Rubrica()
        {
            InitializeComponent();
        }

        private void Frm_Rubrica_Load(object sender, EventArgs e)
        {
            try
            {
                CargarCronogramas();
                CargarGrid();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCronogramas()
        {
            cmbCronograma.DataSource = controlador.ListarCronogramas();
            cmbCronograma.DisplayMember = "Texto";
            cmbCronograma.ValueMember = "Id";
            cmbCronograma.SelectedIndex = -1;
        }

        private void CargarGrid()
        {
            dgvRubricas.DataSource = controlador.Listar();
            ConfigurarEncabezados();
        }

        private void ConfigurarEncabezados()
        {
            if (dgvRubricas.Columns.Count > 0)
            {
                dgvRubricas.Columns["Id"].HeaderText = "ID";
                dgvRubricas.Columns["IdCronograma"].HeaderText = "ID Cronograma";
                dgvRubricas.Columns["Nombre"].HeaderText = "Nombre";
                dgvRubricas.Columns["Descripcion"].HeaderText = "Descripción";
                dgvRubricas.Columns["Objetivo"].HeaderText = "Objetivo";
            }
        }

        private void LimpiarCampos()
        {
            idSeleccionado = 0;
            txtId.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtObjetivo.Text = "";
            cmbCronograma.SelectedIndex = -1;
            btnGuardar.Enabled = true;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            txtNombre.Focus();
        }

        private int ObtenerIdCronograma()
        {
            return cmbCronograma.SelectedValue != null
                ? Convert.ToInt32(cmbCronograma.SelectedValue)
                : 0;
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string resultado = controlador.Guardar(
                ObtenerIdCronograma(),
                txtNombre.Text,
                txtDescripcion.Text,
                txtObjetivo.Text);

            if (resultado == "OK")
            {
                MessageBox.Show("Rúbrica guardada correctamente.", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrid();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show(resultado, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string resultado = controlador.Modificar(
                idSeleccionado,
                ObtenerIdCronograma(),
                txtNombre.Text,
                txtDescripcion.Text,
                txtObjetivo.Text);

            if (resultado == "OK")
            {
                MessageBox.Show("Rúbrica modificada correctamente.", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrid();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show(resultado, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult confirmar = MessageBox.Show(
                "¿Está seguro de eliminar esta rúbrica?\nSe eliminarán también sus criterios y actividades asociadas.",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmar != DialogResult.Yes) return;

            string resultado = controlador.Eliminar(idSeleccionado);
            if (resultado == "OK")
            {
                MessageBox.Show("Rúbrica eliminada correctamente.", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrid();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show(resultado, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvRubricas.DataSource = controlador.Buscar(txtBuscar.Text.Trim());
            ConfigurarEncabezados();
        }

        private void btnMostrarTodo_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = "";
            CargarGrid();
        }

        private void dgvRubricas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dgvRubricas.Rows[e.RowIndex];
            idSeleccionado = Convert.ToInt32(fila.Cells["Id"].Value);

            txtId.Text = idSeleccionado.ToString();
            cmbCronograma.SelectedValue = Convert.ToInt32(fila.Cells["IdCronograma"].Value);
            txtNombre.Text = fila.Cells["Nombre"].Value?.ToString();
            txtDescripcion.Text = fila.Cells["Descripcion"].Value?.ToString();
            txtObjetivo.Text = fila.Cells["Objetivo"].Value?.ToString();

            btnGuardar.Enabled = false;
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
// Termina codigo hecho por Maria Morales 0901-22-1226 el dia 07/10/2026