using System;
using System.Collections.Generic;
using System.IO;

namespace Capa_Controlador_Informe
{
    /// <summary>
    /// Convierte las rutas de imagen registradas en tbl_reporte (formulario de Reportes de
    /// Pedro Ibanez) en rutas absolutas accesibles para el generador del PDF.
    ///
    /// Las imágenes se toman de la carpeta del módulo de Pedro Ibanez:
    ///     codigo/Grupo_4_Informes/Pedro Ibanez/Reportes/Imagenes_Reportes
    ///
    /// Orden de búsqueda para cada ruta registrada:
    ///   1. La ruta tal como está guardada (si es absoluta y existe en esta máquina).
    ///   2. La ruta relativa dentro de la carpeta de imágenes de Pedro Ibanez.
    ///   3. Solo el nombre del archivo dentro de la carpeta de imágenes (incluye subcarpetas),
    ///      útil cuando la BD guarda la ruta absoluta de otra computadora.
    /// Si no se encuentra, se devuelve la ruta original y el PDF muestra el aviso de
    /// "Evidencia registrada (no disponible)".
    /// </summary>
    public static class Cls_Resolver_Imagenes
    {
        public const string NombreCarpetaImagenes = "Imagenes_Reportes";
        private static readonly string[] SegmentosCarpetaPedro = { "Pedro Ibanez", "Reportes", NombreCarpetaImagenes };

        private static readonly object bloqueo = new object();
        private static bool carpetaBuscada;
        private static string carpetaImagenes;

        /// <summary>Carpeta de imágenes de Pedro Ibanez encontrada, o null si no existe.</summary>
        public static string CarpetaImagenes
        {
            get
            {
                lock (bloqueo)
                {
                    if (!carpetaBuscada)
                    {
                        carpetaImagenes = BuscarCarpeta();
                        carpetaBuscada = true;
                    }
                    return carpetaImagenes;
                }
            }
        }

        /// <summary>Separador de varias imágenes en una misma columna (formulario de Reportes).</summary>
        public const char Separador = '|';

        /// <summary>
        /// Resuelve un valor que puede traer varias imágenes separadas por '|'
        /// y devuelve las rutas resueltas unidas con el mismo separador.
        /// </summary>
        public static string ResolverLista(string valorRegistrado)
        {
            if (string.IsNullOrWhiteSpace(valorRegistrado)) return valorRegistrado;
            List<string> resueltas = new List<string>();
            foreach (string parte in valorRegistrado.Split(new[] { Separador, '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
            {
                string ruta = Resolver(parte);
                if (!string.IsNullOrWhiteSpace(ruta)) resueltas.Add(ruta);
            }
            return string.Join(Separador.ToString(), resueltas);
        }

        public static string Resolver(string rutaRegistrada)
        {
            if (string.IsNullOrWhiteSpace(rutaRegistrada)) return rutaRegistrada;
            string ruta = rutaRegistrada.Trim().Trim('"');

            try
            {
                if (Path.IsPathRooted(ruta) && File.Exists(ruta)) return ruta;

                string carpeta = CarpetaImagenes;
                if (carpeta == null) return ruta;

                // Ruta relativa (p. ej. "Imagenes_Reportes\foto.png" o "informe1\foto.png").
                if (!Path.IsPathRooted(ruta))
                {
                    string relativa = ruta.Replace('/', Path.DirectorySeparatorChar)
                                          .TrimStart(Path.DirectorySeparatorChar);
                    string prefijo = NombreCarpetaImagenes + Path.DirectorySeparatorChar;
                    if (relativa.StartsWith(prefijo, StringComparison.OrdinalIgnoreCase))
                        relativa = relativa.Substring(prefijo.Length);

                    string candidata = Path.Combine(carpeta, relativa);
                    if (File.Exists(candidata)) return Path.GetFullPath(candidata);
                }

                // Por nombre de archivo (la BD puede traer la ruta absoluta de otra computadora).
                string nombre = Path.GetFileName(ruta.Replace('/', '\\').Replace('\\', Path.DirectorySeparatorChar));
                if (!string.IsNullOrEmpty(nombre))
                {
                    string directa = Path.Combine(carpeta, nombre);
                    if (File.Exists(directa)) return directa;

                    foreach (string archivo in Directory.EnumerateFiles(carpeta, nombre, SearchOption.AllDirectories))
                        return archivo;
                }
            }
            catch (Exception)
            {
                // Ruta inválida o sin permisos: se deja la original para que el PDF muestre el aviso.
            }
            return ruta;
        }

        private static string BuscarCarpeta()
        {
            List<string> inicios = new List<string> { AppContext.BaseDirectory };
            try { inicios.Add(Directory.GetCurrentDirectory()); } catch (Exception) { }

            foreach (string inicio in inicios)
            {
                // Copia junto al ejecutable (si se distribuye la carpeta con el EXE).
                string local = Path.Combine(inicio, NombreCarpetaImagenes);
                if (Directory.Exists(local)) return local;

                // Subir por los directorios padre hasta encontrar la carpeta de Pedro Ibanez.
                DirectoryInfo dir = new DirectoryInfo(inicio);
                while (dir != null)
                {
                    string candidata = Path.Combine(dir.FullName, Path.Combine(SegmentosCarpetaPedro));
                    if (Directory.Exists(candidata)) return candidata;
                    dir = dir.Parent;
                }
            }
            return null;
        }
    }
}
