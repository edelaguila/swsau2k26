namespace Capa_Vista_Rubrica
{
    partial class Frm_Rubrica
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

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Rubrica));
            this.Pnl_Titulo = new System.Windows.Forms.Panel();
            this.Lbl_CodigoAplicacion = new System.Windows.Forms.Label();
            this.Lbl_Titulo = new System.Windows.Forms.Label();
            this.Pnl_Botones = new System.Windows.Forms.FlowLayoutPanel();
            this.Btn_Ingresar = new System.Windows.Forms.Button();
            this.Btn_Modificar = new System.Windows.Forms.Button();
            this.Btn_Guardar = new System.Windows.Forms.Button();
            this.Btn_Cancelar = new System.Windows.Forms.Button();
            this.Btn_Eliminar = new System.Windows.Forms.Button();
            this.Btn_Consultar = new System.Windows.Forms.Button();
            this.Btn_Imprimir = new System.Windows.Forms.Button();
            this.Btn_Refrescar = new System.Windows.Forms.Button();
            this.Btn_Inicio = new System.Windows.Forms.Button();
            this.Btn_Anterior = new System.Windows.Forms.Button();
            this.Btn_Siguiente = new System.Windows.Forms.Button();
            this.Btn_Fin = new System.Windows.Forms.Button();
            this.Btn_Ayuda = new System.Windows.Forms.Button();
            this.Btn_Salir = new System.Windows.Forms.Button();
            this.Gpb_Datos = new System.Windows.Forms.GroupBox();
            this.Lbl_Cronograma = new System.Windows.Forms.Label();
            this.Cbo_Cronograma = new System.Windows.Forms.ComboBox();
            this.Lbl_Nombre = new System.Windows.Forms.Label();
            this.Txt_Nombre = new System.Windows.Forms.TextBox();
            this.Lbl_InfoCronograma = new System.Windows.Forms.Label();
            this.Lbl_Descripcion = new System.Windows.Forms.Label();
            this.Txt_Descripcion = new System.Windows.Forms.TextBox();
            this.Lbl_Objetivo = new System.Windows.Forms.Label();
            this.Txt_Objetivo = new System.Windows.Forms.TextBox();
            this.Dgv_Rubricas = new System.Windows.Forms.DataGridView();
            this.Erp_Validacion = new System.Windows.Forms.ErrorProvider(this.components);
            this.Pnl_Titulo.SuspendLayout();
            this.Pnl_Botones.SuspendLayout();
            this.Gpb_Datos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Rubricas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Erp_Validacion)).BeginInit();
            this.SuspendLayout();
            // 
            // Pnl_Titulo
            // 
            this.Pnl_Titulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(0)))));
            this.Pnl_Titulo.Controls.Add(this.Lbl_CodigoAplicacion);
            this.Pnl_Titulo.Controls.Add(this.Lbl_Titulo);
            this.Pnl_Titulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.Pnl_Titulo.Location = new System.Drawing.Point(0, 0);
            this.Pnl_Titulo.Name = "Pnl_Titulo";
            this.Pnl_Titulo.Size = new System.Drawing.Size(1175, 64);
            this.Pnl_Titulo.TabIndex = 0;
            // 
            // Lbl_CodigoAplicacion
            // 
            this.Lbl_CodigoAplicacion.AutoSize = true;
            this.Lbl_CodigoAplicacion.Font = new System.Drawing.Font("Rockwell", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_CodigoAplicacion.ForeColor = System.Drawing.Color.Black;
            this.Lbl_CodigoAplicacion.Location = new System.Drawing.Point(17, 40);
            this.Lbl_CodigoAplicacion.Name = "Lbl_CodigoAplicacion";
            this.Lbl_CodigoAplicacion.Size = new System.Drawing.Size(212, 20);
            this.Lbl_CodigoAplicacion.TabIndex = 1;
            this.Lbl_CodigoAplicacion.Text = "Código de aplicación: 515";
            // 
            // Lbl_Titulo
            // 
            this.Lbl_Titulo.AutoSize = true;
            this.Lbl_Titulo.Font = new System.Drawing.Font("Rockwell", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Titulo.ForeColor = System.Drawing.Color.Black;
            this.Lbl_Titulo.Location = new System.Drawing.Point(14, 6);
            this.Lbl_Titulo.Name = "Lbl_Titulo";
            this.Lbl_Titulo.Size = new System.Drawing.Size(432, 38);
            this.Lbl_Titulo.TabIndex = 0;
            this.Lbl_Titulo.Text = "Mantenimiento de Rúbricas";
            // 
            // Pnl_Botones
            // 
            this.Pnl_Botones.AutoSize = true;
            this.Pnl_Botones.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Pnl_Botones.BackColor = System.Drawing.Color.White;
            this.Pnl_Botones.Controls.Add(this.Btn_Ingresar);
            this.Pnl_Botones.Controls.Add(this.Btn_Modificar);
            this.Pnl_Botones.Controls.Add(this.Btn_Guardar);
            this.Pnl_Botones.Controls.Add(this.Btn_Cancelar);
            this.Pnl_Botones.Controls.Add(this.Btn_Eliminar);
            this.Pnl_Botones.Controls.Add(this.Btn_Consultar);
            this.Pnl_Botones.Controls.Add(this.Btn_Imprimir);
            this.Pnl_Botones.Controls.Add(this.Btn_Refrescar);
            this.Pnl_Botones.Controls.Add(this.Btn_Inicio);
            this.Pnl_Botones.Controls.Add(this.Btn_Anterior);
            this.Pnl_Botones.Controls.Add(this.Btn_Siguiente);
            this.Pnl_Botones.Controls.Add(this.Btn_Fin);
            this.Pnl_Botones.Controls.Add(this.Btn_Ayuda);
            this.Pnl_Botones.Controls.Add(this.Btn_Salir);
            this.Pnl_Botones.Dock = System.Windows.Forms.DockStyle.Top;
            this.Pnl_Botones.Location = new System.Drawing.Point(0, 64);
            this.Pnl_Botones.Name = "Pnl_Botones";
            this.Pnl_Botones.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.Pnl_Botones.Size = new System.Drawing.Size(1175, 82);
            this.Pnl_Botones.TabIndex = 1;
            // 
            // Btn_Ingresar
            // 
            this.Btn_Ingresar.BackColor = System.Drawing.Color.White;
            this.Btn_Ingresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Ingresar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.Btn_Ingresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Ingresar.Font = new System.Drawing.Font("Rockwell", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Ingresar.ForeColor = System.Drawing.Color.Black;
            this.Btn_Ingresar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Ingresar.Image")));
            this.Btn_Ingresar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Ingresar.Location = new System.Drawing.Point(10, 8);
            this.Btn_Ingresar.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_Ingresar.Name = "Btn_Ingresar";
            this.Btn_Ingresar.Size = new System.Drawing.Size(74, 66);
            this.Btn_Ingresar.TabIndex = 0;
            this.Btn_Ingresar.Text = "Ingresar";
            this.Btn_Ingresar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Ingresar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Btn_Ingresar.UseVisualStyleBackColor = false;
            this.Btn_Ingresar.Click += new System.EventHandler(this.pro_btn_ingresar_click);
            // 
            // Btn_Modificar
            // 
            this.Btn_Modificar.BackColor = System.Drawing.Color.White;
            this.Btn_Modificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Modificar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.Btn_Modificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Modificar.Font = new System.Drawing.Font("Rockwell", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Modificar.ForeColor = System.Drawing.Color.Black;
            this.Btn_Modificar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Modificar.Image")));
            this.Btn_Modificar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Modificar.Location = new System.Drawing.Point(88, 8);
            this.Btn_Modificar.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_Modificar.Name = "Btn_Modificar";
            this.Btn_Modificar.Size = new System.Drawing.Size(74, 66);
            this.Btn_Modificar.TabIndex = 1;
            this.Btn_Modificar.Text = "Modificar";
            this.Btn_Modificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Modificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Btn_Modificar.UseVisualStyleBackColor = false;
            this.Btn_Modificar.Click += new System.EventHandler(this.pro_btn_modificar_click);
            // 
            // Btn_Guardar
            // 
            this.Btn_Guardar.BackColor = System.Drawing.Color.White;
            this.Btn_Guardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Guardar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.Btn_Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Guardar.Font = new System.Drawing.Font("Rockwell", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Guardar.ForeColor = System.Drawing.Color.Black;
            this.Btn_Guardar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Guardar.Image")));
            this.Btn_Guardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Guardar.Location = new System.Drawing.Point(166, 8);
            this.Btn_Guardar.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_Guardar.Name = "Btn_Guardar";
            this.Btn_Guardar.Size = new System.Drawing.Size(74, 66);
            this.Btn_Guardar.TabIndex = 2;
            this.Btn_Guardar.Text = "Guardar";
            this.Btn_Guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Guardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Btn_Guardar.UseVisualStyleBackColor = false;
            this.Btn_Guardar.Click += new System.EventHandler(this.pro_btn_guardar_click);
            // 
            // Btn_Cancelar
            // 
            this.Btn_Cancelar.BackColor = System.Drawing.Color.White;
            this.Btn_Cancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Cancelar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.Btn_Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Cancelar.Font = new System.Drawing.Font("Rockwell", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Cancelar.ForeColor = System.Drawing.Color.Black;
            this.Btn_Cancelar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Cancelar.Image")));
            this.Btn_Cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Cancelar.Location = new System.Drawing.Point(244, 8);
            this.Btn_Cancelar.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_Cancelar.Name = "Btn_Cancelar";
            this.Btn_Cancelar.Size = new System.Drawing.Size(74, 66);
            this.Btn_Cancelar.TabIndex = 3;
            this.Btn_Cancelar.Text = "Cancelar";
            this.Btn_Cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Cancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Btn_Cancelar.UseVisualStyleBackColor = false;
            this.Btn_Cancelar.Click += new System.EventHandler(this.pro_btn_cancelar_click);
            // 
            // Btn_Eliminar
            // 
            this.Btn_Eliminar.BackColor = System.Drawing.Color.White;
            this.Btn_Eliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Eliminar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.Btn_Eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Eliminar.Font = new System.Drawing.Font("Rockwell", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Eliminar.ForeColor = System.Drawing.Color.Black;
            this.Btn_Eliminar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Eliminar.Image")));
            this.Btn_Eliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Eliminar.Location = new System.Drawing.Point(322, 8);
            this.Btn_Eliminar.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_Eliminar.Name = "Btn_Eliminar";
            this.Btn_Eliminar.Size = new System.Drawing.Size(74, 66);
            this.Btn_Eliminar.TabIndex = 4;
            this.Btn_Eliminar.Text = "Eliminar";
            this.Btn_Eliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Eliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Btn_Eliminar.UseVisualStyleBackColor = false;
            this.Btn_Eliminar.Click += new System.EventHandler(this.pro_btn_eliminar_click);
            // 
            // Btn_Consultar
            // 
            this.Btn_Consultar.BackColor = System.Drawing.Color.White;
            this.Btn_Consultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Consultar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.Btn_Consultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Consultar.Font = new System.Drawing.Font("Rockwell", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Consultar.ForeColor = System.Drawing.Color.Black;
            this.Btn_Consultar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Consultar.Image")));
            this.Btn_Consultar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Consultar.Location = new System.Drawing.Point(400, 8);
            this.Btn_Consultar.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_Consultar.Name = "Btn_Consultar";
            this.Btn_Consultar.Size = new System.Drawing.Size(74, 66);
            this.Btn_Consultar.TabIndex = 5;
            this.Btn_Consultar.Text = "Consultar";
            this.Btn_Consultar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Consultar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Btn_Consultar.UseVisualStyleBackColor = false;
            this.Btn_Consultar.Click += new System.EventHandler(this.pro_btn_consultar_click);
            // 
            // Btn_Imprimir
            // 
            this.Btn_Imprimir.BackColor = System.Drawing.Color.White;
            this.Btn_Imprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Imprimir.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.Btn_Imprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Imprimir.Font = new System.Drawing.Font("Rockwell", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Imprimir.ForeColor = System.Drawing.Color.Black;
            this.Btn_Imprimir.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Imprimir.Image")));
            this.Btn_Imprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Imprimir.Location = new System.Drawing.Point(478, 8);
            this.Btn_Imprimir.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_Imprimir.Name = "Btn_Imprimir";
            this.Btn_Imprimir.Size = new System.Drawing.Size(74, 66);
            this.Btn_Imprimir.TabIndex = 6;
            this.Btn_Imprimir.Text = "Imprimir";
            this.Btn_Imprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Imprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Btn_Imprimir.UseVisualStyleBackColor = false;
            this.Btn_Imprimir.Click += new System.EventHandler(this.pro_btn_imprimir_click);
            // 
            // Btn_Refrescar
            // 
            this.Btn_Refrescar.BackColor = System.Drawing.Color.White;
            this.Btn_Refrescar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Refrescar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.Btn_Refrescar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Refrescar.Font = new System.Drawing.Font("Rockwell", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Refrescar.ForeColor = System.Drawing.Color.Black;
            this.Btn_Refrescar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Refrescar.Image")));
            this.Btn_Refrescar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Refrescar.Location = new System.Drawing.Point(556, 8);
            this.Btn_Refrescar.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_Refrescar.Name = "Btn_Refrescar";
            this.Btn_Refrescar.Size = new System.Drawing.Size(74, 66);
            this.Btn_Refrescar.TabIndex = 7;
            this.Btn_Refrescar.Text = "Refrescar";
            this.Btn_Refrescar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Refrescar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Btn_Refrescar.UseVisualStyleBackColor = false;
            this.Btn_Refrescar.Click += new System.EventHandler(this.pro_btn_refrescar_click);
            // 
            // Btn_Inicio
            // 
            this.Btn_Inicio.BackColor = System.Drawing.Color.White;
            this.Btn_Inicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Inicio.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.Btn_Inicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Inicio.Font = new System.Drawing.Font("Rockwell", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Inicio.ForeColor = System.Drawing.Color.Black;
            this.Btn_Inicio.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Inicio.Image")));
            this.Btn_Inicio.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Inicio.Location = new System.Drawing.Point(634, 8);
            this.Btn_Inicio.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_Inicio.Name = "Btn_Inicio";
            this.Btn_Inicio.Size = new System.Drawing.Size(74, 66);
            this.Btn_Inicio.TabIndex = 8;
            this.Btn_Inicio.Text = "Inicio";
            this.Btn_Inicio.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Inicio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Btn_Inicio.UseVisualStyleBackColor = false;
            this.Btn_Inicio.Click += new System.EventHandler(this.pro_btn_inicio_click);
            // 
            // Btn_Anterior
            // 
            this.Btn_Anterior.BackColor = System.Drawing.Color.White;
            this.Btn_Anterior.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Anterior.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.Btn_Anterior.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Anterior.Font = new System.Drawing.Font("Rockwell", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Anterior.ForeColor = System.Drawing.Color.Black;
            this.Btn_Anterior.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Anterior.Image")));
            this.Btn_Anterior.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Anterior.Location = new System.Drawing.Point(712, 8);
            this.Btn_Anterior.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_Anterior.Name = "Btn_Anterior";
            this.Btn_Anterior.Size = new System.Drawing.Size(74, 66);
            this.Btn_Anterior.TabIndex = 9;
            this.Btn_Anterior.Text = "Anterior";
            this.Btn_Anterior.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Anterior.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Btn_Anterior.UseVisualStyleBackColor = false;
            this.Btn_Anterior.Click += new System.EventHandler(this.pro_btn_anterior_click);
            // 
            // Btn_Siguiente
            // 
            this.Btn_Siguiente.BackColor = System.Drawing.Color.White;
            this.Btn_Siguiente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Siguiente.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.Btn_Siguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Siguiente.Font = new System.Drawing.Font("Rockwell", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Siguiente.ForeColor = System.Drawing.Color.Black;
            this.Btn_Siguiente.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Siguiente.Image")));
            this.Btn_Siguiente.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Siguiente.Location = new System.Drawing.Point(790, 8);
            this.Btn_Siguiente.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_Siguiente.Name = "Btn_Siguiente";
            this.Btn_Siguiente.Size = new System.Drawing.Size(74, 66);
            this.Btn_Siguiente.TabIndex = 10;
            this.Btn_Siguiente.Text = "Siguiente";
            this.Btn_Siguiente.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Siguiente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Btn_Siguiente.UseVisualStyleBackColor = false;
            this.Btn_Siguiente.Click += new System.EventHandler(this.pro_btn_siguiente_click);
            // 
            // Btn_Fin
            // 
            this.Btn_Fin.BackColor = System.Drawing.Color.White;
            this.Btn_Fin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Fin.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.Btn_Fin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Fin.Font = new System.Drawing.Font("Rockwell", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Fin.ForeColor = System.Drawing.Color.Black;
            this.Btn_Fin.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Fin.Image")));
            this.Btn_Fin.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Fin.Location = new System.Drawing.Point(868, 8);
            this.Btn_Fin.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_Fin.Name = "Btn_Fin";
            this.Btn_Fin.Size = new System.Drawing.Size(74, 66);
            this.Btn_Fin.TabIndex = 11;
            this.Btn_Fin.Text = "Fin";
            this.Btn_Fin.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Fin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Btn_Fin.UseVisualStyleBackColor = false;
            this.Btn_Fin.Click += new System.EventHandler(this.pro_btn_fin_click);
            // 
            // Btn_Ayuda
            // 
            this.Btn_Ayuda.BackColor = System.Drawing.Color.White;
            this.Btn_Ayuda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Ayuda.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.Btn_Ayuda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Ayuda.Font = new System.Drawing.Font("Rockwell", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Ayuda.ForeColor = System.Drawing.Color.Black;
            this.Btn_Ayuda.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Ayuda.Image")));
            this.Btn_Ayuda.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Ayuda.Location = new System.Drawing.Point(946, 8);
            this.Btn_Ayuda.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_Ayuda.Name = "Btn_Ayuda";
            this.Btn_Ayuda.Size = new System.Drawing.Size(74, 66);
            this.Btn_Ayuda.TabIndex = 12;
            this.Btn_Ayuda.Text = "Ayuda";
            this.Btn_Ayuda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Ayuda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Btn_Ayuda.UseVisualStyleBackColor = false;
            this.Btn_Ayuda.Click += new System.EventHandler(this.pro_btn_ayuda_click);
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.BackColor = System.Drawing.Color.White;
            this.Btn_Salir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Salir.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.Btn_Salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Salir.Font = new System.Drawing.Font("Rockwell", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Salir.ForeColor = System.Drawing.Color.Black;
            this.Btn_Salir.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Salir.Image")));
            this.Btn_Salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Salir.Location = new System.Drawing.Point(1024, 8);
            this.Btn_Salir.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(74, 66);
            this.Btn_Salir.TabIndex = 13;
            this.Btn_Salir.Text = "Salir";
            this.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Salir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Btn_Salir.UseVisualStyleBackColor = false;
            this.Btn_Salir.Click += new System.EventHandler(this.pro_btn_salir_click);
            // 
            // Gpb_Datos
            // 
            this.Gpb_Datos.Controls.Add(this.Lbl_Cronograma);
            this.Gpb_Datos.Controls.Add(this.Cbo_Cronograma);
            this.Gpb_Datos.Controls.Add(this.Lbl_Nombre);
            this.Gpb_Datos.Controls.Add(this.Txt_Nombre);
            this.Gpb_Datos.Controls.Add(this.Lbl_InfoCronograma);
            this.Gpb_Datos.Controls.Add(this.Lbl_Descripcion);
            this.Gpb_Datos.Controls.Add(this.Txt_Descripcion);
            this.Gpb_Datos.Controls.Add(this.Lbl_Objetivo);
            this.Gpb_Datos.Controls.Add(this.Txt_Objetivo);
            this.Gpb_Datos.Dock = System.Windows.Forms.DockStyle.Top;
            this.Gpb_Datos.Font = new System.Drawing.Font("Rockwell", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gpb_Datos.Location = new System.Drawing.Point(0, 146);
            this.Gpb_Datos.Name = "Gpb_Datos";
            this.Gpb_Datos.Padding = new System.Windows.Forms.Padding(10);
            this.Gpb_Datos.Size = new System.Drawing.Size(1175, 230);
            this.Gpb_Datos.TabIndex = 2;
            this.Gpb_Datos.TabStop = false;
            this.Gpb_Datos.Text = "Datos de la rúbrica";
            // 
            // Lbl_Cronograma
            // 
            this.Lbl_Cronograma.AutoSize = true;
            this.Lbl_Cronograma.Font = new System.Drawing.Font("Rockwell", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Cronograma.Location = new System.Drawing.Point(20, 35);
            this.Lbl_Cronograma.Name = "Lbl_Cronograma";
            this.Lbl_Cronograma.Size = new System.Drawing.Size(123, 20);
            this.Lbl_Cronograma.TabIndex = 0;
            this.Lbl_Cronograma.Text = "Cronograma:";
            // 
            // Cbo_Cronograma
            // 
            this.Cbo_Cronograma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbo_Cronograma.Font = new System.Drawing.Font("Rockwell", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cbo_Cronograma.Location = new System.Drawing.Point(160, 31);
            this.Cbo_Cronograma.Name = "Cbo_Cronograma";
            this.Cbo_Cronograma.Size = new System.Drawing.Size(340, 28);
            this.Cbo_Cronograma.TabIndex = 1;
            this.Cbo_Cronograma.SelectedIndexChanged += new System.EventHandler(this.pro_cbo_cronograma_cambiado);
            // 
            // Lbl_Nombre
            // 
            this.Lbl_Nombre.AutoSize = true;
            this.Lbl_Nombre.Font = new System.Drawing.Font("Rockwell", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Nombre.Location = new System.Drawing.Point(20, 72);
            this.Lbl_Nombre.Name = "Lbl_Nombre";
            this.Lbl_Nombre.Size = new System.Drawing.Size(84, 20);
            this.Lbl_Nombre.TabIndex = 2;
            this.Lbl_Nombre.Text = "Nombre:";
            // 
            // Txt_Nombre
            // 
            this.Txt_Nombre.Font = new System.Drawing.Font("Rockwell", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Nombre.Location = new System.Drawing.Point(160, 68);
            this.Txt_Nombre.MaxLength = 100;
            this.Txt_Nombre.Name = "Txt_Nombre";
            this.Txt_Nombre.Size = new System.Drawing.Size(340, 27);
            this.Txt_Nombre.TabIndex = 3;
            this.Txt_Nombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pro_txt_nombre_keypress);
            // 
            // Lbl_InfoCronograma
            // 
            this.Lbl_InfoCronograma.AutoSize = true;
            this.Lbl_InfoCronograma.Font = new System.Drawing.Font("Rockwell", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_InfoCronograma.ForeColor = System.Drawing.Color.DimGray;
            this.Lbl_InfoCronograma.Location = new System.Drawing.Point(160, 104);
            this.Lbl_InfoCronograma.MaximumSize = new System.Drawing.Size(600, 0);
            this.Lbl_InfoCronograma.Name = "Lbl_InfoCronograma";
            this.Lbl_InfoCronograma.Size = new System.Drawing.Size(0, 20);
            this.Lbl_InfoCronograma.TabIndex = 4;
            // 
            // Lbl_Descripcion
            // 
            this.Lbl_Descripcion.AutoSize = true;
            this.Lbl_Descripcion.Font = new System.Drawing.Font("Rockwell", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Descripcion.Location = new System.Drawing.Point(540, 35);
            this.Lbl_Descripcion.Name = "Lbl_Descripcion";
            this.Lbl_Descripcion.Size = new System.Drawing.Size(210, 20);
            this.Lbl_Descripcion.TabIndex = 5;
            this.Lbl_Descripcion.Text = "Descripción (opcional):";
            // 
            // Txt_Descripcion
            // 
            this.Txt_Descripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_Descripcion.Font = new System.Drawing.Font("Rockwell", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Descripcion.Location = new System.Drawing.Point(540, 58);
            this.Txt_Descripcion.MaxLength = 1000;
            this.Txt_Descripcion.Multiline = true;
            this.Txt_Descripcion.Name = "Txt_Descripcion";
            this.Txt_Descripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Txt_Descripcion.Size = new System.Drawing.Size(605, 60);
            this.Txt_Descripcion.TabIndex = 6;
            // 
            // Lbl_Objetivo
            // 
            this.Lbl_Objetivo.AutoSize = true;
            this.Lbl_Objetivo.Font = new System.Drawing.Font("Rockwell", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Objetivo.Location = new System.Drawing.Point(540, 126);
            this.Lbl_Objetivo.Name = "Lbl_Objetivo";
            this.Lbl_Objetivo.Size = new System.Drawing.Size(179, 20);
            this.Lbl_Objetivo.TabIndex = 7;
            this.Lbl_Objetivo.Text = "Objetivo (opcional):";
            // 
            // Txt_Objetivo
            // 
            this.Txt_Objetivo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_Objetivo.Font = new System.Drawing.Font("Rockwell", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Objetivo.Location = new System.Drawing.Point(540, 149);
            this.Txt_Objetivo.MaxLength = 1000;
            this.Txt_Objetivo.Multiline = true;
            this.Txt_Objetivo.Name = "Txt_Objetivo";
            this.Txt_Objetivo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Txt_Objetivo.Size = new System.Drawing.Size(605, 60);
            this.Txt_Objetivo.TabIndex = 8;
            // 
            // Dgv_Rubricas
            // 
            this.Dgv_Rubricas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_Rubricas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dgv_Rubricas.Location = new System.Drawing.Point(0, 376);
            this.Dgv_Rubricas.Name = "Dgv_Rubricas";
            this.Dgv_Rubricas.RowHeadersWidth = 51;
            this.Dgv_Rubricas.Size = new System.Drawing.Size(1175, 304);
            this.Dgv_Rubricas.TabIndex = 3;
            this.Dgv_Rubricas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.pro_dgv_rubricas_cellclick);
            // 
            // Erp_Validacion
            // 
            this.Erp_Validacion.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.Erp_Validacion.ContainerControl = this;
            // 
            // Frm_Rubrica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1175, 680);
            this.Controls.Add(this.Dgv_Rubricas);
            this.Controls.Add(this.Gpb_Datos);
            this.Controls.Add(this.Pnl_Botones);
            this.Controls.Add(this.Pnl_Titulo);
            this.Font = new System.Drawing.Font("Rockwell", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(850, 550);
            this.Name = "Frm_Rubrica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "515 - Rúbricas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.pro_frm_rubrica_closing);
            this.Load += new System.EventHandler(this.pro_frm_rubrica_load);
            this.Pnl_Titulo.ResumeLayout(false);
            this.Pnl_Titulo.PerformLayout();
            this.Pnl_Botones.ResumeLayout(false);
            this.Gpb_Datos.ResumeLayout(false);
            this.Gpb_Datos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Rubricas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Erp_Validacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Pnl_Titulo;
        private System.Windows.Forms.Label Lbl_Titulo;
        private System.Windows.Forms.Label Lbl_CodigoAplicacion;
        private System.Windows.Forms.FlowLayoutPanel Pnl_Botones;
        private System.Windows.Forms.Button Btn_Ingresar;
        private System.Windows.Forms.Button Btn_Modificar;
        private System.Windows.Forms.Button Btn_Guardar;
        private System.Windows.Forms.Button Btn_Cancelar;
        private System.Windows.Forms.Button Btn_Eliminar;
        private System.Windows.Forms.Button Btn_Consultar;
        private System.Windows.Forms.Button Btn_Imprimir;
        private System.Windows.Forms.Button Btn_Refrescar;
        private System.Windows.Forms.Button Btn_Inicio;
        private System.Windows.Forms.Button Btn_Anterior;
        private System.Windows.Forms.Button Btn_Siguiente;
        private System.Windows.Forms.Button Btn_Fin;
        private System.Windows.Forms.Button Btn_Ayuda;
        private System.Windows.Forms.Button Btn_Salir;
        private System.Windows.Forms.GroupBox Gpb_Datos;
        private System.Windows.Forms.Label Lbl_Cronograma;
        private System.Windows.Forms.ComboBox Cbo_Cronograma;
        private System.Windows.Forms.Label Lbl_Nombre;
        private System.Windows.Forms.TextBox Txt_Nombre;
        private System.Windows.Forms.Label Lbl_InfoCronograma;
        private System.Windows.Forms.Label Lbl_Descripcion;
        private System.Windows.Forms.TextBox Txt_Descripcion;
        private System.Windows.Forms.Label Lbl_Objetivo;
        private System.Windows.Forms.TextBox Txt_Objetivo;
        private System.Windows.Forms.DataGridView Dgv_Rubricas;
        private System.Windows.Forms.ErrorProvider Erp_Validacion;
    }
}
