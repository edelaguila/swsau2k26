namespace Capa_Vista_Areas
{
    partial class Frm_Areas
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Areas));
            this.txt_idArea = new System.Windows.Forms.TextBox();
            this.txt_nombreArea = new System.Windows.Forms.TextBox();
            this.txt_descripcion = new System.Windows.Forms.TextBox();
            this.cbo_proyecto = new System.Windows.Forms.ComboBox();
            this.rdb_activo = new System.Windows.Forms.RadioButton();
            this.rdb_inactivo = new System.Windows.Forms.RadioButton();
            this.dgv_areas = new System.Windows.Forms.DataGridView();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.btn_modificar = new System.Windows.Forms.Button();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.btn_limpiar = new System.Windows.Forms.Button();
            this.btn_salir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gpb = new System.Windows.Forms.GroupBox();
            this.Gpb_Datos = new System.Windows.Forms.GroupBox();
            this.Btn_Imprimir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_areas)).BeginInit();
            this.gpb.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_idArea
            // 
            this.txt_idArea.Location = new System.Drawing.Point(160, 35);
            this.txt_idArea.Name = "txt_idArea";
            this.txt_idArea.Size = new System.Drawing.Size(120, 27);
            this.txt_idArea.TabIndex = 0;
            this.txt_idArea.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // txt_nombreArea
            // 
            this.txt_nombreArea.Location = new System.Drawing.Point(160, 75);
            this.txt_nombreArea.Name = "txt_nombreArea";
            this.txt_nombreArea.Size = new System.Drawing.Size(300, 27);
            this.txt_nombreArea.TabIndex = 1;
            this.txt_nombreArea.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // txt_descripcion
            // 
            this.txt_descripcion.Location = new System.Drawing.Point(160, 150);
            this.txt_descripcion.Multiline = true;
            this.txt_descripcion.Name = "txt_descripcion";
            this.txt_descripcion.Size = new System.Drawing.Size(784, 60);
            this.txt_descripcion.TabIndex = 2;
            this.txt_descripcion.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // cbo_proyecto
            // 
            this.cbo_proyecto.FormattingEnabled = true;
            this.cbo_proyecto.Location = new System.Drawing.Point(620, 35);
            this.cbo_proyecto.Name = "cbo_proyecto";
            this.cbo_proyecto.Size = new System.Drawing.Size(324, 28);
            this.cbo_proyecto.TabIndex = 3;
            this.cbo_proyecto.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // rdb_activo
            // 
            this.rdb_activo.AutoSize = true;
            this.rdb_activo.Font = new System.Drawing.Font("Rockwell", 10F);
            this.rdb_activo.Location = new System.Drawing.Point(20, 24);
            this.rdb_activo.Name = "rdb_activo";
            this.rdb_activo.Size = new System.Drawing.Size(92, 21);
            this.rdb_activo.TabIndex = 6;
            this.rdb_activo.TabStop = true;
            this.rdb_activo.Text = "Habilitado";
            this.rdb_activo.UseVisualStyleBackColor = true;
            // 
            // rdb_inactivo
            // 
            this.rdb_inactivo.AutoSize = true;
            this.rdb_inactivo.Font = new System.Drawing.Font("Rockwell", 10F);
            this.rdb_inactivo.Location = new System.Drawing.Point(200, 24);
            this.rdb_inactivo.Name = "rdb_inactivo";
            this.rdb_inactivo.Size = new System.Drawing.Size(114, 21);
            this.rdb_inactivo.TabIndex = 7;
            this.rdb_inactivo.TabStop = true;
            this.rdb_inactivo.Text = "Deshabilitado";
            this.rdb_inactivo.UseVisualStyleBackColor = true;
            // 
            // dgv_areas
            // 
            this.dgv_areas.BackgroundColor = System.Drawing.Color.White;
            this.dgv_areas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_areas.Location = new System.Drawing.Point(13, 363);
            this.dgv_areas.Name = "dgv_areas";
            this.dgv_areas.ReadOnly = true;
            this.dgv_areas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_areas.Size = new System.Drawing.Size(964, 260);
            this.dgv_areas.TabIndex = 13;
            this.dgv_areas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_areas.RowHeadersVisible = false;
            this.dgv_areas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_areas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_areas_CellClick);
            // 
            // btn_guardar
            // 
            this.btn_guardar.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.btn_guardar.Location = new System.Drawing.Point(121, 15);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(97, 93);
            this.btn_guardar.TabIndex = 8;
            this.btn_guardar.Text = "Guardar";
            this.btn_guardar.UseVisualStyleBackColor = true;
            this.btn_guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_guardar.Image = ((System.Drawing.Image)(resources.GetObject("btn_guardar.Image")));
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // btn_modificar
            // 
            this.btn_modificar.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.btn_modificar.Location = new System.Drawing.Point(13, 15);
            this.btn_modificar.Name = "btn_modificar";
            this.btn_modificar.Size = new System.Drawing.Size(97, 93);
            this.btn_modificar.TabIndex = 9;
            this.btn_modificar.Text = "Modificar";
            this.btn_modificar.UseVisualStyleBackColor = true;
            this.btn_modificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_modificar.Image = ((System.Drawing.Image)(resources.GetObject("btn_modificar.Image")));
            this.btn_modificar.Click += new System.EventHandler(this.btn_modificar_Click);
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.btn_eliminar.Location = new System.Drawing.Point(337, 15);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(97, 93);
            this.btn_eliminar.TabIndex = 10;
            this.btn_eliminar.Text = "Eliminar";
            this.btn_eliminar.UseVisualStyleBackColor = true;
            this.btn_eliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_eliminar.Image = ((System.Drawing.Image)(resources.GetObject("btn_eliminar.Image")));
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // btn_limpiar
            // 
            this.btn_limpiar.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.btn_limpiar.Location = new System.Drawing.Point(229, 15);
            this.btn_limpiar.Name = "btn_limpiar";
            this.btn_limpiar.Size = new System.Drawing.Size(97, 93);
            this.btn_limpiar.TabIndex = 11;
            this.btn_limpiar.Text = "Cancelar";
            this.btn_limpiar.UseVisualStyleBackColor = true;
            this.btn_limpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_limpiar.Image = ((System.Drawing.Image)(resources.GetObject("btn_limpiar.Image")));
            this.btn_limpiar.Click += new System.EventHandler(this.btn_limpiar_Click);
            // 
            // btn_salir
            // 
            this.btn_salir.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.btn_salir.Location = new System.Drawing.Point(553, 15);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(97, 93);
            this.btn_salir.TabIndex = 12;
            this.btn_salir.Text = "Salir";
            this.btn_salir.UseVisualStyleBackColor = true;
            this.btn_salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_salir.Image = ((System.Drawing.Image)(resources.GetObject("btn_salir.Image")));
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Rockwell", 10F);
            this.label1.Location = new System.Drawing.Point(20, 39);
            this.label1.Name = "label1";
            this.label1.TabIndex = 13;
            this.label1.Text = "ID área:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Rockwell", 10F);
            this.label2.Location = new System.Drawing.Point(490, 39);
            this.label2.Name = "label2";
            this.label2.TabIndex = 14;
            this.label2.Text = "ID proyecto:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Rockwell", 10F);
            this.label3.Location = new System.Drawing.Point(20, 79);
            this.label3.Name = "label3";
            this.label3.TabIndex = 15;
            this.label3.Text = "Nombre área:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Rockwell", 10F);
            this.label4.Location = new System.Drawing.Point(20, 154);
            this.label4.Name = "label4";
            this.label4.TabIndex = 16;
            this.label4.Text = "Descripción:";
            // 
            // gpb
            // 
            this.gpb.Font = new System.Drawing.Font("Rockwell", 10F);
            this.gpb.Location = new System.Drawing.Point(490, 67);
            this.gpb.Name = "gpb";
            this.gpb.Size = new System.Drawing.Size(454, 58);
            this.gpb.TabIndex = 5;
            this.gpb.TabStop = false;
            this.gpb.Text = "Estado";
            // 
            // Frm_Areas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(177)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(990, 638);
            this.Controls.Add(this.btn_modificar);
            this.Controls.Add(this.btn_guardar);
            this.Controls.Add(this.btn_limpiar);
            this.Controls.Add(this.btn_eliminar);
            this.Controls.Add(this.btn_salir);
            // 
            // Gpb_Datos
            // 
            this.Gpb_Datos.Location = new System.Drawing.Point(13, 123);
            this.Gpb_Datos.Size = new System.Drawing.Size(964, 225);
            this.Gpb_Datos.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Gpb_Datos.TabStop = false;
            this.Gpb_Datos.Text = "Datos del área";
            this.Gpb_Datos.Name = "Gpb_Datos";
            this.Controls.Add(this.Gpb_Datos);
            this.Gpb_Datos.Controls.Add(this.label1);
            this.Gpb_Datos.Controls.Add(this.txt_idArea);
            this.Gpb_Datos.Controls.Add(this.label3);
            this.Gpb_Datos.Controls.Add(this.txt_nombreArea);
            this.Gpb_Datos.Controls.Add(this.label2);
            this.Gpb_Datos.Controls.Add(this.cbo_proyecto);
            this.Gpb_Datos.Controls.Add(this.gpb);
            this.gpb.Controls.Add(this.rdb_activo);
            this.gpb.Controls.Add(this.rdb_inactivo);
            this.Gpb_Datos.Controls.Add(this.label4);
            this.Gpb_Datos.Controls.Add(this.txt_descripcion);
            this.Controls.Add(this.dgv_areas);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
            this.Name = "Frm_Areas";
            this.Text = "Áreas";
            this.Load += new System.EventHandler(this.Frm_Areas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_areas)).EndInit();
            this.gpb.ResumeLayout(false);
            this.gpb.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txt_idArea;
        private System.Windows.Forms.TextBox txt_nombreArea;
        private System.Windows.Forms.TextBox txt_descripcion;
        private System.Windows.Forms.ComboBox cbo_proyecto;
        private System.Windows.Forms.RadioButton rdb_activo;
        private System.Windows.Forms.RadioButton rdb_inactivo;
        private System.Windows.Forms.DataGridView dgv_areas;
        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.Button btn_modificar;
        private System.Windows.Forms.Button btn_eliminar;
        private System.Windows.Forms.Button btn_limpiar;
        private System.Windows.Forms.Button btn_salir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gpb;
        private System.Windows.Forms.GroupBox Gpb_Datos;
        private System.Windows.Forms.Button Btn_Imprimir;
    }
}

