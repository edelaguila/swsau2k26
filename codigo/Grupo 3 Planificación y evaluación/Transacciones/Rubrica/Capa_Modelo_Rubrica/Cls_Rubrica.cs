// Empieza codigo hecho por Maria Morales 0901-22-1226 el dia 07/10/2026
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Modelo_Rubrica
{
    public class Cls_Rubrica
    {
        public int PkIdRubrica { get; set; }
        public int FkIdCronograma { get; set; }
        public string NombreRubrica { get; set; }
        public string DescripcionRubrica { get; set; }
        public string ObjetivoRubrica { get; set; }
    }
}
// Termina codigo hecho por Maria Morales 0901-22-1226 el dia 07/10/2026