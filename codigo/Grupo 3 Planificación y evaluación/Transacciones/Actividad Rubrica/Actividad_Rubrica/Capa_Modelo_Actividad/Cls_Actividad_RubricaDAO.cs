// Codigo empezado por: Maria Morales 0901-22-1226 el día 19/10/2026
using Capa_Modelo_Actividad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Modelo_Actividad_Rubrica
{

    public class Cls_Actividad_RubricaDAO
    {
        private readonly Cls_Conexion_Actividad_Rubrica gConexion = new Cls_Conexion_Actividad_Rubrica();

        // ===================== Consultas =====================
        public List<Cls_Actividad_Rubrica> fun_listar()
        {
            List<Cls_Actividad_Rubrica> lstRegistros = new List<Cls_Actividad_Rubrica>();
            const string sSql = @"SELECT ar.Pk_Id_Actividad_Rubrica, ar.Fk_Id_Actividad_Proyecto, ap.Cmp_Nombre_Actividad_Proyecto,
                                         ar.Fk_Id_Rubrica, r.Cmp_Nombre_Rubrica,
                                         CAST(ar.Cmp_Estado_Actividad_Rubrica AS SIGNED) AS Estado
                                  FROM tbl_actividad_rubrica ar
                                  JOIN tbl_actividades_proyecto ap ON ap.Pk_Id_Actividad_Proyecto = ar.Fk_Id_Actividad_Proyecto
                                  JOIN tbl_rubrica r ON r.Pk_Id_Rubrica = ar.Fk_Id_Rubrica
                                  ORDER BY ar.Pk_Id_Actividad_Rubrica";

            OdbcConnection cnConexion = gConexion.conexion();
            try
            {
                cnConexion.Open();
                using (OdbcCommand cmdConsulta = new OdbcCommand(sSql, cnConexion))
                using (OdbcDataReader drLector = cmdConsulta.ExecuteReader())
                {
                    while (drLector.Read())
                    {
                        lstRegistros.Add(new Cls_Actividad_Rubrica
                        {
                            pIdActividadRubrica = Convert.ToInt32(drLector["Pk_Id_Actividad_Rubrica"]),
                            pIdActividad = Convert.ToInt32(drLector["Fk_Id_Actividad_Proyecto"]),
                            pNombreActividad = fun_texto(drLector["Cmp_Nombre_Actividad_Proyecto"]),
                            pIdRubrica = Convert.ToInt32(drLector["Fk_Id_Rubrica"]),
                            pNombreRubrica = fun_texto(drLector["Cmp_Nombre_Rubrica"]),
                            pEstado = Convert.ToInt32(drLector["Estado"]) == 1
                        });
                    }
                }
            }
            finally
            {
                gConexion.desconexion(cnConexion);
            }
            return lstRegistros;
        }

        // Actividades para el ComboBox (solo lectura). Columnas: Id, Texto, Info
        public DataTable fun_listar_actividades()
        {
            const string sSql = @"SELECT ap.Pk_Id_Actividad_Proyecto AS Id,
                                         CONCAT(ap.Pk_Id_Actividad_Proyecto, ' - ', ap.Cmp_Nombre_Actividad_Proyecto) AS Texto,
                                         CONCAT('Proyecto: ', p.Cmp_Nombre_Proyecto) AS Info
                                  FROM tbl_actividades_proyecto ap
                                  JOIN tbl_proyecto p ON p.Pk_Id_Proyecto = ap.Fk_Id_Proyecto
                                  ORDER BY ap.Pk_Id_Actividad_Proyecto";
            return fun_tabla(sSql);
        }

        // Rúbricas para el ComboBox (solo lectura). Columnas: Id, Texto, Info
        public DataTable fun_listar_rubricas()
        {
            const string sSql = @"SELECT r.Pk_Id_Rubrica AS Id,
                                         CONCAT(r.Pk_Id_Rubrica, ' - ', r.Cmp_Nombre_Rubrica) AS Texto,
                                         CONCAT('Cronograma: ', c.Cmp_Nombre_Tarea_Cronograma) AS Info
                                  FROM tbl_rubrica r
                                  JOIN tbl_cronograma c ON c.Pk_Id_Cronograma = r.Fk_Id_Cronograma
                                  ORDER BY r.Pk_Id_Rubrica";
            return fun_tabla(sSql);
        }

        // Llave única (Fk_Id_Actividad_Proyecto, Fk_Id_Rubrica): se valida antes de guardar
        public bool fun_existe_combinacion(int iIdActividad, int iIdRubrica, int iIdExcluido)
        {
            const string sSql = @"SELECT COUNT(*) FROM tbl_actividad_rubrica
                                  WHERE Fk_Id_Actividad_Proyecto = ? AND Fk_Id_Rubrica = ? AND Pk_Id_Actividad_Rubrica <> ?";
            return Convert.ToInt32(fun_escalar(sSql, iIdActividad, iIdRubrica, iIdExcluido)) > 0;
        }

        // ===================== Operaciones =====================
        public void pro_insertar(Cls_Actividad_Rubrica oRegistro)
        {
            // En ODBC los parámetros son posicionales (?): el orden importa
            const string sSql = @"INSERT INTO tbl_actividad_rubrica
                (Fk_Id_Actividad_Proyecto, Fk_Id_Rubrica, Cmp_Estado_Actividad_Rubrica)
                VALUES (?, ?, ?)";
            pro_ejecutar(sSql, oRegistro, false);
        }

        public void pro_actualizar(Cls_Actividad_Rubrica oRegistro)
        {
            const string sSql = @"UPDATE tbl_actividad_rubrica SET
                Fk_Id_Actividad_Proyecto = ?, Fk_Id_Rubrica = ?, Cmp_Estado_Actividad_Rubrica = ?
                WHERE Pk_Id_Actividad_Rubrica = ?";
            pro_ejecutar(sSql, oRegistro, true);
        }

        public void pro_eliminar(int iIdActividadRubrica)
        {
            OdbcConnection cnConexion = gConexion.conexion();
            try
            {
                cnConexion.Open();
                using (OdbcCommand cmdComando = new OdbcCommand(
                    "DELETE FROM tbl_actividad_rubrica WHERE Pk_Id_Actividad_Rubrica = ?", cnConexion))
                {
                    cmdComando.Parameters.AddWithValue("@id", iIdActividadRubrica);
                    cmdComando.ExecuteNonQuery();
                }
            }
            finally
            {
                gConexion.desconexion(cnConexion);
            }
        }

        // ===================== Auxiliares =====================
        private void pro_ejecutar(string sSql, Cls_Actividad_Rubrica oRegistro, bool bIncluirId)
        {
            OdbcConnection cnConexion = gConexion.conexion();
            try
            {
                cnConexion.Open();
                using (OdbcCommand cmdComando = new OdbcCommand(sSql, cnConexion))
                {
                    cmdComando.Parameters.AddWithValue("@actividad", oRegistro.pIdActividad);
                    cmdComando.Parameters.AddWithValue("@rubrica", oRegistro.pIdRubrica);
                    cmdComando.Parameters.AddWithValue("@estado", oRegistro.pEstado ? 1 : 0);
                    if (bIncluirId) cmdComando.Parameters.AddWithValue("@id", oRegistro.pIdActividadRubrica);
                    cmdComando.ExecuteNonQuery();
                }
            }
            finally
            {
                gConexion.desconexion(cnConexion);
            }
        }

        private DataTable fun_tabla(string sSql)
        {
            DataTable dtResultado = new DataTable();
            OdbcConnection cnConexion = gConexion.conexion();
            try
            {
                cnConexion.Open();
                using (OdbcDataAdapter daAdaptador = new OdbcDataAdapter(sSql, cnConexion))
                {
                    daAdaptador.Fill(dtResultado);
                }
            }
            finally
            {
                gConexion.desconexion(cnConexion);
            }
            return dtResultado;
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
    }
}
// Codigo terminado por: Maria Morales 0901-22-1226 el día 19/10/2026