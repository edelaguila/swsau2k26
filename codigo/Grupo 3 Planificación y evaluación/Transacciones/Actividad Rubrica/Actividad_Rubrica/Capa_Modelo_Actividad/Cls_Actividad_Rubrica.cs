// Codigo empezado por: Maria Morales 0901-22-1226 el día 19/10/2026
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Modelo_Actividad
{
    public class Cls_Actividad_Rubrica
    {
        public int PkIdActividadRubrica { get; set; }
        public int FkIdActividadProyecto { get; set; }
        public int FkIdRubrica { get; set; }
        public bool EstadoActividadRubrica { get; set; }
    }


}
// Codigo terminado por: Maria Morales 0901-22-1226 el día 19/10/2026