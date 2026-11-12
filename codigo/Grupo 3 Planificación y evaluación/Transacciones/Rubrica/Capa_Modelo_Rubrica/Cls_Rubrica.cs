// Empieza codigo hecho por Maria Morales 0901-22-1226 el dia 07/10/2026
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Modelo_Rubrica
{
    // Entidad que representa un registro de tbl_rubrica.
    public class Cls_Rubrica
    {
        public int pIdRubrica { get; set; }
        public int pIdCronograma { get; set; }
        public string pNombreCronograma { get; set; }   // Solo para mostrar en la grilla
        public string pNombre { get; set; }
        public string pDescripcion { get; set; }
        public string pObjetivo { get; set; }
    }
}
// Termina codigo hecho por Maria Morales 0901-22-1226 el dia 07/10/2026