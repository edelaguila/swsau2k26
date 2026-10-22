using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Modelo_Desc_Criterio
{
    public class Cls_DescripcionCriterio
    {
        public int pIdDescripcion { get; set; }
        public int pIdCriterio { get; set; }
        public int pIdEscala { get; set; }
        public string pNombreCriterio { get; set; }      // "Rúbrica - Criterio", solo para mostrar
        public int pPorcentajeEscala { get; set; }       // solo para mostrar
        public string pNombreNivel { get; set; }         // solo para mostrar
        public string pDescripcionDetallada { get; set; }
        public string pEvidenciaRequerida { get; set; }
        public string pObservaciones { get; set; }
    }
}
