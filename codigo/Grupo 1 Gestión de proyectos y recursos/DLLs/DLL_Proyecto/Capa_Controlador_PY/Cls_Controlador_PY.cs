using System;
using System.Data;
using System.Data.Odbc;
using Capa_Modelo_PY;

//Inicio de código de Paula Daniela Leonardo Paredes carné 0901-22-9580 en la fecha de: "20/10/2026"
namespace Capa_Controlador_PY
{
    // Controlador del mantenimiento de proyectos. Las funciones de guardar, modificar y eliminar
    // devuelven "" cuando todo salió bien, o el mensaje de error para mostrarlo en la vista.
    public class Cls_Controlador_PY
    {
        private readonly Cls_Dao_PY gDao = new Cls_Dao_PY();

        public DataTable fun_listar_proyectos()
        {
            return gDao.fun_listar_proyectos();
        }

        public DataTable fun_listar_estados()
        {
            return gDao.fun_listar_estados();
        }

        public int fun_siguiente_id()
        {
            return gDao.fun_siguiente_id();
        }

        public string fun_guardar_proyecto(int iIdEstado, string sNombre, string sDescripcion,
                                           DateTime? dInicio, DateTime? dFin, string sObjetivo)
        {
            string sError = fun_validar(iIdEstado, sNombre, dInicio, dFin);
            if (sError != "") return sError;

            try
            {
                gDao.fun_insertar_proyecto(iIdEstado, sNombre.Trim(), sDescripcion, dInicio, dFin, sObjetivo);
                return "";
            }
            catch (Exception ex)
            {
                return "No se pudo guardar el proyecto: " + ex.Message;
            }
        }

        public string fun_modificar_proyecto(int iIdProyecto, int iIdEstado, string sNombre, string sDescripcion,
                                             DateTime? dInicio, DateTime? dFin, string sObjetivo)
        {
            if (iIdProyecto <= 0) return "Seleccione un proyecto para modificar.";

            string sError = fun_validar(iIdEstado, sNombre, dInicio, dFin);
            if (sError != "") return sError;

            try
            {
                int iFilas = gDao.fun_modificar_proyecto(iIdProyecto, iIdEstado, sNombre.Trim(),
                                                         sDescripcion, dInicio, dFin, sObjetivo);
                return iFilas > 0 ? "" : "El proyecto ya no existe.";
            }
            catch (Exception ex)
            {
                return "No se pudo modificar el proyecto: " + ex.Message;
            }
        }

        public string fun_eliminar_proyecto(int iIdProyecto)
        {
            if (iIdProyecto <= 0) return "Seleccione un proyecto para eliminar.";

            try
            {
                int iFilas = gDao.fun_eliminar_proyecto(iIdProyecto);
                return iFilas > 0 ? "" : "El proyecto ya no existe.";
            }
            catch (OdbcException ex)
            {
                // 1451: la llave foránea impide borrar un proyecto que ya se usa en otras tablas
                if (ex.Errors.Count > 0 && ex.Errors[0].NativeError == 1451)
                    return "No se puede eliminar: el proyecto está siendo utilizado en otros registros.";
                return "No se pudo eliminar el proyecto: " + ex.Message;
            }
            catch (Exception ex)
            {
                return "No se pudo eliminar el proyecto: " + ex.Message;
            }
        }

        // Reglas de la tabla: el nombre es varchar(100) y el estado es llave foránea obligatoria
        private string fun_validar(int iIdEstado, string sNombre, DateTime? dInicio, DateTime? dFin)
        {
            if (string.IsNullOrWhiteSpace(sNombre)) return "Ingrese el nombre del proyecto.";
            if (sNombre.Trim().Length > 100) return "El nombre no puede pasar de 100 caracteres.";
            if (iIdEstado <= 0) return "Seleccione un estado.";
            if (dInicio.HasValue && dFin.HasValue && dFin.Value.Date < dInicio.Value.Date)
                return "La fecha fin no puede ser anterior a la fecha de inicio.";
            return "";
        }
    }
}
//Fin de código de Paula Daniela Leonardo Paredes carné 0901-22-9580 en la fecha de: "20/10/2026"
