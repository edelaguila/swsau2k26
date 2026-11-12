//Inicio de código de Paula Daniela Leonardo Paredes carné 0901-22-9580 en la fecha de: "20/10/2026"
namespace Capa_Vista_PY
{
    partial class Frm_PY
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_PY));
            this.Gpb_Datos_PY = new System.Windows.Forms.GroupBox();
            this.Lbl_Id_PY = new System.Windows.Forms.Label();
            this.Txt_Id_PY = new System.Windows.Forms.TextBox();
            this.Lbl_Estado_PY = new System.Windows.Forms.Label();
            this.Cbo_Estado_PY = new System.Windows.Forms.ComboBox();
            this.Lbl_Nombre_PY = new System.Windows.Forms.Label();
            this.Txt_Nombre_PY = new System.Windows.Forms.TextBox();
            this.Lbl_Inicio_PY = new System.Windows.Forms.Label();
            this.Dtp_Inicio_PY = new System.Windows.Forms.DateTimePicker();
            this.Lbl_Fin_PY = new System.Windows.Forms.Label();
            this.Dtp_Fin_PY = new System.Windows.Forms.DateTimePicker();
            this.Lbl_Descripcion_PY = new System.Windows.Forms.Label();
            this.Txt_Descripcion_PY = new System.Windows.Forms.TextBox();
            this.Lbl_Objetivo_PY = new System.Windows.Forms.Label();
            this.Txt_Objetivo_PY = new System.Windows.Forms.TextBox();
            this.Btn_Guardar_PY = new System.Windows.Forms.Button();
            this.Btn_Modificar_PY = new System.Windows.Forms.Button();
            this.Btn_Eliminar_PY = new System.Windows.Forms.Button();
            this.Btn_Limpiar_PY = new System.Windows.Forms.Button();
            this.Btn_Ayuda_PY = new System.Windows.Forms.Button();
            this.Dgv_PY = new System.Windows.Forms.DataGridView();
            this.Btn_Salir_PY = new System.Windows.Forms.Button();
            this.Btn_Imprimir = new System.Windows.Forms.Button();
            this.Gpb_Datos_PY.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_PY)).BeginInit();
            this.SuspendLayout();
            // 
            // Gpb_Datos_PY
            // 
            this.Gpb_Datos_PY.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Gpb_Datos_PY.Location = new System.Drawing.Point(13, 123);
            this.Gpb_Datos_PY.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Gpb_Datos_PY.Name = "Gpb_Datos_PY";
            this.Gpb_Datos_PY.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Gpb_Datos_PY.Size = new System.Drawing.Size(964, 242);
            this.Gpb_Datos_PY.TabIndex = 1;
            this.Gpb_Datos_PY.TabStop = false;
            this.Gpb_Datos_PY.Text = "Datos del proyecto";
            // 
            // Lbl_Id_PY
            // 
            this.Lbl_Id_PY.AutoSize = true;
            this.Lbl_Id_PY.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Lbl_Id_PY.Location = new System.Drawing.Point(20, 39);
            this.Lbl_Id_PY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_Id_PY.Name = "Lbl_Id_PY";
            this.Lbl_Id_PY.TabIndex = 0;
            this.Lbl_Id_PY.Text = "Código:";
            // 
            // Txt_Id_PY
            // 
            this.Txt_Id_PY.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Txt_Id_PY.Location = new System.Drawing.Point(150, 35);
            this.Txt_Id_PY.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Txt_Id_PY.Name = "Txt_Id_PY";
            this.Txt_Id_PY.ReadOnly = true;
            this.Txt_Id_PY.Size = new System.Drawing.Size(150, 27);
            this.Txt_Id_PY.TabIndex = 1;
            this.Txt_Id_PY.TabStop = false;
            // 
            // Lbl_Estado_PY
            // 
            this.Lbl_Estado_PY.AutoSize = true;
            this.Lbl_Estado_PY.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Lbl_Estado_PY.Location = new System.Drawing.Point(20, 79);
            this.Lbl_Estado_PY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_Estado_PY.Name = "Lbl_Estado_PY";
            this.Lbl_Estado_PY.TabIndex = 2;
            this.Lbl_Estado_PY.Text = "Estado:";
            // 
            // Cbo_Estado_PY
            // 
            this.Cbo_Estado_PY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbo_Estado_PY.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Cbo_Estado_PY.FormattingEnabled = true;
            this.Cbo_Estado_PY.Location = new System.Drawing.Point(150, 75);
            this.Cbo_Estado_PY.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Cbo_Estado_PY.Name = "Cbo_Estado_PY";
            this.Cbo_Estado_PY.Size = new System.Drawing.Size(300, 28);
            this.Cbo_Estado_PY.TabIndex = 3;
            // 
            // Lbl_Nombre_PY
            // 
            this.Lbl_Nombre_PY.AutoSize = true;
            this.Lbl_Nombre_PY.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Lbl_Nombre_PY.Location = new System.Drawing.Point(20, 119);
            this.Lbl_Nombre_PY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_Nombre_PY.Name = "Lbl_Nombre_PY";
            this.Lbl_Nombre_PY.TabIndex = 4;
            this.Lbl_Nombre_PY.Text = "Nombre:";
            // 
            // Txt_Nombre_PY
            // 
            this.Txt_Nombre_PY.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Txt_Nombre_PY.Location = new System.Drawing.Point(150, 115);
            this.Txt_Nombre_PY.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Txt_Nombre_PY.MaxLength = 100;
            this.Txt_Nombre_PY.Name = "Txt_Nombre_PY";
            this.Txt_Nombre_PY.Size = new System.Drawing.Size(300, 27);
            this.Txt_Nombre_PY.TabIndex = 5;
            // 
            // Lbl_Inicio_PY
            // 
            this.Lbl_Inicio_PY.AutoSize = true;
            this.Lbl_Inicio_PY.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Lbl_Inicio_PY.Location = new System.Drawing.Point(20, 159);
            this.Lbl_Inicio_PY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_Inicio_PY.Name = "Lbl_Inicio_PY";
            this.Lbl_Inicio_PY.TabIndex = 6;
            this.Lbl_Inicio_PY.Text = "Fecha inicio:";
            // 
            // Dtp_Inicio_PY
            // 
            this.Dtp_Inicio_PY.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Dtp_Inicio_PY.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Dtp_Inicio_PY.Location = new System.Drawing.Point(150, 155);
            this.Dtp_Inicio_PY.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Dtp_Inicio_PY.Name = "Dtp_Inicio_PY";
            this.Dtp_Inicio_PY.ShowCheckBox = true;
            this.Dtp_Inicio_PY.Size = new System.Drawing.Size(240, 27);
            this.Dtp_Inicio_PY.TabIndex = 7;
            // 
            // Lbl_Fin_PY
            // 
            this.Lbl_Fin_PY.AutoSize = true;
            this.Lbl_Fin_PY.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Lbl_Fin_PY.Location = new System.Drawing.Point(20, 199);
            this.Lbl_Fin_PY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_Fin_PY.Name = "Lbl_Fin_PY";
            this.Lbl_Fin_PY.TabIndex = 8;
            this.Lbl_Fin_PY.Text = "Fecha fin:";
            // 
            // Dtp_Fin_PY
            // 
            this.Dtp_Fin_PY.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Dtp_Fin_PY.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Dtp_Fin_PY.Location = new System.Drawing.Point(150, 195);
            this.Dtp_Fin_PY.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Dtp_Fin_PY.Name = "Dtp_Fin_PY";
            this.Dtp_Fin_PY.ShowCheckBox = true;
            this.Dtp_Fin_PY.Size = new System.Drawing.Size(240, 27);
            this.Dtp_Fin_PY.TabIndex = 9;
            // 
            // Lbl_Descripcion_PY
            // 
            this.Lbl_Descripcion_PY.AutoSize = true;
            this.Lbl_Descripcion_PY.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Lbl_Descripcion_PY.Location = new System.Drawing.Point(490, 39);
            this.Lbl_Descripcion_PY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_Descripcion_PY.Name = "Lbl_Descripcion_PY";
            this.Lbl_Descripcion_PY.TabIndex = 10;
            this.Lbl_Descripcion_PY.Text = "Descripción:";
            // 
            // Txt_Descripcion_PY
            // 
            this.Txt_Descripcion_PY.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Txt_Descripcion_PY.Location = new System.Drawing.Point(610, 35);
            this.Txt_Descripcion_PY.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Txt_Descripcion_PY.Multiline = true;
            this.Txt_Descripcion_PY.Name = "Txt_Descripcion_PY";
            this.Txt_Descripcion_PY.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Txt_Descripcion_PY.Size = new System.Drawing.Size(334, 75);
            this.Txt_Descripcion_PY.TabIndex = 11;
            // 
            // Lbl_Objetivo_PY
            // 
            this.Lbl_Objetivo_PY.AutoSize = true;
            this.Lbl_Objetivo_PY.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Lbl_Objetivo_PY.Location = new System.Drawing.Point(490, 124);
            this.Lbl_Objetivo_PY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_Objetivo_PY.Name = "Lbl_Objetivo_PY";
            this.Lbl_Objetivo_PY.TabIndex = 12;
            this.Lbl_Objetivo_PY.Text = "Objetivo:";
            // 
            // Txt_Objetivo_PY
            // 
            this.Txt_Objetivo_PY.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Txt_Objetivo_PY.Location = new System.Drawing.Point(610, 120);
            this.Txt_Objetivo_PY.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Txt_Objetivo_PY.Multiline = true;
            this.Txt_Objetivo_PY.Name = "Txt_Objetivo_PY";
            this.Txt_Objetivo_PY.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Txt_Objetivo_PY.Size = new System.Drawing.Size(334, 75);
            this.Txt_Objetivo_PY.TabIndex = 13;
            // 
            // Btn_Guardar_PY
            // 
            this.Btn_Guardar_PY.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.Btn_Guardar_PY.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Guardar_PY.Image")));
            this.Btn_Guardar_PY.Location = new System.Drawing.Point(121, 15);
            this.Btn_Guardar_PY.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Btn_Guardar_PY.Name = "Btn_Guardar_PY";
            this.Btn_Guardar_PY.Size = new System.Drawing.Size(97, 93);
            this.Btn_Guardar_PY.TabIndex = 0;
            this.Btn_Guardar_PY.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Guardar_PY.UseVisualStyleBackColor = true;
            this.Btn_Guardar_PY.Text = "Guardar";
            this.Btn_Guardar_PY.Click += new System.EventHandler(this.Btn_Guardar_PY_Click);
            // 
            // Btn_Modificar_PY
            // 
            this.Btn_Modificar_PY.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.Btn_Modificar_PY.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Modificar_PY.Image")));
            this.Btn_Modificar_PY.Location = new System.Drawing.Point(13, 15);
            this.Btn_Modificar_PY.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Btn_Modificar_PY.Name = "Btn_Modificar_PY";
            this.Btn_Modificar_PY.Size = new System.Drawing.Size(97, 93);
            this.Btn_Modificar_PY.TabIndex = 1;
            this.Btn_Modificar_PY.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Modificar_PY.UseVisualStyleBackColor = true;
            this.Btn_Modificar_PY.Text = "Modificar";
            this.Btn_Modificar_PY.Click += new System.EventHandler(this.Btn_Modificar_PY_Click);
            // 
            // Btn_Eliminar_PY
            // 
            this.Btn_Eliminar_PY.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.Btn_Eliminar_PY.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Eliminar_PY.Image")));
            this.Btn_Eliminar_PY.Location = new System.Drawing.Point(337, 15);
            this.Btn_Eliminar_PY.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Btn_Eliminar_PY.Name = "Btn_Eliminar_PY";
            this.Btn_Eliminar_PY.Size = new System.Drawing.Size(97, 93);
            this.Btn_Eliminar_PY.TabIndex = 2;
            this.Btn_Eliminar_PY.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Eliminar_PY.UseVisualStyleBackColor = true;
            this.Btn_Eliminar_PY.Text = "Eliminar";
            this.Btn_Eliminar_PY.Click += new System.EventHandler(this.Btn_Eliminar_PY_Click);
            // 
            // Btn_Limpiar_PY
            // 
            this.Btn_Limpiar_PY.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.Btn_Limpiar_PY.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Limpiar_PY.Image")));
            this.Btn_Limpiar_PY.Location = new System.Drawing.Point(229, 15);
            this.Btn_Limpiar_PY.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Btn_Limpiar_PY.Name = "Btn_Limpiar_PY";
            this.Btn_Limpiar_PY.Size = new System.Drawing.Size(97, 93);
            this.Btn_Limpiar_PY.TabIndex = 3;
            this.Btn_Limpiar_PY.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Limpiar_PY.UseVisualStyleBackColor = true;
            this.Btn_Limpiar_PY.Text = "Cancelar";
            this.Btn_Limpiar_PY.Click += new System.EventHandler(this.Btn_Limpiar_PY_Click);
            // 
            // Btn_Ayuda_PY
            // 
            this.Btn_Ayuda_PY.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.Btn_Ayuda_PY.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Ayuda_PY.Image")));
            this.Btn_Ayuda_PY.Location = new System.Drawing.Point(553, 15);
            this.Btn_Ayuda_PY.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Btn_Ayuda_PY.Name = "Btn_Ayuda_PY";
            this.Btn_Ayuda_PY.Size = new System.Drawing.Size(97, 93);
            this.Btn_Ayuda_PY.TabIndex = 4;
            this.Btn_Ayuda_PY.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Ayuda_PY.UseVisualStyleBackColor = true;
            this.Btn_Ayuda_PY.Text = "Ayuda";
            this.Btn_Ayuda_PY.Click += new System.EventHandler(this.Btn_Ayuda_PY_Click);
            // 
            // Dgv_PY
            // 
            this.Dgv_PY.AllowUserToAddRows = false;
            this.Dgv_PY.AllowUserToDeleteRows = false;
            this.Dgv_PY.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Dgv_PY.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Dgv_PY.BackgroundColor = System.Drawing.Color.White;
            this.Dgv_PY.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_PY.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Dgv_PY.Location = new System.Drawing.Point(13, 380);
            this.Dgv_PY.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Dgv_PY.MultiSelect = false;
            this.Dgv_PY.Name = "Dgv_PY";
            this.Dgv_PY.ReadOnly = true;
            this.Dgv_PY.RowHeadersVisible = false;
            this.Dgv_PY.RowHeadersWidth = 51;
            this.Dgv_PY.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv_PY.Size = new System.Drawing.Size(964, 260);
            this.Dgv_PY.TabIndex = 3;
            this.Dgv_PY.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_PY_CellClick);
            // 
            // Frm_PY
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(177)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(990, 655);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            // 
            // Btn_Salir_PY
            // 
            this.Btn_Salir_PY.Text = "Salir";
            this.Btn_Salir_PY.Name = "Btn_Salir_PY";
            this.Btn_Salir_PY.Location = new System.Drawing.Point(661, 15);
            this.Btn_Salir_PY.Size = new System.Drawing.Size(97, 93);
            this.Btn_Salir_PY.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.Btn_Salir_PY.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Salir_PY.UseVisualStyleBackColor = true;
            this.Btn_Salir_PY.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Salir_PY.Image")));
            this.Btn_Salir_PY.Click += new System.EventHandler(this.Btn_Salir_PY_Click);
            this.Controls.Add(this.Btn_Salir_PY);
            this.Controls.Add(this.Btn_Modificar_PY);
            this.Controls.Add(this.Btn_Guardar_PY);
            this.Controls.Add(this.Btn_Limpiar_PY);
            this.Controls.Add(this.Btn_Eliminar_PY);
            this.Controls.Add(this.Btn_Ayuda_PY);
            this.Controls.Add(this.Gpb_Datos_PY);
            this.Gpb_Datos_PY.Controls.Add(this.Lbl_Id_PY);
            this.Gpb_Datos_PY.Controls.Add(this.Txt_Id_PY);
            this.Gpb_Datos_PY.Controls.Add(this.Lbl_Estado_PY);
            this.Gpb_Datos_PY.Controls.Add(this.Cbo_Estado_PY);
            this.Gpb_Datos_PY.Controls.Add(this.Lbl_Nombre_PY);
            this.Gpb_Datos_PY.Controls.Add(this.Txt_Nombre_PY);
            this.Gpb_Datos_PY.Controls.Add(this.Lbl_Inicio_PY);
            this.Gpb_Datos_PY.Controls.Add(this.Dtp_Inicio_PY);
            this.Gpb_Datos_PY.Controls.Add(this.Lbl_Fin_PY);
            this.Gpb_Datos_PY.Controls.Add(this.Dtp_Fin_PY);
            this.Gpb_Datos_PY.Controls.Add(this.Lbl_Descripcion_PY);
            this.Gpb_Datos_PY.Controls.Add(this.Txt_Descripcion_PY);
            this.Gpb_Datos_PY.Controls.Add(this.Lbl_Objetivo_PY);
            this.Gpb_Datos_PY.Controls.Add(this.Txt_Objetivo_PY);
            this.Controls.Add(this.Dgv_PY);
            // 
            // Btn_Imprimir
            // 
            this.Btn_Imprimir.Text = "Imprimir";
            this.Btn_Imprimir.Name = "Btn_Imprimir";
            this.Btn_Imprimir.Location = new System.Drawing.Point(445, 15);
            this.Btn_Imprimir.Size = new System.Drawing.Size(97, 93);
            this.Btn_Imprimir.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.Btn_Imprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Imprimir.UseVisualStyleBackColor = true;
            this.Btn_Imprimir.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Imprimir.Image")));
            this.Btn_Imprimir.Click += new System.EventHandler(this.Btn_Imprimir_Click);
            this.Controls.Add(this.Btn_Imprimir);
            this.Name = "Frm_PY";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proyectos";
            this.Load += new System.EventHandler(this.Frm_PY_Load);
            this.Gpb_Datos_PY.ResumeLayout(false);
            this.Gpb_Datos_PY.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_PY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox Gpb_Datos_PY;
        private System.Windows.Forms.Label Lbl_Id_PY;
        private System.Windows.Forms.TextBox Txt_Id_PY;
        private System.Windows.Forms.Label Lbl_Estado_PY;
        private System.Windows.Forms.ComboBox Cbo_Estado_PY;
        private System.Windows.Forms.Label Lbl_Nombre_PY;
        private System.Windows.Forms.TextBox Txt_Nombre_PY;
        private System.Windows.Forms.Label Lbl_Inicio_PY;
        private System.Windows.Forms.DateTimePicker Dtp_Inicio_PY;
        private System.Windows.Forms.Label Lbl_Fin_PY;
        private System.Windows.Forms.DateTimePicker Dtp_Fin_PY;
        private System.Windows.Forms.Label Lbl_Descripcion_PY;
        private System.Windows.Forms.TextBox Txt_Descripcion_PY;
        private System.Windows.Forms.Label Lbl_Objetivo_PY;
        private System.Windows.Forms.TextBox Txt_Objetivo_PY;
        private System.Windows.Forms.Button Btn_Guardar_PY;
        private System.Windows.Forms.Button Btn_Modificar_PY;
        private System.Windows.Forms.Button Btn_Eliminar_PY;
        private System.Windows.Forms.Button Btn_Limpiar_PY;
        private System.Windows.Forms.Button Btn_Ayuda_PY;
        private System.Windows.Forms.DataGridView Dgv_PY;
        private System.Windows.Forms.Button Btn_Salir_PY;
        private System.Windows.Forms.Button Btn_Imprimir;
    }
}
//Fin de código de Paula Daniela Leonardo Paredes carné 0901-22-9580 en la fecha de: "20/10/2026"
