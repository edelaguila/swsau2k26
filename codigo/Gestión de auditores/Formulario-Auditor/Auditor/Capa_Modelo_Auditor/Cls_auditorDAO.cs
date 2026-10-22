using Capa_Modelo_Seguridad;   
using System;
using System.Data;
using System.Data.Odbc;

//Erneto David Samayoa Jocol 0901-22-3415
namespace Capa_Modelo_Auditor
{
    public class Cls_auditorDAO
    {
        // Conexion desde modelo seguridad
        private Cls_Conexion conexion = new Cls_Conexion();

        private static readonly string SQL_LISTADO = @"
        SELECT
            a.Pk_Id_Auditor,
            a.Cmp_Carnet_Auditor,
            a.Cmp_Nombre_Auditor,
            a.Cmp_Telefono_Auditor,
            a.Cmp_Email_Auditor,
            a.Fk_Id_Estado_Auditor,
            e.Cmp_Nombre_Estado_Auditor
        FROM tbl_auditor a
        INNER JOIN tbl_estado_auditor e
            ON a.Fk_Id_Estado_Auditor = e.Pk_Id_Estado_Auditor
        ORDER BY a.Pk_Id_Auditor ASC";

        public DataTable ObtenerAuditores()
        {
            using (OdbcConnection conn = conexion.AbrirConexion())
            using (OdbcDataAdapter da = new OdbcDataAdapter(SQL_LISTADO, conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        //Estado de combobox
        private static readonly string SQL_ESTADOS = @"
        SELECT
            Pk_Id_Estado_Auditor,
            Cmp_Nombre_Estado_Auditor
        FROM tbl_estado_auditor
        ORDER BY Pk_Id_Estado_Auditor ASC";

        public DataTable ObtenerEstados()
        {
            using (OdbcConnection conn = conexion.AbrirConexion())
            using (OdbcDataAdapter da = new OdbcDataAdapter(SQL_ESTADOS, conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        //Siguiente ID de auditor
        private static readonly string SQL_SIN_CACHE =
            "SET SESSION information_schema_stats_expiry = 0";

        private static readonly string SQL_SIGUIENTE_ID = @"
        SELECT AUTO_INCREMENT
        FROM information_schema.TABLES
        WHERE TABLE_SCHEMA = DATABASE()
        AND TABLE_NAME = 'tbl_auditor'";

        public int ObtenerSiguienteId()
        {
            using (OdbcConnection conn = conexion.AbrirConexion())
            {
                using (OdbcCommand cmdCache = new OdbcCommand(SQL_SIN_CACHE, conn))
                {
                    cmdCache.ExecuteNonQuery();
                }

                using (OdbcCommand cmd = new OdbcCommand(SQL_SIGUIENTE_ID, conn))
                {
                    object resultado = cmd.ExecuteScalar();

                    if (resultado == null || resultado == DBNull.Value)
                        return 1;

                    return Convert.ToInt32(resultado);
                }
            }
        }

        //Insertar
        private static readonly string SQL_EXISTE_CARNET = @"
        SELECT COUNT(*)
        FROM tbl_auditor
        WHERE Cmp_Carnet_Auditor = ?
        AND Pk_Id_Auditor <> ?";

        public bool ExisteCarnet(string sCarnet, int iIdExcluir)
        {
            using (OdbcConnection conn = conexion.AbrirConexion())
            using (OdbcCommand cmd = new OdbcCommand(SQL_EXISTE_CARNET, conn))
            {
                cmd.Parameters.Add("?", OdbcType.VarChar, 15).Value = sCarnet;
                cmd.Parameters.Add("?", OdbcType.Int).Value = iIdExcluir;

                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        private static readonly string SQL_INSERT = @"
        INSERT INTO tbl_auditor
            (Fk_Id_Estado_Auditor, Cmp_Nombre_Auditor, Cmp_Telefono_Auditor,
             Cmp_Email_Auditor, Cmp_Carnet_Auditor)
        VALUES (?, ?, ?, ?, ?)";

        public int InsertarAuditor(Cls_auditor auditor)
        {
            using (OdbcConnection conn = conexion.AbrirConexion())
            {
                using (OdbcCommand cmd = new OdbcCommand(SQL_INSERT, conn))
                {
                    cmd.Parameters.Add("?", OdbcType.Int).Value = auditor.Fk_Id_Estado_Auditor;
                    cmd.Parameters.Add("?", OdbcType.VarChar, 45).Value = auditor.Cmp_Nombre_Auditor;
                    cmd.Parameters.Add("?", OdbcType.VarChar, 45).Value = auditor.Cmp_Telefono_Auditor;
                    cmd.Parameters.Add("?", OdbcType.VarChar, 100).Value = auditor.Cmp_Email_Auditor;
                    cmd.Parameters.Add("?", OdbcType.VarChar, 15).Value = auditor.Cmp_Carnet_Auditor;

                    cmd.ExecuteNonQuery();
                }

                using (OdbcCommand cmdId = new OdbcCommand("SELECT LAST_INSERT_ID()", conn))
                {
                    return Convert.ToInt32(cmdId.ExecuteScalar());
                }
            }
        }

        //Modificar
        private static readonly string SQL_UPDATE = @"
        UPDATE tbl_auditor
        SET
            Fk_Id_Estado_Auditor = ?,
            Cmp_Nombre_Auditor = ?,
            Cmp_Telefono_Auditor = ?,
            Cmp_Email_Auditor = ?,
            Cmp_Carnet_Auditor = ?
        WHERE Pk_Id_Auditor = ?";

        // Devuelve el numero de filas afectadas
        public int ActualizarAuditor(Cls_auditor auditor)
        {
            using (OdbcConnection conn = conexion.AbrirConexion())
            using (OdbcCommand cmd = new OdbcCommand(SQL_UPDATE, conn))
            {
                // Mismo orden que los ? del UPDATE (el ID va al final, en el WHERE)
                cmd.Parameters.Add("?", OdbcType.Int).Value = auditor.Fk_Id_Estado_Auditor;
                cmd.Parameters.Add("?", OdbcType.VarChar, 45).Value = auditor.Cmp_Nombre_Auditor;
                cmd.Parameters.Add("?", OdbcType.VarChar, 45).Value = auditor.Cmp_Telefono_Auditor;
                cmd.Parameters.Add("?", OdbcType.VarChar, 100).Value = auditor.Cmp_Email_Auditor;
                cmd.Parameters.Add("?", OdbcType.VarChar, 15).Value = auditor.Cmp_Carnet_Auditor;
                cmd.Parameters.Add("?", OdbcType.Int).Value = auditor.Pk_Id_Auditor;

                return cmd.ExecuteNonQuery();
            }
        }

        //Eliminar
        private static readonly string SQL_DELETE =
            "DELETE FROM tbl_auditor WHERE Pk_Id_Auditor = ?";

        // Devuelve el numero de filas eliminadas (0 = no existia)
        public int EliminarAuditor(int iIdAuditor)
        {
            using (OdbcConnection conn = conexion.AbrirConexion())
            using (OdbcCommand cmd = new OdbcCommand(SQL_DELETE, conn))
            {
                cmd.Parameters.Add("?", OdbcType.Int).Value = iIdAuditor;
                return cmd.ExecuteNonQuery();
            }
        }
    }
    //Ernesto David Samayoa Jocol 0901-22-3415 17/10/2026
}
