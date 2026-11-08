// Pedro Ibanez - Manejo de varias imágenes por apartado en tbl_reporte
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Capa_Controlador_Reportes
{
    /// <summary>
    /// Cada columna imagen_* de tbl_reporte puede guardar varias imágenes separadas por '|'
    /// (carácter que no es válido en rutas de Windows). Ej.: "captura1.png|informe2\foto.jpg".
    ///
    /// Las imágenes elegidas se copian a la carpeta compartida
    ///     Pedro Ibanez/Reportes/Imagenes_Reportes
    /// y se guarda solo la ruta relativa a esa carpeta, para que el informe PDF las encuentre
    /// en cualquier computadora y para no exceder el varchar(500) de la columna.
    /// </summary>
    public static class Cls_Imagenes_Reporte
    {
        public const char cSEPARADOR = '|';
        public const string sNOMBRE_CARPETA = "Imagenes_Reportes";
        public static readonly string[] EXTENSIONES = { ".png", ".jpg", ".jpeg", ".bmp", ".webp" };
        public const string sFILTRO_DIALOGO = "Imágenes|*.png;*.jpg;*.jpeg;*.bmp;*.webp";

        private static string sCarpetaCache;

        /// <summary>Carpeta Imagenes_Reportes (se crea si se encuentra la carpeta Reportes de Pedro). Null si no se ubica.</summary>
        public static string fun_Carpeta_Imagenes()
        {
            if (sCarpetaCache != null && Directory.Exists(sCarpetaCache)) return sCarpetaCache;

            string sBase = AppDomain.CurrentDomain.BaseDirectory;

            string sLocal = Path.Combine(sBase, sNOMBRE_CARPETA);
            if (Directory.Exists(sLocal)) return sCarpetaCache = sLocal;

            DirectoryInfo dir = new DirectoryInfo(sBase);
            while (dir != null)
            {
                string sReportes = Path.Combine(dir.FullName, "Pedro Ibanez", "Reportes");
                if (Directory.Exists(sReportes))
                {
                    string sCarpeta = Path.Combine(sReportes, sNOMBRE_CARPETA);
                    try { Directory.CreateDirectory(sCarpeta); } catch (Exception) { return null; }
                    return sCarpetaCache = sCarpeta;
                }
                dir = dir.Parent;
            }
            return null;
        }

        /// <summary>Separa el valor guardado en la BD en una lista de rutas (sin vacíos).</summary>
        public static List<string> fun_Separar(string sValor)
        {
            if (string.IsNullOrWhiteSpace(sValor)) return new List<string>();
            return sValor.Split(new[] { cSEPARADOR, '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                         .Select(s => s.Trim().Trim('"'))
                         .Where(s => s.Length > 0)
                         .ToList();
        }

        /// <summary>Une las rutas en el formato que se guarda en la BD.</summary>
        public static string fun_Unir(IEnumerable<string> lstRutas)
        {
            return string.Join(cSEPARADOR.ToString(),
                (lstRutas ?? Enumerable.Empty<string>()).Select(s => s.Trim()).Where(s => s.Length > 0));
        }

        /// <summary>Devuelve la ruta absoluta existente de una imagen guardada, o null si no se encuentra.</summary>
        public static string fun_Resolver(string sRuta)
        {
            if (string.IsNullOrWhiteSpace(sRuta)) return null;
            try
            {
                if (Path.IsPathRooted(sRuta))
                    return File.Exists(sRuta) ? sRuta : null;

                string sCarpeta = fun_Carpeta_Imagenes();
                if (sCarpeta == null) return null;
                string sCandidata = Path.Combine(sCarpeta, sRuta);
                return File.Exists(sCandidata) ? sCandidata : null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static bool fun_Extension_Valida(string sRuta)
        {
            string sExt = Path.GetExtension(sRuta ?? "").ToLowerInvariant();
            return EXTENSIONES.Contains(sExt);
        }

        /// <summary>
        /// Copia la imagen a Imagenes_Reportes y devuelve la ruta relativa a guardar.
        /// Si ya está dentro de la carpeta no se copia. Si la carpeta no existe, devuelve la ruta original.
        /// </summary>
        public static string fun_Copiar_A_Carpeta(string sRutaOrigen)
        {
            string sCarpeta = fun_Carpeta_Imagenes();
            if (sCarpeta == null) return sRutaOrigen;

            string sOrigen = Path.GetFullPath(sRutaOrigen);
            string sCarpetaCompleta = Path.GetFullPath(sCarpeta).TrimEnd(Path.DirectorySeparatorChar) + Path.DirectorySeparatorChar;

            // Ya está en la carpeta compartida: se guarda la ruta relativa
            if (sOrigen.StartsWith(sCarpetaCompleta, StringComparison.OrdinalIgnoreCase))
                return sOrigen.Substring(sCarpetaCompleta.Length);

            string sNombre = Path.GetFileNameWithoutExtension(sOrigen);
            string sExt = Path.GetExtension(sOrigen);
            string sDestino = Path.Combine(sCarpeta, sNombre + sExt);
            int iSufijo = 1;

            // Si ya existe un archivo con ese nombre y es el mismo contenido, se reutiliza
            while (File.Exists(sDestino))
            {
                if (fun_Mismo_Contenido(sOrigen, sDestino))
                    return Path.GetFileName(sDestino);
                sDestino = Path.Combine(sCarpeta, sNombre + "_" + iSufijo + sExt);
                iSufijo++;
            }

            File.Copy(sOrigen, sDestino);
            return Path.GetFileName(sDestino);
        }

        private static bool fun_Mismo_Contenido(string sA, string sB)
        {
            FileInfo a = new FileInfo(sA), b = new FileInfo(sB);
            if (a.Length != b.Length) return false;
            return File.ReadAllBytes(sA).SequenceEqual(File.ReadAllBytes(sB));
        }
    }
}
