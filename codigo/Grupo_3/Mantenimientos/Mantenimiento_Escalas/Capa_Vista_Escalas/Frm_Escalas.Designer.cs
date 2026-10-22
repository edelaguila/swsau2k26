namespace Capa_Vista_Escalas
{
    partial class Frm_Escalas
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
            this.navegador1 = new Capa_Vista_Navegador.Navegador();
            this.Btn_Ayudas = new System.Windows.Forms.Button();
            this.Btn_Reportes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // navegador1
            // 
            this.navegador1.IPkId_Aplicacion = 0;
            this.navegador1.IPkId_Modulo = 0;
            this.navegador1.Location = new System.Drawing.Point(16, 15);
            this.navegador1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.navegador1.Name = "navegador1";
            this.navegador1.SAlias = null;
            this.navegador1.SEtiquetas = null;
            this.navegador1.Size = new System.Drawing.Size(1573, 601);
            this.navegador1.SNombreTabla = null;
            this.navegador1.TabIndex = 0;
            // 
            // Btn_Ayudas
            // 
            this.Btn_Ayudas.Location = new System.Drawing.Point(1305, 15);
            this.Btn_Ayudas.Name = "Btn_Ayudas";
            this.Btn_Ayudas.Size = new System.Drawing.Size(97, 115);
            this.Btn_Ayudas.TabIndex = 1;
            this.Btn_Ayudas.Text = "Ayudas";
            this.Btn_Ayudas.UseVisualStyleBackColor = true;
            this.Btn_Ayudas.Click += new System.EventHandler(this.Btn_Ayudas_Click);
            // 
            // Btn_Reportes
            // 
            this.Btn_Reportes.Location = new System.Drawing.Point(662, 15);
            this.Btn_Reportes.Name = "Btn_Reportes";
            this.Btn_Reportes.Size = new System.Drawing.Size(98, 115);
            this.Btn_Reportes.TabIndex = 2;
            this.Btn_Reportes.Text = "Reportes";
            this.Btn_Reportes.UseVisualStyleBackColor = true;
            this.Btn_Reportes.Click += new System.EventHandler(this.Btn_Reportes_Click);
            // 
            // Frm_Escalas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1676, 602);
            this.Controls.Add(this.Btn_Reportes);
            this.Controls.Add(this.Btn_Ayudas);
            this.Controls.Add(this.navegador1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Frm_Escalas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_Escalas";
            this.ResumeLayout(false);

        }

        #endregion

        private Capa_Vista_Navegador.Navegador navegador1;
        private System.Windows.Forms.Button Btn_Ayudas;
        private System.Windows.Forms.Button Btn_Reportes;
    }
}