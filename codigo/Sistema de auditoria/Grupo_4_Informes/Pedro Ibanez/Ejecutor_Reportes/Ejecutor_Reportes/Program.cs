using System;
using System.Windows.Forms;
using Capa_Vista_Reportes;

namespace Ejecutor_Reportes
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmReportes());
        }
    }
}
