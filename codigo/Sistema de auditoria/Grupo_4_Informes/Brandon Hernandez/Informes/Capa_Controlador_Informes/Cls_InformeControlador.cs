// Brandon Hernandez 0901-22-9663 18/10/2026 - Controlador de tbl_informes
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using Capa_Modelo_Informes;

namespace Capa_Controlador_Informes
{
    public class Cls_InformesControlador
    {
        private readonly Cls_InformesDAO dao = new Cls_InformesDAO();
        public static class Cls_CamposInforme
        {
            public const string sTitulo = nameof(Cls_Informes.Cmp_titulo_informe);
            public const string sProyecto = nameof(Cls_Informes.Fk_id_proyecto);
            public const string sEstado = nameof(Cls_Informes.Fk_id_estado_informe);
            public const string sAuditor = nameof(Cls_Informes.Fk_id_auditor);
        }

        // =============== CONSULTAS ===============
        public Cls_ResultadoOperacion fun_Obtener_Informes() => fun_Consultar(dao.fun_Obtener_Informes, "informes");
        public Cls_ResultadoOperacion fun_Obtener_Proyectos() => fun_Consultar(dao.fun_Obtener_Proyectos, "proyectos");
        public Cls_ResultadoOperacion fun_Obtener_Auditores() => fun_Consultar(dao.fun_Obtener_Auditores, "auditores");
        public Cls_ResultadoOperacion fun_Obtener_Estados_Informe() => fun_Consultar(dao.fun_Obtener_Estados_Informe, "estados de informe");

        // =============== INSERTAR ===============
        public Cls_ResultadoOperacion fun_Insertar(string sTitulo, object oProyecto, object oEstado, object oAuditor)
        {
            Cls_Informes oInforme = fun_Construir(0, sTitulo, oProyecto, oEstado, oAuditor);

            var dicErrores = Cls_Validador_Modelo.fun_Validar(oInforme);
            if (dicErrores.Count > 0)
                return Cls_ResultadoOperacion.Invalido(dicErrores);

            try
            {
                return dao.fun_Insertar_Informe(oInforme)
                    ? Cls_ResultadoOperacion.Ok("Informe guardado correctamente.")
                    : Cls_ResultadoOperacion.Fallo("No se pudo guardar el informe.");
            }
            catch (OdbcException ex) { return fun_ErrorBD("guardar", ex); }
            catch (Exception ex) { return Cls_ResultadoOperacion.Fallo("Error inesperado al guardar: " + ex.Message); }
        }

        // =============== ACTUALIZAR ===============
        public Cls_ResultadoOperacion fun_Actualizar(string sId, string sTitulo, object oProyecto, object oEstado, object oAuditor)
        {
            if (!int.TryParse(sId, out int iId) || iId <= 0)
                return Cls_ResultadoOperacion.Fallo("Seleccione un informe de la lista para modificar.", GravedadMensaje.Advertencia);

            Cls_Informes oInforme = fun_Construir(iId, sTitulo, oProyecto, oEstado, oAuditor);

            var dicErrores = Cls_Validador_Modelo.fun_Validar(oInforme);
            if (dicErrores.Count > 0)
                return Cls_ResultadoOperacion.Invalido(dicErrores);

            try
            {
                return dao.fun_Actualizar_Informe(oInforme)
                    ? Cls_ResultadoOperacion.Ok("Informe modificado correctamente.")
                    : Cls_ResultadoOperacion.Fallo("No se modificó el informe (no existe o no hubo cambios).",
                                                   GravedadMensaje.Advertencia);
            }
            catch (OdbcException ex) { return fun_ErrorBD("modificar", ex); }
            catch (Exception ex) { return Cls_ResultadoOperacion.Fallo("Error inesperado al modificar: " + ex.Message); }
        }

        // =============== CAMBIAR ESTADO ===============
        public Cls_ResultadoOperacion fun_Cambiar_Estado(string sId, object oNuevoEstado)
        {
            if (!int.TryParse(sId, out int iId) || iId <= 0)
                return Cls_ResultadoOperacion.Fallo("Seleccione un informe de la lista.", GravedadMensaje.Advertencia);

            int iEstado = fun_ConvertirEntero(oNuevoEstado);
            if (iEstado <= 0)
                return Cls_ResultadoOperacion.Invalido(new Dictionary<string, string>
                {
                    { nameof(Cls_Informes.Fk_id_estado_informe), "Seleccione un estado." }
                });

            try
            {
                return dao.fun_Cambiar_Estado_Informe(iId, iEstado)
                    ? Cls_ResultadoOperacion.Ok("Estado actualizado correctamente.")
                    : Cls_ResultadoOperacion.Fallo("El informe ya tenía ese estado o no existe.", GravedadMensaje.Advertencia);
            }
            catch (OdbcException ex) { return fun_ErrorBD("cambiar el estado de", ex); }
            catch (Exception ex) { return Cls_ResultadoOperacion.Fallo("Error inesperado: " + ex.Message); }
        }

        // =============== AUXILIARES PRIVADOS ===============
        private Cls_Informes fun_Construir(int iId, string sTitulo, object oProyecto, object oEstado, object oAuditor) //arma un objeto Cls_Informes a partir de los datos recibidos (para insertar o actualizar)
        {
            return new Cls_Informes
            {
                Pk_id_Informe = iId,
                Cmp_titulo_informe = sTitulo?.Trim(),
                Fk_id_proyecto = fun_ConvertirEntero(oProyecto),
                Fk_id_estado_informe = fun_ConvertirEntero(oEstado),
                Fk_id_auditor = fun_ConvertirEntero(oAuditor)
            };
        }
        //Convierte un valor a entero, devolviendo 0 si es null, DBNull o no es un número válido.
        // SelectedValue de un ComboBox puede llegar null, DBNull o de tipo inesperado
        private int fun_ConvertirEntero(object oValor)
        {
            if (oValor == null || oValor == DBNull.Value) return 0;
            return int.TryParse(oValor.ToString(), out int iResultado) ? iResultado : 0;
        }

        private Cls_ResultadoOperacion fun_Consultar(Func<DataTable> funConsulta, string sDescripcion)
        {
            try
            {
                return Cls_ResultadoOperacion.Ok(dt: funConsulta());
            }
            catch (OdbcException ex)
            {
                return Cls_ResultadoOperacion.Fallo($"Error al obtener {sDescripcion}: {ex.Message}");
            }
        }
        //traduce errores de OdbcException a mensajes amigables para el usuario, según el código de error nativo de MySQL
        private Cls_ResultadoOperacion fun_ErrorBD(string sAccion, OdbcException ex)
        {
            // 1452 = FK inexistente, 1062 = duplicado (códigos nativos de MySQL)
            int iCodigo = ex.Errors.Count > 0 ? ex.Errors[0].NativeError : 0;
            switch (iCodigo)
            {
                case 1452: return Cls_ResultadoOperacion.Fallo("El proyecto, estado o auditor seleccionado ya no existe.");
                case 1062: return Cls_ResultadoOperacion.Fallo("Ya existe un informe con esos datos.");
                default: return Cls_ResultadoOperacion.Fallo($"Error de base de datos al {sAccion} el informe: {ex.Message}");
            }
        }
    }
}