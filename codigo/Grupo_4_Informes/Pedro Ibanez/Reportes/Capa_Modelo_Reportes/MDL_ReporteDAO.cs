// Pedro Ibanez 19/10/2026 - DAO de tbl_reporte
using System;
using System.Data;
using System.Data.Odbc;
using Capa_Modelo_Seguridad;

namespace Capa_Modelo_Reportes
{
    public class MDL_ReporteDAO
    {
        private readonly Cls_Conexion conexion = new Cls_Conexion();
        private const int iESTADO_ACTIVO = 1;

        // ---------- Sentencias ----------
        private const string SQL_INSERT = @"
            INSERT INTO tbl_reporte
                (Fk_id_informe, Fk_id_actividad_rubrica,
                 aspectos_positivos, imagen_aspectos_positivos,
                 correcciones, imagen_correcciones,
                 recomendaciones, imagen_recomendaciones)
            VALUES (?, ?, ?, ?, ?, ?, ?, ?);";

        private const string SQL_UPDATE = @"
            UPDATE tbl_reporte SET
                Fk_id_informe = ?,
                Fk_id_actividad_rubrica = ?,
                aspectos_positivos = ?,
                imagen_aspectos_positivos = ?,
                correcciones = ?,
                imagen_correcciones = ?,
                recomendaciones = ?,
                imagen_recomendaciones = ?
            WHERE Pk_id_reporte = ?;";

        private const string SQL_DELETE = @"
            DELETE FROM tbl_reporte
            WHERE Pk_id_reporte = ?;";

        private const string SQL_INFORMES = @"
            SELECT Pk_id_informe,
                   titulo_informe,
                   CONCAT(Pk_id_informe, ' - ', titulo_informe) AS Informe
            FROM tbl_informe
            ORDER BY Pk_id_informe;";

        private const string SQL_ACTIVIDADES = @"
            SELECT ar.Pk_Id_Actividad_Rubrica,
                   ap.Cmp_Nombre_Actividad_Proyecto,
                   CONCAT(ar.Pk_Id_Actividad_Rubrica, ' - ', ap.Cmp_Nombre_Actividad_Proyecto) AS Actividad
            FROM tbl_actividad_rubrica ar
            INNER JOIN tbl_actividades_proyecto ap ON ap.Pk_Id_Actividad_Proyecto = ar.Fk_Id_Actividad_Proyecto
            WHERE ar.Cmp_Estado_Actividad_Rubrica = ?
            ORDER BY ar.Pk_Id_Actividad_Rubrica;";

        private const string SQL_REPORTES = @"
            SELECT r.Pk_id_reporte,
                   i.titulo_informe,
                   i.fecha_creacion,
                   CONCAT(r.Pk_id_reporte, ' - ', i.titulo_informe, ' - ',
                          DATE_FORMAT(i.fecha_creacion, '%d/%m/%Y')) AS Reporte
            FROM tbl_reporte r
            INNER JOIN tbl_informe i ON i.Pk_id_informe = r.Fk_id_informe
            ORDER BY r.Pk_id_reporte;";

        private const string SQL_REPORTE_POR_ID = @"
            SELECT Pk_id_reporte, Fk_id_informe, Fk_id_actividad_rubrica,
                   aspectos_positivos, imagen_aspectos_positivos,
                   correcciones, imagen_correcciones,
                   recomendaciones, imagen_recomendaciones
            FROM tbl_reporte
            WHERE Pk_id_reporte = ?;";

        // ---------- Consultas ----------
        // Devuelve null si no existe un reporte con ese id
        public MDL_Reporte fun_obtener_reporte_por_id(int iIdReporte)
        {
            using (OdbcConnection conn = conexion.AbrirConexion())
            using (OdbcCommand cmd = new OdbcCommand(SQL_REPORTE_POR_ID, conn))
            {
                cmd.Parameters.AddWithValue("@Pk_id_reporte", iIdReporte);
                using (OdbcDataReader dr = cmd.ExecuteReader())
                {
                    if (!dr.Read())
                        return null;

                    return new MDL_Reporte
                    {
                        Pk_id_reporte = Convert.ToInt32(dr["Pk_id_reporte"]),
                        Fk_id_informe = Convert.ToInt32(dr["Fk_id_informe"]),
                        Fk_id_actividad_rubrica = Convert.ToInt32(dr["Fk_id_actividad_rubrica"]),
                        aspectos_positivos = dr["aspectos_positivos"].ToString(),
                        imagen_aspectos_positivos = dr["imagen_aspectos_positivos"].ToString(),
                        correcciones = dr["correcciones"].ToString(),
                        imagen_correcciones = dr["imagen_correcciones"].ToString(),
                        recomendaciones = dr["recomendaciones"].ToString(),
                        imagen_recomendaciones = dr["imagen_recomendaciones"].ToString()
                    };
                }
            }
        }

        public DataTable fun_obtener_informes()
        {
            DataTable dtResultado = new DataTable();
            using (OdbcConnection conn = conexion.AbrirConexion())
            using (OdbcDataAdapter da = new OdbcDataAdapter(SQL_INFORMES, conn))
            {
                da.Fill(dtResultado);
            }
            return dtResultado;
        }

        public DataTable fun_obtener_actividades()
        {
            DataTable dtResultado = new DataTable();
            using (OdbcConnection conn = conexion.AbrirConexion())
            using (OdbcCommand cmd = new OdbcCommand(SQL_ACTIVIDADES, conn))
            {
                cmd.Parameters.AddWithValue("@Cmp_Estado_Actividad_Rubrica", iESTADO_ACTIVO);
                using (OdbcDataAdapter da = new OdbcDataAdapter(cmd))
                {
                    da.Fill(dtResultado);
                }
            }
            return dtResultado;
        }

        public DataTable fun_obtener_reportes()
        {
            DataTable dtResultado = new DataTable();
            using (OdbcConnection conn = conexion.AbrirConexion())
            using (OdbcDataAdapter da = new OdbcDataAdapter(SQL_REPORTES, conn))
            {
                da.Fill(dtResultado);
            }
            return dtResultado;
        }

        // ---------- Mantenimiento ----------
        // Lanza Exception con un mensaje propio si falla la BD
        public int fun_Insertar_Reporte(MDL_Reporte reporte)
        {
            try
            {
                using (OdbcConnection conn = conexion.AbrirConexion())
                using (OdbcCommand cmd = new OdbcCommand(SQL_INSERT, conn))
                {
                    pro_Agregar_Parametros(cmd, reporte);
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (OdbcException ex)
            {
                throw new Exception("No se pudo guardar el reporte: " + ex.Message, ex);
            }
        }

        // Lanza Exception con un mensaje propio si falla la BD.
        // No se trata 0 filas como error: MySQL devuelve 0 si los datos no cambiaron.
        public int fun_Modificar_Reporte(MDL_Reporte reporte)
        {
            try
            {
                using (OdbcConnection conn = conexion.AbrirConexion())
                using (OdbcCommand cmd = new OdbcCommand(SQL_UPDATE, conn))
                {
                    pro_Agregar_Parametros(cmd, reporte);
                    cmd.Parameters.AddWithValue("@Pk_id_reporte", reporte.Pk_id_reporte);
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (OdbcException ex)
            {
                throw new Exception("No se pudo actualizar el reporte: " + ex.Message, ex);
            }
        }

        // Lanza Exception con un mensaje propio si falla la BD o si el reporte no existe
        public int fun_Eliminar_Reporte(int iIdReporte)
        {
            int iFilasAfectadas;
            try
            {
                using (OdbcConnection conn = conexion.AbrirConexion())
                using (OdbcCommand cmd = new OdbcCommand(SQL_DELETE, conn))
                {
                    cmd.Parameters.AddWithValue("@Pk_id_reporte", iIdReporte);
                    iFilasAfectadas = cmd.ExecuteNonQuery();
                }
            }
            catch (OdbcException ex)
            {
                throw new Exception("No se pudo eliminar el reporte: " + ex.Message, ex);
            }

            if (iFilasAfectadas == 0)
                throw new Exception("No existe un reporte con el id " + iIdReporte + ".");

            return iFilasAfectadas;
        }

        // ODBC usa parámetros posicionales (?), el orden debe coincidir con la sentencia
        private void pro_Agregar_Parametros(OdbcCommand cmd, MDL_Reporte reporte)
        {
            cmd.Parameters.AddWithValue("@Fk_id_informe", reporte.Fk_id_informe);
            cmd.Parameters.AddWithValue("@Fk_id_actividad_rubrica", reporte.Fk_id_actividad_rubrica);
            cmd.Parameters.AddWithValue("@aspectos_positivos", reporte.aspectos_positivos ?? "");
            cmd.Parameters.AddWithValue("@imagen_aspectos_positivos", reporte.imagen_aspectos_positivos ?? "");
            cmd.Parameters.AddWithValue("@correcciones", reporte.correcciones ?? "");
            cmd.Parameters.AddWithValue("@imagen_correcciones", reporte.imagen_correcciones ?? "");
            cmd.Parameters.AddWithValue("@recomendaciones", reporte.recomendaciones ?? "");
            cmd.Parameters.AddWithValue("@imagen_recomendaciones", reporte.imagen_recomendaciones ?? "");
        }
    }
}
