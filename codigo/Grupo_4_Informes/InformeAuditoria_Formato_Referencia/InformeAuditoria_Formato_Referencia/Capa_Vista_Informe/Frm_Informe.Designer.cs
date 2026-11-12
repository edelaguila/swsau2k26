namespace Capa_Vista_Informe
{
    partial class Frm_Informe
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblInforme;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cmbInformes;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.Button btnGenerar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Informe));
            this.lblInforme = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cmbInformes = new System.Windows.Forms.ComboBox();
            this.btnCargar = new System.Windows.Forms.Button();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.Gpb_Datos = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();


            this.lblInforme.AutoSize = true;
            this.lblInforme.Location = new System.Drawing.Point(20, 39);
            this.lblInforme.Text = "Informe:";
            this.lblInforme.Font = new System.Drawing.Font("Rockwell", 10F);

            this.cmbInformes.Location = new System.Drawing.Point(120, 35);
            this.cmbInformes.Size = new System.Drawing.Size(824, 28);
            this.cmbInformes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInformes.FormattingEnabled = true;
            this.cmbInformes.Font = new System.Drawing.Font("Rockwell", 10F);

            this.btnCargar.Location = new System.Drawing.Point(13, 15);
            this.btnCargar.Size = new System.Drawing.Size(97, 93);
            this.btnCargar.Text = "Cargar";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.btnCargar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCargar.Image = ((System.Drawing.Image)(resources.GetObject("btnCargar.Image")));

            this.btnGenerar.Location = new System.Drawing.Point(121, 15);
            this.btnGenerar.Size = new System.Drawing.Size(97, 93);
            this.btnGenerar.Text = "Generar PDF";
            this.btnGenerar.Enabled = false;
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.btnGenerar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGenerar.Image = ((System.Drawing.Image)(resources.GetObject("btnGenerar.Image")));

            this.lblEstado.AutoSize = false;
            this.lblEstado.Location = new System.Drawing.Point(20, 79);
            this.lblEstado.Size = new System.Drawing.Size(924, 40);
            this.lblEstado.Text = "La conexión se obtiene desde la DLL Capa_Modelo_Seguridad.";
            this.lblEstado.Font = new System.Drawing.Font("Rockwell", 10F);

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 263);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            // 
            // btnSalir
            // 
            this.btnSalir.Text = "Salir";
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Location = new System.Drawing.Point(229, 15);
            this.btnSalir.Size = new System.Drawing.Size(97, 93);
            this.btnSalir.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCargar);
            this.Controls.Add(this.btnGenerar);
            // 
            // Gpb_Datos
            // 
            this.Gpb_Datos.Location = new System.Drawing.Point(13, 123);
            this.Gpb_Datos.Size = new System.Drawing.Size(964, 125);
            this.Gpb_Datos.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Gpb_Datos.TabStop = false;
            this.Gpb_Datos.Text = "Informe de revisión (PDF)";
            this.Gpb_Datos.Name = "Gpb_Datos";
            this.Controls.Add(this.Gpb_Datos);
            this.Gpb_Datos.Controls.Add(this.lblInforme);
            this.Gpb_Datos.Controls.Add(this.cmbInformes);
            this.Gpb_Datos.Controls.Add(this.lblEstado);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(194)))), ((int)(((byte)(99)))));
            this.Name = "Frm_Informe";
            this.Text = "Informe Final";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.GroupBox Gpb_Datos;
    }
}
