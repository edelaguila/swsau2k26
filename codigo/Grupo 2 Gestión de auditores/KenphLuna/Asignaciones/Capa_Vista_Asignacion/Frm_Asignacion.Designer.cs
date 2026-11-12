namespace Capa_Vista_Asignacion
{
    partial class Frm_Asignacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Asignacion));
            this.Cbo_Auditor = new System.Windows.Forms.ComboBox();
            this.Lbl_Asignacion = new System.Windows.Forms.Label();
            this.Lbl_Auditor = new System.Windows.Forms.Label();
            this.Lbl_Auditado = new System.Windows.Forms.Label();
            this.Lbl_EstadoAsignacion = new System.Windows.Forms.Label();
            this.Lbl_ActividadRubrica = new System.Windows.Forms.Label();
            this.Lbl_NombreAsig = new System.Windows.Forms.Label();
            this.Cbo_Auditado = new System.Windows.Forms.ComboBox();
            this.Cbo_EstadoAsignacion = new System.Windows.Forms.ComboBox();
            this.Cbo_ActividadRubrica = new System.Windows.Forms.ComboBox();
            this.Txt_IdAsignacion = new System.Windows.Forms.TextBox();
            this.Txt_NombreAsignacion = new System.Windows.Forms.TextBox();
            this.Lbl_FechaAsig = new System.Windows.Forms.Label();
            this.Dtp_FechaAsignacion = new System.Windows.Forms.DateTimePicker();
            this.Dgv_Asignaciones = new System.Windows.Forms.DataGridView();
            this.Dtp_FechaFinalizacion = new System.Windows.Forms.DateTimePicker();
            this.Lbl_FechaFin = new System.Windows.Forms.Label();
            this.Lbl_Descripcion = new System.Windows.Forms.Label();
            this.Txt_Descripcion = new System.Windows.Forms.TextBox();
            this.Lbl_Observaciones = new System.Windows.Forms.Label();
            this.Txt_Observaciones = new System.Windows.Forms.TextBox();
            this.Txt_Evidencia = new System.Windows.Forms.TextBox();
            this.Lbl_Evidencia = new System.Windows.Forms.Label();
            this.Btn_Imprimir = new System.Windows.Forms.Button();
            this.Btn_Eliminar = new System.Windows.Forms.Button();
            this.Btn_Cancelar = new System.Windows.Forms.Button();
            this.Btn_Ingresar = new System.Windows.Forms.Button();
            this.Btn_Modificar = new System.Windows.Forms.Button();
            this.Btn_Guardar = new System.Windows.Forms.Button();
            this.Btn_Refrescar = new System.Windows.Forms.Button();
            this.Btn_Inicio = new System.Windows.Forms.Button();
            this.Btn_Anterior = new System.Windows.Forms.Button();
            this.Btn_Siguiente = new System.Windows.Forms.Button();
            this.Btn_Fin = new System.Windows.Forms.Button();
            this.Btn_Salir = new System.Windows.Forms.Button();
            this.Btn_Ayuda = new System.Windows.Forms.Button();
            this.Gpb_Datos = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Asignaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // Cbo_Auditor
            // 
            this.Cbo_Auditor.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Cbo_Auditor.FormattingEnabled = true;
            this.Cbo_Auditor.Location = new System.Drawing.Point(690, 35);
            this.Cbo_Auditor.Name = "Cbo_Auditor";
            this.Cbo_Auditor.Size = new System.Drawing.Size(254, 28);
            this.Cbo_Auditor.TabIndex = 0;
            // 
            // Lbl_Asignacion
            // 
            this.Lbl_Asignacion.AutoSize = true;
            this.Lbl_Asignacion.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Lbl_Asignacion.Location = new System.Drawing.Point(20, 39);
            this.Lbl_Asignacion.Name = "Lbl_Asignacion";
            this.Lbl_Asignacion.TabIndex = 2;
            this.Lbl_Asignacion.Text = "ID asignación:";
            // 
            // Lbl_Auditor
            // 
            this.Lbl_Auditor.AutoSize = true;
            this.Lbl_Auditor.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Lbl_Auditor.Location = new System.Drawing.Point(520, 39);
            this.Lbl_Auditor.Name = "Lbl_Auditor";
            this.Lbl_Auditor.TabIndex = 3;
            this.Lbl_Auditor.Text = "Auditor:";
            // 
            // Lbl_Auditado
            // 
            this.Lbl_Auditado.AutoSize = true;
            this.Lbl_Auditado.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Lbl_Auditado.Location = new System.Drawing.Point(520, 79);
            this.Lbl_Auditado.Name = "Lbl_Auditado";
            this.Lbl_Auditado.TabIndex = 4;
            this.Lbl_Auditado.Text = "Auditado:";
            // 
            // Lbl_EstadoAsignacion
            // 
            this.Lbl_EstadoAsignacion.AutoSize = true;
            this.Lbl_EstadoAsignacion.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Lbl_EstadoAsignacion.Location = new System.Drawing.Point(520, 119);
            this.Lbl_EstadoAsignacion.Name = "Lbl_EstadoAsignacion";
            this.Lbl_EstadoAsignacion.TabIndex = 5;
            this.Lbl_EstadoAsignacion.Text = "Estado asignación:";
            // 
            // Lbl_ActividadRubrica
            // 
            this.Lbl_ActividadRubrica.AutoSize = true;
            this.Lbl_ActividadRubrica.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Lbl_ActividadRubrica.Location = new System.Drawing.Point(520, 159);
            this.Lbl_ActividadRubrica.Name = "Lbl_ActividadRubrica";
            this.Lbl_ActividadRubrica.TabIndex = 6;
            this.Lbl_ActividadRubrica.Text = "Actividad rúbrica:";
            // 
            // Lbl_NombreAsig
            // 
            this.Lbl_NombreAsig.AutoSize = true;
            this.Lbl_NombreAsig.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Lbl_NombreAsig.Location = new System.Drawing.Point(20, 79);
            this.Lbl_NombreAsig.Name = "Lbl_NombreAsig";
            this.Lbl_NombreAsig.TabIndex = 7;
            this.Lbl_NombreAsig.Text = "Nombre de la asignación:";
            // 
            // Cbo_Auditado
            // 
            this.Cbo_Auditado.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Cbo_Auditado.FormattingEnabled = true;
            this.Cbo_Auditado.Location = new System.Drawing.Point(690, 75);
            this.Cbo_Auditado.Name = "Cbo_Auditado";
            this.Cbo_Auditado.Size = new System.Drawing.Size(254, 28);
            this.Cbo_Auditado.TabIndex = 8;
            // 
            // Cbo_EstadoAsignacion
            // 
            this.Cbo_EstadoAsignacion.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Cbo_EstadoAsignacion.FormattingEnabled = true;
            this.Cbo_EstadoAsignacion.Location = new System.Drawing.Point(690, 115);
            this.Cbo_EstadoAsignacion.Name = "Cbo_EstadoAsignacion";
            this.Cbo_EstadoAsignacion.Size = new System.Drawing.Size(254, 28);
            this.Cbo_EstadoAsignacion.TabIndex = 8;
            // 
            // Cbo_ActividadRubrica
            // 
            this.Cbo_ActividadRubrica.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Cbo_ActividadRubrica.FormattingEnabled = true;
            this.Cbo_ActividadRubrica.Location = new System.Drawing.Point(690, 155);
            this.Cbo_ActividadRubrica.Name = "Cbo_ActividadRubrica";
            this.Cbo_ActividadRubrica.Size = new System.Drawing.Size(254, 28);
            this.Cbo_ActividadRubrica.TabIndex = 8;
            // 
            // Txt_IdAsignacion
            // 
            this.Txt_IdAsignacion.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Txt_IdAsignacion.Location = new System.Drawing.Point(240, 35);
            this.Txt_IdAsignacion.Name = "Txt_IdAsignacion";
            this.Txt_IdAsignacion.ReadOnly = true;
            this.Txt_IdAsignacion.Size = new System.Drawing.Size(120, 27);
            this.Txt_IdAsignacion.TabIndex = 8;
            // 
            // Txt_NombreAsignacion
            // 
            this.Txt_NombreAsignacion.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Txt_NombreAsignacion.Location = new System.Drawing.Point(240, 75);
            this.Txt_NombreAsignacion.Name = "Txt_NombreAsignacion";
            this.Txt_NombreAsignacion.Size = new System.Drawing.Size(250, 27);
            this.Txt_NombreAsignacion.TabIndex = 9;
            // 
            // Lbl_FechaAsig
            // 
            this.Lbl_FechaAsig.AutoSize = true;
            this.Lbl_FechaAsig.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Lbl_FechaAsig.Location = new System.Drawing.Point(20, 119);
            this.Lbl_FechaAsig.Name = "Lbl_FechaAsig";
            this.Lbl_FechaAsig.TabIndex = 10;
            this.Lbl_FechaAsig.Text = "Fecha de asignación:";
            // 
            // Dtp_FechaAsignacion
            // 
            this.Dtp_FechaAsignacion.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Dtp_FechaAsignacion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Dtp_FechaAsignacion.Location = new System.Drawing.Point(240, 115);
            this.Dtp_FechaAsignacion.Name = "Dtp_FechaAsignacion";
            this.Dtp_FechaAsignacion.Size = new System.Drawing.Size(250, 27);
            this.Dtp_FechaAsignacion.TabIndex = 11;
            // 
            // Dgv_Asignaciones
            // 
            this.Dgv_Asignaciones.AllowUserToAddRows = false;
            this.Dgv_Asignaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_Asignaciones.Location = new System.Drawing.Point(13, 528);
            this.Dgv_Asignaciones.MultiSelect = false;
            this.Dgv_Asignaciones.Name = "Dgv_Asignaciones";
            this.Dgv_Asignaciones.ReadOnly = true;
            this.Dgv_Asignaciones.RowHeadersWidth = 51;
            this.Dgv_Asignaciones.RowTemplate.Height = 24;
            this.Dgv_Asignaciones.Size = new System.Drawing.Size(964, 220);
            this.Dgv_Asignaciones.TabIndex = 6;
            this.Dgv_Asignaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Dgv_Asignaciones.BackgroundColor = System.Drawing.Color.White;
            this.Dgv_Asignaciones.RowHeadersVisible = false;
            this.Dgv_Asignaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Dgv_Asignaciones.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_Asignaciones_CellClick);
            this.Dgv_Asignaciones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_Asignaciones_CellContentClick);
            // 
            // Dtp_FechaFinalizacion
            // 
            this.Dtp_FechaFinalizacion.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Dtp_FechaFinalizacion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Dtp_FechaFinalizacion.Location = new System.Drawing.Point(240, 155);
            this.Dtp_FechaFinalizacion.Name = "Dtp_FechaFinalizacion";
            this.Dtp_FechaFinalizacion.Size = new System.Drawing.Size(250, 27);
            this.Dtp_FechaFinalizacion.TabIndex = 13;
            // 
            // Lbl_FechaFin
            // 
            this.Lbl_FechaFin.AutoSize = true;
            this.Lbl_FechaFin.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Lbl_FechaFin.Location = new System.Drawing.Point(20, 159);
            this.Lbl_FechaFin.Name = "Lbl_FechaFin";
            this.Lbl_FechaFin.TabIndex = 12;
            this.Lbl_FechaFin.Text = "Fecha finalización:";
            // 
            // Lbl_Descripcion
            // 
            this.Lbl_Descripcion.AutoSize = true;
            this.Lbl_Descripcion.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Lbl_Descripcion.Location = new System.Drawing.Point(20, 199);
            this.Lbl_Descripcion.Name = "Lbl_Descripcion";
            this.Lbl_Descripcion.TabIndex = 14;
            this.Lbl_Descripcion.Text = "Descripción:";
            // 
            // Txt_Descripcion
            // 
            this.Txt_Descripcion.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Txt_Descripcion.Location = new System.Drawing.Point(240, 195);
            this.Txt_Descripcion.Multiline = true;
            this.Txt_Descripcion.Name = "Txt_Descripcion";
            this.Txt_Descripcion.Size = new System.Drawing.Size(250, 70);
            this.Txt_Descripcion.TabIndex = 15;
            // 
            // Lbl_Observaciones
            // 
            this.Lbl_Observaciones.AutoSize = true;
            this.Lbl_Observaciones.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Lbl_Observaciones.Location = new System.Drawing.Point(520, 199);
            this.Lbl_Observaciones.Name = "Lbl_Observaciones";
            this.Lbl_Observaciones.TabIndex = 16;
            this.Lbl_Observaciones.Text = "Observaciones:";
            // 
            // Txt_Observaciones
            // 
            this.Txt_Observaciones.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Txt_Observaciones.Location = new System.Drawing.Point(690, 195);
            this.Txt_Observaciones.Multiline = true;
            this.Txt_Observaciones.Name = "Txt_Observaciones";
            this.Txt_Observaciones.Size = new System.Drawing.Size(254, 70);
            this.Txt_Observaciones.TabIndex = 17;
            // 
            // Txt_Evidencia
            // 
            this.Txt_Evidencia.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Txt_Evidencia.Location = new System.Drawing.Point(240, 275);
            this.Txt_Evidencia.Multiline = true;
            this.Txt_Evidencia.Name = "Txt_Evidencia";
            this.Txt_Evidencia.Size = new System.Drawing.Size(704, 50);
            this.Txt_Evidencia.TabIndex = 18;
            // 
            // Lbl_Evidencia
            // 
            this.Lbl_Evidencia.AutoSize = true;
            this.Lbl_Evidencia.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Lbl_Evidencia.Location = new System.Drawing.Point(20, 279);
            this.Lbl_Evidencia.Name = "Lbl_Evidencia";
            this.Lbl_Evidencia.TabIndex = 18;
            this.Lbl_Evidencia.Text = "Evidencia:";
            // 
            // Btn_Imprimir
            // 
            this.Btn_Imprimir.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.Btn_Imprimir.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Imprimir.Image")));
            this.Btn_Imprimir.Location = new System.Drawing.Point(553, 15);
            this.Btn_Imprimir.Name = "Btn_Imprimir";
            this.Btn_Imprimir.Size = new System.Drawing.Size(97, 93);
            this.Btn_Imprimir.TabIndex = 5;
            this.Btn_Imprimir.Text = "Imprimir";
            this.Btn_Imprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Imprimir.UseVisualStyleBackColor = true;
            this.Btn_Imprimir.Click += new System.EventHandler(this.Btn_Imprimir_Click);
            // 
            // Btn_Eliminar
            // 
            this.Btn_Eliminar.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.Btn_Eliminar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Eliminar.Image")));
            this.Btn_Eliminar.Location = new System.Drawing.Point(445, 15);
            this.Btn_Eliminar.Name = "Btn_Eliminar";
            this.Btn_Eliminar.Size = new System.Drawing.Size(97, 93);
            this.Btn_Eliminar.TabIndex = 4;
            this.Btn_Eliminar.Text = "Eliminar";
            this.Btn_Eliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Eliminar.UseVisualStyleBackColor = true;
            this.Btn_Eliminar.Click += new System.EventHandler(this.Btn_Eliminar_Click);
            // 
            // Btn_Cancelar
            // 
            this.Btn_Cancelar.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.Btn_Cancelar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Cancelar.Image")));
            this.Btn_Cancelar.Location = new System.Drawing.Point(337, 15);
            this.Btn_Cancelar.Name = "Btn_Cancelar";
            this.Btn_Cancelar.Size = new System.Drawing.Size(97, 93);
            this.Btn_Cancelar.TabIndex = 3;
            this.Btn_Cancelar.Text = "Cancelar";
            this.Btn_Cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Cancelar.UseVisualStyleBackColor = true;
            this.Btn_Cancelar.Click += new System.EventHandler(this.Btn_Cancelar_Click);
            // 
            // Btn_Ingresar
            // 
            this.Btn_Ingresar.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.Btn_Ingresar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Ingresar.Image")));
            this.Btn_Ingresar.Location = new System.Drawing.Point(13, 15);
            this.Btn_Ingresar.Name = "Btn_Ingresar";
            this.Btn_Ingresar.Size = new System.Drawing.Size(97, 93);
            this.Btn_Ingresar.TabIndex = 0;
            this.Btn_Ingresar.Text = "Ingresar";
            this.Btn_Ingresar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Ingresar.UseVisualStyleBackColor = true;
            this.Btn_Ingresar.Click += new System.EventHandler(this.Btn_Ingresar_Click);
            // 
            // Btn_Modificar
            // 
            this.Btn_Modificar.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.Btn_Modificar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Modificar.Image")));
            this.Btn_Modificar.Location = new System.Drawing.Point(121, 15);
            this.Btn_Modificar.Name = "Btn_Modificar";
            this.Btn_Modificar.Size = new System.Drawing.Size(97, 93);
            this.Btn_Modificar.TabIndex = 3;
            this.Btn_Modificar.Text = "Modificar";
            this.Btn_Modificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Modificar.UseVisualStyleBackColor = true;
            this.Btn_Modificar.Click += new System.EventHandler(this.Btn_Modificar_Click);
            // 
            // Btn_Guardar
            // 
            this.Btn_Guardar.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.Btn_Guardar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Guardar.Image")));
            this.Btn_Guardar.Location = new System.Drawing.Point(229, 15);
            this.Btn_Guardar.Name = "Btn_Guardar";
            this.Btn_Guardar.Size = new System.Drawing.Size(97, 93);
            this.Btn_Guardar.TabIndex = 3;
            this.Btn_Guardar.Text = "Guardar";
            this.Btn_Guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Guardar.UseVisualStyleBackColor = true;
            this.Btn_Guardar.Click += new System.EventHandler(this.Btn_Guardar_Click);
            // 
            // Btn_Refrescar
            // 
            this.Btn_Refrescar.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.Btn_Refrescar.Image = global::Capa_Vista_Asignacion.Properties.Resources.refresh_page_arrow_button_icon_icons_com_53909;
            this.Btn_Refrescar.Location = new System.Drawing.Point(661, 15);
            this.Btn_Refrescar.Name = "Btn_Refrescar";
            this.Btn_Refrescar.Size = new System.Drawing.Size(97, 93);
            this.Btn_Refrescar.TabIndex = 11;
            this.Btn_Refrescar.Text = "Refrescar";
            this.Btn_Refrescar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Refrescar.UseVisualStyleBackColor = true;
            this.Btn_Refrescar.Click += new System.EventHandler(this.Btn_Refrescar_Click);
            // 
            // Btn_Inicio
            // 
            this.Btn_Inicio.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.Btn_Inicio.Image = global::Capa_Vista_Asignacion.Properties.Resources.arrow_direction_left_undo_previous_backward_back_icon_250686;
            this.Btn_Inicio.Location = new System.Drawing.Point(13, 480);
            this.Btn_Inicio.Name = "Btn_Inicio";
            this.Btn_Inicio.Size = new System.Drawing.Size(120, 36);
            this.Btn_Inicio.TabIndex = 6;
            this.Btn_Inicio.Text = "Inicio";
            this.Btn_Inicio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Btn_Inicio.UseVisualStyleBackColor = true;
            this.Btn_Inicio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Btn_Inicio.Click += new System.EventHandler(this.Btn_Inicio_Click);
            // 
            // Btn_Anterior
            // 
            this.Btn_Anterior.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.Btn_Anterior.Image = global::Capa_Vista_Asignacion.Properties.Resources.direction_play_backward_arrow_next_previous_back_icon_250674;
            this.Btn_Anterior.Location = new System.Drawing.Point(143, 480);
            this.Btn_Anterior.Name = "Btn_Anterior";
            this.Btn_Anterior.Size = new System.Drawing.Size(120, 36);
            this.Btn_Anterior.TabIndex = 7;
            this.Btn_Anterior.Text = "Anterior";
            this.Btn_Anterior.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Btn_Anterior.UseVisualStyleBackColor = true;
            this.Btn_Anterior.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Btn_Anterior.Click += new System.EventHandler(this.Btn_Anterior_Click);
            // 
            // Btn_Siguiente
            // 
            this.Btn_Siguiente.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.Btn_Siguiente.Image = global::Capa_Vista_Asignacion.Properties.Resources.next_right_play_arrow_arrows_fast_forward_icon_250672;
            this.Btn_Siguiente.Location = new System.Drawing.Point(273, 480);
            this.Btn_Siguiente.Name = "Btn_Siguiente";
            this.Btn_Siguiente.Size = new System.Drawing.Size(120, 36);
            this.Btn_Siguiente.TabIndex = 8;
            this.Btn_Siguiente.Text = "Siguiente";
            this.Btn_Siguiente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Btn_Siguiente.UseVisualStyleBackColor = true;
            this.Btn_Siguiente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Btn_Siguiente.Click += new System.EventHandler(this.Btn_Siguiente_Click);
            // 
            // Btn_Fin
            // 
            this.Btn_Fin.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.Btn_Fin.Image = global::Capa_Vista_Asignacion.Properties.Resources.next_forward_player_multimedia_video_play_button_icon_250680__1_;
            this.Btn_Fin.Location = new System.Drawing.Point(403, 480);
            this.Btn_Fin.Name = "Btn_Fin";
            this.Btn_Fin.Size = new System.Drawing.Size(120, 36);
            this.Btn_Fin.TabIndex = 9;
            this.Btn_Fin.Text = "Fin";
            this.Btn_Fin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Btn_Fin.UseVisualStyleBackColor = true;
            this.Btn_Fin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Btn_Fin.Click += new System.EventHandler(this.Btn_Fin_Click);
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.Btn_Salir.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Salir.Image")));
            this.Btn_Salir.Location = new System.Drawing.Point(877, 15);
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(97, 93);
            this.Btn_Salir.TabIndex = 10;
            this.Btn_Salir.Text = "Salir";
            this.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Salir.UseVisualStyleBackColor = true;
            this.Btn_Salir.Click += new System.EventHandler(this.Btn_Salir_Click);
            // 
            // Btn_Ayuda
            // 
            this.Btn_Ayuda.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.Btn_Ayuda.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Ayuda.Image")));
            this.Btn_Ayuda.Location = new System.Drawing.Point(769, 15);
            this.Btn_Ayuda.Name = "Btn_Ayuda";
            this.Btn_Ayuda.Size = new System.Drawing.Size(97, 93);
            this.Btn_Ayuda.TabIndex = 11;
            this.Btn_Ayuda.Text = "Ayuda";
            this.Btn_Ayuda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Ayuda.UseVisualStyleBackColor = true;
            this.Btn_Ayuda.Click += new System.EventHandler(this.Btn_Ayuda_Click);
            // 
            // Frm_Asignacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 763);
            this.Controls.Add(this.Btn_Ingresar);
            this.Controls.Add(this.Btn_Modificar);
            this.Controls.Add(this.Btn_Guardar);
            this.Controls.Add(this.Btn_Cancelar);
            this.Controls.Add(this.Btn_Eliminar);
            this.Controls.Add(this.Btn_Imprimir);
            this.Controls.Add(this.Btn_Refrescar);
            this.Controls.Add(this.Btn_Ayuda);
            this.Controls.Add(this.Btn_Salir);
            // 
            // Gpb_Datos
            // 
            this.Gpb_Datos.Location = new System.Drawing.Point(13, 123);
            this.Gpb_Datos.Size = new System.Drawing.Size(964, 345);
            this.Gpb_Datos.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Gpb_Datos.TabStop = false;
            this.Gpb_Datos.Text = "Datos de la asignación";
            this.Gpb_Datos.Name = "Gpb_Datos";
            this.Controls.Add(this.Gpb_Datos);
            this.Gpb_Datos.Controls.Add(this.Lbl_Asignacion);
            this.Gpb_Datos.Controls.Add(this.Txt_IdAsignacion);
            this.Gpb_Datos.Controls.Add(this.Lbl_NombreAsig);
            this.Gpb_Datos.Controls.Add(this.Txt_NombreAsignacion);
            this.Gpb_Datos.Controls.Add(this.Lbl_FechaAsig);
            this.Gpb_Datos.Controls.Add(this.Dtp_FechaAsignacion);
            this.Gpb_Datos.Controls.Add(this.Lbl_FechaFin);
            this.Gpb_Datos.Controls.Add(this.Dtp_FechaFinalizacion);
            this.Gpb_Datos.Controls.Add(this.Lbl_Auditor);
            this.Gpb_Datos.Controls.Add(this.Cbo_Auditor);
            this.Gpb_Datos.Controls.Add(this.Lbl_Auditado);
            this.Gpb_Datos.Controls.Add(this.Cbo_Auditado);
            this.Gpb_Datos.Controls.Add(this.Lbl_EstadoAsignacion);
            this.Gpb_Datos.Controls.Add(this.Cbo_EstadoAsignacion);
            this.Gpb_Datos.Controls.Add(this.Lbl_ActividadRubrica);
            this.Gpb_Datos.Controls.Add(this.Cbo_ActividadRubrica);
            this.Gpb_Datos.Controls.Add(this.Lbl_Descripcion);
            this.Gpb_Datos.Controls.Add(this.Txt_Descripcion);
            this.Gpb_Datos.Controls.Add(this.Lbl_Observaciones);
            this.Gpb_Datos.Controls.Add(this.Txt_Observaciones);
            this.Gpb_Datos.Controls.Add(this.Lbl_Evidencia);
            this.Gpb_Datos.Controls.Add(this.Txt_Evidencia);
            this.Controls.Add(this.Btn_Inicio);
            this.Controls.Add(this.Btn_Anterior);
            this.Controls.Add(this.Btn_Siguiente);
            this.Controls.Add(this.Btn_Fin);
            this.Controls.Add(this.Dgv_Asignaciones);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "Frm_Asignacion";
            this.Text = "Asignaciones";
            this.Load += new System.EventHandler(this.Frm_Asignacion_Load);
            this.Resize += new System.EventHandler(this.Frm_Asignacion_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Asignaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox Cbo_Auditor;
        private System.Windows.Forms.Button Btn_Ingresar;
        private System.Windows.Forms.Button Btn_Salir;
        private System.Windows.Forms.Button Btn_Fin;
        private System.Windows.Forms.Button Btn_Siguiente;
        private System.Windows.Forms.Button Btn_Anterior;
        private System.Windows.Forms.Button Btn_Inicio;
        private System.Windows.Forms.Button Btn_Imprimir;
        private System.Windows.Forms.Button Btn_Eliminar;
        private System.Windows.Forms.Button Btn_Cancelar;
        private System.Windows.Forms.Button Btn_Modificar;
        private System.Windows.Forms.Button Btn_Guardar;
        private System.Windows.Forms.Label Lbl_Auditado;
        private System.Windows.Forms.Label Lbl_Auditor;
        private System.Windows.Forms.Label Lbl_Asignacion;
        private System.Windows.Forms.Label Lbl_NombreAsig;
        private System.Windows.Forms.Label Lbl_EstadoAsignacion;
        private System.Windows.Forms.Label Lbl_ActividadRubrica;
        private System.Windows.Forms.DateTimePicker Dtp_FechaAsignacion;
        private System.Windows.Forms.Label Lbl_FechaAsig;
        private System.Windows.Forms.TextBox Txt_NombreAsignacion;
        private System.Windows.Forms.TextBox Txt_IdAsignacion;
        private System.Windows.Forms.ComboBox Cbo_ActividadRubrica;
        private System.Windows.Forms.ComboBox Cbo_EstadoAsignacion;
        private System.Windows.Forms.ComboBox Cbo_Auditado;
        private System.Windows.Forms.DataGridView Dgv_Asignaciones;
        private System.Windows.Forms.TextBox Txt_Observaciones;
        private System.Windows.Forms.Label Lbl_Observaciones;
        private System.Windows.Forms.TextBox Txt_Descripcion;
        private System.Windows.Forms.Label Lbl_Descripcion;
        private System.Windows.Forms.DateTimePicker Dtp_FechaFinalizacion;
        private System.Windows.Forms.Label Lbl_FechaFin;
        private System.Windows.Forms.Label Lbl_Evidencia;
        private System.Windows.Forms.TextBox Txt_Evidencia;
        private System.Windows.Forms.Button Btn_Ayuda;
        private System.Windows.Forms.Button Btn_Refrescar;
        private System.Windows.Forms.GroupBox Gpb_Datos;
    }
}