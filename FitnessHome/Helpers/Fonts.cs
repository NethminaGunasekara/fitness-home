using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.IO;

namespace FitnessHome.Helpers
{
    /// <summary>
    /// Provides static properties to access the custom fonts used in the application.<br/><br/>
    /// 
    /// Example usage:
    /// 
    /// <example>
    /// <code>
    /// label1.Font = new Font(Fonts.RajdhaniRegular, 24);
    /// </code>
    /// </example>
    /// </summary>
    public static class Fonts
    {
        private const int FR_PRIVATE = 0x10;
        private static bool _initialized = false;

        // Font families
        public static FontFamily RajdhaniLight { get; private set; }
        public static FontFamily RajdhaniRegular { get; private set; }
        public static FontFamily RajdhaniMedium { get; private set; }
        public static FontFamily RajdhaniSemiBold { get; private set; }
        public static FontFamily RajdhaniBold { get; private set; }

        /// <summary>
        /// Initializes the custom fonts used in the application.
        /// </summary>
        public static void Init()
        {
            if (_initialized)
                return;

            string fontsDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Fonts");
            Directory.CreateDirectory(fontsDir); // Ensure folder exists

            RajdhaniLight = LoadFontFromBytes(Properties.Resources.RajdhaniLight, fontsDir, "Rajdhani-Light.ttf", "Rajdhani");
            RajdhaniRegular = LoadFontFromBytes(Properties.Resources.RajdhaniRegular, fontsDir, "Rajdhani-Regular.ttf", "Rajdhani");
            RajdhaniMedium = LoadFontFromBytes(Properties.Resources.RajdhaniMedium, fontsDir, "Rajdhani-Medium.ttf", "Rajdhani");
            RajdhaniSemiBold = LoadFontFromBytes(Properties.Resources.RajdhaniSemiBold, fontsDir, "Rajdhani-SemiBold.ttf", "Rajdhani");
            RajdhaniBold = LoadFontFromBytes(Properties.Resources.RajdhaniBold, fontsDir, "Rajdhani-Bold.ttf", "Rajdhani");

            _initialized = true;
        }

        /// <summary>
        /// Saves font to a file, registers it as a private font, and returns its FontFamily.
        /// </summary>
        private static FontFamily LoadFontFromBytes(byte[] fontData, string outputDir, string fileName, string fontFamilyName)
        {
            string fontPath = Path.Combine(outputDir, fileName);

            // Write the .ttf file to disk if not already written
            if (!File.Exists(fontPath))
            {
                File.WriteAllBytes(fontPath, fontData);
            }

            int result = AddFontResourceEx(fontPath, FR_PRIVATE, IntPtr.Zero);
            if (result == 0)
                throw new Exception($"Failed to load font: {fontPath}");

            return new FontFamily(fontFamilyName);
        }

        [DllImport("gdi32.dll", SetLastError = true)]
        private static extern int AddFontResourceEx(string lpszFilename, uint fl, IntPtr pdv);
    }
}
