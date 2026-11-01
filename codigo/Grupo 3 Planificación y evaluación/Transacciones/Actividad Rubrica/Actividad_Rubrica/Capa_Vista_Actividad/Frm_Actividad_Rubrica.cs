// Codigo empezado por: Maria Morales 0901-22-1226 el día 19/10/2026
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Controlador_Actividad_Rubrica;

namespace Capa_Vista_Actividad
{
    public partial class Frm_Actividad_Rubrica : Form
    {
        private readonly Cls_Controlador_Actividad controlador = new Cls_Controlador_Actividad();
        private int idSeleccionado = 0;

        public Frm_Actividad_Rubrica()
        {
            InitializeComponent();
        }

        private void Frm_Actividad_Rubrica_Load(object sender, EventArgs e)
        {
            try
            {
                CargarCombos();
                CargarGrid();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCombos()
        {
            cmbActividad.DataSource = controlador.ListarActividades();
            cmbActividad.DisplayMember = "Texto";
            cmbActividad.ValueMember = "Id";
            cmbActividad.SelectedIndex = -1;

            cmbRubrica.DataSource = controlador.ListarRubricas();
            cmbRubrica.DisplayMember = "Texto";
            cmbRubrica.ValueMember = "Id";
            cmbRubrica.SelectedIndex = -1;
        }

        private void CargarGrid()
        {
            dgvActividadRubrica.DataSource = controlador.Listar();
            ConfigurarGrid();
        }

        private void ConfigurarGrid()
        {
            if (dgvActividadRubrica.Columns.Count > 0)
            {
                dgvActividadRubrica.Columns["Id"].HeaderText = "ID";
                dgvActividadRubrica.Columns["Actividad"].HeaderText = "Actividad";
                dgvActividadRubrica.Columns["Rubrica"].HeaderText = "Rúbrica";
                dgvActividadRubrica.Columns["EstadoTexto"].HeaderText = "Estado";

                
                dgvActividadRubrica.Columns["IdActividad"].Visible = false;
                dgvActividadRubrica.Columns["IdRubrica"].Visible = false;
                dgvActividadRubrica.Columns["Estado"].Visible = false;
            }
        }

        private void LimpiarCampos()
        {
            idSeleccionado = 0;
            txtId.Text = "";
            cmbActividad.SelectedIndex = -1;
            cmbRubrica.SelectedIndex = -1;
            chkEstado.Checked = true;
            btnGuardar.Enabled = true;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            cmbActividad.Focus();
        }

        private int ObtenerIdActividad()
        {
            return cmbActividad.SelectedValue != null ? Convert.ToInt32(cmbActividad.SelectedValue) : 0;
        }

        private int ObtenerIdRubrica()
        {
            return cmbRubrica.SelectedValue != null ? Convert.ToInt32(cmbRubrica.SelectedValue) : 0;
        }

    
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string resultado = controlador.Guardar(ObtenerIdActividad(), ObtenerIdRubrica(), chkEstado.Checked);

            if (resultado == "OK")
            {
                MessageBox.Show("Registro guardado correctamente.", "Éxito",
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
            string resultado = controlador.Modificar(idSeleccionado, ObtenerIdActividad(),
                                                     ObtenerIdRubrica(), chkEstado.Checked);

            if (resultado == "OK")
            {
                MessageBox.Show("Registro modificado correctamente.", "Éxito",
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
            DialogResult confirmar = MessageBox.Show("¿Está seguro de eliminar este registro?",
                                     "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmar != DialogResult.Yes) return;

            string resultado = controlador.Eliminar(idSeleccionado);
            if (resultado == "OK")
            {
                MessageBox.Show("Registro eliminado correctamente.", "Éxito",
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
            dgvActividadRubrica.DataSource = controlador.Buscar(txtBuscar.Text.Trim());
            ConfigurarGrid();
        }

        private void btnMostrarTodo_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = "";
            CargarGrid();
        }

        private void dgvActividadRubrica_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dgvActividadRubrica.Rows[e.RowIndex];
            idSeleccionado = Convert.ToInt32(fila.Cells["Id"].Value);

            txtId.Text = idSeleccionado.ToString();
            cmbActividad.SelectedValue = Convert.ToInt32(fila.Cells["IdActividad"].Value);
            cmbRubrica.SelectedValue = Convert.ToInt32(fila.Cells["IdRubrica"].Value);
            chkEstado.Checked = Convert.ToInt32(fila.Cells["Estado"].Value) == 1;

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
// Codigo terminado por: Maria Morales 0901-22-1226 el día 19/10/2026