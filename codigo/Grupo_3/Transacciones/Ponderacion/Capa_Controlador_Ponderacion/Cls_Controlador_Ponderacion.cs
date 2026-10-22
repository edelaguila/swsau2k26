// Juan Carlos Sandoval Quej, carné: 0901-22-4170 fecha de: "21/10/2026"
using System;
using System.Data;
using System.Globalization;
using Capa_Modelo_Ponderacion;

namespace Capa_Controlador_Ponderacion
{
    public class Cls_Controlador_Ponderacion
    {
        private readonly Cls_PonderacionDAO gDao = new Cls_PonderacionDAO();

        public string fun_guardar(int iIdAuditado, int iIdCronograma, int iIdRubrica, int iIdCriterio,
                                  int iIdEscala, string sPorcentaje, string sPonderada, string sComentarios)
        {
            Cls_Ponderacion oPonderacion;
            string sError = fun_armar(0, iIdAuditado, iIdCronograma, iIdRubrica, iIdCriterio, iIdEscala,
                                      sPorcentaje, sPonderada, sComentarios, out oPonderacion);
            if (sError != null) return sError;

            try
            {
                return gDao.fun_insertar(oPonderacion) ? "OK" : "No se pudo guardar la ponderación.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string fun_modificar(int iIdPonderacion, int iIdAuditado, int iIdCronograma, int iIdRubrica,
                                    int iIdCriterio, int iIdEscala, string sPorcentaje, string sPonderada,
                                    string sComentarios)
        {
            if (iIdPonderacion <= 0) return "Seleccione una ponderación de la lista para modificar.";

            Cls_Ponderacion oPonderacion;
            string sError = fun_armar(iIdPonderacion, iIdAuditado, iIdCronograma, iIdRubrica, iIdCriterio,
                                      iIdEscala, sPorcentaje, sPonderada, sComentarios, out oPonderacion);
            if (sError != null) return sError;

            try
            {
                return gDao.fun_modificar(oPonderacion) ? "OK" : "No se pudo modificar la ponderación.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // Aquí se elimina una ponderación
        public string fun_eliminar(int iIdPonderacion)
        {
            if (iIdPonderacion <= 0) return "Seleccione una ponderación de la lista para eliminar.";

            try
            {
                return gDao.fun_eliminar(iIdPonderacion) ? "OK" : "No se pudo eliminar la ponderación.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // Acá se hace un listado de todas las ponderaciones
        public DataTable fun_listar()
        {
            return gDao.fun_consultar_todos();
        }

        public DataTable fun_listar_auditados()  { return gDao.fun_combo_auditados(); }
        public DataTable fun_listar_cronogramas() { return gDao.fun_combo_cronogramas(); }
        public DataTable fun_listar_rubricas()   { return gDao.fun_combo_rubricas(); }
        public DataTable fun_listar_criterios()  { return gDao.fun_combo_criterios(); }
        public DataTable fun_listar_escalas()    { return gDao.fun_combo_escalas(); }


        // Apartado de validaciones
        private string fun_armar(int iId, int iIdAuditado, int iIdCronograma, int iIdRubrica, int iIdCriterio,
                                 int iIdEscala, string sPorcentaje, string sPonderada, string sComentarios,
                                 out Cls_Ponderacion oPonderacion)
        {
            oPonderacion = null;

            if (iIdAuditado <= 0) return "Debe seleccionar un auditado.";
            if (iIdCronograma <= 0) return "Debe seleccionar un cronograma.";
            if (iIdRubrica <= 0) return "Debe seleccionar una rúbrica.";
            if (iIdCriterio <= 0) return "Debe seleccionar un criterio.";
            if (iIdEscala <= 0) return "Debe seleccionar una escala.";

            decimal dePorcentaje;
            string sErrorPorcentaje = fun_validar_calificacion(sPorcentaje, "La calificación en porcentaje", out dePorcentaje);
            if (sErrorPorcentaje != null) return sErrorPorcentaje;

            decimal dePonderada;
            string sErrorPonderada = fun_validar_calificacion(sPonderada, "La calificación ponderada", out dePonderada);
            if (sErrorPonderada != null) return sErrorPonderada;

            oPonderacion = new Cls_Ponderacion
            {
                pPkIdPonderacion = iId,
                pFkIdAuditado = iIdAuditado,
                pFkIdCronograma = iIdCronograma,
                pFkIdRubrica = iIdRubrica,
                pFkIdCriterio = iIdCriterio,
                pFkIdEscala = iIdEscala,
                pCalificacionPorcentaje = dePorcentaje,
                pCalificacionPonderada = dePonderada,
                pComentariosAuditor = sComentarios == null ? "" : sComentarios.Trim()
            };
            return null;
        }

        // valida que la calificación sea un número entre 0 y 100
        private string fun_validar_calificacion(string sTexto, string sNombre, out decimal deValor)
        {
            deValor = 0;
            if (string.IsNullOrWhiteSpace(sTexto)) return sNombre + " es obligatoria.";

            string sNormalizado = sTexto.Trim().Replace(',', '.');
            if (!decimal.TryParse(sNormalizado, NumberStyles.Number, CultureInfo.InvariantCulture, out deValor))
                return sNombre + " debe ser un número.";

            if (deValor < 0 || deValor > 100) return sNombre + " debe estar entre 0 y 100.";

            deValor = Math.Round(deValor, 2); // la BD guarda 2 decimales
            return null;
        }
    }
}
