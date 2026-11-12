namespace Capa_Vista_Checklist
{
    partial class Frm_Checklist
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Checklist));
            this.btn_mostar_actividades = new System.Windows.Forms.Button();
            this.dgvActividades = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbRubrica = new System.Windows.Forms.ComboBox();
            this.btn_registrar = new System.Windows.Forms.Button();
            this.cmbEstadoActividad = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIdActividadRubrica = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbIdInforme = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.cmbIdInformeB = new System.Windows.Forms.ComboBox();
            this.btnEditar = new System.Windows.Forms.Button();
            this.cmbEstadoNuevo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIdChecklist = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvChecklist = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.Btn_Imprimir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActividades)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChecklist)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_mostar_actividades
            // 
            this.btn_mostar_actividades.Location = new System.Drawing.Point(275, 53);
            this.btn_mostar_actividades.Name = "btn_mostar_actividades";
            this.btn_mostar_actividades.Size = new System.Drawing.Size(184, 31);
            this.btn_mostar_actividades.TabIndex = 0;
            this.btn_mostar_actividades.Text = "Mostrar actividades";
            this.btn_mostar_actividades.UseVisualStyleBackColor = true;
            this.btn_mostar_actividades.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.btn_mostar_actividades.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvActividades
            // 
            this.dgvActividades.AllowUserToAddRows = false;
            this.dgvActividades.AllowUserToDeleteRows = false;
            this.dgvActividades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvActividades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActividades.Location = new System.Drawing.Point(15, 120);
            this.dgvActividades.Name = "dgvActividades";
            this.dgvActividades.ReadOnly = true;
            this.dgvActividades.RowHeadersWidth = 51;
            this.dgvActividades.RowTemplate.Height = 24;
            this.dgvActividades.Size = new System.Drawing.Size(444, 170);
            this.dgvActividades.TabIndex = 2;
            this.dgvActividades.BackgroundColor = System.Drawing.Color.White;
            this.dgvActividades.RowHeadersVisible = false;
            this.dgvActividades.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChecklist_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 30);
            this.label1.Name = "label1";
            this.label1.TabIndex = 3;
            this.label1.Text = "Ingrese el ID de rúbrica para mostrar actividades:";
            this.label1.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 96);
            this.label2.Name = "label2";
            this.label2.TabIndex = 4;
            this.label2.Text = "Seleccione la actividad a agregar al checklist:";
            this.label2.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(13, 123);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(474, 425);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Agregar al checklist";
            this.groupBox1.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // cmbRubrica
            // 
            this.cmbRubrica.FormattingEnabled = true;
            this.cmbRubrica.Items.AddRange(new object[] {
            "Entregado",
            "No Entregado"});
            this.cmbRubrica.Location = new System.Drawing.Point(15, 55);
            this.cmbRubrica.Name = "cmbRubrica";
            this.cmbRubrica.Size = new System.Drawing.Size(250, 28);
            this.cmbRubrica.TabIndex = 12;
            this.cmbRubrica.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // btn_registrar
            // 
            this.btn_registrar.Location = new System.Drawing.Point(121, 15);
            this.btn_registrar.Name = "btn_registrar";
            this.btn_registrar.Size = new System.Drawing.Size(97, 93);
            this.btn_registrar.TabIndex = 11;
            this.btn_registrar.Text = "Guardar";
            this.btn_registrar.UseVisualStyleBackColor = true;
            this.btn_registrar.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.btn_registrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_registrar.Image = ((System.Drawing.Image)(resources.GetObject("btn_registrar.Image")));
            this.btn_registrar.Click += new System.EventHandler(this.btn_registrar_Click);
            // 
            // cmbEstadoActividad
            // 
            this.cmbEstadoActividad.FormattingEnabled = true;
            this.cmbEstadoActividad.Items.AddRange(new object[] {
            "Entregado",
            "No Entregado"});
            this.cmbEstadoActividad.Location = new System.Drawing.Point(275, 381);
            this.cmbEstadoActividad.Name = "cmbEstadoActividad";
            this.cmbEstadoActividad.Size = new System.Drawing.Size(184, 28);
            this.cmbEstadoActividad.TabIndex = 10;
            this.cmbEstadoActividad.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 385);
            this.label5.Name = "label5";
            this.label5.TabIndex = 9;
            this.label5.Text = "Estado de la actividad:";
            this.label5.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // txtIdActividadRubrica
            // 
            this.txtIdActividadRubrica.Enabled = false;
            this.txtIdActividadRubrica.Location = new System.Drawing.Point(275, 301);
            this.txtIdActividadRubrica.Name = "txtIdActividadRubrica";
            this.txtIdActividadRubrica.Size = new System.Drawing.Size(184, 27);
            this.txtIdActividadRubrica.TabIndex = 8;
            this.txtIdActividadRubrica.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 305);
            this.label4.Name = "label4";
            this.label4.TabIndex = 7;
            this.label4.Text = "ID actividad:";
            this.label4.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // cmbIdInforme
            // 
            this.cmbIdInforme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIdInforme.FormattingEnabled = true;
            this.cmbIdInforme.Location = new System.Drawing.Point(275, 341);
            this.cmbIdInforme.Name = "cmbIdInforme";
            this.cmbIdInforme.Size = new System.Drawing.Size(184, 28);
            this.cmbIdInforme.TabIndex = 6;
            this.cmbIdInforme.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 345);
            this.label3.Name = "label3";
            this.label3.TabIndex = 5;
            this.label3.Text = "ID de su informe:";
            this.label3.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(503, 123);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(474, 425);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Editar y eliminar del checklist";
            this.groupBox2.Font = new System.Drawing.Font("Rockwell", 10F);
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(229, 15);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(97, 93);
            this.btnEliminar.TabIndex = 13;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // cmbIdInformeB
            // 
            this.cmbIdInformeB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIdInformeB.FormattingEnabled = true;
            this.cmbIdInformeB.Location = new System.Drawing.Point(15, 55);
            this.cmbIdInformeB.Name = "cmbIdInformeB";
            this.cmbIdInformeB.Size = new System.Drawing.Size(250, 28);
            this.cmbIdInformeB.TabIndex = 12;
            this.cmbIdInformeB.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(13, 15);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(97, 93);
            this.btnEditar.TabIndex = 11;
            this.btnEditar.Text = "Modificar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // cmbEstadoNuevo
            // 
            this.cmbEstadoNuevo.FormattingEnabled = true;
            this.cmbEstadoNuevo.Items.AddRange(new object[] {
            "Entregado",
            "No Entregado"});
            this.cmbEstadoNuevo.Location = new System.Drawing.Point(275, 341);
            this.cmbEstadoNuevo.Name = "cmbEstadoNuevo";
            this.cmbEstadoNuevo.Size = new System.Drawing.Size(184, 28);
            this.cmbEstadoNuevo.TabIndex = 10;
            this.cmbEstadoNuevo.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 345);
            this.label6.Name = "label6";
            this.label6.TabIndex = 9;
            this.label6.Text = "Estado de la actividad:";
            this.label6.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // txtIdChecklist
            // 
            this.txtIdChecklist.Enabled = false;
            this.txtIdChecklist.Location = new System.Drawing.Point(275, 301);
            this.txtIdChecklist.Name = "txtIdChecklist";
            this.txtIdChecklist.Size = new System.Drawing.Size(184, 27);
            this.txtIdChecklist.TabIndex = 8;
            this.txtIdChecklist.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 305);
            this.label7.Name = "label7";
            this.label7.TabIndex = 7;
            this.label7.Text = "ID del checklist:";
            this.label7.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // dgvChecklist
            // 
            this.dgvChecklist.AllowUserToAddRows = false;
            this.dgvChecklist.AllowUserToDeleteRows = false;
            this.dgvChecklist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChecklist.Location = new System.Drawing.Point(15, 120);
            this.dgvChecklist.Name = "dgvChecklist";
            this.dgvChecklist.ReadOnly = true;
            this.dgvChecklist.RowHeadersWidth = 51;
            this.dgvChecklist.RowTemplate.Height = 24;
            this.dgvChecklist.Size = new System.Drawing.Size(444, 170);
            this.dgvChecklist.TabIndex = 2;
            this.dgvChecklist.BackgroundColor = System.Drawing.Color.White;
            this.dgvChecklist.RowHeadersVisible = false;
            this.dgvChecklist.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 96);
            this.label9.Name = "label9";
            this.label9.TabIndex = 4;
            this.label9.Text = "Seleccione la actividad a editar del checklist:";
            this.label9.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(275, 53);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(184, 31);
            this.button2.TabIndex = 0;
            this.button2.Text = "Mostrar checklist";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 30);
            this.label10.Name = "label10";
            this.label10.TabIndex = 3;
            this.label10.Text = "Ingrese el ID de informe para mostrar el checklist:";
            this.label10.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // Frm_Checklist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(194)))), ((int)(((byte)(99)))));
            this.ClientSize = new System.Drawing.Size(990, 563);
            // 
            // btnSalir
            // 
            this.btnSalir.Text = "Salir";
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Location = new System.Drawing.Point(445, 15);
            this.btnSalir.Size = new System.Drawing.Size(97, 93);
            this.btnSalir.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btn_registrar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbRubrica);
            this.groupBox1.Controls.Add(this.btn_mostar_actividades);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dgvActividades);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtIdActividadRubrica);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbIdInforme);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbEstadoActividad);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.cmbIdInformeB);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.dgvChecklist);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtIdChecklist);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cmbEstadoNuevo);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            // 
            // Btn_Imprimir
            // 
            this.Btn_Imprimir.Text = "Imprimir";
            this.Btn_Imprimir.Name = "Btn_Imprimir";
            this.Btn_Imprimir.Location = new System.Drawing.Point(337, 15);
            this.Btn_Imprimir.Size = new System.Drawing.Size(97, 93);
            this.Btn_Imprimir.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.Btn_Imprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Imprimir.UseVisualStyleBackColor = true;
            this.Btn_Imprimir.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Imprimir.Image")));
            this.Btn_Imprimir.Click += new System.EventHandler(this.Btn_Imprimir_Click);
            this.Controls.Add(this.Btn_Imprimir);
            this.Name = "Frm_Checklist";
            this.Text = "Checklist";
            ((System.ComponentModel.ISupportInitialize)(this.dgvActividades)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChecklist)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btn_mostar_actividades;
        private System.Windows.Forms.DataGridView dgvActividades;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_registrar;
        private System.Windows.Forms.ComboBox cmbEstadoActividad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIdActividadRubrica;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbIdInforme;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbRubrica;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.ComboBox cmbEstadoNuevo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtIdChecklist;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvChecklist;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbIdInformeB;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button Btn_Imprimir;
    }
}