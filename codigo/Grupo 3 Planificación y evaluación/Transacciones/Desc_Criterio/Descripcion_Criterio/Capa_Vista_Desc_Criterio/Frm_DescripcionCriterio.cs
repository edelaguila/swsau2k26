using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Controlador_Desc_Criterio;

namespace Capa_Vista_Desc_Criterio
{
    public partial class Frm_DescripcionCriterio : Form
    {
        private readonly Cls_Controlador_DC gControlador = new Cls_Controlador_DC();
        private readonly Color gColorModulo = Color.FromArgb(255, 224, 0);   // Color del área (estándar ES-01)
        private int gIdSeleccionado = 0;
        private bool gCargando = false;
        public Frm_DescripcionCriterio()
        {
            InitializeComponent();
            pro_aplicar_estilo();
            pro_configurar_controles();
            Load += pro_formulario_load;
        }
        private void pro_aplicar_estilo()
        {
            Text = "Descripción de Criterios";
            MinimumSize = new Size(850, 550);                      // Ventana secundaria: mínimo 850x550
            ControlBox = true;
            MinimizeBox = true;
            MaximizeBox = true;

            Gpb_Datos.Font = new Font("Rockwell", 10f);                     // Subtítulo 10 (estándar)
            foreach (Control ctlHijo in Gpb_Datos.Controls) ctlHijo.Font = new Font("Rockwell", 10f);


            Dgv_DescripcionCriterio.BackgroundColor = Color.White;
        }

        // ---------- Configuración de controles y eventos ----------
        private void pro_configurar_controles()
        {
            Cbo_Criterio.DropDownStyle = ComboBoxStyle.DropDownList;
            Cbo_Escala.DropDownStyle = ComboBoxStyle.DropDownList;

            // Funciona con TextBox o RichTextBox (ambos heredan de TextBoxBase)
            foreach (TextBoxBase txtCaja in new TextBoxBase[] { Txt_DescripcionDetallada, Txt_EvidenciaRequerida, Txt_Observaciones })
            {
                txtCaja.Multiline = true;
            }

            DataGridView dgvTabla = Dgv_DescripcionCriterio;
            dgvTabla.ReadOnly = true;
            dgvTabla.AllowUserToAddRows = false;
            dgvTabla.AllowUserToDeleteRows = false;
            dgvTabla.MultiSelect = false;
            dgvTabla.RowHeadersVisible = false;
            dgvTabla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTabla.AutoGenerateColumns = false;
            dgvTabla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTabla.Columns.Clear();
            dgvTabla.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID", FillWeight = 7 });
            dgvTabla.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Criterio", HeaderText = "Criterio", FillWeight = 25 });
            dgvTabla.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Porcentaje", HeaderText = "%", FillWeight = 6 });
            dgvTabla.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nivel", HeaderText = "Nivel", FillWeight = 13 });
            dgvTabla.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DescripcionDetallada", HeaderText = "Descripción detallada", FillWeight = 30 });
            dgvTabla.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "EvidenciaRequerida", HeaderText = "Evidencia requerida", FillWeight = 20 });
            dgvTabla.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Observaciones", HeaderText = "Observaciones", FillWeight = 17 });

            Btn_Nuevo.Click += (sender, e) => pro_limpiar();
            Btn_Cancelar.Click += (sender, e) => pro_limpiar();
            Btn_Guardar.Click += pro_guardar_click;
            Btn_Eliminar.Click += pro_eliminar_click;
            Cbo_Criterio.SelectedIndexChanged += pro_criterio_cambiado;
            Chk_FiltrarCriterio.CheckedChanged += (sender, e) => pro_cargar_grilla();
            Dgv_DescripcionCriterio.SelectionChanged += pro_seleccion_cambiada;
        }

        private void pro_formulario_load(object sender, EventArgs e)
        {
            pro_cargar_combos();
            pro_cargar_grilla();
            pro_limpiar();
        }

        // ---------- Carga de datos ----------
        private void pro_cargar_combos()
        {
            gCargando = true;
            try
            {
                Cbo_Escala.DisplayMember = "Cmp_Nombre_Mostrado";
                Cbo_Escala.ValueMember = "Pk_Id_Escala";
                Cbo_Escala.DataSource = gControlador.fun_listar_escalas();

                Cbo_Criterio.DisplayMember = "Cmp_Nombre_Mostrado";
                Cbo_Criterio.ValueMember = "Pk_Id_Criterio";
                Cbo_Criterio.DataSource = gControlador.fun_listar_criterios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los criterios o la escala: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { gCargando = false; }
        }

        private void pro_cargar_grilla()
        {
            gCargando = true;
            try
            {
                int iFiltro = Chk_FiltrarCriterio.Checked ? fun_obtener_id(Cbo_Criterio, "Pk_Id_Criterio") : 0;
                Dgv_DescripcionCriterio.DataSource = null;
                Dgv_DescripcionCriterio.DataSource = gControlador.fun_listar(iFiltro);
                Dgv_DescripcionCriterio.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar la lista: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { gCargando = false; }
            pro_actualizar_resumen();
        }

        private int fun_obtener_id(ComboBox cboCombo, string sColumna)
        {
            DataRowView drvFila = cboCombo.SelectedItem as DataRowView;
            return drvFila == null ? 0 : Convert.ToInt32(drvFila[sColumna]);
        }

        private void pro_actualizar_resumen()
        {
            var rResumen = gControlador.fun_resumen_niveles(fun_obtener_id(Cbo_Criterio, "Pk_Id_Criterio"));
            Lbl_Resumen.Text = rResumen.sTexto;
            Lbl_Resumen.ForeColor = rResumen.bCompleto ? Color.FromArgb(21, 130, 70) : Color.DimGray;
        }

        // Al registrar, propone el primer nivel que aún no tiene descripción
        private void pro_seleccionar_nivel_faltante()
        {
            int iIdEscala = gControlador.fun_primer_nivel_faltante(fun_obtener_id(Cbo_Criterio, "Pk_Id_Criterio"));
            if (iIdEscala > 0) Cbo_Escala.SelectedValue = iIdEscala;
            else if (Cbo_Escala.Items.Count > 0) Cbo_Escala.SelectedIndex = 0;
        }

        // ---------- Eventos ----------
        private void pro_criterio_cambiado(object sender, EventArgs e)
        {
            if (gCargando) return;
            if (Chk_FiltrarCriterio.Checked) pro_cargar_grilla();
            if (gIdSeleccionado == 0) pro_seleccionar_nivel_faltante();
            pro_actualizar_resumen();
        }

        private void pro_seleccion_cambiada(object sender, EventArgs e)
        {
            DataGridViewRow dgvrFila = Dgv_DescripcionCriterio.CurrentRow;
            if (gCargando || dgvrFila == null || !dgvrFila.Selected) return;
            DataRowView drvFila = dgvrFila.DataBoundItem as DataRowView;
            if (drvFila == null) return;
            DataRow drFila = drvFila.Row;

            gCargando = true;
            try
            {
                gIdSeleccionado = Convert.ToInt32(drFila["Id"]);
                Cbo_Criterio.SelectedValue = Convert.ToInt32(drFila["IdCriterio"]);
                Cbo_Escala.SelectedValue = Convert.ToInt32(drFila["IdEscala"]);
                Txt_DescripcionDetallada.Text = drFila["DescripcionDetallada"].ToString();
                Txt_EvidenciaRequerida.Text = drFila["EvidenciaRequerida"].ToString();
                Txt_Observaciones.Text = drFila["Observaciones"].ToString();
            }
            finally { gCargando = false; }

            Btn_Eliminar.Enabled = true;
            Btn_Guardar.Text = "Actualizar";
            pro_actualizar_resumen();
        }

        private void pro_guardar_click(object sender, EventArgs e)
        {
            var rResultado = gControlador.fun_guardar(
                gIdSeleccionado,
                fun_obtener_id(Cbo_Criterio, "Pk_Id_Criterio"),
                fun_obtener_id(Cbo_Escala, "Pk_Id_Escala"),
                Txt_DescripcionDetallada.Text.Trim(),
                Txt_EvidenciaRequerida.Text.Trim(),
                Txt_Observaciones.Text.Trim());

            MessageBox.Show(rResultado.sMensaje, rResultado.bOk ? "Información" : "Atención",
                MessageBoxButtons.OK, rResultado.bOk ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            if (rResultado.bOk) { pro_cargar_grilla(); pro_limpiar(); }
        }

        private void pro_eliminar_click(object sender, EventArgs e)
        {
            if (gIdSeleccionado == 0) return;
            DialogResult drConfirmacion = MessageBox.Show("¿Eliminar esta descripción?", "Confirmar eliminación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (drConfirmacion != DialogResult.Yes) return;

            var rResultado = gControlador.fun_eliminar(gIdSeleccionado);
            MessageBox.Show(rResultado.sMensaje, rResultado.bOk ? "Información" : "Atención",
                MessageBoxButtons.OK, rResultado.bOk ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            if (rResultado.bOk) { pro_cargar_grilla(); pro_limpiar(); }
        }

        // Limpia el formulario pero conserva el criterio elegido, para registrar
        // varios niveles seguidos del mismo criterio
        private void pro_limpiar()
        {
            gIdSeleccionado = 0;
            Txt_DescripcionDetallada.Clear();
            Txt_EvidenciaRequerida.Clear();
            Txt_Observaciones.Clear();
            Btn_Eliminar.Enabled = false;
            Btn_Guardar.Text = "Guardar";
            Dgv_DescripcionCriterio.ClearSelection();
            pro_seleccionar_nivel_faltante();
            pro_actualizar_resumen();
            Txt_DescripcionDetallada.Focus();
        }

        // Boton Salir agregado en la estandarizacion de diseño: solo cierra la ventana
        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Boton Imprimir agregado: abre el reporte Crystal (Rpt_Descripcion_Criterio.rpt dentro de este proyecto)
        private void Btn_Imprimir_Click(object sender, EventArgs e)
        {
            pro_Abrir_Reporte();
        }

        // Abre el reporte Crystal Rpt_Descripcion_Criterio.rpt (incrustado en este proyecto)
        private void pro_Abrir_Reporte()
        {
            try
            {
                Rpt_Descripcion_Criterio rptReporte = new Rpt_Descripcion_Criterio();
                using (Frm_Visor_Reporte frmVisor = new Frm_Visor_Reporte(rptReporte, "Reporte de Descripción de Criterios"))
                {
                    frmVisor.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo abrir el reporte: " + ex.Message, "Imprimir",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
