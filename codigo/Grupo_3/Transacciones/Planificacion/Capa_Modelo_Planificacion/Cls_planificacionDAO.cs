// Empieza codigo hecho por Pablo Quiroa 0901-22-2929 el dia 09/10/2026
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;

namespace Capa_Modelo_Planificacion
{
    public class Cls_planificacionDAO
    {
        private readonly Cls_conexion cn = new Cls_conexion();

        private const string SelectBase =
            "SELECT p.Pk_Id_Planificacion, p.Fk_Id_Proyecto, pr.Cmp_Nombre_Proyecto, " +
            "p.Cmp_Nombre_Plan_Planificacion, p.Cmp_Descripcion_Planificacion, " +
            "p.Cmp_Fecha_Inicio_Planificacion, p.Cmp_Fecha_Fin_Planificacion, " +
            "p.Cmp_Observaciones_Planificacion " +
            "FROM tbl_planificacion p " +
            "INNER JOIN tbl_proyecto pr ON pr.Pk_Id_Proyecto = p.Fk_Id_Proyecto ";


        public bool Insertar(Cls_planificacion p)
        {
            string sql = "INSERT INTO tbl_planificacion " +
                         "(Fk_Id_Proyecto, Cmp_Nombre_Plan_Planificacion, Cmp_Descripcion_Planificacion, " +
                         "Cmp_Fecha_Inicio_Planificacion, Cmp_Fecha_Fin_Planificacion, Cmp_Observaciones_Planificacion) " +
                         "VALUES (?, ?, ?, ?, ?, ?)";

            OdbcConnection conn = cn.conexion();
            try
            {
                conn.Open();
                using (OdbcCommand cmd = new OdbcCommand(sql, conn))
                {
                    AgregarParametros(cmd, p);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            finally
            {
                cn.desconexion(conn);
            }
        }


        public bool Actualizar(Cls_planificacion p)
        {
            string sql = "UPDATE tbl_planificacion SET " +
                         "Fk_Id_Proyecto = ?, " +
                         "Cmp_Nombre_Plan_Planificacion = ?, " +
                         "Cmp_Descripcion_Planificacion = ?, " +
                         "Cmp_Fecha_Inicio_Planificacion = ?, " +
                         "Cmp_Fecha_Fin_Planificacion = ?, " +
                         "Cmp_Observaciones_Planificacion = ? " +
                         "WHERE Pk_Id_Planificacion = ?";

            OdbcConnection conn = cn.conexion();
            try
            {
                conn.Open();
                using (OdbcCommand cmd = new OdbcCommand(sql, conn))
                {
                    AgregarParametros(cmd, p);
                    cmd.Parameters.AddWithValue("@id", p.PkIdPlanificacion); // el WHERE va de ultimo
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            finally
            {
                cn.desconexion(conn);
            }
        }


        public bool Eliminar(int id)
        {
            string sql = "DELETE FROM tbl_planificacion WHERE Pk_Id_Planificacion = ?";

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
                // Los cronogramas se borran en cascada
                // asignaciones o checklist relacionados, MySQL bloquea el borrado.
                if (ex.Message.IndexOf("foreign key", StringComparison.OrdinalIgnoreCase) >= 0)
                    throw new Exception("No se puede eliminar la planificación porque su cronograma tiene " +
                                        "registros relacionados (ponderaciones, asignaciones o checklist).");
                throw;
            }
            finally
            {
                cn.desconexion(conn);
            }
        }


        public List<Cls_planificacion> ObtenerTodas()
        {
            List<Cls_planificacion> lista = new List<Cls_planificacion>();
            string sql = SelectBase + "ORDER BY p.Pk_Id_Planificacion";

            OdbcConnection conn = cn.conexion();
            try
            {
                conn.Open();
                using (OdbcCommand cmd = new OdbcCommand(sql, conn))
                using (OdbcDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                        lista.Add(MapearPlanificacion(dr));
                }
            }
            finally
            {
                cn.desconexion(conn);
            }
            return lista;
        }


        public int ContarCronogramas(int idPlanificacion)
        {
            string sql = "SELECT COUNT(*) FROM tbl_cronograma WHERE Fk_Id_Planificacion = ?";

            OdbcConnection conn = cn.conexion();
            try
            {
                conn.Open();
                using (OdbcCommand cmd = new OdbcCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idPlanificacion);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            finally
            {
                cn.desconexion(conn);
            }
        }


        public DataTable ObtenerProyectosCombo()
        {
            DataTable tabla = new DataTable();
            string sql = "SELECT Pk_Id_Proyecto AS Id, " +
                         "CONCAT(Pk_Id_Proyecto, ' - ', Cmp_Nombre_Proyecto) AS Texto " +
                         "FROM tbl_proyecto ORDER BY Pk_Id_Proyecto";

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


        
        private void AgregarParametros(OdbcCommand cmd, Cls_planificacion p)
        {
            cmd.Parameters.AddWithValue("@proyecto", p.FkIdProyecto);
            cmd.Parameters.AddWithValue("@nombre", p.NombrePlan);
            cmd.Parameters.AddWithValue("@desc", (object)p.Descripcion ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@inicio", (object)p.FechaInicio ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@fin", (object)p.FechaFin ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@obs", (object)p.Observaciones ?? DBNull.Value);
        }


        private Cls_planificacion MapearPlanificacion(OdbcDataReader dr)
        {
            return new Cls_planificacion
            {
                PkIdPlanificacion = dr.GetInt32(0),
                FkIdProyecto = dr.GetInt32(1),
                NombreProyecto = dr.GetString(2),
                NombrePlan = dr.GetString(3),
                Descripcion = dr.IsDBNull(4) ? null : dr.GetString(4),
                FechaInicio = dr.IsDBNull(5) ? (DateTime?)null : Convert.ToDateTime(dr.GetValue(5)),
                FechaFin = dr.IsDBNull(6) ? (DateTime?)null : Convert.ToDateTime(dr.GetValue(6)),
                Observaciones = dr.IsDBNull(7) ? null : dr.GetString(7)
            };
        }
    }
}
// Termina codigo hecho por Pablo Quiroa 0901-22-2929 el dia 09/10/2026