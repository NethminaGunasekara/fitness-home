using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace fitness_home.Views.Trainer.Tabs
{
    public partial class Dashboard : UserControl
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

        // Fields to store assessments made my the trainer
        private short MemberHeight;
        private short MemberWeight;
        private string ActivityFactor;
        private short CalorieGoal;

        public Dashboard()
        {
            InitializeComponent();
        }

        // Applies rounded corners around selected panels
        private void ApplyRoundedCorners()
        {
            // Initialize a list of panels to apply rounded corners
            List<Panel> panelsToDraw = new List<Panel> { panel_schedule, panel_calorie_goal, panel_lbm, panel_bmr, panel_bfp, panel_profile_view, panel_user_stats, panel_table_heading };

            SuspendLayout();

            // Apply rounded corners to all panels of the list above
            panelsToDraw.ForEach((Panel panel) =>
            {
                panel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel.Width, panel.Height, 12, 12));
            });

            ResumeLayout();
        }

        // ** Event: When the control is first loaded
        private void Dashboard_Load(object sender, EventArgs e)
        {
            ApplyRoundedCorners();
        }

        // ** Event: When the control is being resized
        private void Dashboard_Resize(object sender, EventArgs e)
        {
            // Here, we re-calculate the size of the panels with rounded corners as our control is resized
            ApplyRoundedCorners();
        }
    }
}
