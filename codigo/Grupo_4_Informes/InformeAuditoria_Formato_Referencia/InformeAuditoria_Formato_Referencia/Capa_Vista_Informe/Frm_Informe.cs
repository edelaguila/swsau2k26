using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Capa_Controlador_Informe;

namespace Capa_Vista_Informe
{
    // La Vista no consulta SQL: únicamente utiliza el Controlador.
    public partial class Frm_Informe : Form
    {
        // La conexión se obtiene exclusivamente mediante la DLL del módulo Seguridad.
        public Frm_Informe()
        {
            InitializeComponent();
            cmbInformes.DisplayMember = "TextoInforme";
            cmbInformes.ValueMember = "Id";
            cmbInformes.SelectedIndex = -1;
            btnCargar.Click += btnCargar_Click;
            btnGenerar.Click += btnGenerar_Click;
        }

        private Cls_Controlador_Informe CrearControlador()
        {
            return new Cls_Controlador_Informe();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            Ejecutar(delegate {
                List<Cls_Informe_Resumen_DTO> informes = CrearControlador().ObtenerInformes();
                cmbInformes.DataSource = informes;
                btnGenerar.Enabled = informes.Count > 0;
                lblEstado.Text = "Se encontraron " + informes.Count + " informes.";
                if (informes.Count == 0)
                    MessageBox.Show(this, "No hay informes registrados en tbl_informe.",
                        "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            });
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            Ejecutar(delegate {
                Cls_Informe_Resumen_DTO seleccionado = cmbInformes.SelectedItem as Cls_Informe_Resumen_DTO;
                if (seleccionado == null)
                    throw new InvalidOperationException("Selecciona un informe válido.");

                Cls_Informe_DTO informe = CrearControlador().ObtenerInforme(seleccionado.Id);
                using (SaveFileDialog dialogo = new SaveFileDialog())
                {
                    dialogo.Title = "Guardar informe PDF";
                    dialogo.Filter = "Archivos PDF (*.pdf)|*.pdf";
                    dialogo.FileName = "Informe_Auditoria_" + informe.Id + ".pdf";
                    dialogo.DefaultExt = "pdf";
                    dialogo.AddExtension = true;
                    if (dialogo.ShowDialog(this) != DialogResult.OK) return;

                    Cls_Pdf_Informe.Generar(informe, dialogo.FileName);
                    lblEstado.Text = "Informe generado: " + dialogo.FileName;
                    MessageBox.Show(this, "PDF generado correctamente.", "Completado",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            });
        }

        private void Ejecutar(Action accion)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                btnCargar.Enabled = false;
                btnGenerar.Enabled = false;
                accion();
            }
            catch (Exception ex)
            {
                lblEstado.Text = "Error al procesar la solicitud.";
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                btnCargar.Enabled = true;
                btnGenerar.Enabled = cmbInformes.SelectedItem is Cls_Informe_Resumen_DTO;
            }
        }

        // Boton Salir agregado en la estandarizacion de diseño: solo cierra la ventana
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
