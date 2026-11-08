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
        // [Required] no aplica a int (sin selección llega 0, no null): se valida con Range >= 1
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione un auditor.")]
        public int Fk_id_auditor { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione un estado del informe.")]
        public int Fk_id_estado_informe { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione un proyecto.")]
        public int Fk_id_proyecto { get; set; }
        [Required(ErrorMessage = "El campo nombre del informe es obligatorio.")]
        [StringLength(150, ErrorMessage = "El nombre del informe no puede tener más de 150 caracteres.")]
        [RegularExpression("^[a-zA-Z0-9áéíóúÁÉÍÓÚñÑüÜ\\s\\-_.,:;()/#°]+$",
            ErrorMessage = "El nombre del informe solo puede contener letras, números, espacios y los signos - _ . , : ; ( ) / # °")]
        public string Cmp_titulo_informe { get; set; }
        
        public DateTime fecha_creacion { get; set; }
        public DateTime fecha_actualizacion { get; set; } = DateTime.Now;

    }
}
