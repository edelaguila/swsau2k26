using System;
using System.Windows.Forms;
using System.Drawing;

namespace Capa_Vista_Auditoria
{
    partial class Frm_Login_auditoria
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chkMostrarContrasena = new System.Windows.Forms.CheckBox();
            this.lblModuloSeguridad = new System.Windows.Forms.Label();
            this.lblContrasena = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.btnIniciarSesion = new System.Windows.Forms.Button();
            this.lblkRecuperarContrasena = new System.Windows.Forms.LinkLabel();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(596, 164);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(201, 169);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 41;
            this.pictureBox1.TabStop = false;
            // 
            // chkMostrarContrasena
            // 
            this.chkMostrarContrasena.AutoSize = true;
            this.chkMostrarContrasena.Font = new System.Drawing.Font("Rockwell", 10F);
            this.chkMostrarContrasena.Location = new System.Drawing.Point(472, 233);
            this.chkMostrarContrasena.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.chkMostrarContrasena.Name = "chkMostrarContrasena";
            this.chkMostrarContrasena.Size = new System.Drawing.Size(118, 44);
            this.chkMostrarContrasena.TabIndex = 40;
            this.chkMostrarContrasena.Text = "mostrar\r\ncontraseña";
            this.chkMostrarContrasena.UseVisualStyleBackColor = true;
            this.chkMostrarContrasena.CheckedChanged += new System.EventHandler(this.chkMostrarContrasena_CheckedChanged_1);
            // 
            // lblModuloSeguridad
            // 
            this.lblModuloSeguridad.AutoSize = true;
            this.lblModuloSeguridad.Font = new System.Drawing.Font("Rockwell", 18F);
            this.lblModuloSeguridad.Location = new System.Drawing.Point(332, 87);
            this.lblModuloSeguridad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblModuloSeguridad.Name = "lblModuloSeguridad";
            this.lblModuloSeguridad.Size = new System.Drawing.Size(145, 35);
            this.lblModuloSeguridad.TabIndex = 39;
            this.lblModuloSeguridad.Text = "Auditoria";
            this.lblModuloSeguridad.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblContrasena
            // 
            this.lblContrasena.AutoSize = true;
            this.lblContrasena.Font = new System.Drawing.Font("Rockwell", 10F);
            this.lblContrasena.Location = new System.Drawing.Point(116, 244);
            this.lblContrasena.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblContrasena.Name = "lblContrasena";
            this.lblContrasena.Size = new System.Drawing.Size(105, 20);
            this.lblContrasena.TabIndex = 38;
            this.lblContrasena.Text = "Contraseña:";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Rockwell", 10F);
            this.lblUsuario.Location = new System.Drawing.Point(147, 183);
            this.lblUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(75, 20);
            this.lblUsuario.TabIndex = 37;
            this.lblUsuario.Text = "Usuario:";
            // 
            // btnIniciarSesion
            // 
            this.btnIniciarSesion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(88)))));
            this.btnIniciarSesion.FlatAppearance.BorderSize = 0;
            this.btnIniciarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciarSesion.Font = new System.Drawing.Font("Rockwell", 10F);
            this.btnIniciarSesion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(214)))), ((int)(((byte)(221)))));
            this.btnIniciarSesion.Location = new System.Drawing.Point(293, 346);
            this.btnIniciarSesion.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnIniciarSesion.Name = "btnIniciarSesion";
            this.btnIniciarSesion.Size = new System.Drawing.Size(140, 48);
            this.btnIniciarSesion.TabIndex = 36;
            this.btnIniciarSesion.Text = "Iniciar Sesión";
            this.btnIniciarSesion.UseVisualStyleBackColor = false;
            this.btnIniciarSesion.Click += new System.EventHandler(this.btnIniciarSesion_Click);
            // 
            // lblkRecuperarContrasena
            // 
            this.lblkRecuperarContrasena.AutoSize = true;
            this.lblkRecuperarContrasena.Font = new System.Drawing.Font("Rockwell", 10F);
            this.lblkRecuperarContrasena.Location = new System.Drawing.Point(275, 284);
            this.lblkRecuperarContrasena.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblkRecuperarContrasena.Name = "lblkRecuperarContrasena";
            this.lblkRecuperarContrasena.Size = new System.Drawing.Size(182, 20);
            this.lblkRecuperarContrasena.TabIndex = 35;
            this.lblkRecuperarContrasena.TabStop = true;
            this.lblkRecuperarContrasena.Text = "Recuperar contraseña";
            this.lblkRecuperarContrasena.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblkRecuperarContrasena_LinkClicked_1);
            // 
            // txtContrasena
            // 
            this.txtContrasena.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(238)))));
            this.txtContrasena.Font = new System.Drawing.Font("Rockwell", 10F);
            this.txtContrasena.Location = new System.Drawing.Point(244, 236);
            this.txtContrasena.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.Size = new System.Drawing.Size(213, 27);
            this.txtContrasena.TabIndex = 34;
            this.txtContrasena.UseSystemPasswordChar = true;
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(238)))));
            this.txtUsuario.Font = new System.Drawing.Font("Rockwell", 10F);
            this.txtUsuario.Location = new System.Drawing.Point(244, 183);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(213, 27);
            this.txtUsuario.TabIndex = 33;
            // 
            // Frm_Login_auditoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 480);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.chkMostrarContrasena);
            this.Controls.Add(this.lblModuloSeguridad);
            this.Controls.Add(this.lblContrasena);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.btnIniciarSesion);
            this.Controls.Add(this.lblkRecuperarContrasena);
            this.Controls.Add(this.txtContrasena);
            this.Controls.Add(this.txtUsuario);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Frm_Login_auditoria";
            this.Text = "Frm_Login_auditoria";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private CheckBox chkMostrarContrasena;
        private Label lblModuloSeguridad;
        private Label lblContrasena;
        private Label lblUsuario;
        private Button btnIniciarSesion;
        private LinkLabel lblkRecuperarContrasena;
        private TextBox txtContrasena;
        private TextBox txtUsuario;
    }
}