using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Vista_Estado_Auditor
{
    public partial class Frm_Estado_Auditor : Form
    {
        public Frm_Estado_Auditor()
        {
            InitializeComponent();

            // Parámetros para navegador
            Capa_Controlador_Navegador.Cls_ConfiguracionDataGridView config = new Capa_Controlador_Navegador.Cls_ConfiguracionDataGridView
            {
                Ancho = 1100,
                Alto = 200,
                PosX = 10,
                PosY = 300,
                ColorFondo = Color.AliceBlue,
                TipoScrollBars = ScrollBars.Both,
                Nombre = "dgv_Estado_Auditor"
            };

            // Nombre de la tabla y campos según el script SQL de tbl_estado_auditor
            string[] columnas = {
                "tbl_estado_auditor",          // Nombre de la tabla[cite: 1]
                "Pk_Id_Estado_Auditor",        // Llave primaria[cite: 1]
                "Cmp_Nombre_Estado_Auditor"    // Campo nombre[cite: 1]
            };

            // Etiquetas visibles en las columnas del DataGridView
            string[] sEtiquetas = {
                "Código Estado Auditor",
                "Nombre Estado Auditor"
            };

            // ID de aplicación y módulo (ajusta según los asignados en tu sistema)
            int id_aplicacion = 506;
            int id_modulo = 11;

            // Configuración del componente Navegador
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