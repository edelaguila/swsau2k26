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
            this.btn_mostar_actividades = new System.Windows.Forms.Button();
            this.dgvActividades = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIdInforme = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIdActividadRubrica = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbEstadoActividad = new System.Windows.Forms.ComboBox();
            this.btn_registrar = new System.Windows.Forms.Button();
            this.cmbRubrica = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEditar = new System.Windows.Forms.Button();
            this.cmbEstadoNuevo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIdChecklist = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvChecklist = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtidinformeB = new System.Windows.Forms.TextBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActividades)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChecklist)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_mostar_actividades
            // 
            this.btn_mostar_actividades.Location = new System.Drawing.Point(251, 70);
            this.btn_mostar_actividades.Name = "btn_mostar_actividades";
            this.btn_mostar_actividades.Size = new System.Drawing.Size(151, 23);
            this.btn_mostar_actividades.TabIndex = 0;
            this.btn_mostar_actividades.Text = "Mostar Actividades";
            this.btn_mostar_actividades.UseVisualStyleBackColor = true;
            this.btn_mostar_actividades.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvActividades
            // 
            this.dgvActividades.AllowUserToAddRows = false;
            this.dgvActividades.AllowUserToDeleteRows = false;
            this.dgvActividades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvActividades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActividades.Location = new System.Drawing.Point(22, 146);
            this.dgvActividades.Name = "dgvActividades";
            this.dgvActividades.ReadOnly = true;
            this.dgvActividades.RowHeadersWidth = 51;
            this.dgvActividades.RowTemplate.Height = 24;
            this.dgvActividades.Size = new System.Drawing.Size(380, 150);
            this.dgvActividades.TabIndex = 2;
            this.dgvActividades.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChecklist_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(289, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ingrese ID de Rubrica para mostrar actividades";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(281, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Seleccione la actividad a agregar al checklist:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbRubrica);
            this.groupBox1.Controls.Add(this.btn_registrar);
            this.groupBox1.Controls.Add(this.cmbEstadoActividad);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtIdActividadRubrica);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtIdInforme);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dgvActividades);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btn_mostar_actividades);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(424, 477);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Agregar a Checklist";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 351);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ingrese el ID de su informe:";
            // 
            // txtIdInforme
            // 
            this.txtIdInforme.Location = new System.Drawing.Point(214, 348);
            this.txtIdInforme.Name = "txtIdInforme";
            this.txtIdInforme.Size = new System.Drawing.Size(188, 22);
            this.txtIdInforme.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 316);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "ID actividad:";
            // 
            // txtIdActividadRubrica
            // 
            this.txtIdActividadRubrica.Enabled = false;
            this.txtIdActividadRubrica.Location = new System.Drawing.Point(214, 313);
            this.txtIdActividadRubrica.Name = "txtIdActividadRubrica";
            this.txtIdActividadRubrica.Size = new System.Drawing.Size(188, 22);
            this.txtIdActividadRubrica.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 387);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Estado de la actividad:";
            // 
            // cmbEstadoActividad
            // 
            this.cmbEstadoActividad.FormattingEnabled = true;
            this.cmbEstadoActividad.Items.AddRange(new object[] {
            "Entregado",
            "No Entregado"});
            this.cmbEstadoActividad.Location = new System.Drawing.Point(214, 387);
            this.cmbEstadoActividad.Name = "cmbEstadoActividad";
            this.cmbEstadoActividad.Size = new System.Drawing.Size(188, 24);
            this.cmbEstadoActividad.TabIndex = 10;
            // 
            // btn_registrar
            // 
            this.btn_registrar.Location = new System.Drawing.Point(113, 440);
            this.btn_registrar.Name = "btn_registrar";
            this.btn_registrar.Size = new System.Drawing.Size(187, 23);
            this.btn_registrar.TabIndex = 11;
            this.btn_registrar.Text = "Registrar";
            this.btn_registrar.UseVisualStyleBackColor = true;
            this.btn_registrar.Click += new System.EventHandler(this.btn_registrar_Click);
            // 
            // cmbRubrica
            // 
            this.cmbRubrica.FormattingEnabled = true;
            this.cmbRubrica.Items.AddRange(new object[] {
            "Entregado",
            "No Entregado"});
            this.cmbRubrica.Location = new System.Drawing.Point(22, 70);
            this.cmbRubrica.Name = "cmbRubrica";
            this.cmbRubrica.Size = new System.Drawing.Size(223, 24);
            this.cmbRubrica.TabIndex = 12;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnEliminar);
            this.groupBox2.Controls.Add(this.txtidinformeB);
            this.groupBox2.Controls.Add(this.btnEditar);
            this.groupBox2.Controls.Add(this.cmbEstadoNuevo);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtIdChecklist);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.dgvChecklist);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(469, 53);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(424, 448);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Editar y Eliminar Checklist";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(57, 399);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(119, 23);
            this.btnEditar.TabIndex = 11;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // cmbEstadoNuevo
            // 
            this.cmbEstadoNuevo.FormattingEnabled = true;
            this.cmbEstadoNuevo.Items.AddRange(new object[] {
            "Entregado",
            "No Entregado"});
            this.cmbEstadoNuevo.Location = new System.Drawing.Point(214, 348);
            this.cmbEstadoNuevo.Name = "cmbEstadoNuevo";
            this.cmbEstadoNuevo.Size = new System.Drawing.Size(188, 24);
            this.cmbEstadoNuevo.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 354);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "Estado de la actividad:";
            // 
            // txtIdChecklist
            // 
            this.txtIdChecklist.Enabled = false;
            this.txtIdChecklist.Location = new System.Drawing.Point(214, 313);
            this.txtIdChecklist.Name = "txtIdChecklist";
            this.txtIdChecklist.Size = new System.Drawing.Size(188, 22);
            this.txtIdChecklist.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 316);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "ID del checklist:";
            // 
            // dgvChecklist
            // 
            this.dgvChecklist.AllowUserToAddRows = false;
            this.dgvChecklist.AllowUserToDeleteRows = false;
            this.dgvChecklist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChecklist.Location = new System.Drawing.Point(22, 146);
            this.dgvChecklist.Name = "dgvChecklist";
            this.dgvChecklist.ReadOnly = true;
            this.dgvChecklist.RowHeadersWidth = 51;
            this.dgvChecklist.RowTemplate.Height = 24;
            this.dgvChecklist.Size = new System.Drawing.Size(380, 150);
            this.dgvChecklist.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 114);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(275, 16);
            this.label9.TabIndex = 4;
            this.label9.Text = "Seleccione la actividad a editar del checklist:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(235, 70);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(167, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "Mostar Checklist";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 38);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(268, 16);
            this.label10.TabIndex = 3;
            this.label10.Text = "Ingrese ID de Informe para mostrar checklist";
            // 
            // txtidinformeB
            // 
            this.txtidinformeB.Location = new System.Drawing.Point(22, 72);
            this.txtidinformeB.Name = "txtidinformeB";
            this.txtidinformeB.Size = new System.Drawing.Size(188, 22);
            this.txtidinformeB.TabIndex = 12;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(235, 399);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(119, 23);
            this.btnEliminar.TabIndex = 13;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // Frm_Checklist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 541);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_Checklist";
            this.Text = "Frm_Checklist";
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
        private System.Windows.Forms.TextBox txtIdInforme;
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
        private System.Windows.Forms.TextBox txtidinformeB;
        private System.Windows.Forms.Button btnEliminar;
    }
}