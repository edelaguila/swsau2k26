
namespace Capa_Vista_ProAuditor
{
    partial class Frm_ProyectoAuditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ProyectoAuditor));
            this.Lbl_Proyecto = new System.Windows.Forms.Label();
            this.Cbo_Proyecto = new System.Windows.Forms.ComboBox();
            this.Lbl_Auditor = new System.Windows.Forms.Label();
            this.Cbo_Auditor = new System.Windows.Forms.ComboBox();
            this.Lbl_Perfil = new System.Windows.Forms.Label();
            this.Cbo_Perfil = new System.Windows.Forms.ComboBox();
            this.Lbl_Fecha = new System.Windows.Forms.Label();
            this.Dtp_Fecha = new System.Windows.Forms.DateTimePicker();
            this.Btn_Nuevo = new System.Windows.Forms.Button();
            this.Btn_Guardar = new System.Windows.Forms.Button();
            this.Btn_Modificar = new System.Windows.Forms.Button();
            this.Btn_Eliminar = new System.Windows.Forms.Button();
            this.Btn_Cancelar = new System.Windows.Forms.Button();
            this.Lbl_Buscar = new System.Windows.Forms.Label();
            this.Txt_Buscar = new System.Windows.Forms.TextBox();
            this.Btn_Buscar = new System.Windows.Forms.Button();
            this.Dgv_ProyectoAuditor = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.Cbo_CodApl = new System.Windows.Forms.ComboBox();
            this.btn_Reporte = new System.Windows.Forms.Button();
            this.Btn_Salir = new System.Windows.Forms.Button();
            this.Gpb_Datos = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_ProyectoAuditor)).BeginInit();
            this.SuspendLayout();
            // 
            // Lbl_Proyecto
            // 
            this.Lbl_Proyecto.AutoSize = true;
            this.Lbl_Proyecto.Location = new System.Drawing.Point(20, 39);
            this.Lbl_Proyecto.Name = "Lbl_Proyecto";
            this.Lbl_Proyecto.TabIndex = 4;
            this.Lbl_Proyecto.Text = "Proyecto:";
            this.Lbl_Proyecto.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // Cbo_Proyecto
            // 
            this.Cbo_Proyecto.FormattingEnabled = true;
            this.Cbo_Proyecto.Location = new System.Drawing.Point(170, 35);
            this.Cbo_Proyecto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Cbo_Proyecto.Name = "Cbo_Proyecto";
            this.Cbo_Proyecto.Size = new System.Drawing.Size(300, 28);
            this.Cbo_Proyecto.TabIndex = 5;
            this.Cbo_Proyecto.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // Lbl_Auditor
            // 
            this.Lbl_Auditor.AutoSize = true;
            this.Lbl_Auditor.Location = new System.Drawing.Point(20, 79);
            this.Lbl_Auditor.Name = "Lbl_Auditor";
            this.Lbl_Auditor.TabIndex = 6;
            this.Lbl_Auditor.Text = "Auditor:";
            this.Lbl_Auditor.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // Cbo_Auditor
            // 
            this.Cbo_Auditor.FormattingEnabled = true;
            this.Cbo_Auditor.Location = new System.Drawing.Point(170, 75);
            this.Cbo_Auditor.Margin = new System.Windows.Forms.Padding(4);
            this.Cbo_Auditor.Name = "Cbo_Auditor";
            this.Cbo_Auditor.Size = new System.Drawing.Size(300, 28);
            this.Cbo_Auditor.TabIndex = 7;
            this.Cbo_Auditor.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Cbo_Auditor.SelectedIndexChanged += new System.EventHandler(this.Cbo_Auditor_SelectedIndexChanged);
            // 
            // Lbl_Perfil
            // 
            this.Lbl_Perfil.AutoSize = true;
            this.Lbl_Perfil.Location = new System.Drawing.Point(20, 119);
            this.Lbl_Perfil.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_Perfil.Name = "Lbl_Perfil";
            this.Lbl_Perfil.TabIndex = 8;
            this.Lbl_Perfil.Text = "Perfil:";
            this.Lbl_Perfil.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // Cbo_Perfil
            // 
            this.Cbo_Perfil.FormattingEnabled = true;
            this.Cbo_Perfil.Location = new System.Drawing.Point(170, 115);
            this.Cbo_Perfil.Margin = new System.Windows.Forms.Padding(4);
            this.Cbo_Perfil.Name = "Cbo_Perfil";
            this.Cbo_Perfil.Size = new System.Drawing.Size(300, 28);
            this.Cbo_Perfil.TabIndex = 9;
            this.Cbo_Perfil.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // Lbl_Fecha
            // 
            this.Lbl_Fecha.AutoSize = true;
            this.Lbl_Fecha.Location = new System.Drawing.Point(500, 39);
            this.Lbl_Fecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_Fecha.Name = "Lbl_Fecha";
            this.Lbl_Fecha.TabIndex = 10;
            this.Lbl_Fecha.Text = "Fecha:";
            this.Lbl_Fecha.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // Dtp_Fecha
            // 
            this.Dtp_Fecha.Location = new System.Drawing.Point(680, 35);
            this.Dtp_Fecha.Margin = new System.Windows.Forms.Padding(4);
            this.Dtp_Fecha.Name = "Dtp_Fecha";
            this.Dtp_Fecha.Size = new System.Drawing.Size(200, 27);
            this.Dtp_Fecha.TabIndex = 11;
            this.Dtp_Fecha.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // Btn_Nuevo
            // 
            this.Btn_Nuevo.Location = new System.Drawing.Point(13, 15);
            this.Btn_Nuevo.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_Nuevo.Name = "Btn_Nuevo";
            this.Btn_Nuevo.Size = new System.Drawing.Size(97, 93);
            this.Btn_Nuevo.TabIndex = 12;
            this.Btn_Nuevo.Text = "Ingresar";
            this.Btn_Nuevo.UseVisualStyleBackColor = true;
            this.Btn_Nuevo.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.Btn_Nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Nuevo.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Nuevo.Image")));
            this.Btn_Nuevo.Click += new System.EventHandler(this.Btn_Nuevo_Click_1);
            // 
            // Btn_Guardar
            // 
            this.Btn_Guardar.Location = new System.Drawing.Point(229, 15);
            this.Btn_Guardar.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_Guardar.Name = "Btn_Guardar";
            this.Btn_Guardar.Size = new System.Drawing.Size(97, 93);
            this.Btn_Guardar.TabIndex = 13;
            this.Btn_Guardar.Text = "Guardar";
            this.Btn_Guardar.UseVisualStyleBackColor = true;
            this.Btn_Guardar.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.Btn_Guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Guardar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Guardar.Image")));
            // 
            // Btn_Modificar
            // 
            this.Btn_Modificar.Location = new System.Drawing.Point(121, 15);
            this.Btn_Modificar.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_Modificar.Name = "Btn_Modificar";
            this.Btn_Modificar.Size = new System.Drawing.Size(97, 93);
            this.Btn_Modificar.TabIndex = 14;
            this.Btn_Modificar.Text = "Modificar";
            this.Btn_Modificar.UseVisualStyleBackColor = true;
            this.Btn_Modificar.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.Btn_Modificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Modificar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Modificar.Image")));
            // 
            // Btn_Eliminar
            // 
            this.Btn_Eliminar.Location = new System.Drawing.Point(445, 15);
            this.Btn_Eliminar.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_Eliminar.Name = "Btn_Eliminar";
            this.Btn_Eliminar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Btn_Eliminar.Size = new System.Drawing.Size(97, 93);
            this.Btn_Eliminar.TabIndex = 15;
            this.Btn_Eliminar.Text = "Eliminar";
            this.Btn_Eliminar.UseVisualStyleBackColor = true;
            this.Btn_Eliminar.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.Btn_Eliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Eliminar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Eliminar.Image")));
            // 
            // Btn_Cancelar
            // 
            this.Btn_Cancelar.Location = new System.Drawing.Point(337, 15);
            this.Btn_Cancelar.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_Cancelar.Name = "Btn_Cancelar";
            this.Btn_Cancelar.Size = new System.Drawing.Size(97, 93);
            this.Btn_Cancelar.TabIndex = 16;
            this.Btn_Cancelar.Text = "Cancelar";
            this.Btn_Cancelar.UseVisualStyleBackColor = true;
            this.Btn_Cancelar.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.Btn_Cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Cancelar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Cancelar.Image")));
            // 
            // Lbl_Buscar
            // 
            this.Lbl_Buscar.AutoSize = true;
            this.Lbl_Buscar.Location = new System.Drawing.Point(13, 304);
            this.Lbl_Buscar.Name = "Lbl_Buscar";
            this.Lbl_Buscar.TabIndex = 18;
            this.Lbl_Buscar.Text = "Buscar:";
            this.Lbl_Buscar.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // Txt_Buscar
            // 
            this.Txt_Buscar.Location = new System.Drawing.Point(90, 300);
            this.Txt_Buscar.Margin = new System.Windows.Forms.Padding(4);
            this.Txt_Buscar.Name = "Txt_Buscar";
            this.Txt_Buscar.Size = new System.Drawing.Size(500, 27);
            this.Txt_Buscar.TabIndex = 19;
            this.Txt_Buscar.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // Btn_Buscar
            // 
            this.Btn_Buscar.Location = new System.Drawing.Point(600, 298);
            this.Btn_Buscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_Buscar.Name = "Btn_Buscar";
            this.Btn_Buscar.Size = new System.Drawing.Size(110, 31);
            this.Btn_Buscar.TabIndex = 20;
            this.Btn_Buscar.Text = "Buscar";
            this.Btn_Buscar.UseVisualStyleBackColor = true;
            this.Btn_Buscar.Font = new System.Drawing.Font("Rockwell", 9.75F);
            // 
            // Dgv_ProyectoAuditor
            // 
            this.Dgv_ProyectoAuditor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_ProyectoAuditor.Location = new System.Drawing.Point(13, 340);
            this.Dgv_ProyectoAuditor.Margin = new System.Windows.Forms.Padding(4);
            this.Dgv_ProyectoAuditor.Name = "Dgv_ProyectoAuditor";
            this.Dgv_ProyectoAuditor.RowHeadersWidth = 51;
            this.Dgv_ProyectoAuditor.RowTemplate.Height = 24;
            this.Dgv_ProyectoAuditor.Size = new System.Drawing.Size(964, 260);
            this.Dgv_ProyectoAuditor.TabIndex = 21;
            this.Dgv_ProyectoAuditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Dgv_ProyectoAuditor.BackgroundColor = System.Drawing.Color.White;
            this.Dgv_ProyectoAuditor.RowHeadersVisible = false;
            this.Dgv_ProyectoAuditor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(500, 79);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.TabIndex = 22;
            this.label1.Text = "Código aplicación:";
            this.label1.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // Cbo_CodApl
            // 
            this.Cbo_CodApl.FormattingEnabled = true;
            this.Cbo_CodApl.Location = new System.Drawing.Point(680, 75);
            this.Cbo_CodApl.Margin = new System.Windows.Forms.Padding(4);
            this.Cbo_CodApl.Name = "Cbo_CodApl";
            this.Cbo_CodApl.Size = new System.Drawing.Size(264, 28);
            this.Cbo_CodApl.TabIndex = 23;
            this.Cbo_CodApl.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // btn_Reporte
            // 
            this.btn_Reporte.Location = new System.Drawing.Point(553, 15);
            this.btn_Reporte.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Reporte.Name = "btn_Reporte";
            this.btn_Reporte.Size = new System.Drawing.Size(97, 93);
            this.btn_Reporte.TabIndex = 24;
            this.btn_Reporte.Text = "Imprimir";
            this.btn_Reporte.UseVisualStyleBackColor = true;
            this.btn_Reporte.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.btn_Reporte.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Reporte.Image = ((System.Drawing.Image)(resources.GetObject("btn_Reporte.Image")));
            this.btn_Reporte.Click += new System.EventHandler(this.btn_Reporte_Click);
            // 
            // Frm_ProyectoAuditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 615);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.Text = "Salir";
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Location = new System.Drawing.Point(661, 15);
            this.Btn_Salir.Size = new System.Drawing.Size(97, 93);
            this.Btn_Salir.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Salir.UseVisualStyleBackColor = true;
            this.Btn_Salir.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Salir.Image")));
            this.Btn_Salir.Click += new System.EventHandler(this.Btn_Salir_Click);
            this.Controls.Add(this.Btn_Salir);
            this.Controls.Add(this.Btn_Nuevo);
            this.Controls.Add(this.Btn_Modificar);
            this.Controls.Add(this.Btn_Guardar);
            this.Controls.Add(this.Btn_Cancelar);
            this.Controls.Add(this.Btn_Eliminar);
            this.Controls.Add(this.btn_Reporte);
            // 
            // Gpb_Datos
            // 
            this.Gpb_Datos.Location = new System.Drawing.Point(13, 123);
            this.Gpb_Datos.Size = new System.Drawing.Size(964, 165);
            this.Gpb_Datos.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Gpb_Datos.TabStop = false;
            this.Gpb_Datos.Text = "Datos del proyecto auditor";
            this.Gpb_Datos.Name = "Gpb_Datos";
            this.Controls.Add(this.Gpb_Datos);
            this.Gpb_Datos.Controls.Add(this.Lbl_Proyecto);
            this.Gpb_Datos.Controls.Add(this.Cbo_Proyecto);
            this.Gpb_Datos.Controls.Add(this.Lbl_Auditor);
            this.Gpb_Datos.Controls.Add(this.Cbo_Auditor);
            this.Gpb_Datos.Controls.Add(this.Lbl_Perfil);
            this.Gpb_Datos.Controls.Add(this.Cbo_Perfil);
            this.Gpb_Datos.Controls.Add(this.Lbl_Fecha);
            this.Gpb_Datos.Controls.Add(this.Dtp_Fecha);
            this.Gpb_Datos.Controls.Add(this.label1);
            this.Gpb_Datos.Controls.Add(this.Cbo_CodApl);
            this.Controls.Add(this.Lbl_Buscar);
            this.Controls.Add(this.Txt_Buscar);
            this.Controls.Add(this.Btn_Buscar);
            this.Controls.Add(this.Dgv_ProyectoAuditor);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "Frm_ProyectoAuditor";
            this.Text = "Proyecto Auditor";
            this.Load += new System.EventHandler(this.Frm_ProyectoAuditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_ProyectoAuditor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label Lbl_Proyecto;
        private System.Windows.Forms.ComboBox Cbo_Proyecto;
        private System.Windows.Forms.Label Lbl_Auditor;
        private System.Windows.Forms.ComboBox Cbo_Auditor;
        private System.Windows.Forms.Label Lbl_Perfil;
        private System.Windows.Forms.ComboBox Cbo_Perfil;
        private System.Windows.Forms.Label Lbl_Fecha;
        private System.Windows.Forms.DateTimePicker Dtp_Fecha;
        private System.Windows.Forms.Button Btn_Nuevo;
        private System.Windows.Forms.Button Btn_Guardar;
        private System.Windows.Forms.Button Btn_Modificar;
        private System.Windows.Forms.Button Btn_Eliminar;
        private System.Windows.Forms.Button Btn_Cancelar;
        private System.Windows.Forms.Label Lbl_Buscar;
        private System.Windows.Forms.TextBox Txt_Buscar;
        private System.Windows.Forms.Button Btn_Buscar;
        private System.Windows.Forms.DataGridView Dgv_ProyectoAuditor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Cbo_CodApl;
        private System.Windows.Forms.Button btn_Reporte;
        private System.Windows.Forms.Button Btn_Salir;
        private System.Windows.Forms.GroupBox Gpb_Datos;
    }
}