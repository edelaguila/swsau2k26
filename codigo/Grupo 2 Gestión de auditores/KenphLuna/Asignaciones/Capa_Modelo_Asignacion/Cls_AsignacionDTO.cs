using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Modelo_Asignacion
{
    //Inicio de código de Kenph Luna 9959-22-6326 en la fecha 16/10/2026
    public class Cls_AsignacionDTO
    {
        public int iPk_Id_Asignacion { get; set; }
        public int iFk_Id_Auditor { get; set; }
        public int iFk_Id_Auditado { get; set; }
        public int iFk_Id_Estado_Asignacion { get; set; }
        public int iFk_Id_Actividad_Rubrica { get; set; }
        public string sNombre_Asignacion { get; set; }
        public DateTime dFecha_Asignacion { get; set; }
        public DateTime? dFecha_Finalizacion_Asignacion { get; set; }
        public string sDescripcion_Asignacion { get; set; }
        public string sEvidencia_Asignacion { get; set; }
        public string sObservaciones_Asignacion { get; set; }

        public Cls_AsignacionDTO()
        {
            sNombre_Asignacion = string.Empty;
            sDescripcion_Asignacion = string.Empty;
            sEvidencia_Asignacion = string.Empty;
            sObservaciones_Asignacion = string.Empty;
        }
    }
    //Fin del código de Kenph Luna 9959-22-6326 en la fecha 16/10/2026
}

