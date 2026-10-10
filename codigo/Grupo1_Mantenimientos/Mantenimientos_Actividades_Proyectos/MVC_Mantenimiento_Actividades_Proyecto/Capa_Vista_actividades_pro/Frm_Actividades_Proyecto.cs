
/*
 * ================================================================
 * Área       : Gestión de Proyectos y Recursos
 * Componente : Mantenimiento de Actividades del Proyecto
 * Capa       : Vista
 * Autor      : Danilo Mazariegos
 * Carné      : 0901-19-25059
 * Fecha      : 08/10/2026
 * Estándar   : ES-01 Versión 1.5
 * ================================================================
 */

using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using Capa_Controlador_actividades_pro;

namespace Capa_Vista_actividades_pro
{
    public partial class Frm_Actividades_Proyecto : Form
    {
      

        private enum Enm_Estado
        {
            Consulta,
            Ingreso,
            Modificacion
        }

        private Enm_Estado gEstado = Enm_Estado.Consulta;

     

        private readonly Cls_Actividades_Controlador gControlador =
            new Cls_Actividades_Controlador();

        private readonly BindingSource gFuente =
            new BindingSource();

        private readonly PrintDocument gDocumento =
            new PrintDocument();

        private int iIdSeleccionado = 0;

        private bool bCargando = false;

     

        public Frm_Actividades_Proyecto()
        {
            InitializeComponent();

            pro_configurar_formulario();
            pro_conectar_eventos();
            pro_configurar_tabla();

            gDocumento.PrintPage += pro_imprimir_pagina;

            this.Shown += (s, e) => pro_refrescar();

            pro_estado(Enm_Estado.Consulta);
        }

      

        private void pro_configurar_formulario()
        {
            this.Text =
                "Mantenimiento de Actividades del Proyecto";

            this.MinimumSize = new Size(850, 550);

            this.StartPosition =
                FormStartPosition.CenterScreen;

            this.MinimizeBox = true;
            this.MaximizeBox = true;
            this.ControlBox = true;
        }

       

        private void pro_conectar_eventos()
        {
            Btn_Ingresar.Click +=
                (s, e) => pro_ingresar();

            Btn_Modificar.Click +=
                (s, e) => pro_modificar();

            Btn_Guardar.Click +=
                (s, e) => pro_guardar();

            Btn_Cancelar.Click +=
                (s, e) => pro_cancelar();

            Btn_Eliminar.Click +=
                (s, e) => pro_eliminar();

            Btn_Consultar.Click +=
                (s, e) => pro_consultar();

            Btn_Imprimir.Click +=
                (s, e) => pro_imprimir();

            Btn_Refrescar.Click +=
                (s, e) => pro_refrescar();
            Btn_Ayuda.Click +=
                (s, e) => pro_ayuda();

            Btn_Salir.Click +=
                (s, e) => this.Close();

            // Selección de registros del DataGridView.
            Dgv_Actividades.SelectionChanged +=
                (s, e) => pro_mostrar_registro();

            // Búsqueda presionando Enter.
            Txt_Buscar.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    pro_consultar();
                    e.SuppressKeyPress = true;
                }
            };
        }

       

        private void pro_configurar_tabla()
        {
            Dgv_Actividades.ReadOnly = true;
            Dgv_Actividades.MultiSelect = false;

            Dgv_Actividades.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            Dgv_Actividades.AllowUserToAddRows = false;
            Dgv_Actividades.AllowUserToDeleteRows = false;

            Dgv_Actividades.AutoGenerateColumns = true;

            Dgv_Actividades.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            Dgv_Actividades.RowHeadersVisible = false;

            Dgv_Actividades.BackgroundColor =
                Color.AliceBlue;

            Dgv_Actividades.DataSource = gFuente;
        }

    

        private void pro_estado(Enm_Estado gNuevoEstado)
        {
            gEstado = gNuevoEstado;

            bool bEdicion =
                gEstado != Enm_Estado.Consulta;

            bool bSeleccion =
                iIdSeleccionado > 0;

            Txt_Id_Actividad.ReadOnly =
                gEstado != Enm_Estado.Ingreso;

            Cbo_Proyecto.Enabled = bEdicion;

            Txt_Nombre_Actividad.ReadOnly = !bEdicion;
            Txt_Descripcion.ReadOnly = !bEdicion;
            Txt_Observaciones.ReadOnly = !bEdicion;

            Btn_Ingresar.Enabled = !bEdicion;
            Btn_Modificar.Enabled = !bEdicion && bSeleccion;
            Btn_Guardar.Enabled = bEdicion;
            Btn_Cancelar.Enabled = bEdicion;
            Btn_Eliminar.Enabled = !bEdicion && bSeleccion;

            Btn_Consultar.Enabled = !bEdicion;
            Btn_Refrescar.Enabled = !bEdicion;
            Btn_Imprimir.Enabled = !bEdicion && bSeleccion;

            Btn_Ayuda.Enabled = true;
            Btn_Salir.Enabled = true;

            Dgv_Actividades.Enabled = !bEdicion;
            Txt_Buscar.Enabled = !bEdicion;

           
        }

       

        private void pro_cargar_proyectos()
        {
            DataTable gDatos =
                gControlador.fun_obtener_proyectos();

            Cbo_Proyecto.DataSource = null;

            Cbo_Proyecto.DisplayMember =
                "Cmp_Nombre_Proyecto";

            Cbo_Proyecto.ValueMember =
                "Pk_Id_Proyecto";

            Cbo_Proyecto.DataSource = gDatos;

            Cbo_Proyecto.SelectedIndex = -1;
        }

      

        private void pro_cargar_actividades(int iRestaurarId)
        {
            bCargando = true;

            try
            {
                DataTable gDatos =
                    gControlador.fun_obtener_actividades();

                gFuente.DataSource = gDatos;

                pro_configurar_columnas();

                if (gFuente.Count == 0)
                {
                    pro_limpiar_campos();
                    return;
                }

                int iPosicion = 0;

                // Restaurar la selección anterior si existe.
                for (int i = 0; i < gFuente.Count; i++)
                {
                    DataRowView gFila =
                        gFuente[i] as DataRowView;

                    if (gFila != null &&
                        Convert.ToInt32(
                            gFila["Pk_Id_Actividad_Proyecto"])
                            == iRestaurarId)
                    {
                        iPosicion = i;
                        break;
                    }
                }

                gFuente.Position = iPosicion;
            }
            finally
            {
                bCargando = false;
            }

            pro_mostrar_registro();
        }

  
        private void pro_configurar_columnas()
        {
            if (Dgv_Actividades.Columns.Count == 0)
                return;

            Dgv_Actividades.Columns[
                "Pk_Id_Actividad_Proyecto"]
                .HeaderText = "ID Actividad";

            Dgv_Actividades.Columns[
                "Fk_Id_Proyecto"]
                .HeaderText = "ID Proyecto";

            Dgv_Actividades.Columns[
                "Cmp_Nombre_Proyecto"]
                .HeaderText = "Proyecto";

            Dgv_Actividades.Columns[
                "Cmp_Nombre_Actividad_Proyecto"]
                .HeaderText = "Actividad";

            Dgv_Actividades.Columns[
                "Cmp_Descripcion_Actividad_Proyecto"]
                .HeaderText = "Descripción";

            Dgv_Actividades.Columns[
                "Cmp_Observaciones_Actividad_Proyecto"]
                .HeaderText = "Observaciones";
        }

       

        private void pro_mostrar_registro()
        {
            if (bCargando ||
                gEstado != Enm_Estado.Consulta)
            {
                return;
            }

            if (Dgv_Actividades.CurrentRow != null &&
                Dgv_Actividades.CurrentRow.DataBoundItem
                    is DataRowView gFilaSeleccionada)
            {
                int iPosicion =
                    gFuente.IndexOf(gFilaSeleccionada);

                if (iPosicion >= 0)
                    gFuente.Position = iPosicion;
            }

            DataRowView gFila =
                gFuente.Current as DataRowView;

            if (gFila == null)
            {
                pro_limpiar_campos();
                return;
            }

            iIdSeleccionado = Convert.ToInt32(
                gFila["Pk_Id_Actividad_Proyecto"]);

            Txt_Id_Actividad.Text =
                iIdSeleccionado.ToString();

            Cbo_Proyecto.SelectedValue =
                Convert.ToInt32(gFila["Fk_Id_Proyecto"]);

            Txt_Nombre_Actividad.Text =
                Convert.ToString(
                    gFila["Cmp_Nombre_Actividad_Proyecto"]);

            Txt_Descripcion.Text =
                Convert.ToString(
                    gFila["Cmp_Descripcion_Actividad_Proyecto"]);

            Txt_Observaciones.Text =
                Convert.ToString(
                    gFila["Cmp_Observaciones_Actividad_Proyecto"]);

            pro_estado(Enm_Estado.Consulta);
        }

        

        private void pro_limpiar_campos()
        {
            iIdSeleccionado = 0;

            Txt_Id_Actividad.Clear();
            Txt_Nombre_Actividad.Clear();
            Txt_Descripcion.Clear();
            Txt_Observaciones.Clear();

            Cbo_Proyecto.SelectedIndex = -1;

            if (gEstado == Enm_Estado.Consulta)
                pro_estado(Enm_Estado.Consulta);
        }

    

        private void pro_ingresar()
        {
            pro_limpiar_campos();

            pro_estado(Enm_Estado.Ingreso);

            Txt_Id_Actividad.Focus();
        }

    

        private void pro_modificar()
        {
            if (iIdSeleccionado <= 0)
            {
                MessageBox.Show(
                    "Seleccione una actividad.");
                return;
            }

            pro_estado(Enm_Estado.Modificacion);

            Txt_Nombre_Actividad.Focus();
        }


        private void pro_guardar()
        {
            if (gEstado == Enm_Estado.Consulta)
                return;

            if (!int.TryParse(
                Txt_Id_Actividad.Text,
                out int iIdActividad) || iIdActividad <= 0)
            {
                MessageBox.Show(
                    "Ingrese un ID válido.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (Cbo_Proyecto.SelectedValue == null ||
                !int.TryParse(
                    Cbo_Proyecto.SelectedValue.ToString(),
                    out int iIdProyecto))
            {
                MessageBox.Show(
                    "Seleccione un proyecto válido.");
                return;
            }

            try
            {
                Cls_Actividades_Controlador
                    .Cls_Resultado_Operacion gResultado;

                if (gEstado == Enm_Estado.Ingreso)
                {
                    gResultado =
                        gControlador.fun_guardar_actividad(
                            iIdActividad,
                            iIdProyecto,
                            Txt_Nombre_Actividad.Text,
                            Txt_Descripcion.Text,
                            Txt_Observaciones.Text);
                }
                else
                {
                    gResultado =
                        gControlador.fun_modificar_actividad(
                            iIdActividad,
                            iIdProyecto,
                            Txt_Nombre_Actividad.Text,
                            Txt_Descripcion.Text,
                            Txt_Observaciones.Text);
                }

                MessageBox.Show(
                    gResultado.sMensaje,
                    "Mantenimiento de Actividades",
                    MessageBoxButtons.OK,
                    gResultado.bExito
                        ? MessageBoxIcon.Information
                        : MessageBoxIcon.Warning);

                if (!gResultado.bExito)
                    return;

                pro_estado(Enm_Estado.Consulta);

                pro_cargar_actividades(iIdActividad);
            }
            catch (Exception gEx)
            {
                pro_mostrar_error(gEx);
            }
        }

       

        private void pro_cancelar()
        {
            if (gEstado == Enm_Estado.Consulta)
                return;

            DialogResult gRespuesta =
                MessageBox.Show(
                    "¿Desea descartar los cambios?",
                    "Cancelar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (gRespuesta != DialogResult.Yes)
                return;

            pro_estado(Enm_Estado.Consulta);

            if (gFuente.Count > 0)
                pro_mostrar_registro();
            else
                pro_limpiar_campos();
        }


        private void pro_eliminar()
        {
            if (iIdSeleccionado <= 0)
                return;

            DialogResult gRespuesta =
                MessageBox.Show(
                    "¿Desea eliminar la actividad "
                    + iIdSeleccionado + "?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

            if (gRespuesta != DialogResult.Yes)
                return;

            try
            {
                var gResultado =
                    gControlador.fun_eliminar_actividad(
                        iIdSeleccionado);

                MessageBox.Show(
                    gResultado.sMensaje,
                    "Actividades");

                if (gResultado.bExito)
                    pro_cargar_actividades(0);
            }
            catch (System.Data.Odbc.OdbcException)
            {
                MessageBox.Show(
                    "No fue posible eliminar la actividad. "
                    + "Puede estar relacionada con otros datos.",
                    "Eliminación restringida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (Exception gEx)
            {
                pro_mostrar_error(gEx);
            }
        }

  

        private void pro_consultar()
        {
            if (!(gFuente.DataSource is DataTable))
                return;

            string sTexto = Txt_Buscar.Text.Trim();

            try
            {
                bCargando = true;

                if (string.IsNullOrWhiteSpace(sTexto))
                {
                    gFuente.RemoveFilter();
                }
                else if (int.TryParse(sTexto, out int iId))
                {
                    gFuente.Filter =
                        "Pk_Id_Actividad_Proyecto = " + iId;
                }
                else
                {
                    string sBusqueda = sTexto
                        .Replace("'", "''")
                        .Replace("[", "[[]")
                        .Replace("%", "[%]")
                        .Replace("*", "[*]");

                    gFuente.Filter =
                        "Cmp_Nombre_Actividad_Proyecto LIKE '%"
                        + sBusqueda + "%'";
                }

                if (gFuente.Count > 0)
                    gFuente.Position = 0;
            }
            catch (Exception gEx)
            {
                pro_mostrar_error(gEx);
                return;
            }
            finally
            {
                bCargando = false;
            }

            if (gFuente.Count == 0)
            {
                pro_limpiar_campos();

                MessageBox.Show(
                    "No se encontraron actividades.");
            }
            else
            {
                pro_mostrar_registro();
            }
        }

      

        private void pro_refrescar()
        {
            try
            {
                int iIdAnterior = iIdSeleccionado;

                Txt_Buscar.Clear();

                pro_cargar_proyectos();

                pro_cargar_actividades(iIdAnterior);
            }
            catch (Exception gEx)
            {
                pro_mostrar_error(gEx);
            }
        }

        // ========================================================
        // NAVEGACIÓN
        // ========================================================

        private void pro_navegar(int iDireccion)
        {
            if (gFuente.Count == 0)
                return;

            bCargando = true;

            try
            {
                switch (iDireccion)
                {
                    case 0:
                        gFuente.MoveFirst();
                        break;

                    case -1:
                        gFuente.MovePrevious();
                        break;

                    case 1:
                        gFuente.MoveNext();
                        break;

                    case 2:
                        gFuente.MoveLast();
                        break;
                }
            }
            finally
            {
                bCargando = false;
            }

            pro_mostrar_registro();
        }

        // ========================================================
        // IMPRIMIR
        // ========================================================

        private void pro_imprimir()
        {
            if (iIdSeleccionado <= 0)
                return;

            using (PrintPreviewDialog gVista =
                new PrintPreviewDialog())
            {
                gVista.Document = gDocumento;
                gVista.Width = 900;
                gVista.Height = 650;

                gVista.ShowDialog(this);
            }
        }

        // ========================================================
        // DOCUMENTO DE IMPRESIÓN
        // ========================================================

        private void pro_imprimir_pagina(
            object sender,
            PrintPageEventArgs e)
        {
            using (Font gTitulo =
                new Font("Rockwell", 18, FontStyle.Bold))
            using (Font gTexto =
                new Font("Rockwell", 11))
            {
                float fX = e.MarginBounds.Left;
                float fY = e.MarginBounds.Top;

                e.Graphics.DrawString(
                    "Ficha de Actividad del Proyecto",
                    gTitulo,
                    Brushes.Black,
                    fX,
                    fY);

                fY += 60;

                string[] arrDatos =
                {
                    "ID: " + Txt_Id_Actividad.Text,
                    "Proyecto: " + Cbo_Proyecto.Text,
                    "Nombre: " + Txt_Nombre_Actividad.Text,
                    "Descripción: " + Txt_Descripcion.Text,
                    "Observaciones: " + Txt_Observaciones.Text
                };

                foreach (string sDato in arrDatos)
                {
                    RectangleF gArea = new RectangleF(
                        fX, fY, e.MarginBounds.Width, 90);

                    e.Graphics.DrawString(
                        sDato,
                        gTexto,
                        Brushes.Black,
                        gArea);

                    fY += 95;
                }
            }

            e.HasMorePages = false;
        }

        // ========================================================
        // AYUDA
        // ========================================================

        private void pro_ayuda()
        {
            MessageBox.Show(
                "INGRESAR: crea una actividad nueva.\n" +
                "MODIFICAR: edita la actividad seleccionada.\n" +
                "GUARDAR: registra los cambios.\n" +
                "CANCELAR: descarta cambios.\n" +
                "ELIMINAR: elimina previa confirmación.\n" +
                "CONSULTAR: busca por ID o nombre.\n" +
                "IMPRIMIR: genera una vista previa.\n" +
                "REFRESCAR: actualiza los registros.\n" +
                "INICIO: primer registro.\n" +
                "ANTERIOR: registro anterior.\n" +
                "SIGUIENTE: próximo registro.\n" +
                "FIN: último registro.\n" +
                "AYUDA: muestra esta información.\n" +
                "SALIR: cierra el formulario.",
                "Ayuda - Mantenimiento de Actividades",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // ========================================================
        // MANEJO DE ERRORES
        // ========================================================

        private void pro_mostrar_error(Exception gEx)
        {
            MessageBox.Show(
                "Error durante la operación:\n"
                + gEx.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        private void Frm_Actividades_Proyecto_Load(object sender, EventArgs e)
        {

        }
    }
}
