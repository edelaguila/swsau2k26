// Brandon Hernandez 0901-22-9663 18/10/2026 - DAO de tbl_informes
using System.Data;
using System.Data.Odbc;
using Capa_Modelo_Seguridad;

namespace Capa_Modelo_Informes
{
    public class Cls_InformesDAO
    {
        private readonly Cls_Conexion conexion = new Cls_Conexion();
        private const int iESTADO_ACTIVO = 1;

        // ---------- Sentencias ----------
        private const string SQL_SELECT_ALL = @"
            SELECT 
                i.Pk_id_informe,
                i.titulo_informe,
                i.Fk_id_proyecto,
                p.Cmp_Nombre_Proyecto,
                i.Fk_id_estado_informe,
                e.Cmp_Nombre_Estado_Informe,
                i.Fk_id_auditor,
                a.Cmp_Nombre_Auditor,
                i.fecha_creacion,
                i.fecha_actualizacion
            FROM tbl_informe i
            INNER JOIN tbl_proyecto      p ON p.Pk_id_proyecto       = i.Fk_id_proyecto
            INNER JOIN tbl_estado_informe e ON e.Pk_id_estado_informe = i.Fk_id_estado_informe
            INNER JOIN tbl_auditor      a ON a.Pk_id_auditor        = i.Fk_id_auditor
            ORDER BY i.Pk_id_informe DESC;";

        private const string SQL_INSERT = @"
            INSERT INTO tbl_informe
                (titulo_informe, Fk_id_proyecto, Fk_id_estado_informe, Fk_id_auditor)
            VALUES (?, ?, ?, ?);";

        private const string SQL_UPDATE = @"
            UPDATE tbl_informe SET
                titulo_informe = ?,
                Fk_id_proyecto = ?,
                Fk_id_estado_informe = ?,
                Fk_id_auditor = ?
            WHERE Pk_id_informe = ?;";

        private const string SQL_CAMBIAR_ESTADO = @"
            UPDATE tbl_informe SET Fk_id_estado_informe = ?
            WHERE Pk_id_informe = ?;";

        private const string SQL_PROYECTOS = @"
            SELECT Pk_id_proyecto,
                   CONCAT(Pk_id_proyecto, ' - ', Cmp_Nombre_Proyecto) AS Proyecto
            FROM tbl_proyecto
            WHERE Fk_id_Proyecto_Estado = ?
            ORDER BY Cmp_Nombre_Proyecto;";

        private const string SQL_AUDITORES = @"
            SELECT Pk_id_auditor,
                   CONCAT(Cmp_Carnet_Auditor, ' - ', Cmp_Nombre_Auditor) AS Auditor
            FROM tbl_auditor
            WHERE Fk_id_estado_auditor = ?
            ORDER BY Cmp_Nombre_Auditor;";

        private const string SQL_ESTADOS = @"
            SELECT Pk_id_estado_informe, Cmp_Nombre_Estado_Informe
            FROM tbl_estado_informe
            ORDER BY Cmp_Nombre_Estado_Informe;";

        // ---------- Consultas ----------
        public DataTable fun_Obtener_Informes()
        {
            DataTable dtResultado = new DataTable();
            using (OdbcConnection conn = conexion.AbrirConexion())
            using (OdbcDataAdapter da = new OdbcDataAdapter(SQL_SELECT_ALL, conn))
            {
                da.Fill(dtResultado);
            }
            return dtResultado;
        }

        public DataTable fun_Obtener_Proyectos()
        {
            DataTable dtResultado = new DataTable();
            using (OdbcConnection conn = conexion.AbrirConexion())
            using (OdbcCommand cmd = new OdbcCommand(SQL_PROYECTOS, conn))
            {
                cmd.Parameters.AddWithValue("@Fk_id_estado_proyecto", iESTADO_ACTIVO);
                using (OdbcDataAdapter da = new OdbcDataAdapter(cmd))
                {
                    da.Fill(dtResultado);
                }
            }
            return dtResultado;
        }

        public DataTable fun_Obtener_Auditores()
        {
            DataTable dtResultado = new DataTable();
            using (OdbcConnection conn = conexion.AbrirConexion())
            using (OdbcCommand cmd = new OdbcCommand(SQL_AUDITORES, conn))
            {
                cmd.Parameters.AddWithValue("@Fk_id_estado_auditor", iESTADO_ACTIVO);
                using (OdbcDataAdapter da = new OdbcDataAdapter(cmd))
                {
                    da.Fill(dtResultado);
                }
            }
            return dtResultado;
        }

        public DataTable fun_Obtener_Estados_Informe()
        {
            DataTable dtResultado = new DataTable();
            using (OdbcConnection conn = conexion.AbrirConexion())
            using (OdbcDataAdapter da = new OdbcDataAdapter(SQL_ESTADOS, conn))
            {
                da.Fill(dtResultado);
            }
            return dtResultado;
        }

        // ---------- Escritura ----------
        public bool fun_Insertar_Informe(Cls_Informes oInforme)
        {
            using (OdbcConnection conn = conexion.AbrirConexion())
            using (OdbcCommand cmd = new OdbcCommand(SQL_INSERT, conn))
            {
                cmd.Parameters.AddWithValue("@titulo_informe", oInforme.Cmp_titulo_informe);
                cmd.Parameters.AddWithValue("@Fk_id_proyecto", oInforme.Fk_id_proyecto);
                cmd.Parameters.AddWithValue("@Fk_id_estado_informe", oInforme.Fk_id_estado_informe);
                cmd.Parameters.AddWithValue("@Fk_id_auditor", oInforme.Fk_id_auditor);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool fun_Actualizar_Informe(Cls_Informes oInforme)
        {
            using (OdbcConnection conn = conexion.AbrirConexion())
            using (OdbcCommand cmd = new OdbcCommand(SQL_UPDATE, conn))
            {
                cmd.Parameters.AddWithValue("@titulo_informe", oInforme.Cmp_titulo_informe);
                cmd.Parameters.AddWithValue("@Fk_id_proyecto", oInforme.Fk_id_proyecto);
                cmd.Parameters.AddWithValue("@Fk_id_estado_informe", oInforme.Fk_id_estado_informe);
                cmd.Parameters.AddWithValue("@Fk_id_auditor", oInforme.Fk_id_auditor);
                cmd.Parameters.AddWithValue("@Pk_id_informe", oInforme.Pk_id_Informe); // WHERE al final
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool fun_Cambiar_Estado_Informe(int iIdInforme, int iNuevoEstado)
        {
            using (OdbcConnection conn = conexion.AbrirConexion())
            using (OdbcCommand cmd = new OdbcCommand(SQL_CAMBIAR_ESTADO, conn))
            {
                cmd.Parameters.AddWithValue("@Fk_id_estado_informe", iNuevoEstado);
                cmd.Parameters.AddWithValue("@Pk_id_informe", iIdInforme);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}