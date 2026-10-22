namespace Capa_Vista_Auditor
{
    partial class Frm_Auditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Auditor));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_salir = new System.Windows.Forms.Button();
            this.Btn_eliminar = new System.Windows.Forms.Button();
            this.Btn_guardar = new System.Windows.Forms.Button();
            this.Btn_consultar = new System.Windows.Forms.Button();
            this.Btn_reporte = new System.Windows.Forms.Button();
            this.Btn_ingresar = new System.Windows.Forms.Button();
            this.Btn_ayuda = new System.Windows.Forms.Button();
            this.Btn_cancelar = new System.Windows.Forms.Button();
            this.Btn_modificar = new System.Windows.Forms.Button();
            this.gb_auditor = new System.Windows.Forms.GroupBox();
            this.Txt_carnet = new System.Windows.Forms.TextBox();
            this.Txt_email = new System.Windows.Forms.TextBox();
            this.Txt_telefono = new System.Windows.Forms.TextBox();
            this.Lbl_telefono = new System.Windows.Forms.Label();
            this.Txt_nombre = new System.Windows.Forms.TextBox();
            this.Txt_id_auditor = new System.Windows.Forms.TextBox();
            this.Cbo_estado = new System.Windows.Forms.ComboBox();
            this.Lbl_Estado = new System.Windows.Forms.Label();
            this.Lbl_nombre_auditor = new System.Windows.Forms.Label();
            this.Lbl_carnet = new System.Windows.Forms.Label();
            this.Lbl_email = new System.Windows.Forms.Label();
            this.Lbl_id_auditor = new System.Windows.Forms.Label();
            this.Dgv_auditor = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.gb_auditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_auditor)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(105)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1486, 82);
            this.panel1.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Rockwell", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(38, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 35);
            this.label1.TabIndex = 1;
            this.label1.Text = "507 - Auditor";
            // 
            // Btn_salir
            // 
            this.Btn_salir.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.Btn_salir.Image = ((System.Drawing.Image)(resources.GetObject("Btn_salir.Image")));
            this.Btn_salir.Location = new System.Drawing.Point(859, 108);
            this.Btn_salir.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_salir.Name = "Btn_salir";
            this.Btn_salir.Size = new System.Drawing.Size(97, 93);
            this.Btn_salir.TabIndex = 82;
            this.Btn_salir.Text = "Salir";
            this.Btn_salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_salir.UseVisualStyleBackColor = true;
            this.Btn_salir.Click += new System.EventHandler(this.Btn_salir_Click);
            // 
            // Btn_eliminar
            // 
            this.Btn_eliminar.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.Btn_eliminar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_eliminar.Image")));
            this.Btn_eliminar.Location = new System.Drawing.Point(431, 108);
            this.Btn_eliminar.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_eliminar.Name = "Btn_eliminar";
            this.Btn_eliminar.Size = new System.Drawing.Size(97, 93);
            this.Btn_eliminar.TabIndex = 77;
            this.Btn_eliminar.Text = "Eliminar";
            this.Btn_eliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_eliminar.UseVisualStyleBackColor = true;
            this.Btn_eliminar.Click += new System.EventHandler(this.Btn_eliminar_Click);
            // 
            // Btn_guardar
            // 
            this.Btn_guardar.BackColor = System.Drawing.Color.White;
            this.Btn_guardar.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.Btn_guardar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_guardar.Image")));
            this.Btn_guardar.Location = new System.Drawing.Point(213, 108);
            this.Btn_guardar.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_guardar.Name = "Btn_guardar";
            this.Btn_guardar.Size = new System.Drawing.Size(97, 93);
            this.Btn_guardar.TabIndex = 76;
            this.Btn_guardar.Text = "Guardar";
            this.Btn_guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_guardar.UseVisualStyleBackColor = true;
            this.Btn_guardar.Click += new System.EventHandler(this.Btn_guardar_Click);
            // 
            // Btn_consultar
            // 
            this.Btn_consultar.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.Btn_consultar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_consultar.Image")));
            this.Btn_consultar.Location = new System.Drawing.Point(540, 108);
            this.Btn_consultar.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_consultar.Name = "Btn_consultar";
            this.Btn_consultar.Size = new System.Drawing.Size(97, 93);
            this.Btn_consultar.TabIndex = 75;
            this.Btn_consultar.Text = "Consultar";
            this.Btn_consultar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_consultar.UseVisualStyleBackColor = true;
            this.Btn_consultar.Click += new System.EventHandler(this.Btn_consultar_Click);
            // 
            // Btn_reporte
            // 
            this.Btn_reporte.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.Btn_reporte.Image = ((System.Drawing.Image)(resources.GetObject("Btn_reporte.Image")));
            this.Btn_reporte.Location = new System.Drawing.Point(649, 108);
            this.Btn_reporte.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_reporte.Name = "Btn_reporte";
            this.Btn_reporte.Size = new System.Drawing.Size(97, 93);
            this.Btn_reporte.TabIndex = 73;
            this.Btn_reporte.Text = "Imprimir";
            this.Btn_reporte.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_reporte.UseVisualStyleBackColor = true;
            this.Btn_reporte.Click += new System.EventHandler(this.Btn_reporte_Click);
            // 
            // Btn_ingresar
            // 
            this.Btn_ingresar.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.Btn_ingresar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_ingresar.Image")));
            this.Btn_ingresar.Location = new System.Drawing.Point(13, 108);
            this.Btn_ingresar.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_ingresar.Name = "Btn_ingresar";
            this.Btn_ingresar.Size = new System.Drawing.Size(87, 93);
            this.Btn_ingresar.TabIndex = 70;
            this.Btn_ingresar.Text = "Ingresar";
            this.Btn_ingresar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_ingresar.UseVisualStyleBackColor = true;
            this.Btn_ingresar.Click += new System.EventHandler(this.Btn_ingresar_Click);
            // 
            // Btn_ayuda
            // 
            this.Btn_ayuda.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.Btn_ayuda.Image = ((System.Drawing.Image)(resources.GetObject("Btn_ayuda.Image")));
            this.Btn_ayuda.Location = new System.Drawing.Point(754, 108);
            this.Btn_ayuda.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_ayuda.Name = "Btn_ayuda";
            this.Btn_ayuda.Size = new System.Drawing.Size(97, 93);
            this.Btn_ayuda.TabIndex = 72;
            this.Btn_ayuda.Text = "Ayuda";
            this.Btn_ayuda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_ayuda.UseVisualStyleBackColor = true;
            this.Btn_ayuda.Click += new System.EventHandler(this.Btn_ayuda_Click);
            // 
            // Btn_cancelar
            // 
            this.Btn_cancelar.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.Btn_cancelar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_cancelar.Image")));
            this.Btn_cancelar.Location = new System.Drawing.Point(322, 108);
            this.Btn_cancelar.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_cancelar.Name = "Btn_cancelar";
            this.Btn_cancelar.Size = new System.Drawing.Size(97, 93);
            this.Btn_cancelar.TabIndex = 71;
            this.Btn_cancelar.Text = "Cancelar";
            this.Btn_cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_cancelar.UseVisualStyleBackColor = true;
            this.Btn_cancelar.Click += new System.EventHandler(this.Btn_cancelar_Click);
            // 
            // Btn_modificar
            // 
            this.Btn_modificar.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.Btn_modificar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_modificar.Image")));
            this.Btn_modificar.Location = new System.Drawing.Point(108, 108);
            this.Btn_modificar.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_modificar.Name = "Btn_modificar";
            this.Btn_modificar.Size = new System.Drawing.Size(97, 93);
            this.Btn_modificar.TabIndex = 74;
            this.Btn_modificar.Text = "Modificar";
            this.Btn_modificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_modificar.UseVisualStyleBackColor = true;
            this.Btn_modificar.Click += new System.EventHandler(this.Btn_modificar_Click);
            // 
            // gb_auditor
            // 
            this.gb_auditor.Controls.Add(this.Txt_carnet);
            this.gb_auditor.Controls.Add(this.Txt_email);
            this.gb_auditor.Controls.Add(this.Txt_telefono);
            this.gb_auditor.Controls.Add(this.Lbl_telefono);
            this.gb_auditor.Controls.Add(this.Txt_nombre);
            this.gb_auditor.Controls.Add(this.Txt_id_auditor);
            this.gb_auditor.Controls.Add(this.Cbo_estado);
            this.gb_auditor.Controls.Add(this.Lbl_Estado);
            this.gb_auditor.Controls.Add(this.Lbl_nombre_auditor);
            this.gb_auditor.Controls.Add(this.Lbl_carnet);
            this.gb_auditor.Controls.Add(this.Lbl_email);
            this.gb_auditor.Controls.Add(this.Lbl_id_auditor);
            this.gb_auditor.Font = new System.Drawing.Font("Rockwell", 10F);
            this.gb_auditor.Location = new System.Drawing.Point(54, 229);
            this.gb_auditor.Margin = new System.Windows.Forms.Padding(4);
            this.gb_auditor.Name = "gb_auditor";
            this.gb_auditor.Padding = new System.Windows.Forms.Padding(4);
            this.gb_auditor.Size = new System.Drawing.Size(848, 225);
            this.gb_auditor.TabIndex = 83;
            this.gb_auditor.TabStop = false;
            this.gb_auditor.Text = "Datos del Auditor";
            // 
            // Txt_carnet
            // 
            this.Txt_carnet.Location = new System.Drawing.Point(634, 33);
            this.Txt_carnet.Name = "Txt_carnet";
            this.Txt_carnet.Size = new System.Drawing.Size(148, 27);
            this.Txt_carnet.TabIndex = 89;
            // 
            // Txt_email
            // 
            this.Txt_email.Location = new System.Drawing.Point(133, 166);
            this.Txt_email.Name = "Txt_email";
            this.Txt_email.Size = new System.Drawing.Size(314, 27);
            this.Txt_email.TabIndex = 88;
            // 
            // Txt_telefono
            // 
            this.Txt_telefono.Location = new System.Drawing.Point(133, 121);
            this.Txt_telefono.MaxLength = 9;
            this.Txt_telefono.Name = "Txt_telefono";
            this.Txt_telefono.Size = new System.Drawing.Size(148, 27);
            this.Txt_telefono.TabIndex = 87;
            // 
            // Lbl_telefono
            // 
            this.Lbl_telefono.AutoSize = true;
            this.Lbl_telefono.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_telefono.Location = new System.Drawing.Point(22, 125);
            this.Lbl_telefono.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_telefono.Name = "Lbl_telefono";
            this.Lbl_telefono.Size = new System.Drawing.Size(84, 20);
            this.Lbl_telefono.TabIndex = 86;
            this.Lbl_telefono.Text = "Teléfono:";
            // 
            // Txt_nombre
            // 
            this.Txt_nombre.Location = new System.Drawing.Point(133, 78);
            this.Txt_nombre.Name = "Txt_nombre";
            this.Txt_nombre.Size = new System.Drawing.Size(314, 27);
            this.Txt_nombre.TabIndex = 85;
            // 
            // Txt_id_auditor
            // 
            this.Txt_id_auditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Txt_id_auditor.Location = new System.Drawing.Point(133, 36);
            this.Txt_id_auditor.Name = "Txt_id_auditor";
            this.Txt_id_auditor.ReadOnly = true;
            this.Txt_id_auditor.Size = new System.Drawing.Size(102, 27);
            this.Txt_id_auditor.TabIndex = 84;
            this.Txt_id_auditor.TabStop = false;
            // 
            // Cbo_estado
            // 
            this.Cbo_estado.FormattingEnabled = true;
            this.Cbo_estado.Location = new System.Drawing.Point(634, 130);
            this.Cbo_estado.Margin = new System.Windows.Forms.Padding(4);
            this.Cbo_estado.MaxLength = 13;
            this.Cbo_estado.Name = "Cbo_estado";
            this.Cbo_estado.Size = new System.Drawing.Size(189, 28);
            this.Cbo_estado.TabIndex = 17;
            // 
            // Lbl_Estado
            // 
            this.Lbl_Estado.AutoSize = true;
            this.Lbl_Estado.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Estado.Location = new System.Drawing.Point(545, 135);
            this.Lbl_Estado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_Estado.Name = "Lbl_Estado";
            this.Lbl_Estado.Size = new System.Drawing.Size(67, 20);
            this.Lbl_Estado.TabIndex = 14;
            this.Lbl_Estado.Text = "Estado:";
            // 
            // Lbl_nombre_auditor
            // 
            this.Lbl_nombre_auditor.AutoSize = true;
            this.Lbl_nombre_auditor.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_nombre_auditor.Location = new System.Drawing.Point(22, 82);
            this.Lbl_nombre_auditor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_nombre_auditor.Name = "Lbl_nombre_auditor";
            this.Lbl_nombre_auditor.Size = new System.Drawing.Size(78, 20);
            this.Lbl_nombre_auditor.TabIndex = 12;
            this.Lbl_nombre_auditor.Text = "Nombre:";
            // 
            // Lbl_carnet
            // 
            this.Lbl_carnet.AutoSize = true;
            this.Lbl_carnet.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_carnet.Location = new System.Drawing.Point(544, 40);
            this.Lbl_carnet.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_carnet.Name = "Lbl_carnet";
            this.Lbl_carnet.Size = new System.Drawing.Size(68, 20);
            this.Lbl_carnet.TabIndex = 2;
            this.Lbl_carnet.Text = "Carnet:";
            // 
            // Lbl_email
            // 
            this.Lbl_email.AutoSize = true;
            this.Lbl_email.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_email.Location = new System.Drawing.Point(25, 170);
            this.Lbl_email.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_email.Name = "Lbl_email";
            this.Lbl_email.Size = new System.Drawing.Size(59, 20);
            this.Lbl_email.TabIndex = 1;
            this.Lbl_email.Text = "Email:";
            // 
            // Lbl_id_auditor
            // 
            this.Lbl_id_auditor.AutoSize = true;
            this.Lbl_id_auditor.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Lbl_id_auditor.Location = new System.Drawing.Point(22, 36);
            this.Lbl_id_auditor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_id_auditor.Name = "Lbl_id_auditor";
            this.Lbl_id_auditor.Size = new System.Drawing.Size(94, 20);
            this.Lbl_id_auditor.TabIndex = 0;
            this.Lbl_id_auditor.Text = "ID Auditor:";
            // 
            // Dgv_auditor
            // 
            this.Dgv_auditor.AllowUserToAddRows = false;
            this.Dgv_auditor.AllowUserToDeleteRows = false;
            this.Dgv_auditor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Dgv_auditor.BackgroundColor = System.Drawing.Color.White;
            this.Dgv_auditor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_auditor.Location = new System.Drawing.Point(54, 475);
            this.Dgv_auditor.MultiSelect = false;
            this.Dgv_auditor.Name = "Dgv_auditor";
            this.Dgv_auditor.ReadOnly = true;
            this.Dgv_auditor.RowHeadersVisible = false;
            this.Dgv_auditor.RowHeadersWidth = 51;
            this.Dgv_auditor.RowTemplate.Height = 24;
            this.Dgv_auditor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv_auditor.Size = new System.Drawing.Size(848, 171);
            this.Dgv_auditor.TabIndex = 84;
            this.Dgv_auditor.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_auditor_CellClick);
            // 
            // Frm_Auditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(973, 669);
            this.Controls.Add(this.Dgv_auditor);
            this.Controls.Add(this.gb_auditor);
            this.Controls.Add(this.Btn_salir);
            this.Controls.Add(this.Btn_eliminar);
            this.Controls.Add(this.Btn_guardar);
            this.Controls.Add(this.Btn_consultar);
            this.Controls.Add(this.Btn_reporte);
            this.Controls.Add(this.Btn_ingresar);
            this.Controls.Add(this.Btn_ayuda);
            this.Controls.Add(this.Btn_cancelar);
            this.Controls.Add(this.Btn_modificar);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "Frm_Auditor";
            this.Text = "Auditor";
            this.Load += new System.EventHandler(this.Frm_Auditor_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gb_auditor.ResumeLayout(false);
            this.gb_auditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_auditor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Btn_salir;
        private System.Windows.Forms.Button Btn_eliminar;
        private System.Windows.Forms.Button Btn_guardar;
        private System.Windows.Forms.Button Btn_consultar;
        private System.Windows.Forms.Button Btn_reporte;
        private System.Windows.Forms.Button Btn_ingresar;
        private System.Windows.Forms.Button Btn_ayuda;
        private System.Windows.Forms.Button Btn_cancelar;
        private System.Windows.Forms.Button Btn_modificar;
        private System.Windows.Forms.GroupBox gb_auditor;
        private System.Windows.Forms.ComboBox Cbo_estado;
        private System.Windows.Forms.Label Lbl_Estado;
        private System.Windows.Forms.Label Lbl_nombre_auditor;
        private System.Windows.Forms.Label Lbl_carnet;
        private System.Windows.Forms.Label Lbl_email;
        private System.Windows.Forms.Label Lbl_id_auditor;
        private System.Windows.Forms.TextBox Txt_id_auditor;
        private System.Windows.Forms.TextBox Txt_telefono;
        private System.Windows.Forms.Label Lbl_telefono;
        private System.Windows.Forms.TextBox Txt_nombre;
        private System.Windows.Forms.TextBox Txt_email;
        private System.Windows.Forms.TextBox Txt_carnet;
        private System.Windows.Forms.DataGridView Dgv_auditor;
    }
}