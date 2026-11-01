//Inicio de código de "Pablo José Quiroa Martínez" con carné: "0901-22-2929" en la fecha de: "20/10/2026"
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;

namespace Capa_Modelo_Cronograma
{
    // Clase de acceso a datos: ejecuta las sentencias SQL de tbl_cronograma
    public class Cls_CronogramaDAO
    {
        private readonly Cls_Conexion cn = new Cls_Conexion();

        private const string sSelectBase =
            "SELECT c.Pk_Id_Cronograma, c.Fk_Id_Planificacion, p.Cmp_Nombre_Plan_Planificacion, " +
            "c.Fk_Id_Actividad_Proyecto, a.Cmp_Nombre_Actividad_Proyecto, " +
            "c.Cmp_Nombre_Tarea_Cronograma, c.Cmp_Descripcion_Cronograma, " +
            "c.Cmp_Fecha_Inicio_Cronograma, c.Cmp_Fecha_Fin_Cronograma, " +
            "c.Cmp_Responsable_Tarea_Cronograma, c.Cmp_Estado_Tarea_Cronograma, " +
            "c.Cmp_Observaciones_Cronograma " +
            "FROM tbl_cronograma c " +
            "INNER JOIN tbl_planificacion p ON p.Pk_Id_Planificacion = c.Fk_Id_Planificacion " +
            "INNER JOIN tbl_actividades_proyecto a ON a.Pk_Id_Actividad_Proyecto = c.Fk_Id_Actividad_Proyecto ";


        public bool fun_insertar(Cls_Cronograma cronograma)
        {
            string sSql = "INSERT INTO tbl_cronograma " +
                          "(Fk_Id_Planificacion, Fk_Id_Actividad_Proyecto, Cmp_Nombre_Tarea_Cronograma, " +
                          "Cmp_Descripcion_Cronograma, Cmp_Fecha_Inicio_Cronograma, Cmp_Fecha_Fin_Cronograma, " +
                          "Cmp_Responsable_Tarea_Cronograma, Cmp_Estado_Tarea_Cronograma, Cmp_Observaciones_Cronograma) " +
                          "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)";

            OdbcConnection conn = cn.fun_conexion();
            try
            {
                conn.Open();
                using (OdbcCommand cmd = new OdbcCommand(sSql, conn))
                {
                    pro_agregar_parametros(cmd, cronograma);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            finally
            {
                cn.pro_desconexion(conn);
            }
        }


        public bool fun_actualizar(Cls_Cronograma cronograma)
        {
            string sSql = "UPDATE tbl_cronograma SET " +
                          "Fk_Id_Planificacion = ?, " +
                          "Fk_Id_Actividad_Proyecto = ?, " +
                          "Cmp_Nombre_Tarea_Cronograma = ?, " +
                          "Cmp_Descripcion_Cronograma = ?, " +
                          "Cmp_Fecha_Inicio_Cronograma = ?, " +
                          "Cmp_Fecha_Fin_Cronograma = ?, " +
                          "Cmp_Responsable_Tarea_Cronograma = ?, " +
                          "Cmp_Estado_Tarea_Cronograma = ?, " +
                          "Cmp_Observaciones_Cronograma = ? " +
                          "WHERE Pk_Id_Cronograma = ?";

            OdbcConnection conn = cn.fun_conexion();
            try
            {
                conn.Open();
                using (OdbcCommand cmd = new OdbcCommand(sSql, conn))
                {
                    pro_agregar_parametros(cmd, cronograma);
                    cmd.Parameters.AddWithValue("@id", cronograma.PkIdCronograma); // el WHERE va de ultimo
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            finally
            {
                cn.pro_desconexion(conn);
            }
        }


        public bool fun_eliminar(int iIdCronograma)
        {
            string sSql = "DELETE FROM tbl_cronograma WHERE Pk_Id_Cronograma = ?";

            OdbcConnection conn = cn.fun_conexion();
            try
            {
                conn.Open();
                using (OdbcCommand cmd = new OdbcCommand(sSql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", iIdCronograma);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (OdbcException ex)
            {
                // Las rubricas se borran en cascada, pero tbl_tabla_ponderacion no,
                // asi que si ya hay calificaciones MySQL bloquea el borrado.
                if (ex.Message.IndexOf("foreign key", StringComparison.OrdinalIgnoreCase) >= 0)
                    throw new Exception("No se puede eliminar la tarea porque tiene registros relacionados " +
                                        "(ponderaciones, asignaciones o checklist).");
                throw;
            }
            finally
            {
                cn.pro_desconexion(conn);
            }
        }


        public List<Cls_Cronograma> fun_obtener_todos()
        {
            List<Cls_Cronograma> lista = new List<Cls_Cronograma>();
            string sSql = sSelectBase + "ORDER BY c.Pk_Id_Cronograma";

            OdbcConnection conn = cn.fun_conexion();
            try
            {
                conn.Open();
                using (OdbcCommand cmd = new OdbcCommand(sSql, conn))
                using (OdbcDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                        lista.Add(fun_mapear_cronograma(dr));
                }
            }
            finally
            {
                cn.pro_desconexion(conn);
            }
            return lista;
        }


        public DataTable fun_obtener_planificaciones_combo()
        {
            string sSql = "SELECT Pk_Id_Planificacion AS Id, " +
                          "CONCAT(Pk_Id_Planificacion, ' - ', Cmp_Nombre_Plan_Planificacion) AS Texto " +
                          "FROM tbl_planificacion ORDER BY Pk_Id_Planificacion";
            return fun_consultar_tabla(sSql, null);
        }


        // Solo las actividades del proyecto al que pertenece la planificacion
        public DataTable fun_obtener_actividades_por_planificacion(int iIdPlanificacion)
        {
            string sSql = "SELECT a.Pk_Id_Actividad_Proyecto AS Id, " +
                          "CONCAT(a.Pk_Id_Actividad_Proyecto, ' - ', a.Cmp_Nombre_Actividad_Proyecto) AS Texto " +
                          "FROM tbl_actividades_proyecto a " +
                          "INNER JOIN tbl_planificacion p ON p.Fk_Id_Proyecto = a.Fk_Id_Proyecto " +
                          "WHERE p.Pk_Id_Planificacion = ? " +
                          "ORDER BY a.Pk_Id_Actividad_Proyecto";
            return fun_consultar_tabla(sSql, iIdPlanificacion);
        }


        // Verifica que la actividad sea del mismo proyecto que la planificacion
        public bool fun_actividad_pertenece_a_planificacion(int iIdPlanificacion, int iIdActividad)
        {
            string sSql = "SELECT COUNT(*) FROM tbl_actividades_proyecto a " +
                          "INNER JOIN tbl_planificacion p ON p.Fk_Id_Proyecto = a.Fk_Id_Proyecto " +
                          "WHERE p.Pk_Id_Planificacion = ? AND a.Pk_Id_Actividad_Proyecto = ?";

            OdbcConnection conn = cn.fun_conexion();
            try
            {
                conn.Open();
                using (OdbcCommand cmd = new OdbcCommand(sSql, conn))
                {
                    cmd.Parameters.AddWithValue("@plan", iIdPlanificacion);
                    cmd.Parameters.AddWithValue("@act", iIdActividad);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
            finally
            {
                cn.pro_desconexion(conn);
            }
        }


        public int fun_contar_rubricas(int iIdCronograma)
        {
            string sSql = "SELECT COUNT(*) FROM tbl_rubrica WHERE Fk_Id_Cronograma = ?";

            OdbcConnection conn = cn.fun_conexion();
            try
            {
                conn.Open();
                using (OdbcCommand cmd = new OdbcCommand(sSql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", iIdCronograma);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            finally
            {
                cn.pro_desconexion(conn);
            }
        }


        // Ejecuta un SELECT con un parametro entero opcional y devuelve un DataTable
        private DataTable fun_consultar_tabla(string sSql, int? iParametro)
        {
            DataTable tabla = new DataTable();
            OdbcConnection conn = cn.fun_conexion();
            try
            {
                conn.Open();
                using (OdbcCommand cmd = new OdbcCommand(sSql, conn))
                {
                    if (iParametro.HasValue)
                        cmd.Parameters.AddWithValue("@p", iParametro.Value);

                    using (OdbcDataReader dr = cmd.ExecuteReader())
                    {
                        tabla.Load(dr);
                    }
                }
            }
            finally
            {
                cn.pro_desconexion(conn);
            }
            return tabla;
        }


        // Los "?" de ODBC se llenan EN ORDEN, no por nombre
        private void pro_agregar_parametros(OdbcCommand cmd, Cls_Cronograma cronograma)
        {
            cmd.Parameters.AddWithValue("@plan", cronograma.FkIdPlanificacion);
            cmd.Parameters.AddWithValue("@act", cronograma.FkIdActividadProyecto);
            cmd.Parameters.AddWithValue("@nombre", cronograma.NombreTarea);
            cmd.Parameters.AddWithValue("@desc", (object)cronograma.Descripcion ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@inicio", cronograma.FechaInicio);
            cmd.Parameters.AddWithValue("@fin", cronograma.FechaFin);
            cmd.Parameters.AddWithValue("@resp", (object)cronograma.Responsable ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@estado", cronograma.Estado);
            cmd.Parameters.AddWithValue("@obs", (object)cronograma.Observaciones ?? DBNull.Value);
        }


        private Cls_Cronograma fun_mapear_cronograma(OdbcDataReader dr)
        {
            return new Cls_Cronograma
            {
                PkIdCronograma = dr.GetInt32(0),
                FkIdPlanificacion = dr.GetInt32(1),
                NombrePlanificacion = dr.GetString(2),
                FkIdActividadProyecto = dr.GetInt32(3),
                NombreActividad = dr.GetString(4),
                NombreTarea = dr.GetString(5),
                Descripcion = dr.IsDBNull(6) ? null : dr.GetString(6),
                FechaInicio = Convert.ToDateTime(dr.GetValue(7)),
                FechaFin = Convert.ToDateTime(dr.GetValue(8)),
                Responsable = dr.IsDBNull(9) ? null : dr.GetString(9),
                Estado = dr.IsDBNull(10) ? "Pendiente" : dr.GetString(10),
                Observaciones = dr.IsDBNull(11) ? null : dr.GetString(11)
            };
        }
    }
}
//Fin del código de "Pablo José Quiroa Martínez" con carné: "0901-22-2929" en la fecha de: "20/10/2026"