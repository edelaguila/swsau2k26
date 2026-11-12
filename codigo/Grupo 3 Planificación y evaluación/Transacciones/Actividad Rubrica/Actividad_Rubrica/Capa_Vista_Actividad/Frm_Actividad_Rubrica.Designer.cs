namespace Capa_Vista_Actividad
{
    partial class Frm_Actividad_Rubrica
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Actividad_Rubrica));
            this.lblId = new System.Windows.Forms.Label();
            this.lblActividad = new System.Windows.Forms.Label();
            this.lblRubrica = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.cmbActividad = new System.Windows.Forms.ComboBox();
            this.cmbRubrica = new System.Windows.Forms.ComboBox();
            this.chkEstado = new System.Windows.Forms.CheckBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnMostrarTodo = new System.Windows.Forms.Button();
            this.dgvActividadRubrica = new System.Windows.Forms.DataGridView();
            this.Gpb_Datos = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActividadRubrica)).BeginInit();
            this.SuspendLayout();
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(20, 39);
            this.lblId.Name = "lblId";
            this.lblId.TabIndex = 1;
            this.lblId.Text = "ID:";
            this.lblId.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // lblActividad
            // 
            this.lblActividad.AutoSize = true;
            this.lblActividad.Location = new System.Drawing.Point(20, 79);
            this.lblActividad.Name = "lblActividad";
            this.lblActividad.TabIndex = 3;
            this.lblActividad.Text = "Actividad:";
            this.lblActividad.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // lblRubrica
            // 
            this.lblRubrica.AutoSize = true;
            this.lblRubrica.Location = new System.Drawing.Point(20, 119);
            this.lblRubrica.Name = "lblRubrica";
            this.lblRubrica.TabIndex = 5;
            this.lblRubrica.Text = "Rúbrica:";
            this.lblRubrica.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(20, 159);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.TabIndex = 7;
            this.lblEstado.Text = "Estado:";
            this.lblEstado.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(13, 339);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.TabIndex = 14;
            this.lblBuscar.Text = "Buscar:";
            this.lblBuscar.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(130, 35);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(120, 27);
            this.txtId.TabIndex = 2;
            this.txtId.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // cmbActividad
            // 
            this.cmbActividad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbActividad.Location = new System.Drawing.Point(130, 75);
            this.cmbActividad.Name = "cmbActividad";
            this.cmbActividad.Size = new System.Drawing.Size(450, 28);
            this.cmbActividad.TabIndex = 4;
            this.cmbActividad.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // cmbRubrica
            // 
            this.cmbRubrica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRubrica.Location = new System.Drawing.Point(130, 115);
            this.cmbRubrica.Name = "cmbRubrica";
            this.cmbRubrica.Size = new System.Drawing.Size(450, 28);
            this.cmbRubrica.TabIndex = 6;
            this.cmbRubrica.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // chkEstado
            // 
            this.chkEstado.AutoSize = true;
            this.chkEstado.Checked = true;
            this.chkEstado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEstado.Location = new System.Drawing.Point(130, 157);
            this.chkEstado.Name = "chkEstado";
            this.chkEstado.Size = new System.Drawing.Size(66, 20);
            this.chkEstado.TabIndex = 8;
            this.chkEstado.Text = "Activo";
            this.chkEstado.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(85, 335);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(420, 27);
            this.txtBuscar.TabIndex = 15;
            this.txtBuscar.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(13, 15);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(97, 93);
            this.btnNuevo.TabIndex = 9;
            this.btnNuevo.Text = "Ingresar";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(229, 15);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(97, 93);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(121, 15);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(97, 93);
            this.btnModificar.TabIndex = 11;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.btnModificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnModificar.Image = ((System.Drawing.Image)(resources.GetObject("btnModificar.Image")));
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(337, 15);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(97, 93);
            this.btnEliminar.TabIndex = 12;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(445, 15);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(97, 93);
            this.btnSalir.TabIndex = 13;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(515, 333);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(110, 31);
            this.btnBuscar.TabIndex = 16;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnMostrarTodo
            // 
            this.btnMostrarTodo.Location = new System.Drawing.Point(635, 333);
            this.btnMostrarTodo.Name = "btnMostrarTodo";
            this.btnMostrarTodo.Size = new System.Drawing.Size(130, 31);
            this.btnMostrarTodo.TabIndex = 17;
            this.btnMostrarTodo.Text = "Mostrar todo";
            this.btnMostrarTodo.UseVisualStyleBackColor = true;
            this.btnMostrarTodo.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.btnMostrarTodo.Click += new System.EventHandler(this.btnMostrarTodo_Click);
            // 
            // dgvActividadRubrica
            // 
            this.dgvActividadRubrica.AllowUserToAddRows = false;
            this.dgvActividadRubrica.AllowUserToDeleteRows = false;
            this.dgvActividadRubrica.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvActividadRubrica.ColumnHeadersHeight = 29;
            this.dgvActividadRubrica.Location = new System.Drawing.Point(13, 375);
            this.dgvActividadRubrica.MultiSelect = false;
            this.dgvActividadRubrica.Name = "dgvActividadRubrica";
            this.dgvActividadRubrica.ReadOnly = true;
            this.dgvActividadRubrica.RowHeadersWidth = 51;
            this.dgvActividadRubrica.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvActividadRubrica.Size = new System.Drawing.Size(964, 245);
            this.dgvActividadRubrica.TabIndex = 18;
            this.dgvActividadRubrica.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvActividadRubrica.BackgroundColor = System.Drawing.Color.White;
            this.dgvActividadRubrica.RowHeadersVisible = false;
            this.dgvActividadRubrica.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvActividadRubrica_CellClick);
            // 
            // Frm_Actividad_Rubrica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(990, 635);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnSalir);
            // 
            // Gpb_Datos
            // 
            this.Gpb_Datos.Location = new System.Drawing.Point(13, 123);
            this.Gpb_Datos.Size = new System.Drawing.Size(964, 200);
            this.Gpb_Datos.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Gpb_Datos.TabStop = false;
            this.Gpb_Datos.Text = "Datos de la actividad por rúbrica";
            this.Gpb_Datos.Name = "Gpb_Datos";
            this.Controls.Add(this.Gpb_Datos);
            this.Gpb_Datos.Controls.Add(this.lblId);
            this.Gpb_Datos.Controls.Add(this.txtId);
            this.Gpb_Datos.Controls.Add(this.lblActividad);
            this.Gpb_Datos.Controls.Add(this.cmbActividad);
            this.Gpb_Datos.Controls.Add(this.lblRubrica);
            this.Gpb_Datos.Controls.Add(this.cmbRubrica);
            this.Gpb_Datos.Controls.Add(this.lblEstado);
            this.Gpb_Datos.Controls.Add(this.chkEstado);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnMostrarTodo);
            this.Controls.Add(this.dgvActividadRubrica);
            this.Name = "Frm_Actividad_Rubrica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Actividades por Rúbrica";
            this.Load += new System.EventHandler(this.Frm_Actividad_Rubrica_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvActividadRubrica)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblActividad;
        private System.Windows.Forms.Label lblRubrica;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.ComboBox cmbActividad;
        private System.Windows.Forms.ComboBox cmbRubrica;
        private System.Windows.Forms.CheckBox chkEstado;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnMostrarTodo;
        private System.Windows.Forms.DataGridView dgvActividadRubrica;
        private System.Windows.Forms.GroupBox Gpb_Datos;
    }
}