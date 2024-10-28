using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;

namespace fitness_home.Helpers
{
    internal class RoundedCorners
    {
        // Code required to create rounded rectangle panels
        // Source: https://stackoverflow.com/questions/38632035/winforms-smooth-the-rounded-edges-for-panel
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        // Applies rounded corners around selected panels
        public static void Apply(params Panel[] panels)
        {
            foreach (Panel panel in panels)
            {
                panel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel.Width, panel.Height, 12, 12));
            }
        }
    }
}
