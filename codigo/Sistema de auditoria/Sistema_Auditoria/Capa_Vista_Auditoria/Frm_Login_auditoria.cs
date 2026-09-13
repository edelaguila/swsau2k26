using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Controlador_Seguridad;

namespace Capa_Vista_Auditoria
{
    public partial class Frm_Login_auditoria : Form
    {
        // ==========================================
        // VARIABLES GLOBALES
        // ==========================================
        private Cls_BitacoraControlador ctrlBitacora =
            new Cls_BitacoraControlador();

        private Cls_ControladorLogin cn =
            new Cls_ControladorLogin();

        private Cls_Usuario_Controlador gUsuarioControlador =
            new Cls_Usuario_Controlador();

        // ==========================================
        // CLASE DE DISEÑO
        // ==========================================
        private Cls_Diseño_Auditoria diseño =
            new Cls_Diseño_Auditoria();


        // ==========================================
        // CONSTRUCTOR
        // ==========================================
        public Frm_Login_auditoria()
        {
            InitializeComponent();

            // Aplicar diseño del login
            diseño.AplicarDiseñoLogin(
                this,
                txtUsuario,
                txtContrasena,
                chkMostrarContrasena,
                lblkRecuperarContrasena,
                btnIniciarSesion
            );

            // Ocultar contraseña
            txtContrasena.UseSystemPasswordChar = true;

            // Evento al cerrar
            this.FormClosing += Frm_Login_FormClosing;

            // ENTER = iniciar sesión
            this.AcceptButton = btnIniciarSesion;
        }


        // ==========================================
        // CERRAR FORMULARIO
        // ==========================================
        private void Frm_Login_FormClosing(
            object sender,
            FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }


        // ==========================================
        // MOSTRAR / OCULTAR CONTRASEÑA
        // ==========================================
        private void chkMostrarContrasena_CheckedChanged(
            object sender,
            EventArgs e)
        {
            txtContrasena.UseSystemPasswordChar =
                !chkMostrarContrasena.Checked;
        }


        // ==========================================
        // RECUPERAR CONTRASEÑA
        // ==========================================
        private void lblkRecuperarContrasena_LinkClicked(
            object sender,
            LinkLabelLinkClickedEventArgs e)
        {
            Frm_Recuperar_Contrasena frmRecuperar =
                new Frm_Recuperar_Contrasena();

            frmRecuperar.Show();

            this.Hide();
        }


        // ==========================================
        // INICIAR SESIÓN
        // ==========================================
        private void btnIniciarSesion_Click(
            object sender,
            EventArgs e)
        {
            string sUsuario =
                txtUsuario.Text.Trim();

            string sContrasena =
                txtContrasena.Text.Trim();

            string sNombreUsuarioReal = "";

            string sMensaje;

            bool bLoginExitoso =
                cn.bAutenticarUsuario(
                    sUsuario,
                    sContrasena,
                    out sMensaje,
                    out int iIdUsuario,
                    out sNombreUsuarioReal
                );

            MessageBox.Show(sMensaje);

            if (bLoginExitoso)
            {
                int iIdPerfil =
                    gUsuarioControlador
                    .ObtenerIdPerfilDeUsuario(
                        iIdUsuario
                    );

                // Guardar sesión
                Cls_Usuario_Conectado.IniciarSesion(
                    iIdUsuario,
                    sNombreUsuarioReal,
                    iIdPerfil
                );

                // Registrar inicio en bitácora
                ctrlBitacora.RegistrarInicioSesion(
                    iIdUsuario
                );

                // Abrir menú principal de Auditoría
                this.Hide();

                Frm_MDI_Auditoria frmMenu =
                    new Frm_MDI_Auditoria();

                frmMenu.ShowDialog();

                this.Close();
            }
            else
            {
                txtContrasena.Clear();

                txtContrasena.Focus();
            }
        }


        // ==========================================
        // LOAD
        // ==========================================
        private void frmLogin_Load(
            object sender,
            EventArgs e)
        {
        }


        // ==========================================
        // MOVER FORMULARIO
        // ==========================================
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;


        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();


        [DllImport("user32.dll")]
        public static extern int SendMessage(
            IntPtr hWnd,
            int Msg,
            int wParam,
            int lParam
        );


        private void Pnl_Superior_MouseDown(
            object sender,
            MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();

                SendMessage(
                    Handle,
                    WM_NCLBUTTONDOWN,
                    HTCAPTION,
                    0
                );
            }
        }


        // ==========================================
        // BOTÓN CERRAR
        // ==========================================
        private void Pic_Cerrar_Click(
            object sender,
            EventArgs e)
        {
            this.Close();
        }

        private void lblkRecuperarContrasena_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Frm_Recuperar_Contraseña frmRecuperar = new Frm_Recuperar_Contraseña();

            frmRecuperar.Show();

            this.Hide();
        }

        private void chkMostrarContrasena_CheckedChanged_1(object sender, EventArgs e)
        {
            txtContrasena.UseSystemPasswordChar = !chkMostrarContrasena.Checked;
        }
    }
}
