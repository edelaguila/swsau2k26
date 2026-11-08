using Capa_Controlador_Informe;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Capa_Vista_Informe
{
    /// <summary>
    /// Plantilla del informe de revisión, inspirada en el formato MC-04 aportado.
    /// Solo utiliza datos del DTO recibido desde el Controlador.
    /// No consulta la BD, no abre conexiones y no modifica registros.
    /// </summary>
    public static class Cls_Pdf_Informe
    {
        private const string AzulChecklist = "4FB2C6";
        private const string AzulNumero = "3398B0";
        private const string FilaClara = "DAEDF2";
        private const string FilaOscura = "B5DAE5";
        private const string AzulResultado = "0AABE0";
        private const string VerdeResultado = "08B76A";
        private const string GrisBorde = "808080";
        private const string GrisFirmas = "B0B0B0";
        private const string AzulLinea = "3669B1";
        private const string NaranjaLinea = "EE7B30";
        private static readonly CultureInfo Es = CultureInfo.GetCultureInfo("es-GT");

        public static void Generar(Cls_Informe_DTO datos, string destino)
        {
            if (datos == null) throw new ArgumentNullException(nameof(datos));
            if (string.IsNullOrWhiteSpace(destino)) throw new ArgumentException("Ruta PDF inválida.", nameof(destino));

            QuestPDF.Settings.License = LicenseType.Community; // Respetar condiciones de licencia aplicables.
            string codigo = "INF-" + datos.Id.ToString("D6", CultureInfo.InvariantCulture);
            string fecha = datos.Fecha.HasValue ? datos.Fecha.Value.ToString("dd-MM-yyyy", Es) : "—";
            string version = "1.0"; // Versión documental fija solicitada para este formato.
            string logo = Path.Combine(AppContext.BaseDirectory, "Assets", "Logo_Informe.png");
            var grupos = datos.Ponderaciones.GroupBy(x => x.Auditado ?? "").ToList();

            Document.Create(documento =>
            {
                // Página 1: portada sin encabezado; como la referencia.
                documento.Page(pagina =>
                {
                    pagina.Size(PageSizes.Letter);
                    pagina.MarginHorizontal(53);
                    pagina.MarginVertical(48);
                    pagina.DefaultTextStyle(t => t.FontFamily("Lato").FontSize(11));
                    pagina.Content().Column(col =>
                    {
                        col.Item().PaddingTop(105).AlignCenter().Text("INFORME DE REVISIÓN").Bold().FontSize(24);
                        col.Item().PaddingTop(20).AlignCenter().Text(Nulo(datos.Proyecto)).Bold().FontSize(17);
                        col.Item().PaddingTop(8).AlignCenter().Text(Nulo(datos.Titulo)).FontSize(14);
                        col.Item().PaddingTop(48).AlignCenter().Text("Auditor responsable:").Bold().FontSize(11);
                        col.Item().PaddingTop(8).AlignCenter().Text(Nulo(datos.Auditor)).FontSize(13);
                        col.Item().PaddingTop(62).AlignCenter().Text(fecha).FontSize(12);
                        col.Item().PaddingTop(10).AlignCenter().Text("Código del informe: " + codigo).FontSize(10);
                    });
                });

                // Página 2: índice con páginas calculadas por QuestPDF (no números fijos).
                documento.Page(pagina =>
                {
                    pagina.Size(PageSizes.Letter);
                    pagina.MarginHorizontal(62);
                    pagina.MarginVertical(45);
                    pagina.DefaultTextStyle(t => t.FontFamily("Lato").FontSize(10));
                    pagina.Content().Column(col =>
                    {
                        col.Spacing(10);
                        col.Item().PaddingBottom(24).AlignCenter().Text("Índice").Bold().FontSize(17);
                        if (datos.Checklist.Count > 0)
                            EntradaIndice(col, "Checklist", "sec-checklist", false);
                        if (datos.Revisiones.Count > 0)
                        {
                            EntradaIndice(col, "Primera Revisión", "sec-revisiones", false);
                            for (int i = 0; i < datos.Revisiones.Count; i++)
                                EntradaIndice(col, datos.Revisiones[i].Actividad, "sec-revision-" + i, true);
                        }
                        if (datos.Ponderaciones.Count > 0)
                            EntradaIndice(col, "Aspectos para calificar y resultados", "sec-resultados", false);
                        EntradaIndice(col, "Firmas", "sec-firmas", false);
                    });
                });


                // Cada apartado interior utiliza una pagina de QuestPDF independiente.
                // Evitamos que PageBreak, Decoration o una tabla muy larga compitan
                // dentro de la misma Column: era el origen de la excepcion de layout.
                void AgregarPaginaInterior(Action<ColumnDescriptor> construir)
                {
                    documento.Page(pagina =>
                    {
                        pagina.Size(PageSizes.Letter);
                        pagina.MarginLeft(41);
                        pagina.MarginRight(41);
                        pagina.MarginTop(16);
                        pagina.MarginBottom(19);
                        pagina.DefaultTextStyle(t => t.FontFamily("Lato").FontSize(10));
                        pagina.Header().PaddingHorizontal(8).Column(header =>
                        {
                            header.Item().Height(75).Element(c => Encabezado(c, codigo, version, fecha, logo));
                            header.Item().Height(14);
                        });
                        pagina.Content().PaddingHorizontal(8).Column(col =>
                        {
                            col.Spacing(8);
                            construir(col);
                        });
                        pagina.Footer().PaddingHorizontal(8).PaddingBottom(1).AlignRight()
                            .Column(pie =>
                            {
                                pie.Item().AlignRight().Text("INFORME DE REVISIÓN").Bold().FontSize(9);
                                pie.Item().AlignRight().Text(codigo + "   Versión " + version).FontSize(9);
                            });
                    });
                }

                // Checklist repartido en bloques segun la altura estimada de las filas.
                // Cada bloque tiene su propio encabezado azul, sin repetir/eliminar datos.
                if (datos.Checklist.Count > 0)
                {
                    var bloques = ParticionarChecklist(datos.Checklist);
                    int inicio = 0;
                    for (int bloqueIndex = 0; bloqueIndex < bloques.Count; bloqueIndex++)
                    {
                        int indice = bloqueIndex;
                        int primerNumero = inicio;
                        List<Cls_Checklist_DTO> filas = bloques[bloqueIndex];
                        AgregarPaginaInterior(col =>
                        {
                            if (indice == 0)
                                col.Item().Section("sec-checklist").PaddingBottom(16)
                                    .AlignCenter().Text("Checklist").Bold().FontSize(13);
                            else
                                col.Item().PaddingBottom(16)
                                    .AlignCenter().Text("Checklist (continuación)").Bold().FontSize(13);
                            col.Item().Element(c => TablaChecklist(c, filas, primerNumero));
                        });
                        inicio += filas.Count;
                    }
                }

                // Cada revision comienza en pagina nueva, pero los parrafos e imagenes
                // pueden fluir a paginas siguientes si su contenido asi lo necesita.
                if (datos.Revisiones.Count > 0)
                {
                    for (int i = 0; i < datos.Revisiones.Count; i++)
                    {
                        int indice = i;
                        Cls_Revision_DTO revision = datos.Revisiones[i];
                        AgregarPaginaInterior(col =>
                        {
                            if (indice == 0)
                                col.Item().Section("sec-revisiones").PaddingBottom(8)
                                    .AlignCenter().Text("Primera Revisión.").Bold().FontSize(13);
                            col.Item().Section("sec-revision-" + indice).Column(sec =>
                            {
                                sec.Spacing(7);
                                sec.Item().Text(Nulo(revision.Actividad) + ":").Bold().FontSize(12);
                                sec.Item().Text("Revisor: " + Nulo(datos.Auditor)).Italic().FontSize(10);
                                sec.Item().Height(10);
                                Apartado(sec, "Aspectos positivos:", revision.Positivos, revision.ImagenPositivos, destino);
                                sec.Item().Height(9);
                                Apartado(sec, "Correcciones:", revision.Correcciones, revision.ImagenCorrecciones, destino);
                                sec.Item().Height(9);
                                Apartado(sec, "Sugerencias:", revision.Recomendaciones, revision.ImagenRecomendaciones, destino);
                            });
                        });
                    }
                }

                // Resultados: tabla compacta y grafica juntas cuando hay pocos criterios;
                // con muchas filas se divide la tabla y la grafica va en otra pagina.
                if (datos.Ponderaciones.Count > 0)
                {
                    int grupoNumero = 0;
                    foreach (var grupo in grupos)
                    {
                        List<Cls_Ponderacion_DTO> todasLasFilas = grupo.ToList();
                        decimal total = todasLasFilas.Sum(x => x.CalificacionPonderada);
                        bool juntarGrafica = todasLasFilas.Count <= 8;
                        int partes = (todasLasFilas.Count + 11) / 12;
                        for (int parte = 0; parte < partes; parte++)
                        {
                            int indiceGrupo = grupoNumero;
                            int indiceParte = parte;
                            List<Cls_Ponderacion_DTO> fragmento = todasLasFilas
                                .Skip(parte * 12).Take(12).ToList();
                            AgregarPaginaInterior(col =>
                            {
                                if (indiceGrupo == 0 && indiceParte == 0)
                                    col.Item().Section("sec-resultados")
                                        .Text("Aspectos para calificar y resultados:").Bold().FontSize(12);
                                else
                                    col.Item().Text("Aspectos para calificar y resultados (continuación):")
                                        .Bold().FontSize(12);
                                col.Item().Text("Revisor: " + Nulo(datos.Auditor)).Italic();
                                if (grupos.Count > 1)
                                    col.Item().Text("Auditado: " + Nulo(grupo.Key)).Bold();
                                col.Item().Element(c => TablaResultados(c, fragmento, total));
                                if (juntarGrafica)
                                {
                                    col.Item().PaddingTop(10).AlignCenter().Text("Resultados de evaluación")
                                        .FontSize(10).FontColor("777777");
                                    // Ajustar la grafica al ancho, sin imponer altura fija.
                                    // La altura se calcula con la proporcion del SVG (780 x 310),
                                    // evitando el conflicto de medidas cuando aumenta el numero de criterios.
                                    col.Item().AlignCenter().MaxWidth(480)
                                        .Svg(ConstruirGraficaSvg(todasLasFilas)).FitWidth();
                                    col.Item().AlignCenter().Text("Esperado: peso registrado | Alcanzado: calificación ponderada registrada")
                                        .FontSize(7).FontColor("666666");
                                }
                            });
                        }
                        if (!juntarGrafica)
                        {
                            AgregarPaginaInterior(col =>
                            {
                                col.Item().Text("Resultados de evaluación: " + Nulo(grupo.Key)).Bold().FontSize(12);
                                // No usar Height(260) aqui: las restricciones de altura
                                // pueden entrar en conflicto con el SVG para listas extensas.
                                // Se dimensiona por ancho y QuestPDF calcula su altura real.
                                col.Item().PaddingTop(16).AlignCenter().MaxWidth(480)
                                    .Svg(ConstruirGraficaSvg(todasLasFilas)).FitWidth();
                                col.Item().AlignCenter().Text("Esperado: peso registrado | Alcanzado: calificación ponderada registrada")
                                    .FontSize(8).FontColor("666666");
                            });
                        }
                        grupoNumero++;
                    }
                }

                // La pagina final de firmas no queda atrapada tras un PageBreak de
                // otra columna. No se crean firmas ni personas inexistentes.
                AgregarPaginaInterior(col =>
                {
                    col.Item().Section("sec-firmas").PaddingTop(21)
                        .Element(c => TablaFirmas(c, datos, fecha));
                });
            }).GeneratePdf(destino);
        }

        private static void EntradaIndice(ColumnDescriptor col, string nombre, string seccion, bool subnivel)
        {
            col.Item().PaddingLeft(subnivel ? 17 : 0).SectionLink(seccion).Row(fila =>
            {
                fila.RelativeItem().Text(nombre ?? "").FontSize(subnivel ? 9 : 10);
                fila.ConstantItem(45).AlignRight().Text(t =>
                {
                    t.BeginPageNumberOfSection(seccion);
                });
            });
        }

        private static void Encabezado(IContainer contenedor, string codigo, string version, string fecha, string logo)
        {
            contenedor.Table(tabla =>
            {
                tabla.ColumnsDefinition(columnas =>
                {
                    columnas.ConstantColumn(148);
                    columnas.RelativeColumn();
                    columnas.ConstantColumn(67);
                    columnas.ConstantColumn(99);
                });
                var celdaLogo = tabla.Cell().Row(1).Column(1).RowSpan(2)
                    .Border(0.7f).BorderColor(GrisBorde).Height(69).Padding(8);
                if (File.Exists(logo))
                    celdaLogo.Image(logo).FitArea();
                else
                    celdaLogo.AlignCenter().AlignMiddle().Text("AUDITORÍA").Bold().FontSize(17);

                tabla.Cell().Row(1).Column(2).Height(35).Border(0.7f).BorderColor(GrisBorde)
                    .Padding(4).Column(c =>
                    {
                        c.Item().Text("Nombre:").FontSize(9);
                        c.Item().AlignCenter().Text("INFORME DE REVISIÓN").Bold().FontSize(9);
                    });
                tabla.Cell().Row(1).Column(3).ColumnSpan(2).Border(0.7f).BorderColor(GrisBorde)
                    .Padding(5).Text(t => { t.Span("Código: "); t.Span(codigo).Bold(); });
                tabla.Cell().Row(2).Column(2).Border(0.7f).BorderColor(GrisBorde)
                    .Padding(3).Column(c =>
                    {
                        c.Item().Text("Rige a partir de:").FontSize(9);
                        c.Item().AlignCenter().Text(fecha).Bold().FontSize(9);
                    });
                tabla.Cell().Row(2).Column(3).Border(0.7f).BorderColor(GrisBorde)
                    .Padding(3).Column(c =>
                    {
                        c.Item().Text("Versión:").FontSize(9);
                        c.Item().AlignCenter().Text(version).Bold().FontSize(9);
                    });
                tabla.Cell().Row(2).Column(4).Border(0.7f).BorderColor(GrisBorde)
                    .Padding(3).Text(t =>
                    {
                        t.Span("Página "); t.CurrentPageNumber(); t.Span(" de "); t.TotalPages();
                    });
            });
        }


        // Paginas cortas en lugar de una tabla gigante dentro de Decoration.
        // Cada fila conserva colores, numeracion global y marca de entrega.
        private static void TablaChecklist(IContainer contenedor, List<Cls_Checklist_DTO> checklist, int inicio)
        {
            contenedor.Column(columna =>
            {
                columna.Spacing(0);
                columna.Item().Row(fila =>
                {
                    CeldaEncabezado(fila.ConstantItem(54), "Numeral");
                    CeldaEncabezado(fila.RelativeItem(), "Aspecto");
                    CeldaEncabezado(fila.ConstantItem(75), "Entregado");
                });
                for (int i = 0; i < checklist.Count; i++)
                {
                    var actividad = checklist[i];
                    int numero = inicio + i + 1;
                    string fondo = (inicio + i) % 2 == 0 ? FilaOscura : FilaClara;
                    columna.Item().Row(fila =>
                    {
                        fila.ConstantItem(54)
                            .Background(AzulNumero).BorderBottom(0.6f).BorderColor(Colors.White)
                            .PaddingVertical(2).PaddingHorizontal(4).AlignCenter()
                            .Text(numero.ToString()).FontColor(Colors.White).FontSize(9);
                        fila.RelativeItem()
                            .Background(fondo).BorderBottom(0.6f).BorderColor(Colors.White)
                            .PaddingVertical(2).PaddingHorizontal(4)
                            .Text(Nulo(actividad.Actividad)).FontSize(9);
                        fila.ConstantItem(75)
                            .Background(fondo).BorderBottom(0.6f).BorderColor(Colors.White)
                            .PaddingVertical(2).PaddingHorizontal(4).AlignCenter()
                            .Text(actividad.Entregado ? "X" : "").FontSize(10);
                    });
                }
            });
        }

        // Estimacion conservadora: columna Aspecto de ~385 puntos, fuente Lato 9.
        // No se descarta ningun registro: solo se mueve al siguiente bloque.
        private static List<List<Cls_Checklist_DTO>> ParticionarChecklist(List<Cls_Checklist_DTO> checklist)
        {
            var paginas = new List<List<Cls_Checklist_DTO>>();
            var actual = new List<Cls_Checklist_DTO>();
            int altoEstimado = 0;
            foreach (var actividad in checklist)
            {
                string nombre = actividad.Actividad ?? "";
                int lineas = 0;
                foreach (string linea in nombre.Replace("\r", "").Split('\n'))
                    lineas += Math.Max(1, (int)Math.Ceiling(linea.Length / 55.0));
                int altoFila = 9 + Math.Max(1, lineas) * 13;
                if (actual.Count > 0 && (altoEstimado + altoFila > 505 || actual.Count >= 24))
                {
                    paginas.Add(actual);
                    actual = new List<Cls_Checklist_DTO>();
                    altoEstimado = 0;
                }
                actual.Add(actividad);
                altoEstimado += altoFila;
            }
            if (actual.Count > 0) paginas.Add(actual);
            return paginas;
        }

        private static void CeldaEncabezado(IContainer celda, string texto)
        {
            celda.Background(AzulChecklist).PaddingVertical(4).PaddingHorizontal(4)
                .AlignCenter().Text(texto).FontSize(9).FontColor(Colors.White).Bold();
        }

        private static void Apartado(ColumnDescriptor columna, string titulo, string texto, string imagen, string rutaDestino)
        {
            if (string.IsNullOrWhiteSpace(texto) && string.IsNullOrWhiteSpace(imagen)) return;
            columna.Item().PaddingBottom(4).Text(titulo).Bold().FontSize(10);
            if (!string.IsNullOrWhiteSpace(texto))
            {
                string[] parrafos = texto.Replace("\r", "").Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string original in parrafos)
                {
                    string renglon = original.Trim();
                    if (renglon.StartsWith("• ")) renglon = renglon.Substring(2);
                    else if (renglon.StartsWith("- ")) renglon = renglon.Substring(2);
                    if (renglon.Length == 0) continue;
                    columna.Item().PaddingLeft(21).Row(fila =>
                    {
                        fila.ConstantItem(12).Text("•").FontSize(10);
                        fila.RelativeItem().Text(renglon).FontSize(10).Justify();
                    });
                }
            }
            if (!string.IsNullOrWhiteSpace(imagen))
            {
                // Puede haber varias imágenes separadas por '|': cada una se dibuja
                // con el mismo estilo de siempre, una debajo de otra.
                string[] imagenes = imagen.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string original in imagenes)
                {
                    string unaImagen = original.Trim();
                    if (unaImagen.Length == 0) continue;
                    string ruta = ResolverImagen(unaImagen, rutaDestino);
                    if (ruta != null)
                    {
                        // La captura mantiene proporciones, no se estira ni se recorta.
                        columna.Item().PaddingTop(8).AlignCenter().MaxWidth(425).MaxHeight(220)
                            .Image(ruta).FitArea();
                    }
                    else
                    {
                        columna.Item().Text("Evidencia registrada (no disponible): " + Path.GetFileName(unaImagen))
                            .FontSize(8).Italic().FontColor("777777");
                    }
                }
            }
        }

        private static string ResolverImagen(string ruta, string destino)
        {
            if (string.IsNullOrWhiteSpace(ruta)) return null;
            string extension = Path.GetExtension(ruta).ToLowerInvariant();
            if (extension != ".png" && extension != ".jpg" && extension != ".jpeg" && extension != ".webp" && extension != ".bmp")
                return null;
            // Acepta rutas absolutas, relativas a EXE y relativas al directorio de salida.
            string[] candidatos = {
                ruta,
                Path.Combine(AppContext.BaseDirectory, ruta.TrimStart(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)),
                Path.Combine(Path.GetDirectoryName(destino) ?? "", ruta.TrimStart(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar))
            };
            foreach (string candidato in candidatos)
            {
                try { if (File.Exists(candidato)) return candidato; }
                catch (Exception) { /* Ruta registrada inválida: se omite la imagen. */ }
            }
            return null;
        }

        private static void TablaResultados(IContainer contenedor, List<Cls_Ponderacion_DTO> filas, decimal total)
        {
            contenedor.Column(col =>
            {
                col.Item().Row(fila =>
                {
                    fila.RelativeItem().AlignCenter().Text("Primera Revisión").Bold().FontSize(9);
                    fila.ConstantItem(100).Background(AzulResultado).AlignCenter().Padding(3)
                        .Text("Total: " + total.ToString("0.##", Es)).FontColor(Colors.White).Bold().FontSize(8);
                });
                col.Item().Table(tabla =>
                {
                    tabla.ColumnsDefinition(c =>
                    {
                        c.ConstantColumn(39);
                        c.RelativeColumn();
                        c.ConstantColumn(65);
                        c.ConstantColumn(65);
                    });
                    tabla.Header(c =>
                    {
                        ResultadoCabecera(c.Cell(), "Numeral");
                        ResultadoCabecera(c.Cell(), "Aspecto");
                        ResultadoCabecera(c.Cell(), "Esperado");
                        ResultadoCabecera(c.Cell(), "Alcanzado");
                    });
                    for (int i = 0; i < filas.Count; i++)
                    {
                        var fila = filas[i];
                        tabla.Cell().Background(AzulResultado).Border(0.5f).BorderColor("FFFFFF")
                            .Padding(3).AlignCenter().Text((i + 1).ToString()).FontSize(8).FontColor(Colors.White);
                        tabla.Cell().Background(VerdeResultado).Border(0.5f).BorderColor("FFFFFF")
                            .Padding(3).Text(Nulo(fila.Criterio)).FontSize(8);
                        tabla.Cell().Border(0.5f).BorderColor("B6B6B6").Padding(3).AlignCenter()
                            .Text(fila.PesoEsperado.HasValue ? FormatoPorcentaje(fila.PesoEsperado.Value) : "—").FontSize(8);
                        tabla.Cell().Border(0.5f).BorderColor("B6B6B6").Padding(3).AlignCenter()
                            .Text(FormatoPorcentaje(fila.CalificacionPonderada)).FontSize(8);
                    }
                });
            });
        }

        private static void ResultadoCabecera(IContainer c, string texto)
        {
            c.Background(AzulResultado).Border(0.5f).BorderColor("FFFFFF")
                .Padding(4).Text(texto).FontColor(Colors.White).Bold().FontSize(8);
        }

        private static string FormatoPorcentaje(decimal numero)
        {
            return numero.ToString("0.##", Es) + "%";
        }

        private static string ConstruirGraficaSvg(List<Cls_Ponderacion_DTO> datos)
        {
            const double W = 780, H = 310;
            const double left = 62, right = 22, top = 28, bottom = 61;
            double plotW = W - left - right;
            double plotH = H - top - bottom;
            int cantidad = datos.Count;
            double max = datos.SelectMany(d => new[] { (double)(d.PesoEsperado ?? 0m), (double)d.CalificacionPonderada })
                .DefaultIfEmpty(1d).Max();
            double maxY = Math.Max(1d, Math.Ceiling(max / 5d) * 5d);
            var sb = new StringBuilder();
            sb.Append("<svg xmlns='http://www.w3.org/2000/svg' width='780' height='310' viewBox='0 0 780 310'>");
            sb.Append("<rect x='0' y='0' width='780' height='310' rx='10' fill='#FFFFFF' stroke='#DDDDDD'/>");
            for (int tick = 0; tick <= 5; tick++)
            {
                double y = top + plotH - plotH * tick / 5d;
                sb.Append("<line x1='").Append(F(left)).Append("' y1='").Append(F(y))
                    .Append("' x2='").Append(F(W - right)).Append("' y2='").Append(F(y))
                    .Append("' stroke='#E3E3E3' stroke-width='1'/>");
                sb.Append("<text x='").Append(F(left - 11)).Append("' y='").Append(F(y + 4))
                    .Append("' font-size='12' font-family='Lato' text-anchor='end' fill='#666666'>")
                    .Append(F(maxY * tick / 5d)).Append("%</text>");
            }
            string[] colores = { "#" + AzulLinea, "#" + NaranjaLinea };
            for (int serie = 0; serie < 2; serie++)
            {
                var puntos = new StringBuilder();
                for (int i = 0; i < cantidad; i++)
                {
                    double x = left + (cantidad <= 1 ? plotW / 2 : i * plotW / (cantidad - 1d));
                    double value = serie == 0 ? (double)(datos[i].PesoEsperado ?? 0m) : (double)datos[i].CalificacionPonderada;
                    double y = top + plotH * (1d - Math.Max(0d, value) / maxY);
                    puntos.Append(F(x)).Append(',').Append(F(y)).Append(' ');
                }
                sb.Append("<polyline points='").Append(puntos).Append("' fill='none' stroke='")
                    .Append(colores[serie]).Append("' stroke-width='3' stroke-linejoin='round'/>");
            }
            int intervalo = Math.Max(1, (int)Math.Ceiling(cantidad / 25d));
            for (int i = 0; i < cantidad; i += intervalo)
            {
                double x = left + (cantidad <= 1 ? plotW / 2 : i * plotW / (cantidad - 1d));
                sb.Append("<text x='").Append(F(x)).Append("' y='").Append(F(top + plotH + 16))
                    .Append("' text-anchor='middle' font-family='Lato' font-size='10' fill='#666666'>")
                    .Append(i + 1).Append("</text>");
            }
            sb.Append("<line x1='239' y1='282' x2='267' y2='282' stroke='#").Append(AzulLinea).Append("' stroke-width='3'/>");
            sb.Append("<text x='274' y='286' font-family='Lato' font-size='12' fill='#555555'>Esperado</text>");
            sb.Append("<line x1='390' y1='282' x2='418' y2='282' stroke='#").Append(NaranjaLinea).Append("' stroke-width='3'/>");
            sb.Append("<text x='425' y='286' font-family='Lato' font-size='12' fill='#555555'>Alcanzado</text>");
            sb.Append("</svg>");
            return sb.ToString();
        }

        private static string F(double n) { return n.ToString("0.##", CultureInfo.InvariantCulture); }
        private static string Nulo(string texto) { return string.IsNullOrWhiteSpace(texto) ? "—" : texto.Trim(); }

        private static void TablaFirmas(IContainer contenedor, Cls_Informe_DTO datos, string fecha)
        {
            contenedor.Table(tabla =>
            {
                tabla.ColumnsDefinition(c =>
                {
                    c.ConstantColumn(85);
                    c.ConstantColumn(94);
                    c.RelativeColumn();
                    c.ConstantColumn(88);
                    c.ConstantColumn(76);
                });
                tabla.Header(header =>
                {
                    foreach (string nombre in new[] { "Acción", "Cargo", "Nombre", "Fecha", "Firma" })
                        header.Cell().Background(GrisFirmas).Border(0.5f).BorderColor("AAAAAA")
                            .PaddingVertical(12).AlignCenter().Text(nombre).Bold().FontSize(9);
                });
                FirmaFila(tabla, "ELABORÓ", "Auditor", Nulo(datos.Auditor), fecha, "");
                FirmaFila(tabla, "REVISÓ", "", "", "", "");
                FirmaFila(tabla, "APROBÓ", "", "", "", "");
            });
        }

        private static void FirmaFila(TableDescriptor tabla, string accion, string cargo,
            string nombre, string fecha, string firma)
        {
            string[] celdas = { accion, cargo, nombre, fecha, firma };
            for (int i = 0; i < celdas.Length; i++)
            {
                var celda = tabla.Cell().Border(0.5f).BorderColor("BDBDBD")
                    .MinHeight(42).Padding(5).AlignMiddle().AlignCenter();
                if (i == 0) celda.Text(celdas[i]).Bold().FontSize(9);
                else celda.Text(celdas[i]).FontSize(9);
            }
        }
    }
}
