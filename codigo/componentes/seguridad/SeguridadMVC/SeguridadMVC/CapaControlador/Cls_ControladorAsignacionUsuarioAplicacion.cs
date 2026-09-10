using System.Data;
using Capa_Modelo_Seguridad;
using System.Windows.Forms;
using System;
using System.Data.Odbc;
using System.Linq;

namespace Capa_Controlador_Seguridad
{
    public class Cls_ControladorAsignacionUsuarioAplicacion
    {
        Cls_SentenciaAsignacionUsuarioAplicacion model = new Cls_SentenciaAsignacionUsuarioAplicacion();
        Cls_Conexion conexion = new Cls_Conexion();

        // Métodos existentes (sin cambios)
        public DataTable ObtenerUsuarios() => model.fun_ObtenerUsuarios();
        public DataTable ObtenerModulos() => model.fun_ObtenerModulos();
        public DataTable ObtenerAplicacionesPorModulo(int idModulo) => model.fun_ObtenerAplicacionesPorModulo(idModulo);
        public DataTable ObtenerPermisosPorUsuario(int idUsuario) => model.fun_ObtenerPermisosPorUsuario(idUsuario);
        public DataTable ObtenerPermisosPorUsuarioYModulo(int idUsuario, int idModulo) => model.fun_bbtener_permisos_por_usuario_modulo(idUsuario, idModulo);

        public bool InsertarPermisoUsuarioAplicacion(int iIdUsuario, int iIdModulo, int iIdAplicacion,
                                                     bool bIngresar, bool bConsultar, bool bModificar,
                                                     bool bEliminar, bool bImprimir)
        {
            int filas = model.InsertarPermisoUsuarioAplicacion(iIdUsuario, iIdModulo, iIdAplicacion,
                                                               bIngresar, bConsultar, bModificar,
                                                               bEliminar, bImprimir);
            return filas > 0;
        }

        // Brandon Hernandez 0901-22-9663 se agrego que desde el boton insertar se puedan ver los metodos seleccionados 


  

        public bool ValidarYAgregarPermiso(DataGridView dgv, int iIdUsuario, int iIdModulo, int iIdAplicacion, string sUsuario, string sAplicacion)
        {
            // Primero verificar si ya existe en la BASE DE DATOS
            if (model.ExistePermiso(iIdUsuario, iIdModulo, iIdAplicacion))
            {
                // Si existe en BD, cargar los permisos actuales
                CargarPermisosExistentes(dgv, iIdUsuario, iIdModulo, iIdAplicacion, sUsuario, sAplicacion);

                return false;
            }

            // Si no existe en BD, validar en el DataGridView
            bool bExiste = false;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;
                int u = Convert.ToInt32(row.Cells["IdUsuario"].Value);
                int m = Convert.ToInt32(row.Cells["IdModulo"].Value);
                int a = Convert.ToInt32(row.Cells["IdAplicacion"].Value);

                if (u == iIdUsuario && m == iIdModulo && a == iIdAplicacion)
                {
                    bExiste = true;
                    break;
                }
            }

            if (!bExiste)
            {
                // Agregar nuevo registro con checkboxes en false
                dgv.Rows.Add(sUsuario, sAplicacion, false, false, false, false, false, iIdUsuario, iIdModulo, iIdAplicacion);
                return true;
            }
            else
            {
                MessageBox.Show("Este usuario ya tiene esa aplicación asignada en la lista. Solo modifique los permisos.");
                return false;
            }
        }
        public DataTable ObtenerPermisoEspecifico(int iIdUsuario, int iIdModulo, int iIdAplicacion)
        {
            try
            {
                string sQuery = @"SELECT 
                            ingresar_permiso_aplicacion_usuario, 
                            consultar_permiso_aplicacion_usuario, 
                            modificar_permiso_aplicacion_usuario, 
                            eliminar_permiso_aplicacion_usuario, 
                            imprimir_permiso_aplicacion_usuario
                          FROM tbl_permisosAplicacionesUsuario
                          WHERE fk_id_usuario = " + iIdUsuario +
                                  " AND iFk_id_aplicacion = " + iIdAplicacion +
                                  " AND iFk_id_aplicacion IN (SELECT pk_id_aplicacion FROM tbl_aplicaciones WHERE fk_id_modulo = " + iIdModulo + ")";

                OdbcDataAdapter dt = new OdbcDataAdapter(sQuery,(conexion.conexion()));
                DataTable table = new DataTable();
                dt.Fill(table);

                return table;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en ObtenerPermisoEspecifico: " + ex.Message);
                return new DataTable();
            }
        }



        public void CargarPermisosExistentes(DataGridView dgv, int iIdUsuario, int iIdModulo, int iIdAplicacion, string sUsuario, string sAplicacion)
        {
            try
            {
                DataTable dt = model.ObtenerPermisoEspecifico(iIdUsuario, iIdModulo, iIdAplicacion);

                // Verificar si se obtuvieron datos
                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron permisos guardados para este usuario y aplicación.");
                    return;
                }

                // Verificar que las columnas existan
                if (!dt.Columns.Contains("ingresar") || !dt.Columns.Contains("consultar"))
                {
                    MessageBox.Show("Error: El formato de datos de permisos es incorrecto.\n" +
                                  "Columnas disponibles: " + string.Join(", ", dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName)));
                    return;
                }

                DataRow row = dt.Rows[0];

                // Convertir los valores de la BD (0 o 1) a booleanos de forma segura
                bool bIngresar = false;
                bool bConsultar = false;
                bool bModificar = false;
                bool bEliminar = false;
                bool bImprimir = false;

                try
                {
                    bIngresar = row["ingresar"] != DBNull.Value && Convert.ToInt32(row["ingresar"]) == 1;
                    bConsultar = row["consultar"] != DBNull.Value && Convert.ToInt32(row["consultar"]) == 1;
                    bModificar = row["modificar"] != DBNull.Value && Convert.ToInt32(row["modificar"]) == 1;
                    bEliminar = row["eliminar"] != DBNull.Value && Convert.ToInt32(row["eliminar"]) == 1;
                    bImprimir = row["imprimir"] != DBNull.Value && Convert.ToInt32(row["imprimir"]) == 1;
                }
                catch (Exception exConvert)
                {
                    MessageBox.Show("Error al convertir permisos: " + exConvert.Message);
                    return;
                }

                // Buscar si ya existe en el DataGridView
                bool encontrado = false;
                foreach (DataGridViewRow dgvRow in dgv.Rows)
                {
                    if (dgvRow.IsNewRow) continue;

                    // Verificar que las celdas no sean null antes de convertir
                    if (dgvRow.Cells["IdUsuario"].Value == null ||
                        dgvRow.Cells["IdModulo"].Value == null ||
                        dgvRow.Cells["IdAplicacion"].Value == null)
                        continue;

                    int u = Convert.ToInt32(dgvRow.Cells["IdUsuario"].Value);
                    int m = Convert.ToInt32(dgvRow.Cells["IdModulo"].Value);
                    int a = Convert.ToInt32(dgvRow.Cells["IdAplicacion"].Value);

                    if (u == iIdUsuario && m == iIdModulo && a == iIdAplicacion)
                    {
                        // Actualizar la fila existente con los valores de la BD
                        dgvRow.Cells["Ingresar"].Value = bIngresar;
                        dgvRow.Cells["Consultar"].Value = bConsultar;
                        dgvRow.Cells["Modificar"].Value = bModificar;
                        dgvRow.Cells["Eliminar"].Value = bEliminar;
                        dgvRow.Cells["Imprimir"].Value = bImprimir;
                        encontrado = true;
                        break;
                    }
                }

                // Si no se encontró en el grid, agregar nueva fila con los permisos existentes
                if (!encontrado)
                {
                    dgv.Rows.Add(
                        sUsuario,           // Usuario
                        sAplicacion,        // Aplicacion
                        bIngresar,          // Ingresar
                        bConsultar,         // Consultar
                        bModificar,         // Modificar
                        bEliminar,          // Eliminar
                        bImprimir,          // Imprimir
                        iIdUsuario,         // IdUsuario (oculto)
                        iIdModulo,          // IdModulo (oculto)
                        iIdAplicacion       // IdAplicacion (oculto)
                    );
                }

                // Refrescar el DataGridView para mostrar los checkboxes
                dgv.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar permisos existentes: " + ex.Message + "\n\nStackTrace: " + ex.StackTrace);
            }
        }
        public (int Insertados, int Actualizados) ProcesarPermisos(DataGridView dgv, Cls_Registrar_Permisos_Bitacora registrarBitacora)
        {
            int iInsertados = 0;
            int iActualizados = 0;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;

                int iIdUsuario = Convert.ToInt32(row.Cells["IdUsuario"].Value);
                int iIdModulo = Convert.ToInt32(row.Cells["IdModulo"].Value);
                int iIdAplicacion = Convert.ToInt32(row.Cells["IdAplicacion"].Value);

                bool bIngresar = Convert.ToBoolean(row.Cells["Ingresar"].Value ?? false);
                bool bConsultar = Convert.ToBoolean(row.Cells["Consultar"].Value ?? false);
                bool bModificar = Convert.ToBoolean(row.Cells["Modificar"].Value ?? false);
                bool bEliminar = Convert.ToBoolean(row.Cells["Eliminar"].Value ?? false);
                bool bImprimir = Convert.ToBoolean(row.Cells["Imprimir"].Value ?? false);

                // Registrar en bitácora
                var gPermisosActuales = new Cls_Permisos
                {
                    bIngresar = bIngresar,
                    bConsultar = bConsultar,
                    bModificar = bModificar,
                    bEliminar = bEliminar,
                    bImprimir = bImprimir
                };

                registrarBitacora.fun_CompararYRegistrar(
                    Cls_Usuario_Conectado.iIdUsuario,
                    iIdUsuario,
                    iIdModulo,
                    iIdAplicacion,
                    row.Cells["Usuario"].Value.ToString(),
                    row.Cells["Aplicacion"].Value.ToString(),
                    gPermisosActuales
                );

                // Lógica de negocio para insertar o actualizar
                if (model.ExistePermiso(iIdUsuario, iIdModulo, iIdAplicacion))
                {
                    model.ActualizarPermisoUsuarioAplicacion(iIdUsuario, iIdModulo, iIdAplicacion,
                                                              bIngresar, bConsultar, bModificar,
                                                              bEliminar, bImprimir);
                    iActualizados++;
                }
                else
                {
                    model.InsertarPermisoUsuarioAplicacion(iIdUsuario, iIdModulo, iIdAplicacion,
                                                            bIngresar, bConsultar, bModificar,
                                                            bEliminar, bImprimir);
                    iInsertados++;
                }
            }

            return (iInsertados, iActualizados);
        }

        public void QuitarPermiso(DataGridView dgv, Cls_BitacoraControlador ctrlBitacora)
        {
            int idAplicacion = Convert.ToInt32(dgv.CurrentRow.Cells["IdAplicacion"].Value);
            int idUsuario = Cls_Usuario_Conectado.iIdUsuario;
            string sUsuario = dgv.CurrentRow.Cells["Usuario"].Value.ToString();
            string sAplicacion = dgv.CurrentRow.Cells["Aplicacion"].Value.ToString();

            dgv.Rows.Remove(dgv.CurrentRow);

            ctrlBitacora.RegistrarAccion(idUsuario, idAplicacion,
                $"Al usuario '{sUsuario}' se le quitarán todos los permisos en la aplicación '{sAplicacion}'", true);
        }

        public bool CargarPermisosUsuario(DataGridView dgv, int idUsuario)
        {
            DataTable dtPermisos = ObtenerPermisosPorUsuario(idUsuario);
            dgv.Rows.Clear();

            if (dtPermisos.Rows.Count > 0)
            {
                foreach (DataRow row in dtPermisos.Rows)
                {
                    dgv.Rows.Add(
                        row["nombre_usuario"].ToString(),
                        row["nombre_aplicacion"].ToString(),
                        Convert.ToBoolean(row["ingresar_permiso_aplicacion_usuario"]),
                        Convert.ToBoolean(row["consultar_permiso_aplicacion_usuario"]),
                        Convert.ToBoolean(row["modificar_permiso_aplicacion_usuario"]),
                        Convert.ToBoolean(row["eliminar_permiso_aplicacion_usuario"]),
                        Convert.ToBoolean(row["imprimir_permiso_aplicacion_usuario"]),
                        row["fk_id_usuario"],
                        row["iFk_id_modulo"],
                        row["iFk_id_aplicacion"]
                    );
                }
                return true;
            }
            return false;
        }
    }
}