using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaEjecucionNavegador
{
    public partial class Form1 : Form
    {
        public Form1()
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
                    "tbl_contacto",
                    "Pk_Contacto_Id",
                    "Cmp_Correo",
                    "Cmp_Telefono"
};

            string[] sEtiquetas = {
                    "Código Contacto Personal Extremadamente Largo",
                    "Correo Electrónico",
                    "Teléfono"
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