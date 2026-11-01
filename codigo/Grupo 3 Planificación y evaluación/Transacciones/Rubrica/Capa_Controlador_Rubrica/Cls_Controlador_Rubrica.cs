// Empieza codigo hecho por Maria Morales 0901-22-1226 el dia 07/10/2026
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Modelo_Rubrica;

namespace Capa_Controlador_Rubrica
{
    public class Cls_Controlador_Rubrica
    {
        private readonly Cls_RubricaDAO dao = new Cls_RubricaDAO();

        public string Guardar(int idCronograma, string nombre, string descripcion, string objetivo)
        {
            Cls_Rubrica r = Armar(0, idCronograma, nombre, descripcion, objetivo);

            string validacion = Validar(r);
            if (validacion != null) return validacion;

            try
            {
                return dao.Insertar(r) ? "OK" : "No se pudo guardar la rúbrica.";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public string Modificar(int id, int idCronograma, string nombre, string descripcion, string objetivo)
        {
            if (id <= 0) return "Seleccione una rúbrica para modificar.";

            Cls_Rubrica r = Armar(id, idCronograma, nombre, descripcion, objetivo);

            string validacion = Validar(r);
            if (validacion != null) return validacion;

            try
            {
                return dao.Actualizar(r) ? "OK" : "No se pudo actualizar la rúbrica.";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public string Eliminar(int id)
        {
            if (id <= 0) return "Seleccione una rúbrica para eliminar.";

            try
            {
                return dao.Eliminar(id) ? "OK" : "No se pudo eliminar la rúbrica.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public DataTable Listar()
        {
            return ConvertirATabla(dao.ObtenerTodas());
        }

        public DataTable Buscar(string texto)
        {
            List<Cls_Rubrica> lista = string.IsNullOrWhiteSpace(texto)
                ? dao.ObtenerTodas()
                : dao.BuscarPorNombre(texto);
            return ConvertirATabla(lista);
        }

        public DataTable ListarCronogramas()
        {
            return dao.ObtenerCronogramasCombo();
        }


        private Cls_Rubrica Armar(int id, int idCronograma, string nombre, string descripcion, string objetivo)
        {
            return new Cls_Rubrica
            {
                PkIdRubrica = id,
                FkIdCronograma = idCronograma,
                NombreRubrica = nombre == null ? "" : nombre.Trim(),
                DescripcionRubrica = descripcion == null ? "" : descripcion.Trim(),
                ObjetivoRubrica = objetivo == null ? "" : objetivo.Trim()
            };
        }

        private DataTable ConvertirATabla(List<Cls_Rubrica> lista)
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("Id", typeof(int));
            tabla.Columns.Add("IdCronograma", typeof(int));
            tabla.Columns.Add("Nombre", typeof(string));
            tabla.Columns.Add("Descripcion", typeof(string));
            tabla.Columns.Add("Objetivo", typeof(string));

            foreach (Cls_Rubrica r in lista)
            {
                tabla.Rows.Add(r.PkIdRubrica, r.FkIdCronograma, r.NombreRubrica,
                               r.DescripcionRubrica, r.ObjetivoRubrica);
            }
            return tabla;
        }


        private string Validar(Cls_Rubrica r)
        {
            if (r.FkIdCronograma <= 0)
                return "Debe seleccionar un cronograma.";
            if (string.IsNullOrWhiteSpace(r.NombreRubrica))
                return "El nombre de la rúbrica es obligatorio.";
            if (r.NombreRubrica.Length > 100)
                return "El nombre no puede exceder 100 caracteres.";
            return null;
        }
    }
}

// Termina codigo hecho por Maria Morales 0901-22-1226 el dia 07/10/2026