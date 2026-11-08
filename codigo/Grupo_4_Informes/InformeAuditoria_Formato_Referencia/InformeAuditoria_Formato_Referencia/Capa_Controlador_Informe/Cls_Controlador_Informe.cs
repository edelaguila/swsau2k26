using System;
using System.Collections.Generic;
using Capa_Modelo_Informe;

namespace Capa_Controlador_Informe
{
    public class Cls_Controlador_Informe
    {
        private readonly Cls_Modelo_Informe modelo;

        public Cls_Controlador_Informe()
        {
            modelo = new Cls_Modelo_Informe();
        }

        public void ProbarConexion()
        {
            modelo.ProbarConexion();
        }

        public List<Cls_Informe_Resumen_DTO> ObtenerInformes()
        {
            List<Cls_Informe_Resumen_DTO> lista = new List<Cls_Informe_Resumen_DTO>();
            foreach (Cls_Informe_Resumen info in modelo.ListarInformes())
                lista.Add(new Cls_Informe_Resumen_DTO { Id = info.Id, Titulo = info.Titulo });
            return lista;
        }

        public Cls_Informe_DTO ObtenerInforme(int idInforme)
        {
            Cls_Datos_Informe origen = modelo.ObtenerInforme(idInforme);
            Cls_Informe_DTO destino = new Cls_Informe_DTO {
                Id = origen.Id, ProyectoId = origen.ProyectoId,
                Titulo = origen.Titulo, Fecha = origen.Fecha, Estado = origen.Estado,
                Proyecto = origen.Proyecto, DescripcionProyecto = origen.DescripcionProyecto,
                ObjetivoProyecto = origen.ObjetivoProyecto, Auditor = origen.Auditor
            };
            foreach (Cls_Checklist_Informe f in origen.Checklist)
                destino.Checklist.Add(new Cls_Checklist_DTO {
                    Actividad = f.Actividad, Entregado = f.Entregado
                });
            foreach (Cls_Revision_Informe f in origen.Revisiones)
                destino.Revisiones.Add(new Cls_Revision_DTO {
                    Actividad = f.Actividad, Positivos = f.Positivos,
                    // Las imágenes se toman de la carpeta de Pedro Ibanez (Imagenes_Reportes).
                    // Cada apartado puede traer varias imágenes separadas por '|'.
                    ImagenPositivos = Cls_Resolver_Imagenes.ResolverLista(f.ImagenPositivos),
                    Correcciones = f.Correcciones,
                    ImagenCorrecciones = Cls_Resolver_Imagenes.ResolverLista(f.ImagenCorrecciones),
                    Recomendaciones = f.Recomendaciones,
                    ImagenRecomendaciones = Cls_Resolver_Imagenes.ResolverLista(f.ImagenRecomendaciones)
                });
            foreach (Cls_Ponderacion_Informe f in origen.Ponderaciones)
                destino.Ponderaciones.Add(new Cls_Ponderacion_DTO {
                    Auditado = f.Auditado, Criterio = f.Criterio,
                    PesoEsperado = f.PesoEsperado, CalificacionPorcentaje = f.CalificacionPorcentaje,
                    CalificacionPonderada = f.CalificacionPonderada, Comentarios = f.Comentarios
                });
            foreach (Cls_Grafica_Informe f in origen.Graficas)
                destino.Graficas.Add(new Cls_Grafica_DTO {
                    Tipo = f.Tipo, Descripcion = f.Descripcion, DatosJson = f.DatosJson
                });
            return destino;
        }
    }
}
