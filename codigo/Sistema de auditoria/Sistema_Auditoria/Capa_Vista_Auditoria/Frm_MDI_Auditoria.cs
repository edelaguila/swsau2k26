using Capa_Controlador_Seguridad;
using Capa_Vista_Actividad;
using Capa_Vista_actividades_pro;
using Capa_Vista_Areas;
using Capa_Vista_Asignacion;
//Grupo 2
using Capa_Vista_Auditor;
using Capa_Vista_Checklist;
using Capa_Vista_Criterios;
using Capa_Vista_Cronograma;
using Capa_Vista_Desc_Criterio;
//Grupo 3
using Capa_Vista_Escalas;
using Capa_Vista_Estado_Auditor;
using Capa_Vista_Graficas_Informes;
using Capa_Vista_Informes;
using Capa_Vista_PE;
using Capa_Vista_Perfil_Auditor;
using Capa_Vista_Planificacion;
using Capa_Vista_Ponderacion;
using Capa_Vista_PY;
using Capa_Vista_Recursos;
using Capa_Vista_Reportes;
using Capa_Vista_Rubrica;
using Capavista_pauditado;
using mantenimiento_auditor_perrfil;
using mantenimiento_auditores;
using mantenimiento_estado_auditor;
//Grupo 4
using Mantenimiento_Estado_Informe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        // Control agregado: solo se permite un formulario abierto a la vez desde el MDI.
        // Guarda el formulario abierto como ventana independiente: se puede mover por toda
        // la pantalla y queda encima del sistema (Show(this)).
        private Form frmAbiertoFueraMdi = null;

        // Cierra el formulario que este abierto antes de abrir otro.
        // Devuelve false si el formulario abierto cancelo su cierre.
        private bool pro_cerrar_formulario_abierto()
        {
            foreach (Form frmHijo in this.MdiChildren)
            {
                frmHijo.Close();
            }

            if (frmAbiertoFueraMdi != null && !frmAbiertoFueraMdi.IsDisposed)
            {
                frmAbiertoFueraMdi.Close();
            }

            if (this.MdiChildren.Length > 0 || (frmAbiertoFueraMdi != null && !frmAbiertoFueraMdi.IsDisposed))
            {
                return false;
            }

            frmAbiertoFueraMdi = null;
            return true;
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
            if (!pro_cerrar_formulario_abierto()) return;

            Frm_PY FrmProyecto = new Frm_PY();
            frmAbiertoFueraMdi = FrmProyecto;
            FrmProyecto.Show(this);

        }


        private void actividadesDelProyectoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!pro_cerrar_formulario_abierto()) return;

            Frm_Actividades_Proyecto FrmActividadesProyecto = new Frm_Actividades_Proyecto();
            frmAbiertoFueraMdi = FrmActividadesProyecto;
            FrmActividadesProyecto.Show(this);
        }

        private void áreasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!pro_cerrar_formulario_abierto()) return;

            //pendiente
            Frm_Areas frmAreas = new Frm_Areas();
            frmAbiertoFueraMdi = frmAreas;
            frmAreas.Show(this);
        }

        private void recursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!pro_cerrar_formulario_abierto()) return;

            Frm_Recursos FrmRecursos = new Frm_Recursos();
            frmAbiertoFueraMdi = FrmRecursos;
            FrmRecursos.Show(this);
        }

        private void proyectoEstadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!pro_cerrar_formulario_abierto()) return;

            Frm_PE FrmProyectoEstado = new Frm_PE();
            frmAbiertoFueraMdi = FrmProyectoEstado;
            FrmProyectoEstado.Show(this);
        }

        private void auditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!pro_cerrar_formulario_abierto()) return;

            Capa_Vista_Auditor.Frm_Auditor g = new Capa_Vista_Auditor.Frm_Auditor();
            g.ShowDialog();
        }

        private void asignaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!pro_cerrar_formulario_abierto()) return;

            Capa_Vista_Asignacion.Frm_Asignacion g = new Capa_Vista_Asignacion.Frm_Asignacion();
            g.ShowDialog();
        }

        private void auditadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!pro_cerrar_formulario_abierto()) return;

            mantenimiento_auditores.Frm_auditados g = new mantenimiento_auditores.Frm_auditados();
            g.ShowDialog();
        }

        private void perfilAuditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!pro_cerrar_formulario_abierto()) return;

            Capa_Vista_Perfil_Auditor.Frm_Perfil_Auditor g = new Capa_Vista_Perfil_Auditor.Frm_Perfil_Auditor();
            g.ShowDialog();
        }

        private void estadoAuditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!pro_cerrar_formulario_abierto()) return;

            Capa_Vista_Estado_Auditor.Frm_Estado_Auditor g = new Capa_Vista_Estado_Auditor.Frm_Estado_Auditor();
            g.ShowDialog();
        }

        private void proyectoAuditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!pro_cerrar_formulario_abierto()) return;

            Capa_Vista_ProAuditor.Frm_ProyectoAuditor g = new Capa_Vista_ProAuditor.Frm_ProyectoAuditor();
            g.ShowDialog();
        }

        private void proyectoAuditadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!pro_cerrar_formulario_abierto()) return;

            Capavista_pauditado.Frm_pauditado g = new Capavista_pauditado.Frm_pauditado();
            g.ShowDialog();
        }

        private void escalasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!pro_cerrar_formulario_abierto()) return;

            Capa_Vista_Escalas.Frm_Escalas g = new Capa_Vista_Escalas.Frm_Escalas();
            g.ShowDialog();
        }

        private void actividadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!pro_cerrar_formulario_abierto()) return;

            Capa_Vista_Actividad.Frm_Actividad_Rubrica g = new Capa_Vista_Actividad.Frm_Actividad_Rubrica();
            g.ShowDialog();

        }

        private void criteriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!pro_cerrar_formulario_abierto()) return;

            Capa_Vista_Criterios.Frm_Criterio g = new Capa_Vista_Criterios.Frm_Criterio();
            g.ShowDialog();
        }

        private void cronogramaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!pro_cerrar_formulario_abierto()) return;

            Capa_Vista_Cronograma.Frm_Cronograma g = new Capa_Vista_Cronograma.Frm_Cronograma();
            g.ShowDialog();
        }

        private void descripciónCriteriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!pro_cerrar_formulario_abierto()) return;

            Capa_Vista_Desc_Criterio.Frm_DescripcionCriterio g = new Capa_Vista_Desc_Criterio.Frm_DescripcionCriterio();
            g.ShowDialog();
        }

        private void planificaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!pro_cerrar_formulario_abierto()) return;

            Capa_Vista_Planificacion.Frm_Planificacion g = new Capa_Vista_Planificacion.Frm_Planificacion();
            g.ShowDialog();
        }

        private void ponderaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!pro_cerrar_formulario_abierto()) return;

            Capa_Vista_Ponderacion.Frm_Ponderacion g = new Capa_Vista_Ponderacion.Frm_Ponderacion();
            g.ShowDialog();
        }

        private void rúbricaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!pro_cerrar_formulario_abierto()) return;

            Capa_Vista_Rubrica.Frm_Rubrica g = new Capa_Vista_Rubrica.Frm_Rubrica();
            g.ShowDialog();
        }

        private void estadoInformeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!pro_cerrar_formulario_abierto()) return;

            Frm_MEI frm = new Frm_MEI();
            // Ventana libre (se puede mover por toda la pantalla) y encima del sistema
            frmAbiertoFueraMdi = frm;
            frm.Show(this);
        }

        private void cheToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!pro_cerrar_formulario_abierto()) return;

            Frm_Informes frm = new Frm_Informes();
            // Ventana libre (se puede mover por toda la pantalla) y encima del sistema
            frmAbiertoFueraMdi = frm;
            frm.Show(this);
        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!pro_cerrar_formulario_abierto()) return;

            FrmReportes frm = new FrmReportes();
            // Ventana libre (se puede mover por toda la pantalla) y encima del sistema
            frmAbiertoFueraMdi = frm;
            frm.Show(this);
        }

        private void checklistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!pro_cerrar_formulario_abierto()) return;

            Frm_Checklist frm = new Frm_Checklist();
            // Ventana libre (se puede mover por toda la pantalla) y encima del sistema
            frmAbiertoFueraMdi = frm;
            frm.Show(this);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (!pro_cerrar_formulario_abierto()) return;

            FrmGraficasI frm = new FrmGraficasI();
            // Ventana libre (se puede mover por toda la pantalla) y encima del sistema
            frmAbiertoFueraMdi = frm;
            frm.Show(this);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ctrlBitacora.RegistrarCierreSesion(Cls_Usuario_Conectado.iIdUsuario);

            this.Hide();
            Frm_Login_auditoria formLogin = new Frm_Login_auditoria();
            formLogin.ShowDialog();
            this.Close();
        }

        private void informeFinalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!pro_cerrar_formulario_abierto()) return;

            // Generador del informe final en PDF (Grupo 4 - InformeAuditoria_Formato_Referencia)
            Capa_Vista_Informe.Frm_Informe frm = new Capa_Vista_Informe.Frm_Informe();
            // Ventana libre (se puede mover por toda la pantalla) y encima del sistema
            frmAbiertoFueraMdi = frm;
            frm.Show(this);
        }
    }
}
