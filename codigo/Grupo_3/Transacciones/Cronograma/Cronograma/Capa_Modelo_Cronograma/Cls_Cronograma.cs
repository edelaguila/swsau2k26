//Inicio de código de "Pablo José Quiroa Martínez" con carné: "0901-22-2929" en la fecha de: "20/10/2026"
using System;

namespace Capa_Modelo_Cronograma
{
    // Entidad que representa un registro de tbl_cronograma
    public class Cls_Cronograma
    {
        public int PkIdCronograma { get; set; }
        public int FkIdPlanificacion { get; set; }
        public string NombrePlanificacion { get; set; }   // solo lectura, viene del JOIN
        public int FkIdActividadProyecto { get; set; }
        public string NombreActividad { get; set; }       // solo lectura, viene del JOIN
        public string NombreTarea { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }         // NOT NULL en la BD
        public DateTime FechaFin { get; set; }            // NOT NULL en la BD
        public string Responsable { get; set; }
        public string Estado { get; set; }
        public string Observaciones { get; set; }
    }
}
//Fin del código de "Pablo José Quiroa Martínez" con carné: "0901-22-2929" en la fecha de: "20/10/2026"