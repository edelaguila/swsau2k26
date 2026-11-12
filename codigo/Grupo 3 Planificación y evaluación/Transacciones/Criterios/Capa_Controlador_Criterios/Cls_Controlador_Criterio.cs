//Inicio de código de "Nombre del programador" con carné: "No_carné" en la fecha de: "11/11/2026"
using Capa_Modelo_Criterios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Text.RegularExpressions;

namespace Capa_Controlador_Criterios
{
    // Controlador del mantenimiento de tbl_criterios (aplicación 516).
    // La Vista solo conoce esta clase: no se exponen tipos del Modelo (se usan DataTable y tipos simples).
    public class Cls_Controlador_Criterio
    {
        // Observación de revisión (13/10/2026): no permitir dos criterios con el mismo porcentaje
        // en la misma rúbrica. Si el equipo decide que sí se permite, cambiar a false.
        public const bool B_PORCENTAJE_UNICO_POR_RUBRICA = true;

        private readonly Cls_Dao gDao = new Cls_Dao();

        // Lista de criterios para el DataGridView
        public DataTable fun_listar()
        {
            List<Cls_Criterio> lstCriterios = gDao.fun_listar();

            DataTable dtCriterios = new DataTable();
            dtCriterios.Columns.Add("Id", typeof(int));
            dtCriterios.Columns.Add("IdRubrica", typeof(int));
            dtCriterios.Columns.Add("Rubrica", typeof(string));
            dtCriterios.Columns.Add("Nombre", typeof(string));
            dtCriterios.Columns.Add("Porcentaje", typeof(int));
            dtCriterios.Columns.Add("Importancia", typeof(string));
            dtCriterios.Columns.Add("Descripcion", typeof(string));

            foreach (Cls_Criterio oCriterio in lstCriterios)
            {
                dtCriterios.Rows.Add(oCriterio.pIdCriterio, oCriterio.pIdRubrica, oCriterio.pNombreRubrica,
                    oCriterio.pNombre, (object)oCriterio.pPorcentaje ?? DBNull.Value,
                    oCriterio.pNivelImportancia, oCriterio.pDescripcion);
            }
            return dtCriterios;
        }

        public DataTable fun_listar_rubricas()
        {
            return gDao.fun_listar_rubricas();
        }

        // Porcentaje ya usado en la rúbrica, sin contar el criterio que se edita
        public int fun_suma_porcentajes(int iIdRubrica, int iIdCriterioExcluido)
        {
            if (iIdRubrica <= 0) return 0;
            try { return gDao.fun_suma_porcentajes(iIdRubrica, iIdCriterioExcluido); }
            catch (OdbcException) { return 0; }
        }

        // Reglas de texto compartidas con la Vista (validación al escribir)
        public static bool fun_caracter_valido_nombre(char cCaracter)
        {
            return char.IsLetterOrDigit(cCaracter) || char.IsControl(cCaracter)
                || cCaracter == ' ' || ".,-()/".IndexOf(cCaracter) >= 0;
        }

        public (bool bOk, string sMensaje) fun_guardar(int iIdCriterio, int iIdRubrica, string sNombre,
            int iPorcentaje, string sNivelImportancia, string sDescripcion)
        {
            Cls_Criterio oCriterio = new Cls_Criterio
            {
                pIdCriterio = iIdCriterio,
                pIdRubrica = iIdRubrica,
                pNombre = (sNombre ?? "").Trim(),
                pPorcentaje = iPorcentaje,
                pNivelImportancia = sNivelImportancia,
                pDescripcion = (sDescripcion ?? "").Trim()
            };

            try
            {
                string sError = fun_validar(oCriterio);
                if (sError != null) return (false, sError);

                bool bNuevo = iIdCriterio == 0;
                if (bNuevo) gDao.pro_insertar(oCriterio); else gDao.pro_actualizar(oCriterio);
                return (true, bNuevo ? "Criterio registrado correctamente." : "Criterio actualizado correctamente.");
            }
            catch (OdbcException ex)
            {
                return (false, fun_traducir_error(ex));
            }
        }

        public (bool bOk, string sMensaje) fun_eliminar(int iIdCriterio)
        {
            if (iIdCriterio <= 0) return (false, "Seleccione un criterio para eliminar.");
            try
            {
                gDao.pro_eliminar(iIdCriterio);
                return (true, "Criterio eliminado correctamente.");
            }
            catch (OdbcException ex)
            {
                return (false, fun_traducir_error(ex));
            }
        }

        // Reglas de negocio (se validan contra la BD para que funcionen aunque otro usuario haya guardado)
        private string fun_validar(Cls_Criterio oCriterio)
        {
            if (oCriterio.pIdRubrica <= 0) return "Seleccione una rúbrica.";
            if (oCriterio.pNombre.Length == 0) return "El nombre del criterio es obligatorio.";
            if (oCriterio.pNombre.Length < 3) return "El nombre del criterio debe tener al menos 3 caracteres.";
            if (oCriterio.pNombre.Length > 100) return "El nombre no puede superar 100 caracteres.";
            foreach (char cCaracter in oCriterio.pNombre)
                if (!fun_caracter_valido_nombre(cCaracter))
                    return "El nombre contiene caracteres no permitidos.";
            if (!Regex.IsMatch(oCriterio.pNombre, @"\p{L}"))
                return "El nombre debe contener al menos una letra.";

            int iPorcentaje = oCriterio.pPorcentaje ?? 0;
            if (iPorcentaje < 1 || iPorcentaje > 100) return "El porcentaje debe estar entre 1 y 100.";

            if (string.IsNullOrWhiteSpace(oCriterio.pNivelImportancia)) return "Seleccione el nivel de importancia.";
            if (oCriterio.pNivelImportancia != "Alta" && oCriterio.pNivelImportancia != "Media" && oCriterio.pNivelImportancia != "Baja")
                return "El nivel de importancia debe ser Alta, Media o Baja.";

            if (oCriterio.pDescripcion.Length > 1000) return "La descripción no puede superar 1000 caracteres.";

            if (gDao.fun_existe_nombre(oCriterio.pIdRubrica, oCriterio.pNombre, oCriterio.pIdCriterio))
                return "Ya existe un criterio con ese nombre en la rúbrica seleccionada.";

            if (B_PORCENTAJE_UNICO_POR_RUBRICA &&
                gDao.fun_existe_porcentaje(oCriterio.pIdRubrica, iPorcentaje, oCriterio.pIdCriterio))
                return "Ya existe un criterio con " + iPorcentaje + "% en esta rúbrica. Use un porcentaje distinto.";

            int iSuma = gDao.fun_suma_porcentajes(oCriterio.pIdRubrica, oCriterio.pIdCriterio);
            if (iSuma + iPorcentaje > 100)
                return "La suma de porcentajes de la rúbrica sería " + (iSuma + iPorcentaje)
                     + "%. Solo quedan " + (100 - iSuma) + "% disponibles.";

            return null;
        }

        // Con el driver MySQL ODBC, NativeError trae el código de error de MySQL
        private string fun_traducir_error(OdbcException ex)
        {
            int iCodigo = ex.Errors.Count > 0 ? ex.Errors[0].NativeError : 0;
            string sTexto = ex.Errors.Count > 0 ? ex.Errors[0].Message : ex.Message;

            switch (iCodigo)
            {
                case 1644: // SIGNAL de un trigger: quitar el prefijo del driver
                    int iPosicion = sTexto.LastIndexOf(']');
                    return iPosicion >= 0 ? sTexto.Substring(iPosicion + 1).Trim() : sTexto;
                case 1062: // UNIQUE (rúbrica, nombre)
                    return "Ya existe un criterio con ese nombre en la rúbrica seleccionada.";
                case 1451: // FK: tiene ponderaciones asociadas
                    return "No se puede eliminar: el criterio ya tiene evaluaciones registradas.";
                case 1452: // FK: la rúbrica ya no existe
                    return "La rúbrica seleccionada ya no existe. Use Refrescar.";
                case 3819: // CHECK
                    return "Alguno de los valores no cumple las restricciones (porcentaje o nivel de importancia).";
                default:
                    return "Error de base de datos: " + sTexto;
            }
        }
    }
}
//Fin del código de "Nombre del programador" con carné: "No_carné" en la fecha de: "11/11/2026"
