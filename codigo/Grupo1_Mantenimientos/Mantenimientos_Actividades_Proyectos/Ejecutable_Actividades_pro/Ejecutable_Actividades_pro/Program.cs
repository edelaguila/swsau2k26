
using System;
using System.Windows.Forms;
using Capa_Vista_actividades_pro;

namespace Capa_Ejecutable_actividades_pro
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Frm_Actividades_Proyecto());
        }
    }
}
