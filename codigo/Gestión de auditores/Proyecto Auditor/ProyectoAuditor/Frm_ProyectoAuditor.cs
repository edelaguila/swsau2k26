//Inicio del código de "Barbara Saldaña" con carné: "0901-22-9136" en la fecha de : "16/10/26"
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Capa_Controlador_ProAuditor;

namespace Capa_Vista_ProAuditor
{
    public partial class Frm_ProyectoAuditor : Form
    {
        private Cls_Controlador_ProyectoAuditor gControlador = new Cls_Controlador_ProyectoAuditor();

        private int gIdSeleccionado = 0;
        private bool gCargando = true;

        private readonly Color gColorArea = Color.FromArgb(0, 170, 255);
        private readonly Font gFuenteTitulo = new Font("Rockwell", 18, FontStyle.Bold);
        private readonly Font gFuenteSubtitulo = new Font("Rockwell", 11);
        private readonly Font gFuenteTexto = new Font("Rockwell", 10);

        public Frm_ProyectoAuditor()
        {
            InitializeComponent();
            pro_aplicar_estilo();
            pro_enlazar_eventos();
        }

        private void pro_aplicar_estilo()
        {
            Text = "Proyecto Auditor";
            Font = gFuenteTexto;
            MinimumSize = new Size(850, 550);
            StartPosition = FormStartPosition.CenterScreen;
            MinimizeBox = true; MaximizeBox = true; ControlBox = true;

            Pnl_Encabezado.BackColor = gColorArea;
            Lbl_Titulo.Font = gFuenteTitulo; Lbl_Titulo.ForeColor = Color.Black;
            Lbl_Subtitulo.Font = gFuenteSubtitulo; Lbl_Subtitulo.ForeColor = Color.Black;
            Gpb_Datos.Font = gFuenteSubtitulo;

            foreach (Control Ctrl in Gpb_Datos.Controls)
                if (!(Ctrl is Button)) Ctrl.Font = gFuenteTexto;
            Txt_Buscar.Font = gFuenteTexto;
            Cbo_Proyecto.DropDownStyle = ComboBoxStyle.DropDownList;
            Cbo_Auditor.DropDownStyle = ComboBoxStyle.DropDownList;
            Cbo_Perfil.DropDownStyle = ComboBoxStyle.DropDownList;
            Dtp_Fecha.Format = DateTimePickerFormat.Short;

            foreach (Button Btn in new[] { Btn_Nuevo, Btn_Guardar, Btn_Modificar, Btn_Eliminar, Btn_Cancelar, Btn_Buscar })
            {
                Btn.Font = gFuenteTexto;
                Btn.FlatStyle = FlatStyle.Flat;
                Btn.FlatAppearance.BorderSize = 0;
                Btn.BackColor = gColorArea;
                Btn.ForeColor = Color.White;
                Btn.Cursor = Cursors.Hand;
            }

            Dgv_ProyectoAuditor.ReadOnly = true;
            Dgv_ProyectoAuditor.AllowUserToAddRows = false;
            Dgv_ProyectoAuditor.AllowUserToDeleteRows = false;
            Dgv_ProyectoAuditor.MultiSelect = false;
            Dgv_ProyectoAuditor.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Dgv_ProyectoAuditor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Dgv_ProyectoAuditor.RowHeadersVisible = false;
            Dgv_ProyectoAuditor.Font = gFuenteTexto;
            Dgv_ProyectoAuditor.EnableHeadersVisualStyles = false;
            Dgv_ProyectoAuditor.ColumnHeadersDefaultCellStyle.BackColor = gColorArea;
            Dgv_ProyectoAuditor.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void pro_enlazar_eventos()
        {
            Load += Frm_ProyectoAuditor_Load;
            Btn_Nuevo.Click += Btn_Nuevo_Click;
            Btn_Guardar.Click += Btn_Guardar_Click;
            Btn_Modificar.Click += Btn_Modificar_Click;
            Btn_Eliminar.Click += Btn_Eliminar_Click;
            Btn_Cancelar.Click += Btn_Cancelar_Click;
            Btn_Buscar.Click += Btn_Buscar_Click;
            Dgv_ProyectoAuditor.SelectionChanged += Dgv_ProyectoAuditor_SelectionChanged;
        }

        // ---- Carga inicial ----
        private void Frm_ProyectoAuditor_Load(object sender, EventArgs e)
        {
            try
            {
                pro_cargar_combo(Cbo_Proyecto, gControlador.fun_combo_proyectos());
                pro_cargar_combo(Cbo_Auditor, gControlador.fun_combo_auditores());
                pro_cargar_combo(Cbo_Perfil, gControlador.fun_combo_perfiles());
                pro_cargar_tabla("");
                gCargando = false;
                pro_modo_nuevo();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error al cargar el formulario: " + Ex.Message, "Proyecto Auditor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pro_cargar_combo(ComboBox Cbo, DataTable Dts_Datos)
        {
            Cbo.DataSource = Dts_Datos;
            Cbo.DisplayMember = "Nombre";
            Cbo.ValueMember = "Id";
            Cbo.SelectedIndex = -1;
        }

        private void pro_cargar_tabla(string sFiltro)
        {
            Dgv_ProyectoAuditor.DataSource = gControlador.fun_listar(sFiltro);
            foreach (string sColumna in new[] { "Pk_Id_Proyecto_Auditor", "Fk_Id_Proyecto", "Fk_Id_Auditor", "Fk_Id_Perfil_Auditor" })
                if (Dgv_ProyectoAuditor.Columns[sColumna] != null) Dgv_ProyectoAuditor.Columns[sColumna].Visible = false;
            Dgv_ProyectoAuditor.ClearSelection();
        }

        // ---- Estados del formulario ----
        private void pro_modo_nuevo()
        {
            gIdSeleccionado = 0;
            Cbo_Proyecto.SelectedIndex = -1;
            Cbo_Auditor.SelectedIndex = -1;
            Cbo_Perfil.SelectedIndex = -1;
            Dtp_Fecha.Value = DateTime.Today;
            Dgv_ProyectoAuditor.ClearSelection();
            Btn_Guardar.Enabled = true;
            Btn_Modificar.Enabled = false;
            Btn_Eliminar.Enabled = false;
        }

        private void pro_modo_seleccion()
        {
            Btn_Guardar.Enabled = false;
            Btn_Modificar.Enabled = true;
            Btn_Eliminar.Enabled = true;
        }

        private void Dgv_ProyectoAuditor_SelectionChanged(object sender, EventArgs e)
        {
            if (gCargando || Dgv_ProyectoAuditor.CurrentRow == null || !Dgv_ProyectoAuditor.CurrentRow.Selected) return;

            DataGridViewRow Fila = Dgv_ProyectoAuditor.CurrentRow;
            gIdSeleccionado = Convert.ToInt32(Fila.Cells["Pk_Id_Proyecto_Auditor"].Value);
            Cbo_Proyecto.SelectedValue = Convert.ToInt32(Fila.Cells["Fk_Id_Proyecto"].Value);
            Cbo_Auditor.SelectedValue = Convert.ToInt32(Fila.Cells["Fk_Id_Auditor"].Value);
            Cbo_Perfil.SelectedValue = Convert.ToInt32(Fila.Cells["Fk_Id_Perfil_Auditor"].Value);

            object oFecha = Fila.Cells["Fecha_Asignacion"].Value;
            Dtp_Fecha.Value = (oFecha == null || oFecha == DBNull.Value) ? DateTime.Today : Convert.ToDateTime(oFecha);
            pro_modo_seleccion();
        }

        private int fun_valor_combo(ComboBox Cbo)
        {
            return Cbo.SelectedValue == null ? 0 : Convert.ToInt32(Cbo.SelectedValue);
        }

        private void pro_resultado(bool bExito, string sMensaje)
        {
            MessageBox.Show(sMensaje, "Proyecto Auditor", MessageBoxButtons.OK, bExito ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            if (bExito)
            {
                pro_cargar_tabla(Txt_Buscar.Text.Trim());
                pro_modo_nuevo();
            }
        }

        // ---- Eventos de botones ----
        private void Btn_Nuevo_Click(object sender, EventArgs e) { pro_modo_nuevo(); }
        private void Btn_Cancelar_Click(object sender, EventArgs e) { pro_modo_nuevo(); }

        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            try { pro_cargar_tabla(Txt_Buscar.Text.Trim()); pro_modo_nuevo(); }
            catch (Exception Ex) { MessageBox.Show("Error al buscar: " + Ex.Message); }
        }

        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            string sMensaje;
            bool bExito = gControlador.fun_guardar(fun_valor_combo(Cbo_Proyecto), fun_valor_combo(Cbo_Auditor),
                                                   fun_valor_combo(Cbo_Perfil), Dtp_Fecha.Value, out sMensaje);
            pro_resultado(bExito, sMensaje);
        }

        private void Btn_Modificar_Click(object sender, EventArgs e)
        {
            string sMensaje;
            bool bExito = gControlador.fun_modificar(gIdSeleccionado, fun_valor_combo(Cbo_Proyecto), fun_valor_combo(Cbo_Auditor),
                                                     fun_valor_combo(Cbo_Perfil), Dtp_Fecha.Value, out sMensaje);
            pro_resultado(bExito, sMensaje);
        }

        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea eliminar la asignación seleccionada?", "Proyecto Auditor",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            string sMensaje;
            bool bExito = gControlador.fun_eliminar(gIdSeleccionado, out sMensaje);
            pro_resultado(bExito, sMensaje);
        }

        private void Lbl_Titulo_Click(object sender, EventArgs e)
        {

        }
    }
}
//fin del código de "Barbara Saldaña" con carné: "0901-22-9136" en la fecha de : "16/10/26"
