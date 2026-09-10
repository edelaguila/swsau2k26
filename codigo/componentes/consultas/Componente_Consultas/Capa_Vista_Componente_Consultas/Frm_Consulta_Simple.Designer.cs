
namespace Capa_Vista_Componente_Consultas
{
    partial class Frm_Consulta_Simple
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
            this.consulta_simple1 = new Capa_Vista_Componente_Consultas_simples.Consulta_simple();
            this.SuspendLayout();
            // 
            // consulta_simple1
            // 
            this.consulta_simple1.Location = new System.Drawing.Point(-3, -1);
            this.consulta_simple1.Name = "consulta_simple1";
            this.consulta_simple1.Size = new System.Drawing.Size(823, 473);
            this.consulta_simple1.sNombreTablaExterna = null;
            this.consulta_simple1.TabIndex = 0;
            // 
            // Frm_Consulta_Simple
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 530);
            this.Controls.Add(this.consulta_simple1);
            this.Name = "Frm_Consulta_Simple";
            this.Text = "Frm_Consulta_Simple";
            this.ResumeLayout(false);

        }

        #endregion

        private Capa_Vista_Componente_Consultas_simples.Consulta_simple consulta_simple1;
    }
}