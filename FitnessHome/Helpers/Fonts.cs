using System;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace FitnessHome.Helpers
{
    public static class Fonts
    {
        private static bool _initialized = false;
        private static readonly PrivateFontCollection _fontCollection = new PrivateFontCollection();

        public static FontFamily RajdhaniLight { get; private set; }
        public static FontFamily RajdhaniRegular { get; private set; }
        public static FontFamily RajdhaniMedium { get; private set; }
        public static FontFamily RajdhaniSemiBold { get; private set; }
        public static FontFamily RajdhaniBold { get; private set; }

        public static void Init()
        {
            if (_initialized) return;

            // Load fonts from embedded byte arrays
            RajdhaniLight = LoadFontFromBytes(Properties.Resources.RajdhaniLight);
            RajdhaniRegular = LoadFontFromBytes(Properties.Resources.RajdhaniRegular);
            RajdhaniMedium = LoadFontFromBytes(Properties.Resources.RajdhaniMedium);
            RajdhaniSemiBold = LoadFontFromBytes(Properties.Resources.RajdhaniSemiBold);
            RajdhaniBold = LoadFontFromBytes(Properties.Resources.RajdhaniBold);

            _initialized = true;
        }

        private static FontFamily LoadFontFromBytes(byte[] fontData)
        {
            IntPtr fontPtr = Marshal.AllocCoTaskMem(fontData.Length);
            try
            {
                Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
                _fontCollection.AddMemoryFont(fontPtr, fontData.Length);

                // Validate the last added font exists
                var families = _fontCollection.Families;
                if (families.Length == 0)
                    throw new InvalidOperationException("Failed to load font family from bytes.");

                return families[^1]; // Get the last loaded font
            }
            finally
            {
                Marshal.FreeCoTaskMem(fontPtr);
            }
        }

        public static Font Create(FontFamily family, float size, FontStyle style = FontStyle.Regular)
        {
            if (family == null)
                throw new ArgumentNullException(nameof(family), "Font family must be initialized.");

            return new Font(family, size, style, GraphicsUnit.Point);
        }

        public static void ApplyTextSmoothing(Graphics g)
        {
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
        }
    }
}
