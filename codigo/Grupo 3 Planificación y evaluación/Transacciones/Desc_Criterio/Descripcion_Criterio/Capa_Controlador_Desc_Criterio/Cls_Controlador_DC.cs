using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Modelo_Desc_Criterio;
using System.Data;
using System.Data.Odbc;

namespace Capa_Controlador_Desc_Criterio
{
    public class Cls_Controlador_DC
    {
        private readonly Cls_Dao_DescripcionCriterio gDao = new Cls_Dao_DescripcionCriterio();
        private List<Cls_DescripcionCriterio> gLista = new List<Cls_DescripcionCriterio>();
        private DataTable gEscalas = new DataTable();

        // Lista para el DataGridView. iIdCriterioFiltro = 0 muestra todo.
        public DataTable fun_listar(int iIdCriterioFiltro)
        {
            gLista = gDao.fun_listar();

            DataTable dtDescripciones = new DataTable();
            dtDescripciones.Columns.Add("Id", typeof(int));
            dtDescripciones.Columns.Add("IdCriterio", typeof(int));
            dtDescripciones.Columns.Add("IdEscala", typeof(int));
            dtDescripciones.Columns.Add("Criterio", typeof(string));
            dtDescripciones.Columns.Add("Porcentaje", typeof(int));
            dtDescripciones.Columns.Add("Nivel", typeof(string));
            dtDescripciones.Columns.Add("DescripcionDetallada", typeof(string));
            dtDescripciones.Columns.Add("EvidenciaRequerida", typeof(string));
            dtDescripciones.Columns.Add("Observaciones", typeof(string));

            foreach (Cls_DescripcionCriterio oDescripcion in gLista)
            {
                if (iIdCriterioFiltro > 0 && oDescripcion.pIdCriterio != iIdCriterioFiltro) continue;
                dtDescripciones.Rows.Add(oDescripcion.pIdDescripcion, oDescripcion.pIdCriterio, oDescripcion.pIdEscala,
                    oDescripcion.pNombreCriterio, oDescripcion.pPorcentajeEscala, oDescripcion.pNombreNivel,
                    oDescripcion.pDescripcionDetallada, oDescripcion.pEvidenciaRequerida, oDescripcion.pObservaciones);
            }
            return dtDescripciones;
        }

        public DataTable fun_listar_criterios()
        {
            return gDao.fun_listar_criterios();
        }

        public DataTable fun_listar_escalas()
        {
            gEscalas = gDao.fun_listar_escalas();
            return gEscalas;
        }

        // Resumen de cuántos niveles de la escala ya tienen descripción para el criterio
        public (string sTexto, bool bCompleto) fun_resumen_niveles(int iIdCriterio)
        {
            if (iIdCriterio <= 0 || gEscalas.Rows.Count == 0) return ("", false);

            List<string> lstFaltantes = new List<string>();
            int iDefinidos = 0;
            foreach (DataRow drEscala in gEscalas.Rows)
            {
                if (fun_nivel_definido(iIdCriterio, Convert.ToInt32(drEscala["Pk_Id_Escala"]))) iDefinidos++;
                else lstFaltantes.Add(drEscala["Cmp_Porcentaje_Escala"] + "%");
            }

            bool bCompleto = lstFaltantes.Count == 0;
            string sTexto = "Niveles definidos: " + iDefinidos + " de " + gEscalas.Rows.Count
                          + (bCompleto ? "  |  Criterio completo" : "  |  Faltan: " + string.Join(", ", lstFaltantes));
            return (sTexto, bCompleto);
        }

        // Primer nivel de la escala que aún no tiene descripción (0 si están todos)
        public int fun_primer_nivel_faltante(int iIdCriterio)
        {
            foreach (DataRow drEscala in gEscalas.Rows)
            {
                int iIdEscala = Convert.ToInt32(drEscala["Pk_Id_Escala"]);
                if (!fun_nivel_definido(iIdCriterio, iIdEscala)) return iIdEscala;
            }
            return 0;
        }

        public (bool bOk, string sMensaje) fun_guardar(int iIdDescripcion, int iIdCriterio, int iIdEscala,
            string sDescripcionDetallada, string sEvidenciaRequerida, string sObservaciones)
        {
            Cls_DescripcionCriterio oDescripcion = new Cls_DescripcionCriterio
            {
                pIdDescripcion = iIdDescripcion,
                pIdCriterio = iIdCriterio,
                pIdEscala = iIdEscala,
                pDescripcionDetallada = sDescripcionDetallada,
                pEvidenciaRequerida = sEvidenciaRequerida,
                pObservaciones = sObservaciones
            };

            string sError = fun_validar(oDescripcion);
            if (sError != null) return (false, sError);

            try
            {
                bool bNuevo = iIdDescripcion == 0;
                if (bNuevo) gDao.pro_insertar(oDescripcion); else gDao.pro_actualizar(oDescripcion);
                return (true, bNuevo ? "Descripción registrada correctamente." : "Descripción actualizada correctamente.");
            }
            catch (OdbcException ex)
            {
                return (false, fun_traducir_error(ex));
            }
        }

        public (bool bOk, string sMensaje) fun_eliminar(int iIdDescripcion)
        {
            try
            {
                gDao.pro_eliminar(iIdDescripcion);
                return (true, "Descripción eliminada correctamente.");
            }
            catch (OdbcException ex)
            {
                return (false, fun_traducir_error(ex));
            }
        }

        private bool fun_nivel_definido(int iIdCriterio, int iIdEscala)
        {
            foreach (Cls_DescripcionCriterio oDescripcion in gLista)
                if (oDescripcion.pIdCriterio == iIdCriterio && oDescripcion.pIdEscala == iIdEscala) return true;
            return false;
        }

        private string fun_validar(Cls_DescripcionCriterio oDescripcion)
        {
            if (oDescripcion.pIdCriterio <= 0) return "Seleccione un criterio.";
            if (oDescripcion.pIdEscala <= 0) return "Seleccione un nivel de la escala.";
            if (string.IsNullOrWhiteSpace(oDescripcion.pDescripcionDetallada))
                return "La descripción detallada es obligatoria.";
            return null;
        }

        // Con el driver MySQL ODBC, NativeError trae el código de error de MySQL
        private string fun_traducir_error(OdbcException ex)
        {
            int iCodigo = ex.Errors.Count > 0 ? ex.Errors[0].NativeError : 0;
            string sTexto = ex.Errors.Count > 0 ? ex.Errors[0].Message : ex.Message;

            switch (iCodigo)
            {
                case 1062: // UNIQUE (criterio, escala)
                    return "Ese nivel de la escala ya tiene una descripción para el criterio seleccionado.";
                case 1452: // FK: el criterio o la escala ya no existen
                    return "El criterio o el nivel seleccionado ya no existe. Actualice la lista.";
                case 1644: // SIGNAL de un trigger: quitar el prefijo del driver
                    int iPosicion = sTexto.LastIndexOf(']');
                    return iPosicion >= 0 ? sTexto.Substring(iPosicion + 1).Trim() : sTexto;
                default:
                    return "Error de base de datos: " + sTexto;
            }
        }
    }
}
