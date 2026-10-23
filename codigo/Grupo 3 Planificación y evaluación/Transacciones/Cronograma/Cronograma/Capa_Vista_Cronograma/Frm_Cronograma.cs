//Inicio de código de "Pablo José Quiroa Martínez" con carné: "0901-22-2929" en la fecha de: "20/10/2026"
using System;
using System.Drawing;
using System.Windows.Forms;
using Capa_Controlador_Cronograma;

namespace Capa_Vista_Cronograma
{
    // Formulario de mantenimiento del cronograma 
    public partial class Frm_Cronograma : Form
    {
        private readonly Cls_Controlador_Cronograma controlador = new Cls_Controlador_Cronograma();
        private int iIdSeleccionado = 0;
        private bool bCargandoCombos = false;   // evita que el combo dispare eventos mientras se llena

        public Frm_Cronograma()
        {
            InitializeComponent();

           
            this.Load += Frm_Cronograma_Load;
            Btn_Nuevo.Click += Btn_Nuevo_Click;
            Btn_Guardar.Click += Btn_Guardar_Click;
            Btn_Modificar.Click += Btn_Modificar_Click;
            Btn_Eliminar.Click += Btn_Eliminar_Click;
            Dgv_Cronograma.CellClick += Dgv_Cronograma_CellClick;
        }

        private void Frm_Cronograma_Load(object sender, EventArgs e)
        {
            pro_configurar_controles();
            try
            {
                pro_cargar_estados();
                pro_cargar_planificaciones();
                pro_cargar_grid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            pro_limpiar_campos();
        }


        // confguracion

        private void pro_configurar_controles()
        {
            this.MinimumSize = new Size(850, 550);   

            Txt_Id_Cronograma.ReadOnly = true;
            Cbo_Id_Planificacion.DropDownStyle = ComboBoxStyle.DropDownList;
            Cbo_Id_Actividad_Proyecto.DropDownStyle = ComboBoxStyle.DropDownList;
            Cbo_Cmp_Estado_Tarea_Cronograma.DropDownStyle = ComboBoxStyle.DropDownList;
            Txt_Cmp_Nombre_Tarea_Cronograma.MaxLength = 100;
            Txt_Cmp_Responsable_Tarea_Cronograma.MaxLength = 100;

            Dtp_Cmp_Fecha_Inicio_Cronograma.Format = DateTimePickerFormat.Short;
            Dtp_Cmp_Fecha_Fin_Cronograma.Format = DateTimePickerFormat.Short;

            
            foreach (Button btn in new[] { Btn_Nuevo, Btn_Guardar, Btn_Modificar, Btn_Eliminar })
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 1;
            }

            Dgv_Cronograma.ReadOnly = true;
            Dgv_Cronograma.AllowUserToAddRows = false;
            Dgv_Cronograma.AllowUserToDeleteRows = false;
            Dgv_Cronograma.MultiSelect = false;
            Dgv_Cronograma.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Dgv_Cronograma.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void pro_cargar_estados()
        {
            Cbo_Cmp_Estado_Tarea_Cronograma.Items.Clear();
            Cbo_Cmp_Estado_Tarea_Cronograma.Items.AddRange(controlador.fun_obtener_estados());
        }

        private void pro_cargar_planificaciones()
        {
            bCargandoCombos = true;
            Cbo_Id_Planificacion.DisplayMember = "Texto";
            Cbo_Id_Planificacion.ValueMember = "Id";
            Cbo_Id_Planificacion.DataSource = controlador.fun_listar_planificaciones();
            Cbo_Id_Planificacion.SelectedIndex = -1;
            bCargandoCombos = false;
        }

        // Carga solo las actividades del proyecto de la planificacio
        private void pro_cargar_actividades()
        {
            Cbo_Id_Actividad_Proyecto.DataSource = null;
            Cbo_Id_Actividad_Proyecto.Items.Clear();

            int iIdPlanificacion = fun_obtener_id_combo(Cbo_Id_Planificacion);
            if (iIdPlanificacion <= 0) return;

            try
            {
                Cbo_Id_Actividad_Proyecto.DisplayMember = "Texto";
                Cbo_Id_Actividad_Proyecto.ValueMember = "Id";
                Cbo_Id_Actividad_Proyecto.DataSource = controlador.fun_listar_actividades(iIdPlanificacion);
                Cbo_Id_Actividad_Proyecto.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pro_cargar_grid()
        {
            Dgv_Cronograma.DataSource = controlador.fun_listar();
            pro_configurar_encabezados();
        }

        private void pro_configurar_encabezados()
        {
            if (Dgv_Cronograma.Columns.Count == 0) return;

            Dgv_Cronograma.Columns["Id"].HeaderText = "ID";
            Dgv_Cronograma.Columns["IdPlanificacion"].Visible = false;
            Dgv_Cronograma.Columns["Planificacion"].HeaderText = "Planificación";
            Dgv_Cronograma.Columns["IdActividad"].Visible = false;
            Dgv_Cronograma.Columns["Actividad"].HeaderText = "Actividad";
            Dgv_Cronograma.Columns["Tarea"].HeaderText = "Tarea";
            Dgv_Cronograma.Columns["Descripcion"].HeaderText = "Descripción";
            Dgv_Cronograma.Columns["FechaInicio"].HeaderText = "Inicio";
            Dgv_Cronograma.Columns["FechaInicio"].DefaultCellStyle.Format = "dd/MM/yyyy";
            Dgv_Cronograma.Columns["FechaFin"].HeaderText = "Fin";
            Dgv_Cronograma.Columns["FechaFin"].DefaultCellStyle.Format = "dd/MM/yyyy";
            Dgv_Cronograma.Columns["Responsable"].HeaderText = "Responsable";
            Dgv_Cronograma.Columns["Estado"].HeaderText = "Estado";
            Dgv_Cronograma.Columns["Observaciones"].HeaderText = "Observaciones";
        }

        private void pro_limpiar_campos()
        {
            iIdSeleccionado = 0;
            Txt_Id_Cronograma.Text = "";

            bCargandoCombos = true;
            Cbo_Id_Planificacion.SelectedIndex = -1;
            bCargandoCombos = false;
            pro_cargar_actividades();   // deja vacio el combo de actividades

            Txt_Cmp_Nombre_Tarea_Cronograma.Text = "";
            Txt_Cmp_Descripcion_Cronograma.Text = "";
            Dtp_Cmp_Fecha_Inicio_Cronograma.Value = DateTime.Today;
            Dtp_Cmp_Fecha_Fin_Cronograma.Value = DateTime.Today;
            Txt_Cmp_Responsable_Tarea_Cronograma.Text = "";
            Cbo_Cmp_Estado_Tarea_Cronograma.SelectedItem = Cls_Controlador_Cronograma.sEstadoPorDefecto;
            Txt_Cmp_Observaciones_Cronograma.Text = "";
            Dgv_Cronograma.ClearSelection();

            Btn_Guardar.Enabled = true;
            Btn_Modificar.Enabled = false;
            Btn_Eliminar.Enabled = false;
            Cbo_Id_Planificacion.Focus();
        }


        

        private int fun_obtener_id_combo(ComboBox cbo)
        {
            return cbo.SelectedValue != null && int.TryParse(cbo.SelectedValue.ToString(), out int iId)
                ? iId
                : 0;
        }

        private string fun_obtener_estado()
        {
            return Cbo_Cmp_Estado_Tarea_Cronograma.SelectedItem?.ToString();
        }

        private void pro_mostrar_resultado(string sResultado, string sMensajeExito)
        {
            if (sResultado == "OK")
            {
                MessageBox.Show(sMensajeExito, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pro_cargar_grid();
                pro_limpiar_campos();
            }
            else
            {
                MessageBox.Show(sResultado, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        // Botones
        private void Btn_Nuevo_Click(object sender, EventArgs e)
        {
            pro_limpiar_campos();
        }

        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            string sResultado = controlador.fun_guardar(
                fun_obtener_id_combo(Cbo_Id_Planificacion),
                fun_obtener_id_combo(Cbo_Id_Actividad_Proyecto),
                Txt_Cmp_Nombre_Tarea_Cronograma.Text,
                Txt_Cmp_Descripcion_Cronograma.Text,
                Dtp_Cmp_Fecha_Inicio_Cronograma.Value,
                Dtp_Cmp_Fecha_Fin_Cronograma.Value,
                Txt_Cmp_Responsable_Tarea_Cronograma.Text,
                fun_obtener_estado(),
                Txt_Cmp_Observaciones_Cronograma.Text);

            pro_mostrar_resultado(sResultado, "Tarea del cronograma guardada correctamente.");
        }

        private void Btn_Modificar_Click(object sender, EventArgs e)
        {
            string sResultado = controlador.fun_modificar(
                iIdSeleccionado,
                fun_obtener_id_combo(Cbo_Id_Planificacion),
                fun_obtener_id_combo(Cbo_Id_Actividad_Proyecto),
                Txt_Cmp_Nombre_Tarea_Cronograma.Text,
                Txt_Cmp_Descripcion_Cronograma.Text,
                Dtp_Cmp_Fecha_Inicio_Cronograma.Value,
                Dtp_Cmp_Fecha_Fin_Cronograma.Value,
                Txt_Cmp_Responsable_Tarea_Cronograma.Text,
                fun_obtener_estado(),
                Txt_Cmp_Observaciones_Cronograma.Text);

            pro_mostrar_resultado(sResultado, "Tarea del cronograma modificada correctamente.");
        }

        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            DialogResult confirmar = MessageBox.Show(
                controlador.fun_mensaje_confirmacion_eliminar(iIdSeleccionado),
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmar != DialogResult.Yes) return;

            string sResultado = controlador.fun_eliminar(iIdSeleccionado);
            pro_mostrar_resultado(sResultado, "Tarea del cronograma eliminada correctamente.");
        }


        // Tabla

        private void Dgv_Cronograma_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = Dgv_Cronograma.Rows[e.RowIndex];
            iIdSeleccionado = Convert.ToInt32(fila.Cells["Id"].Value);
            Txt_Id_Cronograma.Text = iIdSeleccionado.ToString();

            // Primero la planificacion y luego la actibidad
            Cbo_Id_Planificacion.SelectedValue = Convert.ToInt32(fila.Cells["IdPlanificacion"].Value);
            Cbo_Id_Actividad_Proyecto.SelectedValue = Convert.ToInt32(fila.Cells["IdActividad"].Value);

            Txt_Cmp_Nombre_Tarea_Cronograma.Text = fila.Cells["Tarea"].Value?.ToString();
            Txt_Cmp_Descripcion_Cronograma.Text = fila.Cells["Descripcion"].Value?.ToString();
            Dtp_Cmp_Fecha_Inicio_Cronograma.Value = Convert.ToDateTime(fila.Cells["FechaInicio"].Value);
            Dtp_Cmp_Fecha_Fin_Cronograma.Value = Convert.ToDateTime(fila.Cells["FechaFin"].Value);
            Txt_Cmp_Responsable_Tarea_Cronograma.Text = fila.Cells["Responsable"].Value?.ToString();
            Cbo_Cmp_Estado_Tarea_Cronograma.SelectedItem = fila.Cells["Estado"].Value?.ToString();
            Txt_Cmp_Observaciones_Cronograma.Text = fila.Cells["Observaciones"].Value?.ToString();

            Btn_Guardar.Enabled = false;
            Btn_Modificar.Enabled = true;
            Btn_Eliminar.Enabled = true;
        }


        // 

        // Combos en cascada: al cambiar la planificacion se recargan las actividades
        private void Cbo_Id_Planificacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bCargandoCombos) return;
            pro_cargar_actividades();
        }

        // Eventos vacios que ya estaban conectados en el diseñador; se dejan para que no truene
        private void Txt_Id_Cronograma_TextChanged(object sender, EventArgs e) { }
        private void Cbo_Id_Actividad_Proyecto_SelectedIndexChanged(object sender, EventArgs e) { }
        private void Txt_Cmp_Nombre_Tarea_Cronograma_TextChanged(object sender, EventArgs e) { }
        private void Txt_Cmp_Descripcion_Cronograma_TextChanged(object sender, EventArgs e) { }
        private void Dtp_Cmp_Fecha_Inicio_Cronograma_ValueChanged(object sender, EventArgs e) { }
        private void Dtp_Cmp_Fecha_Fin_Cronograma_ValueChanged(object sender, EventArgs e) { }
        private void Txt_Cmp_Observaciones_Cronograma_TextChanged(object sender, EventArgs e) { }
        private void Txt_Cmp_Responsable_Tarea_Cronograma_TextChanged(object sender, EventArgs e) { }
        private void Cbo_Cmp_Estado_Tarea_Cronograma_SelectedIndexChanged(object sender, EventArgs e) { }
        private void Dgv_Cronograma_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void Btn_Nuevo_Click_1(object sender, EventArgs e)
        {

        }

        private void Btn_Guardar_Click_1(object sender, EventArgs e)
        {

        }

        private void Btn_Modificar_Click_1(object sender, EventArgs e)
        {

        }

        private void Btn_Eliminar_Click_1(object sender, EventArgs e)
        {

        }
    }
}
//Fin del código de "Pablo José Quiroa Martínez" con carné: "0901-22-2929" en la fecha de: "20/10/2026"