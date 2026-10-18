using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Controlador_Informes;

namespace Capa_Vista_Informes
{
    public partial class Frm_Informes : Form
    {
        private readonly Cls_InformesControlador Controlador = new Cls_InformesControlador();
        //Cls_BitacoraControlador ctrlBitacora = new Cls_BitacoraControlador();
        public Frm_Informes()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {


        }
        private void fun_cargar_Informes()
        {
            // Aquí iría la lógica para cargar los informes en el DataGridView
        }

        private void fun_CargarCombo(ComboBox cbo, Cls_ResultadoOperacion resultado,
                                     string sDisplay, string sValue, string sDescripcion)
        {
            if (!resultado.bExito)
            {
                MessageBox.Show(resultado.sMensaje, "Error al cargar " + sDescripcion,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cbo.DisplayMember = sDisplay;
            cbo.ValueMember = sValue;
            cbo.DataSource = resultado.dtDatos;   // siempre al final
            cbo.SelectedIndex = -1;               // sin selección inicial
        }

        private void fun_cargar_Proyectos() =>
            fun_CargarCombo(Cbo_Proyecto, Controlador.fun_Obtener_Proyectos(),
                            "Proyecto", "Pk_id_proyecto", "proyectos");

        private void fun_cargar_Auditores() =>
            fun_CargarCombo(Cbo_Auditores, Controlador.fun_Obtener_Auditores(),
                            "Auditor", "Pk_id_auditor", "auditores");

        private void fun_cargar_EstadosInforme() =>
            fun_CargarCombo(Cbo_Estado, Controlador.fun_Obtener_Estados_Informe(),
                            "Cmp_Nombre_Estado_Informe", "Pk_id_estado_informe", "estados de informe");
    }
}
