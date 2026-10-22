using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_controlador_pauditado;
using Capa_modelo_pauditado;

namespace Capa_controlador_pauditado
{

    public class Cls_Controlador_pauditado
    {
        private readonly cls_modelo_pauditado modelo = new cls_modelo_pauditado();

        public DataTable CargarProyectos() { return modelo.ObtenerProyectos(); }
        public DataTable CargarAuditados() { return modelo.ObtenerAuditados(); }
        public DataTable CargarRegistros() { return modelo.ObtenerRegistros(); }

        // Devuelven un mensaje de error, o "" si todo salió bien
        public string Guardar(int idProyecto, int idAuditado, DateTime fecha)
        {
            string error = Validar(idProyecto, idAuditado, 0);
            if (error != "") return error;
            modelo.Insertar(idProyecto, idAuditado, fecha);
            return "";
        }

        public string Modificar(int id, int idProyecto, int idAuditado, DateTime fecha)
        {
            if (id <= 0) return "Seleccione un registro de la tabla.";
            string error = Validar(idProyecto, idAuditado, id);
            if (error != "") return error;
            modelo.Actualizar(id, idProyecto, idAuditado, fecha);
            return "";
        }

        public string Eliminar(int id)
        {
            if (id <= 0) return "Seleccione un registro de la tabla.";
            modelo.Eliminar(id);
            return "";
        }

        private string Validar(int idProyecto, int idAuditado, int idExcluir)
        {
            if (idProyecto <= 0) return "Seleccione un proyecto.";
            if (idAuditado <= 0) return "Seleccione un auditado.";
            if (modelo.Existe(idProyecto, idAuditado, idExcluir))
                return "Ese auditado ya está asignado a este proyecto.";
            return "";
        }
    }
}
