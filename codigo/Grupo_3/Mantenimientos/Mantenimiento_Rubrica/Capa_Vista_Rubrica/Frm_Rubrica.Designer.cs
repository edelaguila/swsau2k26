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
            this.lblTitulo = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvRubricas)).BeginInit();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblTitulo.Text = "Mantenimiento de Rúbricas";

            // lblId / txtId
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(20, 65);
            this.lblId.Text = "ID:";
            this.txtId.Location = new System.Drawing.Point(130, 62);
            this.txtId.Size = new System.Drawing.Size(80, 23);
            this.txtId.ReadOnly = true;

            // lblCronograma / cmbCronograma
            this.lblCronograma.AutoSize = true;
            this.lblCronograma.Location = new System.Drawing.Point(20, 100);
            this.lblCronograma.Text = "Cronograma:";
            this.cmbCronograma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCronograma.Location = new System.Drawing.Point(130, 97);
            this.cmbCronograma.Size = new System.Drawing.Size(300, 23);

            // lblNombre / txtNombre
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(20, 135);
            this.lblNombre.Text = "Nombre:";
            this.txtNombre.Location = new System.Drawing.Point(130, 132);
            this.txtNombre.MaxLength = 100;
            this.txtNombre.Size = new System.Drawing.Size(300, 23);

            // lblDescripcion / txtDescripcion
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(20, 170);
            this.lblDescripcion.Text = "Descripción:";
            this.txtDescripcion.Location = new System.Drawing.Point(130, 167);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescripcion.Size = new System.Drawing.Size(300, 60);

            // lblObjetivo / txtObjetivo
            this.lblObjetivo.AutoSize = true;
            this.lblObjetivo.Location = new System.Drawing.Point(20, 240);
            this.lblObjetivo.Text = "Objetivo:";
            this.txtObjetivo.Location = new System.Drawing.Point(130, 237);
            this.txtObjetivo.Multiline = true;
            this.txtObjetivo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObjetivo.Size = new System.Drawing.Size(300, 60);

            // Botones CRUD (columna derecha)
            this.btnNuevo.Location = new System.Drawing.Point(470, 62);
            this.btnNuevo.Size = new System.Drawing.Size(110, 32);
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);

            this.btnGuardar.Location = new System.Drawing.Point(470, 102);
            this.btnGuardar.Size = new System.Drawing.Size(110, 32);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            this.btnModificar.Location = new System.Drawing.Point(470, 142);
            this.btnModificar.Size = new System.Drawing.Size(110, 32);
            this.btnModificar.Text = "Modificar";
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);

            this.btnEliminar.Location = new System.Drawing.Point(470, 182);
            this.btnEliminar.Size = new System.Drawing.Size(110, 32);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            this.btnSalir.Location = new System.Drawing.Point(470, 265);
            this.btnSalir.Size = new System.Drawing.Size(110, 32);
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);

            // Busqueda
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(20, 320);
            this.lblBuscar.Text = "Buscar por nombre:";
            this.txtBuscar.Location = new System.Drawing.Point(150, 317);
            this.txtBuscar.Size = new System.Drawing.Size(280, 23);

            this.btnBuscar.Location = new System.Drawing.Point(445, 314);
            this.btnBuscar.Size = new System.Drawing.Size(80, 28);
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);

            this.btnMostrarTodo.Location = new System.Drawing.Point(530, 314);
            this.btnMostrarTodo.Size = new System.Drawing.Size(90, 28);
            this.btnMostrarTodo.Text = "Mostrar todo";
            this.btnMostrarTodo.Click += new System.EventHandler(this.btnMostrarTodo_Click);

            // dgvRubricas
            this.dgvRubricas.AllowUserToAddRows = false;
            this.dgvRubricas.AllowUserToDeleteRows = false;
            this.dgvRubricas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRubricas.Location = new System.Drawing.Point(20, 355);
            this.dgvRubricas.MultiSelect = false;
            this.dgvRubricas.ReadOnly = true;
            this.dgvRubricas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRubricas.Size = new System.Drawing.Size(600, 200);
            this.dgvRubricas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRubricas_CellClick);

            // Frm_Rubrica
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 575);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblCronograma);
            this.Controls.Add(this.cmbCronograma);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblObjetivo);
            this.Controls.Add(this.txtObjetivo);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnMostrarTodo);
            this.Controls.Add(this.dgvRubricas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Frm_Rubrica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rúbricas";
            this.Load += new System.EventHandler(this.Frm_Rubrica_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRubricas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo;
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
    }
}