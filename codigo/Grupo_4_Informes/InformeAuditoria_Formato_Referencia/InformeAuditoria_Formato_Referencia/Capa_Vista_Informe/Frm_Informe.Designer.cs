namespace Capa_Vista_Informe
{
    partial class Frm_Informe
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitulo;
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblInforme = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cmbInformes = new System.Windows.Forms.ComboBox();
            this.btnCargar = new System.Windows.Forms.Button();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(26, 98, 130);
            this.lblTitulo.Location = new System.Drawing.Point(30, 25);
            this.lblTitulo.Text = "INFORME DE REVISIÓN — PDF";

            this.lblInforme.AutoSize = true;
            this.lblInforme.Location = new System.Drawing.Point(33, 102);
            this.lblInforme.Text = "Informe:";

            this.cmbInformes.Location = new System.Drawing.Point(143, 98);
            this.cmbInformes.Size = new System.Drawing.Size(490, 28);
            this.cmbInformes.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.cmbInformes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInformes.FormattingEnabled = true;

            this.btnCargar.Location = new System.Drawing.Point(143, 163);
            this.btnCargar.Size = new System.Drawing.Size(210, 42);
            this.btnCargar.Text = "Cargar informes";
            this.btnCargar.UseVisualStyleBackColor = true;

            this.btnGenerar.Location = new System.Drawing.Point(377, 163);
            this.btnGenerar.Size = new System.Drawing.Size(256, 42);
            this.btnGenerar.Text = "Generar PDF";
            this.btnGenerar.Enabled = false;
            this.btnGenerar.UseVisualStyleBackColor = true;

            this.lblEstado.AutoSize = false;
            this.lblEstado.Location = new System.Drawing.Point(33, 246);
            this.lblEstado.Size = new System.Drawing.Size(605, 52);
            this.lblEstado.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.lblEstado.Text = "La conexión se obtiene desde la DLL Capa_Modelo_Seguridad.";

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 329);
            this.MinimumSize = new System.Drawing.Size(690, 365);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "Frm_Informe";
            this.Text = "Módulo de informes";
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblInforme);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.cmbInformes);
            this.Controls.Add(this.btnCargar);
            this.Controls.Add(this.btnGenerar);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
