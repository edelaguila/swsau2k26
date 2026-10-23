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
            this.Btn_Ayuda.BackColor = System.Drawing.Color.White;
            this.Btn_Ayuda.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Btn_Ayuda.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Ayuda.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Ayuda.Image")));
            this.Btn_Ayuda.Location = new System.Drawing.Point(615, 12);
            this.Btn_Ayuda.Name = "Btn_Ayuda";
            this.Btn_Ayuda.Size = new System.Drawing.Size(88, 88);
            this.Btn_Ayuda.TabIndex = 6;
            this.Btn_Ayuda.Text = "Ayuda";
            this.Btn_Ayuda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Ayuda.UseVisualStyleBackColor = false;
            this.Btn_Ayuda.Click += new System.EventHandler(this.Btn_Ayuda_Click);
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.BackColor = System.Drawing.Color.White;
            this.Btn_Salir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Btn_Salir.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Salir.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Salir.Image")));
            this.Btn_Salir.Location = new System.Drawing.Point(715, 12);
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(88, 88);
            this.Btn_Salir.TabIndex = 7;
            this.Btn_Salir.Text = "Salir";
            this.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Salir.UseVisualStyleBackColor = false;
            this.Btn_Salir.Click += new System.EventHandler(this.Btn_Salir_Click);
            // 
            // Btn_Insertar
            // 
            this.Btn_Insertar.BackColor = System.Drawing.Color.White;
            this.Btn_Insertar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Btn_Insertar.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Insertar.Image = global::Capa_Vista_Informes.Properties.Resources.icono_agregar;
            this.Btn_Insertar.Location = new System.Drawing.Point(15, 12);
            this.Btn_Insertar.Name = "Btn_Insertar";
            this.Btn_Insertar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Btn_Insertar.Size = new System.Drawing.Size(88, 88);
            this.Btn_Insertar.TabIndex = 0;
            this.Btn_Insertar.Text = "Ingresar";
            this.Btn_Insertar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Insertar.UseVisualStyleBackColor = false;
            this.Btn_Insertar.Click += new System.EventHandler(this.Btn_Insertar_Click);
            // 
            // Btn_Modificar
            // 
            this.Btn_Modificar.BackColor = System.Drawing.Color.White;
            this.Btn_Modificar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Btn_Modificar.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Modificar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Modificar.Image")));
            this.Btn_Modificar.Location = new System.Drawing.Point(115, 12);
            this.Btn_Modificar.Name = "Btn_Modificar";
            this.Btn_Modificar.Size = new System.Drawing.Size(88, 88);
            this.Btn_Modificar.TabIndex = 1;
            this.Btn_Modificar.Text = "Modificar";
            this.Btn_Modificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Modificar.UseVisualStyleBackColor = false;
            this.Btn_Modificar.Click += new System.EventHandler(this.Btn_Modificar_Click);
            // 
            // Btn_Imprimir
            // 
            this.Btn_Imprimir.BackColor = System.Drawing.Color.White;
            this.Btn_Imprimir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Btn_Imprimir.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Imprimir.Image = global::Capa_Vista_Informes.Properties.Resources.icono_imprimir;
            this.Btn_Imprimir.Location = new System.Drawing.Point(515, 12);
            this.Btn_Imprimir.Name = "Btn_Imprimir";
            this.Btn_Imprimir.Size = new System.Drawing.Size(88, 88);
            this.Btn_Imprimir.TabIndex = 5;
            this.Btn_Imprimir.Text = "Imprimir";
            this.Btn_Imprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Imprimir.UseVisualStyleBackColor = false;
            this.Btn_Imprimir.Click += new System.EventHandler(this.Btn_Imprimir_Click);
            // 
            // Btn_Guardar
            // 
            this.Btn_Guardar.BackColor = System.Drawing.Color.White;
            this.Btn_Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Btn_Guardar.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Guardar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Guardar.Image")));
            this.Btn_Guardar.Location = new System.Drawing.Point(215, 12);
            this.Btn_Guardar.Name = "Btn_Guardar";
            this.Btn_Guardar.Size = new System.Drawing.Size(88, 88);
            this.Btn_Guardar.TabIndex = 2;
            this.Btn_Guardar.Text = "Guardar";
            this.Btn_Guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Guardar.UseVisualStyleBackColor = false;
            this.Btn_Guardar.Click += new System.EventHandler(this.Btn_Guardar_Click);
            // 
            // Btn_Consultar
            // 
            this.Btn_Consultar.BackColor = System.Drawing.Color.White;
            this.Btn_Consultar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Btn_Consultar.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Consultar.Image = global::Capa_Vista_Informes.Properties.Resources.icono_buscar;
            this.Btn_Consultar.Location = new System.Drawing.Point(415, 12);
            this.Btn_Consultar.Name = "Btn_Consultar";
            this.Btn_Consultar.Size = new System.Drawing.Size(88, 88);
            this.Btn_Consultar.TabIndex = 4;
            this.Btn_Consultar.Text = "Consultar";
            this.Btn_Consultar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Consultar.UseVisualStyleBackColor = false;
            this.Btn_Consultar.Click += new System.EventHandler(this.Btn_Consultar_Click);
            // 
            // Btn_Eliminar
            // 
            this.Btn_Eliminar.BackColor = System.Drawing.Color.White;
            this.Btn_Eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Btn_Eliminar.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Eliminar.Image = global::Capa_Vista_Informes.Properties.Resources.icono_eliminar;
            this.Btn_Eliminar.Location = new System.Drawing.Point(315, 12);
            this.Btn_Eliminar.Name = "Btn_Eliminar";
            this.Btn_Eliminar.Size = new System.Drawing.Size(88, 88);
            this.Btn_Eliminar.TabIndex = 3;
            this.Btn_Eliminar.Text = "Eliminar";
            this.Btn_Eliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Eliminar.UseVisualStyleBackColor = false;
            this.Btn_Eliminar.Click += new System.EventHandler(this.Btn_Eliminar_Click);
            // 
            // Cbo_Auditores
            // 
            this.Cbo_Auditores.FormattingEnabled = true;
            this.Cbo_Auditores.Location = new System.Drawing.Point(6, 49);
            this.Cbo_Auditores.Name = "Cbo_Auditores";
            this.Cbo_Auditores.Size = new System.Drawing.Size(363, 21);
            this.Cbo_Auditores.TabIndex = 8;
            // 
            // Gbp_Campos
            // 
            this.Gbp_Campos.Controls.Add(this.Lbl_Titulo);
            this.Gbp_Campos.Controls.Add(this.Lbl_Proyecto);
            this.Gbp_Campos.Controls.Add(this.Lbl_Estado);
            this.Gbp_Campos.Controls.Add(this.Lbl_Auditor);
            this.Gbp_Campos.Controls.Add(this.Txt_Titulo);
            this.Gbp_Campos.Controls.Add(this.Cbo_Proyecto);
            this.Gbp_Campos.Controls.Add(this.Cbo_Estado);
            this.Gbp_Campos.Controls.Add(this.Cbo_Auditores);
            this.Gbp_Campos.Location = new System.Drawing.Point(12, 120);
            this.Gbp_Campos.Name = "Gbp_Campos";
            this.Gbp_Campos.Size = new System.Drawing.Size(815, 154);
            this.Gbp_Campos.TabIndex = 10;
            this.Gbp_Campos.TabStop = false;
            // 
            // Lbl_Titulo
            // 
            this.Lbl_Titulo.AutoSize = true;
            this.Lbl_Titulo.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.Lbl_Titulo.Location = new System.Drawing.Point(433, 82);
            this.Lbl_Titulo.Name = "Lbl_Titulo";
            this.Lbl_Titulo.Size = new System.Drawing.Size(38, 16);
            this.Lbl_Titulo.TabIndex = 15;
            this.Lbl_Titulo.Text = "Titulo";
            // 
            // Lbl_Proyecto
            // 
            this.Lbl_Proyecto.AutoSize = true;
            this.Lbl_Proyecto.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.Lbl_Proyecto.Location = new System.Drawing.Point(25, 85);
            this.Lbl_Proyecto.Name = "Lbl_Proyecto";
            this.Lbl_Proyecto.Size = new System.Drawing.Size(58, 16);
            this.Lbl_Proyecto.TabIndex = 14;
            this.Lbl_Proyecto.Text = "Proyecto";
            // 
            // Lbl_Estado
            // 
            this.Lbl_Estado.AutoSize = true;
            this.Lbl_Estado.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.Lbl_Estado.Location = new System.Drawing.Point(433, 33);
            this.Lbl_Estado.Name = "Lbl_Estado";
            this.Lbl_Estado.Size = new System.Drawing.Size(47, 16);
            this.Lbl_Estado.TabIndex = 13;
            this.Lbl_Estado.Text = "Estado";
            // 
            // Lbl_Auditor
            // 
            this.Lbl_Auditor.AutoSize = true;
            this.Lbl_Auditor.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Auditor.Location = new System.Drawing.Point(25, 33);
            this.Lbl_Auditor.Name = "Lbl_Auditor";
            this.Lbl_Auditor.Size = new System.Drawing.Size(50, 16);
            this.Lbl_Auditor.TabIndex = 12;
            this.Lbl_Auditor.Text = "Auditor";
            // 
            // Txt_Titulo
            // 
            this.Txt_Titulo.Location = new System.Drawing.Point(425, 101);
            this.Txt_Titulo.Name = "Txt_Titulo";
            this.Txt_Titulo.Size = new System.Drawing.Size(363, 20);
            this.Txt_Titulo.TabIndex = 11;
            // 
            // Cbo_Proyecto
            // 
            this.Cbo_Proyecto.FormattingEnabled = true;
            this.Cbo_Proyecto.Location = new System.Drawing.Point(6, 101);
            this.Cbo_Proyecto.Name = "Cbo_Proyecto";
            this.Cbo_Proyecto.Size = new System.Drawing.Size(363, 21);
            this.Cbo_Proyecto.TabIndex = 10;
            // 
            // Cbo_Estado
            // 
            this.Cbo_Estado.FormattingEnabled = true;
            this.Cbo_Estado.Location = new System.Drawing.Point(425, 49);
            this.Cbo_Estado.Name = "Cbo_Estado";
            this.Cbo_Estado.Size = new System.Drawing.Size(363, 21);
            this.Cbo_Estado.TabIndex = 9;
            // 
            // Dgv_Informes
            // 
            this.Dgv_Informes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_Informes.Location = new System.Drawing.Point(12, 314);
            this.Dgv_Informes.Name = "Dgv_Informes";
            this.Dgv_Informes.Size = new System.Drawing.Size(809, 256);
            this.Dgv_Informes.TabIndex = 11;
            this.Dgv_Informes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_Informes_CellClick);
            // 
            // Frm_Informes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(194)))), ((int)(((byte)(99)))));
            this.ClientSize = new System.Drawing.Size(843, 582);
            this.Controls.Add(this.Dgv_Informes);
            this.Controls.Add(this.Gbp_Campos);
            this.Controls.Add(this.Btn_Salir);
            this.Controls.Add(this.Btn_Insertar);
            this.Controls.Add(this.Btn_Ayuda);
            this.Controls.Add(this.Btn_Modificar);
            this.Controls.Add(this.Btn_Imprimir);
            this.Controls.Add(this.Btn_Guardar);
            this.Controls.Add(this.Btn_Consultar);
            this.Controls.Add(this.Btn_Eliminar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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