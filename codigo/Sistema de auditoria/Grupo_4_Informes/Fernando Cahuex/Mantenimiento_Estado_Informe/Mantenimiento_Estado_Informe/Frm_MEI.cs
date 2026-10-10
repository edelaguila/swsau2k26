using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mantenimiento_Estado_Informe
{
    public partial class Frm_MEI : Form
    {
        public Frm_MEI()
        {
            InitializeComponent();
            navegador1.Load += Navegador1_Load;

            void Navegador1_Load(object sender, EventArgs e)
            {
                navegador1.BotonesEstadoCRUD(true, true, true, true, true);
            }
            //parametros para navegador
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
                    "tbl_estado_informe",
                    "Pk_Id_Estado_Informe",
                    "Cmp_Nombre_Estado_Informe",
                    "Cmp_Descripcion_Estado_Informe"
};

            string[] sEtiquetas = {
                    "Estado de informe",
                    "Nombre de estado",
                    "Descripcion"
};



            int id_aplicacion = 100;
            navegador1.IPkId_Aplicacion = id_aplicacion;
            navegador1.configurarDataGridView(config);
            navegador1.SNombreTabla = columnas[0];
            navegador1.SAlias = columnas;
            navegador1.SEtiquetas = sEtiquetas;
            navegador1.mostrarDatos();
        }
    }
}
