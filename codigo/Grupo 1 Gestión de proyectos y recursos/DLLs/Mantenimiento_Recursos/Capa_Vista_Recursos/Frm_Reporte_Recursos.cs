using System;
using System.IO;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

//Inicio de código de Nelson Godínez carné 0901-22-3550 en la fecha de: "12/11/2026"
namespace Capa_Vista_Recursos
{
    public partial class Frm_Reporte_Recursos : Form
    {
        private const string sRUTA_REPORTE = @"reportes\Grupo 1\Recursos\Rpt_Recursos.rpt";

        public Frm_Reporte_Recursos()
        {
            InitializeComponent();
        }

        private void Frm_Reporte_Recursos_Load(object sender, EventArgs e)
        {
            try
            {
                // Busca el reporte subiendo carpetas desde el .exe, igual que la ayuda
                string sRutaEncontrada = null;
                DirectoryInfo dir = new DirectoryInfo(Application.StartupPath);
                for (int i = 0; i < 10 && dir != null; i++, dir = dir.Parent)
                {
                    string sCandidata = Path.Combine(dir.FullName, sRUTA_REPORTE);
                    if (File.Exists(sCandidata))
                    {
                        sRutaEncontrada = sCandidata;
                        break;
                    }
                }

                if (sRutaEncontrada == null)
                {
                    MessageBox.Show("No se encontró el reporte:\n" + sRUTA_REPORTE, "Reporte de recursos",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ReportDocument rptRecursos = new ReportDocument();
                rptRecursos.Load(sRutaEncontrada);

                // Aplica la conexión ODBC a cada tabla del reporte
                ConnectionInfo conexion = new ConnectionInfo
                {
                    ServerName = "bd_auditoria", // DSN
                    IntegratedSecurity = true
                };
                foreach (Table tabla in rptRecursos.Database.Tables)
                {
                    TableLogOnInfo logOn = tabla.LogOnInfo;
                    logOn.ConnectionInfo = conexion;
                    tabla.ApplyLogOnInfo(logOn);
                }

                Crv_Recursos.ReportSource = rptRecursos;
                Crv_Recursos.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el reporte: " + ex.Message, "Reporte de recursos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
//Fin del código de Nelson Godínez carné: 0901-22-3550 en la fecha de : "12/11/2026"