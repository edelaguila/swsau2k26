using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Vista_PE
{
    public partial class Frm_PE : Form
    {
        public Frm_PE()
        {
            InitializeComponent();

            // Configuración del DataGridView para el navegador
            Capa_Controlador_Navegador.Cls_ConfiguracionDataGridView config = new Capa_Controlador_Navegador.Cls_ConfiguracionDataGridView
            {
                Ancho = 1100,
                Alto = 200,
                PosX = 10,
                PosY = 300,
                ColorFondo = Color.AliceBlue,
                TipoScrollBars = ScrollBars.Both,
                Nombre = "dgv_proyecto_estado"
            };

            // Definición de la tabla y columnas para tbl_proyecto_estado
            // Posición [0]: Nombre de la tabla en MySQL
            // Posiciones [1..N]: Nombres exactos de las columnas de la tabla
            string[] columnas = {
                "tbl_proyecto_estado",
                "Pk_Id_Proyecto_Estado",
                "Cmp_Nombre_Proyecto_Estado",
                "Cmp_Descripcion_Proyecto_Estado"
            };

            // Etiquetas visibles en la interfaz (deben coincidir en número con las columnas)
            string[] sEtiquetas = {
                "ID Estado Proyecto",
                "Nombre Estado",
                "Descripción Estado"
            };

            // Asignación de ID de Aplicación y Módulo
            int id_aplicacion = 501;
            int id_modulo = 10;

            navegador1.IPkId_Aplicacion = id_aplicacion;
            navegador1.IPkId_Modulo = id_modulo;

            // Configuración general del navegador
            navegador1.configurarDataGridView(config);
            navegador1.SNombreTabla = columnas[0];
            navegador1.SAlias = columnas;
            navegador1.SEtiquetas = sEtiquetas;

            // Cargar datos en el navegador
            navegador1.mostrarDatos();
        }

        // Método referenciado por Frm_PE.Designer.cs (this.navegador1.Load += ...)
        private void navegador1_Load(object sender, EventArgs e)
        {
            navegador1.BotonesEstadoCRUD(true, true, true, true, true);
        }
    }
}