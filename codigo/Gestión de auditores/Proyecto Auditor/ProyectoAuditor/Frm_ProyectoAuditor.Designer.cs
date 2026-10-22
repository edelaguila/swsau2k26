
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
            this.Gpb_Datos = new System.Windows.Forms.GroupBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_ProyectoAuditor)).BeginInit();
            this.SuspendLayout();
            // 
            // Pnl_Encabezado
            // 
            this.Pnl_Encabezado.Location = new System.Drawing.Point(10, 2);
            this.Pnl_Encabezado.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Pnl_Encabezado.Name = "Pnl_Encabezado";
            this.Pnl_Encabezado.Size = new System.Drawing.Size(610, 26);
            this.Pnl_Encabezado.TabIndex = 0;
            // 
            // Lbl_Titulo
            // 
            this.Lbl_Titulo.AutoSize = true;
            this.Lbl_Titulo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Lbl_Titulo.Location = new System.Drawing.Point(10, 33);
            this.Lbl_Titulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_Titulo.Name = "Lbl_Titulo";
            this.Lbl_Titulo.Size = new System.Drawing.Size(105, 13);
            this.Lbl_Titulo.TabIndex = 1;
            this.Lbl_Titulo.Text = "Gestión de Auditores";
            this.Lbl_Titulo.Click += new System.EventHandler(this.Lbl_Titulo_Click);
            // 
            // Lbl_Subtitulo
            // 
            this.Lbl_Subtitulo.AutoSize = true;
            this.Lbl_Subtitulo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Lbl_Subtitulo.Location = new System.Drawing.Point(10, 58);
            this.Lbl_Subtitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_Subtitulo.Name = "Lbl_Subtitulo";
            this.Lbl_Subtitulo.Size = new System.Drawing.Size(85, 13);
            this.Lbl_Subtitulo.TabIndex = 2;
            this.Lbl_Subtitulo.Text = "Proyecto Auditor";
            // 
            // Gpb_Datos
            // 
            this.Gpb_Datos.Location = new System.Drawing.Point(17, 159);
            this.Gpb_Datos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Gpb_Datos.Name = "Gpb_Datos";
            this.Gpb_Datos.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Gpb_Datos.Size = new System.Drawing.Size(602, 81);
            this.Gpb_Datos.TabIndex = 3;
            this.Gpb_Datos.TabStop = false;
            this.Gpb_Datos.Text = "Datos";
            // 
            // Lbl_Proyecto
            // 
            this.Lbl_Proyecto.AutoSize = true;
            this.Lbl_Proyecto.Location = new System.Drawing.Point(16, 108);
            this.Lbl_Proyecto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_Proyecto.Name = "Lbl_Proyecto";
            this.Lbl_Proyecto.Size = new System.Drawing.Size(49, 13);
            this.Lbl_Proyecto.TabIndex = 4;
            this.Lbl_Proyecto.Text = "Proyecto";
            // 
            // Cbo_Proyecto
            // 
            this.Cbo_Proyecto.FormattingEnabled = true;
            this.Cbo_Proyecto.Location = new System.Drawing.Point(69, 108);
            this.Cbo_Proyecto.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Cbo_Proyecto.Name = "Cbo_Proyecto";
            this.Cbo_Proyecto.Size = new System.Drawing.Size(151, 21);
            this.Cbo_Proyecto.TabIndex = 5;
            // 
            // Lbl_Auditor
            // 
            this.Lbl_Auditor.AutoSize = true;
            this.Lbl_Auditor.Location = new System.Drawing.Point(224, 108);
            this.Lbl_Auditor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_Auditor.Name = "Lbl_Auditor";
            this.Lbl_Auditor.Size = new System.Drawing.Size(40, 13);
            this.Lbl_Auditor.TabIndex = 6;
            this.Lbl_Auditor.Text = "Auditor";
            // 
            // Cbo_Auditor
            // 
            this.Cbo_Auditor.FormattingEnabled = true;
            this.Cbo_Auditor.Location = new System.Drawing.Point(268, 108);
            this.Cbo_Auditor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Cbo_Auditor.Name = "Cbo_Auditor";
            this.Cbo_Auditor.Size = new System.Drawing.Size(151, 21);
            this.Cbo_Auditor.TabIndex = 7;
            // 
            // Lbl_Perfil
            // 
            this.Lbl_Perfil.AutoSize = true;
            this.Lbl_Perfil.Location = new System.Drawing.Point(435, 110);
            this.Lbl_Perfil.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_Perfil.Name = "Lbl_Perfil";
            this.Lbl_Perfil.Size = new System.Drawing.Size(30, 13);
            this.Lbl_Perfil.TabIndex = 8;
            this.Lbl_Perfil.Text = "Perfil";
            // 
            // Cbo_Perfil
            // 
            this.Cbo_Perfil.FormattingEnabled = true;
            this.Cbo_Perfil.Location = new System.Drawing.Point(470, 107);
            this.Cbo_Perfil.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Cbo_Perfil.Name = "Cbo_Perfil";
            this.Cbo_Perfil.Size = new System.Drawing.Size(151, 21);
            this.Cbo_Perfil.TabIndex = 9;
            // 
            // Lbl_Fecha
            // 
            this.Lbl_Fecha.AutoSize = true;
            this.Lbl_Fecha.Location = new System.Drawing.Point(19, 137);
            this.Lbl_Fecha.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_Fecha.Name = "Lbl_Fecha";
            this.Lbl_Fecha.Size = new System.Drawing.Size(37, 13);
            this.Lbl_Fecha.TabIndex = 10;
            this.Lbl_Fecha.Text = "Fecha";
            // 
            // Dtp_Fecha
            // 
            this.Dtp_Fecha.Location = new System.Drawing.Point(69, 132);
            this.Dtp_Fecha.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Dtp_Fecha.Name = "Dtp_Fecha";
            this.Dtp_Fecha.Size = new System.Drawing.Size(151, 20);
            this.Dtp_Fecha.TabIndex = 11;
            // 
            // Btn_Nuevo
            // 
            this.Btn_Nuevo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Btn_Nuevo.Location = new System.Drawing.Point(314, 67);
            this.Btn_Nuevo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Btn_Nuevo.Name = "Btn_Nuevo";
            this.Btn_Nuevo.Size = new System.Drawing.Size(56, 26);
            this.Btn_Nuevo.TabIndex = 12;
            this.Btn_Nuevo.Text = "Nuevo";
            this.Btn_Nuevo.UseVisualStyleBackColor = true;
            // 
            // Btn_Guardar
            // 
            this.Btn_Guardar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Btn_Guardar.Location = new System.Drawing.Point(380, 67);
            this.Btn_Guardar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Btn_Guardar.Name = "Btn_Guardar";
            this.Btn_Guardar.Size = new System.Drawing.Size(56, 26);
            this.Btn_Guardar.TabIndex = 13;
            this.Btn_Guardar.Text = "Guardar";
            this.Btn_Guardar.UseVisualStyleBackColor = true;
            // 
            // Btn_Modificar
            // 
            this.Btn_Modificar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Btn_Modificar.Location = new System.Drawing.Point(441, 67);
            this.Btn_Modificar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Btn_Modificar.Name = "Btn_Modificar";
            this.Btn_Modificar.Size = new System.Drawing.Size(56, 26);
            this.Btn_Modificar.TabIndex = 14;
            this.Btn_Modificar.Text = "Modificar";
            this.Btn_Modificar.UseVisualStyleBackColor = true;
            // 
            // Btn_Eliminar
            // 
            this.Btn_Eliminar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Btn_Eliminar.Location = new System.Drawing.Point(502, 67);
            this.Btn_Eliminar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Btn_Eliminar.Name = "Btn_Eliminar";
            this.Btn_Eliminar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Btn_Eliminar.Size = new System.Drawing.Size(56, 26);
            this.Btn_Eliminar.TabIndex = 15;
            this.Btn_Eliminar.Text = "Eliminar";
            this.Btn_Eliminar.UseVisualStyleBackColor = true;
            // 
            // Btn_Cancelar
            // 
            this.Btn_Cancelar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Btn_Cancelar.Location = new System.Drawing.Point(563, 67);
            this.Btn_Cancelar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Btn_Cancelar.Name = "Btn_Cancelar";
            this.Btn_Cancelar.Size = new System.Drawing.Size(56, 26);
            this.Btn_Cancelar.TabIndex = 16;
            this.Btn_Cancelar.Text = "Cancelar";
            this.Btn_Cancelar.UseVisualStyleBackColor = true;
            // 
            // Pnl_Busqueda
            // 
            this.Pnl_Busqueda.Location = new System.Drawing.Point(17, 245);
            this.Pnl_Busqueda.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Pnl_Busqueda.Name = "Pnl_Busqueda";
            this.Pnl_Busqueda.Size = new System.Drawing.Size(602, 10);
            this.Pnl_Busqueda.TabIndex = 17;
            // 
            // Lbl_Buscar
            // 
            this.Lbl_Buscar.AutoSize = true;
            this.Lbl_Buscar.Location = new System.Drawing.Point(19, 265);
            this.Lbl_Buscar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_Buscar.Name = "Lbl_Buscar";
            this.Lbl_Buscar.Size = new System.Drawing.Size(40, 13);
            this.Lbl_Buscar.TabIndex = 18;
            this.Lbl_Buscar.Text = "Buscar";
            // 
            // Txt_Buscar
            // 
            this.Txt_Buscar.Location = new System.Drawing.Point(21, 281);
            this.Txt_Buscar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Txt_Buscar.Name = "Txt_Buscar";
            this.Txt_Buscar.Size = new System.Drawing.Size(539, 20);
            this.Txt_Buscar.TabIndex = 19;
            // 
            // Btn_Buscar
            // 
            this.Btn_Buscar.Location = new System.Drawing.Point(563, 280);
            this.Btn_Buscar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Btn_Buscar.Name = "Btn_Buscar";
            this.Btn_Buscar.Size = new System.Drawing.Size(56, 19);
            this.Btn_Buscar.TabIndex = 20;
            this.Btn_Buscar.Text = "Buscar";
            this.Btn_Buscar.UseVisualStyleBackColor = true;
            // 
            // Dgv_ProyectoAuditor
            // 
            this.Dgv_ProyectoAuditor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_ProyectoAuditor.Location = new System.Drawing.Point(21, 305);
            this.Dgv_ProyectoAuditor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Dgv_ProyectoAuditor.Name = "Dgv_ProyectoAuditor";
            this.Dgv_ProyectoAuditor.RowHeadersWidth = 51;
            this.Dgv_ProyectoAuditor.RowTemplate.Height = 24;
            this.Dgv_ProyectoAuditor.Size = new System.Drawing.Size(598, 167);
            this.Dgv_ProyectoAuditor.TabIndex = 21;
            // 
            // Frm_ProyectoAuditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(640, 486);
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
            this.Controls.Add(this.Gpb_Datos);
            this.Controls.Add(this.Lbl_Subtitulo);
            this.Controls.Add(this.Lbl_Titulo);
            this.Controls.Add(this.Pnl_Encabezado);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Frm_ProyectoAuditor";
            this.Text = "Frm_ProyectoAuditor";
            this.Load += new System.EventHandler(this.Frm_ProyectoAuditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_ProyectoAuditor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Pnl_Encabezado;
        private System.Windows.Forms.Label Lbl_Titulo;
        private System.Windows.Forms.Label Lbl_Subtitulo;
        private System.Windows.Forms.GroupBox Gpb_Datos;
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
    }
}