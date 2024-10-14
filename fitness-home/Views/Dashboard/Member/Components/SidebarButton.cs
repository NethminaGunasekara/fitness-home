using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace fitness_home.Views.Dashboard.Member.Components
{
    public partial class SidebarButton : UserControl
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

        private readonly bool ActiveButton;

        public SidebarButton(bool activeButton = false)
        {
            InitializeComponent();
            ActiveButton = activeButton;
        }

        // ** Event: When the control is first loaded
        private void SidebarButton_Load(object sender, EventArgs e)
        {
            // Make the "panel_button" a rounded rectangle
            panel_button.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel_button.Width,
            panel_button.Height, 12, 12));

            // If the current button is active, set the background color to #A1D200
            if(ActiveButton) panel_button.BackColor = Color.FromArgb(161, 210, 0);
        }

        // ** Event: When the mouse cursor enters the visible part of the control
        private void SidebarButton_MouseEnter(object sender, EventArgs e)
        {
            panel_button.BackColor = Color.FromArgb(161, 210, 0);
        }

        // ** Event: When the mouse cursor leaves the visible part of the control
        private void SidebarButton_MouseLeave(object sender, EventArgs e)
        {
            if (ActiveButton) return; // Exit the method if the current button is active

            panel_button.BackColor = Color.Black;
        }

        // ** Event: When the button is being resized
        private void SidebarButton_Resize(object sender, EventArgs e)
        {
            // Here, we re-calculate the size of the rounded rectangle as our control is resized
            panel_button.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel_button.Width,
            panel_button.Height, 12, 12));
        }
    }
}
