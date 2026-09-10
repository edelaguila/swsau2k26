using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Vista_Componente_Consultas_simples;

namespace Capa_Vista_Componente_Consultas
{
    public partial class Frm_Consulta_Simple : Form
    {
        public Frm_Consulta_Simple()
        {
            InitializeComponent();
        }
        // Constructor que recibe parámetros y asigna el nombre de la tabla externa
        // al control consulta_simple1 si existe al menos un valor en el arreglo.
        public Frm_Consulta_Simple(string[] sParametros) : this()
        {
            if (sParametros != null && sParametros.Length > 0)
                consulta_simple1.sNombreTablaExterna = sParametros[0];
        }
    }
}
