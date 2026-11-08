using System;
using System.Collections.Generic;

namespace Capa_Modelo_Informe
{
    public class Cls_Informe_Resumen
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
    }

    public class Cls_Checklist_Informe
    {
        public string Actividad { get; set; }
        public bool Entregado { get; set; }
    }

    public class Cls_Revision_Informe
    {
        public string Actividad { get; set; }
        public string Positivos { get; set; }
        public string ImagenPositivos { get; set; }
        public string Correcciones { get; set; }
        public string ImagenCorrecciones { get; set; }
        public string Recomendaciones { get; set; }
        public string ImagenRecomendaciones { get; set; }
    }

    public class Cls_Ponderacion_Informe
    {
        public string Auditado { get; set; }
        public string Criterio { get; set; }
        public decimal? PesoEsperado { get; set; }
        public decimal CalificacionPorcentaje { get; set; }
        public decimal CalificacionPonderada { get; set; }
        public string Comentarios { get; set; }
    }

    public class Cls_Grafica_Informe
    {
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        public string DatosJson { get; set; }
    }

    public class Cls_Datos_Informe
    {
        public int Id { get; set; }
        public int ProyectoId { get; set; }
        public string Titulo { get; set; }
        public DateTime? Fecha { get; set; }
        public string Estado { get; set; }
        public string Proyecto { get; set; }
        public string DescripcionProyecto { get; set; }
        public string ObjetivoProyecto { get; set; }
        public string Auditor { get; set; }

        public List<Cls_Checklist_Informe> Checklist { get; private set; }
        public List<Cls_Revision_Informe> Revisiones { get; private set; }
        public List<Cls_Ponderacion_Informe> Ponderaciones { get; private set; }
        public List<Cls_Grafica_Informe> Graficas { get; private set; }

        public Cls_Datos_Informe()
        {
            Checklist = new List<Cls_Checklist_Informe>();
            Revisiones = new List<Cls_Revision_Informe>();
            Ponderaciones = new List<Cls_Ponderacion_Informe>();
            Graficas = new List<Cls_Grafica_Informe>();
        }
    }
}
