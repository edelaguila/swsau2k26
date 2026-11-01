// Brandon Hernandez - 0901-22-9663 18/10/2026 - Clase para manejar los resultados de operaciones (éxito, fallo, errores de validación)
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Controlador_Informes
{
    public enum GravedadMensaje { Info, Advertencia, Error }

    public class Cls_ResultadoOperacion
    {
        public bool bExito { get; private set; }
        public string sMensaje { get; private set; }
        public GravedadMensaje Gravedad { get; private set; }
        public Dictionary<string, string> dicErrores { get; private set; } = new Dictionary<string, string>();
        public DataTable dtDatos { get; private set; }

        public static Cls_ResultadoOperacion Ok(string sMensaje = null, DataTable dt = null) =>
            new Cls_ResultadoOperacion { bExito = true, sMensaje = sMensaje, Gravedad = GravedadMensaje.Info, dtDatos = dt };

        public static Cls_ResultadoOperacion Fallo(string sMensaje, GravedadMensaje g = GravedadMensaje.Error) =>
            new Cls_ResultadoOperacion { bExito = false, sMensaje = sMensaje, Gravedad = g };

        public static Cls_ResultadoOperacion Invalido(Dictionary<string, string> dicErrores) =>
            new Cls_ResultadoOperacion
            {
                bExito = false,
                sMensaje = "Corrija los campos marcados.",
                Gravedad = GravedadMensaje.Advertencia,
                dicErrores = dicErrores
            };
    }
}
