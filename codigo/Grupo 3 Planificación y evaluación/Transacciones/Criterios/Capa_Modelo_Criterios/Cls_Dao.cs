//Inicio de código de "Nombre del programador" con carné: "No_carné" en la fecha de: "11/11/2026"
using Capa_Modelo_Seguridad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;

namespace Capa_Modelo_Criterios
{
    // Acceso a datos de tbl_criterios. Usa la conexión ODBC compartida (Cls_Conexion, DSN bd_auditoria).
    public class Cls_Dao
    {
        // AbrirConexion() lanza la excepción si no conecta, así el error llega al usuario.
        private OdbcConnection fun_obtener_conexion()
        {
            return new Cls_Conexion().AbrirConexion();
        }

        public List<Cls_Criterio> fun_listar()
        {
            List<Cls_Criterio> lstCriterios = new List<Cls_Criterio>();
            const string sSql = @"SELECT c.Pk_Id_Criterio, c.Fk_Id_Rubrica, r.Cmp_Nombre_Rubrica,
                                         c.Cmp_Nombre_Criterio, c.Cmp_Porcentaje_Criterio,
                                         c.Cmp_Descripcion_Criterio, c.Cmp_Nivel_Importancia_Criterio
                                  FROM tbl_criterios c
                                  JOIN tbl_rubrica r ON r.Pk_Id_Rubrica = c.Fk_Id_Rubrica
                                  ORDER BY r.Cmp_Nombre_Rubrica, c.Cmp_Nombre_Criterio";

            using (OdbcConnection cnConexion = fun_obtener_conexion())
            using (OdbcCommand cmdConsulta = new OdbcCommand(sSql, cnConexion))
            using (OdbcDataReader drLector = cmdConsulta.ExecuteReader())
            {
                while (drLector.Read())
                {
                    lstCriterios.Add(new Cls_Criterio
                    {
                        pIdCriterio = Convert.ToInt32(drLector["Pk_Id_Criterio"]),
                        pIdRubrica = Convert.ToInt32(drLector["Fk_Id_Rubrica"]),
                        pNombreRubrica = fun_texto(drLector["Cmp_Nombre_Rubrica"]),
                        pNombre = fun_texto(drLector["Cmp_Nombre_Criterio"]),
                        pPorcentaje = drLector["Cmp_Porcentaje_Criterio"] == DBNull.Value
                            ? (int?)null : Convert.ToInt32(drLector["Cmp_Porcentaje_Criterio"]),
                        pDescripcion = fun_texto(drLector["Cmp_Descripcion_Criterio"]),
                        pNivelImportancia = fun_texto(drLector["Cmp_Nivel_Importancia_Criterio"])
                    });
                }
            }
            return lstCriterios;
        }

        public DataTable fun_listar_rubricas()
        {
            DataTable dtRubricas = new DataTable();
            const string sSql = "SELECT Pk_Id_Rubrica, Cmp_Nombre_Rubrica FROM tbl_rubrica ORDER BY Cmp_Nombre_Rubrica";
            using (OdbcConnection cnConexion = fun_obtener_conexion())
            using (OdbcDataAdapter daAdaptador = new OdbcDataAdapter(sSql, cnConexion))
            {
                daAdaptador.Fill(dtRubricas);
            }
            return dtRubricas;
        }

        // Suma de porcentajes de una rúbrica sin contar el criterio que se edita.
        // Se valida aquí porque el script de BD actual (V2.3) no incluye los triggers.
        public int fun_suma_porcentajes(int iIdRubrica, int iIdExcluido)
        {
            const string sSql = @"SELECT COALESCE(SUM(Cmp_Porcentaje_Criterio), 0) FROM tbl_criterios
                                  WHERE Fk_Id_Rubrica = ? AND Pk_Id_Criterio <> ?";
            return Convert.ToInt32(fun_escalar(sSql, iIdRubrica, iIdExcluido));
        }

        public bool fun_existe_porcentaje(int iIdRubrica, int iPorcentaje, int iIdExcluido)
        {
            const string sSql = @"SELECT COUNT(*) FROM tbl_criterios
                                  WHERE Fk_Id_Rubrica = ? AND Cmp_Porcentaje_Criterio = ? AND Pk_Id_Criterio <> ?";
            return Convert.ToInt32(fun_escalar(sSql, iIdRubrica, iPorcentaje, iIdExcluido)) > 0;
        }

        public bool fun_existe_nombre(int iIdRubrica, string sNombre, int iIdExcluido)
        {
            const string sSql = @"SELECT COUNT(*) FROM tbl_criterios
                                  WHERE Fk_Id_Rubrica = ? AND Cmp_Nombre_Criterio = ? AND Pk_Id_Criterio <> ?";
            return Convert.ToInt32(fun_escalar(sSql, iIdRubrica, sNombre, iIdExcluido)) > 0;
        }

        public void pro_insertar(Cls_Criterio oCriterio)
        {
            // En ODBC los parámetros son posicionales (?): el orden importa
            const string sSql = @"INSERT INTO tbl_criterios
                (Fk_Id_Rubrica, Cmp_Nombre_Criterio, Cmp_Porcentaje_Criterio,
                 Cmp_Descripcion_Criterio, Cmp_Nivel_Importancia_Criterio)
                VALUES (?, ?, ?, ?, ?)";
            pro_ejecutar(sSql, oCriterio, false);
        }

        public void pro_actualizar(Cls_Criterio oCriterio)
        {
            const string sSql = @"UPDATE tbl_criterios SET
                Fk_Id_Rubrica = ?, Cmp_Nombre_Criterio = ?,
                Cmp_Porcentaje_Criterio = ?, Cmp_Descripcion_Criterio = ?,
                Cmp_Nivel_Importancia_Criterio = ?
                WHERE Pk_Id_Criterio = ?";
            pro_ejecutar(sSql, oCriterio, true);
        }

        public void pro_eliminar(int iIdCriterio)
        {
            using (OdbcConnection cnConexion = fun_obtener_conexion())
            using (OdbcCommand cmdComando = new OdbcCommand("DELETE FROM tbl_criterios WHERE Pk_Id_Criterio = ?", cnConexion))
            {
                cmdComando.Parameters.AddWithValue("@id", iIdCriterio);
                cmdComando.ExecuteNonQuery();
            }
        }

        private void pro_ejecutar(string sSql, Cls_Criterio oCriterio, bool bIncluirId)
        {
            using (OdbcConnection cnConexion = fun_obtener_conexion())
            using (OdbcCommand cmdComando = new OdbcCommand(sSql, cnConexion))
            {
                cmdComando.Parameters.AddWithValue("@rubrica", oCriterio.pIdRubrica);
                cmdComando.Parameters.AddWithValue("@nombre", oCriterio.pNombre);
                cmdComando.Parameters.AddWithValue("@porcentaje", (object)oCriterio.pPorcentaje ?? DBNull.Value);
                cmdComando.Parameters.AddWithValue("@descripcion", fun_valor_o_nulo(oCriterio.pDescripcion));
                cmdComando.Parameters.AddWithValue("@importancia", fun_valor_o_nulo(oCriterio.pNivelImportancia));
                if (bIncluirId) cmdComando.Parameters.AddWithValue("@id", oCriterio.pIdCriterio);
                cmdComando.ExecuteNonQuery();
            }
        }

        private object fun_escalar(string sSql, params object[] arrParametros)
        {
            using (OdbcConnection cnConexion = fun_obtener_conexion())
            using (OdbcCommand cmdConsulta = new OdbcCommand(sSql, cnConexion))
            {
                for (int iIndice = 0; iIndice < arrParametros.Length; iIndice++)
                    cmdConsulta.Parameters.AddWithValue("@p" + iIndice, arrParametros[iIndice]);
                object oResultado = cmdConsulta.ExecuteScalar();
                return oResultado == null || oResultado == DBNull.Value ? 0 : oResultado;
            }
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
//Fin del código de "Nombre del programador" con carné: "No_carné" en la fecha de: "11/11/2026"
