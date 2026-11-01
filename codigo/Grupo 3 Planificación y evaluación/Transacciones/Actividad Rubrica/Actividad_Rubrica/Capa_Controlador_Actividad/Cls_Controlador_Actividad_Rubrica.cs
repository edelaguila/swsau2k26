// Codigo empezado por: Maria Morales 0901-22-1226 el día 19/10/2026
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Capa_Modelo_Actividad;

namespace Capa_Controlador_Actividad_Rubrica
{
    public class Cls_Controlador_Actividad
    {
        private readonly Cls_Actividad_RubricaDAO dao = new Cls_Actividad_RubricaDAO();

        public string Guardar(int idActividad, int idRubrica, bool activo)
        {
            Cls_Actividad_Rubrica a = Armar(0, idActividad, idRubrica, activo);

            string validacion = Validar(a);
            if (validacion != null) return validacion;

            try
            {
                return dao.Insertar(a) ? "OK" : "No se pudo guardar el registro.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Modificar(int id, int idActividad, int idRubrica, bool activo)
        {
            if (id <= 0) return "Seleccione un registro para modificar.";

            Cls_Actividad_Rubrica a = Armar(id, idActividad, idRubrica, activo);

            string validacion = Validar(a);
            if (validacion != null) return validacion;

            try
            {
                return dao.Actualizar(a) ? "OK" : "No se pudo actualizar el registro.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Eliminar(int id)
        {
            if (id <= 0) return "Seleccione un registro para eliminar.";

            try
            {
                return dao.Eliminar(id) ? "OK" : "No se pudo eliminar el registro.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public DataTable Listar()
        {
            return dao.ObtenerListado("");
        }

        public DataTable Buscar(string texto)
        {
            return dao.ObtenerListado(texto);
        }

        public DataTable ListarActividades()
        {
            return dao.ObtenerActividadesCombo();
        }

        public DataTable ListarRubricas()
        {
            return dao.ObtenerRubricasCombo();
        }

    
        private Cls_Actividad_Rubrica Armar(int id, int idActividad, int idRubrica, bool activo)
        {
            return new Cls_Actividad_Rubrica
            {
                PkIdActividadRubrica = id,
                FkIdActividadProyecto = idActividad,
                FkIdRubrica = idRubrica,
                EstadoActividadRubrica = activo
            };
        }

        private string Validar(Cls_Actividad_Rubrica a)
        {
            if (a.FkIdActividadProyecto <= 0)
                return "Debe seleccionar una actividad.";
            if (a.FkIdRubrica <= 0)
                return "Debe seleccionar una rúbrica.";
            return null;
        }
    }
}
// Codigo terminado por: Maria Morales 0901-22-1226 el día 19/10/2026