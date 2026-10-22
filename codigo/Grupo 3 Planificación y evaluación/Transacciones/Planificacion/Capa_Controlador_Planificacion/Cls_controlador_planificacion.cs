// Empieza codigo hecho por Pablo Quiroa 0901-22-2929 el dia 09/10/2026
using System;
using System.Collections.Generic;
using System.Data;
using Capa_Modelo_Planificacion;

namespace Capa_Controlador_Planificacion
{
    public class Cls_controlador_planificacion
    {
        private readonly Cls_planificacionDAO dao = new Cls_planificacionDAO();

        public string Guardar(int idProyecto, string nombre, string descripcion,
                              DateTime? fechaInicio, DateTime? fechaFin, string observaciones)
        {
            Cls_planificacion p = Armar(0, idProyecto, nombre, descripcion, fechaInicio, fechaFin, observaciones);

            string validacion = Validar(p);
            if (validacion != null) return validacion;

            try
            {
                return dao.Insertar(p) ? "OK" : "No se pudo guardar la planificación.";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public string Modificar(int id, int idProyecto, string nombre, string descripcion,
                                DateTime? fechaInicio, DateTime? fechaFin, string observaciones)
        {
            if (id <= 0) return "Seleccione una planificación para modificar.";

            Cls_planificacion p = Armar(id, idProyecto, nombre, descripcion, fechaInicio, fechaFin, observaciones);

            string validacion = Validar(p);
            if (validacion != null) return validacion;

            try
            {
                return dao.Actualizar(p) ? "OK" : "No se pudo actualizar la planificación.";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public string Eliminar(int id)
        {
            if (id <= 0) return "Seleccione una planificación para eliminar.";

            try
            {
                return dao.Eliminar(id) ? "OK" : "No se pudo eliminar la planificación.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // muestra cuantas tareas del cronograma se borran
        public string MensajeConfirmacionEliminar(int id)
        {
            string mensaje = "¿Está seguro de eliminar esta planificación?";
            try
            {
                int cantidad = dao.ContarCronogramas(id);
                if (cantidad > 0)
                    mensaje += "\nSe eliminarán también " + cantidad +
                               " tarea(s) del cronograma con sus rúbricas y criterios.";
            }
            catch
            {
                // Si no se pudo contar, se muestra solo la pregunta general
            }
            return mensaje;
        }

        public DataTable Listar()
        {
            return ConvertirATabla(dao.ObtenerTodas());
        }

        public DataTable ListarProyectos()
        {
            return dao.ObtenerProyectosCombo();
        }


        private Cls_planificacion Armar(int id, int idProyecto, string nombre, string descripcion,
                                        DateTime? fechaInicio, DateTime? fechaFin, string observaciones)
        {
            return new Cls_planificacion
            {
                PkIdPlanificacion = id,
                FkIdProyecto = idProyecto,
                NombrePlan = nombre == null ? "" : nombre.Trim(),
                Descripcion = TextoONulo(descripcion),          // vacio -> NULL en la BD
                FechaInicio = fechaInicio?.Date,
                FechaFin = fechaFin?.Date,
                Observaciones = TextoONulo(observaciones)
            };
        }

        private string TextoONulo(string texto)
        {
            return string.IsNullOrWhiteSpace(texto) ? null : texto.Trim();
        }

        private DataTable ConvertirATabla(List<Cls_planificacion> lista)
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("Id", typeof(int));
            tabla.Columns.Add("IdProyecto", typeof(int));
            tabla.Columns.Add("Proyecto", typeof(string));
            tabla.Columns.Add("Nombre", typeof(string));
            tabla.Columns.Add("Descripcion", typeof(string));
            tabla.Columns.Add("FechaInicio", typeof(DateTime));
            tabla.Columns.Add("FechaFin", typeof(DateTime));
            tabla.Columns.Add("Observaciones", typeof(string));

            foreach (Cls_planificacion p in lista)
            {
                tabla.Rows.Add(p.PkIdPlanificacion, p.FkIdProyecto, p.NombreProyecto, p.NombrePlan,
                               (object)p.Descripcion ?? DBNull.Value,
                               (object)p.FechaInicio ?? DBNull.Value,
                               (object)p.FechaFin ?? DBNull.Value,
                               (object)p.Observaciones ?? DBNull.Value);
            }
            return tabla;
        }


        // Reglas
        private string Validar(Cls_planificacion p)
        {
            if (p.FkIdProyecto <= 0)
                return "Debe seleccionar un proyecto.";
            if (string.IsNullOrWhiteSpace(p.NombrePlan))
                return "El nombre de la planificación es obligatorio.";
            if (p.NombrePlan.Length > 100)
                return "El nombre no puede exceder 100 caracteres.";
            if (p.FechaInicio.HasValue && p.FechaFin.HasValue && p.FechaFin.Value < p.FechaInicio.Value)
                return "La fecha de fin no puede ser anterior a la fecha de inicio.";
            return null;
        }
    }
}
// Termina codigo hecho por Pablo Quiroa 0901-22-2929 el dia 09/10/2026