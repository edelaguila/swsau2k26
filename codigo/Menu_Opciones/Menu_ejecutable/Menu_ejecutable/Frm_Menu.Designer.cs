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
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_Auditoria = new System.Windows.Forms.Button();
            this.Btn_Seguridad = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(224, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 37);
            this.label1.TabIndex = 5;
            this.label1.Text = "Menú de opciones";
            // 
            // Btn_Auditoria
            // 
            this.Btn_Auditoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Auditoria.Location = new System.Drawing.Point(398, 203);
            this.Btn_Auditoria.Name = "Btn_Auditoria";
            this.Btn_Auditoria.Size = new System.Drawing.Size(205, 89);
            this.Btn_Auditoria.TabIndex = 4;
            this.Btn_Auditoria.Text = "Auditoria";
            this.Btn_Auditoria.UseVisualStyleBackColor = true;
            this.Btn_Auditoria.Click += new System.EventHandler(this.Btn_Auditoria_Click);
            // 
            // Btn_Seguridad
            // 
            this.Btn_Seguridad.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Seguridad.Location = new System.Drawing.Point(140, 203);
            this.Btn_Seguridad.Name = "Btn_Seguridad";
            this.Btn_Seguridad.Size = new System.Drawing.Size(205, 89);
            this.Btn_Seguridad.TabIndex = 3;
            this.Btn_Seguridad.Text = "Seguridad";
            this.Btn_Seguridad.UseVisualStyleBackColor = true;
            this.Btn_Seguridad.Click += new System.EventHandler(this.Btn_Seguridad_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Btn_Auditoria);
            this.Controls.Add(this.Btn_Seguridad);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Btn_Auditoria;
        private System.Windows.Forms.Button Btn_Seguridad;
    }
}

