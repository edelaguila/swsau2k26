// Juan Carlos Sandoval Quej, carné: 0901-22-4170 fecha de: "21/10/2026"
using System;
using System.Data;
using System.Data.Odbc;

namespace Capa_Modelo_Ponderacion
{
    // Aquí va el acceso a datos de tbl_tabla_ponderacion y el CRUD
    public class Cls_PonderacionDAO
    {
        private readonly Cls_Conexion_Ponderacion gCn = new Cls_Conexion_Ponderacion();

        public bool fun_insertar(Cls_Ponderacion oPonderacion)
        {
            string sSql = "INSERT INTO tbl_tabla_ponderacion " +
                          "(Fk_Id_Auditado, Fk_Id_Cronograma, Fk_Id_Rubrica, Fk_Id_Criterio, Fk_Id_Escala, " +
                          "Cmp_Calificacion_Porcentaje_Ponderacion, Cmp_Calificacion_Ponderada_Ponderacion, " +
                          "Cmp_Comentarios_Auditor_Ponderacion) " +
                          "VALUES (?, ?, ?, ?, ?, ?, ?, ?)";

            OdbcConnection conn = gCn.fun_conexion();
            try
            {
                conn.Open();
                using (OdbcCommand cmd = new OdbcCommand(sSql, conn))
                {
                    pro_cargar_parametros(cmd, oPonderacion);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (OdbcException ex)
            {
                throw fun_traducir_error(ex);
            }
            finally
            {
                gCn.pro_desconexion(conn);
            }
        }

        // Apartado para modifica una ponderación existente
        public bool fun_modificar(Cls_Ponderacion oPonderacion)
        {
            string sSql = "UPDATE tbl_tabla_ponderacion SET " +
                          "Fk_Id_Auditado = ?, Fk_Id_Cronograma = ?, Fk_Id_Rubrica = ?, " +
                          "Fk_Id_Criterio = ?, Fk_Id_Escala = ?, " +
                          "Cmp_Calificacion_Porcentaje_Ponderacion = ?, " +
                          "Cmp_Calificacion_Ponderada_Ponderacion = ?, " +
                          "Cmp_Comentarios_Auditor_Ponderacion = ? " +
                          "WHERE Pk_Id_Ponderacion = ?";

            OdbcConnection conn = gCn.fun_conexion();
            try
            {
                conn.Open();
                using (OdbcCommand cmd = new OdbcCommand(sSql, conn))
                {
                    pro_cargar_parametros(cmd, oPonderacion);
                    cmd.Parameters.AddWithValue("@id", oPonderacion.pPkIdPonderacion);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (OdbcException ex)
            {
                throw fun_traducir_error(ex);
            }
            finally
            {
                gCn.pro_desconexion(conn);
            }
        }

        // Función, elimina una ponderación por su llave primaria.
        public bool fun_eliminar(int iIdPonderacion)
        {
            string sSql = "DELETE FROM tbl_tabla_ponderacion WHERE Pk_Id_Ponderacion = ?";

            OdbcConnection conn = gCn.fun_conexion();
            try
            {
                conn.Open();
                using (OdbcCommand cmd = new OdbcCommand(sSql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", iIdPonderacion);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (OdbcException ex)
            {
                throw fun_traducir_error(ex);
            }
            finally
            {
                gCn.pro_desconexion(conn);
            }
        }

        // Aquí se consulta todas las ponderaciones (con los nombres de auditado, criterio y escala).
        public DataTable fun_consultar_todos()
        {
            return fun_consultar(null);
        }

        // consultar una sola ponderación por su llave primaria.
        public DataTable fun_consultar_por_id(int iIdPonderacion)
        {
            return fun_consultar(iIdPonderacion);
        }

        private DataTable fun_consultar(int? iIdPonderacion)
        {
            DataTable dtTabla = new DataTable();
            string sSql = "SELECT p.Pk_Id_Ponderacion AS Id, " +
                          "p.Fk_Id_Auditado AS IdAuditado, " +
                          "p.Fk_Id_Cronograma AS IdCronograma, " +
                          "p.Fk_Id_Rubrica AS IdRubrica, " +
                          "p.Fk_Id_Criterio AS IdCriterio, " +
                          "p.Fk_Id_Escala AS IdEscala, " +
                          "a.Cmp_Nombre_Auditado AS Auditado, " +
                          "c.Cmp_Nombre_Criterio AS Criterio, " +
                          "e.Cmp_Nombre_Nivel_Escala AS Escala, " +
                          "p.Cmp_Calificacion_Porcentaje_Ponderacion AS Porcentaje, " +
                          "p.Cmp_Calificacion_Ponderada_Ponderacion AS Ponderada, " +
                          "p.Cmp_Comentarios_Auditor_Ponderacion AS Comentarios, " +
                          "p.Cmp_Fecha_Evaluacion_Ponderacion AS Fecha " +
                          "FROM tbl_tabla_ponderacion p " +
                          "INNER JOIN tbl_auditados a ON a.Pk_Id_Auditado = p.Fk_Id_Auditado " +
                          "INNER JOIN tbl_criterios c ON c.Pk_Id_Criterio = p.Fk_Id_Criterio " +
                          "INNER JOIN tbl_escala_descripcion e ON e.Pk_Id_Escala = p.Fk_Id_Escala ";
            if (iIdPonderacion.HasValue) sSql += "WHERE p.Pk_Id_Ponderacion = ? ";
            sSql += "ORDER BY p.Pk_Id_Ponderacion";

            OdbcConnection conn = gCn.fun_conexion();
            try
            {
                conn.Open();
                using (OdbcCommand cmd = new OdbcCommand(sSql, conn))
                {
                    if (iIdPonderacion.HasValue) cmd.Parameters.AddWithValue("@id", iIdPonderacion.Value);
                    using (OdbcDataReader dr = cmd.ExecuteReader())
                    {
                        dtTabla.Load(dr);
                    }
                }
            }
            finally
            {
                gCn.pro_desconexion(conn);
            }
            return dtTabla;
        }


        public DataTable fun_combo_auditados()
        {
            return fun_combo("SELECT Pk_Id_Auditado AS Id, " +
                             "CONCAT(Pk_Id_Auditado, ' - ', Cmp_Nombre_Auditado) AS Texto " +
                             "FROM tbl_auditados ORDER BY Pk_Id_Auditado");
        }

        public DataTable fun_combo_cronogramas()
        {
            return fun_combo("SELECT Pk_Id_Cronograma AS Id, " +
                             "CONCAT(Pk_Id_Cronograma, ' - ', Cmp_Nombre_Tarea_Cronograma) AS Texto " +
                             "FROM tbl_cronograma ORDER BY Pk_Id_Cronograma");
        }

        public DataTable fun_combo_rubricas()
        {
            return fun_combo("SELECT Pk_Id_Rubrica AS Id, " +
                             "CONCAT(Pk_Id_Rubrica, ' - ', Cmp_Nombre_Rubrica) AS Texto " +
                             "FROM tbl_rubrica ORDER BY Pk_Id_Rubrica");
        }

        public DataTable fun_combo_criterios()
        {
            return fun_combo("SELECT Pk_Id_Criterio AS Id, " +
                             "CONCAT(Pk_Id_Criterio, ' - ', Cmp_Nombre_Criterio) AS Texto " +
                             "FROM tbl_criterios ORDER BY Pk_Id_Criterio");
        }

        public DataTable fun_combo_escalas()
        {
            return fun_combo("SELECT Pk_Id_Escala AS Id, " +
                             "CONCAT(Cmp_Porcentaje_Escala, '% - ', Cmp_Nombre_Nivel_Escala) AS Texto " +
                             "FROM tbl_escala_descripcion ORDER BY Cmp_Porcentaje_Escala");
        }

        private DataTable fun_combo(string sSql)
        {
            DataTable dtTabla = new DataTable();
            OdbcConnection conn = gCn.fun_conexion();
            try
            {
                conn.Open();
                using (OdbcCommand cmd = new OdbcCommand(sSql, conn))
                using (OdbcDataReader dr = cmd.ExecuteReader())
                {
                    dtTabla.Load(dr);
                }
            }
            finally
            {
                gCn.pro_desconexion(conn);
            }
            return dtTabla;
        }


        // Se carga los 8 parámetros en el mismo orden que usan los insert y update.
        private void pro_cargar_parametros(OdbcCommand cmd, Cls_Ponderacion oPonderacion)
        {
            cmd.Parameters.AddWithValue("@auditado", oPonderacion.pFkIdAuditado);
            cmd.Parameters.AddWithValue("@cronograma", oPonderacion.pFkIdCronograma);
            cmd.Parameters.AddWithValue("@rubrica", oPonderacion.pFkIdRubrica);
            cmd.Parameters.AddWithValue("@criterio", oPonderacion.pFkIdCriterio);
            cmd.Parameters.AddWithValue("@escala", oPonderacion.pFkIdEscala);
            cmd.Parameters.AddWithValue("@porcentaje", (double)oPonderacion.pCalificacionPorcentaje);
            cmd.Parameters.AddWithValue("@ponderada", (double)oPonderacion.pCalificacionPonderada);
            cmd.Parameters.AddWithValue("@comentarios",
                string.IsNullOrWhiteSpace(oPonderacion.pComentariosAuditor)
                    ? (object)DBNull.Value
                    : oPonderacion.pComentariosAuditor);
        }

        // está funcion convierte los errores de MySQL en mensajes entendibles para el usuario.
        private Exception fun_traducir_error(OdbcException ex)
        {
            string sMensaje = ex.Message ?? "";

            if (sMensaje.IndexOf("Duplicate entry", StringComparison.OrdinalIgnoreCase) >= 0 ||
                sMensaje.IndexOf("UNIQUE constraint", StringComparison.OrdinalIgnoreCase) >= 0 ||
                sMensaje.IndexOf("Uq_Ponderacion_Auditado_Criterio", StringComparison.OrdinalIgnoreCase) >= 0)
                return new Exception("Ya existe una ponderación para ese Auditado y ese Criterio.");

            if (sMensaje.IndexOf("check constraint", StringComparison.OrdinalIgnoreCase) >= 0 ||
                sMensaje.IndexOf("Chk_Ponderacion", StringComparison.OrdinalIgnoreCase) >= 0)
                return new Exception("Las calificaciones deben estar entre 0 y 100.");

            if (sMensaje.IndexOf("foreign key", StringComparison.OrdinalIgnoreCase) >= 0)
                return new Exception("Alguno de los datos seleccionados ya no existe en la base de datos.");

            return new Exception("Error de base de datos: " + sMensaje);
        }
    }
}
