namespace Capa_Vista_Recursos
{
    partial class Frm_Recursos
    {
        private System.ComponentModel.IContainer components = null;

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
        private void InitializeComponent()
        {
            this.Lbl_Titulo = new System.Windows.Forms.Label();
            this.Gpb_Datos = new System.Windows.Forms.GroupBox();
            this.Lbl_Id = new System.Windows.Forms.Label();
            this.Txt_Id = new System.Windows.Forms.TextBox();
            this.Lbl_Proyecto = new System.Windows.Forms.Label();
            this.Cbo_Proyecto = new System.Windows.Forms.ComboBox();
            this.Lbl_Nombre = new System.Windows.Forms.Label();
            this.Txt_Nombre = new System.Windows.Forms.TextBox();
            this.Lbl_Tipo = new System.Windows.Forms.Label();
            this.Cbo_Tipo = new System.Windows.Forms.ComboBox();
            this.Lbl_Cantidad = new System.Windows.Forms.Label();
            this.Nud_Cantidad = new System.Windows.Forms.NumericUpDown();
            this.Pnl_Botones = new System.Windows.Forms.Panel();
            this.Btn_Guardar = new System.Windows.Forms.Button();
            this.Btn_Modificar = new System.Windows.Forms.Button();
            this.Btn_Eliminar = new System.Windows.Forms.Button();
            this.Btn_Cancelar = new System.Windows.Forms.Button();
            this.Dgv_Recursos = new System.Windows.Forms.DataGridView();
            this.Gpb_Datos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_Cantidad)).BeginInit();
            this.Pnl_Botones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Recursos)).BeginInit();
            this.SuspendLayout();
            // 
            // Lbl_Titulo
            // 
            this.Lbl_Titulo.AutoSize = true;
            this.Lbl_Titulo.Font = new System.Drawing.Font("Rockwell", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Titulo.Location = new System.Drawing.Point(20, 12);
            this.Lbl_Titulo.Name = "Lbl_Titulo";
            this.Lbl_Titulo.Size = new System.Drawing.Size(380, 29);
            this.Lbl_Titulo.TabIndex = 0;
            this.Lbl_Titulo.Text = "MANTENIMIENTO RECURSOS";
            // 
            // Gpb_Datos
            // 
            this.Gpb_Datos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Gpb_Datos.Controls.Add(this.Lbl_Id);
            this.Gpb_Datos.Controls.Add(this.Txt_Id);
            this.Gpb_Datos.Controls.Add(this.Lbl_Proyecto);
            this.Gpb_Datos.Controls.Add(this.Cbo_Proyecto);
            this.Gpb_Datos.Controls.Add(this.Lbl_Nombre);
            this.Gpb_Datos.Controls.Add(this.Txt_Nombre);
            this.Gpb_Datos.Controls.Add(this.Lbl_Tipo);
            this.Gpb_Datos.Controls.Add(this.Cbo_Tipo);
            this.Gpb_Datos.Controls.Add(this.Lbl_Cantidad);
            this.Gpb_Datos.Controls.Add(this.Nud_Cantidad);
            this.Gpb_Datos.Font = new System.Drawing.Font("Rockwell", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gpb_Datos.Location = new System.Drawing.Point(20, 60);
            this.Gpb_Datos.Name = "Gpb_Datos";
            this.Gpb_Datos.Size = new System.Drawing.Size(960, 150);
            this.Gpb_Datos.TabIndex = 1;
            this.Gpb_Datos.TabStop = false;
            this.Gpb_Datos.Text = "Datos del recurso";
            // 
            // Lbl_Id
            // 
            this.Lbl_Id.AutoSize = true;
            this.Lbl_Id.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Lbl_Id.Location = new System.Drawing.Point(20, 35);
            this.Lbl_Id.Name = "Lbl_Id";
            this.Lbl_Id.Size = new System.Drawing.Size(76, 16);
            this.Lbl_Id.TabIndex = 0;
            this.Lbl_Id.Text = "Id recurso";
            // 
            // Txt_Id
            // 
            this.Txt_Id.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Txt_Id.Location = new System.Drawing.Point(150, 32);
            this.Txt_Id.Name = "Txt_Id";
            this.Txt_Id.ReadOnly = true;
            this.Txt_Id.Size = new System.Drawing.Size(100, 23);
            this.Txt_Id.TabIndex = 1;
            this.Txt_Id.TabStop = false;
            // 
            // Lbl_Proyecto
            // 
            this.Lbl_Proyecto.AutoSize = true;
            this.Lbl_Proyecto.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Lbl_Proyecto.Location = new System.Drawing.Point(20, 70);
            this.Lbl_Proyecto.Name = "Lbl_Proyecto";
            this.Lbl_Proyecto.Size = new System.Drawing.Size(66, 16);
            this.Lbl_Proyecto.TabIndex = 2;
            this.Lbl_Proyecto.Text = "Proyecto";
            // 
            // Cbo_Proyecto
            // 
            this.Cbo_Proyecto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbo_Proyecto.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Cbo_Proyecto.FormattingEnabled = true;
            this.Cbo_Proyecto.Location = new System.Drawing.Point(150, 67);
            this.Cbo_Proyecto.Name = "Cbo_Proyecto";
            this.Cbo_Proyecto.Size = new System.Drawing.Size(330, 24);
            this.Cbo_Proyecto.TabIndex = 3;
            // 
            // Lbl_Nombre
            // 
            this.Lbl_Nombre.AutoSize = true;
            this.Lbl_Nombre.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Lbl_Nombre.Location = new System.Drawing.Point(20, 105);
            this.Lbl_Nombre.Name = "Lbl_Nombre";
            this.Lbl_Nombre.Size = new System.Drawing.Size(59, 16);
            this.Lbl_Nombre.TabIndex = 4;
            this.Lbl_Nombre.Text = "Nombre";
            // 
            // Txt_Nombre
            // 
            this.Txt_Nombre.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Txt_Nombre.Location = new System.Drawing.Point(150, 102);
            this.Txt_Nombre.MaxLength = 100;
            this.Txt_Nombre.Name = "Txt_Nombre";
            this.Txt_Nombre.Size = new System.Drawing.Size(330, 23);
            this.Txt_Nombre.TabIndex = 5;
            // 
            // Lbl_Tipo
            // 
            this.Lbl_Tipo.AutoSize = true;
            this.Lbl_Tipo.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Lbl_Tipo.Location = new System.Drawing.Point(540, 70);
            this.Lbl_Tipo.Name = "Lbl_Tipo";
            this.Lbl_Tipo.Size = new System.Drawing.Size(34, 16);
            this.Lbl_Tipo.TabIndex = 6;
            this.Lbl_Tipo.Text = "Tipo";
            // 
            // Cbo_Tipo
            // 
            this.Cbo_Tipo.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Cbo_Tipo.FormattingEnabled = true;
            this.Cbo_Tipo.Items.AddRange(new object[] {
            "Material",
            "Herramienta",
            "Equipo"});
            this.Cbo_Tipo.Location = new System.Drawing.Point(650, 67);
            this.Cbo_Tipo.MaxLength = 100;
            this.Cbo_Tipo.Name = "Cbo_Tipo";
            this.Cbo_Tipo.Size = new System.Drawing.Size(280, 24);
            this.Cbo_Tipo.TabIndex = 7;
            // 
            // Lbl_Cantidad
            // 
            this.Lbl_Cantidad.AutoSize = true;
            this.Lbl_Cantidad.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Lbl_Cantidad.Location = new System.Drawing.Point(540, 105);
            this.Lbl_Cantidad.Name = "Lbl_Cantidad";
            this.Lbl_Cantidad.Size = new System.Drawing.Size(64, 16);
            this.Lbl_Cantidad.TabIndex = 8;
            this.Lbl_Cantidad.Text = "Cantidad";
            // 
            // Nud_Cantidad
            // 
            this.Nud_Cantidad.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Nud_Cantidad.Location = new System.Drawing.Point(650, 102);
            this.Nud_Cantidad.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.Nud_Cantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Nud_Cantidad.Name = "Nud_Cantidad";
            this.Nud_Cantidad.Size = new System.Drawing.Size(100, 23);
            this.Nud_Cantidad.TabIndex = 9;
            this.Nud_Cantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Pnl_Botones
            // 
            this.Pnl_Botones.Controls.Add(this.Btn_Guardar);
            this.Pnl_Botones.Controls.Add(this.Btn_Modificar);
            this.Pnl_Botones.Controls.Add(this.Btn_Eliminar);
            this.Pnl_Botones.Controls.Add(this.Btn_Cancelar);
            this.Pnl_Botones.Location = new System.Drawing.Point(20, 220);
            this.Pnl_Botones.Name = "Pnl_Botones";
            this.Pnl_Botones.Size = new System.Drawing.Size(960, 45);
            this.Pnl_Botones.TabIndex = 2;
            // 
            // Btn_Guardar
            // 
            this.Btn_Guardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            this.Btn_Guardar.FlatAppearance.BorderSize = 0;
            this.Btn_Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Guardar.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Btn_Guardar.ForeColor = System.Drawing.Color.White;
            this.Btn_Guardar.Location = new System.Drawing.Point(0, 5);
            this.Btn_Guardar.Name = "Btn_Guardar";
            this.Btn_Guardar.Size = new System.Drawing.Size(140, 34);
            this.Btn_Guardar.TabIndex = 0;
            this.Btn_Guardar.Text = "Guardar";
            this.Btn_Guardar.UseVisualStyleBackColor = false;
            this.Btn_Guardar.Click += new System.EventHandler(this.Btn_Guardar_Click);
            // 
            // Btn_Modificar
            // 
            this.Btn_Modificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            this.Btn_Modificar.FlatAppearance.BorderSize = 0;
            this.Btn_Modificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Modificar.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Btn_Modificar.ForeColor = System.Drawing.Color.White;
            this.Btn_Modificar.Location = new System.Drawing.Point(150, 5);
            this.Btn_Modificar.Name = "Btn_Modificar";
            this.Btn_Modificar.Size = new System.Drawing.Size(140, 34);
            this.Btn_Modificar.TabIndex = 1;
            this.Btn_Modificar.Text = "Modificar";
            this.Btn_Modificar.UseVisualStyleBackColor = false;
            this.Btn_Modificar.Click += new System.EventHandler(this.Btn_Modificar_Click);
            // 
            // Btn_Eliminar
            // 
            this.Btn_Eliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            this.Btn_Eliminar.FlatAppearance.BorderSize = 0;
            this.Btn_Eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Eliminar.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Btn_Eliminar.ForeColor = System.Drawing.Color.White;
            this.Btn_Eliminar.Location = new System.Drawing.Point(300, 5);
            this.Btn_Eliminar.Name = "Btn_Eliminar";
            this.Btn_Eliminar.Size = new System.Drawing.Size(140, 34);
            this.Btn_Eliminar.TabIndex = 2;
            this.Btn_Eliminar.Text = "Eliminar";
            this.Btn_Eliminar.UseVisualStyleBackColor = false;
            this.Btn_Eliminar.Click += new System.EventHandler(this.Btn_Eliminar_Click);
            // 
            // Btn_Cancelar
            // 
            this.Btn_Cancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            this.Btn_Cancelar.FlatAppearance.BorderSize = 0;
            this.Btn_Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Cancelar.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Btn_Cancelar.ForeColor = System.Drawing.Color.White;
            this.Btn_Cancelar.Location = new System.Drawing.Point(450, 5);
            this.Btn_Cancelar.Name = "Btn_Cancelar";
            this.Btn_Cancelar.Size = new System.Drawing.Size(140, 34);
            this.Btn_Cancelar.TabIndex = 3;
            this.Btn_Cancelar.Text = "Cancelar";
            this.Btn_Cancelar.UseVisualStyleBackColor = false;
            this.Btn_Cancelar.Click += new System.EventHandler(this.Btn_Cancelar_Click);
            // 
            // Dgv_Recursos
            // 
            this.Dgv_Recursos.AllowUserToAddRows = false;
            this.Dgv_Recursos.AllowUserToDeleteRows = false;
            this.Dgv_Recursos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Dgv_Recursos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Dgv_Recursos.BackgroundColor = System.Drawing.Color.White;
            this.Dgv_Recursos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_Recursos.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Dgv_Recursos.Location = new System.Drawing.Point(20, 275);
            this.Dgv_Recursos.MultiSelect = false;
            this.Dgv_Recursos.Name = "Dgv_Recursos";
            this.Dgv_Recursos.ReadOnly = true;
            this.Dgv_Recursos.RowHeadersVisible = false;
            this.Dgv_Recursos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv_Recursos.Size = new System.Drawing.Size(960, 255);
            this.Dgv_Recursos.TabIndex = 3;
            this.Dgv_Recursos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_Recursos_CellClick);
            // 
            // Frm_Recursos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(177)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1000, 550);
            this.Controls.Add(this.Dgv_Recursos);
            this.Controls.Add(this.Pnl_Botones);
            this.Controls.Add(this.Gpb_Datos);
            this.Controls.Add(this.Lbl_Titulo);
            this.MinimumSize = new System.Drawing.Size(850, 550);
            this.Name = "Frm_Recursos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Recursos";
            this.Load += new System.EventHandler(this.Frm_Recursos_Load);
            this.Gpb_Datos.ResumeLayout(false);
            this.Gpb_Datos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_Cantidad)).EndInit();
            this.Pnl_Botones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Recursos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbl_Titulo;
        private System.Windows.Forms.GroupBox Gpb_Datos;
        private System.Windows.Forms.Label Lbl_Id;
        private System.Windows.Forms.TextBox Txt_Id;
        private System.Windows.Forms.Label Lbl_Proyecto;
        private System.Windows.Forms.ComboBox Cbo_Proyecto;
        private System.Windows.Forms.Label Lbl_Nombre;
        private System.Windows.Forms.TextBox Txt_Nombre;
        private System.Windows.Forms.Label Lbl_Tipo;
        private System.Windows.Forms.ComboBox Cbo_Tipo;
        private System.Windows.Forms.Label Lbl_Cantidad;
        private System.Windows.Forms.NumericUpDown Nud_Cantidad;
        private System.Windows.Forms.Panel Pnl_Botones;
        private System.Windows.Forms.Button Btn_Guardar;
        private System.Windows.Forms.Button Btn_Modificar;
        private System.Windows.Forms.Button Btn_Eliminar;
        private System.Windows.Forms.Button Btn_Cancelar;
        private System.Windows.Forms.DataGridView Dgv_Recursos;
    }
}