using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Controlador_Graficas_Informes;
using System.Data;
using System.Data.Odbc;
using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;
using Capa_Modelo_Graficas_Informes;

namespace Capa_Controlador_Graficas_Informes
{
    public enum GravedadGrafica { Info, Advertencia, Error }

    public class ClsResultadoGrafica
    {
        public bool bExito { get; private set; }
        public string sMensaje { get; private set; }
        public GravedadGrafica Gravedad { get; private set; }
        public Dictionary<string, string> dicErrores { get; private set; } = new Dictionary<string, string>();
        public DataTable dtDatos { get; private set; }

        public static ClsResultadoGrafica Ok(string sMensaje = null, DataTable dt = null)
        {
            return new ClsResultadoGrafica { bExito = true, sMensaje = sMensaje, Gravedad = GravedadGrafica.Info, dtDatos = dt };
        }

        public static ClsResultadoGrafica Fallo(string sMensaje, GravedadGrafica g = GravedadGrafica.Error)
        {
            return new ClsResultadoGrafica { bExito = false, sMensaje = sMensaje, Gravedad = g };
        }

        public static ClsResultadoGrafica Invalido(Dictionary<string, string> dicErrores)
        {
            return new ClsResultadoGrafica
            {
                bExito = false,
                sMensaje = "Corrija los campos marcados.",
                Gravedad = GravedadGrafica.Advertencia,
                dicErrores = dicErrores
            };
        }
    }

    public static class ClsValidadorGrafica
    {
        public static Dictionary<string, string> fun_Validar(object oModelo)
        {
            var lstResultados = new List<ValidationResult>();
            var contexto = new ValidationContext(oModelo);
            Validator.TryValidateObject(oModelo, contexto, lstResultados, true);

            var dicErrores = new Dictionary<string, string>();
            foreach (var resultado in lstResultados)
                foreach (var sPropiedad in resultado.MemberNames)
                    if (!dicErrores.ContainsKey(sPropiedad))
                        dicErrores.Add(sPropiedad, resultado.ErrorMessage);

            return dicErrores;
        }
    }

    public class ClsGraficaC
    {
        private readonly ClsGraficaDAO dao = new ClsGraficaDAO();

        public const string sTIPO_BARRAS = "barras";
        public const string sTIPO_PASTEL = "pastel";
        public const string sTIPO_LINEA = "linea";
        private static readonly string[] sTIPOS_VALIDOS = { sTIPO_BARRAS, sTIPO_PASTEL, sTIPO_LINEA };

        private const string sTITULO_BASE = "Calificación";

        public static class ClsCamposGrafica
        {
            public const string sProyecto = nameof(ClsGraficasM.Fk_id_proyecto);
            public const string sTipo = nameof(ClsGraficasM.tipo_grafica);
            public const string sDescripcion = nameof(ClsGraficasM.descripcion);
            public const string sDatos = nameof(ClsGraficasM.datos_json_grafica);
            public const string sRubrica = nameof(ClsDatosGraficaM.IdRubrica);
        }

        public string[] fun_Obtener_Tipos()
        {
            return sTIPOS_VALIDOS;
        }

        public ClsResultadoGrafica fun_Obtener_Proyectos()
        {
            return fun_Consultar(dao.fun_Obtener_Proyectos, "proyectos");
        }

        public ClsResultadoGrafica fun_Obtener_Rubricas(object oProyecto)
        {
            int iProyecto = fun_ConvertirEntero(oProyecto);
            if (iProyecto <= 0) return ClsResultadoGrafica.Ok(dt: new DataTable());
            return fun_Consultar(() => dao.fun_Obtener_Rubricas_Por_Proyecto(iProyecto), "rúbricas");
        }

        public ClsResultadoGrafica fun_Obtener_Graficas(object oProyecto)
        {
            int iProyecto = fun_ConvertirEntero(oProyecto);
            if (iProyecto <= 0) return ClsResultadoGrafica.Ok(dt: new DataTable());
            return fun_Consultar(() => dao.fun_Obtener_Graficas_Por_Proyecto(iProyecto), "gráficas");
        }

        public ClsResultadoGrafica fun_Generar_Datos(object oProyecto, object oRubrica)
        {
            int iProyecto = fun_ConvertirEntero(oProyecto);
            int iRubrica = fun_ConvertirEntero(oRubrica);

            var dicErrores = new Dictionary<string, string>();
            if (iProyecto <= 0) dicErrores.Add(ClsCamposGrafica.sProyecto, "Seleccione un proyecto.");
            if (iRubrica <= 0) dicErrores.Add(ClsCamposGrafica.sRubrica, "Seleccione una rúbrica.");
            if (dicErrores.Count > 0) return ClsResultadoGrafica.Invalido(dicErrores);

            try
            {
                DataTable dt = dao.fun_Obtener_Datos_Por_Auditado(iProyecto, iRubrica);
                if (dt.Rows.Count == 0)
                    return ClsResultadoGrafica.Fallo("La rúbrica seleccionada no tiene calificaciones registradas en este proyecto.",
                                                     GravedadGrafica.Advertencia);
                return ClsResultadoGrafica.Ok(dt: dt);
            }
            catch (OdbcException ex)
            {
                return ClsResultadoGrafica.Fallo("Error al obtener las calificaciones: " + ex.Message);
            }
            catch (Exception ex)
            {
                return ClsResultadoGrafica.Fallo("Error inesperado al generar: " + ex.Message);
            }
        }

        public ClsDatosGraficaM fun_Construir_Datos(DataTable dt, object oRubrica)
        {
            string sRubrica = dt.Rows.Count > 0 ? dt.Rows[0]["Rubrica"].ToString() : "";

            ClsDatosGraficaM oDatos = new ClsDatosGraficaM
            {
                Titulo = sTITULO_BASE + " - " + sRubrica,
                IdRubrica = fun_ConvertirEntero(oRubrica),
                Rubrica = sRubrica
            };

            foreach (DataRow fila in dt.Rows)
            {
                oDatos.Etiquetas.Add(fila["Etiqueta"].ToString());
                oDatos.Valores.Add(Convert.ToDouble(fila["Valor"]));
            }
            return oDatos;
        }

        public ClsDatosGraficaM fun_Leer_Datos(string sJson)
        {
            if (string.IsNullOrWhiteSpace(sJson)) return null;
            try { return new JavaScriptSerializer().Deserialize<ClsDatosGraficaM>(sJson); }
            catch (Exception) { return null; }
        }

        public ClsResultadoGrafica fun_Guardar(object oProyecto, object oTipo, string sDescripcion, ClsDatosGraficaM oDatos)
        {
            ClsGraficasM oGrafica = fun_Construir(0, oProyecto, oTipo, sDescripcion, oDatos);

            var dicErrores = fun_ValidarGrafica(oGrafica);
            if (dicErrores.Count > 0)
                return ClsResultadoGrafica.Invalido(dicErrores);

            try
            {
                return dao.fun_Insertar_Grafica(oGrafica)
                    ? ClsResultadoGrafica.Ok("Gráfica guardada correctamente.")
                    : ClsResultadoGrafica.Fallo("No se pudo guardar la gráfica.");
            }
            catch (OdbcException ex) { return fun_ErrorBD("guardar", ex); }
            catch (Exception ex) { return ClsResultadoGrafica.Fallo("Error inesperado al guardar: " + ex.Message); }
        }

        public ClsResultadoGrafica fun_Actualizar(string sId, object oProyecto, object oTipo, string sDescripcion, ClsDatosGraficaM oDatos)
        {
            if (!int.TryParse(sId, out int iId) || iId <= 0)
                return ClsResultadoGrafica.Fallo("Seleccione una gráfica de la lista para modificar.", GravedadGrafica.Advertencia);

            ClsGraficasM oGrafica = fun_Construir(iId, oProyecto, oTipo, sDescripcion, oDatos);

            var dicErrores = fun_ValidarGrafica(oGrafica);
            if (dicErrores.Count > 0)
                return ClsResultadoGrafica.Invalido(dicErrores);

            try
            {
                return dao.fun_Actualizar_Grafica(oGrafica)
                    ? ClsResultadoGrafica.Ok("Gráfica modificada correctamente.")
                    : ClsResultadoGrafica.Fallo("No se modificó la gráfica (no existe o no hubo cambios).",
                                                GravedadGrafica.Advertencia);
            }
            catch (OdbcException ex) { return fun_ErrorBD("modificar", ex); }
            catch (Exception ex) { return ClsResultadoGrafica.Fallo("Error inesperado al modificar: " + ex.Message); }
        }

        public ClsResultadoGrafica fun_Eliminar(string sId)
        {
            if (!int.TryParse(sId, out int iId) || iId <= 0)
                return ClsResultadoGrafica.Fallo("Seleccione una gráfica de la lista para eliminar.", GravedadGrafica.Advertencia);

            try
            {
                return dao.fun_Eliminar_Grafica(iId)
                    ? ClsResultadoGrafica.Ok("Gráfica eliminada correctamente.")
                    : ClsResultadoGrafica.Fallo("La gráfica ya no existe.", GravedadGrafica.Advertencia);
            }
            catch (OdbcException ex) { return fun_ErrorBD("eliminar", ex); }
            catch (Exception ex) { return ClsResultadoGrafica.Fallo("Error inesperado al eliminar: " + ex.Message); }
        }

        private ClsGraficasM fun_Construir(int iId, object oProyecto, object oTipo, string sDescripcion, ClsDatosGraficaM oDatos)
        {
            return new ClsGraficasM
            {
                Pk_id_grafica = iId,
                Fk_id_proyecto = fun_ConvertirEntero(oProyecto),
                tipo_grafica = oTipo == null ? null : oTipo.ToString(),
                descripcion = string.IsNullOrWhiteSpace(sDescripcion) ? null : sDescripcion.Trim(),
                datos_json_grafica = oDatos == null ? null : new JavaScriptSerializer().Serialize(oDatos)
            };
        }

        private Dictionary<string, string> fun_ValidarGrafica(ClsGraficasM oGrafica)
        {
            var dicErrores = ClsValidadorGrafica.fun_Validar(oGrafica);

            if (!dicErrores.ContainsKey(ClsCamposGrafica.sTipo) &&
                Array.IndexOf(sTIPOS_VALIDOS, oGrafica.tipo_grafica) < 0)
                dicErrores.Add(ClsCamposGrafica.sTipo, "El tipo de gráfica no es válido.");

            return dicErrores;
        }

        private int fun_ConvertirEntero(object oValor)
        {
            if (oValor == null || oValor == DBNull.Value) return 0;
            return int.TryParse(oValor.ToString(), out int iResultado) ? iResultado : 0;
        }

        private ClsResultadoGrafica fun_Consultar(Func<DataTable> funConsulta, string sDescripcion)
        {
            try
            {
                return ClsResultadoGrafica.Ok(dt: funConsulta());
            }
            catch (OdbcException ex)
            {
                return ClsResultadoGrafica.Fallo("Error al obtener " + sDescripcion + ": " + ex.Message);
            }
        }

        private ClsResultadoGrafica fun_ErrorBD(string sAccion, OdbcException ex)
        {
            int iCodigo = ex.Errors.Count > 0 ? ex.Errors[0].NativeError : 0;
            switch (iCodigo)
            {
                case 1452: return ClsResultadoGrafica.Fallo("El proyecto seleccionado ya no existe.");
                default: return ClsResultadoGrafica.Fallo("Error de base de datos al " + sAccion + " la gráfica: " + ex.Message);
            }
        }
    }
}