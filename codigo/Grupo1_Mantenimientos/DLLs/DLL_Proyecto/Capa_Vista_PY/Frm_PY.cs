using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Capa_Controlador_PY;

namespace Capa_Vista_PY
{
    // Formulario secundario de mantenimiento de Proyectos (Área 1 - Mostaza)
    public partial class Frm_PY : Form
    {
        private readonly Cls_Controlador_PY ctrControlador = new Cls_Controlador_PY();

        // Estándar ES-01: color Área 1 y fuente Rockwell (Título 18, Subtítulo 11, Texto 10)
        private readonly Color gColorBase = Color.FromArgb(255, 177, 0);
        private readonly Color gColorTexto = Color.FromArgb(40, 40, 40);
        private readonly Font gFuenteTitulo = new Font("Rockwell", 18F, FontStyle.Bold);
        private readonly Font gFuenteSubtitulo = new Font("Rockwell", 11F, FontStyle.Bold);
        private readonly Font gFuenteTexto = new Font("Rockwell", 10F);

        private bool gbEdicion = false; // false = registro nuevo, true = registro existente seleccionado

        private Panel Pnl_Encabezado, Pnl_Botones;
        private Label Lbl_Titulo, Lbl_Id, Lbl_Estado, Lbl_Nombre, Lbl_Inicio, Lbl_Fin, Lbl_Descripcion, Lbl_Objetivo;
        private GroupBox Gpb_Datos;
        private TextBox Txt_Id, Txt_Nombre, Txt_Descripcion, Txt_Objetivo;
        private ComboBox Cbo_Estado;
        private DateTimePicker Dtp_Inicio, Dtp_Fin;
        private Button Btn_Nuevo, Btn_Guardar, Btn_Modificar, Btn_Eliminar, Btn_Cancelar;
        private DataGridView Dgv_Proyectos;

        public Frm_PY()
        {
            InitializeComponent(); // Llama a la inicialización del diseñador
            pro_construir_formulario();
        }

        // ---------- Evento Load (Generado por el Diseñador) ----------
        private void Frm_PY_Load(object sender, EventArgs e)
        {
            pro_cargar_estados();
            pro_cargar_proyectos();
            pro_nuevo();
        }

        // ---------- Construcción de la interfaz ----------
        private void pro_construir_formulario()
        {
            Name = "Frm_PY";
            Text = "Proyectos";
            Font = gFuenteTexto;
            Size = new Size(1000, 650);
            MinimumSize = new Size(850, 550);      // Resolución mínima del estándar
            StartPosition = FormStartPosition.CenterScreen;
            MinimizeBox = true; MaximizeBox = true; ControlBox = true; // Botones habilitados

            // Encabezado
            Pnl_Encabezado = new Panel { Name = "Pnl_Encabezado", Dock = DockStyle.Top, Height = 60, BackColor = gColorBase };
            Lbl_Titulo = new Label
            {
                Name = "Lbl_Titulo",
                Text = "Gestión de Proyectos",
                Dock = DockStyle.Fill,
                Font = gFuenteTitulo,
                ForeColor = gColorTexto,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(15, 0, 0, 0)
            };
            Pnl_Encabezado.Controls.Add(Lbl_Titulo);

            // Botones (Flat, sin borde grueso ni sombreado)
            Pnl_Botones = new Panel { Name = "Pnl_Botones", Dock = DockStyle.Top, Height = 55, Padding = new Padding(10) };
            Btn_Nuevo = fun_crear_boton("Btn_Nuevo", "Nuevo", 10);
            Btn_Guardar = fun_crear_boton("Btn_Guardar", "Guardar", 140);
            Btn_Modificar = fun_crear_boton("Btn_Modificar", "Modificar", 270);
            Btn_Eliminar = fun_crear_boton("Btn_Eliminar", "Eliminar", 400);
            Btn_Cancelar = fun_crear_boton("Btn_Cancelar", "Cancelar", 530);
            Pnl_Botones.Controls.AddRange(new Control[] { Btn_Nuevo, Btn_Guardar, Btn_Modificar, Btn_Eliminar, Btn_Cancelar });

            // Datos
            Gpb_Datos = new GroupBox { Name = "Gpb_Datos", Text = "Datos del proyecto", Dock = DockStyle.Top, Height = 255, Font = gFuenteSubtitulo };

            Lbl_Id = fun_crear_label("Lbl_Id", "Código:", 20, 38);
            Txt_Id = new TextBox { Name = "Txt_Id", Location = new Point(150, 35), Width = 120, ReadOnly = true, Font = gFuenteTexto };

            Lbl_Estado = fun_crear_label("Lbl_Estado", "Estado:", 20, 78);
            Cbo_Estado = new ComboBox { Name = "Cbo_Estado", Location = new Point(150, 75), Width = 270, DropDownStyle = ComboBoxStyle.DropDownList, Font = gFuenteTexto };

            Lbl_Nombre = fun_crear_label("Lbl_Nombre", "Nombre:", 20, 118);
            Txt_Nombre = new TextBox { Name = "Txt_Nombre", Location = new Point(150, 115), Width = 270, MaxLength = 100, Font = gFuenteTexto };

            Lbl_Inicio = fun_crear_label("Lbl_Inicio", "Fecha inicio:", 20, 158);
            Dtp_Inicio = new DateTimePicker { Name = "Dtp_Inicio", Location = new Point(150, 155), Width = 170, Format = DateTimePickerFormat.Short, ShowCheckBox = true, Font = gFuenteTexto };

            Lbl_Fin = fun_crear_label("Lbl_Fin", "Fecha fin:", 20, 198);
            Dtp_Fin = new DateTimePicker { Name = "Dtp_Fin", Location = new Point(150, 195), Width = 170, Format = DateTimePickerFormat.Short, ShowCheckBox = true, Font = gFuenteTexto };

            Lbl_Descripcion = fun_crear_label("Lbl_Descripcion", "Descripción:", 470, 35);
            Txt_Descripcion = new TextBox
            {
                Name = "Txt_Descripcion",
                Location = new Point(470, 60),
                Size = new Size(440, 70),
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                Font = gFuenteTexto
            };

            Lbl_Objetivo = fun_crear_label("Lbl_Objetivo", "Objetivo:", 470, 140);
            Txt_Objetivo = new TextBox
            {
                Name = "Txt_Objetivo",
                Location = new Point(470, 165),
                Size = new Size(440, 70),
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                Font = gFuenteTexto
            };

            Gpb_Datos.Controls.AddRange(new Control[]
            {
                Lbl_Id, Txt_Id, Lbl_Estado, Cbo_Estado, Lbl_Nombre, Txt_Nombre,
                Lbl_Inicio, Dtp_Inicio, Lbl_Fin, Dtp_Fin,
                Lbl_Descripcion, Txt_Descripcion, Lbl_Objetivo, Txt_Objetivo
            });

            // Grid
            Dgv_Proyectos = new DataGridView
            {
                Name = "Dgv_Proyectos",
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                RowHeadersVisible = false,
                EnableHeadersVisualStyles = false,
                Font = gFuenteTexto
            };
            Dgv_Proyectos.ColumnHeadersDefaultCellStyle.BackColor = gColorBase;
            Dgv_Proyectos.ColumnHeadersDefaultCellStyle.ForeColor = gColorTexto;
            Dgv_Proyectos.ColumnHeadersDefaultCellStyle.Font = gFuenteSubtitulo;
            Dgv_Proyectos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 217, 128);
            Dgv_Proyectos.DefaultCellStyle.SelectionForeColor = gColorTexto;

            // Orden: el último en agregarse queda hasta arriba
            Controls.Add(Dgv_Proyectos);
            Controls.Add(Gpb_Datos);
            Controls.Add(Pnl_Botones);
            Controls.Add(Pnl_Encabezado);

            // Eventos
            Btn_Nuevo.Click += (s, e) => pro_nuevo();
            Btn_Guardar.Click += (s, e) => pro_guardar();
            Btn_Modificar.Click += (s, e) => pro_modificar();
            Btn_Eliminar.Click += (s, e) => pro_eliminar();
            Btn_Cancelar.Click += (s, e) => pro_nuevo();
            Dgv_Proyectos.CellClick += (s, e) =>
            {
                if (e.RowIndex >= 0) pro_cargar_fila(Dgv_Proyectos.Rows[e.RowIndex]);
            };
        }

        private Label fun_crear_label(string sNombre, string sTexto, int iX, int iY)
        {
            return new Label { Name = sNombre, Text = sTexto, Location = new Point(iX, iY), AutoSize = true, Font = gFuenteTexto };
        }

        private Button fun_crear_boton(string sNombre, string sTexto, int iX)
        {
            Button btn = new Button
            {
                Name = sNombre,
                Text = sTexto,
                Location = new Point(iX, 8),
                Size = new Size(120, 38),
                FlatStyle = FlatStyle.Flat,
                BackColor = gColorBase,
                ForeColor = gColorTexto,
                Font = gFuenteTexto,
                Cursor = Cursors.Hand,
                TextImageRelation = TextImageRelation.ImageBeforeText
            };
            btn.FlatAppearance.BorderSize = 0;
            return btn;
        }

        // ---------- Carga de datos ----------
        private void pro_cargar_estados()
        {
            try
            {
                Cbo_Estado.DisplayMember = "Nombre";
                Cbo_Estado.ValueMember = "Id";
                Cbo_Estado.DataSource = ctrControlador.fun_obtener_estados();
            }
            catch (Exception ex) { MessageBox.Show("Error al cargar estados: " + ex.Message, "Proyectos", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void pro_cargar_proyectos()
        {
            try
            {
                Dgv_Proyectos.DataSource = ctrControlador.fun_obtener_proyectos();
                Dgv_Proyectos.Columns["Pk_Id_Proyecto"].HeaderText = "Código";
                Dgv_Proyectos.Columns["Fk_Id_Proyecto_Estado"].Visible = false;
                Dgv_Proyectos.Columns["Cmp_Nombre_Proyecto_Estado"].HeaderText = "Estado";
                Dgv_Proyectos.Columns["Cmp_Nombre_Proyecto"].HeaderText = "Nombre";
                Dgv_Proyectos.Columns["Cmp_Descripcion_Proyecto"].HeaderText = "Descripción";
                Dgv_Proyectos.Columns["Cmp_Fecha_Inicio_Proyecto"].HeaderText = "Fecha inicio";
                Dgv_Proyectos.Columns["Cmp_Fecha_Fin_Proyecto"].HeaderText = "Fecha fin";
                Dgv_Proyectos.Columns["Cmp_Objetivo_Proyecto"].HeaderText = "Objetivo";
                Dgv_Proyectos.Columns["Cmp_Fecha_Inicio_Proyecto"].DefaultCellStyle.Format = "dd/MM/yyyy";
                Dgv_Proyectos.Columns["Cmp_Fecha_Fin_Proyecto"].DefaultCellStyle.Format = "dd/MM/yyyy";
                Dgv_Proyectos.ClearSelection();
            }
            catch (Exception ex) { MessageBox.Show("Error al cargar proyectos: " + ex.Message, "Proyectos", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void pro_cargar_fila(DataGridViewRow fila)
        {
            gbEdicion = true;
            Txt_Id.Text = Convert.ToString(fila.Cells["Pk_Id_Proyecto"].Value);
            Cbo_Estado.SelectedValue = Convert.ToInt32(fila.Cells["Fk_Id_Proyecto_Estado"].Value);
            Txt_Nombre.Text = Convert.ToString(fila.Cells["Cmp_Nombre_Proyecto"].Value);
            Txt_Descripcion.Text = Convert.ToString(fila.Cells["Cmp_Descripcion_Proyecto"].Value);
            Txt_Objetivo.Text = Convert.ToString(fila.Cells["Cmp_Objetivo_Proyecto"].Value);
            pro_asignar_fecha(Dtp_Inicio, fila.Cells["Cmp_Fecha_Inicio_Proyecto"].Value);
            pro_asignar_fecha(Dtp_Fin, fila.Cells["Cmp_Fecha_Fin_Proyecto"].Value);
            pro_estado_botones();
        }

        private void pro_asignar_fecha(DateTimePicker dtp, object oValor)
        {
            if (oValor == null || oValor == DBNull.Value) { dtp.Value = DateTime.Today; dtp.Checked = false; }
            else { dtp.Value = Convert.ToDateTime(oValor); dtp.Checked = true; }
        }

        // ---------- Acciones ----------
        private void pro_nuevo()
        {
            gbEdicion = false;
            try { Txt_Id.Text = ctrControlador.fun_siguiente_id().ToString(); }
            catch (Exception ex) { MessageBox.Show("Error al obtener el código: " + ex.Message, "Proyectos", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            Cbo_Estado.SelectedIndex = Cbo_Estado.Items.Count > 0 ? 0 : -1;
            Txt_Nombre.Clear(); Txt_Descripcion.Clear(); Txt_Objetivo.Clear();
            Dtp_Inicio.Value = DateTime.Today; Dtp_Inicio.Checked = false;
            Dtp_Fin.Value = DateTime.Today; Dtp_Fin.Checked = false;
            Dgv_Proyectos.ClearSelection();
            pro_estado_botones();
            Txt_Nombre.Focus();
        }

        private void pro_guardar()
        {
            string sError = ctrControlador.fun_insertar_proyecto(
                int.Parse(Txt_Id.Text), fun_estado_seleccionado(), Txt_Nombre.Text, Txt_Descripcion.Text,
                fun_fecha(Dtp_Inicio), fun_fecha(Dtp_Fin), Txt_Objetivo.Text);

            if (sError != "") { MessageBox.Show(sError, "Proyectos", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            MessageBox.Show("Proyecto guardado correctamente.", "Proyectos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            pro_cargar_proyectos();
            pro_nuevo();
        }

        private void pro_modificar()
        {
            string sError = ctrControlador.fun_modificar_proyecto(
                int.Parse(Txt_Id.Text), fun_estado_seleccionado(), Txt_Nombre.Text, Txt_Descripcion.Text,
                fun_fecha(Dtp_Inicio), fun_fecha(Dtp_Fin), Txt_Objetivo.Text);

            if (sError != "") { MessageBox.Show(sError, "Proyectos", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            MessageBox.Show("Proyecto modificado correctamente.", "Proyectos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            pro_cargar_proyectos();
            pro_nuevo();
        }

        private void pro_eliminar()
        {
            if (MessageBox.Show("¿Desea eliminar el proyecto seleccionado?", "Proyectos",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            string sError = ctrControlador.fun_eliminar_proyecto(int.Parse(Txt_Id.Text));
            if (sError != "") { MessageBox.Show(sError, "Proyectos", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            MessageBox.Show("Proyecto eliminado correctamente.", "Proyectos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            pro_cargar_proyectos();
            pro_nuevo();
        }

        // ---------- Auxiliares ----------
        private void pro_estado_botones()
        {
            Btn_Guardar.Enabled = !gbEdicion;
            Btn_Modificar.Enabled = gbEdicion;
            Btn_Eliminar.Enabled = gbEdicion;
        }

        private int fun_estado_seleccionado()
        {
            return Cbo_Estado.SelectedValue == null ? 0 : Convert.ToInt32(Cbo_Estado.SelectedValue);
        }

        private DateTime? fun_fecha(DateTimePicker dtp)
        {
            if (dtp.Checked) return dtp.Value.Date;
            return null;
        }
    }
}