using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Vista_Escalas
{
    public partial class Frm_Escalas : Form
    {
        public Frm_Escalas()
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
                Nombre = "dgv_escalas"
            };

            string[] columnas = {
                    "tbl_escala_descripcion",
                    "Pk_Id_Escala",
                    "Cmp_Porcentaje_Escala",
                    "Cmp_Nombre_Nivel_Escala",
                    "Cmp_Descripcion_General_Escala",
                    "Cmp_Color_Referencia_Escala"
            };

            string[] sEtiquetas = {
                    "Código Escala",
                    "Porcentaje",
                    "Nombre Nivel",
                    "Descripcion General",
                    "Color Referencia"
            };

            int id_aplicacion = 517;
            navegador1.IPkId_Aplicacion = id_aplicacion;
            navegador1.configurarDataGridView(config);
            navegador1.SNombreTabla = columnas[0];
            navegador1.SAlias = columnas;
            navegador1.SEtiquetas = sEtiquetas;
            navegador1.mostrarDatos();
        }

        private void Btn_Reportes_Click(object sender, EventArgs e)
        {
            MessageBox.Show("En este apartado se mostrará el reporte con crystal report", "Reportes", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Btn_Ayudas_Click(object sender, EventArgs e)
        {
            MessageBox.Show("En este apartado se mostrará la ayuda con HTMLHelper", "Ayudas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
