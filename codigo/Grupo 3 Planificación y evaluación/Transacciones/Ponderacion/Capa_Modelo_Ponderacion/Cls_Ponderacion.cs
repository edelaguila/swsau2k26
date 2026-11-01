// Juan Carlos Sandoval Quej, carné: 0901-22-4170 fecha de: "21/10/2026"
using System;

namespace Capa_Modelo_Ponderacion
{
    public class Cls_Ponderacion
    {
        public int pPkIdPonderacion { get; set; }            // Pk_Id_Ponderacion (automático)
        public int pFkIdAuditado { get; set; }               // Fk_Id_Auditado
        public int pFkIdCronograma { get; set; }             // Fk_Id_Cronograma
        public int pFkIdRubrica { get; set; }                // Fk_Id_Rubrica
        public int pFkIdCriterio { get; set; }               // Fk_Id_Criterio
        public int pFkIdEscala { get; set; }                 // Fk_Id_Escala
        public decimal pCalificacionPorcentaje { get; set; } // Cmp_Calificacion_Porcentaje_Ponderacion (0 a 100)
        public decimal pCalificacionPonderada { get; set; }  // Cmp_Calificacion_Ponderada_Ponderacion (0 a 100)
        public string pComentariosAuditor { get; set; }      // Cmp_Comentarios_Auditor_Ponderacion (opcional)
    }
}

