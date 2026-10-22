using Capa_Modelo_Asignacion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Controlador_Seguridad;

namespace Capa_Controlador_Asignacion
{
    //Inicio de código de Kenph Luna 9959-22-6326 en la fecha 16/10/2026
    public class Cls_AsignacionControlador
    {
        private readonly Cls_AsignacionDAO gDaoAsignacion = new Cls_AsignacionDAO();
        private readonly Cls_Validaciones gValidador = new Cls_Validaciones();
        private readonly Cls_BitacoraControlador gControladorBitacora = new Cls_BitacoraControlador();

        // Código de la aplicación en tbl_aplicacion 512 Asignaciones
        private const int I_ID_APLICACION_ASIGNACION = 512;

        public (bool bExito, string sMensaje) fun_RegistrarAsignacion(
            int iAuditor,
            int iAuditado,
            int iEstado,
            int iActividadRubrica,
            string sNombre,
            DateTime dInicio,
            DateTime? dFin,
            string sDescripcion,
            string sEvidencia,
            string sObservaciones)
        {
            // Validaciones de negocio
            if (iAuditor <= 0 || iAuditado <= 0 || iEstado <= 0 || iActividadRubrica <= 0)
                return (false, "Debe seleccionar todas las opciones requeridas en los catálogos.");

            if (!gValidador.fun_ValidarLongitud(sNombre, 3, 100))
                return (false, "El nombre de la asignación debe tener entre 3 y 100 caracteres.");

            if (!gValidador.fun_SinCaracteresEspeciales(sNombre))
                return (false, "El nombre de la asignación contiene caracteres inválidos.");

            if (!gValidador.fun_ValidarRangoFechas(dInicio, dFin))
                return (false, "La fecha de finalización no puede ser menor a la fecha de inicio.");

            Cls_AsignacionDTO dto = new Cls_AsignacionDTO
            {
                iFk_Id_Auditor = iAuditor,
                iFk_Id_Auditado = iAuditado,
                iFk_Id_Estado_Asignacion = iEstado,
                iFk_Id_Actividad_Rubrica = iActividadRubrica,
                sNombre_Asignacion = sNombre.Trim(),
                dFecha_Asignacion = dInicio,
                dFecha_Finalizacion_Asignacion = dFin,
                sDescripcion_Asignacion = sDescripcion?.Trim(),
                sEvidencia_Asignacion = sEvidencia?.Trim(),
                sObservaciones_Asignacion = sObservaciones?.Trim()
            };

            string sError = string.Empty;
            bool bOk = gDaoAsignacion.fun_InsertarAsignacion(dto, ref sError);

            if (bOk)
            {
                // Insercion en bitácora
                string sAccion = $"Se registró la asignación: {dto.sNombre_Asignacion}";
                gControladorBitacora.RegistrarAccion(Cls_Usuario_Conectado.iIdUsuario, I_ID_APLICACION_ASIGNACION, sAccion, true);
                return (true, "Asignación registrada exitosamente.");
            }

            return (false, sError);
        }

        public (bool bExito, string sMensaje) fun_ActualizarAsignacion(
            int iIdAsignacion,
            int iAuditor,
            int iAuditado,
            int iEstado,
            int iActividadRubrica,
            string sNombre,
            DateTime dInicio,
            DateTime? dFin,
            string sDescripcion,
            string sEvidencia,
            string sObservaciones)
        {
            if (iIdAsignacion <= 0)
                return (false, "Identificador de asignación no válido.");

            if (iAuditor <= 0 || iAuditado <= 0 || iEstado <= 0 || iActividadRubrica <= 0)
                return (false, "Debe seleccionar todas las opciones de los catálogos.");

            if (!gValidador.fun_ValidarLongitud(sNombre, 3, 100))
                return (false, "El nombre debe contener entre 3 y 100 caracteres.");

            if (!gValidador.fun_SinCaracteresEspeciales(sNombre))
                return (false, "El nombre contiene caracteres especiales no admitidos.");

            if (!gValidador.fun_ValidarRangoFechas(dInicio, dFin))
                return (false, "La fecha final no puede ser menor a la de inicio.");

            Cls_AsignacionDTO dto = new Cls_AsignacionDTO
            {
                iPk_Id_Asignacion = iIdAsignacion,
                iFk_Id_Auditor = iAuditor,
                iFk_Id_Auditado = iAuditado,
                iFk_Id_Estado_Asignacion = iEstado,
                iFk_Id_Actividad_Rubrica = iActividadRubrica,
                sNombre_Asignacion = sNombre.Trim(),
                dFecha_Asignacion = dInicio,
                dFecha_Finalizacion_Asignacion = dFin,
                sDescripcion_Asignacion = sDescripcion?.Trim(),
                sEvidencia_Asignacion = sEvidencia?.Trim(),
                sObservaciones_Asignacion = sObservaciones?.Trim()
            };

            string sError = string.Empty;
            bool bOk = gDaoAsignacion.fun_ModificarAsignacion(dto, ref sError);

            if (bOk)
            {
                string sAccion = $"Se modificó la asignación ID: {iIdAsignacion} ({dto.sNombre_Asignacion})";
                gControladorBitacora.RegistrarAccion(Cls_Usuario_Conectado.iIdUsuario, I_ID_APLICACION_ASIGNACION, sAccion, true);
                return (true, "Asignación actualizada correctamente.");
            }

            return (false, sError);
        }

        public (bool bExito, string sMensaje) fun_BorrarAsignacion(int iIdAsignacion, string sNombreAsignacion)
        {
            if (iIdAsignacion <= 0)
                return (false, "Debe seleccionar un registro válido para eliminar.");

            string sError = string.Empty;
            bool bOk = gDaoAsignacion.fun_EliminarAsignacion(iIdAsignacion, ref sError);

            if (bOk)
            {
                string sAccion = $"Se eliminó la asignación ID: {iIdAsignacion} ({sNombreAsignacion})";
                gControladorBitacora.RegistrarAccion(Cls_Usuario_Conectado.iIdUsuario, I_ID_APLICACION_ASIGNACION, sAccion, true);
                return (true, "Asignación eliminada del sistema.");
            }

            return (false, sError);
        }

        public DataTable fun_ConsultarAsignaciones()
        {
            return gDaoAsignacion.fun_ConsultarAsignaciones();
        }

        public DataTable fun_CargarAuditores()
        {
            return gDaoAsignacion.fun_ObtenerCatalogoAuditores();
        }

        public DataTable fun_CargarAuditados()
        {
            return gDaoAsignacion.fun_ObtenerCatalogoAuditados();
        }

        public DataTable fun_CargarEstados()
        {
            return gDaoAsignacion.fun_ObtenerCatalogoEstados();
        }

        public DataTable fun_CargarActividadesRubrica()
        {
            return gDaoAsignacion.fun_ObtenerCatalogoActividadesRubrica();
        }
    }
    //Fin del código de Kenph Luna 9959-22-6326 en la fecha 16/10/2026
}
