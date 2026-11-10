using System;
using System.Windows.Forms;

namespace Capa_Vista_Auditor
{
    public partial class Frm_Reporte_Auditor : Form
    {
        public Frm_Reporte_Auditor()
        {
            InitializeComponent();
        }

        private void Frm_Reporte_Auditor_Load(object sender, EventArgs e)
        {
            // El informe (Reporte_Auditor1) ya se asigna al visor en el diseñador
        }

        private void Frm_Reporte_Auditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Liberar el trabajo de Crystal para no llegar al limite de procesamiento
            crystalReportViewer1.ReportSource = null;
            if (Reporte_Auditor1 != null)
            {
                Reporte_Auditor1.Close();
                Reporte_Auditor1.Dispose();
                Reporte_Auditor1 = null;
            }
        }
    }
}
