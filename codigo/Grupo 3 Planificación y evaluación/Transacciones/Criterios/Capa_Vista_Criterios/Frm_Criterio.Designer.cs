namespace Capa_Vista_Criterios
{
    partial class Frm_Criterio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Criterio));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.lblSuma = new System.Windows.Forms.Label();
            this.chkSinPorcentaje = new System.Windows.Forms.CheckBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.cmbImportancia = new System.Windows.Forms.ComboBox();
            this.numPorcentaje = new System.Windows.Forms.NumericUpDown();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.cmbRubrica = new System.Windows.Forms.ComboBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblImportancia = new System.Windows.Forms.Label();
            this.lblPorcentaje = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblRubrica = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.btnSalir = new System.Windows.Forms.Button();
            this.Btn_Imprimir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPorcentaje)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(13, 123);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(964, 203);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Font = new System.Drawing.Font("Rockwell", 10F);
            this.groupBox1.Text = "Datos del criterio";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(337, 15);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(97, 93);
            this.btnEliminar.TabIndex = 15;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(229, 15);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(97, 93);
            this.btnCancelar.TabIndex = 14;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(121, 15);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(97, 93);
            this.btnGuardar.TabIndex = 13;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(13, 15);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(97, 93);
            this.btnNuevo.TabIndex = 12;
            this.btnNuevo.Text = "Ingresar";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            // 
            // lblSuma
            // 
            this.lblSuma.AutoSize = true;
            this.lblSuma.Location = new System.Drawing.Point(480, 79);
            this.lblSuma.Name = "lblSuma";
            this.lblSuma.TabIndex = 11;
            this.lblSuma.Text = "Suma";
            this.lblSuma.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // chkSinPorcentaje
            // 
            this.chkSinPorcentaje.AutoSize = true;
            this.chkSinPorcentaje.Location = new System.Drawing.Point(290, 117);
            this.chkSinPorcentaje.Name = "chkSinPorcentaje";
            this.chkSinPorcentaje.Size = new System.Drawing.Size(95, 17);
            this.chkSinPorcentaje.TabIndex = 10;
            this.chkSinPorcentaje.Text = "Sin Porcentaje";
            this.chkSinPorcentaje.UseVisualStyleBackColor = true;
            this.chkSinPorcentaje.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(600, 35);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(344, 27);
            this.txtDescripcion.TabIndex = 9;
            this.txtDescripcion.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // cmbImportancia
            // 
            this.cmbImportancia.FormattingEnabled = true;
            this.cmbImportancia.Location = new System.Drawing.Point(150, 155);
            this.cmbImportancia.Name = "cmbImportancia";
            this.cmbImportancia.Size = new System.Drawing.Size(300, 28);
            this.cmbImportancia.TabIndex = 8;
            this.cmbImportancia.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // numPorcentaje
            // 
            this.numPorcentaje.Location = new System.Drawing.Point(150, 115);
            this.numPorcentaje.Name = "numPorcentaje";
            this.numPorcentaje.Size = new System.Drawing.Size(120, 27);
            this.numPorcentaje.TabIndex = 7;
            this.numPorcentaje.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(150, 75);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(300, 27);
            this.txtNombre.TabIndex = 6;
            this.txtNombre.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // cmbRubrica
            // 
            this.cmbRubrica.FormattingEnabled = true;
            this.cmbRubrica.Location = new System.Drawing.Point(150, 35);
            this.cmbRubrica.Name = "cmbRubrica";
            this.cmbRubrica.Size = new System.Drawing.Size(300, 28);
            this.cmbRubrica.TabIndex = 5;
            this.cmbRubrica.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(480, 39);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.TabIndex = 4;
            this.lblDescripcion.Text = "Descripción";
            this.lblDescripcion.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // lblImportancia
            // 
            this.lblImportancia.AutoSize = true;
            this.lblImportancia.Location = new System.Drawing.Point(20, 159);
            this.lblImportancia.Name = "lblImportancia";
            this.lblImportancia.TabIndex = 3;
            this.lblImportancia.Text = "Importancia";
            this.lblImportancia.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // lblPorcentaje
            // 
            this.lblPorcentaje.AutoSize = true;
            this.lblPorcentaje.Location = new System.Drawing.Point(20, 119);
            this.lblPorcentaje.Name = "lblPorcentaje";
            this.lblPorcentaje.TabIndex = 2;
            this.lblPorcentaje.Text = "Porcentaje";
            this.lblPorcentaje.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(20, 79);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre";
            this.lblNombre.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // lblRubrica
            // 
            this.lblRubrica.AutoSize = true;
            this.lblRubrica.Location = new System.Drawing.Point(20, 39);
            this.lblRubrica.Name = "lblRubrica";
            this.lblRubrica.TabIndex = 0;
            this.lblRubrica.Text = "Rúbrica";
            this.lblRubrica.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(13, 341);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(964, 260);
            this.dgv.TabIndex = 1;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.RowHeadersVisible = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            // 
            // Frm_Criterio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(990, 616);
            this.Margin = new System.Windows.Forms.Padding(2);
            // 
            // btnSalir
            // 
            this.btnSalir.Text = "Salir";
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Location = new System.Drawing.Point(553, 15);
            this.btnSalir.Size = new System.Drawing.Size(97, 93);
            this.btnSalir.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.groupBox1);
            this.groupBox1.Controls.Add(this.lblRubrica);
            this.groupBox1.Controls.Add(this.cmbRubrica);
            this.groupBox1.Controls.Add(this.lblNombre);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.lblPorcentaje);
            this.groupBox1.Controls.Add(this.numPorcentaje);
            this.groupBox1.Controls.Add(this.chkSinPorcentaje);
            this.groupBox1.Controls.Add(this.lblImportancia);
            this.groupBox1.Controls.Add(this.cmbImportancia);
            this.groupBox1.Controls.Add(this.lblDescripcion);
            this.groupBox1.Controls.Add(this.txtDescripcion);
            this.groupBox1.Controls.Add(this.lblSuma);
            this.Controls.Add(this.dgv);
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
            this.Name = "Frm_Criterio";
            this.Text = "Criterios";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPorcentaje)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblImportancia;
        private System.Windows.Forms.Label lblPorcentaje;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblRubrica;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.ComboBox cmbImportancia;
        private System.Windows.Forms.NumericUpDown numPorcentaje;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.ComboBox cmbRubrica;
        private System.Windows.Forms.Label lblSuma;
        private System.Windows.Forms.CheckBox chkSinPorcentaje;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button Btn_Imprimir;
    }
}