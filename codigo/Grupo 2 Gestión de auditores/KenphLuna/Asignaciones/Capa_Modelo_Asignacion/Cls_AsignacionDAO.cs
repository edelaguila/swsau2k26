using Capa_Modelo_Seguridad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Modelo_Asignacion
{
    public class Cls_AsignacionDAO
    {
        //Inicio de código de Kenph Luna 9959-22-6326 en la fecha 16/10/2026
        private readonly Cls_Conexion gConexion = new Cls_Conexion();
        private readonly Cls_Sentencias_Asignacion gSentencias = new Cls_Sentencias_Asignacion();

        public bool fun_InsertarAsignacion(Cls_AsignacionDTO dtoAsignacion, ref string sError)
        {
            bool bResultado = false;
            using (OdbcConnection conn = gConexion.AbrirConexion())
            {
                using (OdbcTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        using (OdbcCommand cmd = new OdbcCommand(gSentencias.fun_SentenciaInsertar(), conn, trans))
                        {
                            cmd.Parameters.Add("Fk_Id_Auditor", OdbcType.Int).Value = dtoAsignacion.iFk_Id_Auditor;
                            cmd.Parameters.Add("Fk_Id_Auditado", OdbcType.Int).Value = dtoAsignacion.iFk_Id_Auditado;
                            cmd.Parameters.Add("Fk_Id_Estado_Asignacion", OdbcType.Int).Value = dtoAsignacion.iFk_Id_Estado_Asignacion;
                            cmd.Parameters.Add("Fk_Id_Actividad_Rubrica", OdbcType.Int).Value = dtoAsignacion.iFk_Id_Actividad_Rubrica;
                            cmd.Parameters.Add("Cmp_Nombre_Asignacion", OdbcType.VarChar, 100).Value = dtoAsignacion.sNombre_Asignacion;
                            cmd.Parameters.Add("Cmp_Fecha_Asignacion", OdbcType.Date).Value = dtoAsignacion.dFecha_Asignacion;
                            cmd.Parameters.Add("Cmp_Fecha_Finalizacion_Asignacion", OdbcType.Date).Value =
                                dtoAsignacion.dFecha_Finalizacion_Asignacion.HasValue
                                ? (object)dtoAsignacion.dFecha_Finalizacion_Asignacion.Value
                                : DBNull.Value;
                            cmd.Parameters.Add("Cmp_Descripcion_Asignacion", OdbcType.Text).Value = (object)dtoAsignacion.sDescripcion_Asignacion ?? DBNull.Value;
                            cmd.Parameters.Add("Cmp_Evidencia_Asignacion", OdbcType.VarChar, 255).Value = (object)dtoAsignacion.sEvidencia_Asignacion ?? DBNull.Value;
                            cmd.Parameters.Add("Cmp_Observaciones_Asignacion", OdbcType.Text).Value = (object)dtoAsignacion.sObservaciones_Asignacion ?? DBNull.Value;

                            cmd.ExecuteNonQuery();
                        }

                        trans.Commit();
                        bResultado = true;
                    }
                    catch (OdbcException ex)
                    {
                        trans.Rollback();
                        sError = "Error ODBC al insertar asignación: " + ex.Message;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        sError = "Error general al insertar asignación: " + ex.Message;
                    }
                }
            }
            return bResultado;
        }

        public bool fun_ModificarAsignacion(Cls_AsignacionDTO dtoAsignacion, ref string sError)
        {
            bool bResultado = false;
            using (OdbcConnection conn = gConexion.AbrirConexion())
            {
                using (OdbcTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        using (OdbcCommand cmd = new OdbcCommand(gSentencias.fun_SentenciaModificar(), conn, trans))
                        {
                            cmd.Parameters.Add("Fk_Id_Auditor", OdbcType.Int).Value = dtoAsignacion.iFk_Id_Auditor;
                            cmd.Parameters.Add("Fk_Id_Auditado", OdbcType.Int).Value = dtoAsignacion.iFk_Id_Auditado;
                            cmd.Parameters.Add("Fk_Id_Estado_Asignacion", OdbcType.Int).Value = dtoAsignacion.iFk_Id_Estado_Asignacion;
                            cmd.Parameters.Add("Fk_Id_Actividad_Rubrica", OdbcType.Int).Value = dtoAsignacion.iFk_Id_Actividad_Rubrica;
                            cmd.Parameters.Add("Cmp_Nombre_Asignacion", OdbcType.VarChar, 100).Value = dtoAsignacion.sNombre_Asignacion;
                            cmd.Parameters.Add("Cmp_Fecha_Asignacion", OdbcType.Date).Value = dtoAsignacion.dFecha_Asignacion;
                            cmd.Parameters.Add("Cmp_Fecha_Finalizacion_Asignacion", OdbcType.Date).Value =
                                dtoAsignacion.dFecha_Finalizacion_Asignacion.HasValue
                                ? (object)dtoAsignacion.dFecha_Finalizacion_Asignacion.Value
                                : DBNull.Value;
                            cmd.Parameters.Add("Cmp_Descripcion_Asignacion", OdbcType.Text).Value = (object)dtoAsignacion.sDescripcion_Asignacion ?? DBNull.Value;
                            cmd.Parameters.Add("Cmp_Evidencia_Asignacion", OdbcType.VarChar, 255).Value = (object)dtoAsignacion.sEvidencia_Asignacion ?? DBNull.Value;
                            cmd.Parameters.Add("Cmp_Observaciones_Asignacion", OdbcType.Text).Value = (object)dtoAsignacion.sObservaciones_Asignacion ?? DBNull.Value;
                            cmd.Parameters.Add("Pk_Id_Asignacion", OdbcType.Int).Value = dtoAsignacion.iPk_Id_Asignacion;

                            cmd.ExecuteNonQuery();
                        }

                        trans.Commit();
                        bResultado = true;
                    }
                    catch (OdbcException ex)
                    {
                        trans.Rollback();
                        sError = "Error ODBC al actualizar asignación: " + ex.Message;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        sError = "Error general al actualizar asignación: " + ex.Message;
                    }
                }
            }
            return bResultado;
        }

        public bool fun_EliminarAsignacion(int iIdAsignacion, ref string sError)
        {
            bool bResultado = false;
            using (OdbcConnection conn = gConexion.AbrirConexion())
            {
                using (OdbcTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        using (OdbcCommand cmd = new OdbcCommand(gSentencias.fun_SentenciaEliminar(), conn, trans))
                        {
                            cmd.Parameters.Add("Pk_Id_Asignacion", OdbcType.Int).Value = iIdAsignacion;
                            cmd.ExecuteNonQuery();
                        }

                        trans.Commit();
                        bResultado = true;
                    }
                    catch (OdbcException ex)
                    {
                        trans.Rollback();
                        sError = "Error ODBC al eliminar asignación: " + ex.Message;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        sError = "Error general al eliminar asignación: " + ex.Message;
                    }
                }
            }
            return bResultado;
        }

        public DataTable fun_ConsultarAsignaciones()
        {
            DataTable dt = new DataTable();
            using (OdbcConnection conn = gConexion.AbrirConexion())
            {
                using (OdbcDataAdapter da = new OdbcDataAdapter(gSentencias.fun_SentenciaConsultarTodas(), conn))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public DataTable fun_ObtenerCatalogoAuditores()
        {
            DataTable dt = new DataTable();
            using (OdbcConnection conn = gConexion.AbrirConexion())
            {
                using (OdbcDataAdapter da = new OdbcDataAdapter(gSentencias.fun_SentenciaConsultarAuditores(), conn))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public DataTable fun_ObtenerCatalogoAuditados()
        {
            DataTable dt = new DataTable();
            using (OdbcConnection conn = gConexion.AbrirConexion())
            {
                using (OdbcDataAdapter da = new OdbcDataAdapter(gSentencias.fun_SentenciaConsultarAuditados(), conn))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public DataTable fun_ObtenerCatalogoEstados()
        {
            DataTable dt = new DataTable();
            using (OdbcConnection conn = gConexion.AbrirConexion())
            {
                using (OdbcDataAdapter da = new OdbcDataAdapter(gSentencias.fun_SentenciaConsultarEstados(), conn))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public DataTable fun_ObtenerCatalogoActividadesRubrica()
        {
            DataTable dt = new DataTable();
            using (OdbcConnection conn = gConexion.AbrirConexion())
            {
                using (OdbcDataAdapter da = new OdbcDataAdapter(gSentencias.fun_SentenciaConsultarActividadesRubrica(), conn))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }
        //Fin del código de Kenph Luna 9959-22-6326 en la fecha 16/10/2026
    }
}
