using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Modelo_Seguridad;
using System.Data;
using System.Data.Odbc;

namespace Capa_Modelo_Graficas_Informes
{
    public class ClsGraficaDAO
    {
        private readonly Cls_Conexion conexion = new Cls_Conexion();
        private const int iESTADO_ACTIVO = 1;
        private const string SQL_PROYECTOS = @"
            SELECT Pk_Id_Proyecto,
                   CONCAT(Pk_Id_Proyecto, ' - ', Cmp_Nombre_Proyecto) AS Proyecto
            FROM tbl_proyecto
            WHERE Fk_Id_Proyecto_Estado = ?
            ORDER BY Cmp_Nombre_Proyecto;";

        private const string SQL_RUBRICAS = @"
            SELECT r.Pk_Id_Rubrica,
                   r.Cmp_Nombre_Rubrica
            FROM tbl_rubrica r
            INNER JOIN tbl_cronograma    c  ON c.Pk_Id_Cronograma     = r.Fk_Id_Cronograma
            INNER JOIN tbl_planificacion pl ON pl.Pk_Id_Planificacion = c.Fk_Id_Planificacion
            WHERE pl.Fk_Id_Proyecto = ?
            ORDER BY r.Cmp_Nombre_Rubrica;";

        private const string SQL_DATOS_POR_AUDITADO = @"
            SELECT a.Cmp_Nombre_Auditado AS Etiqueta,
                   r.Cmp_Nombre_Rubrica  AS Rubrica,
                   ROUND(SUM(t.Cmp_Calificacion_Ponderada_Ponderacion), 2) AS Valor
            FROM tbl_tabla_ponderacion t
            INNER JOIN tbl_auditados     a  ON a.Pk_Id_Auditado       = t.Fk_Id_Auditado
            INNER JOIN tbl_rubrica       r  ON r.Pk_Id_Rubrica        = t.Fk_Id_Rubrica
            INNER JOIN tbl_cronograma    c  ON c.Pk_Id_Cronograma     = t.Fk_Id_Cronograma
            INNER JOIN tbl_planificacion pl ON pl.Pk_Id_Planificacion = c.Fk_Id_Planificacion
            WHERE pl.Fk_Id_Proyecto = ?
              AND t.Fk_Id_Rubrica   = ?
            GROUP BY a.Pk_Id_Auditado, a.Cmp_Nombre_Auditado, r.Cmp_Nombre_Rubrica
            ORDER BY a.Cmp_Nombre_Auditado;";

        private const string SQL_SELECT_POR_PROYECTO = @"
            SELECT Pk_id_grafica,
                   Fk_id_proyecto,
                   tipo_grafica,
                   JSON_UNQUOTE(JSON_EXTRACT(datos_json_grafica, '$.Rubrica')) AS Rubrica,
                   descripcion,
                   CAST(datos_json_grafica AS CHAR) AS datos_json_grafica
            FROM tbl_grafica
            WHERE Fk_id_proyecto = ?
            ORDER BY Pk_id_grafica DESC;";

        private const string SQL_INSERT = @"
            INSERT INTO tbl_grafica
                (Fk_id_proyecto, tipo_grafica, descripcion, datos_json_grafica)
            VALUES (?, ?, ?, ?);";

        private const string SQL_UPDATE = @"
            UPDATE tbl_grafica SET
                tipo_grafica = ?,
                descripcion = ?,
                datos_json_grafica = ?
            WHERE Pk_id_grafica = ?
              AND Fk_id_proyecto = ?;";

        private const string SQL_DELETE = @"
            DELETE FROM tbl_grafica
            WHERE Pk_id_grafica = ?;";

        public DataTable fun_Obtener_Proyectos()
        {
            DataTable dtResultado = new DataTable();
            using (OdbcConnection conn = conexion.AbrirConexion())
            using (OdbcCommand cmd = new OdbcCommand(SQL_PROYECTOS, conn))
            {
                cmd.Parameters.AddWithValue("@Fk_Id_Proyecto_Estado", iESTADO_ACTIVO);
                using (OdbcDataAdapter da = new OdbcDataAdapter(cmd))
                {
                    da.Fill(dtResultado);
                }
            }
            return dtResultado;
        }

        public DataTable fun_Obtener_Rubricas_Por_Proyecto(int iIdProyecto)
        {
            DataTable dtResultado = new DataTable();
            using (OdbcConnection conn = conexion.AbrirConexion())
            using (OdbcCommand cmd = new OdbcCommand(SQL_RUBRICAS, conn))
            {
                cmd.Parameters.AddWithValue("@Fk_Id_Proyecto", iIdProyecto);
                using (OdbcDataAdapter da = new OdbcDataAdapter(cmd))
                {
                    da.Fill(dtResultado);
                }
            }
            return dtResultado;
        }

        public DataTable fun_Obtener_Datos_Por_Auditado(int iIdProyecto, int iIdRubrica)
        {
            DataTable dtResultado = new DataTable();
            using (OdbcConnection conn = conexion.AbrirConexion())
            using (OdbcCommand cmd = new OdbcCommand(SQL_DATOS_POR_AUDITADO, conn))
            {
                cmd.Parameters.AddWithValue("@Fk_Id_Proyecto", iIdProyecto);
                cmd.Parameters.AddWithValue("@Fk_Id_Rubrica", iIdRubrica);
                using (OdbcDataAdapter da = new OdbcDataAdapter(cmd))
                {
                    da.Fill(dtResultado);
                }
            }
            return dtResultado;
        }

        public DataTable fun_Obtener_Graficas_Por_Proyecto(int iIdProyecto)
        {
            DataTable dtResultado = new DataTable();
            using (OdbcConnection conn = conexion.AbrirConexion())
            using (OdbcCommand cmd = new OdbcCommand(SQL_SELECT_POR_PROYECTO, conn))
            {
                cmd.Parameters.AddWithValue("@Fk_id_proyecto", iIdProyecto);
                using (OdbcDataAdapter da = new OdbcDataAdapter(cmd))
                {
                    da.Fill(dtResultado);
                }
            }
            return dtResultado;
        }

        public bool fun_Insertar_Grafica(ClsGraficasM oGrafica)
        {
            using (OdbcConnection conn = conexion.AbrirConexion())
            using (OdbcCommand cmd = new OdbcCommand(SQL_INSERT, conn))
            {
                cmd.Parameters.AddWithValue("@Fk_id_proyecto", oGrafica.Fk_id_proyecto);
                cmd.Parameters.AddWithValue("@tipo_grafica", oGrafica.tipo_grafica);
                cmd.Parameters.AddWithValue("@descripcion", (object)oGrafica.descripcion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@datos_json_grafica", oGrafica.datos_json_grafica);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool fun_Actualizar_Grafica(ClsGraficasM oGrafica)
        {
            using (OdbcConnection conn = conexion.AbrirConexion())
            using (OdbcCommand cmd = new OdbcCommand(SQL_UPDATE, conn))
            {
                cmd.Parameters.AddWithValue("@tipo_grafica", oGrafica.tipo_grafica);
                cmd.Parameters.AddWithValue("@descripcion", (object)oGrafica.descripcion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@datos_json_grafica", oGrafica.datos_json_grafica);
                cmd.Parameters.AddWithValue("@Pk_id_grafica", oGrafica.Pk_id_grafica);
                cmd.Parameters.AddWithValue("@Fk_id_proyecto", oGrafica.Fk_id_proyecto);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool fun_Eliminar_Grafica(int iIdGrafica)
        {
            using (OdbcConnection conn = conexion.AbrirConexion())
            using (OdbcCommand cmd = new OdbcCommand(SQL_DELETE, conn))
            {
                cmd.Parameters.AddWithValue("@Pk_id_grafica", iIdGrafica);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}