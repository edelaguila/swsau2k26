using System;
using System.Windows.Forms;
using Capa_Vista_Informe;

namespace Inicio_Informe
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Frm_Informe());
        }
    }
}
