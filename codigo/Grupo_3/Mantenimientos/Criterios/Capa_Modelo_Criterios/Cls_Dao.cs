using Capa_Modelo_Seguridad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Capa_Modelo_Criterios
{
    public class Cls_Dao
    {

        private OdbcConnection ObtenerConexion()
        {
            return new Cls_Conexion().AbrirConexion();
        }

        public List<Cls_Criterio> Listar()
        {
            var lista = new List<Cls_Criterio>();
            const string sql = @"SELECT c.Pk_Id_Criterio, c.Fk_Id_Rubrica, r.Cmp_Nombre_Rubrica,
                                        c.Cmp_Nombre_Criterio, c.Cmp_Porcentaje_Criterio,
                                        c.Cmp_Descripcion_Criterio, c.Cmp_Nivel_Importancia_Criterio
                                 FROM tbl_criterios c
                                 JOIN tbl_rubrica r ON r.Pk_Id_Rubrica = c.Fk_Id_Rubrica
                                 ORDER BY r.Cmp_Nombre_Rubrica, c.Cmp_Nombre_Criterio";

            using (var cn = ObtenerConexion())
            using (var cmd = new OdbcCommand(sql, cn))
            {
                AbrirSiHaceFalta(cn);
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        lista.Add(new Cls_Criterio
                        {
                            Id = Convert.ToInt32(rd["Pk_Id_Criterio"]),
                            IdRubrica = Convert.ToInt32(rd["Fk_Id_Rubrica"]),
                            NombreRubrica = rd["Cmp_Nombre_Rubrica"].ToString(),
                            Nombre = rd["Cmp_Nombre_Criterio"].ToString(),
                            Porcentaje = rd["Cmp_Porcentaje_Criterio"] == DBNull.Value
                                ? (int?)null : Convert.ToInt32(rd["Cmp_Porcentaje_Criterio"]),
                            Descripcion = rd["Cmp_Descripcion_Criterio"] == DBNull.Value
                                ? "" : rd["Cmp_Descripcion_Criterio"].ToString(),
                            NivelImportancia = rd["Cmp_Nivel_Importancia_Criterio"] == DBNull.Value
                                ? "" : rd["Cmp_Nivel_Importancia_Criterio"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public DataTable ListarRubricas()
        {
            var dt = new DataTable();
            const string sql = "SELECT Pk_Id_Rubrica, Cmp_Nombre_Rubrica FROM tbl_rubrica ORDER BY Cmp_Nombre_Rubrica";
            using (var cn = ObtenerConexion())
            using (var da = new OdbcDataAdapter(sql, cn))
            {
                da.Fill(dt);
            }
            return dt;
        }

        public void Insertar(Cls_Criterio c)
        {
            // En ODBC los parámetros son posicionales (?) : el orden importa
            const string sql = @"INSERT INTO tbl_criterios
                (Fk_Id_Rubrica, Cmp_Nombre_Criterio, Cmp_Porcentaje_Criterio,
                 Cmp_Descripcion_Criterio, Cmp_Nivel_Importancia_Criterio)
                VALUES (?, ?, ?, ?, ?)";
            Ejecutar(sql, c, incluirId: false);
        }

        public void Actualizar(Cls_Criterio c)
        {
            const string sql = @"UPDATE tbl_criterios SET
                Fk_Id_Rubrica = ?, Cmp_Nombre_Criterio = ?,
                Cmp_Porcentaje_Criterio = ?, Cmp_Descripcion_Criterio = ?,
                Cmp_Nivel_Importancia_Criterio = ?
                WHERE Pk_Id_Criterio = ?";
            Ejecutar(sql, c, incluirId: true);
        }

        public void Eliminar(int id)
        {
            using (var cn = ObtenerConexion())
            using (var cmd = new OdbcCommand("DELETE FROM tbl_criterios WHERE Pk_Id_Criterio = ?", cn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                AbrirSiHaceFalta(cn);
                cmd.ExecuteNonQuery();
            }
        }

        private void Ejecutar(string sql, Cls_Criterio c, bool incluirId)
        {
            using (var cn = ObtenerConexion())
            using (var cmd = new OdbcCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@rub", c.IdRubrica);
                cmd.Parameters.AddWithValue("@nom", c.Nombre);
                cmd.Parameters.AddWithValue("@por", (object)c.Porcentaje ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@des", string.IsNullOrWhiteSpace(c.Descripcion)
                    ? (object)DBNull.Value : c.Descripcion);
                cmd.Parameters.AddWithValue("@imp", string.IsNullOrWhiteSpace(c.NivelImportancia)
                    ? (object)DBNull.Value : c.NivelImportancia);
                if (incluirId) cmd.Parameters.AddWithValue("@id", c.Id);

                AbrirSiHaceFalta(cn);
                cmd.ExecuteNonQuery();
            }
        }

        private static void AbrirSiHaceFalta(OdbcConnection cn)
        {
            if (cn.State != ConnectionState.Open) cn.Open();
        }
    }
}
