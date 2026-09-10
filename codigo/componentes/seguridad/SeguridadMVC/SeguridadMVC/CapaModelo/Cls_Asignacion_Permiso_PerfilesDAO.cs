using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Odbc;

/* Brandon Alexander Hernandez Salguero
 * 0901-22-9663
 */

namespace Capa_Modelo_Seguridad
{
    public class Cls_Asignacion_Permiso_PerfilesDAO
    {
        private Cls_Conexion conexion = new Cls_Conexion();

        /// Brandon Alexander Hernandez 0901-22-9663 11/02/2026
        /// Obtiene un permiso específico de un perfil para una aplicación

        public DataTable ObtenerPermisoPerfilEspecifico(int iIdPerfil, int iIdAplicacion)
        {
            DataTable dt = new DataTable();
            OdbcConnection conn = null;

            string query = @"SELECT 
                p.Cmp_Puesto_Perfil AS nombre_perfil,
                a.Cmp_Nombre_Aplicacion AS nombre_aplicacion,
                ppa.Cmp_Ingresar_Permisos_Aplicacion_Perfil + 0 AS bIngresar_permiso_aplicacion_perfil,
                ppa.Cmp_Consultar_Permisos_Aplicacion_Perfil + 0 AS bConsultar_permiso_aplicacion_perfil,
                ppa.Cmp_Modificar_Permisos_Aplicacion_Perfil + 0 AS bModificar_permiso_aplicacion_perfil,
                ppa.Cmp_Eliminar_Permisos_Aplicacion_Perfil + 0 AS bEliminar_permiso_aplicacion_perfil,
                ppa.Cmp_Imprimir_Permisos_Aplicacion_Perfil + 0 AS imprimir_permiso_aplicacion_perfil,
                ppa.Fk_Id_Perfil AS iFk_id_perfil,
                ppa.Fk_Id_Modulo AS iFk_id_modulo,
                ppa.Fk_Id_Aplicacion AS iFk_id_aplicacion
            FROM Tbl_Permiso_Perfil_Aplicacion ppa
            INNER JOIN Tbl_Perfil p ON ppa.Fk_Id_Perfil = p.Pk_Id_Perfil
            INNER JOIN Tbl_Aplicacion a ON ppa.Fk_Id_Aplicacion = a.Pk_Id_Aplicacion
            WHERE ppa.Fk_Id_Perfil = ? AND ppa.Fk_Id_Aplicacion = ?";

            try
            {
                conn = conexion.conexion();
                // NO llamar a conn.Open() porque conexion.conexion() ya la abre

                using (OdbcCommand cmd = new OdbcCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idPerfil", iIdPerfil);
                    cmd.Parameters.AddWithValue("@idAplicacion", iIdAplicacion);

                  
                    using (OdbcDataAdapter adapter = new OdbcDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }

                    Console.WriteLine($"Filas retornadas: {dt.Rows.Count}");

                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                    
                    }
                    else
                    {
                        Console.WriteLine("¡NO SE ENCONTRARON DATOS!");
                    }
                }

                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR en ObtenerPermisoPerfilEspecifico: " + ex.Message);
                Console.WriteLine("StackTrace: " + ex.StackTrace);
                
                return dt;
            }
            finally
            {
                if (conn != null && conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                    Console.WriteLine("Conexión cerrada en ObtenerPermisoPerfilEspecifico");
                }
            }
        }


        public DataTable datObtenerPerfiles()
        {
            DataTable dt = new DataTable();
            string query = "SELECT Pk_Id_Perfil, Cmp_Puesto_Perfil FROM Tbl_Perfil";

            using (OdbcConnection conn = conexion.conexion())
            {
                using (OdbcCommand cmd = new OdbcCommand(query, conn))
                {
                    using (OdbcDataAdapter da = new OdbcDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }

            return dt;
        }

        public DataTable datObtenerModulos()
        {
            DataTable dt = new DataTable();
            string query = "SELECT Pk_Id_Modulo, Cmp_Nombre_Modulo FROM Tbl_Modulo";

            using (OdbcConnection conn = conexion.conexion())
            {
                using (OdbcCommand cmd = new OdbcCommand(query, conn))
                {
                    using (OdbcDataAdapter da = new OdbcDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }

            return dt;
        }

        public DataTable datObtenerAplicaciones()
        {
            DataTable dt = new DataTable();
            string query = "SELECT Pk_Id_Aplicacion, Cmp_Nombre_Aplicacion FROM Tbl_Aplicacion";

            using (OdbcConnection conn = conexion.conexion())
            {
                using (OdbcCommand cmd = new OdbcCommand(query, conn))
                {
                    using (OdbcDataAdapter da = new OdbcDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
                return dt;
            }
        }

        public int iInsertarPermisoPerfilAplicacion(
            int iIdPerfil,
            int idModulo,
            int iIdAplicacion,
            bool bIngresar,
            bool bConsultar,
            bool bModificar,
            bool bEliminar,
            bool bImprimir)
        {
            int filasAfectadas = 0;

            string query = @"INSERT INTO Tbl_Permiso_Perfil_Aplicacion
                (Fk_Id_Modulo, Fk_Id_Perfil, Fk_Id_Aplicacion,
                 Cmp_Ingresar_Permisos_Aplicacion_Perfil,
                 Cmp_Consultar_Permisos_Aplicacion_Perfil,
                 Cmp_Modificar_Permisos_Aplicacion_Perfil,
                 Cmp_Eliminar_Permisos_Aplicacion_Perfil,
                 Cmp_Imprimir_Permisos_Aplicacion_Perfil)
                VALUES (?, ?, ?, ?, ?, ?, ?, ?)";

            using (OdbcConnection conn = conexion.conexion())
            {
                using (OdbcCommand cmd = new OdbcCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", idModulo);
                    cmd.Parameters.AddWithValue("?", iIdPerfil);
                    cmd.Parameters.AddWithValue("?", iIdAplicacion);
                    cmd.Parameters.AddWithValue("?", bIngresar);
                    cmd.Parameters.AddWithValue("?", bConsultar);
                    cmd.Parameters.AddWithValue("?", bModificar);
                    cmd.Parameters.AddWithValue("?", bEliminar);
                    cmd.Parameters.AddWithValue("?", bImprimir);

                    filasAfectadas = cmd.ExecuteNonQuery();
                }
            }

            return filasAfectadas;
        }

        public bool bExistePermisoPerfil(int iIdPerfil, int iIdModulo, int iIdAplicacion)
        {
            OdbcConnection conn = null;
            try
            {
                conn = conexion.conexion();

                // NO llamar a conn.Open() porque conexion.conexion() ya la abre

                string verificar = @"SELECT COUNT(*) 
                             FROM Tbl_Permiso_Perfil_Aplicacion
                             WHERE Fk_Id_Perfil = ? AND Fk_Id_Modulo = ? AND Fk_Id_Aplicacion = ?";

                using (OdbcCommand cmd = new OdbcCommand(verificar, conn))
                {
                    cmd.Parameters.AddWithValue("?", iIdPerfil);
                    cmd.Parameters.AddWithValue("?", iIdModulo);
                    cmd.Parameters.AddWithValue("?", iIdAplicacion);

                    int existe = Convert.ToInt32(cmd.ExecuteScalar());

                    Console.WriteLine($"bExistePermisoPerfil → Perfil:{iIdPerfil}, Modulo:{iIdModulo}, App:{iIdAplicacion} = {existe}");

                    return existe > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en bExistePermisoPerfil: " + ex.Message);
              
                return false;
            }
            finally
            {
                if (conn != null && conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                    Console.WriteLine("Conexión cerrada en bExistePermisoPerfil");
                }
            }
        }

        public int iActualizarPermisoPerfilAplicacion(int iIdPerfil, int iIdModulo, int iIdAplicacion,
                                             bool bIngresar, bool bConsultar, bool bModificar,
                                             bool bEliminar, bool bImprimir)
        {
            int filasAfectadas = 0;

            string query = @"UPDATE Tbl_Permiso_Perfil_Aplicacion
                     SET Cmp_Ingresar_Permisos_Aplicacion_Perfil = ?,
                         Cmp_Consultar_Permisos_Aplicacion_Perfil = ?,
                         Cmp_Modificar_Permisos_Aplicacion_Perfil = ?,
                         Cmp_Eliminar_Permisos_Aplicacion_Perfil = ?,
                         Cmp_Imprimir_Permisos_Aplicacion_Perfil = ?
                     WHERE Fk_Id_Perfil = ? AND Fk_Id_Modulo = ? AND Fk_Id_Aplicacion = ?";

            using (OdbcConnection conn = conexion.conexion())
            {
                using (OdbcCommand cmd = new OdbcCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", bIngresar);
                    cmd.Parameters.AddWithValue("?", bConsultar);
                    cmd.Parameters.AddWithValue("?", bModificar);
                    cmd.Parameters.AddWithValue("?", bEliminar);
                    cmd.Parameters.AddWithValue("?", bImprimir);
                    cmd.Parameters.AddWithValue("?", iIdPerfil);
                    cmd.Parameters.AddWithValue("?", iIdModulo);
                    cmd.Parameters.AddWithValue("?", iIdAplicacion);

                    filasAfectadas = cmd.ExecuteNonQuery();
                }
            }

            return filasAfectadas;
        }
        public DataTable datObtenerAplicacionesPorModulo(int iIdModulo)
        {
            DataTable dt = new DataTable();
            // Consulta JOIN entre Tbl_Aplicacion y Tbl_Asignacion_Modulo_Aplicacion
            string query = @"
        SELECT a.Pk_Id_Aplicacion, 
        a.Cmp_Nombre_Aplicacion 
        FROM Tbl_Aplicacion a
        INNER JOIN Tbl_Asignacion_Modulo_Aplicacion ma 
        ON a.Pk_Id_Aplicacion = ma.Fk_Id_Aplicacion
        WHERE a.Cmp_Estado_Aplicacion = 1 
        AND ma.Fk_Id_Modulo = ?";

            try
            {
                using (OdbcConnection conn = conexion.conexion())
                {
                    using (OdbcCommand cmd = new OdbcCommand(query, conn))
                    {
                        // Agregamos el parámetro del módulo para el WHERE
                        cmd.Parameters.AddWithValue("?", iIdModulo);
                        using (OdbcDataAdapter da = new OdbcDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de error
                Console.WriteLine("Error al obtener aplicaciones por módulo: " + ex.Message);
            }
            return dt;
        }
        public DataTable datObtenerPermisosPorPerfil(int iIdPerfil)
        {
            DataTable dt = new DataTable();
            string query = @"
        SELECT 
            p.Cmp_Puesto_Perfil AS nombre_perfil,
            a.Cmp_Nombre_Aplicacion AS nombre_aplicacion,
            ppa.Cmp_Ingresar_Permisos_Aplicacion_Perfil AS bIngresar_permiso_aplicacion_perfil,
            ppa.Cmp_Consultar_Permisos_Aplicacion_Perfil AS bConsultar_permiso_aplicacion_perfil,
            ppa.Cmp_Modificar_Permisos_Aplicacion_Perfil AS bModificar_permiso_aplicacion_perfil,
            ppa.Cmp_Eliminar_Permisos_Aplicacion_Perfil AS bEliminar_permiso_aplicacion_perfil,
            ppa.Cmp_Imprimir_Permisos_Aplicacion_Perfil AS imprimir_permiso_aplicacion_perfil,
            ppa.Fk_Id_Perfil AS iFk_id_perfil,
            ppa.Fk_Id_Modulo AS iFk_id_modulo,
            ppa.Fk_Id_Aplicacion AS iFk_id_aplicacion
        FROM Tbl_Permiso_Perfil_Aplicacion ppa
        INNER JOIN Tbl_Perfil p ON ppa.Fk_Id_Perfil = p.Pk_Id_Perfil
        INNER JOIN Tbl_Aplicacion a ON ppa.Fk_Id_Aplicacion = a.Pk_Id_Aplicacion
        WHERE ppa.Fk_Id_Perfil = ?";
            try
            {
                using (OdbcConnection conn = conexion.conexion())
                {
                    using (OdbcCommand cmd = new OdbcCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", iIdPerfil);
                        using (OdbcDataAdapter da = new OdbcDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
               
                
            }
            return dt;
        }

        /*Carlo Sosa 0901-22-1106
         */

        public DataTable ObtenerPermisosPerfilAplicacion(int iIdPerfil, int iIdAplicacion)
        {
            DataTable dt = new DataTable();
            string query = @"SELECT 
                        Cmp_Ingresar_Permisos_Aplicacion_Perfil AS bIngresar,
                        Cmp_Consultar_Permisos_Aplicacion_Perfil AS bConsultar,
                        Cmp_Modificar_Permisos_Aplicacion_Perfil AS bModificar,
                        Cmp_Eliminar_Permisos_Aplicacion_Perfil AS bEliminar,
                        Cmp_Imprimir_Permisos_Aplicacion_Perfil AS bImprimir
                    FROM  Tbl_Permiso_Perfil_Aplicacion
                    WHERE Fk_Id_Perfil = ? AND Fk_Id_Aplicacion = ?";

            using (OdbcConnection conn = conexion.conexion())
            using (OdbcCommand cmd = new OdbcCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@iIdPerfil", iIdPerfil);
                cmd.Parameters.AddWithValue("@iIdAplicacion", iIdAplicacion);

                using (OdbcDataAdapter adapter = new OdbcDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }
            return dt;
        }
    }
}
