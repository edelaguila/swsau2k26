using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Vista_PE; // Espacio de nombres de la biblioteca de clases

namespace Exe_PE
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Reemplazamos Form1() por Frm_PE() de la biblioteca de clases
            Application.Run(new Frm_PE());
        }
    }
}
