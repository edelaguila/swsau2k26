//Inicio de código de "Pablo José Quiroa Martínez" con carné: "0901-22-2929" en la fecha de: "20/10/2026"
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Capa_Modelo_Cronograma;

namespace Capa_Controlador_Cronograma
{
    // Controlador: contiene las reglas de negocio y validaciones del cronograma
    public class Cls_Controlador_Cronograma
    {
        private readonly Cls_CronogramaDAO dao = new Cls_CronogramaDAO();

        // Valores permitidos por el CHECK de la BD (Chk_Cronograma_Estado)
        private static readonly string[] arrEstados = { "Pendiente", "En proceso", "Completada", "Cancelada" };
        public const string sEstadoPorDefecto = "Pendiente";


        public string fun_guardar(int iIdPlanificacion, int iIdActividad, string sNombreTarea, string sDescripcion,
                                  DateTime dFechaInicio, DateTime dFechaFin, string sResponsable,
                                  string sEstado, string sObservaciones)
        {
            Cls_Cronograma cronograma = fun_armar(0, iIdPlanificacion, iIdActividad, sNombreTarea, sDescripcion,
                                                  dFechaInicio, dFechaFin, sResponsable, sEstado, sObservaciones);

            string sValidacion = fun_validar(cronograma);
            if (sValidacion != null) return sValidacion;

            try
            {
                return dao.fun_insertar(cronograma) ? "OK" : "No se pudo guardar la tarea del cronograma.";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }


        public string fun_modificar(int iIdCronograma, int iIdPlanificacion, int iIdActividad, string sNombreTarea,
                                    string sDescripcion, DateTime dFechaInicio, DateTime dFechaFin,
                                    string sResponsable, string sEstado, string sObservaciones)
        {
            if (iIdCronograma <= 0) return "Seleccione una tarea del cronograma para modificar.";

            Cls_Cronograma cronograma = fun_armar(iIdCronograma, iIdPlanificacion, iIdActividad, sNombreTarea,
                                                  sDescripcion, dFechaInicio, dFechaFin, sResponsable,
                                                  sEstado, sObservaciones);

            string sValidacion = fun_validar(cronograma);
            if (sValidacion != null) return sValidacion;

            try
            {
                return dao.fun_actualizar(cronograma) ? "OK" : "No se pudo actualizar la tarea del cronograma.";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }


        public string fun_eliminar(int iIdCronograma)
        {
            if (iIdCronograma <= 0) return "Seleccione una tarea del cronograma para eliminar.";

            try
            {
                return dao.fun_eliminar(iIdCronograma) ? "OK" : "No se pudo eliminar la tarea del cronograma.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        // Arma el mensaje de confirmacion avisando cuantas rubricas se borran en cascada
        public string fun_mensaje_confirmacion_eliminar(int iIdCronograma)
        {
            string sMensaje = "¿Está seguro de eliminar esta tarea del cronograma?";
            try
            {
                int iCantidad = dao.fun_contar_rubricas(iIdCronograma);
                if (iCantidad > 0)
                    sMensaje += "\nSe eliminarán también " + iCantidad + " rúbrica(s) con sus criterios.";
            }
            catch
            {
                // Si no se pudo contar, se muestra solo la pregunta general
            }
            return sMensaje;
        }


        public DataTable fun_listar()
        {
            return fun_convertir_a_tabla(dao.fun_obtener_todos());
        }

        public DataTable fun_listar_planificaciones()
        {
            return dao.fun_obtener_planificaciones_combo();
        }

        public DataTable fun_listar_actividades(int iIdPlanificacion)
        {
            if (iIdPlanificacion <= 0) return new DataTable();
            return dao.fun_obtener_actividades_por_planificacion(iIdPlanificacion);
        }

        public string[] fun_obtener_estados()
        {
            return (string[])arrEstados.Clone();
        }


        private Cls_Cronograma fun_armar(int iIdCronograma, int iIdPlanificacion, int iIdActividad,
                                         string sNombreTarea, string sDescripcion, DateTime dFechaInicio,
                                         DateTime dFechaFin, string sResponsable, string sEstado,
                                         string sObservaciones)
        {
            return new Cls_Cronograma
            {
                PkIdCronograma = iIdCronograma,
                FkIdPlanificacion = iIdPlanificacion,
                FkIdActividadProyecto = iIdActividad,
                NombreTarea = sNombreTarea == null ? "" : sNombreTarea.Trim(),
                Descripcion = fun_texto_o_nulo(sDescripcion),     // vacio -> NULL en la BD
                FechaInicio = dFechaInicio.Date,
                FechaFin = dFechaFin.Date,
                Responsable = fun_texto_o_nulo(sResponsable),
                Estado = string.IsNullOrWhiteSpace(sEstado) ? sEstadoPorDefecto : sEstado.Trim(),
                Observaciones = fun_texto_o_nulo(sObservaciones)
            };
        }

        private string fun_texto_o_nulo(string sTexto)
        {
            return string.IsNullOrWhiteSpace(sTexto) ? null : sTexto.Trim();
        }


        private DataTable fun_convertir_a_tabla(List<Cls_Cronograma> lista)
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("Id", typeof(int));
            tabla.Columns.Add("IdPlanificacion", typeof(int));
            tabla.Columns.Add("Planificacion", typeof(string));
            tabla.Columns.Add("IdActividad", typeof(int));
            tabla.Columns.Add("Actividad", typeof(string));
            tabla.Columns.Add("Tarea", typeof(string));
            tabla.Columns.Add("Descripcion", typeof(string));
            tabla.Columns.Add("FechaInicio", typeof(DateTime));
            tabla.Columns.Add("FechaFin", typeof(DateTime));
            tabla.Columns.Add("Responsable", typeof(string));
            tabla.Columns.Add("Estado", typeof(string));
            tabla.Columns.Add("Observaciones", typeof(string));

            foreach (Cls_Cronograma c in lista)
            {
                tabla.Rows.Add(c.PkIdCronograma, c.FkIdPlanificacion, c.NombrePlanificacion,
                               c.FkIdActividadProyecto, c.NombreActividad, c.NombreTarea,
                               (object)c.Descripcion ?? DBNull.Value,
                               c.FechaInicio, c.FechaFin,
                               (object)c.Responsable ?? DBNull.Value,
                               c.Estado,
                               (object)c.Observaciones ?? DBNull.Value);
            }
            return tabla;
        }


        // Reglas de negocio
        private string fun_validar(Cls_Cronograma cronograma)
        {
            if (cronograma.FkIdPlanificacion <= 0)
                return "Debe seleccionar una planificación.";
            if (cronograma.FkIdActividadProyecto <= 0)
                return "Debe seleccionar una actividad del proyecto.";
            if (string.IsNullOrWhiteSpace(cronograma.NombreTarea))
                return "El nombre de la tarea es obligatorio.";
            if (cronograma.NombreTarea.Length > 100)
                return "El nombre de la tarea no puede exceder 100 caracteres.";
            if (cronograma.Responsable != null && cronograma.Responsable.Length > 100)
                return "El responsable no puede exceder 100 caracteres.";
            if (!arrEstados.Contains(cronograma.Estado))
                return "El estado seleccionado no es válido.";
            if (cronograma.FechaFin < cronograma.FechaInicio)
                return "La fecha de fin no puede ser anterior a la fecha de inicio.";

            try
            {
                if (!dao.fun_actividad_pertenece_a_planificacion(cronograma.FkIdPlanificacion,
                                                                 cronograma.FkIdActividadProyecto))
                    return "La actividad seleccionada no pertenece al proyecto de esa planificación.";
            }
            catch (Exception ex)
            {
                return "Error al validar la actividad: " + ex.Message;
            }

            return null;
        }
    }
}
//Fin del código de "Pablo José Quiroa Martínez" con carné: "0901-22-2929" en la fecha de: "20/10/2026"