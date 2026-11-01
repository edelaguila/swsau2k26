namespace Capa_Vista_Cronograma
{
    partial class Frm_Cronograma
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
            this.label1 = new System.Windows.Forms.Label();
            this.Txt_Id_Cronograma = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Cbo_Id_Planificacion = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Cbo_Id_Actividad_Proyecto = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Txt_Cmp_Nombre_Tarea_Cronograma = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Txt_Cmp_Descripcion_Cronograma = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Dtp_Cmp_Fecha_Inicio_Cronograma = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.Dtp_Cmp_Fecha_Fin_Cronograma = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.Txt_Cmp_Responsable_Tarea_Cronograma = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Cbo_Cmp_Estado_Tarea_Cronograma = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.Txt_Cmp_Observaciones_Cronograma = new System.Windows.Forms.TextBox();
            this.Dgv_Cronograma = new System.Windows.Forms.DataGridView();
            this.Btn_Nuevo = new System.Windows.Forms.Button();
            this.Btn_Guardar = new System.Windows.Forms.Button();
            this.Btn_Modificar = new System.Windows.Forms.Button();
            this.Btn_Eliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Cronograma)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Rockwell", 11F);
            this.label1.Location = new System.Drawing.Point(30, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id cronograma:";
            // 
            // Txt_Id_Cronograma
            // 
            this.Txt_Id_Cronograma.Location = new System.Drawing.Point(185, 76);
            this.Txt_Id_Cronograma.Name = "Txt_Id_Cronograma";
            this.Txt_Id_Cronograma.Size = new System.Drawing.Size(100, 22);
            this.Txt_Id_Cronograma.TabIndex = 1;
            this.Txt_Id_Cronograma.TextChanged += new System.EventHandler(this.Txt_Id_Cronograma_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Rockwell", 11F);
            this.label2.Location = new System.Drawing.Point(301, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Id planificación:";
            // 
            // Cbo_Id_Planificacion
            // 
            this.Cbo_Id_Planificacion.FormattingEnabled = true;
            this.Cbo_Id_Planificacion.Location = new System.Drawing.Point(461, 77);
            this.Cbo_Id_Planificacion.Name = "Cbo_Id_Planificacion";
            this.Cbo_Id_Planificacion.Size = new System.Drawing.Size(121, 24);
            this.Cbo_Id_Planificacion.TabIndex = 3;
            this.Cbo_Id_Planificacion.SelectedIndexChanged += new System.EventHandler(this.Cbo_Id_Planificacion_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Rockwell", 11F);
            this.label3.Location = new System.Drawing.Point(599, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(209, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Id Actividad proyecto:";
            // 
            // Cbo_Id_Actividad_Proyecto
            // 
            this.Cbo_Id_Actividad_Proyecto.FormattingEnabled = true;
            this.Cbo_Id_Actividad_Proyecto.Location = new System.Drawing.Point(814, 80);
            this.Cbo_Id_Actividad_Proyecto.Name = "Cbo_Id_Actividad_Proyecto";
            this.Cbo_Id_Actividad_Proyecto.Size = new System.Drawing.Size(121, 24);
            this.Cbo_Id_Actividad_Proyecto.TabIndex = 5;
            this.Cbo_Id_Actividad_Proyecto.SelectedIndexChanged += new System.EventHandler(this.Cbo_Id_Actividad_Proyecto_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Rockwell", 18F);
            this.label4.Location = new System.Drawing.Point(28, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(192, 35);
            this.label4.TabIndex = 6;
            this.label4.Text = "Cronograma";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Rockwell", 10F);
            this.label5.Location = new System.Drawing.Point(31, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(275, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Nombre de tarea del cronograma:";
            // 
            // Txt_Cmp_Nombre_Tarea_Cronograma
            // 
            this.Txt_Cmp_Nombre_Tarea_Cronograma.Location = new System.Drawing.Point(336, 118);
            this.Txt_Cmp_Nombre_Tarea_Cronograma.Name = "Txt_Cmp_Nombre_Tarea_Cronograma";
            this.Txt_Cmp_Nombre_Tarea_Cronograma.Size = new System.Drawing.Size(119, 22);
            this.Txt_Cmp_Nombre_Tarea_Cronograma.TabIndex = 8;
            this.Txt_Cmp_Nombre_Tarea_Cronograma.TextChanged += new System.EventHandler(this.Txt_Cmp_Nombre_Tarea_Cronograma_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Rockwell", 10F);
            this.label6.Location = new System.Drawing.Point(478, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(209, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "Descripción cronograma:";
            // 
            // Txt_Cmp_Descripcion_Cronograma
            // 
            this.Txt_Cmp_Descripcion_Cronograma.Location = new System.Drawing.Point(709, 120);
            this.Txt_Cmp_Descripcion_Cronograma.Multiline = true;
            this.Txt_Cmp_Descripcion_Cronograma.Name = "Txt_Cmp_Descripcion_Cronograma";
            this.Txt_Cmp_Descripcion_Cronograma.Size = new System.Drawing.Size(189, 100);
            this.Txt_Cmp_Descripcion_Cronograma.TabIndex = 10;
            this.Txt_Cmp_Descripcion_Cronograma.TextChanged += new System.EventHandler(this.Txt_Cmp_Descripcion_Cronograma_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Rockwell", 10F);
            this.label7.Location = new System.Drawing.Point(32, 157);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "Fecha de inicio:";
            // 
            // Dtp_Cmp_Fecha_Inicio_Cronograma
            // 
            this.Dtp_Cmp_Fecha_Inicio_Cronograma.Location = new System.Drawing.Point(185, 157);
            this.Dtp_Cmp_Fecha_Inicio_Cronograma.Name = "Dtp_Cmp_Fecha_Inicio_Cronograma";
            this.Dtp_Cmp_Fecha_Inicio_Cronograma.Size = new System.Drawing.Size(249, 22);
            this.Dtp_Cmp_Fecha_Inicio_Cronograma.TabIndex = 12;
            this.Dtp_Cmp_Fecha_Inicio_Cronograma.ValueChanged += new System.EventHandler(this.Dtp_Cmp_Fecha_Inicio_Cronograma_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Rockwell", 10F);
            this.label8.Location = new System.Drawing.Point(33, 195);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 20);
            this.label8.TabIndex = 13;
            this.label8.Text = "Fecha fin:";
            // 
            // Dtp_Cmp_Fecha_Fin_Cronograma
            // 
            this.Dtp_Cmp_Fecha_Fin_Cronograma.Location = new System.Drawing.Point(185, 195);
            this.Dtp_Cmp_Fecha_Fin_Cronograma.Name = "Dtp_Cmp_Fecha_Fin_Cronograma";
            this.Dtp_Cmp_Fecha_Fin_Cronograma.Size = new System.Drawing.Size(249, 22);
            this.Dtp_Cmp_Fecha_Fin_Cronograma.TabIndex = 14;
            this.Dtp_Cmp_Fecha_Fin_Cronograma.ValueChanged += new System.EventHandler(this.Dtp_Cmp_Fecha_Fin_Cronograma_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Rockwell", 10F);
            this.label9.Location = new System.Drawing.Point(33, 231);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(182, 20);
            this.label9.TabIndex = 15;
            this.label9.Text = "Responsable de tarea:";
            // 
            // Txt_Cmp_Responsable_Tarea_Cronograma
            // 
            this.Txt_Cmp_Responsable_Tarea_Cronograma.Location = new System.Drawing.Point(221, 231);
            this.Txt_Cmp_Responsable_Tarea_Cronograma.Name = "Txt_Cmp_Responsable_Tarea_Cronograma";
            this.Txt_Cmp_Responsable_Tarea_Cronograma.Size = new System.Drawing.Size(157, 22);
            this.Txt_Cmp_Responsable_Tarea_Cronograma.TabIndex = 16;
            this.Txt_Cmp_Responsable_Tarea_Cronograma.TextChanged += new System.EventHandler(this.Txt_Cmp_Responsable_Tarea_Cronograma_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Rockwell", 10F);
            this.label10.Location = new System.Drawing.Point(33, 265);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(153, 20);
            this.label10.TabIndex = 17;
            this.label10.Text = "Estado de la tarea:";
            // 
            // Cbo_Cmp_Estado_Tarea_Cronograma
            // 
            this.Cbo_Cmp_Estado_Tarea_Cronograma.FormattingEnabled = true;
            this.Cbo_Cmp_Estado_Tarea_Cronograma.Location = new System.Drawing.Point(221, 265);
            this.Cbo_Cmp_Estado_Tarea_Cronograma.Name = "Cbo_Cmp_Estado_Tarea_Cronograma";
            this.Cbo_Cmp_Estado_Tarea_Cronograma.Size = new System.Drawing.Size(121, 24);
            this.Cbo_Cmp_Estado_Tarea_Cronograma.TabIndex = 18;
            this.Cbo_Cmp_Estado_Tarea_Cronograma.SelectedIndexChanged += new System.EventHandler(this.Cbo_Cmp_Estado_Tarea_Cronograma_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Rockwell", 10F);
            this.label11.Location = new System.Drawing.Point(449, 231);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(133, 20);
            this.label11.TabIndex = 19;
            this.label11.Text = "Observaciones:";
            // 
            // Txt_Cmp_Observaciones_Cronograma
            // 
            this.Txt_Cmp_Observaciones_Cronograma.Location = new System.Drawing.Point(588, 231);
            this.Txt_Cmp_Observaciones_Cronograma.Name = "Txt_Cmp_Observaciones_Cronograma";
            this.Txt_Cmp_Observaciones_Cronograma.Size = new System.Drawing.Size(266, 22);
            this.Txt_Cmp_Observaciones_Cronograma.TabIndex = 20;
            this.Txt_Cmp_Observaciones_Cronograma.TextChanged += new System.EventHandler(this.Txt_Cmp_Observaciones_Cronograma_TextChanged);
            // 
            // Dgv_Cronograma
            // 
            this.Dgv_Cronograma.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_Cronograma.Location = new System.Drawing.Point(34, 295);
            this.Dgv_Cronograma.Name = "Dgv_Cronograma";
            this.Dgv_Cronograma.RowHeadersWidth = 51;
            this.Dgv_Cronograma.RowTemplate.Height = 24;
            this.Dgv_Cronograma.Size = new System.Drawing.Size(633, 151);
            this.Dgv_Cronograma.TabIndex = 21;
            this.Dgv_Cronograma.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_Cronograma_CellContentClick);
            // 
            // Btn_Nuevo
            // 
            this.Btn_Nuevo.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Btn_Nuevo.Location = new System.Drawing.Point(758, 279);
            this.Btn_Nuevo.Name = "Btn_Nuevo";
            this.Btn_Nuevo.Size = new System.Drawing.Size(99, 44);
            this.Btn_Nuevo.TabIndex = 22;
            this.Btn_Nuevo.Text = "Nuevo";
            this.Btn_Nuevo.UseVisualStyleBackColor = true;
            this.Btn_Nuevo.Click += new System.EventHandler(this.Btn_Nuevo_Click_1);
            // 
            // Btn_Guardar
            // 
            this.Btn_Guardar.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Btn_Guardar.Location = new System.Drawing.Point(863, 279);
            this.Btn_Guardar.Name = "Btn_Guardar";
            this.Btn_Guardar.Size = new System.Drawing.Size(99, 44);
            this.Btn_Guardar.TabIndex = 23;
            this.Btn_Guardar.Text = "Guardar";
            this.Btn_Guardar.UseVisualStyleBackColor = true;
            this.Btn_Guardar.Click += new System.EventHandler(this.Btn_Guardar_Click_1);
            // 
            // Btn_Modificar
            // 
            this.Btn_Modificar.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Btn_Modificar.Location = new System.Drawing.Point(755, 329);
            this.Btn_Modificar.Name = "Btn_Modificar";
            this.Btn_Modificar.Size = new System.Drawing.Size(99, 44);
            this.Btn_Modificar.TabIndex = 24;
            this.Btn_Modificar.Text = "Modificar";
            this.Btn_Modificar.UseVisualStyleBackColor = true;
            this.Btn_Modificar.Click += new System.EventHandler(this.Btn_Modificar_Click_1);
            // 
            // Btn_Eliminar
            // 
            this.Btn_Eliminar.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Btn_Eliminar.Location = new System.Drawing.Point(863, 329);
            this.Btn_Eliminar.Name = "Btn_Eliminar";
            this.Btn_Eliminar.Size = new System.Drawing.Size(99, 44);
            this.Btn_Eliminar.TabIndex = 25;
            this.Btn_Eliminar.Text = "Eliminar";
            this.Btn_Eliminar.UseVisualStyleBackColor = true;
            this.Btn_Eliminar.Click += new System.EventHandler(this.Btn_Eliminar_Click_1);
            // 
            // Frm_Cronograma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1028, 478);
            this.Controls.Add(this.Btn_Eliminar);
            this.Controls.Add(this.Btn_Modificar);
            this.Controls.Add(this.Btn_Guardar);
            this.Controls.Add(this.Btn_Nuevo);
            this.Controls.Add(this.Dgv_Cronograma);
            this.Controls.Add(this.Txt_Cmp_Observaciones_Cronograma);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.Cbo_Cmp_Estado_Tarea_Cronograma);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.Txt_Cmp_Responsable_Tarea_Cronograma);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Dtp_Cmp_Fecha_Fin_Cronograma);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Dtp_Cmp_Fecha_Inicio_Cronograma);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Txt_Cmp_Descripcion_Cronograma);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Txt_Cmp_Nombre_Tarea_Cronograma);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Cbo_Id_Actividad_Proyecto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Cbo_Id_Planificacion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Txt_Id_Cronograma);
            this.Controls.Add(this.label1);
            this.Name = "Frm_Cronograma";
            this.Text = "Frm_Cronograma";
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Cronograma)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Txt_Id_Cronograma;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Cbo_Id_Planificacion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox Cbo_Id_Actividad_Proyecto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Txt_Cmp_Nombre_Tarea_Cronograma;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Txt_Cmp_Descripcion_Cronograma;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker Dtp_Cmp_Fecha_Inicio_Cronograma;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker Dtp_Cmp_Fecha_Fin_Cronograma;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox Txt_Cmp_Responsable_Tarea_Cronograma;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox Cbo_Cmp_Estado_Tarea_Cronograma;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox Txt_Cmp_Observaciones_Cronograma;
        private System.Windows.Forms.DataGridView Dgv_Cronograma;
        private System.Windows.Forms.Button Btn_Nuevo;
        private System.Windows.Forms.Button Btn_Guardar;
        private System.Windows.Forms.Button Btn_Modificar;
        private System.Windows.Forms.Button Btn_Eliminar;
    }
}