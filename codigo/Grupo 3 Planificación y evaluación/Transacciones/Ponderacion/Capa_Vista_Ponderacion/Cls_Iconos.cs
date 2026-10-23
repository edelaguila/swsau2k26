// Juan Carlos Sandoval Quej, carné: 0901-22-4170 fecha de: "21/10/2026"
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Capa_Vista_Ponderacion
{
    public static class Cls_Iconos
    {
        public const int iTamano = 24;

        public static Bitmap fun_guardar(Color color)
        {
            return fun_crear(color, (g, oBrocha, oBlanco) =>
            {
                g.FillRectangle(oBrocha, 3, 3, 18, 18);       // cuerpo del disquete
                g.FillRectangle(oBlanco, 7, 3, 10, 6);        // ventana superior
                g.FillRectangle(oBlanco, 6, 13, 12, 8);       // etiqueta inferior
                g.FillRectangle(oBrocha, 13, 4, 2, 4);        // pestaña
            });
        }

        public static Bitmap fun_modificar(Color color)
        {
            return fun_crear(color, (g, oBrocha, oBlanco) =>
            {
                g.FillPolygon(oBrocha, new[]
                {
                    new Point(16, 3), new Point(21, 8), new Point(9, 20),
                    new Point(3, 21), new Point(4, 15)
                });                                   
                g.FillPolygon(oBlanco, new[]
                {
                    new Point(14, 6), new Point(16, 8), new Point(8, 16), new Point(6, 14)
                });                                   
            });
        }

        public static Bitmap fun_eliminar(Color color)
        {
            return fun_crear(color, (g, oBrocha, oBlanco) =>
            {
                g.FillRectangle(oBrocha, 9, 2, 6, 3);        
                g.FillRectangle(oBrocha, 3, 5, 18, 3);        
                g.FillPolygon(oBrocha, new[]
                {
                    new Point(5, 9), new Point(19, 9), new Point(18, 22), new Point(6, 22)
                });                                         
                g.FillRectangle(oBlanco, 8, 11, 2, 9);      
                g.FillRectangle(oBlanco, 14, 11, 2, 9);
            });
        }

        public static Bitmap fun_limpiar(Color color)
        {
            return fun_crear(color, (g, oBrocha, oBlanco) =>
            {
                g.FillPolygon(oBrocha, new[]
                {
                    new Point(14, 2), new Point(22, 10), new Point(11, 21), new Point(3, 13)
                });                                    
                g.FillPolygon(oBlanco, new[]
                {
                    new Point(9, 10), new Point(13, 14), new Point(11, 16), new Point(7, 12)
                });                                        
                g.FillRectangle(oBrocha, 3, 21, 18, 2);       
            });
        }

        private delegate void Dibujo(Graphics g, Brush oBrocha, Brush oBlanco);

        private static Bitmap fun_crear(Color color, Dibujo oDibujo)
        {
            Bitmap bmpIcono = new Bitmap(iTamano, iTamano);
            using (Graphics g = Graphics.FromImage(bmpIcono))
            using (Brush oBrocha = new SolidBrush(color))
            using (Brush oBlanco = new SolidBrush(Color.White))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.Transparent);
                oDibujo(g, oBrocha, oBlanco);
            }
            return bmpIcono;
        }
    }
}

