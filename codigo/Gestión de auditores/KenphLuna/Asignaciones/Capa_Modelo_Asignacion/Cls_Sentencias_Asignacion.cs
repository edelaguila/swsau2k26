using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Modelo_Asignacion
{
    public class Cls_Sentencias_Asignacion
    {
        //Inicio de código de Kenph Luna 9959-22-6326 en la fecha 16/10/2026
        // Sentencias para la tabla transaccional
        public string fun_SentenciaInsertar()
        {
            return "INSERT INTO tbl_asignacion (" +
                   "Fk_Id_Auditor, Fk_Id_Auditado, Fk_Id_Estado_Asignacion, Fk_Id_Actividad_Rubrica, " +
                   "Cmp_Nombre_Asignacion, Cmp_Fecha_Asignacion, Cmp_Fecha_Finalizacion_Asignacion, " +
                   "Cmp_Descripcion_Asignacion, Cmp_Evidencia_Asignacion, Cmp_Observaciones_Asignacion) " +
                   "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?);";
        }

        public string fun_SentenciaModificar()
        {
            return "UPDATE tbl_asignacion SET " +
                   "Fk_Id_Auditor = ?, Fk_Id_Auditado = ?, Fk_Id_Estado_Asignacion = ?, Fk_Id_Actividad_Rubrica = ?, " +
                   "Cmp_Nombre_Asignacion = ?, Cmp_Fecha_Asignacion = ?, Cmp_Fecha_Finalizacion_Asignacion = ?, " +
                   "Cmp_Descripcion_Asignacion = ?, Cmp_Evidencia_Asignacion = ?, Cmp_Observaciones_Asignacion = ? " +
                   "WHERE Pk_Id_Asignacion = ?;";
        }

        public string fun_SentenciaEliminar()
        {
            return "DELETE FROM tbl_asignacion WHERE Pk_Id_Asignacion = ?;";
        }

        public string fun_SentenciaConsultarTodas()
        {
            return "SELECT " +
                   "a.Pk_Id_Asignacion AS 'ID', " +
                   "a.Cmp_Nombre_Asignacion AS 'Asignacion', " +
                   "aud.Cmp_Nombre_Auditor AS 'Auditor', " +
                   "adt.Cmp_Nombre_Auditado AS 'Auditado', " +
                   "est.Cmp_Nombre_Estado_Asignacion AS 'Estado', " +
                   "act.Cmp_Nombre_Actividad_Proyecto AS 'Actividad', " +
                   "a.Cmp_Fecha_Asignacion AS 'Fecha Asignada', " +
                   "a.Cmp_Fecha_Finalizacion_Asignacion AS 'Fecha Limite', " +
                   "a.Cmp_Descripcion_Asignacion AS 'Descripcion', " +
                   "a.Cmp_Evidencia_Asignacion AS 'Evidencia', " +
                   "a.Cmp_Observaciones_Asignacion AS 'Observaciones', " +
                   "a.Fk_Id_Auditor, a.Fk_Id_Auditado, a.Fk_Id_Estado_Asignacion, a.Fk_Id_Actividad_Rubrica " +
                   "FROM tbl_asignacion a " +
                   "INNER JOIN tbl_auditor aud ON a.Fk_Id_Auditor = aud.Pk_Id_Auditor " +
                   "INNER JOIN tbl_auditados adt ON a.Fk_Id_Auditado = adt.Pk_Id_Auditado " +
                   "INNER JOIN tbl_estado_asignacion est ON a.Fk_Id_Estado_Asignacion = est.Pk_Id_Estado_Asignacion " +
                   "INNER JOIN tbl_actividad_rubrica ar ON a.Fk_Id_Actividad_Rubrica = ar.Pk_Id_Actividad_Rubrica " +
                   "INNER JOIN tbl_actividades_proyecto act ON ar.Fk_Id_Actividad_Proyecto = act.Pk_Id_Actividad_Proyecto;";
        }

        // Consultas para llenar los ComboBox de las fk
        public string fun_SentenciaConsultarAuditores()
        {
            return "SELECT Pk_Id_Auditor, Cmp_Nombre_Auditor FROM tbl_auditor WHERE Fk_Id_Estado_Auditor = 1;";
        }

        public string fun_SentenciaConsultarAuditados()
        {
            return "SELECT Pk_Id_Auditado, Cmp_Nombre_Auditado FROM tbl_auditados;";
        }

        public string fun_SentenciaConsultarEstados()
        {
            return "SELECT Pk_Id_Estado_Asignacion, Cmp_Nombre_Estado_Asignacion FROM tbl_estado_asignacion;";
        }

        public string fun_SentenciaConsultarActividadesRubrica()
        {
            return "SELECT ar.Pk_Id_Actividad_Rubrica, CONCAT(act.Cmp_Nombre_Actividad_Proyecto, ' - ', rub.Cmp_Nombre_Rubrica) AS Cmp_Detalle_Actividad " +
                   "FROM tbl_actividad_rubrica ar " +
                   "INNER JOIN tbl_actividades_proyecto act ON ar.Fk_Id_Actividad_Proyecto = act.Pk_Id_Actividad_Proyecto " +
                   "INNER JOIN tbl_rubrica rub ON ar.Fk_Id_Rubrica = rub.Pk_Id_Rubrica " +
                   "WHERE ar.Cmp_Estado_Actividad_Rubrica = 1;";
        }
    }
    //Fin del código de Kenph Luna 9959-22-6326 en la fecha 16/10/2026
}
