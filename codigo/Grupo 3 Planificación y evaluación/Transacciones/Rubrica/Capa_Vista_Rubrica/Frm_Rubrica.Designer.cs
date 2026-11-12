namespace Capa_Vista_Rubrica
{
    partial class Frm_Rubrica
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Rubrica));
            this.lblId = new System.Windows.Forms.Label();
            this.lblCronograma = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblObjetivo = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.cmbCronograma = new System.Windows.Forms.ComboBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtObjetivo = new System.Windows.Forms.TextBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnMostrarTodo = new System.Windows.Forms.Button();
            this.dgvRubricas = new System.Windows.Forms.DataGridView();
            this.Gpb_Datos = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRubricas)).BeginInit();
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
            // lblCronograma
            // 
            this.lblCronograma.AutoSize = true;
            this.lblCronograma.Location = new System.Drawing.Point(20, 79);
            this.lblCronograma.Name = "lblCronograma";
            this.lblCronograma.TabIndex = 3;
            this.lblCronograma.Text = "Cronograma:";
            this.lblCronograma.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(20, 119);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.TabIndex = 5;
            this.lblNombre.Text = "Nombre:";
            this.lblNombre.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(480, 39);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.TabIndex = 7;
            this.lblDescripcion.Text = "Descripción:";
            this.lblDescripcion.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // lblObjetivo
            // 
            this.lblObjetivo.AutoSize = true;
            this.lblObjetivo.Location = new System.Drawing.Point(480, 119);
            this.lblObjetivo.Name = "lblObjetivo";
            this.lblObjetivo.TabIndex = 9;
            this.lblObjetivo.Text = "Objetivo:";
            this.lblObjetivo.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(13, 344);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.TabIndex = 16;
            this.lblBuscar.Text = "Buscar por nombre:";
            this.lblBuscar.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(140, 35);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(120, 27);
            this.txtId.TabIndex = 2;
            this.txtId.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // cmbCronograma
            // 
            this.cmbCronograma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCronograma.Location = new System.Drawing.Point(140, 75);
            this.cmbCronograma.Name = "cmbCronograma";
            this.cmbCronograma.Size = new System.Drawing.Size(300, 28);
            this.cmbCronograma.TabIndex = 4;
            this.cmbCronograma.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(140, 115);
            this.txtNombre.MaxLength = 100;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(300, 27);
            this.txtNombre.TabIndex = 6;
            this.txtNombre.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(600, 35);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescripcion.Size = new System.Drawing.Size(344, 70);
            this.txtDescripcion.TabIndex = 8;
            this.txtDescripcion.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // txtObjetivo
            // 
            this.txtObjetivo.Location = new System.Drawing.Point(600, 115);
            this.txtObjetivo.Multiline = true;
            this.txtObjetivo.Name = "txtObjetivo";
            this.txtObjetivo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObjetivo.Size = new System.Drawing.Size(344, 70);
            this.txtObjetivo.TabIndex = 10;
            this.txtObjetivo.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(185, 340);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(345, 27);
            this.txtBuscar.TabIndex = 17;
            this.txtBuscar.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(13, 15);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(97, 93);
            this.btnNuevo.TabIndex = 11;
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
            this.btnGuardar.TabIndex = 12;
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
            this.btnModificar.TabIndex = 13;
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
            this.btnEliminar.TabIndex = 14;
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
            this.btnSalir.TabIndex = 15;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(540, 338);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(110, 31);
            this.btnBuscar.TabIndex = 18;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnMostrarTodo
            // 
            this.btnMostrarTodo.Location = new System.Drawing.Point(660, 338);
            this.btnMostrarTodo.Name = "btnMostrarTodo";
            this.btnMostrarTodo.Size = new System.Drawing.Size(130, 31);
            this.btnMostrarTodo.TabIndex = 19;
            this.btnMostrarTodo.Text = "Mostrar todo";
            this.btnMostrarTodo.UseVisualStyleBackColor = true;
            this.btnMostrarTodo.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.btnMostrarTodo.Click += new System.EventHandler(this.btnMostrarTodo_Click);
            // 
            // dgvRubricas
            // 
            this.dgvRubricas.AllowUserToAddRows = false;
            this.dgvRubricas.AllowUserToDeleteRows = false;
            this.dgvRubricas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRubricas.Location = new System.Drawing.Point(13, 380);
            this.dgvRubricas.MultiSelect = false;
            this.dgvRubricas.Name = "dgvRubricas";
            this.dgvRubricas.ReadOnly = true;
            this.dgvRubricas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRubricas.Size = new System.Drawing.Size(964, 240);
            this.dgvRubricas.TabIndex = 20;
            this.dgvRubricas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRubricas.BackgroundColor = System.Drawing.Color.White;
            this.dgvRubricas.RowHeadersVisible = false;
            this.dgvRubricas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRubricas_CellClick);
            // 
            // Frm_Rubrica
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
            this.Gpb_Datos.Size = new System.Drawing.Size(964, 205);
            this.Gpb_Datos.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Gpb_Datos.TabStop = false;
            this.Gpb_Datos.Text = "Datos de la rúbrica";
            this.Gpb_Datos.Name = "Gpb_Datos";
            this.Controls.Add(this.Gpb_Datos);
            this.Gpb_Datos.Controls.Add(this.lblId);
            this.Gpb_Datos.Controls.Add(this.txtId);
            this.Gpb_Datos.Controls.Add(this.lblCronograma);
            this.Gpb_Datos.Controls.Add(this.cmbCronograma);
            this.Gpb_Datos.Controls.Add(this.lblNombre);
            this.Gpb_Datos.Controls.Add(this.txtNombre);
            this.Gpb_Datos.Controls.Add(this.lblDescripcion);
            this.Gpb_Datos.Controls.Add(this.txtDescripcion);
            this.Gpb_Datos.Controls.Add(this.lblObjetivo);
            this.Gpb_Datos.Controls.Add(this.txtObjetivo);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnMostrarTodo);
            this.Controls.Add(this.dgvRubricas);
            this.Name = "Frm_Rubrica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rúbricas";
            this.Load += new System.EventHandler(this.Frm_Rubrica_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRubricas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblCronograma;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblObjetivo;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.ComboBox cmbCronograma;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtObjetivo;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnMostrarTodo;
        private System.Windows.Forms.DataGridView dgvRubricas;
        private System.Windows.Forms.GroupBox Gpb_Datos;
    }
}