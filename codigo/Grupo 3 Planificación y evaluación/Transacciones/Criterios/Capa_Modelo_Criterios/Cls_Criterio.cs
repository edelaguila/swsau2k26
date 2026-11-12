//Inicio de código de "Nombre del programador" con carné: "No_carné" en la fecha de: "11/11/2026"
using System;

namespace Capa_Modelo_Criterios
{
    // Entidad que representa un registro de tbl_criterios (criterio de evaluación de una rúbrica).
    public class Cls_Criterio
    {
        public int pIdCriterio { get; set; }
        public int pIdRubrica { get; set; }
        public string pNombreRubrica { get; set; }      // Solo para mostrar en la grilla
        public string pNombre { get; set; }
        public int? pPorcentaje { get; set; }
        public string pDescripcion { get; set; }
        public string pNivelImportancia { get; set; }   // Alta, Media, Baja
    }
}
//Fin del código de "Nombre del programador" con carné: "No_carné" en la fecha de: "11/11/2026"
