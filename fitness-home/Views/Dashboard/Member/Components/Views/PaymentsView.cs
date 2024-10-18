using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace fitness_home.Views.Dashboard.Member.Components.Views
{
    public partial class PaymentsView : UserControl
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
        private void ApplyRoundedCorners()
        {
            // Initialize a list of pannels to apply rounded corners
            List<Panel> panelsToDraw = new List<Panel> { panel_content };

            SuspendLayout();

            // Apply rounded corners to all panels of the list above
            panelsToDraw.ForEach((Panel panel) =>
            {
                panel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel.Width, panel.Height, 12, 12));
            });

            ResumeLayout();
        }

        public PaymentsView()
        {
            InitializeComponent();
        }

        // ** Event: When the control is first loaded
        private void PaymentsView_Load(object sender, EventArgs e)
        {
            ApplyRoundedCorners();
        }

        // ** Event: When the control is being resized
        private void PaymentsView_Resize(object sender, EventArgs e)
        {
            ApplyRoundedCorners();
        }

        private void tableLayoutPanel_weekly_schedule_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
