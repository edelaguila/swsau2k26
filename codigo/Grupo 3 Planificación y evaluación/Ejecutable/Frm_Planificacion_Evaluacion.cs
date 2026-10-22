//Inicio de código de "Edwin Stevens Cambranes Mendizábal" con carné: "0901-22-940" en la fecha de: "20/10/2026"
// Formulario principal (MDI) del ejecutable del área Planificación y Evaluación (PV): abre los módulos del Grupo 3.
//Fin del código de "Edwin Stevens Cambranes Mendizábal" con carné: "0901-22-940" en la fecha de : "20/10/2026"
using System;
using System.Windows.Forms;

namespace Ejecutable
{
    public partial class Frm_Planificacion_Evaluacion : Form
    {
        public Frm_Planificacion_Evaluacion()
        {
            InitializeComponent();
            // En un MDI el fondo gris es del MdiClient, no del formulario.
            foreach (Control c in Controls)
            {
                if (c is MdiClient) c.BackColor = System.Drawing.Color.FromArgb(255, 224, 0);
            }
        }

        // Abre el formulario dentro del MDI; si ya está abierto, lo trae al frente.
        private void Abrir<T>() where T : Form, new()
        {
            foreach (Form f in MdiChildren)
            {
                if (f is T) { f.Activate(); return; }
            }
            new T { MdiParent = this }.Show();
        }

        private void escalasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir<Capa_Vista_Escalas.Frm_Escalas>();
        }

        private void planificacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir<Capa_Vista_Planificacion.Frm_Planificacion>();
        }

        private void rubricaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir<Capa_Vista_Rubrica.Frm_Rubrica>();
        }

        private void criteriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir<Capa_Vista_Criterios.Frm_Criterio>();
        }

        private void descCriterioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir<Capa_Vista_Desc_Criterio.Frm_DescripcionCriterio>();
        }

        private void actividadRubricaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir<Capa_Vista_Actividad.Frm_Actividad_Rubrica>();
        }

        private void cronogramaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir<Capa_Vista_Cronograma.Frm_Cronograma>();
        }

        private void ponderacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir<Capa_Vista_Ponderacion.Frm_Ponderacion>();
        }
    }
}
