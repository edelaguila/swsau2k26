// Codigo empezado por: Maria Morales 0901-22-1226 el día 19/10/2026
using Capa_Modelo_Actividad;
using Capa_Modelo_Actividad_Rubrica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Controlador_Actividad_Rubrica
{

    public class Cls_Controlador_Actividad_Rubrica
    {
        private readonly Cls_Actividad_RubricaDAO gDao = new Cls_Actividad_RubricaDAO();

        // Lista para el DataGridView
        public DataTable fun_listar()
        {
            List<Cls_Actividad_Rubrica> lstRegistros = gDao.fun_listar();

            DataTable dtRegistros = new DataTable();
            dtRegistros.Columns.Add("Id", typeof(int));
            dtRegistros.Columns.Add("IdActividad", typeof(int));
            dtRegistros.Columns.Add("Actividad", typeof(string));
            dtRegistros.Columns.Add("IdRubrica", typeof(int));
            dtRegistros.Columns.Add("Rubrica", typeof(string));
            dtRegistros.Columns.Add("Estado", typeof(bool));
            dtRegistros.Columns.Add("EstadoTexto", typeof(string));

            foreach (Cls_Actividad_Rubrica oRegistro in lstRegistros)
            {
                dtRegistros.Rows.Add(oRegistro.pIdActividadRubrica, oRegistro.pIdActividad, oRegistro.pNombreActividad,
                    oRegistro.pIdRubrica, oRegistro.pNombreRubrica, oRegistro.pEstado,
                    oRegistro.pEstado ? "Activo" : "Inactivo");
            }
            return dtRegistros;
        }

        // Columnas: Id, Texto, Info
        public DataTable fun_listar_actividades()
        {
            return gDao.fun_listar_actividades();
        }

        // Columnas: Id, Texto, Info
        public DataTable fun_listar_rubricas()
        {
            return gDao.fun_listar_rubricas();
        }

        // Para avisar en pantalla (antes de guardar) que la combinación ya existe
        public bool fun_existe_combinacion(int iIdActividad, int iIdRubrica, int iIdExcluido)
        {
            if (iIdActividad <= 0 || iIdRubrica <= 0) return false;
            try { return gDao.fun_existe_combinacion(iIdActividad, iIdRubrica, iIdExcluido); }
            catch (OdbcException) { return false; }
        }

        public (bool bOk, string sMensaje) fun_guardar(int iIdActividadRubrica, int iIdActividad, int iIdRubrica, bool bActivo)
        {
            Cls_Actividad_Rubrica oRegistro = new Cls_Actividad_Rubrica
            {
                pIdActividadRubrica = iIdActividadRubrica,
                pIdActividad = iIdActividad,
                pIdRubrica = iIdRubrica,
                pEstado = bActivo
            };

            try
            {
                string sError = fun_validar(oRegistro);
                if (sError != null) return (false, sError);

                bool bNuevo = iIdActividadRubrica == 0;
                if (bNuevo) gDao.pro_insertar(oRegistro); else gDao.pro_actualizar(oRegistro);
                return (true, bNuevo ? "Actividad asignada a la rúbrica correctamente."
                                     : "Asignación actualizada correctamente.");
            }
            catch (OdbcException ex)
            {
                return (false, fun_traducir_error(ex));
            }
        }

        public (bool bOk, string sMensaje) fun_eliminar(int iIdActividadRubrica)
        {
            if (iIdActividadRubrica <= 0) return (false, "Seleccione un registro para eliminar.");
            try
            {
                gDao.pro_eliminar(iIdActividadRubrica);
                return (true, "Registro eliminado correctamente.");
            }
            catch (OdbcException ex)
            {
                return (false, fun_traducir_error(ex));
            }
        }

        // Reglas de negocio (se validan contra la BD para que funcionen aunque otro usuario haya guardado)
        private string fun_validar(Cls_Actividad_Rubrica oRegistro)
        {
            if (oRegistro.pIdActividad <= 0) return "Seleccione una actividad.";
            if (oRegistro.pIdRubrica <= 0) return "Seleccione una rúbrica.";

            if (gDao.fun_existe_combinacion(oRegistro.pIdActividad, oRegistro.pIdRubrica, oRegistro.pIdActividadRubrica))
                return "Esa actividad ya está asignada a la rúbrica seleccionada.";

            return null;
        }

        // Con el driver MySQL ODBC, NativeError trae el código de error de MySQL
        private string fun_traducir_error(OdbcException ex)
        {
            int iCodigo = ex.Errors.Count > 0 ? ex.Errors[0].NativeError : 0;
            string sTexto = ex.Errors.Count > 0 ? ex.Errors[0].Message : ex.Message;

            switch (iCodigo)
            {
                case 1062: // UNIQUE (actividad, rúbrica)
                    return "Esa actividad ya está asignada a la rúbrica seleccionada.";
                case 1451: // FK: tbl_asignacion, tbl_checklist o tbl_reporte la usan (sin cascade)
                    return "No se puede eliminar: el registro ya tiene asignaciones, checklist o reportes asociados. " +
                           "Puede marcarlo como Inactivo en su lugar.";
                case 1452: // FK: la actividad o la rúbrica ya no existen
                    return "La actividad o la rúbrica seleccionada ya no existe. Use Refrescar.";
                default:
                    return "Error de base de datos: " + sTexto;
            }
        }
    }
}
// Codigo terminado por: Maria Morales 0901-22-1226 el día 19/10/2026