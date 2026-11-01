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
            this.Lbl_Titulo_PY = new System.Windows.Forms.Label();
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
            this.Pnl_Botones_PY = new System.Windows.Forms.Panel();
            this.Btn_Guardar_PY = new System.Windows.Forms.Button();
            this.Btn_Modificar_PY = new System.Windows.Forms.Button();
            this.Btn_Eliminar_PY = new System.Windows.Forms.Button();
            this.Btn_Limpiar_PY = new System.Windows.Forms.Button();
            this.Btn_Ayuda_PY = new System.Windows.Forms.Button();
            this.Dgv_PY = new System.Windows.Forms.DataGridView();
            this.Gpb_Datos_PY.SuspendLayout();
            this.Pnl_Botones_PY.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_PY)).BeginInit();
            this.SuspendLayout();
            // 
            // Lbl_Titulo_PY
            // 
            this.Lbl_Titulo_PY.AutoSize = true;
            this.Lbl_Titulo_PY.Font = new System.Drawing.Font("Rockwell", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Titulo_PY.Location = new System.Drawing.Point(27, 15);
            this.Lbl_Titulo_PY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_Titulo_PY.Name = "Lbl_Titulo_PY";
            this.Lbl_Titulo_PY.Size = new System.Drawing.Size(504, 38);
            this.Lbl_Titulo_PY.TabIndex = 0;
            this.Lbl_Titulo_PY.Text = "MANTENIMIENTO PROYECTOS";
            // 
            // Gpb_Datos_PY
            // 
            this.Gpb_Datos_PY.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.Gpb_Datos_PY.Font = new System.Drawing.Font("Rockwell", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gpb_Datos_PY.Location = new System.Drawing.Point(27, 74);
            this.Gpb_Datos_PY.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Gpb_Datos_PY.Name = "Gpb_Datos_PY";
            this.Gpb_Datos_PY.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Gpb_Datos_PY.Size = new System.Drawing.Size(1280, 308);
            this.Gpb_Datos_PY.TabIndex = 1;
            this.Gpb_Datos_PY.TabStop = false;
            this.Gpb_Datos_PY.Text = "Datos del proyecto";
            // 
            // Lbl_Id_PY
            // 
            this.Lbl_Id_PY.AutoSize = true;
            this.Lbl_Id_PY.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Lbl_Id_PY.Location = new System.Drawing.Point(27, 43);
            this.Lbl_Id_PY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_Id_PY.Name = "Lbl_Id_PY";
            this.Lbl_Id_PY.Size = new System.Drawing.Size(67, 20);
            this.Lbl_Id_PY.TabIndex = 0;
            this.Lbl_Id_PY.Text = "Código";
            // 
            // Txt_Id_PY
            // 
            this.Txt_Id_PY.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Txt_Id_PY.Location = new System.Drawing.Point(200, 39);
            this.Txt_Id_PY.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Txt_Id_PY.Name = "Txt_Id_PY";
            this.Txt_Id_PY.ReadOnly = true;
            this.Txt_Id_PY.Size = new System.Drawing.Size(159, 27);
            this.Txt_Id_PY.TabIndex = 1;
            this.Txt_Id_PY.TabStop = false;
            // 
            // Lbl_Estado_PY
            // 
            this.Lbl_Estado_PY.AutoSize = true;
            this.Lbl_Estado_PY.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Lbl_Estado_PY.Location = new System.Drawing.Point(27, 86);
            this.Lbl_Estado_PY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_Estado_PY.Name = "Lbl_Estado_PY";
            this.Lbl_Estado_PY.Size = new System.Drawing.Size(62, 20);
            this.Lbl_Estado_PY.TabIndex = 2;
            this.Lbl_Estado_PY.Text = "Estado";
            // 
            // Cbo_Estado_PY
            // 
            this.Cbo_Estado_PY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbo_Estado_PY.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Cbo_Estado_PY.FormattingEnabled = true;
            this.Cbo_Estado_PY.Location = new System.Drawing.Point(200, 82);
            this.Cbo_Estado_PY.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Cbo_Estado_PY.Name = "Cbo_Estado_PY";
            this.Cbo_Estado_PY.Size = new System.Drawing.Size(399, 28);
            this.Cbo_Estado_PY.TabIndex = 3;
            // 
            // Lbl_Nombre_PY
            // 
            this.Lbl_Nombre_PY.AutoSize = true;
            this.Lbl_Nombre_PY.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Lbl_Nombre_PY.Location = new System.Drawing.Point(27, 129);
            this.Lbl_Nombre_PY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_Nombre_PY.Name = "Lbl_Nombre_PY";
            this.Lbl_Nombre_PY.Size = new System.Drawing.Size(73, 20);
            this.Lbl_Nombre_PY.TabIndex = 4;
            this.Lbl_Nombre_PY.Text = "Nombre";
            // 
            // Txt_Nombre_PY
            // 
            this.Txt_Nombre_PY.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Txt_Nombre_PY.Location = new System.Drawing.Point(200, 126);
            this.Txt_Nombre_PY.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Txt_Nombre_PY.MaxLength = 100;
            this.Txt_Nombre_PY.Name = "Txt_Nombre_PY";
            this.Txt_Nombre_PY.Size = new System.Drawing.Size(399, 27);
            this.Txt_Nombre_PY.TabIndex = 5;
            // 
            // Lbl_Inicio_PY
            // 
            this.Lbl_Inicio_PY.AutoSize = true;
            this.Lbl_Inicio_PY.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Lbl_Inicio_PY.Location = new System.Drawing.Point(27, 172);
            this.Lbl_Inicio_PY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_Inicio_PY.Name = "Lbl_Inicio_PY";
            this.Lbl_Inicio_PY.Size = new System.Drawing.Size(104, 20);
            this.Lbl_Inicio_PY.TabIndex = 6;
            this.Lbl_Inicio_PY.Text = "Fecha inicio";
            // 
            // Dtp_Inicio_PY
            // 
            this.Dtp_Inicio_PY.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Dtp_Inicio_PY.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Dtp_Inicio_PY.Location = new System.Drawing.Point(200, 169);
            this.Dtp_Inicio_PY.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Dtp_Inicio_PY.Name = "Dtp_Inicio_PY";
            this.Dtp_Inicio_PY.ShowCheckBox = true;
            this.Dtp_Inicio_PY.Size = new System.Drawing.Size(239, 27);
            this.Dtp_Inicio_PY.TabIndex = 7;
            // 
            // Lbl_Fin_PY
            // 
            this.Lbl_Fin_PY.AutoSize = true;
            this.Lbl_Fin_PY.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Lbl_Fin_PY.Location = new System.Drawing.Point(27, 215);
            this.Lbl_Fin_PY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_Fin_PY.Name = "Lbl_Fin_PY";
            this.Lbl_Fin_PY.Size = new System.Drawing.Size(80, 20);
            this.Lbl_Fin_PY.TabIndex = 8;
            this.Lbl_Fin_PY.Text = "Fecha fin";
            // 
            // Dtp_Fin_PY
            // 
            this.Dtp_Fin_PY.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Dtp_Fin_PY.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Dtp_Fin_PY.Location = new System.Drawing.Point(200, 212);
            this.Dtp_Fin_PY.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Dtp_Fin_PY.Name = "Dtp_Fin_PY";
            this.Dtp_Fin_PY.ShowCheckBox = true;
            this.Dtp_Fin_PY.Size = new System.Drawing.Size(239, 27);
            this.Dtp_Fin_PY.TabIndex = 9;
            // 
            // Lbl_Descripcion_PY
            // 
            this.Lbl_Descripcion_PY.AutoSize = true;
            this.Lbl_Descripcion_PY.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Lbl_Descripcion_PY.Location = new System.Drawing.Point(653, 43);
            this.Lbl_Descripcion_PY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_Descripcion_PY.Name = "Lbl_Descripcion_PY";
            this.Lbl_Descripcion_PY.Size = new System.Drawing.Size(104, 20);
            this.Lbl_Descripcion_PY.TabIndex = 10;
            this.Lbl_Descripcion_PY.Text = "Descripción";
            // 
            // Txt_Descripcion_PY
            // 
            this.Txt_Descripcion_PY.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_Descripcion_PY.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Txt_Descripcion_PY.Location = new System.Drawing.Point(653, 71);
            this.Txt_Descripcion_PY.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Txt_Descripcion_PY.Multiline = true;
            this.Txt_Descripcion_PY.Name = "Txt_Descripcion_PY";
            this.Txt_Descripcion_PY.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Txt_Descripcion_PY.Size = new System.Drawing.Size(585, 91);
            this.Txt_Descripcion_PY.TabIndex = 11;
            // 
            // Lbl_Objetivo_PY
            // 
            this.Lbl_Objetivo_PY.AutoSize = true;
            this.Lbl_Objetivo_PY.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Lbl_Objetivo_PY.Location = new System.Drawing.Point(653, 172);
            this.Lbl_Objetivo_PY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_Objetivo_PY.Name = "Lbl_Objetivo_PY";
            this.Lbl_Objetivo_PY.Size = new System.Drawing.Size(77, 20);
            this.Lbl_Objetivo_PY.TabIndex = 12;
            this.Lbl_Objetivo_PY.Text = "Objetivo";
            // 
            // Txt_Objetivo_PY
            // 
            this.Txt_Objetivo_PY.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_Objetivo_PY.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Txt_Objetivo_PY.Location = new System.Drawing.Point(653, 201);
            this.Txt_Objetivo_PY.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Txt_Objetivo_PY.Multiline = true;
            this.Txt_Objetivo_PY.Name = "Txt_Objetivo_PY";
            this.Txt_Objetivo_PY.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Txt_Objetivo_PY.Size = new System.Drawing.Size(585, 91);
            this.Txt_Objetivo_PY.TabIndex = 13;
            // 
            // Pnl_Botones_PY
            // 
            this.Pnl_Botones_PY.Controls.Add(this.Btn_Guardar_PY);
            this.Pnl_Botones_PY.Controls.Add(this.Btn_Modificar_PY);
            this.Pnl_Botones_PY.Controls.Add(this.Btn_Eliminar_PY);
            this.Pnl_Botones_PY.Controls.Add(this.Btn_Limpiar_PY);
            this.Pnl_Botones_PY.Location = new System.Drawing.Point(27, 394);
            this.Pnl_Botones_PY.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Pnl_Botones_PY.Name = "Pnl_Botones_PY";
            this.Pnl_Botones_PY.Size = new System.Drawing.Size(1280, 62);
            this.Pnl_Botones_PY.TabIndex = 2;
            // 
            // Btn_Guardar_PY
            // 
            this.Btn_Guardar_PY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            this.Btn_Guardar_PY.FlatAppearance.BorderSize = 0;
            this.Btn_Guardar_PY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Guardar_PY.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Btn_Guardar_PY.ForeColor = System.Drawing.Color.White;
            this.Btn_Guardar_PY.Image = global::Capa_Vista_PY.Properties.Resources.Img_Guardar;
            this.Btn_Guardar_PY.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Guardar_PY.Location = new System.Drawing.Point(7, 7);
            this.Btn_Guardar_PY.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Btn_Guardar_PY.Name = "Btn_Guardar_PY";
            this.Btn_Guardar_PY.Padding = new System.Windows.Forms.Padding(11, 0, 11, 0);
            this.Btn_Guardar_PY.Size = new System.Drawing.Size(62, 47);
            this.Btn_Guardar_PY.TabIndex = 0;
            this.Btn_Guardar_PY.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btn_Guardar_PY.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Btn_Guardar_PY.UseVisualStyleBackColor = false;
            this.Btn_Guardar_PY.Click += new System.EventHandler(this.Btn_Guardar_PY_Click);
            // 
            // Btn_Modificar_PY
            // 
            this.Btn_Modificar_PY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            this.Btn_Modificar_PY.FlatAppearance.BorderSize = 0;
            this.Btn_Modificar_PY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Modificar_PY.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Btn_Modificar_PY.ForeColor = System.Drawing.Color.White;
            this.Btn_Modificar_PY.Image = global::Capa_Vista_PY.Properties.Resources.Img_Modificar;
            this.Btn_Modificar_PY.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Modificar_PY.Location = new System.Drawing.Point(77, 7);
            this.Btn_Modificar_PY.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Btn_Modificar_PY.Name = "Btn_Modificar_PY";
            this.Btn_Modificar_PY.Padding = new System.Windows.Forms.Padding(11, 0, 11, 0);
            this.Btn_Modificar_PY.Size = new System.Drawing.Size(62, 47);
            this.Btn_Modificar_PY.TabIndex = 1;
            this.Btn_Modificar_PY.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btn_Modificar_PY.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Btn_Modificar_PY.UseVisualStyleBackColor = false;
            this.Btn_Modificar_PY.Click += new System.EventHandler(this.Btn_Modificar_PY_Click);
            // 
            // Btn_Eliminar_PY
            // 
            this.Btn_Eliminar_PY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            this.Btn_Eliminar_PY.FlatAppearance.BorderSize = 0;
            this.Btn_Eliminar_PY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Eliminar_PY.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Btn_Eliminar_PY.ForeColor = System.Drawing.Color.White;
            this.Btn_Eliminar_PY.Image = global::Capa_Vista_PY.Properties.Resources.Img_Eliminar;
            this.Btn_Eliminar_PY.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Eliminar_PY.Location = new System.Drawing.Point(147, 7);
            this.Btn_Eliminar_PY.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Btn_Eliminar_PY.Name = "Btn_Eliminar_PY";
            this.Btn_Eliminar_PY.Padding = new System.Windows.Forms.Padding(11, 0, 11, 0);
            this.Btn_Eliminar_PY.Size = new System.Drawing.Size(62, 47);
            this.Btn_Eliminar_PY.TabIndex = 2;
            this.Btn_Eliminar_PY.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btn_Eliminar_PY.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Btn_Eliminar_PY.UseVisualStyleBackColor = false;
            this.Btn_Eliminar_PY.Click += new System.EventHandler(this.Btn_Eliminar_PY_Click);
            // 
            // Btn_Limpiar_PY
            // 
            this.Btn_Limpiar_PY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            this.Btn_Limpiar_PY.FlatAppearance.BorderSize = 0;
            this.Btn_Limpiar_PY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Limpiar_PY.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Btn_Limpiar_PY.ForeColor = System.Drawing.Color.White;
            this.Btn_Limpiar_PY.Image = global::Capa_Vista_PY.Properties.Resources.Img_Limpiar;
            this.Btn_Limpiar_PY.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Limpiar_PY.Location = new System.Drawing.Point(217, 7);
            this.Btn_Limpiar_PY.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Btn_Limpiar_PY.Name = "Btn_Limpiar_PY";
            this.Btn_Limpiar_PY.Padding = new System.Windows.Forms.Padding(11, 0, 11, 0);
            this.Btn_Limpiar_PY.Size = new System.Drawing.Size(62, 47);
            this.Btn_Limpiar_PY.TabIndex = 3;
            this.Btn_Limpiar_PY.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btn_Limpiar_PY.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Btn_Limpiar_PY.UseVisualStyleBackColor = false;
            this.Btn_Limpiar_PY.Click += new System.EventHandler(this.Btn_Limpiar_PY_Click);
            // 
            // Btn_Ayuda_PY
            // 
            this.Btn_Ayuda_PY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            this.Btn_Ayuda_PY.FlatAppearance.BorderSize = 0;
            this.Btn_Ayuda_PY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Ayuda_PY.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Btn_Ayuda_PY.ForeColor = System.Drawing.Color.White;
            this.Btn_Ayuda_PY.Image = global::Capa_Vista_PY.Properties.Resources.Img_Ayuda;
            this.Btn_Ayuda_PY.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Ayuda_PY.Location = new System.Drawing.Point(1245, 19);
            this.Btn_Ayuda_PY.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Btn_Ayuda_PY.Name = "Btn_Ayuda_PY";
            this.Btn_Ayuda_PY.Padding = new System.Windows.Forms.Padding(11, 0, 11, 0);
            this.Btn_Ayuda_PY.Size = new System.Drawing.Size(62, 47);
            this.Btn_Ayuda_PY.TabIndex = 4;
            this.Btn_Ayuda_PY.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btn_Ayuda_PY.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Btn_Ayuda_PY.UseVisualStyleBackColor = false;
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
            this.Dgv_PY.Location = new System.Drawing.Point(27, 468);
            this.Dgv_PY.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Dgv_PY.MultiSelect = false;
            this.Dgv_PY.Name = "Dgv_PY";
            this.Dgv_PY.ReadOnly = true;
            this.Dgv_PY.RowHeadersVisible = false;
            this.Dgv_PY.RowHeadersWidth = 51;
            this.Dgv_PY.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv_PY.Size = new System.Drawing.Size(1280, 271);
            this.Dgv_PY.TabIndex = 3;
            this.Dgv_PY.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_PY_CellClick);
            // 
            // Frm_PY
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(177)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1333, 763);
            this.Controls.Add(this.Dgv_PY);
            this.Controls.Add(this.Pnl_Botones_PY);
            this.Controls.Add(this.Gpb_Datos_PY);
            this.Controls.Add(this.Lbl_Titulo_PY);
            this.Controls.Add(this.Btn_Ayuda_PY);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(1349, 800);
            this.Name = "Frm_PY";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Proyectos";
            this.Load += new System.EventHandler(this.Frm_PY_Load);
            this.Gpb_Datos_PY.ResumeLayout(false);
            this.Gpb_Datos_PY.PerformLayout();
            this.Pnl_Botones_PY.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_PY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbl_Titulo_PY;
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
        private System.Windows.Forms.Panel Pnl_Botones_PY;
        private System.Windows.Forms.Button Btn_Guardar_PY;
        private System.Windows.Forms.Button Btn_Modificar_PY;
        private System.Windows.Forms.Button Btn_Eliminar_PY;
        private System.Windows.Forms.Button Btn_Limpiar_PY;
        private System.Windows.Forms.Button Btn_Ayuda_PY;
        private System.Windows.Forms.DataGridView Dgv_PY;
    }
}
//Fin de código de Paula Daniela Leonardo Paredes carné 0901-22-9580 en la fecha de: "20/10/2026"
