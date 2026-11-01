using System;
using System.Windows.Forms;
using Capa_Vista_Areas;

namespace Ejecucion_Mant_Areas
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Arranca directamente con Frm_Areas sin pasar por ninguna ventana blanca
            Application.Run(new Frm_Areas());
        }
    }
}