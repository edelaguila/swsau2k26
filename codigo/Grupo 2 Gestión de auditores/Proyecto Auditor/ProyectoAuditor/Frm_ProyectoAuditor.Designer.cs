
namespace Capa_Vista_ProAuditor
{
    partial class Frm_ProyectoAuditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Pnl_Encabezado = new System.Windows.Forms.Panel();
            this.Lbl_Titulo = new System.Windows.Forms.Label();
            this.Lbl_Subtitulo = new System.Windows.Forms.Label();
            this.Lbl_Proyecto = new System.Windows.Forms.Label();
            this.Cbo_Proyecto = new System.Windows.Forms.ComboBox();
            this.Lbl_Auditor = new System.Windows.Forms.Label();
            this.Cbo_Auditor = new System.Windows.Forms.ComboBox();
            this.Lbl_Perfil = new System.Windows.Forms.Label();
            this.Cbo_Perfil = new System.Windows.Forms.ComboBox();
            this.Lbl_Fecha = new System.Windows.Forms.Label();
            this.Dtp_Fecha = new System.Windows.Forms.DateTimePicker();
            this.Btn_Nuevo = new System.Windows.Forms.Button();
            this.Btn_Guardar = new System.Windows.Forms.Button();
            this.Btn_Modificar = new System.Windows.Forms.Button();
            this.Btn_Eliminar = new System.Windows.Forms.Button();
            this.Btn_Cancelar = new System.Windows.Forms.Button();
            this.Pnl_Busqueda = new System.Windows.Forms.Panel();
            this.Lbl_Buscar = new System.Windows.Forms.Label();
            this.Txt_Buscar = new System.Windows.Forms.TextBox();
            this.Btn_Buscar = new System.Windows.Forms.Button();
            this.Dgv_ProyectoAuditor = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.Cbo_CodApl = new System.Windows.Forms.ComboBox();
            this.btn_Reporte = new System.Windows.Forms.Button();
            this.Pnl_Encabezado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_ProyectoAuditor)).BeginInit();
            this.SuspendLayout();
            // 
            // Pnl_Encabezado
            // 
            this.Pnl_Encabezado.Controls.Add(this.btn_Reporte);
            this.Pnl_Encabezado.Location = new System.Drawing.Point(13, 2);
            this.Pnl_Encabezado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Pnl_Encabezado.Name = "Pnl_Encabezado";
            this.Pnl_Encabezado.Size = new System.Drawing.Size(874, 32);
            this.Pnl_Encabezado.TabIndex = 0;
            // 
            // Lbl_Titulo
            // 
            this.Lbl_Titulo.AutoSize = true;
            this.Lbl_Titulo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Lbl_Titulo.Location = new System.Drawing.Point(13, 41);
            this.Lbl_Titulo.Name = "Lbl_Titulo";
            this.Lbl_Titulo.Size = new System.Drawing.Size(141, 17);
            this.Lbl_Titulo.TabIndex = 1;
            this.Lbl_Titulo.Text = "Gestión de Auditores";
            this.Lbl_Titulo.Click += new System.EventHandler(this.Lbl_Titulo_Click);
            // 
            // Lbl_Subtitulo
            // 
            this.Lbl_Subtitulo.AutoSize = true;
            this.Lbl_Subtitulo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Lbl_Subtitulo.Location = new System.Drawing.Point(13, 71);
            this.Lbl_Subtitulo.Name = "Lbl_Subtitulo";
            this.Lbl_Subtitulo.Size = new System.Drawing.Size(113, 17);
            this.Lbl_Subtitulo.TabIndex = 2;
            this.Lbl_Subtitulo.Text = "Proyecto Auditor";
            // 
            // Lbl_Proyecto
            // 
            this.Lbl_Proyecto.AutoSize = true;
            this.Lbl_Proyecto.Location = new System.Drawing.Point(21, 133);
            this.Lbl_Proyecto.Name = "Lbl_Proyecto";
            this.Lbl_Proyecto.Size = new System.Drawing.Size(64, 17);
            this.Lbl_Proyecto.TabIndex = 4;
            this.Lbl_Proyecto.Text = "Proyecto";
            // 
            // Cbo_Proyecto
            // 
            this.Cbo_Proyecto.FormattingEnabled = true;
            this.Cbo_Proyecto.Location = new System.Drawing.Point(92, 133);
            this.Cbo_Proyecto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Cbo_Proyecto.Name = "Cbo_Proyecto";
            this.Cbo_Proyecto.Size = new System.Drawing.Size(200, 24);
            this.Cbo_Proyecto.TabIndex = 5;
            // 
            // Lbl_Auditor
            // 
            this.Lbl_Auditor.AutoSize = true;
            this.Lbl_Auditor.Location = new System.Drawing.Point(299, 133);
            this.Lbl_Auditor.Name = "Lbl_Auditor";
            this.Lbl_Auditor.Size = new System.Drawing.Size(53, 17);
            this.Lbl_Auditor.TabIndex = 6;
            this.Lbl_Auditor.Text = "Auditor";
            // 
            // Cbo_Auditor
            // 
            this.Cbo_Auditor.FormattingEnabled = true;
            this.Cbo_Auditor.Location = new System.Drawing.Point(380, 130);
            this.Cbo_Auditor.Margin = new System.Windows.Forms.Padding(4);
            this.Cbo_Auditor.Name = "Cbo_Auditor";
            this.Cbo_Auditor.Size = new System.Drawing.Size(200, 24);
            this.Cbo_Auditor.TabIndex = 7;
            this.Cbo_Auditor.SelectedIndexChanged += new System.EventHandler(this.Cbo_Auditor_SelectedIndexChanged);
            // 
            // Lbl_Perfil
            // 
            this.Lbl_Perfil.AutoSize = true;
            this.Lbl_Perfil.Location = new System.Drawing.Point(625, 134);
            this.Lbl_Perfil.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_Perfil.Name = "Lbl_Perfil";
            this.Lbl_Perfil.Size = new System.Drawing.Size(40, 17);
            this.Lbl_Perfil.TabIndex = 8;
            this.Lbl_Perfil.Text = "Perfil";
            // 
            // Cbo_Perfil
            // 
            this.Cbo_Perfil.FormattingEnabled = true;
            this.Cbo_Perfil.Location = new System.Drawing.Point(687, 130);
            this.Cbo_Perfil.Margin = new System.Windows.Forms.Padding(4);
            this.Cbo_Perfil.Name = "Cbo_Perfil";
            this.Cbo_Perfil.Size = new System.Drawing.Size(200, 24);
            this.Cbo_Perfil.TabIndex = 9;
            // 
            // Lbl_Fecha
            // 
            this.Lbl_Fecha.AutoSize = true;
            this.Lbl_Fecha.Location = new System.Drawing.Point(19, 173);
            this.Lbl_Fecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_Fecha.Name = "Lbl_Fecha";
            this.Lbl_Fecha.Size = new System.Drawing.Size(47, 17);
            this.Lbl_Fecha.TabIndex = 10;
            this.Lbl_Fecha.Text = "Fecha";
            // 
            // Dtp_Fecha
            // 
            this.Dtp_Fecha.Location = new System.Drawing.Point(108, 165);
            this.Dtp_Fecha.Margin = new System.Windows.Forms.Padding(4);
            this.Dtp_Fecha.Name = "Dtp_Fecha";
            this.Dtp_Fecha.Size = new System.Drawing.Size(200, 22);
            this.Dtp_Fecha.TabIndex = 11;
            // 
            // Btn_Nuevo
            // 
            this.Btn_Nuevo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Btn_Nuevo.Location = new System.Drawing.Point(340, 49);
            this.Btn_Nuevo.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_Nuevo.Name = "Btn_Nuevo";
            this.Btn_Nuevo.Size = new System.Drawing.Size(103, 39);
            this.Btn_Nuevo.TabIndex = 12;
            this.Btn_Nuevo.Text = "Nuevo";
            this.Btn_Nuevo.UseVisualStyleBackColor = true;
            this.Btn_Nuevo.Click += new System.EventHandler(this.Btn_Nuevo_Click_1);
            // 
            // Btn_Guardar
            // 
            this.Btn_Guardar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Btn_Guardar.Location = new System.Drawing.Point(451, 49);
            this.Btn_Guardar.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_Guardar.Name = "Btn_Guardar";
            this.Btn_Guardar.Size = new System.Drawing.Size(103, 39);
            this.Btn_Guardar.TabIndex = 13;
            this.Btn_Guardar.Text = "Guardar";
            this.Btn_Guardar.UseVisualStyleBackColor = true;
            // 
            // Btn_Modificar
            // 
            this.Btn_Modificar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Btn_Modificar.Location = new System.Drawing.Point(562, 49);
            this.Btn_Modificar.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_Modificar.Name = "Btn_Modificar";
            this.Btn_Modificar.Size = new System.Drawing.Size(103, 39);
            this.Btn_Modificar.TabIndex = 14;
            this.Btn_Modificar.Text = "Modificar";
            this.Btn_Modificar.UseVisualStyleBackColor = true;
            // 
            // Btn_Eliminar
            // 
            this.Btn_Eliminar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Btn_Eliminar.Location = new System.Drawing.Point(673, 49);
            this.Btn_Eliminar.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_Eliminar.Name = "Btn_Eliminar";
            this.Btn_Eliminar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Btn_Eliminar.Size = new System.Drawing.Size(103, 39);
            this.Btn_Eliminar.TabIndex = 15;
            this.Btn_Eliminar.Text = "Eliminar";
            this.Btn_Eliminar.UseVisualStyleBackColor = true;
            // 
            // Btn_Cancelar
            // 
            this.Btn_Cancelar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Btn_Cancelar.Location = new System.Drawing.Point(784, 49);
            this.Btn_Cancelar.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_Cancelar.Name = "Btn_Cancelar";
            this.Btn_Cancelar.Size = new System.Drawing.Size(103, 39);
            this.Btn_Cancelar.TabIndex = 16;
            this.Btn_Cancelar.Text = "Cancelar";
            this.Btn_Cancelar.UseVisualStyleBackColor = true;
            // 
            // Pnl_Busqueda
            // 
            this.Pnl_Busqueda.Location = new System.Drawing.Point(24, 207);
            this.Pnl_Busqueda.Margin = new System.Windows.Forms.Padding(4);
            this.Pnl_Busqueda.Name = "Pnl_Busqueda";
            this.Pnl_Busqueda.Size = new System.Drawing.Size(803, 12);
            this.Pnl_Busqueda.TabIndex = 17;
            // 
            // Lbl_Buscar
            // 
            this.Lbl_Buscar.AutoSize = true;
            this.Lbl_Buscar.Location = new System.Drawing.Point(21, 239);
            this.Lbl_Buscar.Name = "Lbl_Buscar";
            this.Lbl_Buscar.Size = new System.Drawing.Size(52, 17);
            this.Lbl_Buscar.TabIndex = 18;
            this.Lbl_Buscar.Text = "Buscar";
            // 
            // Txt_Buscar
            // 
            this.Txt_Buscar.Location = new System.Drawing.Point(104, 234);
            this.Txt_Buscar.Margin = new System.Windows.Forms.Padding(4);
            this.Txt_Buscar.Name = "Txt_Buscar";
            this.Txt_Buscar.Size = new System.Drawing.Size(688, 22);
            this.Txt_Buscar.TabIndex = 19;
            // 
            // Btn_Buscar
            // 
            this.Btn_Buscar.Location = new System.Drawing.Point(812, 234);
            this.Btn_Buscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_Buscar.Name = "Btn_Buscar";
            this.Btn_Buscar.Size = new System.Drawing.Size(75, 23);
            this.Btn_Buscar.TabIndex = 20;
            this.Btn_Buscar.Text = "Buscar";
            this.Btn_Buscar.UseVisualStyleBackColor = true;
            // 
            // Dgv_ProyectoAuditor
            // 
            this.Dgv_ProyectoAuditor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_ProyectoAuditor.Location = new System.Drawing.Point(22, 274);
            this.Dgv_ProyectoAuditor.Margin = new System.Windows.Forms.Padding(4);
            this.Dgv_ProyectoAuditor.Name = "Dgv_ProyectoAuditor";
            this.Dgv_ProyectoAuditor.RowHeadersWidth = 51;
            this.Dgv_ProyectoAuditor.RowTemplate.Height = 24;
            this.Dgv_ProyectoAuditor.Size = new System.Drawing.Size(865, 206);
            this.Dgv_ProyectoAuditor.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(383, 165);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 17);
            this.label1.TabIndex = 22;
            this.label1.Text = "Código Aplicación";
            // 
            // Cbo_CodApl
            // 
            this.Cbo_CodApl.FormattingEnabled = true;
            this.Cbo_CodApl.Location = new System.Drawing.Point(580, 162);
            this.Cbo_CodApl.Margin = new System.Windows.Forms.Padding(4);
            this.Cbo_CodApl.Name = "Cbo_CodApl";
            this.Cbo_CodApl.Size = new System.Drawing.Size(265, 24);
            this.Cbo_CodApl.TabIndex = 23;
            // 
            // btn_Reporte
            // 
            this.btn_Reporte.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_Reporte.Location = new System.Drawing.Point(771, 0);
            this.btn_Reporte.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Reporte.Name = "btn_Reporte";
            this.btn_Reporte.Size = new System.Drawing.Size(103, 32);
            this.btn_Reporte.TabIndex = 24;
            this.btn_Reporte.Text = "Reporte";
            this.btn_Reporte.UseVisualStyleBackColor = true;
            this.btn_Reporte.Click += new System.EventHandler(this.btn_Reporte_Click);
            // 
            // Frm_ProyectoAuditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 736);
            this.Controls.Add(this.Cbo_CodApl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Dgv_ProyectoAuditor);
            this.Controls.Add(this.Btn_Buscar);
            this.Controls.Add(this.Txt_Buscar);
            this.Controls.Add(this.Lbl_Buscar);
            this.Controls.Add(this.Pnl_Busqueda);
            this.Controls.Add(this.Btn_Cancelar);
            this.Controls.Add(this.Btn_Eliminar);
            this.Controls.Add(this.Btn_Modificar);
            this.Controls.Add(this.Btn_Guardar);
            this.Controls.Add(this.Btn_Nuevo);
            this.Controls.Add(this.Dtp_Fecha);
            this.Controls.Add(this.Lbl_Fecha);
            this.Controls.Add(this.Cbo_Perfil);
            this.Controls.Add(this.Lbl_Perfil);
            this.Controls.Add(this.Cbo_Auditor);
            this.Controls.Add(this.Lbl_Auditor);
            this.Controls.Add(this.Cbo_Proyecto);
            this.Controls.Add(this.Lbl_Proyecto);
            this.Controls.Add(this.Lbl_Subtitulo);
            this.Controls.Add(this.Lbl_Titulo);
            this.Controls.Add(this.Pnl_Encabezado);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Frm_ProyectoAuditor";
            this.Text = "Frm_ProyectoAuditor";
            this.Load += new System.EventHandler(this.Frm_ProyectoAuditor_Load);
            this.Pnl_Encabezado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_ProyectoAuditor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Pnl_Encabezado;
        private System.Windows.Forms.Label Lbl_Titulo;
        private System.Windows.Forms.Label Lbl_Subtitulo;
        private System.Windows.Forms.Label Lbl_Proyecto;
        private System.Windows.Forms.ComboBox Cbo_Proyecto;
        private System.Windows.Forms.Label Lbl_Auditor;
        private System.Windows.Forms.ComboBox Cbo_Auditor;
        private System.Windows.Forms.Label Lbl_Perfil;
        private System.Windows.Forms.ComboBox Cbo_Perfil;
        private System.Windows.Forms.Label Lbl_Fecha;
        private System.Windows.Forms.DateTimePicker Dtp_Fecha;
        private System.Windows.Forms.Button Btn_Nuevo;
        private System.Windows.Forms.Button Btn_Guardar;
        private System.Windows.Forms.Button Btn_Modificar;
        private System.Windows.Forms.Button Btn_Eliminar;
        private System.Windows.Forms.Button Btn_Cancelar;
        private System.Windows.Forms.Panel Pnl_Busqueda;
        private System.Windows.Forms.Label Lbl_Buscar;
        private System.Windows.Forms.TextBox Txt_Buscar;
        private System.Windows.Forms.Button Btn_Buscar;
        private System.Windows.Forms.DataGridView Dgv_ProyectoAuditor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Cbo_CodApl;
        private System.Windows.Forms.Button btn_Reporte;
    }
}