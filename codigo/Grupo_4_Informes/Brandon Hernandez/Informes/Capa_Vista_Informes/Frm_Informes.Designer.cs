namespace Capa_Vista_Informes
{
    partial class Frm_Informes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Informes));
            this.Btn_Ayuda = new System.Windows.Forms.Button();
            this.Btn_Salir = new System.Windows.Forms.Button();
            this.Btn_Insertar = new System.Windows.Forms.Button();
            this.Btn_Modificar = new System.Windows.Forms.Button();
            this.Btn_Imprimir = new System.Windows.Forms.Button();
            this.Btn_Guardar = new System.Windows.Forms.Button();
            this.Btn_Consultar = new System.Windows.Forms.Button();
            this.Btn_Eliminar = new System.Windows.Forms.Button();
            this.Cbo_Auditores = new System.Windows.Forms.ComboBox();
            this.Gbp_Campos = new System.Windows.Forms.GroupBox();
            this.Lbl_Titulo = new System.Windows.Forms.Label();
            this.Lbl_Proyecto = new System.Windows.Forms.Label();
            this.Lbl_Estado = new System.Windows.Forms.Label();
            this.Lbl_Auditor = new System.Windows.Forms.Label();
            this.Txt_Titulo = new System.Windows.Forms.TextBox();
            this.Cbo_Proyecto = new System.Windows.Forms.ComboBox();
            this.Cbo_Estado = new System.Windows.Forms.ComboBox();
            this.Dgv_Informes = new System.Windows.Forms.DataGridView();
            this.Gbp_Campos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Informes)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_Ayuda
            // 
            this.Btn_Ayuda.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.Btn_Ayuda.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Ayuda.Image")));
            this.Btn_Ayuda.Location = new System.Drawing.Point(661, 15);
            this.Btn_Ayuda.Name = "Btn_Ayuda";
            this.Btn_Ayuda.Size = new System.Drawing.Size(97, 93);
            this.Btn_Ayuda.TabIndex = 6;
            this.Btn_Ayuda.Text = "Ayuda";
            this.Btn_Ayuda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Ayuda.UseVisualStyleBackColor = true;
            this.Btn_Ayuda.Click += new System.EventHandler(this.Btn_Ayuda_Click);
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.Btn_Salir.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Salir.Image")));
            this.Btn_Salir.Location = new System.Drawing.Point(769, 15);
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(97, 93);
            this.Btn_Salir.TabIndex = 7;
            this.Btn_Salir.Text = "Salir";
            this.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Salir.UseVisualStyleBackColor = true;
            this.Btn_Salir.Click += new System.EventHandler(this.Btn_Salir_Click);
            // 
            // Btn_Insertar
            // 
            this.Btn_Insertar.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.Btn_Insertar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Insertar.Image")));
            this.Btn_Insertar.Location = new System.Drawing.Point(13, 15);
            this.Btn_Insertar.Name = "Btn_Insertar";
            this.Btn_Insertar.Size = new System.Drawing.Size(97, 93);
            this.Btn_Insertar.TabIndex = 0;
            this.Btn_Insertar.Text = "Ingresar";
            this.Btn_Insertar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Insertar.UseVisualStyleBackColor = true;
            this.Btn_Insertar.Click += new System.EventHandler(this.Btn_Insertar_Click);
            // 
            // Btn_Modificar
            // 
            this.Btn_Modificar.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.Btn_Modificar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Modificar.Image")));
            this.Btn_Modificar.Location = new System.Drawing.Point(121, 15);
            this.Btn_Modificar.Name = "Btn_Modificar";
            this.Btn_Modificar.Size = new System.Drawing.Size(97, 93);
            this.Btn_Modificar.TabIndex = 1;
            this.Btn_Modificar.Text = "Modificar";
            this.Btn_Modificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Modificar.UseVisualStyleBackColor = true;
            this.Btn_Modificar.Click += new System.EventHandler(this.Btn_Modificar_Click);
            // 
            // Btn_Imprimir
            // 
            this.Btn_Imprimir.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.Btn_Imprimir.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Imprimir.Image")));
            this.Btn_Imprimir.Location = new System.Drawing.Point(553, 15);
            this.Btn_Imprimir.Name = "Btn_Imprimir";
            this.Btn_Imprimir.Size = new System.Drawing.Size(97, 93);
            this.Btn_Imprimir.TabIndex = 5;
            this.Btn_Imprimir.Text = "Imprimir";
            this.Btn_Imprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Imprimir.UseVisualStyleBackColor = true;
            this.Btn_Imprimir.Click += new System.EventHandler(this.Btn_Imprimir_Click);
            // 
            // Btn_Guardar
            // 
            this.Btn_Guardar.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.Btn_Guardar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Guardar.Image")));
            this.Btn_Guardar.Location = new System.Drawing.Point(229, 15);
            this.Btn_Guardar.Name = "Btn_Guardar";
            this.Btn_Guardar.Size = new System.Drawing.Size(97, 93);
            this.Btn_Guardar.TabIndex = 2;
            this.Btn_Guardar.Text = "Guardar";
            this.Btn_Guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Guardar.UseVisualStyleBackColor = true;
            this.Btn_Guardar.Click += new System.EventHandler(this.Btn_Guardar_Click);
            // 
            // Btn_Consultar
            // 
            this.Btn_Consultar.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.Btn_Consultar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Consultar.Image")));
            this.Btn_Consultar.Location = new System.Drawing.Point(445, 15);
            this.Btn_Consultar.Name = "Btn_Consultar";
            this.Btn_Consultar.Size = new System.Drawing.Size(97, 93);
            this.Btn_Consultar.TabIndex = 4;
            this.Btn_Consultar.Text = "Consultar";
            this.Btn_Consultar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Consultar.UseVisualStyleBackColor = true;
            this.Btn_Consultar.Click += new System.EventHandler(this.Btn_Consultar_Click);
            // 
            // Btn_Eliminar
            // 
            this.Btn_Eliminar.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.Btn_Eliminar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Eliminar.Image")));
            this.Btn_Eliminar.Location = new System.Drawing.Point(337, 15);
            this.Btn_Eliminar.Name = "Btn_Eliminar";
            this.Btn_Eliminar.Size = new System.Drawing.Size(97, 93);
            this.Btn_Eliminar.TabIndex = 3;
            this.Btn_Eliminar.Text = "Eliminar";
            this.Btn_Eliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Eliminar.UseVisualStyleBackColor = true;
            this.Btn_Eliminar.Click += new System.EventHandler(this.Btn_Eliminar_Click);
            // 
            // Cbo_Auditores
            // 
            this.Cbo_Auditores.FormattingEnabled = true;
            this.Cbo_Auditores.Location = new System.Drawing.Point(120, 35);
            this.Cbo_Auditores.Name = "Cbo_Auditores";
            this.Cbo_Auditores.Size = new System.Drawing.Size(340, 28);
            this.Cbo_Auditores.TabIndex = 8;
            this.Cbo_Auditores.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // Gbp_Campos
            // 
            this.Gbp_Campos.Location = new System.Drawing.Point(13, 123);
            this.Gbp_Campos.Name = "Gbp_Campos";
            this.Gbp_Campos.Size = new System.Drawing.Size(964, 125);
            this.Gbp_Campos.TabIndex = 10;
            this.Gbp_Campos.TabStop = false;
            this.Gbp_Campos.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Gbp_Campos.Text = "Datos del informe";
            // 
            // Lbl_Titulo
            // 
            this.Lbl_Titulo.AutoSize = true;
            this.Lbl_Titulo.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Lbl_Titulo.Location = new System.Drawing.Point(490, 79);
            this.Lbl_Titulo.Name = "Lbl_Titulo";
            this.Lbl_Titulo.TabIndex = 15;
            this.Lbl_Titulo.Text = "Título:";
            // 
            // Lbl_Proyecto
            // 
            this.Lbl_Proyecto.AutoSize = true;
            this.Lbl_Proyecto.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Lbl_Proyecto.Location = new System.Drawing.Point(20, 79);
            this.Lbl_Proyecto.Name = "Lbl_Proyecto";
            this.Lbl_Proyecto.TabIndex = 14;
            this.Lbl_Proyecto.Text = "Proyecto:";
            // 
            // Lbl_Estado
            // 
            this.Lbl_Estado.AutoSize = true;
            this.Lbl_Estado.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Lbl_Estado.Location = new System.Drawing.Point(490, 39);
            this.Lbl_Estado.Name = "Lbl_Estado";
            this.Lbl_Estado.TabIndex = 13;
            this.Lbl_Estado.Text = "Estado:";
            // 
            // Lbl_Auditor
            // 
            this.Lbl_Auditor.AutoSize = true;
            this.Lbl_Auditor.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Lbl_Auditor.Location = new System.Drawing.Point(20, 39);
            this.Lbl_Auditor.Name = "Lbl_Auditor";
            this.Lbl_Auditor.TabIndex = 12;
            this.Lbl_Auditor.Text = "Auditor:";
            // 
            // Txt_Titulo
            // 
            this.Txt_Titulo.Location = new System.Drawing.Point(580, 75);
            this.Txt_Titulo.Name = "Txt_Titulo";
            this.Txt_Titulo.Size = new System.Drawing.Size(364, 27);
            this.Txt_Titulo.TabIndex = 11;
            this.Txt_Titulo.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // Cbo_Proyecto
            // 
            this.Cbo_Proyecto.FormattingEnabled = true;
            this.Cbo_Proyecto.Location = new System.Drawing.Point(120, 75);
            this.Cbo_Proyecto.Name = "Cbo_Proyecto";
            this.Cbo_Proyecto.Size = new System.Drawing.Size(340, 28);
            this.Cbo_Proyecto.TabIndex = 10;
            this.Cbo_Proyecto.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // Cbo_Estado
            // 
            this.Cbo_Estado.FormattingEnabled = true;
            this.Cbo_Estado.Location = new System.Drawing.Point(580, 35);
            this.Cbo_Estado.Name = "Cbo_Estado";
            this.Cbo_Estado.Size = new System.Drawing.Size(364, 28);
            this.Cbo_Estado.TabIndex = 9;
            this.Cbo_Estado.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // Dgv_Informes
            // 
            this.Dgv_Informes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_Informes.Location = new System.Drawing.Point(13, 263);
            this.Dgv_Informes.Name = "Dgv_Informes";
            this.Dgv_Informes.Size = new System.Drawing.Size(964, 280);
            this.Dgv_Informes.TabIndex = 11;
            this.Dgv_Informes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Dgv_Informes.BackgroundColor = System.Drawing.Color.White;
            this.Dgv_Informes.RowHeadersVisible = false;
            this.Dgv_Informes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Dgv_Informes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_Informes_CellClick);
            // 
            // Frm_Informes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(194)))), ((int)(((byte)(99)))));
            this.ClientSize = new System.Drawing.Size(990, 558);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Controls.Add(this.Btn_Insertar);
            this.Controls.Add(this.Btn_Modificar);
            this.Controls.Add(this.Btn_Guardar);
            this.Controls.Add(this.Btn_Eliminar);
            this.Controls.Add(this.Btn_Consultar);
            this.Controls.Add(this.Btn_Imprimir);
            this.Controls.Add(this.Btn_Ayuda);
            this.Controls.Add(this.Btn_Salir);
            this.Controls.Add(this.Gbp_Campos);
            this.Gbp_Campos.Controls.Add(this.Lbl_Auditor);
            this.Gbp_Campos.Controls.Add(this.Cbo_Auditores);
            this.Gbp_Campos.Controls.Add(this.Lbl_Proyecto);
            this.Gbp_Campos.Controls.Add(this.Cbo_Proyecto);
            this.Gbp_Campos.Controls.Add(this.Lbl_Estado);
            this.Gbp_Campos.Controls.Add(this.Cbo_Estado);
            this.Gbp_Campos.Controls.Add(this.Lbl_Titulo);
            this.Gbp_Campos.Controls.Add(this.Txt_Titulo);
            this.Controls.Add(this.Dgv_Informes);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "Frm_Informes";
            this.Text = "Informes";
            this.Load += new System.EventHandler(this.e);
            this.Gbp_Campos.ResumeLayout(false);
            this.Gbp_Campos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Informes)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button Btn_Insertar;
        private System.Windows.Forms.Button Btn_Modificar;
        private System.Windows.Forms.Button Btn_Guardar;
        private System.Windows.Forms.Button Btn_Eliminar;
        private System.Windows.Forms.Button Btn_Consultar;
        private System.Windows.Forms.Button Btn_Imprimir;
        private System.Windows.Forms.Button Btn_Ayuda;
        private System.Windows.Forms.Button Btn_Salir;
        private System.Windows.Forms.ComboBox Cbo_Auditores;
        private System.Windows.Forms.GroupBox Gbp_Campos;
        private System.Windows.Forms.Label Lbl_Auditor;
        private System.Windows.Forms.TextBox Txt_Titulo;
        private System.Windows.Forms.ComboBox Cbo_Proyecto;
        private System.Windows.Forms.ComboBox Cbo_Estado;
        private System.Windows.Forms.DataGridView Dgv_Informes;
        private System.Windows.Forms.Label Lbl_Titulo;
        private System.Windows.Forms.Label Lbl_Proyecto;
        private System.Windows.Forms.Label Lbl_Estado;
    }
}