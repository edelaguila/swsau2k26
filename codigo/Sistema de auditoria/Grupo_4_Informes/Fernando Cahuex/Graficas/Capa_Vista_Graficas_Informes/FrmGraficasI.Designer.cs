namespace Capa_Vista_Graficas_Informes
{
    partial class FrmGraficasI
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.Lbl_Modulo = new System.Windows.Forms.Label();
            this.Cbo_Proyecto = new System.Windows.Forms.ComboBox();
            this.Lbl_Rubrica = new System.Windows.Forms.Label();
            this.Cbo_Rubrica = new System.Windows.Forms.ComboBox();
            this.Lbl_Tipo = new System.Windows.Forms.Label();
            this.Cbo_Tipo = new System.Windows.Forms.ComboBox();
            this.Btn_Generar = new System.Windows.Forms.Button();
            this.Cht_Grafica = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Lbl_Descripcion = new System.Windows.Forms.Label();
            this.Txt_Descripcion = new System.Windows.Forms.TextBox();
            this.Btn_Guardar = new System.Windows.Forms.Button();
            this.Btn_Modificar = new System.Windows.Forms.Button();
            this.Btn_Eliminar = new System.Windows.Forms.Button();
            this.Btn_Cancelar = new System.Windows.Forms.Button();
            this.Btn_Imprimir = new System.Windows.Forms.Button();
            this.Dgv_Graficas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.Cht_Grafica)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Graficas)).BeginInit();
            this.SuspendLayout();
            // 
            // Lbl_Modulo
            // 
            this.Lbl_Modulo.AutoSize = true;
            this.Lbl_Modulo.Location = new System.Drawing.Point(27, 25);
            this.Lbl_Modulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_Modulo.Name = "Lbl_Modulo";
            this.Lbl_Modulo.Size = new System.Drawing.Size(55, 16);
            this.Lbl_Modulo.TabIndex = 0;
            this.Lbl_Modulo.Text = "Modulo:";
            this.Lbl_Modulo.Click += new System.EventHandler(this.Lbl_Proyecto_Click);
            // 
            // Cbo_Proyecto
            // 
            this.Cbo_Proyecto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbo_Proyecto.FormattingEnabled = true;
            this.Cbo_Proyecto.Location = new System.Drawing.Point(107, 21);
            this.Cbo_Proyecto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Cbo_Proyecto.Name = "Cbo_Proyecto";
            this.Cbo_Proyecto.Size = new System.Drawing.Size(385, 24);
            this.Cbo_Proyecto.TabIndex = 1;
            this.Cbo_Proyecto.SelectionChangeCommitted += new System.EventHandler(this.Cbo_Proyecto_SelectionChangeCommitted);
            // 
            // Lbl_Rubrica
            // 
            this.Lbl_Rubrica.AutoSize = true;
            this.Lbl_Rubrica.Location = new System.Drawing.Point(520, 25);
            this.Lbl_Rubrica.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_Rubrica.Name = "Lbl_Rubrica";
            this.Lbl_Rubrica.Size = new System.Drawing.Size(57, 16);
            this.Lbl_Rubrica.TabIndex = 2;
            this.Lbl_Rubrica.Text = "Rúbrica:";
            // 
            // Cbo_Rubrica
            // 
            this.Cbo_Rubrica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbo_Rubrica.FormattingEnabled = true;
            this.Cbo_Rubrica.Location = new System.Drawing.Point(593, 21);
            this.Cbo_Rubrica.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Cbo_Rubrica.Name = "Cbo_Rubrica";
            this.Cbo_Rubrica.Size = new System.Drawing.Size(305, 24);
            this.Cbo_Rubrica.TabIndex = 3;
            this.Cbo_Rubrica.SelectionChangeCommitted += new System.EventHandler(this.Cbo_Rubrica_SelectionChangeCommitted);
            // 
            // Lbl_Tipo
            // 
            this.Lbl_Tipo.AutoSize = true;
            this.Lbl_Tipo.Location = new System.Drawing.Point(927, 25);
            this.Lbl_Tipo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_Tipo.Name = "Lbl_Tipo";
            this.Lbl_Tipo.Size = new System.Drawing.Size(38, 16);
            this.Lbl_Tipo.TabIndex = 4;
            this.Lbl_Tipo.Text = "Tipo:";
            // 
            // Cbo_Tipo
            // 
            this.Cbo_Tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbo_Tipo.FormattingEnabled = true;
            this.Cbo_Tipo.Location = new System.Drawing.Point(980, 21);
            this.Cbo_Tipo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Cbo_Tipo.Name = "Cbo_Tipo";
            this.Cbo_Tipo.Size = new System.Drawing.Size(159, 24);
            this.Cbo_Tipo.TabIndex = 5;
            this.Cbo_Tipo.SelectionChangeCommitted += new System.EventHandler(this.Cbo_Tipo_SelectionChangeCommitted);
            // 
            // Btn_Generar
            // 
            this.Btn_Generar.Location = new System.Drawing.Point(1160, 16);
            this.Btn_Generar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Btn_Generar.Name = "Btn_Generar";
            this.Btn_Generar.Size = new System.Drawing.Size(147, 37);
            this.Btn_Generar.TabIndex = 6;
            this.Btn_Generar.Text = "Generar gráfica";
            this.Btn_Generar.UseVisualStyleBackColor = true;
            this.Btn_Generar.Click += new System.EventHandler(this.Btn_Generar_Click);
            // 
            // Cht_Grafica
            // 
            chartArea3.Name = "ChartArea1";
            this.Cht_Grafica.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.Cht_Grafica.Legends.Add(legend3);
            this.Cht_Grafica.Location = new System.Drawing.Point(27, 68);
            this.Cht_Grafica.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Cht_Grafica.Name = "Cht_Grafica";
            this.Cht_Grafica.Size = new System.Drawing.Size(827, 412);
            this.Cht_Grafica.TabIndex = 7;
            this.Cht_Grafica.Text = "Cht_Grafica";
            // 
            // Lbl_Descripcion
            // 
            this.Lbl_Descripcion.AutoSize = true;
            this.Lbl_Descripcion.Location = new System.Drawing.Point(880, 70);
            this.Lbl_Descripcion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_Descripcion.Name = "Lbl_Descripcion";
            this.Lbl_Descripcion.Size = new System.Drawing.Size(82, 16);
            this.Lbl_Descripcion.TabIndex = 8;
            this.Lbl_Descripcion.Text = "Descripción:";
            // 
            // Txt_Descripcion
            // 
            this.Txt_Descripcion.Location = new System.Drawing.Point(880, 94);
            this.Txt_Descripcion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Txt_Descripcion.MaxLength = 1000;
            this.Txt_Descripcion.Multiline = true;
            this.Txt_Descripcion.Name = "Txt_Descripcion";
            this.Txt_Descripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Txt_Descripcion.Size = new System.Drawing.Size(425, 282);
            this.Txt_Descripcion.TabIndex = 9;
            // 
            // Btn_Guardar
            // 
            this.Btn_Guardar.Location = new System.Drawing.Point(880, 396);
            this.Btn_Guardar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Btn_Guardar.Name = "Btn_Guardar";
            this.Btn_Guardar.Size = new System.Drawing.Size(133, 39);
            this.Btn_Guardar.TabIndex = 10;
            this.Btn_Guardar.Text = "Guardar";
            this.Btn_Guardar.UseVisualStyleBackColor = true;
            this.Btn_Guardar.Click += new System.EventHandler(this.Btn_Guardar_Click);
            // 
            // Btn_Modificar
            // 
            this.Btn_Modificar.Location = new System.Drawing.Point(1027, 396);
            this.Btn_Modificar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Btn_Modificar.Name = "Btn_Modificar";
            this.Btn_Modificar.Size = new System.Drawing.Size(133, 39);
            this.Btn_Modificar.TabIndex = 11;
            this.Btn_Modificar.Text = "Modificar";
            this.Btn_Modificar.UseVisualStyleBackColor = true;
            this.Btn_Modificar.Click += new System.EventHandler(this.Btn_Modificar_Click);
            // 
            // Btn_Eliminar
            // 
            this.Btn_Eliminar.Location = new System.Drawing.Point(1173, 396);
            this.Btn_Eliminar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Btn_Eliminar.Name = "Btn_Eliminar";
            this.Btn_Eliminar.Size = new System.Drawing.Size(133, 39);
            this.Btn_Eliminar.TabIndex = 12;
            this.Btn_Eliminar.Text = "Eliminar";
            this.Btn_Eliminar.UseVisualStyleBackColor = true;
            this.Btn_Eliminar.Click += new System.EventHandler(this.Btn_Eliminar_Click);
            // 
            // Btn_Cancelar
            // 
            this.Btn_Cancelar.Location = new System.Drawing.Point(880, 443);
            this.Btn_Cancelar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Btn_Cancelar.Name = "Btn_Cancelar";
            this.Btn_Cancelar.Size = new System.Drawing.Size(133, 39);
            this.Btn_Cancelar.TabIndex = 13;
            this.Btn_Cancelar.Text = "Cancelar";
            this.Btn_Cancelar.UseVisualStyleBackColor = true;
            this.Btn_Cancelar.Click += new System.EventHandler(this.Btn_Cancelar_Click);
            // 
            // Btn_Imprimir
            // 
            this.Btn_Imprimir.Location = new System.Drawing.Point(1027, 443);
            this.Btn_Imprimir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Btn_Imprimir.Name = "Btn_Imprimir";
            this.Btn_Imprimir.Size = new System.Drawing.Size(133, 39);
            this.Btn_Imprimir.TabIndex = 14;
            this.Btn_Imprimir.Text = "Imprimir";
            this.Btn_Imprimir.UseVisualStyleBackColor = true;
            this.Btn_Imprimir.Click += new System.EventHandler(this.Btn_Imprimir_Click);
            // 
            // Dgv_Graficas
            // 
            this.Dgv_Graficas.AllowUserToAddRows = false;
            this.Dgv_Graficas.AllowUserToDeleteRows = false;
            this.Dgv_Graficas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Dgv_Graficas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_Graficas.Location = new System.Drawing.Point(27, 498);
            this.Dgv_Graficas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Dgv_Graficas.MultiSelect = false;
            this.Dgv_Graficas.Name = "Dgv_Graficas";
            this.Dgv_Graficas.ReadOnly = true;
            this.Dgv_Graficas.RowHeadersVisible = false;
            this.Dgv_Graficas.RowHeadersWidth = 51;
            this.Dgv_Graficas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv_Graficas.Size = new System.Drawing.Size(1280, 258);
            this.Dgv_Graficas.TabIndex = 15;
            this.Dgv_Graficas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_Graficas_CellClick);
            // 
            // FrmGraficasI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(194)))), ((int)(((byte)(99)))));
            this.ClientSize = new System.Drawing.Size(1333, 832);
            this.Controls.Add(this.Dgv_Graficas);
            this.Controls.Add(this.Btn_Imprimir);
            this.Controls.Add(this.Btn_Cancelar);
            this.Controls.Add(this.Btn_Eliminar);
            this.Controls.Add(this.Btn_Modificar);
            this.Controls.Add(this.Btn_Guardar);
            this.Controls.Add(this.Txt_Descripcion);
            this.Controls.Add(this.Lbl_Descripcion);
            this.Controls.Add(this.Cht_Grafica);
            this.Controls.Add(this.Btn_Generar);
            this.Controls.Add(this.Cbo_Tipo);
            this.Controls.Add(this.Lbl_Tipo);
            this.Controls.Add(this.Cbo_Rubrica);
            this.Controls.Add(this.Lbl_Rubrica);
            this.Controls.Add(this.Cbo_Proyecto);
            this.Controls.Add(this.Lbl_Modulo);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmGraficasI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gráficas de informes";
            this.Load += new System.EventHandler(this.FrmGraficasI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Cht_Grafica)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Graficas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label Lbl_Modulo;
        private System.Windows.Forms.ComboBox Cbo_Proyecto;
        private System.Windows.Forms.Label Lbl_Rubrica;
        private System.Windows.Forms.ComboBox Cbo_Rubrica;
        private System.Windows.Forms.Label Lbl_Tipo;
        private System.Windows.Forms.ComboBox Cbo_Tipo;
        private System.Windows.Forms.Button Btn_Generar;
        private System.Windows.Forms.DataVisualization.Charting.Chart Cht_Grafica;
        private System.Windows.Forms.Label Lbl_Descripcion;
        private System.Windows.Forms.TextBox Txt_Descripcion;
        private System.Windows.Forms.Button Btn_Guardar;
        private System.Windows.Forms.Button Btn_Modificar;
        private System.Windows.Forms.Button Btn_Eliminar;
        private System.Windows.Forms.Button Btn_Cancelar;
        private System.Windows.Forms.Button Btn_Imprimir;
        private System.Windows.Forms.DataGridView Dgv_Graficas;
    }
}

