using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
namespace Menu_ejecutable
{
    public partial class Frm_Splash : Form
    {
        private Timer timerCarga;
        private ProgressBar barraCarga;
        private Label lblTitulo;
        private Label lblEstado;
        private Label lblPorcentaje;

        private int progreso = 0;

        public Frm_Splash()
        {
            InitializeComponent();

            CrearDiseño();
            ConfigurarCarga();
        }

        private void CrearDiseño()
        {
            // ==============================
            // FORMULARIO
            // ==============================
            this.ClientSize = new Size(720, 440);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(8, 17, 35);

            // ==============================
            // LOGO
            // ==============================
            PictureBox picLogo = new PictureBox();

            string rutaLogo = Path.Combine(
                Application.StartupPath,
                @"..\..\..\..\..\..\recursos\sw_auditores\logo_auditores.png"
            );

            rutaLogo = Path.GetFullPath(rutaLogo);

            if (File.Exists(rutaLogo))
            {
                picLogo.Image = Image.FromFile(rutaLogo);
            }
            else
            {
                MessageBox.Show(
                    "No se encontró el logo en:\n" + rutaLogo,
                    "Logo no encontrado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }

            picLogo.Size = new Size(90, 90);
            picLogo.Location = new Point(315, 20);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.BackColor = Color.White;

            this.Controls.Add(picLogo);

            // ==============================
            // TÍTULO
            // ==============================
            lblTitulo = new Label();

            lblTitulo.Text = "SISTEMA DE AUDITORES";
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Font = new Font("Segoe UI", 25, FontStyle.Bold);

            lblTitulo.AutoSize = false;
            lblTitulo.Size = new Size(720, 50);
            lblTitulo.Location = new Point(0, 120);
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            this.Controls.Add(lblTitulo);

            // ==============================
            // SUBTÍTULO
            // ==============================
            Label lblSubtitulo = new Label();

            lblSubtitulo.Text =
                "Auditoría   •   Seguridad   •   Control Interno";

            lblSubtitulo.ForeColor =
                Color.FromArgb(150, 175, 210);

            lblSubtitulo.Font = new Font("Segoe UI", 10);

            lblSubtitulo.AutoSize = false;
            lblSubtitulo.Size = new Size(720, 30);
            lblSubtitulo.Location = new Point(0, 168);
            lblSubtitulo.TextAlign = ContentAlignment.MiddleCenter;

            this.Controls.Add(lblSubtitulo);

            // ==============================
            // ESTADO
            // ==============================
            lblEstado = new Label();

            lblEstado.Text = "Iniciando sistema...";
            lblEstado.ForeColor = Color.FromArgb(200, 215, 235);
            lblEstado.Font = new Font("Segoe UI", 10);

            lblEstado.AutoSize = false;
            lblEstado.Size = new Size(500, 25);
            lblEstado.Location = new Point(110, 250);

            this.Controls.Add(lblEstado);

            // ==============================
            // PORCENTAJE
            // ==============================
            lblPorcentaje = new Label();

            lblPorcentaje.Text = "0%";
            lblPorcentaje.ForeColor = Color.White;
            lblPorcentaje.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            lblPorcentaje.AutoSize = false;
            lblPorcentaje.Size = new Size(60, 25);
            lblPorcentaje.Location = new Point(550, 250);
            lblPorcentaje.TextAlign = ContentAlignment.MiddleRight;

            this.Controls.Add(lblPorcentaje);

            // ==============================
            // BARRA DE CARGA
            // ==============================
            barraCarga = new ProgressBar();

            barraCarga.Minimum = 0;
            barraCarga.Maximum = 100;
            barraCarga.Value = 0;

            barraCarga.Size = new Size(500, 20);
            barraCarga.Location = new Point(110, 285);
            barraCarga.Style = ProgressBarStyle.Continuous;

            this.Controls.Add(barraCarga);

            // ==============================
            // FOOTER
            // ==============================
            Label lblFooter = new Label();

            lblFooter.Text = "Preparando módulos del sistema...";

            lblFooter.ForeColor =
                Color.FromArgb(100, 130, 170);

            lblFooter.Font = new Font("Segoe UI", 9);

            lblFooter.AutoSize = false;
            lblFooter.Size = new Size(720, 25);
            lblFooter.Location = new Point(0, 340);
            lblFooter.TextAlign = ContentAlignment.MiddleCenter;

            this.Controls.Add(lblFooter);

            // ==============================
            // VERSIÓN
            // ==============================
            Label lblVersion = new Label();

            lblVersion.Text = "v1.0";
            lblVersion.ForeColor = Color.FromArgb(70, 95, 130);
            lblVersion.Font = new Font("Segoe UI", 8);

            lblVersion.AutoSize = false;
            lblVersion.Size = new Size(100, 20);
            lblVersion.Location = new Point(600, 400);
            lblVersion.TextAlign = ContentAlignment.MiddleRight;

            this.Controls.Add(lblVersion);
        }

        private void ConfigurarCarga()
        {
            timerCarga = new Timer();

            // 30 ms x 100 = aproximadamente 3 segundos
            timerCarga.Interval = 30;

            timerCarga.Tick += TimerCarga_Tick;

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