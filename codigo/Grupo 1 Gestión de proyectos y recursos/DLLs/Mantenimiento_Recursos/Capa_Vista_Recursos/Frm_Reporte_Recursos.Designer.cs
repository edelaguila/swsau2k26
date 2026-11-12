namespace Capa_Vista_Recursos
{
    partial class Frm_Reporte_Recursos
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
            this.Crv_Recursos = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // Crv_Recursos
            // 
            this.Crv_Recursos.ActiveViewIndex = -1;
            this.Crv_Recursos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Crv_Recursos.Cursor = System.Windows.Forms.Cursors.Default;
            this.Crv_Recursos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Crv_Recursos.Location = new System.Drawing.Point(0, 0);
            this.Crv_Recursos.Name = "Crv_Recursos";
            this.Crv_Recursos.Size = new System.Drawing.Size(1000, 600);
            this.Crv_Recursos.TabIndex = 0;
            // 
            // Frm_Reporte_Recursos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.Crv_Recursos);
            this.MinimumSize = new System.Drawing.Size(850, 550);
            this.Name = "Frm_Reporte_Recursos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de Recursos";
            this.Load += new System.EventHandler(this.Frm_Reporte_Recursos_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer Crv_Recursos;
    }
}
