using System.Drawing;
using System.Windows.Forms;

namespace Capa_Vista_Auditoria
{
    /// <summary>
    /// Paleta de colores del menú del MDI de Auditoría, a juego con la pantalla
    /// de login (fondo azul marino oscuro y acento verde de "Iniciar sesión").
    /// Al asignarse como Renderer del MenuStrip (ver Frm_MDI_Auditoria.Designer.cs),
    /// cualquier ToolStripMenuItem que se agregue después --sin necesidad de
    /// tocar código-- hereda automáticamente estos mismos colores.
    /// </summary>
    public class Cls_TemaMenuAuditoria : ProfessionalColorTable
    {
        private static readonly Color FondoOscuro = Color.FromArgb(15, 27, 52);
        private static readonly Color FondoOscuroHeader = Color.FromArgb(8, 17, 35);
        private static readonly Color FondoCampos = Color.FromArgb(25, 42, 70);
        private static readonly Color VerdeAcento = Color.FromArgb(0, 150, 105);
        private static readonly Color VerdeAcentoClaro = Color.FromArgb(0, 175, 120);
        private static readonly Color VerdeAcentoOscuro = Color.FromArgb(0, 120, 85);
        private static readonly Color BordeAzulado = Color.FromArgb(35, 52, 80);
        private static readonly Color SeparadorClaro = Color.FromArgb(60, 80, 110);

        // Barra del menú principal
        public override Color MenuStripGradientBegin => FondoOscuro;
        public override Color MenuStripGradientEnd => FondoOscuro;

        // Franja de íconos dentro de los desplegables
        public override Color ImageMarginGradientBegin => FondoCampos;
        public override Color ImageMarginGradientMiddle => FondoCampos;
        public override Color ImageMarginGradientEnd => FondoCampos;

        // Fondo de los menús desplegables
        public override Color ToolStripDropDownBackground => FondoOscuro;

        // Ítem resaltado (hover) -> mismo verde del botón "Iniciar sesión"
        public override Color MenuItemSelected => VerdeAcento;
        public override Color MenuItemSelectedGradientBegin => VerdeAcento;
        public override Color MenuItemSelectedGradientEnd => VerdeAcento;
        public override Color MenuItemBorder => VerdeAcentoClaro;

        // Ítem presionado (click)
        public override Color MenuItemPressedGradientBegin => VerdeAcentoOscuro;
        public override Color MenuItemPressedGradientMiddle => VerdeAcentoOscuro;
        public override Color MenuItemPressedGradientEnd => VerdeAcentoOscuro;

        // Bordes y separadores
        public override Color MenuBorder => FondoOscuroHeader;
        public override Color SeparatorDark => SeparadorClaro;
        public override Color SeparatorLight => FondoCampos;

        // Borde de los desplegables
        public override Color ToolStripBorder => BordeAzulado;
    }
}
