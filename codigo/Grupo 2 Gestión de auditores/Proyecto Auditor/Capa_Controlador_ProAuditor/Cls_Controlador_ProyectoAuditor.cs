//Inicio del código de "Barbara Saldaña" con carné: "0901-22-9136" en la fecha de : "16/10/26"
using System;
using System.Data;
using Capa_Modelo_ProAuditor;

namespace Capa_Controlador_ProAuditor
{
    public class Cls_Controlador_ProyectoAuditor
    {
        private Cls_Dao_ProyectoAuditor gDao = new Cls_Dao_ProyectoAuditor();

        public DataTable fun_listar(string sFiltro) { return gDao.fun_listar(sFiltro ?? ""); }
        public DataTable fun_combo_proyectos() { return gDao.fun_combo_proyectos(); }
        public DataTable fun_combo_auditores() { return gDao.fun_combo_auditores(); }
        public DataTable fun_combo_perfiles() { return gDao.fun_combo_perfiles(); }

        // Valida los datos obligatorios y que no exista duplicado
        private string fun_validar(int iProyecto, int iAuditor, int iPerfil, int iIdExcluir)
        {
            if (iProyecto <= 0) return "Seleccione un proyecto.";
            if (iAuditor <= 0) return "Seleccione un auditor.";
            if (iPerfil <= 0) return "Seleccione un perfil de auditor.";
            if (gDao.fun_existe_asignacion(iProyecto, iAuditor, iIdExcluir))
                return "El auditor ya está asignado a este proyecto.";
            return "";
        }

        // Guarda una nueva asignación
        public bool fun_guardar(int iProyecto, int iAuditor, int iPerfil, DateTime dFecha, out string sMensaje)
        {
            try
            {
                sMensaje = fun_validar(iProyecto, iAuditor, iPerfil, 0);
                if (sMensaje != "") return false;
                bool bExito = gDao.fun_insertar(iProyecto, iAuditor, iPerfil, dFecha) > 0;
                sMensaje = bExito ? "Asignación guardada correctamente." : "No se pudo guardar la asignación.";
                return bExito;
            }
            catch (Exception Ex) { sMensaje = "Error al guardar: " + Ex.Message; return false; }
        }

        // Modifica una asignación existente.
        public bool fun_modificar(int iId, int iProyecto, int iAuditor, int iPerfil, DateTime dFecha, out string sMensaje)
        {
            try
            {
                if (iId <= 0) { sMensaje = "Seleccione una asignación de la lista."; return false; }
                sMensaje = fun_validar(iProyecto, iAuditor, iPerfil, iId);
                if (sMensaje != "") return false;
                bool bExito = gDao.fun_modificar(iId, iProyecto, iAuditor, iPerfil, dFecha) > 0;
                sMensaje = bExito ? "Asignación modificada correctamente." : "No se realizaron cambios.";
                return bExito;
            }
            catch (Exception Ex) { sMensaje = "Error al modificar: " + Ex.Message; return false; }
        }

        // Elimina una asignación.
        public bool fun_eliminar(int iId, out string sMensaje)
        {
            try
            {
                if (iId <= 0) { sMensaje = "Seleccione una asignación de la lista."; return false; }
                bool bExito = gDao.fun_eliminar(iId) > 0;
                sMensaje = bExito ? "Asignación eliminada correctamente." : "No se pudo eliminar la asignación.";
                return bExito;
            }
            catch (Exception Ex) { sMensaje = "Error al eliminar: " + Ex.Message; return false; }
        }
    }
}
//Fin del código de "Barbara Saldaña" con carné: "0901-22-9136" en la fecha de : "16/10/26"
