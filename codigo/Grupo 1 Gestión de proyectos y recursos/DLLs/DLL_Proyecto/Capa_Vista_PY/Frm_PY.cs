using System;
using System.Data;
using System.Windows.Forms;
using Capa_Controlador_PY;

//Inicio de código de Paula Daniela Leonardo Paredes carné 0901-22-9580 en la fecha de: "20/10/2026"
namespace Capa_Vista_PY
{
    public partial class Frm_PY : Form
    {
        private readonly Cls_Controlador_PY gControlador = new Cls_Controlador_PY();
        private int iIdSeleccionado = 0; // 0 = ningún proyecto seleccionado (modo nuevo)

        public Frm_PY()
        {
            InitializeComponent();
        }

        private void Frm_PY_Load(object sender, EventArgs e)
        {
            pro_cargar_estados();
            pro_cargar_proyectos();
            pro_limpiar();
        }

        // Llena el combo con los estados del proyecto
        private void pro_cargar_estados()
        {
            try
            {
                Cbo_Estado_PY.DataSource = gControlador.fun_listar_estados();
                Cbo_Estado_PY.DisplayMember = "Cmp_Nombre_Proyecto_Estado";
                Cbo_Estado_PY.ValueMember = "Pk_Id_Proyecto_Estado";
                Cbo_Estado_PY.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los estados: " + ex.Message,
                    "Proyectos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Llena la cuadrícula con los proyectos
        private void pro_cargar_proyectos()
        {
            try
            {
                Dgv_PY.DataSource = gControlador.fun_listar_proyectos();
                Dgv_PY.Columns["Pk_Id_Proyecto"].HeaderText = "Código";
                Dgv_PY.Columns["Fk_Id_Proyecto_Estado"].Visible = false;
                Dgv_PY.Columns["Cmp_Nombre_Proyecto_Estado"].HeaderText = "Estado";
                Dgv_PY.Columns["Cmp_Nombre_Proyecto"].HeaderText = "Nombre";
                Dgv_PY.Columns["Cmp_Descripcion_Proyecto"].HeaderText = "Descripción";
                Dgv_PY.Columns["Cmp_Fecha_Inicio_Proyecto"].HeaderText = "Fecha inicio";
                Dgv_PY.Columns["Cmp_Fecha_Fin_Proyecto"].HeaderText = "Fecha fin";
                Dgv_PY.Columns["Cmp_Objetivo_Proyecto"].HeaderText = "Objetivo";
                Dgv_PY.Columns["Cmp_Fecha_Inicio_Proyecto"].DefaultCellStyle.Format = "dd/MM/yyyy";
                Dgv_PY.Columns["Cmp_Fecha_Fin_Proyecto"].DefaultCellStyle.Format = "dd/MM/yyyy";
                Dgv_PY.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los proyectos: " + ex.Message,
                    "Proyectos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Deja el formulario en modo "nuevo"
        private void pro_limpiar()
        {
            iIdSeleccionado = 0;

            try
            {
                Txt_Id_PY.Text = gControlador.fun_siguiente_id().ToString();
            }
            catch (Exception ex)
            {
                Txt_Id_PY.Text = "";
                MessageBox.Show("No se pudo obtener el código: " + ex.Message,
                    "Proyectos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Cbo_Estado_PY.SelectedIndex = -1;
            Txt_Nombre_PY.Text = "";
            Txt_Descripcion_PY.Text = "";
            Txt_Objetivo_PY.Text = "";
            Dtp_Inicio_PY.Value = DateTime.Today;
            Dtp_Inicio_PY.Checked = false;
            Dtp_Fin_PY.Value = DateTime.Today;
            Dtp_Fin_PY.Checked = false;
            Dgv_PY.ClearSelection();

            Btn_Guardar_PY.Enabled = true;
            Btn_Modificar_PY.Enabled = false;
            Btn_Eliminar_PY.Enabled = false;
            Txt_Nombre_PY.Focus();
        }

        // Pasa los datos de la fila seleccionada a los controles
        private void Dgv_PY_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = Dgv_PY.Rows[e.RowIndex];
            iIdSeleccionado = Convert.ToInt32(fila.Cells["Pk_Id_Proyecto"].Value);
            Txt_Id_PY.Text = iIdSeleccionado.ToString();
            Cbo_Estado_PY.SelectedValue = Convert.ToInt32(fila.Cells["Fk_Id_Proyecto_Estado"].Value);
            Txt_Nombre_PY.Text = Convert.ToString(fila.Cells["Cmp_Nombre_Proyecto"].Value);
            Txt_Descripcion_PY.Text = Convert.ToString(fila.Cells["Cmp_Descripcion_Proyecto"].Value);
            Txt_Objetivo_PY.Text = Convert.ToString(fila.Cells["Cmp_Objetivo_Proyecto"].Value);
            pro_asignar_fecha(Dtp_Inicio_PY, fila.Cells["Cmp_Fecha_Inicio_Proyecto"].Value);
            pro_asignar_fecha(Dtp_Fin_PY, fila.Cells["Cmp_Fecha_Fin_Proyecto"].Value);

            Btn_Guardar_PY.Enabled = false;
            Btn_Modificar_PY.Enabled = true;
            Btn_Eliminar_PY.Enabled = true;
        }

        // Las fechas son opcionales en la tabla, por eso el DateTimePicker lleva casilla
        private void pro_asignar_fecha(DateTimePicker dtpFecha, object oValor)
        {
            if (oValor == null || oValor == DBNull.Value)
            {
                dtpFecha.Value = DateTime.Today;
                dtpFecha.Checked = false;
                return;
            }
            dtpFecha.Value = Convert.ToDateTime(oValor);
            dtpFecha.Checked = true;
        }

        private int fun_estado_seleccionado()
        {
            return Cbo_Estado_PY.SelectedValue == null ? 0 : Convert.ToInt32(Cbo_Estado_PY.SelectedValue);
        }

        private DateTime? fun_fecha(DateTimePicker dtpFecha)
        {
            return dtpFecha.Checked ? (DateTime?)dtpFecha.Value.Date : null;
        }

        private void Btn_Guardar_PY_Click(object sender, EventArgs e)
        {
            string sError = gControlador.fun_guardar_proyecto(
                fun_estado_seleccionado(), Txt_Nombre_PY.Text, Txt_Descripcion_PY.Text,
                fun_fecha(Dtp_Inicio_PY), fun_fecha(Dtp_Fin_PY), Txt_Objetivo_PY.Text);

            if (sError != "")
            {
                MessageBox.Show(sError, "Proyectos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Proyecto guardado.", "Proyectos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            pro_cargar_proyectos();
            pro_limpiar();
        }

        private void Btn_Modificar_PY_Click(object sender, EventArgs e)
        {
            string sError = gControlador.fun_modificar_proyecto(
                iIdSeleccionado, fun_estado_seleccionado(), Txt_Nombre_PY.Text, Txt_Descripcion_PY.Text,
                fun_fecha(Dtp_Inicio_PY), fun_fecha(Dtp_Fin_PY), Txt_Objetivo_PY.Text);

            if (sError != "")
            {
                MessageBox.Show(sError, "Proyectos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Proyecto modificado.", "Proyectos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            pro_cargar_proyectos();
            pro_limpiar();
        }

        private void Btn_Eliminar_PY_Click(object sender, EventArgs e)
        {
            if (iIdSeleccionado <= 0) return;

            DialogResult resultado = MessageBox.Show("¿Eliminar el proyecto seleccionado?",
                "Proyectos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado != DialogResult.Yes) return;

            string sError = gControlador.fun_eliminar_proyecto(iIdSeleccionado);
            if (sError != "")
            {
                MessageBox.Show(sError, "Proyectos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            pro_cargar_proyectos();
            pro_limpiar();
        }

        // Solo limpia los campos de arriba y regresa al modo nuevo
        private void Btn_Limpiar_PY_Click(object sender, EventArgs e)
        {
            pro_limpiar();
        }

        private void Btn_Ayuda_PY_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "MANTENIMIENTO DE PROYECTOS\n\n" +
                "Guardar: registra un proyecto nuevo. El código se asigna solo.\n" +
                "Modificar: cambia el proyecto que esté seleccionado en la tabla.\n" +
                "Eliminar: borra el proyecto seleccionado en la tabla.\n" +
                "Limpiar: vacía los campos y vuelve al modo de registro nuevo.\n\n" +
                "El nombre y el estado son obligatorios. Las fechas son opcionales: " +
                "marque la casilla del campo para activarlas.",
                "Ayuda - Proyectos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
//Fin de código de Paula Daniela Leonardo Paredes carné 0901-22-9580 en la fecha de: "20/10/2026"
