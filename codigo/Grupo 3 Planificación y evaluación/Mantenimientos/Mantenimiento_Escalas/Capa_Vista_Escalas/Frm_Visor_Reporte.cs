using System;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;

namespace Capa_Vista_Escalas
{
    // Ventana que muestra el reporte Crystal de este formulario (boton Imprimir).
    public class Frm_Visor_Reporte : Form
    {
        private readonly CrystalReportViewer crvReporte = new CrystalReportViewer();
        private ReportDocument rptDocumento;

        public Frm_Visor_Reporte(ReportDocument rptReporte, string sTitulo)
        {
            rptDocumento = rptReporte;

            this.Text = sTitulo;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new System.Drawing.Size(1150, 720);
            this.MinimumSize = new System.Drawing.Size(800, 500);

            crvReporte.Dock = DockStyle.Fill;
            crvReporte.ToolPanelView = ToolPanelViewType.None;
            crvReporte.ReportSource = rptDocumento;
            this.Controls.Add(crvReporte);

            this.FormClosed += Frm_Visor_Reporte_FormClosed;
        }

        // Libera el reporte al cerrar para no llegar al limite de trabajos de Crystal
        private void Frm_Visor_Reporte_FormClosed(object sender, FormClosedEventArgs e)
        {
            crvReporte.ReportSource = null;
            if (rptDocumento != null)
            {
                rptDocumento.Close();
                rptDocumento.Dispose();
                rptDocumento = null;
            }
        }
    }
}
