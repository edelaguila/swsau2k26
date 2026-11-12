
namespace Capavista_pauditado
{
    partial class Frm_pauditado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_pauditado));
            this.lbl_proyecto = new System.Windows.Forms.Label();
            this.lbl_auditado = new System.Windows.Forms.Label();
            this.lbl_fecha = new System.Windows.Forms.Label();
            this.cmb_proyecto = new System.Windows.Forms.ComboBox();
            this.cmb_auditado = new System.Windows.Forms.ComboBox();
            this.dtp_fecha = new System.Windows.Forms.DateTimePicker();
            this.dgv_pauditado = new System.Windows.Forms.DataGridView();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.btn_modificar = new System.Windows.Forms.Button();
            this.btn_salir = new System.Windows.Forms.Button();
            this.btn_reporte = new System.Windows.Forms.Button();
            this.btn_ayuda = new System.Windows.Forms.Button();
            this.Gpb_Datos = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_pauditado)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_proyecto
            // 
            this.lbl_proyecto.AutoSize = true;
            this.lbl_proyecto.Font = new System.Drawing.Font("Rockwell", 10F);
            this.lbl_proyecto.Location = new System.Drawing.Point(20, 39);
            this.lbl_proyecto.Name = "lbl_proyecto";
            this.lbl_proyecto.TabIndex = 1;
            this.lbl_proyecto.Text = "Proyecto:";
            // 
            // lbl_auditado
            // 
            this.lbl_auditado.AutoSize = true;
            this.lbl_auditado.Font = new System.Drawing.Font("Rockwell", 10F);
            this.lbl_auditado.Location = new System.Drawing.Point(20, 79);
            this.lbl_auditado.Name = "lbl_auditado";
            this.lbl_auditado.TabIndex = 2;
            this.lbl_auditado.Text = "Auditado:";
            // 
            // lbl_fecha
            // 
            this.lbl_fecha.AutoSize = true;
            this.lbl_fecha.Font = new System.Drawing.Font("Rockwell", 10F);
            this.lbl_fecha.Location = new System.Drawing.Point(490, 39);
            this.lbl_fecha.Name = "lbl_fecha";
            this.lbl_fecha.TabIndex = 3;
            this.lbl_fecha.Text = "Fecha:";
            // 
            // cmb_proyecto
            // 
            this.cmb_proyecto.FormattingEnabled = true;
            this.cmb_proyecto.Location = new System.Drawing.Point(140, 35);
            this.cmb_proyecto.Name = "cmb_proyecto";
            this.cmb_proyecto.Size = new System.Drawing.Size(300, 28);
            this.cmb_proyecto.TabIndex = 4;
            this.cmb_proyecto.Font = new System.Drawing.Font("Rockwell", 10F);
            this.cmb_proyecto.SelectedIndexChanged += new System.EventHandler(this.cmb_proyecto_SelectedIndexChanged);
            // 
            // cmb_auditado
            // 
            this.cmb_auditado.FormattingEnabled = true;
            this.cmb_auditado.Location = new System.Drawing.Point(140, 75);
            this.cmb_auditado.Name = "cmb_auditado";
            this.cmb_auditado.Size = new System.Drawing.Size(300, 28);
            this.cmb_auditado.TabIndex = 5;
            this.cmb_auditado.Font = new System.Drawing.Font("Rockwell", 10F);
            this.cmb_auditado.SelectedIndexChanged += new System.EventHandler(this.cmb_auditado_SelectedIndexChanged);
            // 
            // dtp_fecha
            // 
            this.dtp_fecha.Location = new System.Drawing.Point(600, 35);
            this.dtp_fecha.Name = "dtp_fecha";
            this.dtp_fecha.Size = new System.Drawing.Size(250, 27);
            this.dtp_fecha.TabIndex = 6;
            this.dtp_fecha.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // dgv_pauditado
            // 
            this.dgv_pauditado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_pauditado.Location = new System.Drawing.Point(13, 263);
            this.dgv_pauditado.Name = "dgv_pauditado";
            this.dgv_pauditado.Size = new System.Drawing.Size(964, 280);
            this.dgv_pauditado.TabIndex = 7;
            this.dgv_pauditado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_pauditado.BackgroundColor = System.Drawing.Color.White;
            this.dgv_pauditado.RowHeadersVisible = false;
            this.dgv_pauditado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_pauditado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_pauditado_CellContentClick);
            // 
            // btn_guardar
            // 
            this.btn_guardar.Image = ((System.Drawing.Image)(resources.GetObject("btn_guardar.Image")));
            this.btn_guardar.Location = new System.Drawing.Point(121, 15);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(97, 93);
            this.btn_guardar.TabIndex = 8;
            this.btn_guardar.UseVisualStyleBackColor = true;
            this.btn_guardar.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.btn_guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_guardar.Text = "Guardar";
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.Image = ((System.Drawing.Image)(resources.GetObject("btn_eliminar.Image")));
            this.btn_eliminar.Location = new System.Drawing.Point(229, 15);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(97, 93);
            this.btn_eliminar.TabIndex = 10;
            this.btn_eliminar.UseVisualStyleBackColor = true;
            this.btn_eliminar.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.btn_eliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_eliminar.Text = "Eliminar";
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // btn_modificar
            // 
            this.btn_modificar.Image = ((System.Drawing.Image)(resources.GetObject("btn_modificar.Image")));
            this.btn_modificar.Location = new System.Drawing.Point(13, 15);
            this.btn_modificar.Name = "btn_modificar";
            this.btn_modificar.Size = new System.Drawing.Size(97, 93);
            this.btn_modificar.TabIndex = 11;
            this.btn_modificar.UseVisualStyleBackColor = true;
            this.btn_modificar.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.btn_modificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_modificar.Text = "Modificar";
            this.btn_modificar.Click += new System.EventHandler(this.btn_modificar_Click_1);
            // 
            // btn_salir
            // 
            this.btn_salir.Image = ((System.Drawing.Image)(resources.GetObject("btn_salir.Image")));
            this.btn_salir.Location = new System.Drawing.Point(553, 15);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(97, 93);
            this.btn_salir.TabIndex = 12;
            this.btn_salir.UseVisualStyleBackColor = true;
            this.btn_salir.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.btn_salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_salir.Text = "Salir";
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // btn_reporte
            // 
            this.btn_reporte.Image = ((System.Drawing.Image)(resources.GetObject("btn_reporte.Image")));
            this.btn_reporte.Location = new System.Drawing.Point(337, 15);
            this.btn_reporte.Name = "btn_reporte";
            this.btn_reporte.Size = new System.Drawing.Size(97, 93);
            this.btn_reporte.TabIndex = 13;
            this.btn_reporte.UseVisualStyleBackColor = true;
            this.btn_reporte.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.btn_reporte.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_reporte.Text = "Imprimir";
            this.btn_reporte.Click += new System.EventHandler(this.btn_nuevo_Click_1);
            // 
            // btn_ayuda
            // 
            this.btn_ayuda.Image = ((System.Drawing.Image)(resources.GetObject("btn_ayuda.Image")));
            this.btn_ayuda.Location = new System.Drawing.Point(445, 15);
            this.btn_ayuda.Name = "btn_ayuda";
            this.btn_ayuda.Size = new System.Drawing.Size(97, 93);
            this.btn_ayuda.TabIndex = 14;
            this.btn_ayuda.UseVisualStyleBackColor = true;
            this.btn_ayuda.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.btn_ayuda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_ayuda.Text = "Ayuda";
            // 
            // Frm_pauditado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(990, 558);
            this.Controls.Add(this.btn_modificar);
            this.Controls.Add(this.btn_guardar);
            this.Controls.Add(this.btn_eliminar);
            this.Controls.Add(this.btn_reporte);
            this.Controls.Add(this.btn_ayuda);
            this.Controls.Add(this.btn_salir);
            // 
            // Gpb_Datos
            // 
            this.Gpb_Datos.Location = new System.Drawing.Point(13, 123);
            this.Gpb_Datos.Size = new System.Drawing.Size(964, 125);
            this.Gpb_Datos.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Gpb_Datos.TabStop = false;
            this.Gpb_Datos.Text = "Datos del proyecto auditado";
            this.Gpb_Datos.Name = "Gpb_Datos";
            this.Controls.Add(this.Gpb_Datos);
            this.Gpb_Datos.Controls.Add(this.lbl_proyecto);
            this.Gpb_Datos.Controls.Add(this.cmb_proyecto);
            this.Gpb_Datos.Controls.Add(this.lbl_auditado);
            this.Gpb_Datos.Controls.Add(this.cmb_auditado);
            this.Gpb_Datos.Controls.Add(this.lbl_fecha);
            this.Gpb_Datos.Controls.Add(this.dtp_fecha);
            this.Controls.Add(this.dgv_pauditado);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "Frm_pauditado";
            this.Text = "Proyecto Auditado";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_pauditado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lbl_proyecto;
        private System.Windows.Forms.Label lbl_auditado;
        private System.Windows.Forms.Label lbl_fecha;
        private System.Windows.Forms.ComboBox cmb_proyecto;
        private System.Windows.Forms.ComboBox cmb_auditado;
        private System.Windows.Forms.DateTimePicker dtp_fecha;
        private System.Windows.Forms.DataGridView dgv_pauditado;
        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.Button btn_eliminar;
        private System.Windows.Forms.Button btn_modificar;
        private System.Windows.Forms.Button btn_salir;
        private System.Windows.Forms.Button btn_reporte;
        private System.Windows.Forms.Button btn_ayuda;
        private System.Windows.Forms.GroupBox Gpb_Datos;
    }
}