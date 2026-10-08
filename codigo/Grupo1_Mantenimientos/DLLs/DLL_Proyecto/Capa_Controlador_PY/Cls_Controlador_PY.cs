using System;
using System.Data;
using System.Data.Odbc;
using Capa_Modelo_PY;

namespace Capa_Controlador_PY
{
    // Controlador del CRUD de proyectos. Las funciones de guardar/modificar/eliminar devuelven ""
    // si todo salió bien, o el mensaje de error para mostrarlo en la vista.
    public class Cls_Controlador_PY
    {
        private readonly Cls_Sentencias_PY snSentencias = new Cls_Sentencias_PY();

        public DataTable fun_obtener_proyectos() { return snSentencias.fun_obtener_proyectos(); }
        public DataTable fun_obtener_estados() { return snSentencias.fun_obtener_estados(); }
        public int fun_siguiente_id() { return snSentencias.fun_siguiente_id(); }

        public string fun_insertar_proyecto(int iId, int iEstado, string sNombre, string sDescripcion,
                                            DateTime? dInicio, DateTime? dFin, string sObjetivo)
        {
            string sError = fun_validar(iEstado, sNombre, dInicio, dFin);
            if (sError != "") return sError;

            try
            {
                return snSentencias.fun_insertar_proyecto(iId, iEstado, sNombre.Trim(), sDescripcion, dInicio, dFin, sObjetivo)
                    ? "" : "No se pudo insertar el proyecto.";
            }
            catch (Exception ex) { return "Error al insertar: " + ex.Message; }
        }

        public string fun_modificar_proyecto(int iId, int iEstado, string sNombre, string sDescripcion,
                                             DateTime? dInicio, DateTime? dFin, string sObjetivo)
        {
            string sError = fun_validar(iEstado, sNombre, dInicio, dFin);
            if (sError != "") return sError;

            try
            {
                return snSentencias.fun_actualizar_proyecto(iId, iEstado, sNombre.Trim(), sDescripcion, dInicio, dFin, sObjetivo)
                    ? "" : "No se encontró el proyecto a modificar.";
            }
            catch (Exception ex) { return "Error al modificar: " + ex.Message; }
        }

        public string fun_eliminar_proyecto(int iId)
        {
            try
            {
                return snSentencias.fun_eliminar_proyecto(iId) ? "" : "No se encontró el proyecto a eliminar.";
            }
            catch (OdbcException ex)
            {
                if (ex.Errors.Count > 0 && ex.Errors[0].NativeError == 1451)
                    return "No se puede eliminar: el proyecto está siendo utilizado en otros registros.";
                return "Error al eliminar: " + ex.Message;
            }
            catch (Exception ex) { return "Error al eliminar: " + ex.Message; }
        }

        // Validaciones de negocio
        private string fun_validar(int iEstado, string sNombre, DateTime? dInicio, DateTime? dFin)
        {
            if (string.IsNullOrWhiteSpace(sNombre)) return "El nombre del proyecto es obligatorio.";
            if (sNombre.Trim().Length > 100) return "El nombre no puede superar los 100 caracteres.";
            if (iEstado <= 0) return "Debe seleccionar un estado.";
            if (dInicio.HasValue && dFin.HasValue && dFin.Value.Date < dInicio.Value.Date)
                return "La fecha fin no puede ser anterior a la fecha de inicio.";
            return "";
        }
    }
}