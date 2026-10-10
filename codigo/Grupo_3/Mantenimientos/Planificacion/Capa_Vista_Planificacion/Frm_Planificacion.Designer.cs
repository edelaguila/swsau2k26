namespace Capa_Vista_Planificacion
{
    partial class Frm_Planificacion
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
            this.Txt_Id_planificacion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Cbo_id_proyecto = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Txt_nombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Txt_descripcion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.Btn_nuevo = new System.Windows.Forms.Button();
            this.Btn_modificar = new System.Windows.Forms.Button();
            this.Btn_guardar = new System.Windows.Forms.Button();
            this.Btn_eliminar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.Txt_observaciones = new System.Windows.Forms.TextBox();
            this.Dgv_planificacion = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_planificacion)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id Planificacion:";
            // 
            // Txt_Id_planificacion
            // 
            this.Txt_Id_planificacion.Location = new System.Drawing.Point(140, 61);
            this.Txt_Id_planificacion.Name = "Txt_Id_planificacion";
            this.Txt_Id_planificacion.Size = new System.Drawing.Size(100, 22);
            this.Txt_Id_planificacion.TabIndex = 1;
            this.Txt_Id_planificacion.TextChanged += new System.EventHandler(this.Txt_Id_planificacion_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(309, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Id proyecto:";
            // 
            // Cbo_id_proyecto
            // 
            this.Cbo_id_proyecto.FormattingEnabled = true;
            this.Cbo_id_proyecto.Location = new System.Drawing.Point(392, 64);
            this.Cbo_id_proyecto.Name = "Cbo_id_proyecto";
            this.Cbo_id_proyecto.Size = new System.Drawing.Size(121, 24);
            this.Cbo_id_proyecto.TabIndex = 3;
            this.Cbo_id_proyecto.SelectedIndexChanged += new System.EventHandler(this.Cbo_id_proyecto_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nombre de planificacion:";
            // 
            // Txt_nombre
            // 
            this.Txt_nombre.Location = new System.Drawing.Point(196, 100);
            this.Txt_nombre.Name = "Txt_nombre";
            this.Txt_nombre.Size = new System.Drawing.Size(159, 22);
            this.Txt_nombre.TabIndex = 5;
            this.Txt_nombre.TextChanged += new System.EventHandler(this.Txt_nombre_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Descripcion: ";
            // 
            // Txt_descripcion
            // 
            this.Txt_descripcion.Location = new System.Drawing.Point(178, 144);
            this.Txt_descripcion.Multiline = true;
            this.Txt_descripcion.Name = "Txt_descripcion";
            this.Txt_descripcion.Size = new System.Drawing.Size(242, 132);
            this.Txt_descripcion.TabIndex = 7;
            this.Txt_descripcion.TextChanged += new System.EventHandler(this.Txt_descripcion_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 293);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Inicio de planificación:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 354);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "Fin de planificación:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(178, 293);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(272, 22);
            this.dateTimePicker1.TabIndex = 10;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(178, 348);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(272, 22);
            this.dateTimePicker2.TabIndex = 11;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(30, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(387, 37);
            this.label7.TabIndex = 12;
            this.label7.Text = "Mantenimiento planificación";
            // 
            // Btn_nuevo
            // 
            this.Btn_nuevo.Location = new System.Drawing.Point(944, 96);
            this.Btn_nuevo.Name = "Btn_nuevo";
            this.Btn_nuevo.Size = new System.Drawing.Size(75, 23);
            this.Btn_nuevo.TabIndex = 13;
            this.Btn_nuevo.Text = "Nuevo";
            this.Btn_nuevo.UseVisualStyleBackColor = true;
            this.Btn_nuevo.Click += new System.EventHandler(this.Btn_nuevo_Click);
            // 
            // Btn_modificar
            // 
            this.Btn_modificar.Location = new System.Drawing.Point(944, 140);
            this.Btn_modificar.Name = "Btn_modificar";
            this.Btn_modificar.Size = new System.Drawing.Size(75, 23);
            this.Btn_modificar.TabIndex = 14;
            this.Btn_modificar.Text = "Modificar";
            this.Btn_modificar.UseVisualStyleBackColor = true;
            this.Btn_modificar.Click += new System.EventHandler(this.Btn_modificar_Click);
            // 
            // Btn_guardar
            // 
            this.Btn_guardar.Location = new System.Drawing.Point(944, 182);
            this.Btn_guardar.Name = "Btn_guardar";
            this.Btn_guardar.Size = new System.Drawing.Size(75, 23);
            this.Btn_guardar.TabIndex = 15;
            this.Btn_guardar.Text = "Guardar";
            this.Btn_guardar.UseVisualStyleBackColor = true;
            this.Btn_guardar.Click += new System.EventHandler(this.Btn_guardar_Click);
            // 
            // Btn_eliminar
            // 
            this.Btn_eliminar.Location = new System.Drawing.Point(944, 221);
            this.Btn_eliminar.Name = "Btn_eliminar";
            this.Btn_eliminar.Size = new System.Drawing.Size(75, 23);
            this.Btn_eliminar.TabIndex = 16;
            this.Btn_eliminar.Text = "Eliminar";
            this.Btn_eliminar.UseVisualStyleBackColor = true;
            this.Btn_eliminar.Click += new System.EventHandler(this.Btn_eliminar_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(455, 147);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 16);
            this.label8.TabIndex = 17;
            this.label8.Text = "Observaciones:";
            // 
            // Txt_observaciones
            // 
            this.Txt_observaciones.Location = new System.Drawing.Point(573, 144);
            this.Txt_observaciones.Multiline = true;
            this.Txt_observaciones.Name = "Txt_observaciones";
            this.Txt_observaciones.Size = new System.Drawing.Size(152, 71);
            this.Txt_observaciones.TabIndex = 18;
            this.Txt_observaciones.TextChanged += new System.EventHandler(this.Txt_observaciones_TextChanged);
            // 
            // Dgv_planificacion
            // 
            this.Dgv_planificacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_planificacion.Location = new System.Drawing.Point(573, 221);
            this.Dgv_planificacion.Name = "Dgv_planificacion";
            this.Dgv_planificacion.RowHeadersWidth = 51;
            this.Dgv_planificacion.RowTemplate.Height = 24;
            this.Dgv_planificacion.Size = new System.Drawing.Size(345, 120);
            this.Dgv_planificacion.TabIndex = 19;
            this.Dgv_planificacion.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_planificacion_CellContentClick);
            // 
            // Frm_Planificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 450);
            this.Controls.Add(this.Dgv_planificacion);
            this.Controls.Add(this.Txt_observaciones);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Btn_eliminar);
            this.Controls.Add(this.Btn_guardar);
            this.Controls.Add(this.Btn_modificar);
            this.Controls.Add(this.Btn_nuevo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Txt_descripcion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Txt_nombre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Cbo_id_proyecto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Txt_Id_planificacion);
            this.Controls.Add(this.label1);
            this.Name = "Frm_Planificacion";
            this.Text = "Frm_Planificacion";
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_planificacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Txt_Id_planificacion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Cbo_id_proyecto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Txt_nombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Txt_descripcion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button Btn_nuevo;
        private System.Windows.Forms.Button Btn_modificar;
        private System.Windows.Forms.Button Btn_guardar;
        private System.Windows.Forms.Button Btn_eliminar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Txt_observaciones;
        private System.Windows.Forms.DataGridView Dgv_planificacion;
    }
}