using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Controlador_Checklist;

namespace Capa_Vista_Checklist
{
    public partial class Frm_Checklist : Form
    {
        public Frm_Checklist()
        {
            InitializeComponent();
            dgvActividades.CellClick += dgvActividades_CellClick;
            dgvChecklist.CellClick += dgvChecklist_CellClick;
            CargarRubricas();
        }

        //Cargar rubricas en combobox 
        private void CargarRubricas()
        {
            try
            {
                Cls_Controlador_Checklist controlador = new Cls_Controlador_Checklist();
                cmbRubrica.DataSource = controlador.ObtenerRubricas();
                cmbRubrica.DisplayMember = "TextoRubrica";
                cmbRubrica.ValueMember = "Pk_Id_Rubrica";
                cmbRubrica.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las rúbricas: " + ex.Message);
            }
        }

        //Funcion para cargar actividades
        private void CargarActividades() {

            if (cmbRubrica.SelectedIndex == -1 || cmbRubrica.SelectedValue == null)
            {
                MessageBox.Show("Selecciona una rúbrica.");
                return;
            }

            int idRubrica;

            if (!int.TryParse(cmbRubrica.SelectedValue.ToString(), out idRubrica))
            {
                MessageBox.Show("Selecciona una rúbrica válida.");
                return;
            }

            try
            {
                Cls_Controlador_Checklist controlador = new Cls_Controlador_Checklist();

                dgvActividades.DataSource = controlador.Listar(idRubrica);
                // Cambiar los encabezados de las columnas
                dgvActividades.Columns["Fk_id_actividad_rubrica"].HeaderText = "ID Actividad";
                dgvActividades.Columns["Cmp_Nombre_Actividad_Proyecto"].HeaderText = "Nombre Actividad";

                // Ocultar columnas que manda el DTO
                dgvActividades.Columns["Fk_id_informe"].Visible = false;
                dgvActividades.Columns["Entregado"].Visible = false;
                dgvActividades.Columns["Pk_Id_Rubrica"].Visible = false;
                dgvActividades.Columns["Cmp_Nombre_Rubrica"].Visible = false;
                dgvActividades.Columns["TextoRubrica"].Visible = false;
                dgvActividades.Columns["Pk_id_checklist"].Visible = false;
                dgvActividades.Columns["EstadoTexto"].Visible = false;

                if (dgvActividades.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron actividades pendientes.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar las actividades: " + ex.Message);
            }
        }

        //Btn Mostrar actividades pendientes
        private void button1_Click(object sender, EventArgs e)
        {
            CargarActividades();
        }

        //Usar id de fila seleccionada en el DGV de Actividades
        private void dgvActividades_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex >= 0) {
                txtIdActividadRubrica.Text = dgvActividades.Rows[e.RowIndex].Cells["FK_id_actividad_rubrica"].Value?.ToString();
            }
        }

        //Insertar en checklist
        private void btn_registrar_Click(object sender, EventArgs e)
        {
            Cls_Controlador_Checklist controlador = new Cls_Controlador_Checklist();

            Cls_Checklist_DTO datos = new Cls_Checklist_DTO();

            datos.Fk_id_actividad_rubrica = Convert.ToInt32(txtIdActividadRubrica.Text);

            datos.Fk_id_informe = Convert.ToInt32(txtIdInforme.Text);

            datos.Entregado = cmbEstadoActividad.Text == "Entregado";

            bool resultado = controlador.Insertar(datos);

            if (resultado)
            {
                MessageBox.Show("Actividad guardada correctamente.");
                txtIdActividadRubrica.Clear();
                txtIdInforme.Clear();
                cmbEstadoActividad.SelectedIndex = -1;
                CargarActividades();
            }
            else
            {
                MessageBox.Show("No se pudo guardar la actividad.");
            }
        }

        //Funcion para cargar checklist de un informe
        private void CargarChecklist()
        {
            int idInformeB;

            if (!int.TryParse(txtidinformeB.Text, out idInformeB) || idInformeB <= 0)
            {
                MessageBox.Show("Ingrese un ID de informe válido.");
                return;
            }

            try
            {
                Cls_Controlador_Checklist controlador = new Cls_Controlador_Checklist();

                dgvChecklist.DataSource = controlador.ListarCKL(idInformeB);

                //Cambiar los encabezados de las columnas
                dgvChecklist.Columns["Pk_id_checklist"].HeaderText = "ID Checklist";
                dgvChecklist.Columns["Cmp_Nombre_Actividad_Proyecto"].HeaderText = "Nombre Actividad";
                dgvChecklist.Columns["EstadoTexto"].HeaderText = "Estado";

                //Ocultar columnas que manda el DTO
                dgvChecklist.Columns["Fk_id_informe"].Visible = false;
                dgvChecklist.Columns["Pk_Id_Rubrica"].Visible = false;
                dgvChecklist.Columns["Cmp_Nombre_Rubrica"].Visible = false;
                dgvChecklist.Columns["TextoRubrica"].Visible = false;
                dgvChecklist.Columns["Fk_id_actividad_rubrica"].Visible = false;
                dgvChecklist.Columns["Entregado"].Visible = false;

                //Ordenar columnas dentro del dgv
                dgvChecklist.Columns["Pk_id_checklist"].DisplayIndex = 0;
                dgvChecklist.Columns["Cmp_Nombre_Actividad_Proyecto"].DisplayIndex = 1;
                dgvChecklist.Columns["EstadoTexto"].DisplayIndex = 2;

                if (dgvChecklist.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron checklist de ese informe.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar los checklist: " + ex.Message);
            }
        }

        //btn para Cargar Checklist de 1 informe
        private void button2_Click(object sender, EventArgs e)
        {
            CargarChecklist(); 
        }

        //Usar id de fila seleccionada en el DGV de Actividades
        private void dgvChecklist_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtIdChecklist.Text = dgvChecklist.Rows[e.RowIndex].Cells["Pk_id_checklist"].Value?.ToString();
            }
        }

        //btn para editar un checklist
        private void btnEditar_Click(object sender, EventArgs e)
        {
            int idChecklist;

            if (!int.TryParse(txtIdChecklist.Text, out idChecklist))
            {
                MessageBox.Show("Selecciona un checklist válido.");
                return;
            }

            if (cmbEstadoNuevo.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona el estado de la actividad.");
                return;
            }

            Cls_Checklist_DTO datos = new Cls_Checklist_DTO();

            datos.Pk_id_checklist = idChecklist;
            datos.Entregado = cmbEstadoNuevo.Text == "Entregado";

            try
            {
                Cls_Controlador_Checklist controlador = new Cls_Controlador_Checklist();

                if (controlador.Editar(datos))
                {
                    MessageBox.Show("Checklist actualizado correctamente.");

                    CargarChecklist();

                    txtIdChecklist.Clear();
                    cmbEstadoNuevo.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("No se realizaron cambios en el checklist.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        //Eliminar Checklist
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idChecklist;

            if (!int.TryParse(txtIdChecklist.Text, out idChecklist) || idChecklist <= 0)
            {
                MessageBox.Show("Selecciona un checklist válido.");
                return;
            }

            try
            {
                Cls_Controlador_Checklist controlador = new Cls_Controlador_Checklist();

                Cls_Checklist_DTO datos = new Cls_Checklist_DTO();
                datos.Pk_id_checklist = idChecklist;

                if (controlador.Eliminar(datos))
                {
                    MessageBox.Show("Checklist eliminado correctamente.");

                    txtIdChecklist.Clear();

                    CargarChecklist();
                }
                else
                {
                    MessageBox.Show("No se encontró el checklist para eliminar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
