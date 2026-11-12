// Codigo empezado por: Maria Morales 0901-22-1226 el día 19/10/2026
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Modelo_Actividad_Rubrica 
{

    public class Cls_Actividad_Rubrica
    {
        public int pIdActividadRubrica { get; set; }
        public int pIdActividad { get; set; }
        public string pNombreActividad { get; set; }    // Solo para mostrar en la grilla
        public int pIdRubrica { get; set; }
        public string pNombreRubrica { get; set; }      // Solo para mostrar en la grilla
        public bool pEstado { get; set; }               // tinyint(1): 1 = Activo, 0 = Inactivo
    }
}// Codigo terminado por: Maria Morales 0901-22-1226 el día 19/10/2026