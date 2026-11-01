using Capa_Modelo_Seguridad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Modelo_Desc_Criterio
{
    public class Cls_Dao_DescripcionCriterio
    {
        private OdbcConnection fun_obtener_conexion()
        {
            return new Cls_Conexion().AbrirConexion();
        }

        public List<Cls_DescripcionCriterio> fun_listar()
        {
            List<Cls_DescripcionCriterio> lstDescripciones = new List<Cls_DescripcionCriterio>();
            const string sSql = @"SELECT d.Pk_Id_Descripcion_Criterio, d.Fk_Id_Criterio, d.Fk_Id_Escala,
                                         CONCAT(r.Cmp_Nombre_Rubrica, ' - ', c.Cmp_Nombre_Criterio) AS Cmp_Nombre_Mostrado,
                                         e.Cmp_Porcentaje_Escala, e.Cmp_Nombre_Nivel_Escala,
                                         d.Cmp_Descripcion_Detallada_Descripcion_Criterio,
                                         d.Cmp_Evidencia_Requerida_Descripcion_Criterio,
                                         d.Cmp_Observaciones_Descripcion_Criterio
                                  FROM tbl_descripcion_criterio d
                                  JOIN tbl_criterios c          ON c.Pk_Id_Criterio = d.Fk_Id_Criterio
                                  JOIN tbl_rubrica r            ON r.Pk_Id_Rubrica  = c.Fk_Id_Rubrica
                                  JOIN tbl_escala_descripcion e ON e.Pk_Id_Escala   = d.Fk_Id_Escala
                                  ORDER BY r.Cmp_Nombre_Rubrica, c.Cmp_Nombre_Criterio, e.Cmp_Porcentaje_Escala";

            using (OdbcConnection cnConexion = fun_obtener_conexion())
            using (OdbcCommand cmdConsulta = new OdbcCommand(sSql, cnConexion))
            using (OdbcDataReader drLector = cmdConsulta.ExecuteReader())
            {
                while (drLector.Read())
                {
                    lstDescripciones.Add(new Cls_DescripcionCriterio
                    {
                        pIdDescripcion = Convert.ToInt32(drLector["Pk_Id_Descripcion_Criterio"]),
                        pIdCriterio = Convert.ToInt32(drLector["Fk_Id_Criterio"]),
                        pIdEscala = Convert.ToInt32(drLector["Fk_Id_Escala"]),
                        pNombreCriterio = fun_texto(drLector["Cmp_Nombre_Mostrado"]),
                        pPorcentajeEscala = Convert.ToInt32(drLector["Cmp_Porcentaje_Escala"]),
                        pNombreNivel = fun_texto(drLector["Cmp_Nombre_Nivel_Escala"]),
                        pDescripcionDetallada = fun_texto(drLector["Cmp_Descripcion_Detallada_Descripcion_Criterio"]),
                        pEvidenciaRequerida = fun_texto(drLector["Cmp_Evidencia_Requerida_Descripcion_Criterio"]),
                        pObservaciones = fun_texto(drLector["Cmp_Observaciones_Descripcion_Criterio"])
                    });
                }
            }
            return lstDescripciones;
        }

        // Criterios para el ComboBox, mostrados como "Rúbrica - Criterio"
        public DataTable fun_listar_criterios()
        {
            const string sSql = @"SELECT c.Pk_Id_Criterio,
                                         CONCAT(r.Cmp_Nombre_Rubrica, ' - ', c.Cmp_Nombre_Criterio) AS Cmp_Nombre_Mostrado
                                  FROM tbl_criterios c
                                  JOIN tbl_rubrica r ON r.Pk_Id_Rubrica = c.Fk_Id_Rubrica
                                  ORDER BY r.Cmp_Nombre_Rubrica, c.Cmp_Nombre_Criterio";
            return fun_llenar_tabla(sSql);
        }

        // Niveles de la escala para el ComboBox, mostrados como "80% - Satisfactorio"
        public DataTable fun_listar_escalas()
        {
            const string sSql = @"SELECT Pk_Id_Escala, Cmp_Porcentaje_Escala,
                                         CONCAT(CAST(Cmp_Porcentaje_Escala AS CHAR), '% - ', Cmp_Nombre_Nivel_Escala) AS Cmp_Nombre_Mostrado
                                  FROM tbl_escala_descripcion
                                  ORDER BY Cmp_Porcentaje_Escala";
            return fun_llenar_tabla(sSql);
        }

        public void pro_insertar(Cls_DescripcionCriterio oDescripcion)
        {
            // En ODBC los parámetros son posicionales (?): el orden importa
            const string sSql = @"INSERT INTO tbl_descripcion_criterio
                (Fk_Id_Criterio, Fk_Id_Escala, Cmp_Descripcion_Detallada_Descripcion_Criterio,
                 Cmp_Evidencia_Requerida_Descripcion_Criterio, Cmp_Observaciones_Descripcion_Criterio)
                VALUES (?, ?, ?, ?, ?)";
            pro_ejecutar(sSql, oDescripcion, false);
        }

        public void pro_actualizar(Cls_DescripcionCriterio oDescripcion)
        {
            const string sSql = @"UPDATE tbl_descripcion_criterio SET
                Fk_Id_Criterio = ?, Fk_Id_Escala = ?,
                Cmp_Descripcion_Detallada_Descripcion_Criterio = ?,
                Cmp_Evidencia_Requerida_Descripcion_Criterio = ?,
                Cmp_Observaciones_Descripcion_Criterio = ?
                WHERE Pk_Id_Descripcion_Criterio = ?";
            pro_ejecutar(sSql, oDescripcion, true);
        }

        public void pro_eliminar(int iIdDescripcion)
        {
            const string sSql = "DELETE FROM tbl_descripcion_criterio WHERE Pk_Id_Descripcion_Criterio = ?";
            using (OdbcConnection cnConexion = fun_obtener_conexion())
            using (OdbcCommand cmdComando = new OdbcCommand(sSql, cnConexion))
            {
                cmdComando.Parameters.AddWithValue("@id", iIdDescripcion);
                cmdComando.ExecuteNonQuery();
            }
        }

        private void pro_ejecutar(string sSql, Cls_DescripcionCriterio oDescripcion, bool bIncluirId)
        {
            using (OdbcConnection cnConexion = fun_obtener_conexion())
            using (OdbcCommand cmdComando = new OdbcCommand(sSql, cnConexion))
            {
                cmdComando.Parameters.AddWithValue("@criterio", oDescripcion.pIdCriterio);
                cmdComando.Parameters.AddWithValue("@escala", oDescripcion.pIdEscala);
                cmdComando.Parameters.AddWithValue("@detallada", oDescripcion.pDescripcionDetallada);
                cmdComando.Parameters.AddWithValue("@evidencia", fun_valor_o_nulo(oDescripcion.pEvidenciaRequerida));
                cmdComando.Parameters.AddWithValue("@observaciones", fun_valor_o_nulo(oDescripcion.pObservaciones));
                if (bIncluirId) cmdComando.Parameters.AddWithValue("@id", oDescripcion.pIdDescripcion);
                cmdComando.ExecuteNonQuery();
            }
        }

        private DataTable fun_llenar_tabla(string sSql)
        {
            DataTable dtResultado = new DataTable();
            using (OdbcConnection cnConexion = fun_obtener_conexion())
            using (OdbcDataAdapter daAdaptador = new OdbcDataAdapter(sSql, cnConexion))
            {
                daAdaptador.Fill(dtResultado);
            }
            return dtResultado;
        }

        private static string fun_texto(object oValor)
        {
            return oValor == DBNull.Value ? "" : oValor.ToString();
        }

        private static object fun_valor_o_nulo(string sValor)
        {
            return string.IsNullOrWhiteSpace(sValor) ? (object)DBNull.Value : sValor;
        }
    }
}
