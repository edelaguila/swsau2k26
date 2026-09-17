using System;
using System.Windows.Forms;
using Capa_Vista_Auditoria;
using Capa_Vista_Seguridad;

namespace Menu_ejecutable
{
    public partial class Frm_Menu : Form
    {
        // ==========================================
        // CONSTRUCTOR
        // ==========================================
        public Frm_Menu()
        {
            InitializeComponent();
        }

        // ==========================================
        // SEGURIDAD
        // ==========================================
       
        private void Btn_Seguridad_Click_1(object sender, EventArgs e)
        {
            Frm_Login frm_LoginS = new Frm_Login();

            this.Hide();

            frm_LoginS.Show();
        }

        private void Btn_Seguridad_MouseEnter(object sender, EventArgs e)
        {
            Btn_Seguridad.BackColor = System.Drawing.Color.FromArgb(45, 135, 235);
        }

        private void Btn_Seguridad_MouseLeave(object sender, EventArgs e)
        {
            Btn_Seguridad.BackColor = System.Drawing.Color.FromArgb(30, 120, 220);
        }

        // ==========================================
        // AUDITORÍA
        // ==========================================
        private void Btn_Auditoria_Click(object sender, EventArgs e)
        {
            Frm_Login_auditoria frm_loginA = new Frm_Login_auditoria();
            this.Hide();
            frm_loginA.Show();
        }

        private void Btn_Auditoria_MouseEnter(object sender, EventArgs e)
        {
            Btn_Auditoria.BackColor = System.Drawing.Color.FromArgb(0, 175, 120);
        }

        private void Btn_Auditoria_MouseLeave(object sender, EventArgs e)
        {
            Btn_Auditoria.BackColor = System.Drawing.Color.FromArgb(0, 150, 105);
        }
    }
}