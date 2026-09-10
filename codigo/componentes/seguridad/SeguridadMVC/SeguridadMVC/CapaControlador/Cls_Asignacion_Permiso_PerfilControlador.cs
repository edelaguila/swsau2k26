//Brandon Alexander Hernandez Salguero - 0901-22-9663
using System.Data;
using Capa_Modelo_Seguridad;
using System;
using System.Windows.Forms;  
using System.Linq;

namespace Capa_Controlador_Seguridad
{
    public class Cls_Asignacion_Permiso_PerfilControlador
    {
        Cls_Asignacion_Permiso_PerfilesDAO DAO = new Cls_Asignacion_Permiso_PerfilesDAO();

        public DataTable datObtenerPerfiles()
        {
            return DAO.datObtenerPerfiles();
        }
        public DataTable datObtenerModulos()
        {
            return DAO.datObtenerModulos();
        }
        public DataTable datObtenerAplicaciones()
        {
            return DAO.datObtenerAplicaciones();
        }

        public bool bExistePermisoPerfil(int iIdPerfil, int iIdModulo, int iIdAplicacion)
        {
            return DAO.bExistePermisoPerfil(iIdPerfil, iIdModulo, iIdAplicacion);
        }

        public int iActualizarPermisoPerfilAplicacion(int iIdPerfil, int iIdModulo, int iIdAplicacion,
                                                     bool bIngresar, bool bConsultar, bool bModificar,
                                                     bool bEliminar, bool bImprimir)
        {
            return DAO.iActualizarPermisoPerfilAplicacion(iIdPerfil, iIdModulo, iIdAplicacion,
                                                             bIngresar, bConsultar, bModificar,
                                                             bEliminar, bImprimir);
        }
        public int iInsertarPermisoPerfilAplicacion(int iIdPerfil, int iIdModulo, int iIdAplicacion,
                                                    bool bIngresar, bool bConsultar, bool bModificar,
                                                    bool bEliminar, bool bImprimir)
        {
            return DAO.iInsertarPermisoPerfilAplicacion(iIdPerfil, iIdModulo, iIdAplicacion,
                                                           bIngresar, bConsultar, bModificar, bEliminar, bImprimir);
        }

        public DataTable datObtenerAplicacionesPorModulo(int iIdModulo)
        {
            return DAO.datObtenerAplicacionesPorModulo(iIdModulo);
        }

        public DataTable datObtenerPermisosPorPerfil(int iIdPerfil)
        {
            return DAO.datObtenerPermisosPorPerfil(iIdPerfil);
        }
        // Brandon Alexander Hernandez Salguero 0901-22-9663 11/02/202
        // los checkbox se marcan automatiamente cuando ya tiene permisos 
        public bool bVerificarPermisoPerfilExistente(int iIdPerfil, int iIdModulo, int iIdAplicacion)
        {
            try
            {
                return DAO.bExistePermisoPerfil(iIdPerfil, iIdModulo, iIdAplicacion);
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public void CargarPermisosPerfilExistentes(DataGridView dgv, int iIdPerfil, int iIdModulo, int iIdAplicacion, string sPerfil, string sAplicacion)
        {
            try
            {
                DataTable dt = DAO.ObtenerPermisoPerfilEspecifico(iIdPerfil, iIdAplicacion);

                if (dt == null || dt.Rows.Count == 0)
                {
                    
                    return;
                }

                // Verificar las columnas CON "b"
                if (!dt.Columns.Contains("bIngresar_permiso_aplicacion_perfil"))
                {
                    MessageBox.Show("Error: El formato de datos de permisos es incorrecto.\n" +
                                  "Columnas disponibles: " + string.Join(", ", dt.Columns.Cast<System.Data.DataColumn>().Select(c => c.ColumnName)));
                    return;
                }

                DataRow row = dt.Rows[0];

                // Usar los nombres CON "b"
                bool bIngresar = Convert.ToInt32(row["bIngresar_permiso_aplicacion_perfil"]) == 1;
                bool bConsultar = Convert.ToInt32(row["bConsultar_permiso_aplicacion_perfil"]) == 1;
                bool bModificar = Convert.ToInt32(row["bModificar_permiso_aplicacion_perfil"]) == 1;
                bool bEliminar = Convert.ToInt32(row["bEliminar_permiso_aplicacion_perfil"]) == 1;
                bool bImprimir = Convert.ToInt32(row["imprimir_permiso_aplicacion_perfil"]) == 1;

                // Buscar si ya existe en el DataGridView
                bool encontrado = false;
                foreach (DataGridViewRow dgvRow in dgv.Rows)
                {
                    if (dgvRow.IsNewRow) continue;

                    if (dgvRow.Cells["IdPerfil"].Value == null ||
                        dgvRow.Cells["IdModulo"].Value == null ||
                        dgvRow.Cells["IdAplicacion"].Value == null)
                        continue;

                    int p = Convert.ToInt32(dgvRow.Cells["IdPerfil"].Value);
                    int m = Convert.ToInt32(dgvRow.Cells["IdModulo"].Value);
                    int a = Convert.ToInt32(dgvRow.Cells["IdAplicacion"].Value);

                    if (p == iIdPerfil && m == iIdModulo && a == iIdAplicacion)
                    {
                        // Actualizar la fila existente
                        dgvRow.Cells["Ingresar"].Value = bIngresar;
                        dgvRow.Cells["Consultar"].Value = bConsultar;
                        dgvRow.Cells["Modificar"].Value = bModificar;
                        dgvRow.Cells["Eliminar"].Value = bEliminar;
                        dgvRow.Cells["Imprimir"].Value = bImprimir;
                        encontrado = true;
                        break;
                    }
                }

                // Si no existe en el grid, agregar nueva fila
                if (!encontrado)
                {
                    dgv.Rows.Add(
                        sPerfil,        // 0 - Perfil
                        sAplicacion,    // 1 - Aplicacion
                        bIngresar,      // 2 - Ingresar
                        bConsultar,     // 3 - Consultar
                        bModificar,     // 4 - Modificar
                        bEliminar,      // 5 - Eliminar
                        bImprimir,      // 6 - Imprimir
                        iIdPerfil,      // 7 - IdPerfil
                        iIdModulo,      // 8 - IdModulo
                        iIdAplicacion   // 9 - IdAplicacion
                    );
                }

                dgv.Refresh();

              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar permisos de perfil existentes: " + ex.Message + "\n\nStackTrace: " + ex.StackTrace);
            }
        }

        /// <summary>
        /// Convierte un valor BIT de MySQL a bool
        /// </summary>
        private bool ConvertirBitABool(object valor)
        {
            if (valor == null || valor == DBNull.Value)
                return false;

            // Si es byte array (común con BIT en MySQL via ODBC)
            if (valor is byte[])
            {
                byte[] bytes = (byte[])valor;
                return bytes.Length > 0 && bytes[0] != 0;
            }

            // Si es int o long
            if (valor is int || valor is long || valor is short || valor is byte)
            {
                return Convert.ToInt32(valor) != 0;
            }

            // Si ya es bool
            if (valor is bool)
            {
                return (bool)valor;
            }

            // Intentar convertir como string
            return Convert.ToBoolean(valor);
        }

        public bool ValidarYAgregarPermisoPerfil(DataGridView dgv, int iIdPerfil, int iIdModulo, int iIdAplicacion, string sPerfil, string sAplicacion)
        {
            try
            {
                // Primero verificar si ya existe en la BASE DE DATOS
                bool existeEnBD = DAO.bExistePermisoPerfil(iIdPerfil, iIdModulo, iIdAplicacion);

                if (existeEnBD)
                {
                    // Si existe en BD, cargar los permisos actuales
                    CargarPermisosPerfilExistentes(dgv, iIdPerfil, iIdModulo, iIdAplicacion, sPerfil, sAplicacion);
                    return false;
                }

                // Si no existe en BD, validar en el DataGridView
                bool bExisteEnGrid = false;
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.IsNewRow) continue;

                    if (row.Cells["IdPerfil"].Value == null ||
                        row.Cells["IdModulo"].Value == null ||
                        row.Cells["IdAplicacion"].Value == null)
                        continue;

                    int p = Convert.ToInt32(row.Cells["IdPerfil"].Value);
                    int m = Convert.ToInt32(row.Cells["IdModulo"].Value);
                    int a = Convert.ToInt32(row.Cells["IdAplicacion"].Value);

                    if (p == iIdPerfil && m == iIdModulo && a == iIdAplicacion)
                    {
                        bExisteEnGrid = true;
                        break;
                    }
                }

                if (!bExisteEnGrid)
                {
                    // AGREGAR FILA EN EL ORDEN EXACTO DE LAS COLUMNAS
                    dgv.Rows.Add(
                        sPerfil,        // Índice 0 - Perfil
                        sAplicacion,    // Índice 1 - Aplicacion
                        false,          // Índice 2 - Ingresar
                        false,          // Índice 3 - Consultar
                        false,          // Índice 4 - Modificar
                        false,          // Índice 5 - Eliminar
                        false,          // Índice 6 - Imprimir
                        iIdPerfil,      // Índice 7 - IdPerfil (oculto)
                        iIdModulo,      // Índice 8 - IdModulo (oculto)
                        iIdAplicacion   // Índice 9 - IdAplicacion (oculto)
                    );

                    // Refrescar el DataGridView
                    dgv.Refresh();

                    return true;
                }
                else
                {
                    MessageBox.Show("Este perfil ya tiene esa aplicación asignada en la lista. Solo modifique los permisos.",
                                  "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en ValidarYAgregarPermisoPerfil: " + ex.Message + "\n\n" + ex.StackTrace,
                               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
    }





