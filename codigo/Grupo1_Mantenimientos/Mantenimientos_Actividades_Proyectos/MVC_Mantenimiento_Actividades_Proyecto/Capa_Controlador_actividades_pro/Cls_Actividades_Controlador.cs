
/*
 * ============================================================
 * Área       : Gestión de Proyectos y Recursos
 * Componente : Actividades del Proyecto
 * Capa       : Controlador
 * Autor      : Danilo Mazariegos
 * Carné      : 0901-19-25059
 * Fecha      : 08/10/2026
 * Estándar   : ES-01 versión 1.5
 * ============================================================
 * Propósito:
 * Validar los datos y controlar las operaciones CRUD.
 * ============================================================
 */

using System;
using System.Data;
using Capa_Modelo_actividades_pro;

namespace Capa_Controlador_actividades_pro
{
    public class Cls_Actividades_Controlador
    {
        private readonly Cls_Actividades_Sentencias gModelo =
            new Cls_Actividades_Sentencias();

        // Resultado de una operación.
        public class Cls_Resultado_Operacion
        {
            public bool bExito { get; set; }
            public string sMensaje { get; set; }
        }

        // Consultar actividades.
        public DataTable fun_obtener_actividades()
        {
            return gModelo.fun_obtener_actividades();
        }

        // Consultar proyectos.
        public DataTable fun_obtener_proyectos()
        {
            return gModelo.fun_obtener_proyectos();
        }

        // Validación de campos.
        private string fun_validar(
            int iIdActividad,
            int iIdProyecto,
            string sNombre)
        {
            if (iIdActividad <= 0)
                return "El ID debe ser un entero positivo.";

            if (iIdProyecto <= 0)
                return "Debe seleccionar un proyecto.";

            if (string.IsNullOrWhiteSpace(sNombre))
                return "Ingrese el nombre de la actividad.";

            if (sNombre.Trim().Length > 100)
                return "El nombre no debe superar 100 caracteres.";

            if (!gModelo.fun_existe_proyecto(iIdProyecto))
                return "El proyecto seleccionado no existe.";

            return null;
        }

        // Guardar nueva actividad.
        public Cls_Resultado_Operacion fun_guardar_actividad(
            int iIdActividad,
            int iIdProyecto,
            string sNombre,
            string sDescripcion,
            string sObservaciones)
        {
            string sError = fun_validar(
                iIdActividad, iIdProyecto, sNombre);

            if (sError != null)
                return fun_resultado(false, sError);

            if (gModelo.fun_existe_actividad(iIdActividad))
                return fun_resultado(
                    false, "El ID ya está registrado.");

            int iFilas = gModelo.fun_insertar_actividad(
                iIdActividad,
                iIdProyecto,
                sNombre.Trim(),
                sDescripcion,
                sObservaciones);

            return fun_resultado(
                iFilas > 0,
                iFilas > 0
                    ? "Actividad guardada correctamente."
                    : "No se guardó la actividad.");
        }

        // Modificar actividad.
        public Cls_Resultado_Operacion fun_modificar_actividad(
            int iIdActividad,
            int iIdProyecto,
            string sNombre,
            string sDescripcion,
            string sObservaciones)
        {
            string sError = fun_validar(
                iIdActividad, iIdProyecto, sNombre);

            if (sError != null)
                return fun_resultado(false, sError);

            if (!gModelo.fun_existe_actividad(iIdActividad))
                return fun_resultado(
                    false, "La actividad no existe.");

            int iFilas = gModelo.fun_modificar_actividad(
                iIdActividad,
                iIdProyecto,
                sNombre.Trim(),
                sDescripcion,
                sObservaciones);

            return fun_resultado(
                iFilas > 0,
                iFilas > 0
                    ? "Actividad modificada correctamente."
                    : "No se aplicaron cambios.");
        }

        // Eliminar actividad.
        public Cls_Resultado_Operacion fun_eliminar_actividad(
            int iIdActividad)
        {
            if (iIdActividad <= 0)
                return fun_resultado(
                    false, "Seleccione una actividad válida.");

            if (!gModelo.fun_existe_actividad(iIdActividad))
                return fun_resultado(
                    false, "La actividad no existe.");

            int iFilas =
                gModelo.fun_eliminar_actividad(iIdActividad);

            return fun_resultado(
                iFilas > 0,
                iFilas > 0
                    ? "Actividad eliminada correctamente."
                    : "No se eliminó la actividad.");
        }

        // Crear resultado estandarizado.
        private Cls_Resultado_Operacion fun_resultado(
            bool bExito,
            string sMensaje)
        {
            return new Cls_Resultado_Operacion
            {
                bExito = bExito,
                sMensaje = sMensaje
            };
        }
    }
}
