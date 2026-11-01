using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Modelo_Informes
{
    public class Cls_Informes
    {
        public int Pk_id_Informe { get; set; }
        [Required(ErrorMessage = "El campo auditor es obligatorio.")]
        public int Fk_id_auditor { get; set; }
        [Required(ErrorMessage = "El campo estado del informe es obligatorio.")]
        public int Fk_id_estado_informe { get; set; }
        public int Fk_id_proyecto { get; set; }
        [RegularExpression("^[a-zA-Z0-9áéíóúÁÉÍÓÚñÑüÜ\\s]+$", ErrorMessage = "El nombre del informe solo puede contener letras, números y espacios.")]
                [Required(ErrorMessage = "El campo nombre del informe es obligatorio.")]
        public string Cmp_titulo_informe { get; set; }
        
        public DateTime fecha_creacion { get; set; }
        public DateTime fecha_actualizacion { get; set; } = DateTime.Now;

    }
}
