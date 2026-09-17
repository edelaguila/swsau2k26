namespace Capa_Vista_Auditoria
{
    partial class Frm_Recuperar_Contraseña
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Recuperar_Contraseña));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.Lbl_recuperar_contrasena = new System.Windows.Forms.Label();
            this.Lbl_subtitulo = new System.Windows.Forms.Label();
            this.Btn_Verificar_Token = new System.Windows.Forms.Button();
            this.Txt_Verificar_Token = new System.Windows.Forms.TextBox();
            this.Txt_Mostrar_Token = new System.Windows.Forms.TextBox();
            this.Btn_Generar_Token = new System.Windows.Forms.Button();
            this.Txt_confirmar_contrasena = new System.Windows.Forms.TextBox();
            this.Txt_nueva_contrasena = new System.Windows.Forms.TextBox();
            this.Txt_usuario = new System.Windows.Forms.TextBox();
            this.Btn_Regresar = new System.Windows.Forms.Button();
            this.Btn_Guardar = new System.Windows.Forms.Button();
            this.Lbl_confirmar_contrasena = new System.Windows.Forms.Label();
            this.Lbl_nueva_contrasena = new System.Windows.Forms.Label();
            this.Lbl_verificar_token = new System.Windows.Forms.Label();
            this.Lbl_token_generado = new System.Windows.Forms.Label();
            this.Lbl_usuario = new System.Windows.Forms.Label();
            this.Btn_ayuda = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.pnlHeader.Controls.Add(this.Lbl_recuperar_contrasena);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(760, 100);
            this.pnlHeader.TabIndex = 108;
            // 
            // Lbl_recuperar_contrasena
            // 
            this.Lbl_recuperar_contrasena.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Lbl_recuperar_contrasena.Font = new System.Drawing.Font("Segoe UI", 21F, System.Drawing.FontStyle.Bold);
            this.Lbl_recuperar_contrasena.ForeColor = System.Drawing.Color.White;
            this.Lbl_recuperar_contrasena.Location = new System.Drawing.Point(0, 0);
            this.Lbl_recuperar_contrasena.Name = "Lbl_recuperar_contrasena";
            this.Lbl_recuperar_contrasena.Size = new System.Drawing.Size(760, 100);
            this.Lbl_recuperar_contrasena.TabIndex = 97;
            this.Lbl_recuperar_contrasena.Text = "RECUPERAR CONTRASEÑA";
            this.Lbl_recuperar_contrasena.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lbl_subtitulo
            // 
            this.Lbl_subtitulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Lbl_subtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(190)))), ((int)(((byte)(220)))));
            this.Lbl_subtitulo.Location = new System.Drawing.Point(0, 115);
            this.Lbl_subtitulo.Name = "Lbl_subtitulo";
            this.Lbl_subtitulo.Size = new System.Drawing.Size(760, 30);
            this.Lbl_subtitulo.TabIndex = 109;
            this.Lbl_subtitulo.Text = "Genere y verifique un token para cambiar su contraseña";
            this.Lbl_subtitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Btn_Verificar_Token
            // 
            this.Btn_Verificar_Token.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(120)))), ((int)(((byte)(220)))));
            this.Btn_Verificar_Token.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Verificar_Token.FlatAppearance.BorderSize = 0;
            this.Btn_Verificar_Token.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Verificar_Token.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.Btn_Verificar_Token.ForeColor = System.Drawing.Color.White;
            this.Btn_Verificar_Token.Location = new System.Drawing.Point(465, 338);
            this.Btn_Verificar_Token.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_Verificar_Token.Name = "Btn_Verificar_Token";
            this.Btn_Verificar_Token.Size = new System.Drawing.Size(145, 35);
            this.Btn_Verificar_Token.TabIndex = 106;
            this.Btn_Verificar_Token.Text = "VERIFICAR";
            this.Btn_Verificar_Token.UseVisualStyleBackColor = false;
            this.Btn_Verificar_Token.Click += new System.EventHandler(this.Btn_Verificar_Token_Click);
            // 
            // Txt_Verificar_Token
            // 
            this.Txt_Verificar_Token.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(42)))), ((int)(((byte)(70)))));
            this.Txt_Verificar_Token.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Txt_Verificar_Token.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.Txt_Verificar_Token.ForeColor = System.Drawing.Color.White;
            this.Txt_Verificar_Token.Location = new System.Drawing.Point(150, 340);
            this.Txt_Verificar_Token.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Txt_Verificar_Token.Name = "Txt_Verificar_Token";
            this.Txt_Verificar_Token.Size = new System.Drawing.Size(300, 30);
            this.Txt_Verificar_Token.TabIndex = 105;
            // 
            // Txt_Mostrar_Token
            // 
            this.Txt_Mostrar_Token.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(42)))), ((int)(((byte)(70)))));
            this.Txt_Mostrar_Token.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Txt_Mostrar_Token.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.Txt_Mostrar_Token.ForeColor = System.Drawing.Color.White;
            this.Txt_Mostrar_Token.Location = new System.Drawing.Point(150, 265);
            this.Txt_Mostrar_Token.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Txt_Mostrar_Token.Name = "Txt_Mostrar_Token";
            this.Txt_Mostrar_Token.ReadOnly = true;
            this.Txt_Mostrar_Token.Size = new System.Drawing.Size(460, 30);
            this.Txt_Mostrar_Token.TabIndex = 104;
            // 
            // Btn_Generar_Token
            // 
            this.Btn_Generar_Token.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(120)))), ((int)(((byte)(220)))));
            this.Btn_Generar_Token.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Generar_Token.FlatAppearance.BorderSize = 0;
            this.Btn_Generar_Token.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Generar_Token.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.Btn_Generar_Token.ForeColor = System.Drawing.Color.White;
            this.Btn_Generar_Token.Location = new System.Drawing.Point(465, 188);
            this.Btn_Generar_Token.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_Generar_Token.Name = "Btn_Generar_Token";
            this.Btn_Generar_Token.Size = new System.Drawing.Size(145, 35);
            this.Btn_Generar_Token.TabIndex = 103;
            this.Btn_Generar_Token.Text = "GENERAR TOKEN";
            this.Btn_Generar_Token.UseVisualStyleBackColor = false;
            this.Btn_Generar_Token.Click += new System.EventHandler(this.Btn_Generar_Token_Click);
            // 
            // Txt_confirmar_contrasena
            // 
            this.Txt_confirmar_contrasena.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(42)))), ((int)(((byte)(70)))));
            this.Txt_confirmar_contrasena.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Txt_confirmar_contrasena.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.Txt_confirmar_contrasena.ForeColor = System.Drawing.Color.White;
            this.Txt_confirmar_contrasena.Location = new System.Drawing.Point(150, 485);
            this.Txt_confirmar_contrasena.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Txt_confirmar_contrasena.Name = "Txt_confirmar_contrasena";
            this.Txt_confirmar_contrasena.Size = new System.Drawing.Size(460, 30);
            this.Txt_confirmar_contrasena.TabIndex = 102;
            this.Txt_confirmar_contrasena.UseSystemPasswordChar = true;
            // 
            // Txt_nueva_contrasena
            // 
            this.Txt_nueva_contrasena.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(42)))), ((int)(((byte)(70)))));
            this.Txt_nueva_contrasena.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Txt_nueva_contrasena.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.Txt_nueva_contrasena.ForeColor = System.Drawing.Color.White;
            this.Txt_nueva_contrasena.Location = new System.Drawing.Point(150, 415);
            this.Txt_nueva_contrasena.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Txt_nueva_contrasena.Name = "Txt_nueva_contrasena";
            this.Txt_nueva_contrasena.Size = new System.Drawing.Size(460, 30);
            this.Txt_nueva_contrasena.TabIndex = 101;
            this.Txt_nueva_contrasena.UseSystemPasswordChar = true;
            // 
            // Txt_usuario
            // 
            this.Txt_usuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(42)))), ((int)(((byte)(70)))));
            this.Txt_usuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Txt_usuario.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.Txt_usuario.ForeColor = System.Drawing.Color.White;
            this.Txt_usuario.Location = new System.Drawing.Point(150, 190);
            this.Txt_usuario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Txt_usuario.Name = "Txt_usuario";
            this.Txt_usuario.Size = new System.Drawing.Size(300, 30);
            this.Txt_usuario.TabIndex = 100;
            // 
            // Btn_Regresar
            // 
            this.Btn_Regresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(72)))), ((int)(((byte)(100)))));
            this.Btn_Regresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Regresar.FlatAppearance.BorderSize = 0;
            this.Btn_Regresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Regresar.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.Btn_Regresar.ForeColor = System.Drawing.Color.White;
            this.Btn_Regresar.Location = new System.Drawing.Point(395, 545);
            this.Btn_Regresar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_Regresar.Name = "Btn_Regresar";
            this.Btn_Regresar.Size = new System.Drawing.Size(215, 45);
            this.Btn_Regresar.TabIndex = 99;
            this.Btn_Regresar.Text = "REGRESAR";
            this.Btn_Regresar.UseVisualStyleBackColor = false;
            this.Btn_Regresar.Click += new System.EventHandler(this.Btn_Regresar_Click);
            // 
            // Btn_Guardar
            // 
            this.Btn_Guardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(105)))));
            this.Btn_Guardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Guardar.FlatAppearance.BorderSize = 0;
            this.Btn_Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Guardar.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.Btn_Guardar.ForeColor = System.Drawing.Color.White;
            this.Btn_Guardar.Location = new System.Drawing.Point(150, 545);
            this.Btn_Guardar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_Guardar.Name = "Btn_Guardar";
            this.Btn_Guardar.Size = new System.Drawing.Size(215, 45);
            this.Btn_Guardar.TabIndex = 98;
            this.Btn_Guardar.Text = "GUARDAR";
            this.Btn_Guardar.UseVisualStyleBackColor = false;
            this.Btn_Guardar.Click += new System.EventHandler(this.Btn_Guardar_Click);
            // 
            // Lbl_confirmar_contrasena
            // 
            this.Lbl_confirmar_contrasena.AutoSize = true;
            this.Lbl_confirmar_contrasena.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Lbl_confirmar_contrasena.ForeColor = System.Drawing.Color.White;
            this.Lbl_confirmar_contrasena.Location = new System.Drawing.Point(150, 460);
            this.Lbl_confirmar_contrasena.Name = "Lbl_confirmar_contrasena";
            this.Lbl_confirmar_contrasena.Size = new System.Drawing.Size(133, 19);
            this.Lbl_confirmar_contrasena.TabIndex = 96;
            this.Lbl_confirmar_contrasena.Text = "Confirmar contraseña";
            // 
            // Lbl_nueva_contrasena
            // 
            this.Lbl_nueva_contrasena.AutoSize = true;
            this.Lbl_nueva_contrasena.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Lbl_nueva_contrasena.ForeColor = System.Drawing.Color.White;
            this.Lbl_nueva_contrasena.Location = new System.Drawing.Point(150, 390);
            this.Lbl_nueva_contrasena.Name = "Lbl_nueva_contrasena";
            this.Lbl_nueva_contrasena.Size = new System.Drawing.Size(114, 19);
            this.Lbl_nueva_contrasena.TabIndex = 95;
            this.Lbl_nueva_contrasena.Text = "Nueva contraseña";
            // 
            // Lbl_verificar_token
            // 
            this.Lbl_verificar_token.AutoSize = true;
            this.Lbl_verificar_token.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Lbl_verificar_token.ForeColor = System.Drawing.Color.White;
            this.Lbl_verificar_token.Location = new System.Drawing.Point(150, 315);
            this.Lbl_verificar_token.Name = "Lbl_verificar_token";
            this.Lbl_verificar_token.Size = new System.Drawing.Size(102, 19);
            this.Lbl_verificar_token.TabIndex = 110;
            this.Lbl_verificar_token.Text = "Ingrese el token";
            // 
            // Lbl_token_generado
            // 
            this.Lbl_token_generado.AutoSize = true;
            this.Lbl_token_generado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Lbl_token_generado.ForeColor = System.Drawing.Color.White;
            this.Lbl_token_generado.Location = new System.Drawing.Point(150, 240);
            this.Lbl_token_generado.Name = "Lbl_token_generado";
            this.Lbl_token_generado.Size = new System.Drawing.Size(110, 19);
            this.Lbl_token_generado.TabIndex = 111;
            this.Lbl_token_generado.Text = "Token generado";
            // 
            // Lbl_usuario
            // 
            this.Lbl_usuario.AutoSize = true;
            this.Lbl_usuario.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Lbl_usuario.ForeColor = System.Drawing.Color.White;
            this.Lbl_usuario.Location = new System.Drawing.Point(150, 165);
            this.Lbl_usuario.Name = "Lbl_usuario";
            this.Lbl_usuario.Size = new System.Drawing.Size(56, 19);
            this.Lbl_usuario.TabIndex = 94;
            this.Lbl_usuario.Text = "Usuario";
            // 
            // Btn_ayuda
            // 
            this.Btn_ayuda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(120)))), ((int)(((byte)(220)))));
            this.Btn_ayuda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_ayuda.FlatAppearance.BorderSize = 0;
            this.Btn_ayuda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_ayuda.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.Btn_ayuda.ForeColor = System.Drawing.Color.White;
            this.Btn_ayuda.Image = ((System.Drawing.Image)(resources.GetObject("Btn_ayuda.Image")));
            this.Btn_ayuda.Location = new System.Drawing.Point(700, 115);
            this.Btn_ayuda.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_ayuda.Name = "Btn_ayuda";
            this.Btn_ayuda.Size = new System.Drawing.Size(40, 40);
            this.Btn_ayuda.TabIndex = 107;
            this.Btn_ayuda.Text = "?";
            this.Btn_ayuda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_ayuda.UseVisualStyleBackColor = false;
            this.Btn_ayuda.Click += new System.EventHandler(this.Btn_ayuda_Click);
            // 
            // Frm_Recuperar_Contraseña
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(27)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(760, 620);
            this.Controls.Add(this.Lbl_usuario);
            this.Controls.Add(this.Txt_usuario);
            this.Controls.Add(this.Lbl_token_generado);
            this.Controls.Add(this.Txt_Mostrar_Token);
            this.Controls.Add(this.Lbl_verificar_token);
            this.Controls.Add(this.Txt_Verificar_Token);
            this.Controls.Add(this.Lbl_nueva_contrasena);
            this.Controls.Add(this.Txt_nueva_contrasena);
            this.Controls.Add(this.Lbl_confirmar_contrasena);
            this.Controls.Add(this.Txt_confirmar_contrasena);
            this.Controls.Add(this.Btn_Generar_Token);
            this.Controls.Add(this.Btn_Verificar_Token);
            this.Controls.Add(this.Btn_Guardar);
            this.Controls.Add(this.Btn_Regresar);
            this.Controls.Add(this.Btn_ayuda);
            this.Controls.Add(this.Lbl_subtitulo);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Frm_Recuperar_Contraseña";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auditoría - Recuperar Contraseña";
            this.pnlHeader.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label Lbl_recuperar_contrasena;
        private System.Windows.Forms.Label Lbl_subtitulo;
        private System.Windows.Forms.Button Btn_Verificar_Token;
        private System.Windows.Forms.TextBox Txt_Verificar_Token;
        private System.Windows.Forms.TextBox Txt_Mostrar_Token;
        private System.Windows.Forms.Button Btn_Generar_Token;
        private System.Windows.Forms.TextBox Txt_confirmar_contrasena;
        private System.Windows.Forms.TextBox Txt_nueva_contrasena;
        private System.Windows.Forms.TextBox Txt_usuario;
        private System.Windows.Forms.Button Btn_Regresar;
        private System.Windows.Forms.Button Btn_Guardar;
        private System.Windows.Forms.Label Lbl_confirmar_contrasena;
        private System.Windows.Forms.Label Lbl_nueva_contrasena;
        private System.Windows.Forms.Label Lbl_verificar_token;
        private System.Windows.Forms.Label Lbl_token_generado;
        private System.Windows.Forms.Label Lbl_usuario;
        private System.Windows.Forms.Button Btn_ayuda;
    }
}
