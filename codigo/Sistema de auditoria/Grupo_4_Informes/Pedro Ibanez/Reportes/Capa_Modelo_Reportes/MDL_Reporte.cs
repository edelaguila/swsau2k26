// Pedro Ibanez 19/10/2026 - Modelo de tbl_reporte
namespace Capa_Modelo_Reportes
{
    public class MDL_Reporte
    {
        public int Pk_id_reporte { get; set; }
        public int Fk_id_informe { get; set; }
        public int Fk_id_actividad_rubrica { get; set; }
        public string aspectos_positivos { get; set; }
        public string imagen_aspectos_positivos { get; set; }
        public string correcciones { get; set; }
        public string imagen_correcciones { get; set; }
        public string recomendaciones { get; set; }
        public string imagen_recomendaciones { get; set; }
    }
}
