using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Vista_Navegador;

namespace mantenimiento_auditores
{
    public partial class Frm_auditados : Form
    {
        public Frm_auditados()
        {
            InitializeComponent();




            Capa_Controlador_Navegador.Cls_ConfiguracionDataGridView config =
                new Capa_Controlador_Navegador.Cls_ConfiguracionDataGridView
                {
                    Ancho = 1100,
                    Alto = 200,
                    PosX = 10,
                    PosY = 300,
                    ColorFondo = Color.AliceBlue,
                    TipoScrollBars = ScrollBars.Both,
                    Nombre = "dgv_auditados"
                };

            string[] columnas = {
                "tbl_auditados",
                "Pk_Id_Auditado",
                "Cmp_Nombre_Auditado",
                "Cmp_Cargo_Area_Auditado",
                "Cmp_Correo_Auditado",
                "Cmp_Telefono_Auditado",
                "Cmp_Observaciones_Auditado"

            };

            string[] sEtiquetas = {
                
                "Código Auditado",
                "Nombre",
                "Cargo de Area",
                "Correo",
                "Teléfono",
                "Observaciones"
            };

            int id_aplicacion = 509;
            int id_Modulo = 11;

            navegador1.IPkId_Aplicacion = id_aplicacion;
            navegador1.IPkId_Modulo = id_Modulo;
            navegador1.configurarDataGridView(config);
            navegador1.SNombreTabla = columnas[0];
            navegador1.SAlias = columnas;
            navegador1.SEtiquetas = sEtiquetas;
            navegador1.mostrarDatos();
        
    }
    }
}
