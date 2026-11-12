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
    // Acceso a datos de tbl_rubrica. Usa la conexión ODBC propia del módulo (DSN bd_auditoria).
    // Las excepciones OdbcException se dejan subir para que el Controlador las traduzca.
    public class Cls_RubricaDAO
    {
        private readonly Cls_Conexion_Rubrica gConexion = new Cls_Conexion_Rubrica();

        // ===================== Consultas =====================
        public List<Cls_Rubrica> fun_listar()
        {
            List<Cls_Rubrica> lstRubricas = new List<Cls_Rubrica>();
            const string sSql = @"SELECT r.Pk_Id_Rubrica, r.Fk_Id_Cronograma, c.Cmp_Nombre_Tarea_Cronograma,
                                         r.Cmp_Nombre_Rubrica, r.Cmp_Descripcion_Rubrica, r.Cmp_Objetivo_Rubrica
                                  FROM tbl_rubrica r
                                  JOIN tbl_cronograma c ON c.Pk_Id_Cronograma = r.Fk_Id_Cronograma
                                  ORDER BY r.Pk_Id_Rubrica";

            OdbcConnection cnConexion = gConexion.conexion();
            try
            {
                cnConexion.Open();
                using (OdbcCommand cmdConsulta = new OdbcCommand(sSql, cnConexion))
                using (OdbcDataReader drLector = cmdConsulta.ExecuteReader())
                {
                    while (drLector.Read())
                    {
                        lstRubricas.Add(new Cls_Rubrica
                        {
                            pIdRubrica = Convert.ToInt32(drLector["Pk_Id_Rubrica"]),
                            pIdCronograma = Convert.ToInt32(drLector["Fk_Id_Cronograma"]),
                            pNombreCronograma = fun_texto(drLector["Cmp_Nombre_Tarea_Cronograma"]),
                            pNombre = fun_texto(drLector["Cmp_Nombre_Rubrica"]),
                            pDescripcion = fun_texto(drLector["Cmp_Descripcion_Rubrica"]),
                            pObjetivo = fun_texto(drLector["Cmp_Objetivo_Rubrica"])
                        });
                    }
                }
            }
            finally
            {
                gConexion.desconexion(cnConexion);
            }
            return lstRubricas;
        }

        // Cronogramas para el ComboBox (solo lectura). Columnas: Id, Texto, Info
        public DataTable fun_listar_cronogramas()
        {
            DataTable dtCronogramas = new DataTable();
            const string sSql = @"SELECT Pk_Id_Cronograma AS Id,
                                         CONCAT(Pk_Id_Cronograma, ' - ', Cmp_Nombre_Tarea_Cronograma) AS Texto,
                                         CONCAT('Del ', DATE_FORMAT(Cmp_Fecha_Inicio_Cronograma, '%d/%m/%Y'),
                                                ' al ', DATE_FORMAT(Cmp_Fecha_Fin_Cronograma, '%d/%m/%Y'),
                                                '  |  Estado: ', IFNULL(Cmp_Estado_Tarea_Cronograma, 'Sin estado')) AS Info
                                  FROM tbl_cronograma
                                  ORDER BY Pk_Id_Cronograma";

            OdbcConnection cnConexion = gConexion.conexion();
            try
            {
                cnConexion.Open();
                using (OdbcDataAdapter daAdaptador = new OdbcDataAdapter(sSql, cnConexion))
                {
                    daAdaptador.Fill(dtCronogramas);
                }
            }
            finally
            {
                gConexion.desconexion(cnConexion);
            }
            return dtCronogramas;
        }

        // Evita dos rúbricas con el mismo nombre dentro del mismo cronograma
        public bool fun_existe_nombre(int iIdCronograma, string sNombre, int iIdExcluido)
        {
            const string sSql = @"SELECT COUNT(*) FROM tbl_rubrica
                                  WHERE Fk_Id_Cronograma = ? AND Cmp_Nombre_Rubrica = ? AND Pk_Id_Rubrica <> ?";
            return Convert.ToInt32(fun_escalar(sSql, iIdCronograma, sNombre, iIdExcluido)) > 0;
        }

        // ===================== Operaciones =====================
        public void pro_insertar(Cls_Rubrica oRubrica)
        {
            // En ODBC los parámetros son posicionales (?): el orden importa
            const string sSql = @"INSERT INTO tbl_rubrica
                (Fk_Id_Cronograma, Cmp_Nombre_Rubrica, Cmp_Descripcion_Rubrica, Cmp_Objetivo_Rubrica)
                VALUES (?, ?, ?, ?)";
            pro_ejecutar(sSql, oRubrica, false);
        }

        public void pro_actualizar(Cls_Rubrica oRubrica)
        {
            const string sSql = @"UPDATE tbl_rubrica SET
                Fk_Id_Cronograma = ?, Cmp_Nombre_Rubrica = ?,
                Cmp_Descripcion_Rubrica = ?, Cmp_Objetivo_Rubrica = ?
                WHERE Pk_Id_Rubrica = ?";
            pro_ejecutar(sSql, oRubrica, true);
        }

        public void pro_eliminar(int iIdRubrica)
        {
            OdbcConnection cnConexion = gConexion.conexion();
            try
            {
                cnConexion.Open();
                using (OdbcCommand cmdComando = new OdbcCommand("DELETE FROM tbl_rubrica WHERE Pk_Id_Rubrica = ?", cnConexion))
                {
                    cmdComando.Parameters.AddWithValue("@id", iIdRubrica);
                    cmdComando.ExecuteNonQuery();
                }
            }
            finally
            {
                gConexion.desconexion(cnConexion);
            }
        }

        // ===================== Auxiliares =====================
        private void pro_ejecutar(string sSql, Cls_Rubrica oRubrica, bool bIncluirId)
        {
            OdbcConnection cnConexion = gConexion.conexion();
            try
            {
                cnConexion.Open();
                using (OdbcCommand cmdComando = new OdbcCommand(sSql, cnConexion))
                {
                    cmdComando.Parameters.AddWithValue("@cronograma", oRubrica.pIdCronograma);
                    cmdComando.Parameters.AddWithValue("@nombre", oRubrica.pNombre);
                    cmdComando.Parameters.AddWithValue("@descripcion", fun_valor_o_nulo(oRubrica.pDescripcion));
                    cmdComando.Parameters.AddWithValue("@objetivo", fun_valor_o_nulo(oRubrica.pObjetivo));
                    if (bIncluirId) cmdComando.Parameters.AddWithValue("@id", oRubrica.pIdRubrica);
                    cmdComando.ExecuteNonQuery();
                }
            }
            finally
            {
                gConexion.desconexion(cnConexion);
            }
        }

        private object fun_escalar(string sSql, params object[] arrParametros)
        {
            OdbcConnection cnConexion = gConexion.conexion();
            try
            {
                cnConexion.Open();
                using (OdbcCommand cmdConsulta = new OdbcCommand(sSql, cnConexion))
                {
                    for (int iIndice = 0; iIndice < arrParametros.Length; iIndice++)
                        cmdConsulta.Parameters.AddWithValue("@p" + iIndice, arrParametros[iIndice]);
                    object oResultado = cmdConsulta.ExecuteScalar();
                    return oResultado == null || oResultado == DBNull.Value ? 0 : oResultado;
                }
            }
            finally
            {
                gConexion.desconexion(cnConexion);
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

// Termina codigo hecho por Maria Morales 0901-22-1226 el dia 07/10/2026