// Empieza codigo hecho por Maria Morales 0901-22-1226 el dia 07/10/2026
using Capa_Modelo_Rubrica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Capa_Controlador_Rubrica
{
    // Controlador del mantenimiento de tbl_rubrica (aplicación 515).
    // La Vista solo conoce esta clase: no se exponen tipos del Modelo (se usan DataTable y tipos simples).
    public class Cls_Controlador_Rubrica
    {
        private readonly Cls_RubricaDAO gDao = new Cls_RubricaDAO();

        // Lista de rúbricas para el DataGridView
        public DataTable fun_listar()
        {
            List<Cls_Rubrica> lstRubricas = gDao.fun_listar();

            DataTable dtRubricas = new DataTable();
            dtRubricas.Columns.Add("Id", typeof(int));
            dtRubricas.Columns.Add("IdCronograma", typeof(int));
            dtRubricas.Columns.Add("Cronograma", typeof(string));
            dtRubricas.Columns.Add("Nombre", typeof(string));
            dtRubricas.Columns.Add("Descripcion", typeof(string));
            dtRubricas.Columns.Add("Objetivo", typeof(string));

            foreach (Cls_Rubrica oRubrica in lstRubricas)
            {
                dtRubricas.Rows.Add(oRubrica.pIdRubrica, oRubrica.pIdCronograma, oRubrica.pNombreCronograma,
                    oRubrica.pNombre, oRubrica.pDescripcion, oRubrica.pObjetivo);
            }
            return dtRubricas;
        }

        // Columnas: Id, Texto, Info
        public DataTable fun_listar_cronogramas()
        {
            return gDao.fun_listar_cronogramas();
        }

        // Reglas de texto compartidas con la Vista (validación al escribir)
        public static bool fun_caracter_valido_nombre(char cCaracter)
        {
            return char.IsLetterOrDigit(cCaracter) || char.IsControl(cCaracter)
                || cCaracter == ' ' || ".,-()/".IndexOf(cCaracter) >= 0;
        }

        public (bool bOk, string sMensaje) fun_guardar(int iIdRubrica, int iIdCronograma, string sNombre,
            string sDescripcion, string sObjetivo)
        {
            Cls_Rubrica oRubrica = new Cls_Rubrica
            {
                pIdRubrica = iIdRubrica,
                pIdCronograma = iIdCronograma,
                pNombre = (sNombre ?? "").Trim(),
                pDescripcion = (sDescripcion ?? "").Trim(),
                pObjetivo = (sObjetivo ?? "").Trim()
            };

            try
            {
                string sError = fun_validar(oRubrica);
                if (sError != null) return (false, sError);

                bool bNuevo = iIdRubrica == 0;
                if (bNuevo) gDao.pro_insertar(oRubrica); else gDao.pro_actualizar(oRubrica);
                return (true, bNuevo ? "Rúbrica registrada correctamente." : "Rúbrica actualizada correctamente.");
            }
            catch (OdbcException ex)
            {
                return (false, fun_traducir_error(ex));
            }
        }

        public (bool bOk, string sMensaje) fun_eliminar(int iIdRubrica)
        {
            if (iIdRubrica <= 0) return (false, "Seleccione una rúbrica para eliminar.");
            try
            {
                gDao.pro_eliminar(iIdRubrica);
                return (true, "Rúbrica eliminada correctamente.");
            }
            catch (OdbcException ex)
            {
                return (false, fun_traducir_error(ex));
            }
        }

        // Reglas de negocio (se validan contra la BD para que funcionen aunque otro usuario haya guardado)
        private string fun_validar(Cls_Rubrica oRubrica)
        {
            if (oRubrica.pIdCronograma <= 0) return "Seleccione un cronograma.";
            if (oRubrica.pNombre.Length == 0) return "El nombre de la rúbrica es obligatorio.";
            if (oRubrica.pNombre.Length < 3) return "El nombre de la rúbrica debe tener al menos 3 caracteres.";
            if (oRubrica.pNombre.Length > 100) return "El nombre no puede superar 100 caracteres.";
            foreach (char cCaracter in oRubrica.pNombre)
                if (!fun_caracter_valido_nombre(cCaracter))
                    return "El nombre contiene caracteres no permitidos.";
            if (!Regex.IsMatch(oRubrica.pNombre, @"\p{L}"))
                return "El nombre debe contener al menos una letra.";

            if (oRubrica.pDescripcion.Length > 1000) return "La descripción no puede superar 1000 caracteres.";
            if (oRubrica.pObjetivo.Length > 1000) return "El objetivo no puede superar 1000 caracteres.";

            if (gDao.fun_existe_nombre(oRubrica.pIdCronograma, oRubrica.pNombre, oRubrica.pIdRubrica))
                return "Ya existe una rúbrica con ese nombre en el cronograma seleccionado.";

            return null;
        }

        // Con el driver MySQL ODBC, NativeError trae el código de error de MySQL
        private string fun_traducir_error(OdbcException ex)
        {
            int iCodigo = ex.Errors.Count > 0 ? ex.Errors[0].NativeError : 0;
            string sTexto = ex.Errors.Count > 0 ? ex.Errors[0].Message : ex.Message;

            switch (iCodigo)
            {
                case 1062: // Registro duplicado
                    return "Ya existe un registro con esos datos.";
                case 1451: // FK: tbl_tabla_ponderacion (o asignaciones de sus actividades) sin cascade
                    return "No se puede eliminar: la rúbrica ya tiene evaluaciones (ponderaciones) o asignaciones registradas.";
                case 1452: // FK: el cronograma ya no existe
                    return "El cronograma seleccionado ya no existe. Use Refrescar.";
                case 1406: // Dato demasiado largo
                    return "Alguno de los textos supera el tamaño permitido.";
                default:
                    return "Error de base de datos: " + sTexto;
            }
        }
    }
}

// Termina codigo hecho por Maria Morales 0901-22-1226 el dia 07/10/2026