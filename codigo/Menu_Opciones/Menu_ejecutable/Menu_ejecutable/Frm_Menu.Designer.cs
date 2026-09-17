namespace Menu_ejecutable
{
    partial class Frm_Menu
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.pnlOpciones = new System.Windows.Forms.Panel();
            this.Btn_Seguridad = new System.Windows.Forms.Button();
            this.Btn_Auditoria = new System.Windows.Forms.Button();
            this.lblAyuda = new System.Windows.Forms.Label();
            this.pnlLineaFooter = new System.Windows.Forms.Panel();
            this.lblFooter = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlOpciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(820, 120);
            this.pnlHeader.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 23F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0);
            this.label1.Size = new System.Drawing.Size(820, 120);
            this.label1.TabIndex = 5;
            this.label1.Text = "SISTEMA DE AUDITORES";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(190)))), ((int)(((byte)(220)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(0, 155);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(820, 30);
            this.lblSubtitulo.TabIndex = 7;
            this.lblSubtitulo.Text = "Seleccione el módulo al que desea ingresar";
            this.lblSubtitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlOpciones
            // 
            this.pnlOpciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(33)))), ((int)(((byte)(62)))));
            this.pnlOpciones.Controls.Add(this.Btn_Seguridad);
            this.pnlOpciones.Controls.Add(this.Btn_Auditoria);
            this.pnlOpciones.Location = new System.Drawing.Point(100, 205);
            this.pnlOpciones.Name = "pnlOpciones";
            this.pnlOpciones.Size = new System.Drawing.Size(620, 170);
            this.pnlOpciones.TabIndex = 8;
            // 
            // Btn_Seguridad
            // 
            this.Btn_Seguridad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(120)))), ((int)(((byte)(220)))));
            this.Btn_Seguridad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Seguridad.FlatAppearance.BorderSize = 0;
            this.Btn_Seguridad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Seguridad.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.Btn_Seguridad.ForeColor = System.Drawing.Color.White;
            this.Btn_Seguridad.Location = new System.Drawing.Point(35, 25);
            this.Btn_Seguridad.Name = "Btn_Seguridad";
            this.Btn_Seguridad.Size = new System.Drawing.Size(250, 120);
            this.Btn_Seguridad.TabIndex = 3;
            this.Btn_Seguridad.Text = "🔒\r\n\r\nSEGURIDAD";
            this.Btn_Seguridad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Btn_Seguridad.UseVisualStyleBackColor = false;
            this.Btn_Seguridad.Click += new System.EventHandler(this.Btn_Seguridad_Click_1);
            this.Btn_Seguridad.MouseEnter += new System.EventHandler(this.Btn_Seguridad_MouseEnter);
            this.Btn_Seguridad.MouseLeave += new System.EventHandler(this.Btn_Seguridad_MouseLeave);
            // 
            // Btn_Auditoria
            // 
            this.Btn_Auditoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(105)))));
            this.Btn_Auditoria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Auditoria.FlatAppearance.BorderSize = 0;
            this.Btn_Auditoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Auditoria.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.Btn_Auditoria.ForeColor = System.Drawing.Color.White;
            this.Btn_Auditoria.Location = new System.Drawing.Point(335, 25);
            this.Btn_Auditoria.Name = "Btn_Auditoria";
            this.Btn_Auditoria.Size = new System.Drawing.Size(250, 120);
            this.Btn_Auditoria.TabIndex = 4;
            this.Btn_Auditoria.Text = "📋\r\n\r\nAUDITORÍA";
            this.Btn_Auditoria.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Btn_Auditoria.UseVisualStyleBackColor = false;
            this.Btn_Auditoria.Click += new System.EventHandler(this.Btn_Auditoria_Click);
            this.Btn_Auditoria.MouseEnter += new System.EventHandler(this.Btn_Auditoria_MouseEnter);
            this.Btn_Auditoria.MouseLeave += new System.EventHandler(this.Btn_Auditoria_MouseLeave);
            // 
            // lblAyuda
            // 
            this.lblAyuda.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAyuda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(145)))), ((int)(((byte)(175)))));
            this.lblAyuda.Location = new System.Drawing.Point(0, 395);
            this.lblAyuda.Name = "lblAyuda";
            this.lblAyuda.Size = new System.Drawing.Size(820, 30);
            this.lblAyuda.TabIndex = 9;
            this.lblAyuda.Text = "Seguridad administra usuarios y accesos   •   Auditoría gestiona procesos de au" +
    "ditoría";
            this.lblAyuda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlLineaFooter
            // 
            this.pnlLineaFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(52)))), ((int)(((byte)(80)))));
            this.pnlLineaFooter.Location = new System.Drawing.Point(60, 455);
            this.pnlLineaFooter.Name = "pnlLineaFooter";
            this.pnlLineaFooter.Size = new System.Drawing.Size(700, 1);
            this.pnlLineaFooter.TabIndex = 10;
            // 
            // lblFooter
            // 
            this.lblFooter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFooter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(135)))), ((int)(((byte)(165)))));
            this.lblFooter.Location = new System.Drawing.Point(0, 465);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(820, 35);
            this.lblFooter.TabIndex = 11;
            this.lblFooter.Text = "Control Interno   •   Seguridad   •   Cumplimiento Normativo";
            this.lblFooter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Frm_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(27)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(820, 520);
            this.Controls.Add(this.lblFooter);
            this.Controls.Add(this.pnlLineaFooter);
            this.Controls.Add(this.lblAyuda);
            this.Controls.Add(this.pnlOpciones);
            this.Controls.Add(this.lblSubtitulo);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Auditoría y Seguridad";
            this.pnlHeader.ResumeLayout(false);
            this.pnlOpciones.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Panel pnlOpciones;
        private System.Windows.Forms.Button Btn_Auditoria;
        private System.Windows.Forms.Button Btn_Seguridad;
        private System.Windows.Forms.Label lblAyuda;
        private System.Windows.Forms.Panel pnlLineaFooter;
        private System.Windows.Forms.Label lblFooter;
    }
}
