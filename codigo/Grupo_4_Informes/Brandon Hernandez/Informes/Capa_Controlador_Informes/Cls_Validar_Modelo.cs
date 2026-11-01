using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Capa_Controlador_Informes
{
    //Brandon Hernandez - 0901-22-9663
    public static class Cls_Validador_Modelo
    {
        /// Valida un objeto según sus DataAnnotations e IValidatableObject.
        /// Devuelve un diccionario: nombre de propiedad -> mensaje de error.
        public static Dictionary<string, string> fun_Validar(object oModelo)
        {
            var lstResultados = new List<ValidationResult>();
            var contexto = new ValidationContext(oModelo);
            Validator.TryValidateObject(oModelo, contexto, lstResultados, validateAllProperties: true);

            var dicErrores = new Dictionary<string, string>();
            foreach (var resultado in lstResultados)
                foreach (var sPropiedad in resultado.MemberNames)
                    if (!dicErrores.ContainsKey(sPropiedad))   // un mensaje por campo
                        dicErrores.Add(sPropiedad, resultado.ErrorMessage);

            return dicErrores;
        }
    }
}

