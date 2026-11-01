using System;
using System.Windows.Forms;
using Capa_Vista_PY; // Namespace donde está Frm_PY

namespace Exe_PY
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

            // Abre directamente tu formulario de la Biblioteca de Clases
            Application.Run(new Frm_PY());
        }
    }
}
