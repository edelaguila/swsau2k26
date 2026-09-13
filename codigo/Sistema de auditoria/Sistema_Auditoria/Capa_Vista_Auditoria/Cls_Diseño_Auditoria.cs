using System.Drawing;
using System.Windows.Forms;

namespace Capa_Vista_Auditoria
{
    public class Cls_Diseño_Auditoria
    {
        public void AplicarDiseñoLogin(
            Form formulario,
            TextBox txtUsuario,
            TextBox txtContrasena,
            CheckBox chkMostrarContrasena,
            LinkLabel lblkRecuperarContrasena,
            Button btnIniciarSesion)
        {
            formulario.Text = "Auditoría - Inicio de Sesión";
            formulario.ClientSize = new Size(700, 430);
            formulario.StartPosition = FormStartPosition.CenterScreen;
            formulario.FormBorderStyle = FormBorderStyle.FixedSingle;
            formulario.MaximizeBox = false;
            formulario.BackColor = Color.FromArgb(15, 27, 52);

            // Ocultar labels anteriores
            foreach (Control control in formulario.Controls)
            {
                if (control is Label label)
                {
                    if (label.Text == "Usuario:" ||
                        label.Text == "Contraseña:" ||
                        label.Text == "Auditoria" ||
                        label.Text == "Auditoría")
                    {
                        label.Visible = false;
                    }
                }
            }

            // HEADER
            Panel panelHeader = new Panel();
            panelHeader.BackColor = Color.FromArgb(8, 17, 35);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Height = 110;

            formulario.Controls.Add(panelHeader);

            // TÍTULO
            Label lblTitulo = new Label();

            lblTitulo.Text = "MÓDULO DE AUDITORÍA";
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            lblTitulo.Dock = DockStyle.Fill;
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            panelHeader.Controls.Add(lblTitulo);

            // SUBTÍTULO
            Label lblSubtitulo = new Label();

            lblSubtitulo.Text = "Ingrese sus credenciales para continuar";
            lblSubtitulo.ForeColor = Color.FromArgb(170, 190, 220);
            lblSubtitulo.Font = new Font("Segoe UI", 10);

            lblSubtitulo.AutoSize = false;
            lblSubtitulo.Size = new Size(700, 30);
            lblSubtitulo.Location = new Point(0, 130);
            lblSubtitulo.TextAlign = ContentAlignment.MiddleCenter;

            formulario.Controls.Add(lblSubtitulo);

            // LABEL USUARIO
            Label lblUsuario = new Label();

            lblUsuario.Text = "Usuario";
            lblUsuario.ForeColor = Color.White;
            lblUsuario.Font = new Font("Segoe UI", 10);
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(180, 180);

            formulario.Controls.Add(lblUsuario);

            // USUARIO
            txtUsuario.Location = new Point(180, 205);
            txtUsuario.Size = new Size(340, 30);
            txtUsuario.BackColor = Color.FromArgb(25, 42, 70);
            txtUsuario.ForeColor = Color.White;
            txtUsuario.BorderStyle = BorderStyle.FixedSingle;
            txtUsuario.Font = new Font("Segoe UI", 11);

            // LABEL CONTRASEÑA
            Label lblContrasena = new Label();

            lblContrasena.Text = "Contraseña";
            lblContrasena.ForeColor = Color.White;
            lblContrasena.Font = new Font("Segoe UI", 10);
            lblContrasena.AutoSize = true;
            lblContrasena.Location = new Point(180, 250);

            formulario.Controls.Add(lblContrasena);

            // CONTRASEÑA
            txtContrasena.Location = new Point(180, 275);
            txtContrasena.Size = new Size(340, 30);
            txtContrasena.BackColor = Color.FromArgb(25, 42, 70);
            txtContrasena.ForeColor = Color.White;
            txtContrasena.BorderStyle = BorderStyle.FixedSingle;
            txtContrasena.Font = new Font("Segoe UI", 11);

            // CHECKBOX
            chkMostrarContrasena.Text = "Mostrar contraseña";
            chkMostrarContrasena.ForeColor = Color.FromArgb(180, 195, 215);
            chkMostrarContrasena.BackColor = Color.Transparent;
            chkMostrarContrasena.Font = new Font("Segoe UI", 9);
            chkMostrarContrasena.AutoSize = true;
            chkMostrarContrasena.Location = new Point(180, 315);

            // RECUPERAR CONTRASEÑA
            lblkRecuperarContrasena.Text = "¿Olvidó su contraseña?";
            lblkRecuperarContrasena.LinkColor = Color.FromArgb(90, 165, 255);
            lblkRecuperarContrasena.ActiveLinkColor = Color.FromArgb(130, 190, 255);
            lblkRecuperarContrasena.VisitedLinkColor = Color.FromArgb(90, 165, 255);
            lblkRecuperarContrasena.Font = new Font("Segoe UI", 9);
            lblkRecuperarContrasena.AutoSize = true;
            lblkRecuperarContrasena.Location = new Point(365, 317);

            // BOTÓN
            btnIniciarSesion.Text = "INICIAR SESIÓN";
            btnIniciarSesion.Size = new Size(340, 48);
            btnIniciarSesion.Location = new Point(180, 355);
            btnIniciarSesion.BackColor = Color.FromArgb(0, 150, 105);
            btnIniciarSesion.ForeColor = Color.White;
            btnIniciarSesion.FlatStyle = FlatStyle.Flat;
            btnIniciarSesion.FlatAppearance.BorderSize = 0;
            btnIniciarSesion.Font =
                new Font("Segoe UI Semibold", 11, FontStyle.Bold);
            btnIniciarSesion.Cursor = Cursors.Hand;

            btnIniciarSesion.MouseEnter += (s, e) =>
            {
                btnIniciarSesion.BackColor = Color.FromArgb(0, 175, 120);
            };

            btnIniciarSesion.MouseLeave += (s, e) =>
            {
                btnIniciarSesion.BackColor = Color.FromArgb(0, 150, 105);
            };

            panelHeader.BringToFront();
            lblSubtitulo.BringToFront();
            lblUsuario.BringToFront();
            lblContrasena.BringToFront();

            txtUsuario.BringToFront();
            txtContrasena.BringToFront();

            chkMostrarContrasena.BringToFront();
            lblkRecuperarContrasena.BringToFront();
            btnIniciarSesion.BringToFront();
        }
        public void AplicarDiseñoMenu(
    Form formulario,
    Label labelTitulo,
    Button btnSeguridad,
    Button btnAuditoria)
        {
            // ==============================
            // FORMULARIO
            // ==============================
            formulario.Text = "Sistema de Auditoría y Seguridad";
            formulario.ClientSize = new Size(820, 520);
            formulario.StartPosition = FormStartPosition.CenterScreen;
            formulario.FormBorderStyle = FormBorderStyle.FixedSingle;
            formulario.MaximizeBox = false;
            formulario.BackColor = Color.FromArgb(15, 27, 52);


            // ==============================
            // HEADER
            // ==============================
            Panel panelHeader = new Panel();

            panelHeader.Name = "panelHeader";
            panelHeader.BackColor = Color.FromArgb(8, 17, 35);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Height = 120;

            formulario.Controls.Add(panelHeader);


            // ==============================
            // TÍTULO
            // ==============================
            labelTitulo.Parent = panelHeader;
            labelTitulo.Text = "SISTEMA DE AUDITORES";
            labelTitulo.ForeColor = Color.White;
            labelTitulo.Font = new Font(
                "Segoe UI",
                23,
                FontStyle.Bold
            );

            labelTitulo.AutoSize = false;
            labelTitulo.Dock = DockStyle.Fill;
            labelTitulo.TextAlign = ContentAlignment.MiddleCenter;
            labelTitulo.Padding = new Padding(0);
            labelTitulo.Margin = new Padding(0);


            // ==============================
            // SUBTÍTULO
            // ==============================
            Label lblSubtitulo = new Label();

            lblSubtitulo.Text =
                "Seleccione el módulo al que desea ingresar";

            lblSubtitulo.ForeColor =
                Color.FromArgb(170, 190, 220);

            lblSubtitulo.Font =
                new Font("Segoe UI", 11);

            lblSubtitulo.AutoSize = false;
            lblSubtitulo.Size = new Size(820, 30);
            lblSubtitulo.Location = new Point(0, 155);
            lblSubtitulo.TextAlign = ContentAlignment.MiddleCenter;

            formulario.Controls.Add(lblSubtitulo);


            // ==============================
            // PANEL DE OPCIONES
            // ==============================
            Panel panelOpciones = new Panel();

            panelOpciones.Size = new Size(620, 170);
            panelOpciones.Location = new Point(100, 205);
            panelOpciones.BackColor = Color.FromArgb(18, 33, 62);

            formulario.Controls.Add(panelOpciones);


            // ==============================
            // BOTÓN SEGURIDAD
            // ==============================
            btnSeguridad.Parent = panelOpciones;

            btnSeguridad.Text = "🔒\r\n\r\nSEGURIDAD";

            btnSeguridad.Size =
                new Size(250, 120);

            btnSeguridad.Location =
                new Point(35, 25);

            btnSeguridad.BackColor =
                Color.FromArgb(30, 120, 220);

            btnSeguridad.ForeColor =
                Color.White;

            btnSeguridad.FlatStyle =
                FlatStyle.Flat;

            btnSeguridad.FlatAppearance.BorderSize =
                0;

            btnSeguridad.Font =
                new Font(
                    "Segoe UI Semibold",
                    14,
                    FontStyle.Bold
                );

            btnSeguridad.Cursor =
                Cursors.Hand;

            btnSeguridad.TextAlign =
                ContentAlignment.MiddleCenter;


            // HOVER SEGURIDAD
            btnSeguridad.MouseEnter += (s, e) =>
            {
                btnSeguridad.BackColor =
                    Color.FromArgb(45, 135, 235);
            };

            btnSeguridad.MouseLeave += (s, e) =>
            {
                btnSeguridad.BackColor =
                    Color.FromArgb(30, 120, 220);
            };


            // ==============================
            // BOTÓN AUDITORÍA
            // ==============================
            btnAuditoria.Parent = panelOpciones;

            btnAuditoria.Text = "📋\r\n\r\nAUDITORÍA";

            btnAuditoria.Size =
                new Size(250, 120);

            btnAuditoria.Location =
                new Point(335, 25);

            btnAuditoria.BackColor =
                Color.FromArgb(0, 150, 105);

            btnAuditoria.ForeColor =
                Color.White;

            btnAuditoria.FlatStyle =
                FlatStyle.Flat;

            btnAuditoria.FlatAppearance.BorderSize =
                0;

            btnAuditoria.Font =
                new Font(
                    "Segoe UI Semibold",
                    14,
                    FontStyle.Bold
                );

            btnAuditoria.Cursor =
                Cursors.Hand;

            btnAuditoria.TextAlign =
                ContentAlignment.MiddleCenter;


            // HOVER AUDITORÍA
            btnAuditoria.MouseEnter += (s, e) =>
            {
                btnAuditoria.BackColor =
                    Color.FromArgb(0, 175, 120);
            };

            btnAuditoria.MouseLeave += (s, e) =>
            {
                btnAuditoria.BackColor =
                    Color.FromArgb(0, 150, 105);
            };


            // ==============================
            // TEXTO DE AYUDA
            // ==============================
            Label lblAyuda = new Label();

            lblAyuda.Text =
                "Seguridad administra usuarios y accesos   •   Auditoría gestiona procesos de auditoría";

            lblAyuda.ForeColor =
                Color.FromArgb(125, 145, 175);

            lblAyuda.Font =
                new Font("Segoe UI", 9);

            lblAyuda.AutoSize = false;
            lblAyuda.Size = new Size(820, 30);
            lblAyuda.Location = new Point(0, 395);
            lblAyuda.TextAlign = ContentAlignment.MiddleCenter;

            formulario.Controls.Add(lblAyuda);


            // ==============================
            // LÍNEA FOOTER
            // ==============================
            Panel lineaFooter = new Panel();

            lineaFooter.BackColor =
                Color.FromArgb(35, 52, 80);

            lineaFooter.Size =
                new Size(700, 1);

            lineaFooter.Location =
                new Point(60, 455);

            formulario.Controls.Add(lineaFooter);


            // ==============================
            // FOOTER
            // ==============================
            Label lblFooter = new Label();

            lblFooter.Text =
                "Control Interno   •   Seguridad   •   Cumplimiento Normativo";

            lblFooter.ForeColor =
                Color.FromArgb(115, 135, 165);

            lblFooter.Font =
                new Font("Segoe UI", 9);

            lblFooter.AutoSize = false;
            lblFooter.Size = new Size(820, 35);
            lblFooter.Location = new Point(0, 465);
            lblFooter.TextAlign = ContentAlignment.MiddleCenter;

            formulario.Controls.Add(lblFooter);


            // ==============================
            // ORDEN VISUAL
            // ==============================
            panelHeader.BringToFront();
            lblSubtitulo.BringToFront();
            panelOpciones.BringToFront();
            lblAyuda.BringToFront();
            lineaFooter.BringToFront();
            lblFooter.BringToFront();
        }
    

    // Arón Esquit 0901-22-13036 13/09/2026
    public void AplicarDiseñoRecuperarContrasena(
        Form formulario,
        TextBox txtUsuario,
        TextBox txtMostrarToken,
        TextBox txtVerificarToken,
        TextBox txtNuevaContrasena,
        TextBox txtConfirmarContrasena,
        Button btnGenerarToken,
        Button btnVerificarToken,
        Button btnGuardar,
        Button btnRegresar,
        Button btnAyuda)
        {
            // Formulario
            formulario.Text = "Auditoría - Recuperar Contraseña";
            formulario.ClientSize = new Size(760, 620);
            formulario.StartPosition = FormStartPosition.CenterScreen;
            formulario.FormBorderStyle = FormBorderStyle.FixedSingle;
            formulario.MaximizeBox = false;
            formulario.BackColor = Color.FromArgb(15, 27, 52);

            // Ocultar labels anteriores
            foreach (Control control in formulario.Controls)
            {
                if (control is Label)
                {
                    control.Visible = false;
                }
            }

            // Header
            Panel panelHeader = new Panel();
            panelHeader.BackColor = Color.FromArgb(8, 17, 35);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Height = 100;

            formulario.Controls.Add(panelHeader);

            // Título
            Label lblTitulo = new Label();
            lblTitulo.Text = "RECUPERAR CONTRASEÑA";
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Font = new Font("Segoe UI", 21, FontStyle.Bold);
            lblTitulo.Dock = DockStyle.Fill;
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            panelHeader.Controls.Add(lblTitulo);

            // Subtítulo
            Label lblSubtitulo = new Label();
            lblSubtitulo.Text = "Genere y verifique un token para cambiar su contraseña";
            lblSubtitulo.ForeColor = Color.FromArgb(170, 190, 220);
            lblSubtitulo.Font = new Font("Segoe UI", 10);
            lblSubtitulo.AutoSize = false;
            lblSubtitulo.Size = new Size(760, 30);
            lblSubtitulo.Location = new Point(0, 115);
            lblSubtitulo.TextAlign = ContentAlignment.MiddleCenter;

            formulario.Controls.Add(lblSubtitulo);

            // Usuario
            Label lblUsuario = new Label();
            lblUsuario.Text = "Usuario";
            lblUsuario.ForeColor = Color.White;
            lblUsuario.Font = new Font("Segoe UI", 10);
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(150, 165);

            formulario.Controls.Add(lblUsuario);

            txtUsuario.Location = new Point(150, 190);
            txtUsuario.Size = new Size(300, 30);
            txtUsuario.BackColor = Color.FromArgb(25, 42, 70);
            txtUsuario.ForeColor = Color.White;
            txtUsuario.BorderStyle = BorderStyle.FixedSingle;
            txtUsuario.Font = new Font("Segoe UI", 11);

            // Generar token
            btnGenerarToken.Text = "GENERAR TOKEN";
            btnGenerarToken.Size = new Size(145, 35);
            btnGenerarToken.Location = new Point(465, 188);
            btnGenerarToken.BackColor = Color.FromArgb(30, 120, 220);
            btnGenerarToken.ForeColor = Color.White;
            btnGenerarToken.FlatStyle = FlatStyle.Flat;
            btnGenerarToken.FlatAppearance.BorderSize = 0;
            btnGenerarToken.Font =
                new Font("Segoe UI Semibold", 9, FontStyle.Bold);
            btnGenerarToken.Cursor = Cursors.Hand;

            // Token generado
            Label lblTokenGenerado = new Label();
            lblTokenGenerado.Text = "Token generado";
            lblTokenGenerado.ForeColor = Color.White;
            lblTokenGenerado.Font = new Font("Segoe UI", 10);
            lblTokenGenerado.AutoSize = true;
            lblTokenGenerado.Location = new Point(150, 240);

            formulario.Controls.Add(lblTokenGenerado);

            txtMostrarToken.Location = new Point(150, 265);
            txtMostrarToken.Size = new Size(460, 30);
            txtMostrarToken.BackColor = Color.FromArgb(25, 42, 70);
            txtMostrarToken.ForeColor = Color.White;
            txtMostrarToken.BorderStyle = BorderStyle.FixedSingle;
            txtMostrarToken.Font = new Font("Segoe UI", 11);
            txtMostrarToken.ReadOnly = true;

            // Verificar token
            Label lblVerificar = new Label();
            lblVerificar.Text = "Ingrese el token";
            lblVerificar.ForeColor = Color.White;
            lblVerificar.Font = new Font("Segoe UI", 10);
            lblVerificar.AutoSize = true;
            lblVerificar.Location = new Point(150, 315);

            formulario.Controls.Add(lblVerificar);

            txtVerificarToken.Location = new Point(150, 340);
            txtVerificarToken.Size = new Size(300, 30);
            txtVerificarToken.BackColor = Color.FromArgb(25, 42, 70);
            txtVerificarToken.ForeColor = Color.White;
            txtVerificarToken.BorderStyle = BorderStyle.FixedSingle;
            txtVerificarToken.Font = new Font("Segoe UI", 11);

            btnVerificarToken.Text = "VERIFICAR";
            btnVerificarToken.Size = new Size(145, 35);
            btnVerificarToken.Location = new Point(465, 338);
            btnVerificarToken.BackColor = Color.FromArgb(30, 120, 220);
            btnVerificarToken.ForeColor = Color.White;
            btnVerificarToken.FlatStyle = FlatStyle.Flat;
            btnVerificarToken.FlatAppearance.BorderSize = 0;
            btnVerificarToken.Font =
                new Font("Segoe UI Semibold", 9, FontStyle.Bold);
            btnVerificarToken.Cursor = Cursors.Hand;

            // Nueva contraseña
            Label lblNueva = new Label();
            lblNueva.Text = "Nueva contraseña";
            lblNueva.ForeColor = Color.White;
            lblNueva.Font = new Font("Segoe UI", 10);
            lblNueva.AutoSize = true;
            lblNueva.Location = new Point(150, 390);

            formulario.Controls.Add(lblNueva);

            txtNuevaContrasena.Location = new Point(150, 415);
            txtNuevaContrasena.Size = new Size(460, 30);
            txtNuevaContrasena.BackColor = Color.FromArgb(25, 42, 70);
            txtNuevaContrasena.ForeColor = Color.White;
            txtNuevaContrasena.BorderStyle = BorderStyle.FixedSingle;
            txtNuevaContrasena.Font = new Font("Segoe UI", 11);
            txtNuevaContrasena.UseSystemPasswordChar = true;

            // Confirmar contraseña
            Label lblConfirmar = new Label();
            lblConfirmar.Text = "Confirmar contraseña";
            lblConfirmar.ForeColor = Color.White;
            lblConfirmar.Font = new Font("Segoe UI", 10);
            lblConfirmar.AutoSize = true;
            lblConfirmar.Location = new Point(150, 460);

            formulario.Controls.Add(lblConfirmar);

            txtConfirmarContrasena.Location = new Point(150, 485);
            txtConfirmarContrasena.Size = new Size(460, 30);
            txtConfirmarContrasena.BackColor = Color.FromArgb(25, 42, 70);
            txtConfirmarContrasena.ForeColor = Color.White;
            txtConfirmarContrasena.BorderStyle = BorderStyle.FixedSingle;
            txtConfirmarContrasena.Font = new Font("Segoe UI", 11);
            txtConfirmarContrasena.UseSystemPasswordChar = true;

            // Guardar
            btnGuardar.Text = "GUARDAR";
            btnGuardar.Size = new Size(215, 45);
            btnGuardar.Location = new Point(150, 545);
            btnGuardar.BackColor = Color.FromArgb(0, 150, 105);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.Font =
                new Font("Segoe UI Semibold", 10, FontStyle.Bold);
            btnGuardar.Cursor = Cursors.Hand;

            // Regresar
            btnRegresar.Text = "REGRESAR";
            btnRegresar.Size = new Size(215, 45);
            btnRegresar.Location = new Point(395, 545);
            btnRegresar.BackColor = Color.FromArgb(55, 72, 100);
            btnRegresar.ForeColor = Color.White;
            btnRegresar.FlatStyle = FlatStyle.Flat;
            btnRegresar.FlatAppearance.BorderSize = 0;
            btnRegresar.Font =
                new Font("Segoe UI Semibold", 10, FontStyle.Bold);
            btnRegresar.Cursor = Cursors.Hand;

            // Ayuda
            btnAyuda.Text = "?";
            btnAyuda.Size = new Size(40, 40);
            btnAyuda.Location = new Point(700, 115);
            btnAyuda.BackColor = Color.FromArgb(30, 120, 220);
            btnAyuda.ForeColor = Color.White;
            btnAyuda.FlatStyle = FlatStyle.Flat;
            btnAyuda.FlatAppearance.BorderSize = 0;
            btnAyuda.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            btnAyuda.Cursor = Cursors.Hand;

            // Orden visual
            panelHeader.BringToFront();
            lblSubtitulo.BringToFront();
            lblUsuario.BringToFront();
            lblTokenGenerado.BringToFront();
            lblVerificar.BringToFront();
            lblNueva.BringToFront();
            lblConfirmar.BringToFront();

            txtUsuario.BringToFront();
            txtMostrarToken.BringToFront();
            txtVerificarToken.BringToFront();
            txtNuevaContrasena.BringToFront();
            txtConfirmarContrasena.BringToFront();

            btnGenerarToken.BringToFront();
            btnVerificarToken.BringToFront();
            btnGuardar.BringToFront();
            btnRegresar.BringToFront();
            btnAyuda.BringToFront();
        }
    }


    }