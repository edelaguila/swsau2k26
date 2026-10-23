// Empieza codigo hecho por Maria Morales 0901-22-1226 el dia 07/10/2026
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Modelo_Rubrica
{
    public class Cls_RubricaDAO
    {
        private readonly Cls_Conexion_Rubrica cn = new Cls_Conexion_Rubrica();


        public bool Insertar(Cls_Rubrica r)
        {
            string sql = "INSERT INTO tbl_rubrica " +
                         "(Fk_Id_Cronograma, Cmp_Nombre_Rubrica, Cmp_Descripcion_Rubrica, Cmp_Objetivo_Rubrica) " +
                         "VALUES (?, ?, ?, ?)";

            OdbcConnection conn = cn.conexion();
            try
            {
                conn.Open();
                using (OdbcCommand cmd = new OdbcCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@fk", r.FkIdCronograma);
                    cmd.Parameters.AddWithValue("@nombre", r.NombreRubrica);
                    cmd.Parameters.AddWithValue("@desc", (object)r.DescripcionRubrica ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@obj", (object)r.ObjetivoRubrica ?? DBNull.Value);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            finally
            {
                cn.desconexion(conn);
            }
        }


        public bool Actualizar(Cls_Rubrica r)
        {
            string sql = "UPDATE tbl_rubrica SET " +
                         "Fk_Id_Cronograma = ?, " +
                         "Cmp_Nombre_Rubrica = ?, " +
                         "Cmp_Descripcion_Rubrica = ?, " +
                         "Cmp_Objetivo_Rubrica = ? " +
                         "WHERE Pk_Id_Rubrica = ?";

            OdbcConnection conn = cn.conexion();
            try
            {
                conn.Open();
                using (OdbcCommand cmd = new OdbcCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@fk", r.FkIdCronograma);
                    cmd.Parameters.AddWithValue("@nombre", r.NombreRubrica);
                    cmd.Parameters.AddWithValue("@desc", (object)r.DescripcionRubrica ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@obj", (object)r.ObjetivoRubrica ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@id", r.PkIdRubrica);
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
            string sql = "DELETE FROM tbl_rubrica WHERE Pk_Id_Rubrica = ?";

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
                    throw new Exception("No se puede eliminar la rúbrica porque tiene ponderaciones asociadas.");
                throw;
            }
            finally
            {
                cn.desconexion(conn);
            }
        }


        public List<Cls_Rubrica> ObtenerTodas()
        {
            List<Cls_Rubrica> lista = new List<Cls_Rubrica>();
            string sql = "SELECT Pk_Id_Rubrica, Fk_Id_Cronograma, Cmp_Nombre_Rubrica, " +
                         "Cmp_Descripcion_Rubrica, Cmp_Objetivo_Rubrica " +
                         "FROM tbl_rubrica ORDER BY Pk_Id_Rubrica";

            OdbcConnection conn = cn.conexion();
            try
            {
                conn.Open();
                using (OdbcCommand cmd = new OdbcCommand(sql, conn))
                using (OdbcDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                        lista.Add(MapearRubrica(dr));
                }
            }
            finally
            {
                cn.desconexion(conn);
            }
            return lista;
        }


        public Cls_Rubrica ObtenerPorId(int id)
        {
            string sql = "SELECT Pk_Id_Rubrica, Fk_Id_Cronograma, Cmp_Nombre_Rubrica, " +
                         "Cmp_Descripcion_Rubrica, Cmp_Objetivo_Rubrica " +
                         "FROM tbl_rubrica WHERE Pk_Id_Rubrica = ?";

            OdbcConnection conn = cn.conexion();
            try
            {
                conn.Open();
                using (OdbcCommand cmd = new OdbcCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (OdbcDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                            return MapearRubrica(dr);
                    }
                }
            }
            finally
            {
                cn.desconexion(conn);
            }
            return null;
        }


        public List<Cls_Rubrica> BuscarPorNombre(string texto)
        {
            List<Cls_Rubrica> lista = new List<Cls_Rubrica>();
            string sql = "SELECT Pk_Id_Rubrica, Fk_Id_Cronograma, Cmp_Nombre_Rubrica, " +
                         "Cmp_Descripcion_Rubrica, Cmp_Objetivo_Rubrica " +
                         "FROM tbl_rubrica WHERE Cmp_Nombre_Rubrica LIKE ? ORDER BY Pk_Id_Rubrica";

            OdbcConnection conn = cn.conexion();
            try
            {
                conn.Open();
                using (OdbcCommand cmd = new OdbcCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@texto", "%" + texto + "%");
                    using (OdbcDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                            lista.Add(MapearRubrica(dr));
                    }
                }
            }
            finally
            {
                cn.desconexion(conn);
            }
            return lista;
        }


        public DataTable ObtenerCronogramasCombo()
        {
            DataTable tabla = new DataTable();
            string sql = "SELECT Pk_Id_Cronograma AS Id, " +
                         "CONCAT(Pk_Id_Cronograma, ' - ', Cmp_Nombre_Tarea_Cronograma) AS Texto " +
                         "FROM tbl_cronograma ORDER BY Pk_Id_Cronograma";

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


        private Cls_Rubrica MapearRubrica(OdbcDataReader dr)
        {
            return new Cls_Rubrica
            {
                PkIdRubrica = dr.GetInt32(0),
                FkIdCronograma = dr.GetInt32(1),
                NombreRubrica = dr.GetString(2),
                DescripcionRubrica = dr.IsDBNull(3) ? "" : dr.GetString(3),
                ObjetivoRubrica = dr.IsDBNull(4) ? "" : dr.GetString(4)
            };
        }
    }
}
// Termina codigo hecho por Maria Morales 0901-22-1226 el dia 07/10/2026