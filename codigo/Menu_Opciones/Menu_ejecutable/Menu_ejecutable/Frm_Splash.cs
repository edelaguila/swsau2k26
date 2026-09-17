using System;
using System.Windows.Forms;
namespace Menu_ejecutable
{
    public partial class Frm_Splash : Form
    {
        private int progreso = 0;

        public Frm_Splash()
        {
            InitializeComponent();

            // Logo embebido en el proyecto (Properties.Resources), ya no se
            // busca en disco: evita el mensaje "Logo no encontrado" cuando
            // el ejecutable corre desde una carpeta distinta (por ejemplo,
            // Ejecutable_Auditoria en vez de Menu_ejecutable).
            picLogo.Image = Properties.Resources.logo_auditores;

            timerCarga.Start();
        }

        private void TimerCarga_Tick(object sender, EventArgs e)
        {
            progreso++;

            barraCarga.Value = progreso;

            lblPorcentaje.Text = progreso + "%";

            if (progreso < 25)
            {
                lblEstado.Text = "Iniciando sistema...";
            }
            else if (progreso < 50)
            {
                lblEstado.Text = "Cargando módulo de seguridad...";
            }
            else if (progreso < 75)
            {
                lblEstado.Text = "Cargando módulo de auditoría...";
            }
            else if (progreso < 100)
            {
                lblEstado.Text = "Preparando menú principal...";
            }

            if (progreso >= 100)
            {
                timerCarga.Stop();

                AbrirMenu();
            }
        }

        private void AbrirMenu()
        {
            Frm_Menu menu = new Frm_Menu();

            // Cuando se cierre el menú, cerrar también el Splash
            menu.FormClosed += (s, e) =>
            {
                this.Close();
            };

            this.Hide();

            menu.Show();
        }
    }
}
