//Inicio de código de "NOMBRE_COMPLETO" con carné: "CARNE" en la fecha de: "20/10/2026"
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Capa_Vista_Ponderacion
{
    partial class Frm_Ponderacion
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.Lbl_Titulo = new System.Windows.Forms.Label();
            this.Gpb_Datos = new System.Windows.Forms.GroupBox();
            this.Lbl_Id = new System.Windows.Forms.Label();
            this.Txt_Id = new System.Windows.Forms.TextBox();
            this.Lbl_Auditado = new System.Windows.Forms.Label();
            this.Cbo_Auditado = new System.Windows.Forms.ComboBox();
            this.Lbl_Cronograma = new System.Windows.Forms.Label();
            this.Cbo_Cronograma = new System.Windows.Forms.ComboBox();
            this.Lbl_Rubrica = new System.Windows.Forms.Label();
            this.Cbo_Rubrica = new System.Windows.Forms.ComboBox();
            this.Lbl_Criterio = new System.Windows.Forms.Label();
            this.Cbo_Criterio = new System.Windows.Forms.ComboBox();
            this.Lbl_Escala = new System.Windows.Forms.Label();
            this.Cbo_Escala = new System.Windows.Forms.ComboBox();
            this.Lbl_Fecha = new System.Windows.Forms.Label();
            this.Txt_Fecha = new System.Windows.Forms.TextBox();
            this.Lbl_Porcentaje = new System.Windows.Forms.Label();
            this.Txt_Porcentaje = new System.Windows.Forms.TextBox();
            this.Lbl_Ponderada = new System.Windows.Forms.Label();
            this.Txt_Ponderada = new System.Windows.Forms.TextBox();
            this.Lbl_Comentarios = new System.Windows.Forms.Label();
            this.Txt_Comentarios = new System.Windows.Forms.TextBox();
            this.Pnl_Botones = new System.Windows.Forms.Panel();
            this.Btn_Guardar = new System.Windows.Forms.Button();
            this.Btn_Modificar = new System.Windows.Forms.Button();
            this.Btn_Eliminar = new System.Windows.Forms.Button();
            this.Btn_Limpiar = new System.Windows.Forms.Button();
            this.Gpb_Listado = new System.Windows.Forms.GroupBox();
            this.Dgv_Ponderacion = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Ponderacion)).BeginInit();
            this.Gpb_Datos.SuspendLayout();
            this.Pnl_Botones.SuspendLayout();
            this.Gpb_Listado.SuspendLayout();
            this.SuspendLayout();
            // 
            // Lbl_Titulo
            // 
            this.Lbl_Titulo.Location = new System.Drawing.Point(20, 10);
            this.Lbl_Titulo.Name = "Lbl_Titulo";
            this.Lbl_Titulo.TabIndex = 0;
            this.Lbl_Titulo.AutoSize = true;
            this.Lbl_Titulo.Text = "Ponderación de Auditados";
            // 
            // Gpb_Datos
            // 
            this.Gpb_Datos.Location = new System.Drawing.Point(20, 55);
            this.Gpb_Datos.Size = new System.Drawing.Size(900, 255);
            this.Gpb_Datos.Name = "Gpb_Datos";
            this.Gpb_Datos.TabIndex = 1;
            this.Gpb_Datos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.Gpb_Datos.Text = "Datos de la ponderación";
            // 
            // Lbl_Id
            // 
            this.Lbl_Id.Location = new System.Drawing.Point(15, 35);
            this.Lbl_Id.Name = "Lbl_Id";
            this.Lbl_Id.TabIndex = 9;
            this.Lbl_Id.AutoSize = true;
            this.Lbl_Id.Text = "ID:";
            // 
            // Txt_Id
            // 
            this.Txt_Id.Location = new System.Drawing.Point(135, 32);
            this.Txt_Id.Size = new System.Drawing.Size(80, 24);
            this.Txt_Id.Name = "Txt_Id";
            this.Txt_Id.TabIndex = 0;
            this.Txt_Id.ReadOnly = true;
            this.Txt_Id.TabStop = false;
            // 
            // Lbl_Auditado
            // 
            this.Lbl_Auditado.Location = new System.Drawing.Point(15, 70);
            this.Lbl_Auditado.Name = "Lbl_Auditado";
            this.Lbl_Auditado.TabIndex = 10;
            this.Lbl_Auditado.AutoSize = true;
            this.Lbl_Auditado.Text = "Auditado:";
            // 
            // Cbo_Auditado
            // 
            this.Cbo_Auditado.Location = new System.Drawing.Point(135, 67);
            this.Cbo_Auditado.Size = new System.Drawing.Size(290, 24);
            this.Cbo_Auditado.Name = "Cbo_Auditado";
            this.Cbo_Auditado.TabIndex = 1;
            this.Cbo_Auditado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbo_Auditado.FormattingEnabled = true;
            // 
            // Lbl_Cronograma
            // 
            this.Lbl_Cronograma.Location = new System.Drawing.Point(15, 105);
            this.Lbl_Cronograma.Name = "Lbl_Cronograma";
            this.Lbl_Cronograma.TabIndex = 11;
            this.Lbl_Cronograma.AutoSize = true;
            this.Lbl_Cronograma.Text = "Cronograma:";
            // 
            // Cbo_Cronograma
            // 
            this.Cbo_Cronograma.Location = new System.Drawing.Point(135, 102);
            this.Cbo_Cronograma.Size = new System.Drawing.Size(290, 24);
            this.Cbo_Cronograma.Name = "Cbo_Cronograma";
            this.Cbo_Cronograma.TabIndex = 2;
            this.Cbo_Cronograma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbo_Cronograma.FormattingEnabled = true;
            // 
            // Lbl_Rubrica
            // 
            this.Lbl_Rubrica.Location = new System.Drawing.Point(15, 140);
            this.Lbl_Rubrica.Name = "Lbl_Rubrica";
            this.Lbl_Rubrica.TabIndex = 12;
            this.Lbl_Rubrica.AutoSize = true;
            this.Lbl_Rubrica.Text = "Rúbrica:";
            // 
            // Cbo_Rubrica
            // 
            this.Cbo_Rubrica.Location = new System.Drawing.Point(135, 137);
            this.Cbo_Rubrica.Size = new System.Drawing.Size(290, 24);
            this.Cbo_Rubrica.Name = "Cbo_Rubrica";
            this.Cbo_Rubrica.TabIndex = 3;
            this.Cbo_Rubrica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbo_Rubrica.FormattingEnabled = true;
            // 
            // Lbl_Criterio
            // 
            this.Lbl_Criterio.Location = new System.Drawing.Point(15, 175);
            this.Lbl_Criterio.Name = "Lbl_Criterio";
            this.Lbl_Criterio.TabIndex = 13;
            this.Lbl_Criterio.AutoSize = true;
            this.Lbl_Criterio.Text = "Criterio:";
            // 
            // Cbo_Criterio
            // 
            this.Cbo_Criterio.Location = new System.Drawing.Point(135, 172);
            this.Cbo_Criterio.Size = new System.Drawing.Size(290, 24);
            this.Cbo_Criterio.Name = "Cbo_Criterio";
            this.Cbo_Criterio.TabIndex = 4;
            this.Cbo_Criterio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbo_Criterio.FormattingEnabled = true;
            // 
            // Lbl_Escala
            // 
            this.Lbl_Escala.Location = new System.Drawing.Point(15, 210);
            this.Lbl_Escala.Name = "Lbl_Escala";
            this.Lbl_Escala.TabIndex = 14;
            this.Lbl_Escala.AutoSize = true;
            this.Lbl_Escala.Text = "Escala:";
            // 
            // Cbo_Escala
            // 
            this.Cbo_Escala.Location = new System.Drawing.Point(135, 207);
            this.Cbo_Escala.Size = new System.Drawing.Size(290, 24);
            this.Cbo_Escala.Name = "Cbo_Escala";
            this.Cbo_Escala.TabIndex = 5;
            this.Cbo_Escala.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbo_Escala.FormattingEnabled = true;
            // 
            // Lbl_Fecha
            // 
            this.Lbl_Fecha.Location = new System.Drawing.Point(450, 35);
            this.Lbl_Fecha.Name = "Lbl_Fecha";
            this.Lbl_Fecha.TabIndex = 15;
            this.Lbl_Fecha.AutoSize = true;
            this.Lbl_Fecha.Text = "Fecha evaluación:";
            // 
            // Txt_Fecha
            // 
            this.Txt_Fecha.Location = new System.Drawing.Point(585, 32);
            this.Txt_Fecha.Size = new System.Drawing.Size(190, 24);
            this.Txt_Fecha.Name = "Txt_Fecha";
            this.Txt_Fecha.TabIndex = 16;
            this.Txt_Fecha.ReadOnly = true;
            this.Txt_Fecha.TabStop = false;
            // 
            // Lbl_Porcentaje
            // 
            this.Lbl_Porcentaje.Location = new System.Drawing.Point(450, 70);
            this.Lbl_Porcentaje.Name = "Lbl_Porcentaje";
            this.Lbl_Porcentaje.TabIndex = 17;
            this.Lbl_Porcentaje.AutoSize = true;
            this.Lbl_Porcentaje.Text = "Calificación %:";
            // 
            // Txt_Porcentaje
            // 
            this.Txt_Porcentaje.Location = new System.Drawing.Point(585, 67);
            this.Txt_Porcentaje.Size = new System.Drawing.Size(100, 24);
            this.Txt_Porcentaje.Name = "Txt_Porcentaje";
            this.Txt_Porcentaje.TabIndex = 6;
            this.Txt_Porcentaje.MaxLength = 6;
            // 
            // Lbl_Ponderada
            // 
            this.Lbl_Ponderada.Location = new System.Drawing.Point(450, 105);
            this.Lbl_Ponderada.Name = "Lbl_Ponderada";
            this.Lbl_Ponderada.TabIndex = 18;
            this.Lbl_Ponderada.AutoSize = true;
            this.Lbl_Ponderada.Text = "Calif. ponderada:";
            // 
            // Txt_Ponderada
            // 
            this.Txt_Ponderada.Location = new System.Drawing.Point(585, 102);
            this.Txt_Ponderada.Size = new System.Drawing.Size(100, 24);
            this.Txt_Ponderada.Name = "Txt_Ponderada";
            this.Txt_Ponderada.TabIndex = 7;
            this.Txt_Ponderada.MaxLength = 6;
            // 
            // Lbl_Comentarios
            // 
            this.Lbl_Comentarios.Location = new System.Drawing.Point(450, 140);
            this.Lbl_Comentarios.Name = "Lbl_Comentarios";
            this.Lbl_Comentarios.TabIndex = 19;
            this.Lbl_Comentarios.AutoSize = true;
            this.Lbl_Comentarios.Text = "Comentarios:";
            // 
            // Txt_Comentarios
            // 
            this.Txt_Comentarios.Location = new System.Drawing.Point(585, 137);
            this.Txt_Comentarios.Size = new System.Drawing.Size(290, 94);
            this.Txt_Comentarios.Name = "Txt_Comentarios";
            this.Txt_Comentarios.TabIndex = 8;
            this.Txt_Comentarios.Multiline = true;
            this.Txt_Comentarios.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            // 
            // Pnl_Botones
            // 
            this.Pnl_Botones.Location = new System.Drawing.Point(20, 318);
            this.Pnl_Botones.Size = new System.Drawing.Size(900, 50);
            this.Pnl_Botones.Name = "Pnl_Botones";
            this.Pnl_Botones.TabIndex = 2;
            this.Pnl_Botones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.Pnl_Botones.BackColor = System.Drawing.Color.Transparent;
            // 
            // Btn_Guardar
            // 
            this.Btn_Guardar.Location = new System.Drawing.Point(0, 5);
            this.Btn_Guardar.Size = new System.Drawing.Size(140, 40);
            this.Btn_Guardar.Name = "Btn_Guardar";
            this.Btn_Guardar.TabIndex = 0;
            this.Btn_Guardar.Text = "Guardar";
            this.Btn_Guardar.Click += new System.EventHandler(this.Btn_Guardar_Click);
            // 
            // Btn_Modificar
            // 
            this.Btn_Modificar.Location = new System.Drawing.Point(150, 5);
            this.Btn_Modificar.Size = new System.Drawing.Size(140, 40);
            this.Btn_Modificar.Name = "Btn_Modificar";
            this.Btn_Modificar.TabIndex = 1;
            this.Btn_Modificar.Text = "Modificar";
            this.Btn_Modificar.Click += new System.EventHandler(this.Btn_Modificar_Click);
            // 
            // Btn_Eliminar
            // 
            this.Btn_Eliminar.Location = new System.Drawing.Point(300, 5);
            this.Btn_Eliminar.Size = new System.Drawing.Size(140, 40);
            this.Btn_Eliminar.Name = "Btn_Eliminar";
            this.Btn_Eliminar.TabIndex = 2;
            this.Btn_Eliminar.Text = "Eliminar";
            this.Btn_Eliminar.Click += new System.EventHandler(this.Btn_Eliminar_Click);
            // 
            // Btn_Limpiar
            // 
            this.Btn_Limpiar.Location = new System.Drawing.Point(450, 5);
            this.Btn_Limpiar.Size = new System.Drawing.Size(140, 40);
            this.Btn_Limpiar.Name = "Btn_Limpiar";
            this.Btn_Limpiar.TabIndex = 3;
            this.Btn_Limpiar.Text = "Limpiar";
            this.Btn_Limpiar.Click += new System.EventHandler(this.Btn_Limpiar_Click);
            // 
            // Gpb_Listado
            // 
            this.Gpb_Listado.Location = new System.Drawing.Point(20, 376);
            this.Gpb_Listado.Size = new System.Drawing.Size(900, 254);
            this.Gpb_Listado.Name = "Gpb_Listado";
            this.Gpb_Listado.TabIndex = 3;
            this.Gpb_Listado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.Gpb_Listado.Text = "Ponderaciones registradas";
            // 
            // Dgv_Ponderacion
            // 
            this.Dgv_Ponderacion.Name = "Dgv_Ponderacion";
            this.Dgv_Ponderacion.TabIndex = 0;
            this.Dgv_Ponderacion.AllowUserToAddRows = false;
            this.Dgv_Ponderacion.AllowUserToDeleteRows = false;
            this.Dgv_Ponderacion.AllowUserToResizeRows = false;
            this.Dgv_Ponderacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Dgv_Ponderacion.BackgroundColor = System.Drawing.Color.White;
            this.Dgv_Ponderacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Dgv_Ponderacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dgv_Ponderacion.MultiSelect = false;
            this.Dgv_Ponderacion.ReadOnly = true;
            this.Dgv_Ponderacion.RowHeadersVisible = false;
            this.Dgv_Ponderacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv_Ponderacion.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_Ponderacion_CellClick);
            this.Gpb_Datos.Controls.Add(this.Lbl_Id);
            this.Gpb_Datos.Controls.Add(this.Txt_Id);
            this.Gpb_Datos.Controls.Add(this.Lbl_Auditado);
            this.Gpb_Datos.Controls.Add(this.Cbo_Auditado);
            this.Gpb_Datos.Controls.Add(this.Lbl_Cronograma);
            this.Gpb_Datos.Controls.Add(this.Cbo_Cronograma);
            this.Gpb_Datos.Controls.Add(this.Lbl_Rubrica);
            this.Gpb_Datos.Controls.Add(this.Cbo_Rubrica);
            this.Gpb_Datos.Controls.Add(this.Lbl_Criterio);
            this.Gpb_Datos.Controls.Add(this.Cbo_Criterio);
            this.Gpb_Datos.Controls.Add(this.Lbl_Escala);
            this.Gpb_Datos.Controls.Add(this.Cbo_Escala);
            this.Gpb_Datos.Controls.Add(this.Lbl_Fecha);
            this.Gpb_Datos.Controls.Add(this.Txt_Fecha);
            this.Gpb_Datos.Controls.Add(this.Lbl_Porcentaje);
            this.Gpb_Datos.Controls.Add(this.Txt_Porcentaje);
            this.Gpb_Datos.Controls.Add(this.Lbl_Ponderada);
            this.Gpb_Datos.Controls.Add(this.Txt_Ponderada);
            this.Gpb_Datos.Controls.Add(this.Lbl_Comentarios);
            this.Gpb_Datos.Controls.Add(this.Txt_Comentarios);
            this.Pnl_Botones.Controls.Add(this.Btn_Guardar);
            this.Pnl_Botones.Controls.Add(this.Btn_Modificar);
            this.Pnl_Botones.Controls.Add(this.Btn_Eliminar);
            this.Pnl_Botones.Controls.Add(this.Btn_Limpiar);
            this.Gpb_Listado.Controls.Add(this.Dgv_Ponderacion);
            // 
            // Frm_Ponderacion
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(940, 650);
            this.Controls.Add(this.Lbl_Titulo);
            this.Controls.Add(this.Gpb_Datos);
            this.Controls.Add(this.Pnl_Botones);
            this.Controls.Add(this.Gpb_Listado);
            this.MinimumSize = new System.Drawing.Size(850, 550);
            this.Name = "Frm_Ponderacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ponderación";
            this.Load += new System.EventHandler(this.Frm_Ponderacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Ponderacion)).EndInit();
            this.Gpb_Datos.ResumeLayout(false);
            this.Gpb_Datos.PerformLayout();
            this.Pnl_Botones.ResumeLayout(false);
            this.Gpb_Listado.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbl_Titulo;
        private System.Windows.Forms.GroupBox Gpb_Datos;
        private System.Windows.Forms.Label Lbl_Id;
        private System.Windows.Forms.TextBox Txt_Id;
        private System.Windows.Forms.Label Lbl_Auditado;
        private System.Windows.Forms.ComboBox Cbo_Auditado;
        private System.Windows.Forms.Label Lbl_Cronograma;
        private System.Windows.Forms.ComboBox Cbo_Cronograma;
        private System.Windows.Forms.Label Lbl_Rubrica;
        private System.Windows.Forms.ComboBox Cbo_Rubrica;
        private System.Windows.Forms.Label Lbl_Criterio;
        private System.Windows.Forms.ComboBox Cbo_Criterio;
        private System.Windows.Forms.Label Lbl_Escala;
        private System.Windows.Forms.ComboBox Cbo_Escala;
        private System.Windows.Forms.Label Lbl_Fecha;
        private System.Windows.Forms.TextBox Txt_Fecha;
        private System.Windows.Forms.Label Lbl_Porcentaje;
        private System.Windows.Forms.TextBox Txt_Porcentaje;
        private System.Windows.Forms.Label Lbl_Ponderada;
        private System.Windows.Forms.TextBox Txt_Ponderada;
        private System.Windows.Forms.Label Lbl_Comentarios;
        private System.Windows.Forms.TextBox Txt_Comentarios;
        private System.Windows.Forms.Panel Pnl_Botones;
        private System.Windows.Forms.Button Btn_Guardar;
        private System.Windows.Forms.Button Btn_Modificar;
        private System.Windows.Forms.Button Btn_Eliminar;
        private System.Windows.Forms.Button Btn_Limpiar;
        private System.Windows.Forms.GroupBox Gpb_Listado;
        private System.Windows.Forms.DataGridView Dgv_Ponderacion;
    }
}
//Fin del código de "NOMBRE_COMPLETO" con carné: "CARNE" en la fecha de : "20/10/2026"
