using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Capa_Controlador_Asignacion
{
    //Inicio de código de Kenph Luna 9959-22-6326 en la fecha 16/10/2026
    public class Cls_Validaciones
    {
        public bool fun_EsSoloNumeros(string sTexto)
        {
            if (string.IsNullOrWhiteSpace(sTexto)) return false;
            return Regex.IsMatch(sTexto, @"^[0-9]+$");
        }

        public bool fun_EsSoloLetras(string sTexto)
        {
            if (string.IsNullOrWhiteSpace(sTexto)) return false;
            return Regex.IsMatch(sTexto, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$");
        }

        public bool fun_SinCaracteresEspeciales(string sTexto)
        {
            if (string.IsNullOrWhiteSpace(sTexto)) return false;
            return Regex.IsMatch(sTexto, @"^[a-zA-Z0-9áéíóúÁÉÍÓÚñÑ\s.,_-]+$");
        }

        public bool fun_ValidarLongitud(string sTexto, int iMinimo, int iMaximo)
        {
            if (sTexto == null) return false;
            return sTexto.Trim().Length >= iMinimo && sTexto.Trim().Length <= iMaximo;
        }

        public bool fun_ValidarRangoFechas(DateTime dInicio, DateTime? dFin)
        {
            if (!dFin.HasValue) return true;
            return dFin.Value.Date >= dInicio.Date;
        }
    }
    //Fin del código de Kenph Luna 9959-22-6326 en la fecha 16/10/2026
}
