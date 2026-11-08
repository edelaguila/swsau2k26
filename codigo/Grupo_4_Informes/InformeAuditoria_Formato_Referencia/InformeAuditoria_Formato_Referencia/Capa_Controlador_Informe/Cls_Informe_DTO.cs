using System;
using System.Collections.Generic;

namespace Capa_Controlador_Informe
{
    // Los objetos DTO son lo único que recibe la Vista.
    public class Cls_Informe_Resumen_DTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string TextoInforme { get { return "#" + Id + " - " + Titulo; } }
    }

    public class Cls_Checklist_DTO
    {
        public string Actividad { get; set; }
        public bool Entregado { get; set; }
        public string EstadoTexto { get { return Entregado ? "Sí" : "No"; } }
    }

    public class Cls_Revision_DTO
    {
        public string Actividad { get; set; }
        public string Positivos { get; set; }
        public string ImagenPositivos { get; set; }
        public string Correcciones { get; set; }
        public string ImagenCorrecciones { get; set; }
        public string Recomendaciones { get; set; }
        public string ImagenRecomendaciones { get; set; }
    }

    public class Cls_Ponderacion_DTO
    {
        public string Auditado { get; set; }
        public string Criterio { get; set; }
        public decimal? PesoEsperado { get; set; }
        public decimal CalificacionPorcentaje { get; set; }
        public decimal CalificacionPonderada { get; set; }
        public string Comentarios { get; set; }
    }

    public class Cls_Grafica_DTO
    {
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        public string DatosJson { get; set; }
    }

    public class Cls_Informe_DTO
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
        public List<Cls_Checklist_DTO> Checklist { get; private set; }
        public List<Cls_Revision_DTO> Revisiones { get; private set; }
        public List<Cls_Ponderacion_DTO> Ponderaciones { get; private set; }
        public List<Cls_Grafica_DTO> Graficas { get; private set; }

        public Cls_Informe_DTO()
        {
            Checklist = new List<Cls_Checklist_DTO>();
            Revisiones = new List<Cls_Revision_DTO>();
            Ponderaciones = new List<Cls_Ponderacion_DTO>();
            Graficas = new List<Cls_Grafica_DTO>();
        }
    }
}
