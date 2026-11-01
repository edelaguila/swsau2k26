// Juan Carlos Sandoval Quej, carné: 0901-22-4170 fecha de: "21/10/2026"
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Capa_Controlador_Ponderacion;

namespace Capa_Vista_Ponderacion
{
    // Formulario de ponderación: el auditor califica a un auditado por cada criterio.
    public partial class Frm_Ponderacion : Form
    {
        private readonly Cls_Controlador_Ponderacion gControlador = new Cls_Controlador_Ponderacion();
        private readonly Color gColorModulo = Color.FromArgb(255, 224, 0);  
        private int gIdSeleccionado = 0;                        

        public Frm_Ponderacion()
        {
            InitializeComponent();
            pro_aplicar_estandar();
        }


        private void pro_aplicar_estandar()
        {
            BackColor = gColorModulo;
            Font = new Font("Rockwell", 10f);                               
            MinimumSize = new Size(850, 550);                             
            MinimizeBox = true;                                   
            MaximizeBox = true;

            Lbl_Titulo.Font = new Font("Rockwell", 18f, FontStyle.Bold);    
            Gpb_Datos.Font = new Font("Rockwell", 11f);               
            Gpb_Listado.Font = new Font("Rockwell", 11f);
            foreach (Control ctlHijo in Gpb_Datos.Controls) ctlHijo.Font = new Font("Rockwell", 10f);
            Dgv_Ponderacion.Font = new Font("Rockwell", 10f);

            pro_estilo_boton(Btn_Guardar, Cls_Iconos.fun_guardar(Color.FromArgb(33, 33, 33)));
            pro_estilo_boton(Btn_Modificar, Cls_Iconos.fun_modificar(Color.FromArgb(33, 33, 33)));
            pro_estilo_boton(Btn_Eliminar, Cls_Iconos.fun_eliminar(Color.FromArgb(33, 33, 33)));
            pro_estilo_boton(Btn_Limpiar, Cls_Iconos.fun_limpiar(Color.FromArgb(33, 33, 33)));

            Dgv_Ponderacion.EnableHeadersVisualStyles = false;
            Dgv_Ponderacion.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 33, 33);
            Dgv_Ponderacion.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            Dgv_Ponderacion.ColumnHeadersDefaultCellStyle.Font = new Font("Rockwell", 10f, FontStyle.Bold);
            Dgv_Ponderacion.DefaultCellStyle.SelectionBackColor = gColorModulo;
            Dgv_Ponderacion.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void pro_estilo_boton(Button btnBoton, Bitmap bmpIcono)
        {
            btnBoton.FlatStyle = FlatStyle.Flat;
            btnBoton.FlatAppearance.BorderSize = 0;
            btnBoton.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 240, 128);
            btnBoton.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 205, 0);
            btnBoton.BackColor = Color.White;
            btnBoton.ForeColor = Color.FromArgb(33, 33, 33);
            btnBoton.UseVisualStyleBackColor = false;
            btnBoton.Image = bmpIcono;
            btnBoton.ImageAlign = ContentAlignment.MiddleLeft;
            btnBoton.TextAlign = ContentAlignment.MiddleRight;
            btnBoton.Padding = new Padding(8, 0, 12, 0);
        }

        // Aquí se cargan los datos

        private void Frm_Ponderacion_Load(object sender, EventArgs e)
        {
            try
            {
                pro_cargar_combos();
                pro_cargar_grid();
                pro_limpiar_campos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar la información: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pro_cargar_combos()
        {
            pro_llenar_combo(Cbo_Auditado, gControlador.fun_listar_auditados());
            pro_llenar_combo(Cbo_Cronograma, gControlador.fun_listar_cronogramas());
            pro_llenar_combo(Cbo_Rubrica, gControlador.fun_listar_rubricas());
            pro_llenar_combo(Cbo_Criterio, gControlador.fun_listar_criterios());
            pro_llenar_combo(Cbo_Escala, gControlador.fun_listar_escalas());
        }

        private void pro_llenar_combo(ComboBox cboCombo, DataTable dtDatos)
        {
            cboCombo.DataSource = dtDatos;
            cboCombo.DisplayMember = "Texto";
            cboCombo.ValueMember = "Id";
            cboCombo.SelectedIndex = -1;
        }

        private void pro_cargar_grid()
        {
            Dgv_Ponderacion.DataSource = gControlador.fun_listar();
            pro_configurar_grid();
        }

        private void pro_configurar_grid()
        {
            if (Dgv_Ponderacion.Columns.Count == 0) return;

            string[] arrOcultas = { "IdAuditado", "IdCronograma", "IdRubrica", "IdCriterio", "IdEscala" };
            foreach (string sColumna in arrOcultas) Dgv_Ponderacion.Columns[sColumna].Visible = false;

            Dgv_Ponderacion.Columns["Id"].HeaderText = "ID";
            Dgv_Ponderacion.Columns["Auditado"].HeaderText = "Auditado";
            Dgv_Ponderacion.Columns["Criterio"].HeaderText = "Criterio";
            Dgv_Ponderacion.Columns["Escala"].HeaderText = "Escala";
            Dgv_Ponderacion.Columns["Porcentaje"].HeaderText = "Calificación %";
            Dgv_Ponderacion.Columns["Ponderada"].HeaderText = "Calif. ponderada";
            Dgv_Ponderacion.Columns["Comentarios"].HeaderText = "Comentarios del auditor";
            Dgv_Ponderacion.Columns["Fecha"].HeaderText = "Fecha de evaluación";
            Dgv_Ponderacion.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            Dgv_Ponderacion.Columns["Id"].FillWeight = 30;
        }


        private void pro_limpiar_campos()
        {
            gIdSeleccionado = 0;
            Txt_Id.Text = "";
            Txt_Fecha.Text = "";
            Cbo_Auditado.SelectedIndex = -1;
            Cbo_Cronograma.SelectedIndex = -1;
            Cbo_Rubrica.SelectedIndex = -1;
            Cbo_Criterio.SelectedIndex = -1;
            Cbo_Escala.SelectedIndex = -1;
            Txt_Porcentaje.Text = "";
            Txt_Ponderada.Text = "";
            Txt_Comentarios.Text = "";
            Dgv_Ponderacion.ClearSelection();

            Btn_Guardar.Enabled = true;
            Btn_Modificar.Enabled = false;
            Btn_Eliminar.Enabled = false;
            Cbo_Auditado.Focus();
        }

        // Función, devuelve el Id seleccionado en el ComboBox.
        private int fun_obtener_id(ComboBox cboCombo)
        {
            return cboCombo.SelectedValue != null ? Convert.ToInt32(cboCombo.SelectedValue) : 0;
        }

        // Procedimiento, Aquí va a mostrar el resultado de una operación y refresca la pantalla si salió bien.
        private void pro_mostrar_resultado(string sResultado, string sMensajeExito)
        {
            if (sResultado == "OK")
            {
                MessageBox.Show(sMensajeExito, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pro_cargar_grid();
                pro_limpiar_campos();
            }
            else
            {
                MessageBox.Show(sResultado, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            string sResultado = gControlador.fun_guardar(
                fun_obtener_id(Cbo_Auditado), fun_obtener_id(Cbo_Cronograma), fun_obtener_id(Cbo_Rubrica),
                fun_obtener_id(Cbo_Criterio), fun_obtener_id(Cbo_Escala),
                Txt_Porcentaje.Text, Txt_Ponderada.Text, Txt_Comentarios.Text);

            pro_mostrar_resultado(sResultado, "Ponderación guardada correctamente.");
        }

        private void Btn_Modificar_Click(object sender, EventArgs e)
        {
            string sResultado = gControlador.fun_modificar(
                gIdSeleccionado,
                fun_obtener_id(Cbo_Auditado), fun_obtener_id(Cbo_Cronograma), fun_obtener_id(Cbo_Rubrica),
                fun_obtener_id(Cbo_Criterio), fun_obtener_id(Cbo_Escala),
                Txt_Porcentaje.Text, Txt_Ponderada.Text, Txt_Comentarios.Text);

            pro_mostrar_resultado(sResultado, "Ponderación modificada correctamente.");
        }

        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            DialogResult drConfirmar = MessageBox.Show("¿Está seguro de eliminar esta ponderación?",
                                                       "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (drConfirmar != DialogResult.Yes) return;

            pro_mostrar_resultado(gControlador.fun_eliminar(gIdSeleccionado), "Ponderación eliminada correctamente.");
        }

        private void Btn_Limpiar_Click(object sender, EventArgs e)
        {
            pro_limpiar_campos();
        }

        private void Dgv_Ponderacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow drFila = Dgv_Ponderacion.Rows[e.RowIndex];
            gIdSeleccionado = Convert.ToInt32(drFila.Cells["Id"].Value);

            Txt_Id.Text = gIdSeleccionado.ToString();
            Cbo_Auditado.SelectedValue = Convert.ToInt32(drFila.Cells["IdAuditado"].Value);
            Cbo_Cronograma.SelectedValue = Convert.ToInt32(drFila.Cells["IdCronograma"].Value);
            Cbo_Rubrica.SelectedValue = Convert.ToInt32(drFila.Cells["IdRubrica"].Value);
            Cbo_Criterio.SelectedValue = Convert.ToInt32(drFila.Cells["IdCriterio"].Value);
            Cbo_Escala.SelectedValue = Convert.ToInt32(drFila.Cells["IdEscala"].Value);
            Txt_Porcentaje.Text = Convert.ToDecimal(drFila.Cells["Porcentaje"].Value).ToString("0.##", CultureInfo.InvariantCulture);
            Txt_Ponderada.Text = Convert.ToDecimal(drFila.Cells["Ponderada"].Value).ToString("0.##", CultureInfo.InvariantCulture);
            Txt_Comentarios.Text = drFila.Cells["Comentarios"].Value == DBNull.Value
                ? "" : Convert.ToString(drFila.Cells["Comentarios"].Value);
            Txt_Fecha.Text = drFila.Cells["Fecha"].Value == DBNull.Value
                ? "" : Convert.ToDateTime(drFila.Cells["Fecha"].Value).ToString("dd/MM/yyyy HH:mm");

            Btn_Guardar.Enabled = false;
            Btn_Modificar.Enabled = true;
            Btn_Eliminar.Enabled = true;
        }
    }
}
