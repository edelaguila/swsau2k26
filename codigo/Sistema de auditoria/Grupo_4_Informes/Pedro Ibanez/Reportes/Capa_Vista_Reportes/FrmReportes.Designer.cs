namespace Capa_Vista_Reportes
{
    partial class FrmReportes
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
            this.Btn_Cancelar = new System.Windows.Forms.Button();
            this.Btn_Eliminar = new System.Windows.Forms.Button();
            this.Btn_Modificar = new System.Windows.Forms.Button();
            this.Btn_Guardar = new System.Windows.Forms.Button();
            this.Cbo_Fk_Informe = new System.Windows.Forms.ComboBox();
            this.Cbo_Fk_Rubrica = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GPB_Aspectos_Positivos = new System.Windows.Forms.GroupBox();
            this.btn_Rutas_Positivos = new System.Windows.Forms.Button();
            this.txtRutaImagenPos = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtAspectosPositivos = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.GBP_Correcciones = new System.Windows.Forms.GroupBox();
            this.btn_Rutas_Correciones = new System.Windows.Forms.Button();
            this.txtRutaImagenCorrecion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCorreciones = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.GBSugerencias = new System.Windows.Forms.GroupBox();
            this.btn_Rutas_Sugerencias = new System.Windows.Forms.Button();
            this.txtRutaImagenSugerencias = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSugerencias = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Cbo_id_reporte = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.GPB_Aspectos_Positivos.SuspendLayout();
            this.GBP_Correcciones.SuspendLayout();
            this.GBSugerencias.SuspendLayout();
            this.SuspendLayout();
            // 
            // Btn_Cancelar
            // 
            this.Btn_Cancelar.Location = new System.Drawing.Point(540, 86);
            this.Btn_Cancelar.Name = "Btn_Cancelar";
            this.Btn_Cancelar.Size = new System.Drawing.Size(100, 32);
            this.Btn_Cancelar.TabIndex = 18;
            this.Btn_Cancelar.Text = "Cancelar";
            this.Btn_Cancelar.UseVisualStyleBackColor = true;
            this.Btn_Cancelar.Click += new System.EventHandler(this.Btn_Cancelar_Click);
            // 
            // Btn_Eliminar
            // 
            this.Btn_Eliminar.Location = new System.Drawing.Point(646, 86);
            this.Btn_Eliminar.Name = "Btn_Eliminar";
            this.Btn_Eliminar.Size = new System.Drawing.Size(100, 32);
            this.Btn_Eliminar.TabIndex = 17;
            this.Btn_Eliminar.Text = "Eliminar";
            this.Btn_Eliminar.UseVisualStyleBackColor = true;
            this.Btn_Eliminar.Click += new System.EventHandler(this.Btn_Eliminar_Click);
            // 
            // Btn_Modificar
            // 
            this.Btn_Modificar.Location = new System.Drawing.Point(434, 86);
            this.Btn_Modificar.Name = "Btn_Modificar";
            this.Btn_Modificar.Size = new System.Drawing.Size(100, 32);
            this.Btn_Modificar.TabIndex = 16;
            this.Btn_Modificar.Text = "Modificar";
            this.Btn_Modificar.UseVisualStyleBackColor = true;
            this.Btn_Modificar.Click += new System.EventHandler(this.Btn_Modificar_Click);
            // 
            // Btn_Guardar
            // 
            this.Btn_Guardar.Location = new System.Drawing.Point(324, 86);
            this.Btn_Guardar.Name = "Btn_Guardar";
            this.Btn_Guardar.Size = new System.Drawing.Size(100, 32);
            this.Btn_Guardar.TabIndex = 15;
            this.Btn_Guardar.Text = "Guardar";
            this.Btn_Guardar.UseVisualStyleBackColor = true;
            this.Btn_Guardar.Click += new System.EventHandler(this.Btn_Guardar_Click);
            // 
            // Cbo_Fk_Informe
            // 
            this.Cbo_Fk_Informe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbo_Fk_Informe.FormattingEnabled = true;
            this.Cbo_Fk_Informe.Location = new System.Drawing.Point(577, 148);
            this.Cbo_Fk_Informe.Name = "Cbo_Fk_Informe";
            this.Cbo_Fk_Informe.Size = new System.Drawing.Size(145, 21);
            this.Cbo_Fk_Informe.TabIndex = 20;
            // 
            // Cbo_Fk_Rubrica
            // 
            this.Cbo_Fk_Rubrica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbo_Fk_Rubrica.FormattingEnabled = true;
            this.Cbo_Fk_Rubrica.Location = new System.Drawing.Point(858, 148);
            this.Cbo_Fk_Rubrica.Name = "Cbo_Fk_Rubrica";
            this.Cbo_Fk_Rubrica.Size = new System.Drawing.Size(146, 21);
            this.Cbo_Fk_Rubrica.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(517, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Id-Informe";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(749, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Id-Actividad Rubrica";
            // 
            // GPB_Aspectos_Positivos
            // 
            this.GPB_Aspectos_Positivos.BackColor = System.Drawing.Color.Silver;
            this.GPB_Aspectos_Positivos.Controls.Add(this.btn_Rutas_Positivos);
            this.GPB_Aspectos_Positivos.Controls.Add(this.txtRutaImagenPos);
            this.GPB_Aspectos_Positivos.Controls.Add(this.label5);
            this.GPB_Aspectos_Positivos.Controls.Add(this.TxtAspectosPositivos);
            this.GPB_Aspectos_Positivos.Controls.Add(this.label3);
            this.GPB_Aspectos_Positivos.Location = new System.Drawing.Point(30, 201);
            this.GPB_Aspectos_Positivos.Name = "GPB_Aspectos_Positivos";
            this.GPB_Aspectos_Positivos.Size = new System.Drawing.Size(1144, 244);
            this.GPB_Aspectos_Positivos.TabIndex = 24;
            this.GPB_Aspectos_Positivos.TabStop = false;
            this.GPB_Aspectos_Positivos.Text = "Aspectos Positivos";
            this.GPB_Aspectos_Positivos.Enter += new System.EventHandler(this.GPB_Aspectos_Positivos_Enter);
            // 
            // btn_Rutas_Positivos
            // 
            this.btn_Rutas_Positivos.Location = new System.Drawing.Point(969, 178);
            this.btn_Rutas_Positivos.Name = "btn_Rutas_Positivos";
            this.btn_Rutas_Positivos.Size = new System.Drawing.Size(117, 32);
            this.btn_Rutas_Positivos.TabIndex = 27;
            this.btn_Rutas_Positivos.Text = "Ruta";
            this.btn_Rutas_Positivos.UseVisualStyleBackColor = true;
            this.btn_Rutas_Positivos.Click += new System.EventHandler(this.btn_Rutas_Positivos_Click);
            // 
            // txtRutaImagenPos
            // 
            this.txtRutaImagenPos.Location = new System.Drawing.Point(30, 178);
            this.txtRutaImagenPos.Multiline = true;
            this.txtRutaImagenPos.Name = "txtRutaImagenPos";
            this.txtRutaImagenPos.Size = new System.Drawing.Size(892, 31);
            this.txtRutaImagenPos.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Ruta Imagenes Positivos";
            // 
            // TxtAspectosPositivos
            // 
            this.TxtAspectosPositivos.Location = new System.Drawing.Point(30, 48);
            this.TxtAspectosPositivos.Multiline = true;
            this.TxtAspectosPositivos.Name = "TxtAspectosPositivos";
            this.TxtAspectosPositivos.Size = new System.Drawing.Size(1088, 90);
            this.TxtAspectosPositivos.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Aspectos Positivos";
            // 
            // GBP_Correcciones
            // 
            this.GBP_Correcciones.BackColor = System.Drawing.Color.Silver;
            this.GBP_Correcciones.Controls.Add(this.btn_Rutas_Correciones);
            this.GBP_Correcciones.Controls.Add(this.txtRutaImagenCorrecion);
            this.GBP_Correcciones.Controls.Add(this.label6);
            this.GBP_Correcciones.Controls.Add(this.txtCorreciones);
            this.GBP_Correcciones.Controls.Add(this.label4);
            this.GBP_Correcciones.Location = new System.Drawing.Point(30, 474);
            this.GBP_Correcciones.Name = "GBP_Correcciones";
            this.GBP_Correcciones.Size = new System.Drawing.Size(1144, 252);
            this.GBP_Correcciones.TabIndex = 25;
            this.GBP_Correcciones.TabStop = false;
            this.GBP_Correcciones.Text = "Correciones";
            // 
            // btn_Rutas_Correciones
            // 
            this.btn_Rutas_Correciones.Location = new System.Drawing.Point(969, 187);
            this.btn_Rutas_Correciones.Name = "btn_Rutas_Correciones";
            this.btn_Rutas_Correciones.Size = new System.Drawing.Size(117, 32);
            this.btn_Rutas_Correciones.TabIndex = 30;
            this.btn_Rutas_Correciones.Text = "Ruta";
            this.btn_Rutas_Correciones.UseVisualStyleBackColor = true;
            this.btn_Rutas_Correciones.Click += new System.EventHandler(this.btn_Rutas_Correciones_Click);
            // 
            // txtRutaImagenCorrecion
            // 
            this.txtRutaImagenCorrecion.Location = new System.Drawing.Point(30, 187);
            this.txtRutaImagenCorrecion.Multiline = true;
            this.txtRutaImagenCorrecion.Name = "txtRutaImagenCorrecion";
            this.txtRutaImagenCorrecion.Size = new System.Drawing.Size(892, 31);
            this.txtRutaImagenCorrecion.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Ruta Imagenes Correcciones";
            // 
            // txtCorreciones
            // 
            this.txtCorreciones.Location = new System.Drawing.Point(30, 48);
            this.txtCorreciones.Multiline = true;
            this.txtCorreciones.Name = "txtCorreciones";
            this.txtCorreciones.Size = new System.Drawing.Size(1088, 90);
            this.txtCorreciones.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Correciones";
            // 
            // GBSugerencias
            // 
            this.GBSugerencias.BackColor = System.Drawing.Color.Silver;
            this.GBSugerencias.Controls.Add(this.btn_Rutas_Sugerencias);
            this.GBSugerencias.Controls.Add(this.txtRutaImagenSugerencias);
            this.GBSugerencias.Controls.Add(this.label7);
            this.GBSugerencias.Controls.Add(this.txtSugerencias);
            this.GBSugerencias.Controls.Add(this.label8);
            this.GBSugerencias.Location = new System.Drawing.Point(30, 753);
            this.GBSugerencias.Name = "GBSugerencias";
            this.GBSugerencias.Size = new System.Drawing.Size(1144, 252);
            this.GBSugerencias.TabIndex = 26;
            this.GBSugerencias.TabStop = false;
            this.GBSugerencias.Text = "Sugerencias";
            // 
            // btn_Rutas_Sugerencias
            // 
            this.btn_Rutas_Sugerencias.Location = new System.Drawing.Point(969, 187);
            this.btn_Rutas_Sugerencias.Name = "btn_Rutas_Sugerencias";
            this.btn_Rutas_Sugerencias.Size = new System.Drawing.Size(117, 32);
            this.btn_Rutas_Sugerencias.TabIndex = 30;
            this.btn_Rutas_Sugerencias.Text = "Ruta";
            this.btn_Rutas_Sugerencias.UseVisualStyleBackColor = true;
            this.btn_Rutas_Sugerencias.Click += new System.EventHandler(this.btn_Rutas_Sugerencias_Click);
            // 
            // txtRutaImagenSugerencias
            // 
            this.txtRutaImagenSugerencias.Location = new System.Drawing.Point(30, 187);
            this.txtRutaImagenSugerencias.Multiline = true;
            this.txtRutaImagenSugerencias.Name = "txtRutaImagenSugerencias";
            this.txtRutaImagenSugerencias.Size = new System.Drawing.Size(892, 31);
            this.txtRutaImagenSugerencias.TabIndex = 29;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 163);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(141, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Ruta Imagenes Sugerencias";
            // 
            // txtSugerencias
            // 
            this.txtSugerencias.Location = new System.Drawing.Point(30, 48);
            this.txtSugerencias.Multiline = true;
            this.txtSugerencias.Name = "txtSugerencias";
            this.txtSugerencias.Size = new System.Drawing.Size(1088, 90);
            this.txtSugerencias.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Sugerencias";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(281, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(686, 29);
            this.label9.TabIndex = 27;
            this.label9.Text = "ASPECTOS POSITIVOS, CORRECCIONES Y SUGERENCIAS";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(283, 151);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 13);
            this.label10.TabIndex = 29;
            this.label10.Text = "Id-Reporte";
            // 
            // Cbo_id_reporte
            // 
            this.Cbo_id_reporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbo_id_reporte.FormattingEnabled = true;
            this.Cbo_id_reporte.Location = new System.Drawing.Point(343, 148);
            this.Cbo_id_reporte.Name = "Cbo_id_reporte";
            this.Cbo_id_reporte.Size = new System.Drawing.Size(145, 21);
            this.Cbo_id_reporte.TabIndex = 28;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(752, 86);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 32);
            this.btnBuscar.TabIndex = 30;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // FrmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(194)))), ((int)(((byte)(99)))));
            this.ClientSize = new System.Drawing.Size(1216, 1050);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.Cbo_id_reporte);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.GBSugerencias);
            this.Controls.Add(this.GBP_Correcciones);
            this.Controls.Add(this.GPB_Aspectos_Positivos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Cbo_Fk_Rubrica);
            this.Controls.Add(this.Cbo_Fk_Informe);
            this.Controls.Add(this.Btn_Cancelar);
            this.Controls.Add(this.Btn_Eliminar);
            this.Controls.Add(this.Btn_Modificar);
            this.Controls.Add(this.Btn_Guardar);
            this.Name = "FrmReportes";
            this.Text = "FrmReportes";
            this.Load += new System.EventHandler(this.FrmReportes_Load);
            this.GPB_Aspectos_Positivos.ResumeLayout(false);
            this.GPB_Aspectos_Positivos.PerformLayout();
            this.GBP_Correcciones.ResumeLayout(false);
            this.GBP_Correcciones.PerformLayout();
            this.GBSugerencias.ResumeLayout(false);
            this.GBSugerencias.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Btn_Cancelar;
        private System.Windows.Forms.Button Btn_Eliminar;
        private System.Windows.Forms.Button Btn_Modificar;
        private System.Windows.Forms.Button Btn_Guardar;
        private System.Windows.Forms.ComboBox Cbo_Fk_Informe;
        private System.Windows.Forms.ComboBox Cbo_Fk_Rubrica;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox GPB_Aspectos_Positivos;
        private System.Windows.Forms.TextBox TxtAspectosPositivos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox GBP_Correcciones;
        private System.Windows.Forms.TextBox txtCorreciones;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Rutas_Positivos;
        private System.Windows.Forms.TextBox txtRutaImagenPos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_Rutas_Correciones;
        private System.Windows.Forms.TextBox txtRutaImagenCorrecion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox GBSugerencias;
        private System.Windows.Forms.Button btn_Rutas_Sugerencias;
        private System.Windows.Forms.TextBox txtRutaImagenSugerencias;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSugerencias;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox Cbo_id_reporte;
        private System.Windows.Forms.Button btnBuscar;
    }
}