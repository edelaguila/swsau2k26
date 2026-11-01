// Arón Esquit 0901-22-13036 29/10/2026
using System;
using System.Collections.Generic;
using System.Data.Odbc;

namespace Capa_Modelo_Seguridad
{
    public class Cls_AuditorDAO
    {
        private Cls_Conexion conexion = new Cls_Conexion();

        private static readonly string SQL_SELECT = @"
            SELECT Pk_Id_Auditor, Cmp_Nombre_Auditor
            FROM Tbl_Auditor
            ORDER BY Cmp_Nombre_Auditor";

        public List<(int Id, string Nombre)> fun_ObtenerAuditores()
        {
            List<(int Id, string Nombre)> lista =
                new List<(int Id, string Nombre)>();

            using (OdbcConnection conn = conexion.conexion())
            {
                using (OdbcCommand cmd = new OdbcCommand(SQL_SELECT, conn))
                {
                    using (OdbcDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int iIdAuditor = reader.GetInt32(0);

                            string sNombreAuditor = reader.IsDBNull(1)
                                ? string.Empty
                                : reader.GetString(1);

                            lista.Add((iIdAuditor, sNombreAuditor));
                        }
                    }
                }
            }

            return lista;
        }
    }
}
