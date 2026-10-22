using Capa_Controlador_Criterios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Vista_Criterios
{
    public partial class Frm_Criterio : Form
    {
        private readonly Cls_Controlador_Criterio ctrl = new Cls_Controlador_Criterio();
        private int idSeleccionado = 0;
        private bool cargando = false;

        public Frm_Criterio()
        {
            InitializeComponent();
            ConfigurarControles();
            Load += Frm_Criterio_Load;
        }

        // ---------- Configuración inicial ----------
        private void ConfigurarControles()
        {
            cmbRubrica.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbImportancia.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbImportancia.Items.Clear();
            cmbImportancia.Items.AddRange(new object[] { "", "Alta", "Media", "Baja" });

            numPorcentaje.Minimum = 0;
            numPorcentaje.Maximum = 100;
            txtNombre.MaxLength = 100;
            txtDescripcion.Multiline = true;
            txtDescripcion.ScrollBars = ScrollBars.Vertical;

            // Grilla
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.MultiSelect = false;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoGenerateColumns = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.Columns.Clear();
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID", FillWeight = 8 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NombreRubrica", HeaderText = "Rúbrica", FillWeight = 25 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nombre", HeaderText = "Criterio", FillWeight = 30 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Porcentaje", HeaderText = "%", FillWeight = 8 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NivelImportancia", HeaderText = "Importancia", FillWeight = 15 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Descripcion", HeaderText = "Descripción", FillWeight = 40 });

            // Eventos (se conectan aquí, no en el diseñador)
            btnNuevo.Click += (s, e) => Limpiar();
            btnCancelar.Click += (s, e) => Limpiar();
            btnGuardar.Click += BtnGuardar_Click;
            btnEliminar.Click += BtnEliminar_Click;
            cmbRubrica.SelectedIndexChanged += (s, e) => ActualizarSuma();
            chkSinPorcentaje.CheckedChanged += (s, e) => numPorcentaje.Enabled = !chkSinPorcentaje.Checked;
            dgv.SelectionChanged += Dgv_SelectionChanged;
        }

        private void Frm_Criterio_Load(object sender, EventArgs e)
        {
            try { CargarRubricas(); }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar las rúbricas: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CargarGrilla();
            Limpiar();
        }

        // ---------- Carga de datos ----------
        private void CargarRubricas()
        {
            cmbRubrica.DataSource = ctrl.ListarRubricas();
            cmbRubrica.DisplayMember = "Cmp_Nombre_Rubrica";
            cmbRubrica.ValueMember = "Pk_Id_Rubrica";
        }

        private void CargarGrilla()
        {
            cargando = true;
            try
            {
                dgv.DataSource = null;
                dgv.DataSource = ctrl.Listar();
                dgv.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar la lista: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { cargando = false; }
        }

        private int ObtenerIdRubrica()
        {
            var fila = cmbRubrica.SelectedItem as DataRowView;
            return fila == null ? 0 : Convert.ToInt32(fila["Pk_Id_Rubrica"]);
        }

        // Muestra cuánto de 100% ya está usado en la rúbrica elegida
        private void ActualizarSuma()
        {
            int idRub = ObtenerIdRubrica();
            if (idRub == 0) { lblSuma.Text = ""; return; }

            int suma = ctrl.SumaPorcentajes(idRub, idSeleccionado);
            lblSuma.Text = "Ya asignado en esta rúbrica: " + suma + "%  (disponible: " + (100 - suma) + "%)";
            lblSuma.ForeColor = suma >= 100 ? Color.Firebrick : Color.DimGray;
        }

        // ---------- Eventos ----------
        private void Dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (cargando || dgv.CurrentRow == null || !dgv.CurrentRow.Selected) return;
            var vista = dgv.CurrentRow.DataBoundItem as DataRowView;
            if (vista == null) return;
            DataRow f = vista.Row;

            idSeleccionado = Convert.ToInt32(f["Id"]);
            cmbRubrica.SelectedValue = Convert.ToInt32(f["IdRubrica"]);
            txtNombre.Text = f["Nombre"].ToString();
            bool sinPorcentaje = f["Porcentaje"] == DBNull.Value;
            chkSinPorcentaje.Checked = sinPorcentaje;
            numPorcentaje.Value = sinPorcentaje ? 0 : Convert.ToInt32(f["Porcentaje"]);
            cmbImportancia.SelectedItem = f["NivelImportancia"] == DBNull.Value ? "" : f["NivelImportancia"].ToString();
            txtDescripcion.Text = f["Descripcion"] == DBNull.Value ? "" : f["Descripcion"].ToString();
            btnEliminar.Enabled = true;
            btnGuardar.Text = "Actualizar";
            ActualizarSuma();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            var r = ctrl.Guardar(
                idSeleccionado,
                ObtenerIdRubrica(),
                txtNombre.Text.Trim(),
                chkSinPorcentaje.Checked ? (int?)null : (int)numPorcentaje.Value,
                cmbImportancia.SelectedItem as string,
                txtDescripcion.Text.Trim());
            MessageBox.Show(r.mensaje, r.ok ? "Información" : "Atención",
                MessageBoxButtons.OK, r.ok ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            if (r.ok) { CargarGrilla(); Limpiar(); }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0) return;
            var conf = MessageBox.Show(
                "¿Eliminar este criterio? También se eliminarán sus descripciones por nivel.",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (conf != DialogResult.Yes) return;

            var r = ctrl.Eliminar(idSeleccionado);
            MessageBox.Show(r.mensaje, r.ok ? "Información" : "Atención",
                MessageBoxButtons.OK, r.ok ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            if (r.ok) { CargarGrilla(); Limpiar(); }
        }

        private void Limpiar()
        {
            idSeleccionado = 0;
            txtNombre.Clear();
            txtDescripcion.Clear();
            numPorcentaje.Value = 0;
            chkSinPorcentaje.Checked = false;
            cmbImportancia.SelectedIndex = 0;
            if (cmbRubrica.Items.Count > 0) cmbRubrica.SelectedIndex = 0;
            btnEliminar.Enabled = false;
            btnGuardar.Text = "Guardar";
            dgv.ClearSelection();
            ActualizarSuma();
            txtNombre.Focus();
        }


    }
}
