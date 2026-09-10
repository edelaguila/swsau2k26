using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Windows.Forms;
using Capa_Controlador_Componente_Consultas;
using System.ComponentModel;




// Samuel Estuardo Gómez Lec 0901-21-10616 (estandarizacion y reorganizacion del diseño) 13/10/2025
namespace Capa_Vista_Componente_Consultas_simples
{
    public partial class Consulta_simple : UserControl
    {
        private readonly Cls_Controlador controlador = new Cls_Controlador();
        private string snombreTablaExterna;
        private readonly Dictionary<string, string> mapNombreAmigableAReal = new Dictionary<string, string>();

        // CARLO ANDREE BARQUERO BOCHE 0901-22-601 15/10/2025
        //  Constructor vacío (usado por el diseñador)

        public Consulta_simple()
        {
            InitializeComponent();
            Rdb_asc.CheckedChanged += Orden_CheckedChanged;
            Rdb_desc.CheckedChanged += Orden_CheckedChanged;
            this.Load += Consulta_simple_Load;
        }

        // CARLO ANDREE BARQUERO BOCHE 0901-22-60 15/10/2025
        // Constructor que recibe el nombre de la tabla desde otro módulo

        public Consulta_simple(string snombreTabla)
        {
            InitializeComponent();
            snombreTablaExterna = snombreTabla;
            Rdb_asc.CheckedChanged += Orden_CheckedChanged;
            Rdb_desc.CheckedChanged += Orden_CheckedChanged;

 
            this.Load += Consulta_simple_Load;

            if (!string.IsNullOrWhiteSpace(snombreTablaExterna))
                CargarDatosTabla(snombreTablaExterna);
        }

        // CARLO ANDREE BARQUERO BOCHE 0901-22-601 15/10/2025
        // Propiedad pública visible desde el diseñador
        [Browsable(true)]
        [Category("Datos")]
        [Description("Nombre de la tabla que el control debe consultar al cargarse.")]
        public string sNombreTablaExterna
        {
            get => snombreTablaExterna;
            set
            {
                snombreTablaExterna = value;

                // Verifica que el control esté listo antes de cargar
                if (this.IsHandleCreated && !string.IsNullOrWhiteSpace(value))
                    CargarDatosTabla(value);
            }
        }

        // CARLO ANDREE BARQUERO BOCHE 0901-22-601
        // Método público para cambiar tabla en tiempo de ejecución
        public void CambiarTabla(string nuevaTabla)
        {
            snombreTablaExterna = nuevaTabla;
            CargarDatosTabla(snombreTablaExterna);
        }

        // CARLO ANDREE BARQUERO BOCHE 0901-22-601 5/10/2025
        // Evento Load del control
        private void Consulta_simple_Load(object sender, EventArgs e)
        {
            // Si ya hay tabla asignada antes de que el control cargue, aquí se cargan los datos
            if (!string.IsNullOrWhiteSpace(snombreTablaExterna))
                CargarDatosTabla(snombreTablaExterna);
        }

        // Diego André Monterroso Rabarique 0901-22-1369  16/10/2025
        // Carga los datos de la tabla en el grid y llena combos

        private void CargarDatosTabla(string stabla)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(stabla))
                {
                    MessageBox.Show("No se ha recibido el nombre de la tabla.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataTable datos = controlador.fun_EjecutarConsulta(stabla, "");
                Dgv_consultas_simples.DataSource = datos;
                Dgv_consultas_simples.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                // --- Bloque de seguridad para impedir modificaciones ---
                Dgv_consultas_simples.ReadOnly = true;
                Dgv_consultas_simples.AllowUserToAddRows = false;
                Dgv_consultas_simples.AllowUserToDeleteRows = false;
                Dgv_consultas_simples.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                Dgv_consultas_simples.MultiSelect = false;


                LlenarComboCamposConFriendlyNames(datos);
                LlenarComboOperadores();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }

        // CARLO ANDREE BARQUERO BOCHE 0901-22-601 15/10/2025
        // Llena los operadores del ComboBox
        private void LlenarComboOperadores()
        {
            Cbo_Operador.Items.Clear();
            Cbo_Operador.Items.AddRange(new string[]
            {
                "=",
                "!=",
                ">",
                "<",
                ">=",
                "<=",
                "Contiene",
                "Comienza con",
                "Termina con"
            });
            Cbo_Operador.SelectedIndex = 0;
        }
        // Diego André Monterroso Rabarique 0901-22-1369 15/10/2025
        // Llena los campos del ComboBox con nombres amigables
        private void LlenarComboCamposConFriendlyNames(DataTable dresultado)
        {
            Cbo_Campos.Items.Clear();
            mapNombreAmigableAReal.Clear();

            foreach (DataColumn col in dresultado.Columns)
            {
                string friendly = col.ColumnName;
                friendly = Regex.Replace(friendly, @"^(cmp_|tbl_|cmp|pk_|pkid_)?", "", RegexOptions.IgnoreCase);
                friendly = friendly.Replace("_", " ");
                friendly = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(friendly.ToLower());

                string skey = friendly;
                int i = 1;
                while (mapNombreAmigableAReal.ContainsKey(skey))
                {
                    skey = friendly + " (" + i + ")";
                    i++;
                }

                mapNombreAmigableAReal[skey] = col.ColumnName;
                Cbo_Campos.Items.Add(skey);
            }

            if (Cbo_Campos.Items.Count > 0)
                Cbo_Campos.SelectedIndex = 0;
        }
        // Diego André Monterroso Rabarique 0901-22-1369 13/10/2025
        // Botón Buscar: carga toda la tabla
        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            CargarDatosTabla(snombreTablaExterna);
        }
        // Jose Pablo Medina 0901-22-22592
        // Botón Filtrar: genera una consulta simple 15/10/2025
        private void Btn_filtrar_Click(object osender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(snombreTablaExterna))
                {
                    MessageBox.Show("No se ha recibido el nombre de la tabla.", "Consulta",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (Cbo_Campos.SelectedItem == null || Cbo_Operador.SelectedItem == null)
                {
                    MessageBox.Show("Selecciona un campo y un operador.", "Filtro",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string friendly = Cbo_Campos.SelectedItem.ToString();
                string operador = Cbo_Operador.SelectedItem.ToString();
                string valorRaw = Txt_Filtro.Text.Trim();

                if (string.IsNullOrWhiteSpace(valorRaw))
                {
                    MessageBox.Show("Ingresa un valor para filtrar.", "Filtro",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string scampoReal = mapNombreAmigableAReal[friendly];
                string sorden = (Rdb_asc.Checked ? "ORDER BY 1 ASC" :
                                (Rdb_desc.Checked ? "ORDER BY 1 DESC" : ""));

                DataTable resultado = controlador.fun_ConsultaFiltrada(
                    snombreTablaExterna,
                    scampoReal,
                    operador,
                    valorRaw,
                    sorden
                );

                Dgv_consultas_simples.DataSource = resultado;
                Dgv_consultas_simples.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al aplicar filtro: " + ex.Message);
            }
        }
        // RICHARD ANTONY DE LEON 0901 - 22 - 10265 13/10/2025
        // Ordenamiento ASC / DESC
        private void Orden_CheckedChanged(object osender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(snombreTablaExterna))
                return;

            bool basc = Rdb_asc.Checked;

            DataTable resultado = controlador.fun_ConsultaOrdenada(snombreTablaExterna, basc);
            Dgv_consultas_simples.DataSource = resultado;
            Dgv_consultas_simples.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
    }
}
