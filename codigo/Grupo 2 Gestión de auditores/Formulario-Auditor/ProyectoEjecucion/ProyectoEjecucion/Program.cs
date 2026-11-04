using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoEjecucion
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // SOLO PARA PRUEBAS: simula el inicio de sesion (usuario 23 = admin).
            // En el sistema completo esto lo hace el Login.
            Capa_Controlador_Seguridad.Cls_Usuario_Conectado.IniciarSesion(23, "admin", 0);

            Application.Run(new Capa_Vista_Auditor.Frm_Auditor());
        }
    }
}
