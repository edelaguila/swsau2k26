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
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gpb = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_areas)).BeginInit();
            this.panel1.SuspendLayout();
            this.gpb.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_idArea
            // 
            this.txt_idArea.Location = new System.Drawing.Point(138, 103);
            this.txt_idArea.Name = "txt_idArea";
            this.txt_idArea.Size = new System.Drawing.Size(251, 20);
            this.txt_idArea.TabIndex = 0;
            // 
            // txt_nombreArea
            // 
            this.txt_nombreArea.Location = new System.Drawing.Point(140, 145);
            this.txt_nombreArea.Name = "txt_nombreArea";
            this.txt_nombreArea.Size = new System.Drawing.Size(251, 20);
            this.txt_nombreArea.TabIndex = 1;
            // 
            // txt_descripcion
            // 
            this.txt_descripcion.Location = new System.Drawing.Point(140, 192);
            this.txt_descripcion.Multiline = true;
            this.txt_descripcion.Name = "txt_descripcion";
            this.txt_descripcion.Size = new System.Drawing.Size(745, 79);
            this.txt_descripcion.TabIndex = 2;
            // 
            // cbo_proyecto
            // 
            this.cbo_proyecto.FormattingEnabled = true;
            this.cbo_proyecto.Location = new System.Drawing.Point(517, 102);
            this.cbo_proyecto.Name = "cbo_proyecto";
            this.cbo_proyecto.Size = new System.Drawing.Size(366, 21);
            this.cbo_proyecto.TabIndex = 3;
            // 
            // rdb_activo
            // 
            this.rdb_activo.AutoSize = true;
            this.rdb_activo.Font = new System.Drawing.Font("Rockwell", 10F);
            this.rdb_activo.Location = new System.Drawing.Point(121, 22);
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
            this.rdb_inactivo.Location = new System.Drawing.Point(260, 22);
            this.rdb_inactivo.Name = "rdb_inactivo";
            this.rdb_inactivo.Size = new System.Drawing.Size(114, 21);
            this.rdb_inactivo.TabIndex = 7;
            this.rdb_inactivo.TabStop = true;
            this.rdb_inactivo.Text = "Deshabilitado";
            this.rdb_inactivo.UseVisualStyleBackColor = true;
            // 
            // dgv_areas
            // 
            this.dgv_areas.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv_areas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_areas.EnableHeadersVisualStyles = false;
            this.dgv_areas.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgv_areas.Location = new System.Drawing.Point(30, 303);
            this.dgv_areas.Name = "dgv_areas";
            this.dgv_areas.ReadOnly = true;
            this.dgv_areas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_areas.Size = new System.Drawing.Size(853, 226);
            this.dgv_areas.TabIndex = 13;
            this.dgv_areas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_areas_CellClick);
            // 
            // btn_guardar
            // 
            this.btn_guardar.Font = new System.Drawing.Font("Rockwell", 10F);
            this.btn_guardar.Location = new System.Drawing.Point(910, 102);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(95, 80);
            this.btn_guardar.TabIndex = 8;
            this.btn_guardar.Text = "Guardar";
            this.btn_guardar.UseVisualStyleBackColor = true;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // btn_modificar
            // 
            this.btn_modificar.Font = new System.Drawing.Font("Rockwell", 10F);
            this.btn_modificar.Location = new System.Drawing.Point(910, 191);
            this.btn_modificar.Name = "btn_modificar";
            this.btn_modificar.Size = new System.Drawing.Size(95, 80);
            this.btn_modificar.TabIndex = 9;
            this.btn_modificar.Text = "Modificar";
            this.btn_modificar.UseVisualStyleBackColor = true;
            this.btn_modificar.Click += new System.EventHandler(this.btn_modificar_Click);
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.Font = new System.Drawing.Font("Rockwell", 10F);
            this.btn_eliminar.Location = new System.Drawing.Point(910, 277);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(95, 80);
            this.btn_eliminar.TabIndex = 10;
            this.btn_eliminar.Text = "Eliminar";
            this.btn_eliminar.UseVisualStyleBackColor = true;
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // btn_limpiar
            // 
            this.btn_limpiar.Font = new System.Drawing.Font("Rockwell", 10F);
            this.btn_limpiar.Location = new System.Drawing.Point(910, 363);
            this.btn_limpiar.Name = "btn_limpiar";
            this.btn_limpiar.Size = new System.Drawing.Size(95, 80);
            this.btn_limpiar.TabIndex = 11;
            this.btn_limpiar.Text = "Limpiar";
            this.btn_limpiar.UseVisualStyleBackColor = true;
            this.btn_limpiar.Click += new System.EventHandler(this.btn_limpiar_Click);
            // 
            // btn_salir
            // 
            this.btn_salir.Font = new System.Drawing.Font("Rockwell", 10F);
            this.btn_salir.Location = new System.Drawing.Point(910, 449);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(95, 80);
            this.btn_salir.TabIndex = 12;
            this.btn_salir.Text = "Salir";
            this.btn_salir.UseVisualStyleBackColor = true;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Rockwell", 10F);
            this.label1.Location = new System.Drawing.Point(69, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "ID AREA";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Rockwell", 10F);
            this.label2.Location = new System.Drawing.Point(410, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "ID PROYECTO";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Rockwell", 10F);
            this.label3.Location = new System.Drawing.Point(27, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "NOMBRE AREA";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Rockwell", 10F);
            this.label4.Location = new System.Drawing.Point(33, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "DESCRIPCION";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Rockwell", 18F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(13, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(327, 29);
            this.label5.TabIndex = 17;
            this.label5.Text = "MANTENIMIENTO AREAS";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(993, 52);
            this.panel1.TabIndex = 18;
            // 
            // gpb
            // 
            this.gpb.Controls.Add(this.rdb_activo);
            this.gpb.Controls.Add(this.rdb_inactivo);
            this.gpb.Font = new System.Drawing.Font("Rockwell", 10F);
            this.gpb.Location = new System.Drawing.Point(409, 133);
            this.gpb.Name = "gpb";
            this.gpb.Size = new System.Drawing.Size(474, 52);
            this.gpb.TabIndex = 5;
            this.gpb.TabStop = false;
            this.gpb.Text = "Estado";
            // 
            // Frm_Areas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(177)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1019, 558);
            this.Controls.Add(this.gpb);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_salir);
            this.Controls.Add(this.btn_limpiar);
            this.Controls.Add(this.btn_eliminar);
            this.Controls.Add(this.btn_modificar);
            this.Controls.Add(this.btn_guardar);
            this.Controls.Add(this.dgv_areas);
            this.Controls.Add(this.cbo_proyecto);
            this.Controls.Add(this.txt_descripcion);
            this.Controls.Add(this.txt_nombreArea);
            this.Controls.Add(this.txt_idArea);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Frm_Areas";
            this.Text = "Mantenimiento Areas";
            this.Load += new System.EventHandler(this.Frm_Areas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_areas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gpb;
    }
}

