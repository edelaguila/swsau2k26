using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Vista_Perfil_Auditor
{
    public partial class Frm_Perfil_Auditor : Form
    {
        public Frm_Perfil_Auditor()
        {
            InitializeComponent();

            // Parámetros para navegador
            Capa_Controlador_Navegador.Cls_ConfiguracionDataGridView config =
                new Capa_Controlador_Navegador.Cls_ConfiguracionDataGridView
                {
                    Ancho = 1100,
                    Alto = 200,
                    PosX = 10,
                    PosY = 300,
                    ColorFondo = Color.AliceBlue,
                    TipoScrollBars = ScrollBars.Both,
                    Nombre = "dgv_Perfil_Auditor"
                };

            string[] columnas =
            {
                "tbl_perfil_auditor",
                "Pk_Id_Perfil_Auditor",
                "Cmp_Nombre_Perfil_Auditor",
                "Cmp_Descripcion_Perfil"
            };

            string[] sEtiquetas =
            {
                "Código Perfil Auditor",
                "Nombre del Perfil del Auditor",
                "Descripción del Perfil"
            };

            int id_aplicacion = 505;
            int id_modulo = 11;

            navegador1.IPkId_Aplicacion = id_aplicacion;
            navegador1.IPkId_Modulo = id_modulo;

            navegador1.configurarDataGridView(config);

            navegador1.SNombreTabla = columnas[0];
            navegador1.SAlias = columnas;
            navegador1.SEtiquetas = sEtiquetas;

            navegador1.mostrarDatos();
        }
    }
}