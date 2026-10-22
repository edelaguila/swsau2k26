using System;
using System.Windows.Forms;
using System.Drawing;

namespace Capa_Vista_Auditoria
{
    partial class Frm_MDI_Auditoria
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_MDI_Auditoria));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblTituloMDI = new System.Windows.Forms.Label();
            this.lblSubtituloMDI = new System.Windows.Forms.Label();
            this.pnlLineaHeader = new System.Windows.Forms.Panel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mantenimientosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grupo1ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.proyectoEstadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grupo2ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.grupo3ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.grupo4ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gruposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grupo1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proyectoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actividadesDelProyectoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.áreasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recursosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grupo2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grupo3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grupo4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.informeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estadoInformeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checklistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graficasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.pnlHeader.Controls.Add(this.picLogo);
            this.pnlHeader.Controls.Add(this.lblTituloMDI);
            this.pnlHeader.Controls.Add(this.lblSubtituloMDI);
            this.pnlHeader.Controls.Add(this.pnlLineaHeader);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(2);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(632, 73);
            this.pnlHeader.TabIndex = 100;
            // 
            // picLogo
            // 
            this.picLogo.Image = global::Capa_Vista_Auditoria.Properties.Resources.logo_auditores;
            this.picLogo.Location = new System.Drawing.Point(14, 11);
            this.picLogo.Margin = new System.Windows.Forms.Padding(2);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(48, 52);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 101;
            this.picLogo.TabStop = false;
            // 
            // lblTituloMDI
            // 
            this.lblTituloMDI.AutoSize = true;
            this.lblTituloMDI.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTituloMDI.ForeColor = System.Drawing.Color.White;
            this.lblTituloMDI.Location = new System.Drawing.Point(75, 13);
            this.lblTituloMDI.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTituloMDI.Name = "lblTituloMDI";
            this.lblTituloMDI.Size = new System.Drawing.Size(264, 30);
            this.lblTituloMDI.TabIndex = 102;
            this.lblTituloMDI.Text = "SISTEMA DE AUDITORÍA";
            // 
            // lblSubtituloMDI
            // 
            this.lblSubtituloMDI.AutoSize = true;
            this.lblSubtituloMDI.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtituloMDI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(190)))), ((int)(((byte)(220)))));
            this.lblSubtituloMDI.Location = new System.Drawing.Point(76, 41);
            this.lblSubtituloMDI.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSubtituloMDI.Name = "lblSubtituloMDI";
            this.lblSubtituloMDI.Size = new System.Drawing.Size(324, 15);
            this.lblSubtituloMDI.TabIndex = 103;
            this.lblSubtituloMDI.Text = "Control Interno   •   Seguridad   •   Cumplimiento Normativo";
            // 
            // pnlLineaHeader
            // 
            this.pnlLineaHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(105)))));
            this.pnlLineaHeader.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlLineaHeader.Location = new System.Drawing.Point(0, 71);
            this.pnlLineaHeader.Margin = new System.Windows.Forms.Padding(2);
            this.pnlLineaHeader.Name = "pnlLineaHeader";
            this.pnlLineaHeader.Size = new System.Drawing.Size(632, 2);
            this.pnlLineaHeader.TabIndex = 104;
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(27)))), ((int)(((byte)(52)))));
            this.menuStrip.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.menuStrip.ForeColor = System.Drawing.Color.White;
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.mantenimientosToolStripMenuItem,
            this.gruposToolStripMenuItem,
            this.toolsMenu,
            this.helpMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 73);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(632, 25);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(63, 21);
            this.fileMenu.Text = "&Archivo";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.exitToolStripMenuItem.Text = "&Salir";
            // 
            // mantenimientosToolStripMenuItem
            // 
            this.mantenimientosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.grupo1ToolStripMenuItem1,
            this.grupo2ToolStripMenuItem1,
            this.grupo3ToolStripMenuItem1,
            this.grupo4ToolStripMenuItem1});
            this.mantenimientosToolStripMenuItem.Name = "mantenimientosToolStripMenuItem";
            this.mantenimientosToolStripMenuItem.Size = new System.Drawing.Size(113, 21);
            this.mantenimientosToolStripMenuItem.Text = "Mantenimientos";
            // 
            // grupo1ToolStripMenuItem1
            // 
            this.grupo1ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.proyectoEstadoToolStripMenuItem});
            this.grupo1ToolStripMenuItem1.Name = "grupo1ToolStripMenuItem1";
            this.grupo1ToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.grupo1ToolStripMenuItem1.Text = "Grupo 1";
            // 
            // proyectoEstadoToolStripMenuItem
            // 
            this.proyectoEstadoToolStripMenuItem.Name = "proyectoEstadoToolStripMenuItem";
            this.proyectoEstadoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.proyectoEstadoToolStripMenuItem.Text = "Proyecto estado";
            this.proyectoEstadoToolStripMenuItem.Click += new System.EventHandler(this.proyectoEstadoToolStripMenuItem_Click);
            // 
            // grupo2ToolStripMenuItem1
            // 
            this.grupo2ToolStripMenuItem1.Name = "grupo2ToolStripMenuItem1";
            this.grupo2ToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.grupo2ToolStripMenuItem1.Text = "Grupo 2";
            // 
            // grupo3ToolStripMenuItem1
            // 
            this.grupo3ToolStripMenuItem1.Name = "grupo3ToolStripMenuItem1";
            this.grupo3ToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.grupo3ToolStripMenuItem1.Text = "Grupo 3";
            // 
            // grupo4ToolStripMenuItem1
            // 
            this.grupo4ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.estadoInformeToolStripMenuItem});
            this.grupo4ToolStripMenuItem1.Name = "grupo4ToolStripMenuItem1";
            this.grupo4ToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.grupo4ToolStripMenuItem1.Text = "Grupo 4";
            // 
            // gruposToolStripMenuItem
            // 
            this.gruposToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.grupo1ToolStripMenuItem,
            this.grupo2ToolStripMenuItem,
            this.grupo3ToolStripMenuItem,
            this.grupo4ToolStripMenuItem});
            this.gruposToolStripMenuItem.Name = "gruposToolStripMenuItem";
            this.gruposToolStripMenuItem.Size = new System.Drawing.Size(79, 21);
            this.gruposToolStripMenuItem.Text = "Cátalogos";
            // 
            // grupo1ToolStripMenuItem
            // 
            this.grupo1ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.proyectoToolStripMenuItem,
            this.actividadesDelProyectoToolStripMenuItem,
            this.áreasToolStripMenuItem,
            this.recursosToolStripMenuItem});
            this.grupo1ToolStripMenuItem.Name = "grupo1ToolStripMenuItem";
            this.grupo1ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.grupo1ToolStripMenuItem.Text = "Grupo 1";
            // 
            // proyectoToolStripMenuItem
            // 
            this.proyectoToolStripMenuItem.Name = "proyectoToolStripMenuItem";
            this.proyectoToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.proyectoToolStripMenuItem.Text = "Proyecto";
            this.proyectoToolStripMenuItem.Click += new System.EventHandler(this.proyectoToolStripMenuItem_Click);
            // 
            // actividadesDelProyectoToolStripMenuItem
            // 
            this.actividadesDelProyectoToolStripMenuItem.Name = "actividadesDelProyectoToolStripMenuItem";
            this.actividadesDelProyectoToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.actividadesDelProyectoToolStripMenuItem.Text = "Actividades del Proyecto";
            this.actividadesDelProyectoToolStripMenuItem.Click += new System.EventHandler(this.actividadesDelProyectoToolStripMenuItem_Click);
            // 
            // áreasToolStripMenuItem
            // 
            this.áreasToolStripMenuItem.Name = "áreasToolStripMenuItem";
            this.áreasToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.áreasToolStripMenuItem.Text = "Áreas";
            this.áreasToolStripMenuItem.Click += new System.EventHandler(this.áreasToolStripMenuItem_Click);
            // 
            // recursosToolStripMenuItem
            // 
            this.recursosToolStripMenuItem.Name = "recursosToolStripMenuItem";
            this.recursosToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.recursosToolStripMenuItem.Text = "Recursos";
            this.recursosToolStripMenuItem.Click += new System.EventHandler(this.recursosToolStripMenuItem_Click);
            // 
            // grupo2ToolStripMenuItem
            // 
            this.grupo2ToolStripMenuItem.Name = "grupo2ToolStripMenuItem";
            this.grupo2ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.grupo2ToolStripMenuItem.Text = "Grupo 2";
            // 
            // grupo3ToolStripMenuItem
            // 
            this.grupo3ToolStripMenuItem.Name = "grupo3ToolStripMenuItem";
            this.grupo3ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.grupo3ToolStripMenuItem.Text = "Grupo 3";
            // 
            // grupo4ToolStripMenuItem
            // 
            this.grupo4ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informeToolStripMenuItem,
            this.reportesToolStripMenuItem,
            this.checklistToolStripMenuItem,
            this.graficasToolStripMenuItem});
            this.grupo4ToolStripMenuItem.Name = "grupo4ToolStripMenuItem";
            this.grupo4ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.grupo4ToolStripMenuItem.Text = "Grupo 4";
            // 
            // toolsMenu
            // 
            this.toolsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.toolsMenu.Name = "toolsMenu";
            this.toolsMenu.Size = new System.Drawing.Size(98, 21);
            this.toolsMenu.Text = "&Herramientas";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.optionsToolStripMenuItem.Text = "Cambiar contraseña";
            // 
            // helpMenu
            // 
            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.indexToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.toolStripSeparator8,
            this.aboutToolStripMenuItem});
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(56, 21);
            this.helpMenu.Text = "Ay&uda";
            // 
            // contentsToolStripMenuItem
            // 
            this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            this.contentsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.contentsToolStripMenuItem.Size = new System.Drawing.Size(190, 26);
            this.contentsToolStripMenuItem.Text = "&Contenido";
            // 
            // indexToolStripMenuItem
            // 
            this.indexToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("indexToolStripMenuItem.Image")));
            this.indexToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            this.indexToolStripMenuItem.Size = new System.Drawing.Size(190, 26);
            this.indexToolStripMenuItem.Text = "&Índice";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("searchToolStripMenuItem.Image")));
            this.searchToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(190, 26);
            this.searchToolStripMenuItem.Text = "&Buscar";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(187, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(190, 26);
            this.aboutToolStripMenuItem.Text = "&Acerca de... ...";
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.statusStrip.ForeColor = System.Drawing.Color.White;
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 431);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(632, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel.Text = "Estado";
            // 
            // informeToolStripMenuItem
            // 
            this.informeToolStripMenuItem.Name = "informeToolStripMenuItem";
            this.informeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.informeToolStripMenuItem.Text = "Informe ";
            this.informeToolStripMenuItem.Click += new System.EventHandler(this.informeToolStripMenuItem_Click);
            // 
            // estadoInformeToolStripMenuItem
            // 
            this.estadoInformeToolStripMenuItem.Name = "estadoInformeToolStripMenuItem";
            this.estadoInformeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.estadoInformeToolStripMenuItem.Text = "Estado Informe";
            this.estadoInformeToolStripMenuItem.Click += new System.EventHandler(this.estadoInformeToolStripMenuItem_Click_1);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.reportesToolStripMenuItem.Text = "Reportes";
            this.reportesToolStripMenuItem.Click += new System.EventHandler(this.reportesToolStripMenuItem_Click);
            // 
            // checklistToolStripMenuItem
            // 
            this.checklistToolStripMenuItem.Name = "checklistToolStripMenuItem";
            this.checklistToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.checklistToolStripMenuItem.Text = "Checklist";
            this.checklistToolStripMenuItem.Click += new System.EventHandler(this.checklistToolStripMenuItem_Click);
            // 
            // graficasToolStripMenuItem
            // 
            this.graficasToolStripMenuItem.Name = "graficasToolStripMenuItem";
            this.graficasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.graficasToolStripMenuItem.Text = "Graficas";
            this.graficasToolStripMenuItem.Click += new System.EventHandler(this.graficasToolStripMenuItem_Click);
            // 
            // Frm_MDI_Auditoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.pnlHeader);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "Frm_MDI_Auditoria";
            this.Text = "Frm_MDI_Auditoria";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblTituloMDI;
        private System.Windows.Forms.Label lblSubtituloMDI;
        private System.Windows.Forms.Panel pnlLineaHeader;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsMenu;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip;
        private ToolStripMenuItem gruposToolStripMenuItem;
        private ToolStripMenuItem grupo1ToolStripMenuItem;
        private ToolStripMenuItem grupo2ToolStripMenuItem;
        private ToolStripMenuItem grupo3ToolStripMenuItem;
        private ToolStripMenuItem grupo4ToolStripMenuItem;
        private ToolStripMenuItem proyectoToolStripMenuItem;
        private ToolStripMenuItem actividadesDelProyectoToolStripMenuItem;
        private ToolStripMenuItem áreasToolStripMenuItem;
        private ToolStripMenuItem recursosToolStripMenuItem;
        private ToolStripMenuItem mantenimientosToolStripMenuItem;
        private ToolStripMenuItem grupo1ToolStripMenuItem1;
        private ToolStripMenuItem proyectoEstadoToolStripMenuItem;
        private ToolStripMenuItem grupo2ToolStripMenuItem1;
        private ToolStripMenuItem grupo3ToolStripMenuItem1;
        private ToolStripMenuItem grupo4ToolStripMenuItem1;
        private ToolStripMenuItem informeToolStripMenuItem;
        private ToolStripMenuItem estadoInformeToolStripMenuItem;
        private ToolStripMenuItem reportesToolStripMenuItem;
        private ToolStripMenuItem checklistToolStripMenuItem;
        private ToolStripMenuItem graficasToolStripMenuItem;
    }
}



