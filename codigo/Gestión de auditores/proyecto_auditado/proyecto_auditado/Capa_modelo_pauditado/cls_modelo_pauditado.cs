using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_modelo_pauditado
{
    public class cls_modelo_pauditado
    {
        
        
            private readonly cls_conexión con = new cls_conexión();

            // Combo de proyectos (ASUME que tbl_proyecto tiene Cmp_Nombre_Proyecto: cámbialo si se llama distinto)
            public DataTable ObtenerProyectos()
            {
                return Consultar("SELECT Pk_Id_Proyecto, Cmp_Nombre_Proyecto FROM tbl_proyecto ORDER BY Cmp_Nombre_Proyecto");
            }

            // Combo de auditados
            public DataTable ObtenerAuditados()
            {
                return Consultar("SELECT Pk_Id_Auditado, Cmp_Nombre_Auditado FROM tbl_auditados ORDER BY Cmp_Nombre_Auditado");
            }

            // DataGridView: JOIN para ver nombres en lugar de ids
            public DataTable ObtenerRegistros()
            {
                string sql =
                    @"SELECT pa.Pk_Id_Proyecto_Auditado,
                         pa.Fk_Id_Proyecto,
                         pa.Fk_Id_Auditado,
                         p.Cmp_Nombre_Proyecto         AS Proyecto,
                         a.Cmp_Nombre_Auditado         AS Auditado,
                         a.Cmp_Cargo_Area_Auditado     AS Cargo_Area,
                         pa.Cmp_Fecha_Ingreso_Auditado AS Fecha_Ingreso
                  FROM tbl_proyecto_auditado pa
                  INNER JOIN tbl_proyecto  p ON p.Pk_Id_Proyecto = pa.Fk_Id_Proyecto
                  INNER JOIN tbl_auditados a ON a.Pk_Id_Auditado = pa.Fk_Id_Auditado
                  ORDER BY pa.Pk_Id_Proyecto_Auditado DESC";
                return Consultar(sql);
            }

            // Evita el mismo auditado dos veces en el mismo proyecto
            public bool Existe(int idProyecto, int idAuditado, int idExcluir)
            {
                string sql =
                    @"SELECT COUNT(*) FROM tbl_proyecto_auditado
                  WHERE Fk_Id_Proyecto = ? AND Fk_Id_Auditado = ? AND Pk_Id_Proyecto_Auditado <> ?";
                OdbcConnection cn = con.AbrirConexion();
                try
                {
                    using (OdbcCommand cmd = new OdbcCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@proy", idProyecto);
                        cmd.Parameters.AddWithValue("@aud", idAuditado);
                        cmd.Parameters.AddWithValue("@id", idExcluir);
                        return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                    }
                }
                finally { con.desconexion(cn); }
            }

            // CREATE
            public int Insertar(int idProyecto, int idAuditado, DateTime fecha)
            {
                string sql =
                    @"INSERT INTO tbl_proyecto_auditado
                    (Fk_Id_Proyecto, Fk_Id_Auditado, Cmp_Fecha_Ingreso_Auditado)
                  VALUES (?, ?, ?)";
                OdbcConnection cn = con.AbrirConexion();
                try
                {
                    using (OdbcCommand cmd = new OdbcCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@proy", idProyecto);
                        cmd.Parameters.AddWithValue("@aud", idAuditado);
                        cmd.Parameters.Add("@fecha", OdbcType.Date).Value = fecha.Date;
                        return cmd.ExecuteNonQuery();
                    }
                }
                finally { con.desconexion(cn); }
            }

            // UPDATE
            public int Actualizar(int id, int idProyecto, int idAuditado, DateTime fecha)
            {
                string sql =
                    @"UPDATE tbl_proyecto_auditado
                  SET Fk_Id_Proyecto = ?, Fk_Id_Auditado = ?, Cmp_Fecha_Ingreso_Auditado = ?
                  WHERE Pk_Id_Proyecto_Auditado = ?";
                OdbcConnection cn = con.AbrirConexion();
                try
                {
                    using (OdbcCommand cmd = new OdbcCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@proy", idProyecto);
                        cmd.Parameters.AddWithValue("@aud", idAuditado);
                        cmd.Parameters.Add("@fecha", OdbcType.Date).Value = fecha.Date;
                        cmd.Parameters.AddWithValue("@id", id);
                        return cmd.ExecuteNonQuery();
                    }
                }
                finally { con.desconexion(cn); }
            }

            // DELETE
            public int Eliminar(int id)
            {
                OdbcConnection cn = con.AbrirConexion();
                try
                {
                    using (OdbcCommand cmd = new OdbcCommand(
                        "DELETE FROM tbl_proyecto_auditado WHERE Pk_Id_Proyecto_Auditado = ?", cn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        return cmd.ExecuteNonQuery();
                    }
                }
                finally { con.desconexion(cn); }
            }

            private DataTable Consultar(string sql)
            {
                DataTable tabla = new DataTable();
                OdbcConnection cn = con.AbrirConexion();
                try
                {
                    using (OdbcDataAdapter da = new OdbcDataAdapter(sql, cn))
                    {
                        da.Fill(tabla);
                    }
                }
                finally { con.desconexion(cn); }
                return tabla;
            }
        }
    }
