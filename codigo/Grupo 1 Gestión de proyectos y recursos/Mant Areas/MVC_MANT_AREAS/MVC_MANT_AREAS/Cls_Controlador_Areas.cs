using System.Data;
using Capa_Modelo_Areas;

namespace Capa_Controlador_Areas
{
    public class Cls_Controlador_Areas
    {
        private Cls_Dao_Areas dao = new Cls_Dao_Areas();

        public DataTable funcObtenerAreas()
        {
            return dao.funcObtenerAreas();
        }

        public DataTable funcObtenerProyectos()
        {
            return dao.funcObtenerProyectos();
        }

        public bool funcGuardarArea(int idArea, int idProyecto, string nombre, string descripcion, string estado)
        {
            Cls_Area area = new Cls_Area(idArea, idProyecto, nombre, descripcion, estado);
            return dao.funcGuardarArea(area);
        }

        public bool funcActualizarArea(int idArea, int idProyecto, string nombre, string descripcion, string estado)
        {
            Cls_Area area = new Cls_Area(idArea, idProyecto, nombre, descripcion, estado);
            return dao.funcActualizarArea(area);
        }

        public bool funcBorrarArea(int idArea)
        {
            return dao.funcBorrarArea(idArea);
        }
    }
}