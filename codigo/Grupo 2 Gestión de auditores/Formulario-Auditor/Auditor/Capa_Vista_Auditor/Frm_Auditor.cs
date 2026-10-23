using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Controlador_Auditor;
//Ernesto David Samayoa Jocol 0901-22-3415
namespace Capa_Vista_Auditor
{
    public partial class Frm_Auditor : Form
    {
        Cls_auditor_controlador controlador = new Cls_auditor_controlador();

        private string sModo = "CONSULTA";
        public Frm_Auditor()
        {
            InitializeComponent();

            // telefono 0000-0000
            Txt_telefono.KeyPress += Txt_telefono_KeyPress;
            Txt_telefono.TextChanged += Txt_telefono_TextChanged;

            // nombre: solo letras y espacios
            Txt_nombre.KeyPress += Txt_nombre_KeyPress;
        }
        //Al abrir formulario de auditor
        private void Frm_Auditor_Load(object sender, EventArgs e)
        {
            fun_ConfigurarControles();
            fun_CargarEstados();
            fun_CargarAuditores();
            fun_EstadoBotones("CONSULTA");   
        }

        private void fun_ConfigurarControles()
        {
            Txt_id_auditor.ReadOnly = true;
            Txt_id_auditor.TabStop = false;

            Txt_carnet.MaxLength = 15;    
            Txt_nombre.MaxLength = 45;     
            Txt_telefono.MaxLength = 9;  
            Txt_email.MaxLength = 100;   

            // El estado solo se elige de la lista
            Cbo_estado.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void fun_CargarAuditores()
        {
            try
            {
                fun_MostrarEnGrid(controlador.ObtenerAuditores());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar auditores:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fun_MostrarEnGrid(DataTable dt)
        {
            Dgv_auditor.DataSource = dt;

            // Encabezados
            Dgv_auditor.Columns["Pk_Id_Auditor"].HeaderText = "ID";
            Dgv_auditor.Columns["Cmp_Carnet_Auditor"].HeaderText = "Carnet";
            Dgv_auditor.Columns["Cmp_Nombre_Auditor"].HeaderText = "Nombre";
            Dgv_auditor.Columns["Cmp_Telefono_Auditor"].HeaderText = "Teléfono";
            Dgv_auditor.Columns["Cmp_Email_Auditor"].HeaderText = "Email";
            Dgv_auditor.Columns["Cmp_Nombre_Estado_Auditor"].HeaderText = "Estado";

            // El ID del estado se oculta, pero sigue en la fila
            Dgv_auditor.Columns["Fk_Id_Estado_Auditor"].Visible = false;
        }

        private void fun_CargarEstados()
        {
            try
            {
                Cbo_estado.DataSource = controlador.ObtenerEstados();
                Cbo_estado.DisplayMember = "Cmp_Nombre_Estado_Auditor";  
                Cbo_estado.ValueMember = "Pk_Id_Estado_Auditor";         
                Cbo_estado.SelectedIndex = -1;                           
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar estados:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Dgv_auditor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila = Dgv_auditor.Rows[e.RowIndex];

            Txt_id_auditor.Text = fila.Cells["Pk_Id_Auditor"].Value.ToString();
            Txt_carnet.Text = fila.Cells["Cmp_Carnet_Auditor"].Value.ToString();
            Txt_nombre.Text = fila.Cells["Cmp_Nombre_Auditor"].Value.ToString();
            Txt_telefono.Text = fila.Cells["Cmp_Telefono_Auditor"].Value.ToString();
            Txt_email.Text = fila.Cells["Cmp_Email_Auditor"].Value.ToString();

            Cbo_estado.SelectedValue = fila.Cells["Fk_Id_Estado_Auditor"].Value;
        }

        // Funciones de control del formulario
        private void fun_HabilitarCampos(bool bHabilitar)
        {
            Txt_carnet.Enabled = bHabilitar;
            Txt_nombre.Enabled = bHabilitar;
            Txt_telefono.Enabled = bHabilitar;
            Txt_email.Enabled = bHabilitar;
            Cbo_estado.Enabled = bHabilitar;
            // Txt_id_auditor NO: siempre bloqueado
        }

        private void fun_LimpiarCampos()
        {
            Txt_id_auditor.Clear();
            Txt_carnet.Clear();
            Txt_nombre.Clear();
            Txt_telefono.Clear();
            Txt_email.Clear();
            Cbo_estado.SelectedIndex = -1;
        }

        // Activar/desactivar botones y grid según el modo
        private void fun_EstadoBotones(string sNuevoModo)
        {
            sModo = sNuevoModo;
            bool bConsulta = (sModo == "CONSULTA");  

            // Botones que solo se usan en CONSULTA
            Btn_ingresar.Enabled = bConsulta;
            Btn_modificar.Enabled = bConsulta;
            Btn_eliminar.Enabled = bConsulta;
            Btn_consultar.Enabled = bConsulta;
            Btn_reporte.Enabled = bConsulta;
            Dgv_auditor.Enabled = bConsulta;

            // Botones que solo se usan en NUEVO o EDITAR
            Btn_guardar.Enabled = !bConsulta;
            Btn_cancelar.Enabled = !bConsulta;

            // Campos: bloqueados en consulta, habilitados al capturar
            fun_HabilitarCampos(!bConsulta);
        }

        private void Btn_ingresar_Click(object sender, EventArgs e)
        {
            try
            {
                fun_LimpiarCampos();
                Txt_id_auditor.Text =
                    controlador.ObtenerSiguienteId().ToString();//mostrar el próximo ID
                fun_EstadoBotones("NUEVO");
                Txt_carnet.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el siguiente ID:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                fun_EstadoBotones("CONSULTA");
            }
        }

        private void Btn_modificar_Click(object sender, EventArgs e)
        {
            // Debe haber un auditor seleccionado en el grid
            if (string.IsNullOrWhiteSpace(Txt_id_auditor.Text))
            {
                MessageBox.Show("Seleccione un auditor del listado para modificar.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            fun_EstadoBotones("EDITAR");
            Txt_carnet.Focus();
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            int iFkEstado = Cbo_estado.SelectedValue == null
                ? 0
                : Convert.ToInt32(Cbo_estado.SelectedValue);

            (bool bExito, string sMensaje) resultado;

            if (sModo == "NUEVO")
            {
                resultado = controlador.InsertarAuditor(
                    iFkEstado,
                    Txt_nombre.Text,
                    Txt_telefono.Text,
                    Txt_email.Text,
                    Txt_carnet.Text);
            }
            else
            {
                // Editar
                resultado = controlador.ModificarAuditor(
                    Convert.ToInt32(Txt_id_auditor.Text),
                    iFkEstado,
                    Txt_nombre.Text,
                    Txt_telefono.Text,
                    Txt_email.Text,
                    Txt_carnet.Text);
            }

            // Mostrar el resultado
            if (resultado.bExito)
            {
                MessageBox.Show(resultado.sMensaje, "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                fun_CargarAuditores();          
                fun_LimpiarCampos();
                fun_EstadoBotones("CONSULTA");  
            }
            else
            {
                MessageBox.Show(resultado.sMensaje, "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            fun_LimpiarCampos();
            fun_EstadoBotones("CONSULTA");
        }

        // nombre: solo letras (con tildes y ñ), espacios y teclas de control
        private void Txt_nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // telefono 0000-0000
        private void Txt_telefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;  
            }
        }

        private bool bFormateandoTelefono = false; 

        private void Txt_telefono_TextChanged(object sender, EventArgs e)
        {
            if (bFormateandoTelefono) return;
            bFormateandoTelefono = true;

            string sDigitos = new string(Txt_telefono.Text.Where(char.IsDigit).ToArray());

            // Maximo 8 digitos
            if (sDigitos.Length > 8)
                sDigitos = sDigitos.Substring(0, 8);

            // Si hay mas de 4, insertar el guion despues del cuarto
            string sFormateado = sDigitos.Length > 4
                ? sDigitos.Substring(0, 4) + "-" + sDigitos.Substring(4)
                : sDigitos;

            // Solo reescribir si cambio, y dejar el cursor al final
            if (Txt_telefono.Text != sFormateado)
            {
                Txt_telefono.Text = sFormateado;
                Txt_telefono.SelectionStart = sFormateado.Length;
            }

            bFormateandoTelefono = false;
        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            // Debe haber un auditor seleccionado en el grid
            if (string.IsNullOrWhiteSpace(Txt_id_auditor.Text))
            {
                MessageBox.Show("Seleccione un auditor del listado para eliminar.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirmar antes de borrar (no se puede deshacer)
            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de eliminar al auditor " + Txt_carnet.Text + " - " + Txt_nombre.Text + "?\n" +
                "Esta acción no se puede deshacer.",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);   // por defecto queda marcado "No"

            if (respuesta != DialogResult.Yes)
                return;

            var resultado = controlador.EliminarAuditor(Convert.ToInt32(Txt_id_auditor.Text));

            if (resultado.bExito)
            {
                MessageBox.Show(resultado.sMensaje, "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                fun_CargarAuditores();
                fun_LimpiarCampos();
            }
            else
            {
                MessageBox.Show(resultado.sMensaje, "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Btn_consultar_Click(object sender, EventArgs e)
        {

        }

        private void Btn_reporte_Click(object sender, EventArgs e)
        {

        }

        private void Btn_ayuda_Click(object sender, EventArgs e)
        {

        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            // Si esta capturando, avisar que se perderan los datos
            if (sModo != "CONSULTA")
            {
                DialogResult respuesta = MessageBox.Show(
                    "Hay datos sin guardar. ¿Desea salir de todos modos?",
                    "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2);

                if (respuesta != DialogResult.Yes)
                    return;
            }

            this.Close();
        }
    }
    //Ernesto David Samayoa Jocol 0901-22-3415 17/10/2026
}