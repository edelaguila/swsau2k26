// Codigo empezado por: Maria Morales 0901-22-1226 el día 19/10/2026
using Capa_Modelo_Actividad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Modelo_Actividad
{
    public class Cls_Actividad_RubricaDAO
    {
        private readonly Cls_Conexion_Actividad_Rubrica cn = new Cls_Conexion_Actividad_Rubrica();

       
        public bool Insertar(Cls_Actividad_Rubrica a)
        {
            string sql = "INSERT INTO tbl_actividad_rubrica " +
                         "(Fk_Id_Actividad_Proyecto, Fk_Id_Rubrica, Cmp_Estado_Actividad_Rubrica) " +
                         "VALUES (?, ?, ?)";

            OdbcConnection conn = cn.conexion();
            try
            {
                conn.Open();
                using (OdbcCommand cmd = new OdbcCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@act", a.FkIdActividadProyecto);
                    cmd.Parameters.AddWithValue("@rub", a.FkIdRubrica);
                    cmd.Parameters.AddWithValue("@estado", a.EstadoActividadRubrica ? 1 : 0);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (OdbcException ex)
            {
                
                if (ex.Message.IndexOf("duplicate", StringComparison.OrdinalIgnoreCase) >= 0)
                    throw new Exception("Esa actividad ya está asignada a la rúbrica seleccionada.");
                throw;
            }
            finally
            {
                cn.desconexion(conn);
            }
        }


        public bool Actualizar(Cls_Actividad_Rubrica a)
        {
            string sql = "UPDATE tbl_actividad_rubrica SET " +
                         "Fk_Id_Actividad_Proyecto = ?, " +
                         "Fk_Id_Rubrica = ?, " +
                         "Cmp_Estado_Actividad_Rubrica = ? " +
                         "WHERE Pk_Id_Actividad_Rubrica = ?";

            OdbcConnection conn = cn.conexion();
            try
            {
                conn.Open();
                using (OdbcCommand cmd = new OdbcCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@act", a.FkIdActividadProyecto);
                    cmd.Parameters.AddWithValue("@rub", a.FkIdRubrica);
                    cmd.Parameters.AddWithValue("@estado", a.EstadoActividadRubrica ? 1 : 0);
                    cmd.Parameters.AddWithValue("@id", a.PkIdActividadRubrica);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (OdbcException ex)
            {
                if (ex.Message.IndexOf("duplicate", StringComparison.OrdinalIgnoreCase) >= 0)
                    throw new Exception("Esa actividad ya está asignada a la rúbrica seleccionada.");
                throw;
            }
            finally
            {
                cn.desconexion(conn);
            }
        }

       
        public bool Eliminar(int id)
        {
            string sql = "DELETE FROM tbl_actividad_rubrica WHERE Pk_Id_Actividad_Rubrica = ?";

            OdbcConnection conn = cn.conexion();
            try
            {
                conn.Open();
                using (OdbcCommand cmd = new OdbcCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (OdbcException ex)
            {
               
                if (ex.Message.IndexOf("foreign key", StringComparison.OrdinalIgnoreCase) >= 0)
                    throw new Exception("No se puede eliminar el registro porque tiene asignaciones, checklist o reportes asociados.");
                throw;
            }
            finally
            {
                cn.desconexion(conn);
            }
        }

   
        public DataTable ObtenerListado(string filtro)
        {
            DataTable tabla = new DataTable();
            bool hayFiltro = !string.IsNullOrWhiteSpace(filtro);

            string sql =
                "SELECT ar.Pk_Id_Actividad_Rubrica AS Id, " +
                "       ar.Fk_Id_Actividad_Proyecto AS IdActividad, " +
                "       ap.Cmp_Nombre_Actividad_Proyecto AS Actividad, " +
                "       ar.Fk_Id_Rubrica AS IdRubrica, " +
                "       r.Cmp_Nombre_Rubrica AS Rubrica, " +
                "       CAST(ar.Cmp_Estado_Actividad_Rubrica AS SIGNED) AS Estado, " +
                "       IF(ar.Cmp_Estado_Actividad_Rubrica = 1, 'Activo', 'Inactivo') AS EstadoTexto " +
                "FROM tbl_actividad_rubrica ar " +
                "INNER JOIN tbl_actividades_proyecto ap ON ap.Pk_Id_Actividad_Proyecto = ar.Fk_Id_Actividad_Proyecto " +
                "INNER JOIN tbl_rubrica r ON r.Pk_Id_Rubrica = ar.Fk_Id_Rubrica ";

            if (hayFiltro)
                sql += "WHERE ap.Cmp_Nombre_Actividad_Proyecto LIKE ? OR r.Cmp_Nombre_Rubrica LIKE ? ";

            sql += "ORDER BY ar.Pk_Id_Actividad_Rubrica";

            OdbcConnection conn = cn.conexion();
            try
            {
                conn.Open();
                using (OdbcCommand cmd = new OdbcCommand(sql, conn))
                {
                    if (hayFiltro)
                    {
                        cmd.Parameters.AddWithValue("@act", "%" + filtro.Trim() + "%");
                        cmd.Parameters.AddWithValue("@rub", "%" + filtro.Trim() + "%");
                    }
                    using (OdbcDataReader dr = cmd.ExecuteReader())
                    {
                        tabla.Load(dr);
                    }
                }
            }
            finally
            {
                cn.desconexion(conn);
            }
            return tabla;
        }


        public DataTable ObtenerActividadesCombo()
        {
            DataTable tabla = new DataTable();
            string sql = "SELECT Pk_Id_Actividad_Proyecto AS Id, " +
                         "CONCAT(Pk_Id_Actividad_Proyecto, ' - ', Cmp_Nombre_Actividad_Proyecto) AS Texto " +
                         "FROM tbl_actividades_proyecto ORDER BY Pk_Id_Actividad_Proyecto";

            OdbcConnection conn = cn.conexion();
            try
            {
                conn.Open();
                using (OdbcCommand cmd = new OdbcCommand(sql, conn))
                using (OdbcDataReader dr = cmd.ExecuteReader())
                {
                    tabla.Load(dr);
                }
            }
            finally
            {
                cn.desconexion(conn);
            }
            return tabla;
        }

      
        public DataTable ObtenerRubricasCombo()
        {
            DataTable tabla = new DataTable();
            string sql = "SELECT Pk_Id_Rubrica AS Id, " +
                         "CONCAT(Pk_Id_Rubrica, ' - ', Cmp_Nombre_Rubrica) AS Texto " +
                         "FROM tbl_rubrica ORDER BY Pk_Id_Rubrica";

            OdbcConnection conn = cn.conexion();
            try
            {
                conn.Open();
                using (OdbcCommand cmd = new OdbcCommand(sql, conn))
                using (OdbcDataReader dr = cmd.ExecuteReader())
                {
                    tabla.Load(dr);
                }
            }
            finally
            {
                cn.desconexion(conn);
            }
            return tabla;
        }
    }
}
// Codigo terminado por: Maria Morales 0901-22-1226 el día 19/10/2026