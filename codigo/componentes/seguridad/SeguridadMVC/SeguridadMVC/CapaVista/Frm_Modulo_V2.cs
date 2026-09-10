using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Danilo Mazariegos 0901-19-25059
namespace Capa_Vista_Seguridad
{
    public partial class Frm_Modulo_V2 : Form
    {

        private Timer timerBotones; // 🔹 temporizador para vigilar los botones
        public Frm_Modulo_V2()
        {
            InitializeComponent();
            Capa_Controlador_Navegador.Cls_ConfiguracionDataGridView config = new Capa_Controlador_Navegador.Cls_ConfiguracionDataGridView
            {
                Ancho = 1100,
                Alto = 200,
                PosX = 10,
                PosY = 300,
                ColorFondo = Color.AliceBlue,
                TipoScrollBars = ScrollBars.Both,
                Nombre = "dgv_empleados"
            };

            string[] columnas = {
                    "tbl_modulo",
                    "Pk_Id_Modulo",
                    "Cmp_Nombre_Modulo",
                    "Cmp_Descripcion_Modulo",
                    "Cmp_Estado_Modulo"

            };

            string[] sEtiquetas = {
                    "Id Modulo ",
                    "Nombre Modulo",
                    "Descripción",
                    "Estado"

                };
            //Pendiente
            int id_aplicacion = 304;
            int id_Modulo = 4;
            navegador1.IPkId_Aplicacion = id_aplicacion;
            navegador1.IPkId_Modulo = id_Modulo;
            navegador1.configurarDataGridView(config);
            navegador1.SNombreTabla = columnas[0];
            navegador1.SAlias = columnas;
            navegador1.SEtiquetas = sEtiquetas;
            navegador1.mostrarDatos();

            // ==============================
        }
    }
}