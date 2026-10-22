using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Vista_PY;
using Capa_Vista_PE;
using Capa_Vista_actividades_pro;
using Capa_Vista_Areas;
using Capa_Vista_Recursos;

//Grupo 2
using Capa_Vista_Auditor;
using Capa_Vista_Asignacion;
using mantenimiento_auditores;
using Capa_Vista_Perfil_Auditor;
using mantenimiento_auditor_perrfil;
using Capa_Vista_Estado_Auditor;
using mantenimiento_estado_auditor;
using Capavista_pauditado;

//Grupo 3
using Capa_Vista_Escalas;
using Capa_Vista_Actividad;
using Capa_Vista_Criterios;
using Capa_Vista_Cronograma;
using Capa_Vista_Desc_Criterio;
using Capa_Vista_Planificacion;
using Capa_Vista_Ponderacion;
using Capa_Vista_Rubrica;

namespace Capa_Vista_Auditoria
{
    public partial class Frm_MDI_Auditoria : Form
    {
        private int childFormNumber = 0;

        public Frm_MDI_Auditoria()
        {
            InitializeComponent();

            // Abrir maximizado
            this.WindowState = FormWindowState.Maximized;

            // Mantener controles de ventana
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;

            // Área de trabajo del MDI: WinForms no expone el color del
            // MdiClient como propiedad del diseñador, así que se ajusta aquí
            // una sola vez para que combine con el encabezado, sin ser oscuro.
            AplicarColorAreaMdi();
        }

        private void AplicarColorAreaMdi()
        {
            foreach (Control control in this.Controls)
            {
                if (control is MdiClient areaMdi)
                {
                    areaMdi.BackColor = Color.FromArgb(235, 240, 248);
                    break;
                }
            }
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }


        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void proyectoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_PY FrmProyecto = new Frm_PY();
            FrmProyecto.Show();

        }


        private void actividadesDelProyectoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Actividades_Proyecto FrmActividadesProyecto = new Frm_Actividades_Proyecto();
            FrmActividadesProyecto.Show();
        }

        private void áreasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //pendiente
        }

        private void recursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Recursos FrmRecursos = new Frm_Recursos();
            FrmRecursos.Show();
        }

        private void proyectoEstadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_PE FrmProyectoEstado = new Frm_PE();
            FrmProyectoEstado.Show();
        }

        private void auditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Capa_Vista_Auditor.Frm_Auditor g = new Capa_Vista_Auditor.Frm_Auditor();
            g.ShowDialog();
        }

        private void asignaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Capa_Vista_Asignacion.Frm_Asignacion g = new Capa_Vista_Asignacion.Frm_Asignacion();
            g.ShowDialog();
        }

        private void auditadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mantenimiento_auditores.Frm_auditados g = new mantenimiento_auditores.Frm_auditados();
            g.ShowDialog();
        }

        private void perfilAuditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Capa_Vista_Perfil_Auditor.Frm_Perfil_Auditor g = new Capa_Vista_Perfil_Auditor.Frm_Perfil_Auditor();
            g.ShowDialog();
        }

        private void estadoAuditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Capa_Vista_Estado_Auditor.Frm_Estado_Auditor g = new Capa_Vista_Estado_Auditor.Frm_Estado_Auditor();
            g.ShowDialog();
        }

        private void proyectoAuditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Capa_Vista_ProAuditor.Frm_ProyectoAuditor g = new Capa_Vista_ProAuditor.Frm_ProyectoAuditor();
            g.ShowDialog();
        }

        private void proyectoAuditadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Capavista_pauditado.Frm_pauditado g = new Capavista_pauditado.Frm_pauditado();
            g.ShowDialog();
        }

        private void escalasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Capa_Vista_Escalas.Frm_Escalas g = new Capa_Vista_Escalas.Frm_Escalas();
            g.ShowDialog();
        }

        private void actividadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Capa_Vista_Actividad.Frm_Actividad_Rubrica g = new Capa_Vista_Actividad.Frm_Actividad_Rubrica();
            g.ShowDialog();

        }

        private void criteriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Capa_Vista_Criterios.Frm_Criterio g = new Capa_Vista_Criterios.Frm_Criterio();
            g.ShowDialog();
        }

        private void cronogramaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Capa_Vista_Cronograma.Frm_Cronograma g = new Capa_Vista_Cronograma.Frm_Cronograma();
            g.ShowDialog();
        }

        private void descripciónCriteriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Capa_Vista_Desc_Criterio.Frm_DescripcionCriterio g = new Capa_Vista_Desc_Criterio.Frm_DescripcionCriterio();
            g.ShowDialog();
        }

        private void planificaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Capa_Vista_Planificacion.Frm_Planificacion g = new Capa_Vista_Planificacion.Frm_Planificacion();
            g.ShowDialog();
        }

        private void ponderaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Capa_Vista_Ponderacion.Frm_Ponderacion g = new Capa_Vista_Ponderacion.Frm_Ponderacion();
            g.ShowDialog();
        }

        private void rúbricaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Capa_Vista_Rubrica.Frm_Rubrica g = new Capa_Vista_Rubrica.Frm_Rubrica();
            g.ShowDialog();
        }
    }
}
