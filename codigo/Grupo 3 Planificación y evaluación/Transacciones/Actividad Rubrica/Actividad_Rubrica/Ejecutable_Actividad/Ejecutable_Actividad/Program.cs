// Codigo empezado por: Maria Morales 0901-22-1226 el día 19/10/2026
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Vista_Actividad;

namespace Ejecutable_Actividad
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
            Application.Run(new Frm_Actividad_Rubrica());
        }
    }
}
// Codigo terminado por: Maria Morales 0901-22-1226 el día 19/10/2026