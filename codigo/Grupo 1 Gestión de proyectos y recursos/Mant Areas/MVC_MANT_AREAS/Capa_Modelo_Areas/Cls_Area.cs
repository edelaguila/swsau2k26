namespace Capa_Modelo_Areas
{
    public class Cls_Area
    {
        public int Pk_Id_Area { get; set; }
        public int Fk_Id_Proyecto { get; set; }
        public string Cmp_Nombre_Area { get; set; }
        public string Cmp_Descripcion_Area { get; set; }
        public string Cmp_Estado_Area { get; set; }

        public Cls_Area() { }

        public Cls_Area(int idArea, int idProyecto, string nombre, string descripcion, string estado)
        {
            Pk_Id_Area = idArea;
            Fk_Id_Proyecto = idProyecto;
            Cmp_Nombre_Area = nombre;
            Cmp_Descripcion_Area = descripcion;
            Cmp_Estado_Area = estado;
        }
    }
}