// Empieza codigo hecho por Pablo Quiroa 0901-22-2929 el dia 09/10/2026
using System;
using System.Windows.Forms;
using Capa_Controlador_Planificacion;

namespace Capa_Vista_Planificacion
{
    public partial class Frm_Planificacion : Form
    {
        private readonly Cls_controlador_planificacion controlador = new Cls_controlador_planificacion();
        private int idSeleccionado = 0;

        public Frm_Planificacion()
        {
            InitializeComponent();

            // Estos dos eventos se conectan aqu
            this.Load += Frm_Planificacion_Load;
            Dgv_planificacion.CellClick += Dgv_planificacion_CellClick;
        }

        private void Frm_Planificacion_Load(object sender, EventArgs e)
        {
            ConfigurarControles();
            try
            {
                CargarProyectos();
                CargarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LimpiarCampos();
        }

        private void ConfigurarControles()
        {
            Txt_Id_planificacion.ReadOnly = true;
            Cbo_id_proyecto.DropDownStyle = ComboBoxStyle.DropDownList;
            Txt_nombre.MaxLength = 100;

            // Casilla en las fechas: si no esta marcada se guarda NULL
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.ShowCheckBox = true;
            dateTimePicker2.Format = DateTimePickerFormat.Short;
            dateTimePicker2.ShowCheckBox = true;

            Dgv_planificacion.ReadOnly = true;
            Dgv_planificacion.AllowUserToAddRows = false;
            Dgv_planificacion.AllowUserToDeleteRows = false;
            Dgv_planificacion.MultiSelect = false;
            Dgv_planificacion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Dgv_planificacion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarProyectos()
        {
           
            Cbo_id_proyecto.DisplayMember = "Texto";
            Cbo_id_proyecto.ValueMember = "Id";
            Cbo_id_proyecto.DataSource = controlador.ListarProyectos();
            Cbo_id_proyecto.SelectedIndex = -1;
        }

        private void CargarGrid()
        {
            Dgv_planificacion.DataSource = controlador.Listar();
            ConfigurarEncabezados();
        }

        private void ConfigurarEncabezados()
        {
            if (Dgv_planificacion.Columns.Count == 0) return;

            Dgv_planificacion.Columns["Id"].HeaderText = "ID";
            Dgv_planificacion.Columns["IdProyecto"].Visible = false;
            Dgv_planificacion.Columns["Proyecto"].HeaderText = "Proyecto";
            Dgv_planificacion.Columns["Nombre"].HeaderText = "Nombre";
            Dgv_planificacion.Columns["Descripcion"].HeaderText = "Descripción";
            Dgv_planificacion.Columns["FechaInicio"].HeaderText = "Inicio";
            Dgv_planificacion.Columns["FechaInicio"].DefaultCellStyle.Format = "dd/MM/yyyy";
            Dgv_planificacion.Columns["FechaFin"].HeaderText = "Fin";
            Dgv_planificacion.Columns["FechaFin"].DefaultCellStyle.Format = "dd/MM/yyyy";
            Dgv_planificacion.Columns["Observaciones"].HeaderText = "Observaciones";
        }

        private void LimpiarCampos()
        {
            idSeleccionado = 0;
            Txt_Id_planificacion.Text = "";
            Cbo_id_proyecto.SelectedIndex = -1;
            Txt_nombre.Text = "";
            Txt_descripcion.Text = "";
            Txt_observaciones.Text = "";
            AsignarFecha(dateTimePicker1, null);
            AsignarFecha(dateTimePicker2, null);
            Dgv_planificacion.ClearSelection();

            Btn_guardar.Enabled = true;
            Btn_modificar.Enabled = false;
            Btn_eliminar.Enabled = false;
            Txt_nombre.Focus();
        }

        // Solo lee lo que hay en pantalla, tdas ls demas reglas estan en controlador
        private int ObtenerIdProyecto()
        {
            return Cbo_id_proyecto.SelectedValue != null
                ? Convert.ToInt32(Cbo_id_proyecto.SelectedValue)
                : 0;
        }

        private DateTime? ObtenerFecha(DateTimePicker dtp)
        {
            return dtp.Checked ? dtp.Value : (DateTime?)null;
        }

        private void AsignarFecha(DateTimePicker dtp, object valor)
        {
            if (valor is DateTime fecha)
            {
                dtp.Value = fecha;
                dtp.Checked = true;
            }
            else
            {
                dtp.Value = DateTime.Today;
                dtp.Checked = false;
            }
        }

        private void MostrarResultado(string resultado, string mensajeExito)
        {
            if (resultado == "OK")
            {
                MessageBox.Show(mensajeExito, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrid();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show(resultado, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        // Botones

        private void Btn_nuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            string resultado = controlador.Guardar(
                ObtenerIdProyecto(),
                Txt_nombre.Text,
                Txt_descripcion.Text,
                ObtenerFecha(dateTimePicker1),
                ObtenerFecha(dateTimePicker2),
                Txt_observaciones.Text);

            MostrarResultado(resultado, "Planificación guardada correctamente.");
        }

        private void Btn_modificar_Click(object sender, EventArgs e)
        {
            string resultado = controlador.Modificar(
                idSeleccionado,
                ObtenerIdProyecto(),
                Txt_nombre.Text,
                Txt_descripcion.Text,
                ObtenerFecha(dateTimePicker1),
                ObtenerFecha(dateTimePicker2),
                Txt_observaciones.Text);

            MostrarResultado(resultado, "Planificación modificada correctamente.");
        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            DialogResult confirmar = MessageBox.Show(
                controlador.MensajeConfirmacionEliminar(idSeleccionado),
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmar != DialogResult.Yes) return;

            string resultado = controlador.Eliminar(idSeleccionado);
            MostrarResultado(resultado, "Planificación eliminada correctamente.");
        }


        // DGV

        private void Dgv_planificacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = Dgv_planificacion.Rows[e.RowIndex];
            idSeleccionado = Convert.ToInt32(fila.Cells["Id"].Value);

            Txt_Id_planificacion.Text = idSeleccionado.ToString();
            Cbo_id_proyecto.SelectedValue = Convert.ToInt32(fila.Cells["IdProyecto"].Value);
            Txt_nombre.Text = fila.Cells["Nombre"].Value?.ToString();
            Txt_descripcion.Text = fila.Cells["Descripcion"].Value?.ToString();
            Txt_observaciones.Text = fila.Cells["Observaciones"].Value?.ToString();
            AsignarFecha(dateTimePicker1, fila.Cells["FechaInicio"].Value);
            AsignarFecha(dateTimePicker2, fila.Cells["FechaFin"].Value);

            Btn_guardar.Enabled = false;
            Btn_modificar.Enabled = true;
            Btn_eliminar.Enabled = true;
        }


        
        private void Txt_Id_planificacion_TextChanged(object sender, EventArgs e) { }
        private void Cbo_id_proyecto_SelectedIndexChanged(object sender, EventArgs e) { }
        private void Txt_nombre_TextChanged(object sender, EventArgs e) { }
        private void Txt_descripcion_TextChanged(object sender, EventArgs e) { }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) { }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e) { }
        private void Txt_observaciones_TextChanged(object sender, EventArgs e) { }
        private void Dgv_planificacion_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}
// Termina codigo hecho por Pablo Quiroa 0901-22-2929 el dia 09/10/2026