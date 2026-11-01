using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Modelo_Criterios
{
    public class Cls_Criterio
    {
        public int Id { get; set; }
        public int IdRubrica { get; set; }
        public string NombreRubrica { get; set; }      // solo para mostrar en la grilla
        public string Nombre { get; set; }
        public int? Porcentaje { get; set; }
        public string Descripcion { get; set; }
        public string NivelImportancia { get; set; }

    }
}
