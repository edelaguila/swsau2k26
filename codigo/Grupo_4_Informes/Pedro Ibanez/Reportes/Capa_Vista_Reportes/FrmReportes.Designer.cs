namespace Capa_Vista_Reportes
{
    partial class FrmReportes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReportes));
            this.Btn_Cancelar = new System.Windows.Forms.Button();
            this.Btn_Eliminar = new System.Windows.Forms.Button();
            this.Btn_Modificar = new System.Windows.Forms.Button();
            this.Btn_Guardar = new System.Windows.Forms.Button();
            this.Cbo_Fk_Informe = new System.Windows.Forms.ComboBox();
            this.Cbo_Fk_Rubrica = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GPB_Aspectos_Positivos = new System.Windows.Forms.GroupBox();
            this.btn_Rutas_Positivos = new System.Windows.Forms.Button();
            this.txtRutaImagenPos = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtAspectosPositivos = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.GBP_Correcciones = new System.Windows.Forms.GroupBox();
            this.btn_Rutas_Correciones = new System.Windows.Forms.Button();
            this.txtRutaImagenCorrecion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCorreciones = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.GBSugerencias = new System.Windows.Forms.GroupBox();
            this.btn_Rutas_Sugerencias = new System.Windows.Forms.Button();
            this.txtRutaImagenSugerencias = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSugerencias = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Cbo_id_reporte = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.Btn_Salir = new System.Windows.Forms.Button();
            this.Gpb_Datos = new System.Windows.Forms.GroupBox();
            this.flpImagenesPos = new System.Windows.Forms.FlowLayoutPanel();
            this.flpImagenesCorrecion = new System.Windows.Forms.FlowLayoutPanel();
            this.flpImagenesSugerencias = new System.Windows.Forms.FlowLayoutPanel();
            this.Btn_Imprimir = new System.Windows.Forms.Button();
            this.GPB_Aspectos_Positivos.SuspendLayout();
            this.GBP_Correcciones.SuspendLayout();
            this.GBSugerencias.SuspendLayout();
            this.SuspendLayout();
            // 
            // Btn_Cancelar
            // 
            this.Btn_Cancelar.Location = new System.Drawing.Point(229, 15);
            this.Btn_Cancelar.Name = "Btn_Cancelar";
            this.Btn_Cancelar.Size = new System.Drawing.Size(97, 93);
            this.Btn_Cancelar.TabIndex = 18;
            this.Btn_Cancelar.Text = "Cancelar";
            this.Btn_Cancelar.UseVisualStyleBackColor = true;
            this.Btn_Cancelar.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.Btn_Cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Cancelar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Cancelar.Image")));
            this.Btn_Cancelar.Click += new System.EventHandler(this.Btn_Cancelar_Click);
            // 
            // Btn_Eliminar
            // 
            this.Btn_Eliminar.Location = new System.Drawing.Point(337, 15);
            this.Btn_Eliminar.Name = "Btn_Eliminar";
            this.Btn_Eliminar.Size = new System.Drawing.Size(97, 93);
            this.Btn_Eliminar.TabIndex = 17;
            this.Btn_Eliminar.Text = "Eliminar";
            this.Btn_Eliminar.UseVisualStyleBackColor = true;
            this.Btn_Eliminar.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.Btn_Eliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Eliminar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Eliminar.Image")));
            this.Btn_Eliminar.Click += new System.EventHandler(this.Btn_Eliminar_Click);
            // 
            // Btn_Modificar
            // 
            this.Btn_Modificar.Location = new System.Drawing.Point(13, 15);
            this.Btn_Modificar.Name = "Btn_Modificar";
            this.Btn_Modificar.Size = new System.Drawing.Size(97, 93);
            this.Btn_Modificar.TabIndex = 16;
            this.Btn_Modificar.Text = "Modificar";
            this.Btn_Modificar.UseVisualStyleBackColor = true;
            this.Btn_Modificar.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.Btn_Modificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Modificar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Modificar.Image")));
            this.Btn_Modificar.Click += new System.EventHandler(this.Btn_Modificar_Click);
            // 
            // Btn_Guardar
            // 
            this.Btn_Guardar.Location = new System.Drawing.Point(121, 15);
            this.Btn_Guardar.Name = "Btn_Guardar";
            this.Btn_Guardar.Size = new System.Drawing.Size(97, 93);
            this.Btn_Guardar.TabIndex = 15;
            this.Btn_Guardar.Text = "Guardar";
            this.Btn_Guardar.UseVisualStyleBackColor = true;
            this.Btn_Guardar.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.Btn_Guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Guardar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Guardar.Image")));
            this.Btn_Guardar.Click += new System.EventHandler(this.Btn_Guardar_Click);
            // 
            // Cbo_Fk_Informe
            // 
            this.Cbo_Fk_Informe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbo_Fk_Informe.FormattingEnabled = true;
            this.Cbo_Fk_Informe.Location = new System.Drawing.Point(430, 35);
            this.Cbo_Fk_Informe.Name = "Cbo_Fk_Informe";
            this.Cbo_Fk_Informe.Size = new System.Drawing.Size(170, 28);
            this.Cbo_Fk_Informe.TabIndex = 20;
            this.Cbo_Fk_Informe.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // Cbo_Fk_Rubrica
            // 
            this.Cbo_Fk_Rubrica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbo_Fk_Rubrica.FormattingEnabled = true;
            this.Cbo_Fk_Rubrica.Location = new System.Drawing.Point(815, 35);
            this.Cbo_Fk_Rubrica.Name = "Cbo_Fk_Rubrica";
            this.Cbo_Fk_Rubrica.Size = new System.Drawing.Size(129, 28);
            this.Cbo_Fk_Rubrica.TabIndex = 21;
            this.Cbo_Fk_Rubrica.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(320, 39);
            this.label1.Name = "label1";
            this.label1.TabIndex = 22;
            this.label1.Text = "Id informe:";
            this.label1.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(620, 39);
            this.label2.Name = "label2";
            this.label2.TabIndex = 23;
            this.label2.Text = "Id actividad rúbrica:";
            this.label2.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // GPB_Aspectos_Positivos
            // 
            this.GPB_Aspectos_Positivos.Location = new System.Drawing.Point(13, 215);
            this.GPB_Aspectos_Positivos.Name = "GPB_Aspectos_Positivos";
            this.GPB_Aspectos_Positivos.Size = new System.Drawing.Size(964, 300);
            this.GPB_Aspectos_Positivos.TabIndex = 24;
            this.GPB_Aspectos_Positivos.TabStop = false;
            this.GPB_Aspectos_Positivos.Text = "Aspectos positivos";
            this.GPB_Aspectos_Positivos.Font = new System.Drawing.Font("Rockwell", 10F);
            this.GPB_Aspectos_Positivos.Enter += new System.EventHandler(this.GPB_Aspectos_Positivos_Enter);
            // 
            // btn_Rutas_Positivos
            // 
            this.btn_Rutas_Positivos.Location = new System.Drawing.Point(784, 140);
            this.btn_Rutas_Positivos.Name = "btn_Rutas_Positivos";
            this.btn_Rutas_Positivos.Size = new System.Drawing.Size(160, 40);
            this.btn_Rutas_Positivos.TabIndex = 27;
            this.btn_Rutas_Positivos.Text = "Ruta";
            this.btn_Rutas_Positivos.UseVisualStyleBackColor = true;
            this.btn_Rutas_Positivos.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.btn_Rutas_Positivos.Click += new System.EventHandler(this.btn_Rutas_Positivos_Click);
            // 
            // txtRutaImagenPos
            // 
            this.txtRutaImagenPos.Location = new System.Drawing.Point(20, 140);
            this.txtRutaImagenPos.Multiline = true;
            this.txtRutaImagenPos.Name = "txtRutaImagenPos";
            this.txtRutaImagenPos.Size = new System.Drawing.Size(754, 40);
            this.txtRutaImagenPos.TabIndex = 26;
            this.txtRutaImagenPos.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 118);
            this.label5.Name = "label5";
            this.label5.TabIndex = 25;
            this.label5.Text = "Rutas de imágenes:";
            this.label5.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // TxtAspectosPositivos
            // 
            this.TxtAspectosPositivos.Location = new System.Drawing.Point(20, 50);
            this.TxtAspectosPositivos.Multiline = true;
            this.TxtAspectosPositivos.Name = "TxtAspectosPositivos";
            this.TxtAspectosPositivos.Size = new System.Drawing.Size(924, 60);
            this.TxtAspectosPositivos.TabIndex = 24;
            this.TxtAspectosPositivos.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 28);
            this.label3.Name = "label3";
            this.label3.TabIndex = 23;
            this.label3.Text = "Aspectos positivos:";
            this.label3.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // GBP_Correcciones
            // 
            this.GBP_Correcciones.Location = new System.Drawing.Point(13, 525);
            this.GBP_Correcciones.Name = "GBP_Correcciones";
            this.GBP_Correcciones.Size = new System.Drawing.Size(964, 300);
            this.GBP_Correcciones.TabIndex = 25;
            this.GBP_Correcciones.TabStop = false;
            this.GBP_Correcciones.Text = "Correcciones";
            this.GBP_Correcciones.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // btn_Rutas_Correciones
            // 
            this.btn_Rutas_Correciones.Location = new System.Drawing.Point(784, 140);
            this.btn_Rutas_Correciones.Name = "btn_Rutas_Correciones";
            this.btn_Rutas_Correciones.Size = new System.Drawing.Size(160, 40);
            this.btn_Rutas_Correciones.TabIndex = 30;
            this.btn_Rutas_Correciones.Text = "Ruta";
            this.btn_Rutas_Correciones.UseVisualStyleBackColor = true;
            this.btn_Rutas_Correciones.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.btn_Rutas_Correciones.Click += new System.EventHandler(this.btn_Rutas_Correciones_Click);
            // 
            // txtRutaImagenCorrecion
            // 
            this.txtRutaImagenCorrecion.Location = new System.Drawing.Point(20, 140);
            this.txtRutaImagenCorrecion.Multiline = true;
            this.txtRutaImagenCorrecion.Name = "txtRutaImagenCorrecion";
            this.txtRutaImagenCorrecion.Size = new System.Drawing.Size(754, 40);
            this.txtRutaImagenCorrecion.TabIndex = 29;
            this.txtRutaImagenCorrecion.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 118);
            this.label6.Name = "label6";
            this.label6.TabIndex = 28;
            this.label6.Text = "Rutas de imágenes:";
            this.label6.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // txtCorreciones
            // 
            this.txtCorreciones.Location = new System.Drawing.Point(20, 50);
            this.txtCorreciones.Multiline = true;
            this.txtCorreciones.Name = "txtCorreciones";
            this.txtCorreciones.Size = new System.Drawing.Size(924, 60);
            this.txtCorreciones.TabIndex = 24;
            this.txtCorreciones.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 28);
            this.label4.Name = "label4";
            this.label4.TabIndex = 23;
            this.label4.Text = "Correcciones:";
            this.label4.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // GBSugerencias
            // 
            this.GBSugerencias.Location = new System.Drawing.Point(13, 835);
            this.GBSugerencias.Name = "GBSugerencias";
            this.GBSugerencias.Size = new System.Drawing.Size(964, 300);
            this.GBSugerencias.TabIndex = 26;
            this.GBSugerencias.TabStop = false;
            this.GBSugerencias.Text = "Sugerencias";
            this.GBSugerencias.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // btn_Rutas_Sugerencias
            // 
            this.btn_Rutas_Sugerencias.Location = new System.Drawing.Point(784, 140);
            this.btn_Rutas_Sugerencias.Name = "btn_Rutas_Sugerencias";
            this.btn_Rutas_Sugerencias.Size = new System.Drawing.Size(160, 40);
            this.btn_Rutas_Sugerencias.TabIndex = 30;
            this.btn_Rutas_Sugerencias.Text = "Ruta";
            this.btn_Rutas_Sugerencias.UseVisualStyleBackColor = true;
            this.btn_Rutas_Sugerencias.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.btn_Rutas_Sugerencias.Click += new System.EventHandler(this.btn_Rutas_Sugerencias_Click);
            // 
            // txtRutaImagenSugerencias
            // 
            this.txtRutaImagenSugerencias.Location = new System.Drawing.Point(20, 140);
            this.txtRutaImagenSugerencias.Multiline = true;
            this.txtRutaImagenSugerencias.Name = "txtRutaImagenSugerencias";
            this.txtRutaImagenSugerencias.Size = new System.Drawing.Size(754, 40);
            this.txtRutaImagenSugerencias.TabIndex = 29;
            this.txtRutaImagenSugerencias.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 118);
            this.label7.Name = "label7";
            this.label7.TabIndex = 28;
            this.label7.Text = "Rutas de imágenes:";
            this.label7.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // txtSugerencias
            // 
            this.txtSugerencias.Location = new System.Drawing.Point(20, 50);
            this.txtSugerencias.Multiline = true;
            this.txtSugerencias.Name = "txtSugerencias";
            this.txtSugerencias.Size = new System.Drawing.Size(924, 60);
            this.txtSugerencias.TabIndex = 24;
            this.txtSugerencias.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 28);
            this.label8.Name = "label8";
            this.label8.TabIndex = 23;
            this.label8.Text = "Sugerencias:";
            this.label8.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 39);
            this.label10.Name = "label10";
            this.label10.TabIndex = 29;
            this.label10.Text = "Id reporte:";
            this.label10.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // Cbo_id_reporte
            // 
            this.Cbo_id_reporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbo_id_reporte.FormattingEnabled = true;
            this.Cbo_id_reporte.Location = new System.Drawing.Point(130, 35);
            this.Cbo_id_reporte.Name = "Cbo_id_reporte";
            this.Cbo_id_reporte.Size = new System.Drawing.Size(170, 28);
            this.Cbo_id_reporte.TabIndex = 28;
            this.Cbo_id_reporte.Font = new System.Drawing.Font("Rockwell", 10F);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(445, 15);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(97, 93);
            this.btnBuscar.TabIndex = 30;
            this.btnBuscar.Text = "Consultar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // FrmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(194)))), ((int)(((byte)(99)))));
            this.ClientSize = new System.Drawing.Size(990, 820);
            this.Controls.Add(this.GBSugerencias);
            this.Controls.Add(this.GBP_Correcciones);
            this.Controls.Add(this.GPB_Aspectos_Positivos);
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
            this.Controls.Add(this.Btn_Modificar);
            this.Controls.Add(this.Btn_Guardar);
            this.Controls.Add(this.Btn_Cancelar);
            this.Controls.Add(this.Btn_Eliminar);
            this.Controls.Add(this.btnBuscar);
            // 
            // Gpb_Datos
            // 
            this.Gpb_Datos.Location = new System.Drawing.Point(13, 123);
            this.Gpb_Datos.Size = new System.Drawing.Size(964, 80);
            this.Gpb_Datos.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Gpb_Datos.TabStop = false;
            this.Gpb_Datos.Text = "Datos del reporte";
            this.Gpb_Datos.Name = "Gpb_Datos";
            this.Controls.Add(this.Gpb_Datos);
            this.Gpb_Datos.Controls.Add(this.label10);
            this.Gpb_Datos.Controls.Add(this.Cbo_id_reporte);
            this.Gpb_Datos.Controls.Add(this.label1);
            this.Gpb_Datos.Controls.Add(this.Cbo_Fk_Informe);
            this.Gpb_Datos.Controls.Add(this.label2);
            this.Gpb_Datos.Controls.Add(this.Cbo_Fk_Rubrica);
            this.GPB_Aspectos_Positivos.Controls.Add(this.label3);
            this.GPB_Aspectos_Positivos.Controls.Add(this.TxtAspectosPositivos);
            this.GPB_Aspectos_Positivos.Controls.Add(this.label5);
            this.GPB_Aspectos_Positivos.Controls.Add(this.txtRutaImagenPos);
            this.GPB_Aspectos_Positivos.Controls.Add(this.btn_Rutas_Positivos);
            this.GBP_Correcciones.Controls.Add(this.label4);
            this.GBP_Correcciones.Controls.Add(this.txtCorreciones);
            this.GBP_Correcciones.Controls.Add(this.label6);
            this.GBP_Correcciones.Controls.Add(this.txtRutaImagenCorrecion);
            this.GBP_Correcciones.Controls.Add(this.btn_Rutas_Correciones);
            this.GBSugerencias.Controls.Add(this.label8);
            this.GBSugerencias.Controls.Add(this.txtSugerencias);
            this.GBSugerencias.Controls.Add(this.label7);
            this.GBSugerencias.Controls.Add(this.txtRutaImagenSugerencias);
            this.GBSugerencias.Controls.Add(this.btn_Rutas_Sugerencias);
            // 
            // flpImagenesPos (vista previa de las imagenes)
            // 
            this.flpImagenesPos.AutoScroll = true;
            this.flpImagenesPos.BackColor = System.Drawing.Color.White;
            this.flpImagenesPos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpImagenesPos.Location = new System.Drawing.Point(20, 188);
            this.flpImagenesPos.Name = "flpImagenesPos";
            this.flpImagenesPos.Size = new System.Drawing.Size(924, 102);
            this.flpImagenesPos.WrapContents = false;
            this.GPB_Aspectos_Positivos.Controls.Add(this.flpImagenesPos);
            // 
            // flpImagenesCorrecion (vista previa de las imagenes)
            // 
            this.flpImagenesCorrecion.AutoScroll = true;
            this.flpImagenesCorrecion.BackColor = System.Drawing.Color.White;
            this.flpImagenesCorrecion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpImagenesCorrecion.Location = new System.Drawing.Point(20, 188);
            this.flpImagenesCorrecion.Name = "flpImagenesCorrecion";
            this.flpImagenesCorrecion.Size = new System.Drawing.Size(924, 102);
            this.flpImagenesCorrecion.WrapContents = false;
            this.GBP_Correcciones.Controls.Add(this.flpImagenesCorrecion);
            // 
            // flpImagenesSugerencias (vista previa de las imagenes)
            // 
            this.flpImagenesSugerencias.AutoScroll = true;
            this.flpImagenesSugerencias.BackColor = System.Drawing.Color.White;
            this.flpImagenesSugerencias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpImagenesSugerencias.Location = new System.Drawing.Point(20, 188);
            this.flpImagenesSugerencias.Name = "flpImagenesSugerencias";
            this.flpImagenesSugerencias.Size = new System.Drawing.Size(924, 102);
            this.flpImagenesSugerencias.WrapContents = false;
            this.GBSugerencias.Controls.Add(this.flpImagenesSugerencias);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            // 
            // Btn_Imprimir
            // 
            this.Btn_Imprimir.Text = "Imprimir";
            this.Btn_Imprimir.Name = "Btn_Imprimir";
            this.Btn_Imprimir.Location = new System.Drawing.Point(553, 15);
            this.Btn_Imprimir.Size = new System.Drawing.Size(97, 93);
            this.Btn_Imprimir.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.Btn_Imprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Imprimir.UseVisualStyleBackColor = true;
            this.Btn_Imprimir.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Imprimir.Image")));
            this.Btn_Imprimir.Click += new System.EventHandler(this.Btn_Imprimir_Click);
            this.Controls.Add(this.Btn_Imprimir);
            this.Name = "FrmReportes";
            this.Text = "Reportes";
            this.Load += new System.EventHandler(this.FrmReportes_Load);
            this.GPB_Aspectos_Positivos.ResumeLayout(false);
            this.GPB_Aspectos_Positivos.PerformLayout();
            this.GBP_Correcciones.ResumeLayout(false);
            this.GBP_Correcciones.PerformLayout();
            this.GBSugerencias.ResumeLayout(false);
            this.GBSugerencias.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Button Btn_Cancelar;
        private System.Windows.Forms.Button Btn_Eliminar;
        private System.Windows.Forms.Button Btn_Modificar;
        private System.Windows.Forms.Button Btn_Guardar;
        private System.Windows.Forms.ComboBox Cbo_Fk_Informe;
        private System.Windows.Forms.ComboBox Cbo_Fk_Rubrica;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox GPB_Aspectos_Positivos;
        private System.Windows.Forms.TextBox TxtAspectosPositivos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox GBP_Correcciones;
        private System.Windows.Forms.TextBox txtCorreciones;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Rutas_Positivos;
        private System.Windows.Forms.TextBox txtRutaImagenPos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_Rutas_Correciones;
        private System.Windows.Forms.TextBox txtRutaImagenCorrecion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox GBSugerencias;
        private System.Windows.Forms.Button btn_Rutas_Sugerencias;
        private System.Windows.Forms.TextBox txtRutaImagenSugerencias;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSugerencias;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox Cbo_id_reporte;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button Btn_Salir;
        private System.Windows.Forms.GroupBox Gpb_Datos;
        private System.Windows.Forms.FlowLayoutPanel flpImagenesPos;
        private System.Windows.Forms.FlowLayoutPanel flpImagenesCorrecion;
        private System.Windows.Forms.FlowLayoutPanel flpImagenesSugerencias;
        private System.Windows.Forms.Button Btn_Imprimir;
    }
}