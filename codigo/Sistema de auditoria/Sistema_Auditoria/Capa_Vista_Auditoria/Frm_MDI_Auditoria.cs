using Capa_Vista_Checklist;
using Capa_Vista_Reportes;
using Capa_Vista_Graficas_Informes;
using Capa_Vista_Informes;
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

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
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

        private void estadoInformeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_MEI frm = new Frm_MEI();
            frm.MdiParent = this;
            frm.Show();
        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReportes frm = new FrmReportes();
            frm.MdiParent = this;
            frm.Show();
        }

        private void checklistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Checklist frm = new Frm_Checklist();
            frm.MdiParent = this;
            frm.Show();
        }

        private void graficasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGraficasI frm = new FrmGraficasI();
            frm.MdiParent = this;
            frm.Show();
        }

        private void informesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Informes frm = new Frm_Informes();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
