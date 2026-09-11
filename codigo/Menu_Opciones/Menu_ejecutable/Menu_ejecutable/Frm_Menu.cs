using System;
using System.Windows.Forms;
using Capa_Vista_Auditoria;
using Capa_Vista_Seguridad;

namespace Menu_ejecutable
{
    public partial class Frm_Menu : Form
    {
        // ==========================================
        // CLASE DE DISEÑO
        // ==========================================
        private Cls_Diseño_Auditoria diseño = new Cls_Diseño_Auditoria();


        // ==========================================
        // CONSTRUCTOR
        // ==========================================
        public Frm_Menu()
        {
            InitializeComponent();

            diseño.AplicarDiseñoMenu(
                this,
                label1,
                Btn_Seguridad,
                Btn_Auditoria
            );
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

        // ==========================================
        // AUDITORÍA
        // ==========================================
        private void Btn_Auditoria_Click(object sender, EventArgs e)
        {
            Frm_Login_auditoria frm_loginA = new Frm_Login_auditoria();
            this.Hide();
            frm_loginA.Show();
        }
    }
}