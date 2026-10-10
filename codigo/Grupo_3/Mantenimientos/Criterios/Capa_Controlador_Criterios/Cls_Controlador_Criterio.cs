using Capa_Modelo_Criterios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Controlador_Criterios
{
    public class Cls_Controlador_Criterio
    {
        private readonly Cls_Dao dao = new Cls_Dao();
        private List<Cls_Criterio> ultimaLista = new List<Cls_Criterio>();

        // Lista de criterios lista para enlazar a un DataGridView
        public DataTable Listar()
        {
            ultimaLista = dao.Listar();

            var dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("IdRubrica", typeof(int));
            dt.Columns.Add("NombreRubrica", typeof(string));
            dt.Columns.Add("Nombre", typeof(string));
            dt.Columns.Add("Porcentaje", typeof(int));
            dt.Columns.Add("NivelImportancia", typeof(string));
            dt.Columns.Add("Descripcion", typeof(string));

            foreach (var c in ultimaLista)
            {
                dt.Rows.Add(c.Id, c.IdRubrica, c.NombreRubrica, c.Nombre,
                            (object)c.Porcentaje ?? DBNull.Value, c.NivelImportancia, c.Descripcion);
            }
            return dt;
        }

        public DataTable ListarRubricas() { return dao.ListarRubricas(); }

        // Porcentaje ya usado en una rúbrica (sin contar el criterio que se edita)
        public int SumaPorcentajes(int idRubrica, int idCriterioExcluido)
        {
            return ultimaLista.Where(c => c.IdRubrica == idRubrica && c.Id != idCriterioExcluido)
                              .Sum(c => c.Porcentaje ?? 0);
        }

        // Devuelve (éxito, mensaje) para que la vista solo muestre el resultado
        public (bool ok, string mensaje) Guardar(int id, int idRubrica, string nombre,
                                                 int? porcentaje, string nivelImportancia, string descripcion)
        {
            var c = new Cls_Criterio
            {
                Id = id,
                IdRubrica = idRubrica,
                Nombre = nombre,
                Porcentaje = porcentaje,
                NivelImportancia = nivelImportancia,
                Descripcion = descripcion
            };

            string error = Validar(c);
            if (error != null) return (false, error);

            try
            {
                bool nuevo = c.Id == 0;
                if (nuevo) dao.Insertar(c); else dao.Actualizar(c);
                return (true, nuevo ? "Criterio registrado correctamente." : "Criterio actualizado correctamente.");
            }
            catch (OdbcException ex)
            {
                return (false, TraducirError(ex));
            }
        }

        public (bool ok, string mensaje) Eliminar(int id)
        {
            try
            {
                dao.Eliminar(id);
                return (true, "Criterio eliminado correctamente.");
            }
            catch (OdbcException ex)
            {
                return (false, TraducirError(ex));
            }
        }

        private string Validar(Cls_Criterio c)
        {
            if (c.IdRubrica <= 0) return "Seleccione una rúbrica.";
            if (string.IsNullOrWhiteSpace(c.Nombre)) return "El nombre del criterio es obligatorio.";
            if (c.Nombre.Length > 100) return "El nombre no puede superar 100 caracteres.";
            if (c.Porcentaje.HasValue && (c.Porcentaje < 0 || c.Porcentaje > 100))
                return "El porcentaje debe estar entre 0 y 100.";
            return null;
        }

        // Con el driver MySQL ODBC, NativeError trae el código de error de MySQL
        private string TraducirError(OdbcException ex)
        {
            int codigo = ex.Errors.Count > 0 ? ex.Errors[0].NativeError : 0;
            string texto = ex.Errors.Count > 0 ? ex.Errors[0].Message : ex.Message;

            switch (codigo)
            {
                case 1644: // SIGNAL SQLSTATE '45000' (triggers): quitar el prefijo del driver
                    int i = texto.LastIndexOf(']');
                    return i >= 0 ? texto.Substring(i + 1).Trim() : texto;
                case 1062: // UNIQUE (rúbrica, nombre)
                    return "Ya existe un criterio con ese nombre en la rúbrica seleccionada.";
                case 1451: // FK: tiene ponderaciones asociadas
                    return "No se puede eliminar: el criterio ya tiene evaluaciones registradas.";
                case 3819: // CHECK
                    return "Alguno de los valores no cumple las restricciones (porcentaje o nivel de importancia).";
                default:
                    return "Error de base de datos: " + texto;
            }
        }

    }
}
