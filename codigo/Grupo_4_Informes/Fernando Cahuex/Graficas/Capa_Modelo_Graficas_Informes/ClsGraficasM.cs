using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Modelo_Seguridad;
using System.ComponentModel.DataAnnotations;

namespace Capa_Modelo_Graficas_Informes
{
    public class ClsGraficasM
    {
        public int Pk_id_grafica { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Seleccione un proyecto.")]
        public int Fk_id_proyecto { get; set; }

        [Required(ErrorMessage = "Seleccione el tipo de gráfica.")]
        public string tipo_grafica { get; set; }

        [StringLength(1000, ErrorMessage = "La descripción no puede exceder 1000 caracteres.")]
        public string descripcion { get; set; }

        [Required(ErrorMessage = "Primero genere la gráfica.")]
        public string datos_json_grafica { get; set; }
    }

    public class ClsDatosGraficaM
    {
        public string Titulo { get; set; }
        public int IdRubrica { get; set; }
        public string Rubrica { get; set; }
        public List<string> Etiquetas { get; set; } = new List<string>();
        public List<double> Valores { get; set; } = new List<double>();
    }
}