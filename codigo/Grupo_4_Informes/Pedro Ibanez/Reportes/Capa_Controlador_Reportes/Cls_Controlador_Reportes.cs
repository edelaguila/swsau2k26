// Pedro Ibanez 19/10/2026 - Controlador de tbl_reporte
using System;
using System.Data;
using System.IO;
using System.Text;
using Capa_Modelo_Reportes;

namespace Capa_Controlador_Reportes
{
    public class Cls_Controlador_Reportes
    {
        private readonly MDL_ReporteDAO reporteDAO = new MDL_ReporteDAO();
        private const int iMAX_RUTA = 500;   // varchar(500) en tbl_reporte

        public DataTable fun_obtener_informes()
        {
            return reporteDAO.fun_obtener_informes();
        }

        public DataTable fun_obtener_actividades()
        {
            return reporteDAO.fun_obtener_actividades();
        }

        public DataTable fun_obtener_reportes()
        {
            return reporteDAO.fun_obtener_reportes();
        }

        public MDL_Reporte fun_obtener_reporte_por_id(int iIdReporte)
        {
            return reporteDAO.fun_obtener_reporte_por_id(iIdReporte);
        }

        // Devuelve true si se eliminó; en sMensaje va el resultado o el motivo del fallo
        public bool fun_eliminar_reporte(int? iIdReporte, out string sMensaje)
        {
            if (iIdReporte == null)
            {
                sMensaje = "No se pudo eliminar: no se ha seleccionado ningún reporte.";
                return false;
            }

            try
            {
                reporteDAO.fun_Eliminar_Reporte(iIdReporte.Value);
                sMensaje = "Reporte eliminado correctamente.";
                return true;
            }
            catch (Exception ex)
            {
                sMensaje = ex.Message;
                return false;
            }
        }

        // Devuelve true si se insertó; en sMensaje va el resultado o el motivo del fallo
        public bool fun_insertar_reporte(MDL_Reporte reporte, out string sMensaje)
        {
            string sErrores = fun_validar_reporte(reporte, false);
            if (sErrores != "")
            {
                sMensaje = "No se pudo guardar el reporte:" + sErrores;
                return false;
            }

            try
            {
                reporteDAO.fun_Insertar_Reporte(reporte);
                sMensaje = "Reporte guardado correctamente.";
                return true;
            }
            catch (Exception ex)
            {
                sMensaje = ex.Message;
                return false;
            }
        }

        // Devuelve true si se actualizó; en sMensaje va el resultado o el motivo del fallo
        public bool fun_modificar_reporte(MDL_Reporte reporte, out string sMensaje)
        {
            string sErrores = fun_validar_reporte(reporte, true);
            if (sErrores != "")
            {
                sMensaje = "No se pudo actualizar el reporte:" + sErrores;
                return false;
            }

            try
            {
                reporteDAO.fun_Modificar_Reporte(reporte);
                sMensaje = "Reporte actualizado correctamente.";
                return true;
            }
            catch (Exception ex)
            {
                sMensaje = ex.Message;
                return false;
            }
        }

        // Devuelve todos los errores encontrados, uno por línea; "" si el reporte es válido
        private string fun_validar_reporte(MDL_Reporte reporte, bool bEsModificacion)
        {
            if (reporte == null)
                return Environment.NewLine + "- No se recibieron datos del reporte.";

            StringBuilder sbErrores = new StringBuilder();

            if (bEsModificacion && reporte.Pk_id_reporte <= 0)
                sbErrores.AppendLine().Append("- Seleccione un reporte para modificar.");
            if (reporte.Fk_id_informe <= 0)
                sbErrores.AppendLine().Append("- Seleccione un informe.");
            if (reporte.Fk_id_actividad_rubrica <= 0)
                sbErrores.AppendLine().Append("- Seleccione una actividad.");

            pro_Validar_Texto(sbErrores, reporte.aspectos_positivos, "Aspectos positivos");
            pro_Validar_Ruta(sbErrores, reporte.imagen_aspectos_positivos, "Ruta de imagen de aspectos positivos");
            pro_Validar_Texto(sbErrores, reporte.correcciones, "Correcciones");
            pro_Validar_Ruta(sbErrores, reporte.imagen_correcciones, "Ruta de imagen de correcciones");
            pro_Validar_Texto(sbErrores, reporte.recomendaciones, "Sugerencias");
            pro_Validar_Ruta(sbErrores, reporte.imagen_recomendaciones, "Ruta de imagen de sugerencias");

            return sbErrores.ToString();
        }

        private void pro_Validar_Texto(StringBuilder sbErrores, string sValor, string sCampo)
        {
            if (string.IsNullOrWhiteSpace(sValor))
                sbErrores.AppendLine().Append("- " + sCampo + " es obligatorio.");
        }

        // La ruta es opcional (el DAO guarda '' si es nula); si viene, se valida largo y existencia
        private void pro_Validar_Ruta(StringBuilder sbErrores, string sRuta, string sCampo)
        {
            if (string.IsNullOrWhiteSpace(sRuta))
                return;
            if (sRuta.Length > iMAX_RUTA)
            {
                sbErrores.AppendLine().Append("- " + sCampo + " no puede tener más de " + iMAX_RUTA + " caracteres.");
                return;
            }
            if (!File.Exists(sRuta))
                sbErrores.AppendLine().Append("- " + sCampo + ": el archivo no existe.");
        }
    }
}
