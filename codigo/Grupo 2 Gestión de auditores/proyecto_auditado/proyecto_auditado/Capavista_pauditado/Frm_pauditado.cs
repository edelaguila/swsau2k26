using System;
using System.Data;
using System.Windows.Forms;
using Capa_controlador_pauditado;

namespace Capavista_pauditado
{
    public partial class Frm_pauditado : Form
    {
        private readonly Cls_Controlador_pauditado controlador = new Cls_Controlador_pauditado();
        private int idSeleccionado = 0; // Pk del registro elegido en el DataGridView

        public Frm_pauditado()
        {
            InitializeComponent();
            this.Load += Frm_pauditado_Load;
            dgv_pauditado.CellClick += dgv_pauditado_CellContentClick;
        }

        private void Frm_pauditado_Load(object sender, EventArgs e)
        {
            try
            {
                CargarCombos();
                CargarGrid();
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }

        // ---------- Carga de datos ----------
        private void CargarCombos()
        {
            cmb_proyecto.DataSource = controlador.CargarProyectos();
            cmb_proyecto.DisplayMember = "Cmp_Nombre_Proyecto";
            cmb_proyecto.ValueMember = "Pk_Id_Proyecto";
            cmb_proyecto.DropDownStyle = ComboBoxStyle.DropDownList;

            cmb_auditado.DataSource = controlador.CargarAuditados();
            cmb_auditado.DisplayMember = "Cmp_Nombre_Auditado";
            cmb_auditado.ValueMember = "Pk_Id_Auditado";
            cmb_auditado.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void CargarGrid()
        {
            dgv_pauditado.DataSource = controlador.CargarRegistros();
            dgv_pauditado.Columns["Pk_Id_Proyecto_Auditado"].Visible = false;
            dgv_pauditado.Columns["Fk_Id_Proyecto"].Visible = false;
            dgv_pauditado.Columns["Fk_Id_Auditado"].Visible = false;
            dgv_pauditado.Columns["Cargo_Area"].HeaderText = "Cargo / Área";
            dgv_pauditado.Columns["Fecha_Ingreso"].HeaderText = "Fecha de ingreso";
            dgv_pauditado.Columns["Fecha_Ingreso"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgv_pauditado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_pauditado.MultiSelect = false;
            dgv_pauditado.ReadOnly = true;
            dgv_pauditado.AllowUserToAddRows = false;
            dgv_pauditado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void Limpiar()
        {
            idSeleccionado = 0;
            if (cmb_proyecto.Items.Count > 0) cmb_proyecto.SelectedIndex = 0;
            if (cmb_auditado.Items.Count > 0) cmb_auditado.SelectedIndex = 0;
            dtp_fecha.Value = DateTime.Today;
            dgv_pauditado.ClearSelection();
        }

        // Convierte el SelectedValue del combo a int de forma segura
        private int Valor(ComboBox cmb)
        {
            return cmb.SelectedValue == null ? 0 : Convert.ToInt32(cmb.SelectedValue);
        }

        // ---------- Eventos ----------
        private void cmb_proyecto_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cmb_auditado_SelectedIndexChanged(object sender, EventArgs e) { }

        // Al hacer clic en una fila, se llenan los controles para modificar/eliminar
        private void dgv_pauditado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow fila = dgv_pauditado.Rows[e.RowIndex];

            idSeleccionado = Convert.ToInt32(fila.Cells["Pk_Id_Proyecto_Auditado"].Value);
            cmb_proyecto.SelectedValue = Convert.ToInt32(fila.Cells["Fk_Id_Proyecto"].Value);
            cmb_auditado.SelectedValue = Convert.ToInt32(fila.Cells["Fk_Id_Auditado"].Value);

            object f = fila.Cells["Fecha_Ingreso"].Value;
            dtp_fecha.Value = (f == null || f == DBNull.Value) ? DateTime.Today : Convert.ToDateTime(f);
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            Ejecutar(() => controlador.Guardar(Valor(cmb_proyecto), Valor(cmb_auditado), dtp_fecha.Value),
                     "Registro guardado correctamente.");
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            Ejecutar(() => controlador.Modificar(idSeleccionado, Valor(cmb_proyecto), Valor(cmb_auditado), dtp_fecha.Value),
                     "Registro modificado correctamente.");
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado <= 0)
            {
                MessageBox.Show("Seleccione un registro de la tabla.");
                return;
            }
            if (MessageBox.Show("¿Desea eliminar el registro seleccionado?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            Ejecutar(() => controlador.Eliminar(idSeleccionado), "Registro eliminado correctamente.");
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        
        private void Ejecutar(Func<string> accion, string mensajeOk)
        {
            try
            {
                string error = accion();
                if (error != "")
                {
                    MessageBox.Show(error, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                MessageBox.Show(mensajeOk);
                CargarGrid();
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_modificar_Click_1(object sender, EventArgs e)
        {
            Ejecutar(() => controlador.Modificar(idSeleccionado, Valor(cmb_proyecto), Valor(cmb_auditado), dtp_fecha.Value),
                     "Registro modificado correctamente.");
        }

        private void btn_nuevo_Click_1(object sender, EventArgs e)
        {
            Frm_reporte frm_reporte = new Frm_reporte();
            frm_reporte.Show();
        }
    }
}