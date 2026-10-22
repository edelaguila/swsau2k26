using System;
using System.Data;
using Capa_Modelo_Recursos;

//Inicio de código de Nelson Godínez carné 0901-22-3550 en la fecha de: "08/10/2026"
namespace Capa_Controlador_Recursos
{
    public class Cls_Controlador_Recursos
    {
        private readonly Cls_Dao_Recursos gDao = new Cls_Dao_Recursos();

        public DataTable fun_listar_recursos()
        {
            return gDao.fun_listar_recursos();
        }

        public DataTable fun_listar_proyectos()
        {
            return gDao.fun_listar_proyectos();
        }

        public string fun_guardar_recurso(int iIdProyecto, string sNombre, string sTipo, int iCantidad)
        {
            string sError = fun_validar(iIdProyecto, sNombre, sTipo, iCantidad);
            if (sError != "") return sError;

            try
            {
                gDao.fun_insertar_recurso(iIdProyecto, sNombre.Trim(), sTipo.Trim(), iCantidad);
                return "";
            }
            catch (Exception ex)
            {
                return "No se pudo guardar el recurso: " + ex.Message;
            }
        }

        public string fun_modificar_recurso(int iIdRecurso, int iIdProyecto, string sNombre, string sTipo, int iCantidad)
        {
            if (iIdRecurso <= 0) return "Seleccione un recurso para modificar.";

            string sError = fun_validar(iIdProyecto, sNombre, sTipo, iCantidad);
            if (sError != "") return sError;

            try
            {
                int iFilas = gDao.fun_modificar_recurso(iIdRecurso, iIdProyecto, sNombre.Trim(), sTipo.Trim(), iCantidad);
                return iFilas > 0 ? "" : "El recurso ya no existe.";
            }
            catch (Exception ex)
            {
                return "No se pudo modificar el recurso: " + ex.Message;
            }
        }

        public string fun_eliminar_recurso(int iIdRecurso)
        {
            if (iIdRecurso <= 0) return "Seleccione un recurso para eliminar.";

            try
            {
                int iFilas = gDao.fun_eliminar_recurso(iIdRecurso);
                return iFilas > 0 ? "" : "El recurso ya no existe.";
            }
            catch (Exception ex)
            {
                return "No se pudo eliminar el recurso: " + ex.Message;
            }
        }

        // Reglas de la tabla: nombre y tipo son varchar(100) y la cantidad debe ser mayor que 0
        private string fun_validar(int iIdProyecto, string sNombre, string sTipo, int iCantidad)
        {
            if (iIdProyecto <= 0) return "Seleccione un proyecto.";
            if (string.IsNullOrWhiteSpace(sNombre)) return "Ingrese el nombre del recurso.";
            if (sNombre.Trim().Length > 100) return "El nombre no puede pasar de 100 caracteres.";
            if (string.IsNullOrWhiteSpace(sTipo)) return "Ingrese el tipo de recurso.";
            if (sTipo.Trim().Length > 100) return "El tipo no puede pasar de 100 caracteres.";
            if (iCantidad <= 0) return "La cantidad debe ser mayor que 0.";
            return "";
        }
    }
}
//Fin del código de Nelson Godínez carné 0901-22-3550 en la fecha de: "08/10/2026"