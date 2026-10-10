// Empieza codigo hecho por Pablo Quiroa 0901-22-2929 el dia 09/10/2026
using System;

namespace Capa_Modelo_Planificacion
{
    public class Cls_planificacion
    {
        public int PkIdPlanificacion { get; set; }
        public int FkIdProyecto { get; set; }
        public string NombreProyecto { get; set; }     
        public string NombrePlan { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaInicio { get; set; }     
        public DateTime? FechaFin { get; set; }
        public string Observaciones { get; set; }
    }
}
// Termina codigo hecho por Pablo Quiroa 0901-22-2929 el dia 09/10/2026