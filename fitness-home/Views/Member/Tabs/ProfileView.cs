using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace fitness_home.Views.Member.Components.Views
{
    public partial class ProfileView : UserControl
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

        public ProfileView()
        {
            InitializeComponent();
        }

        // ** Event: Triggered when the control is first loaded. 
        private void ProfileView_Load(object sender, EventArgs e)
        {
            // Apply rounded corners to the main panel
            panel_content.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel_content.Width, panel_content.Height, 12, 12));
        }

        // ** Event: Triggered when the form is resized.
        private void ProfileView_Resize(object sender, EventArgs e)
        {
            // Redraw rounded corners of the main panel as it's being resized
            panel_content.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel_content.Width, panel_content.Height, 12, 12));
        }
    }
}
