using System;
using System.Windows.Forms;
using Capa_Vista_Auditoria;

namespace Ejecutable_Auditoria
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
            Application.Run(new Frm_Login_auditoria());
        }
    }
}