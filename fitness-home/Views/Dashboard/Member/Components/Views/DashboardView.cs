using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using fitness_home.Services;
using fitness_home.Utils.Types.UserTypes;
using fitness_home.Properties;
using fitness_home.Services.Actions;

namespace fitness_home.Views.Dashboard.Member.Components.Views
{
    public partial class DashboardView : UserControl
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


        public DashboardView()
        {
            InitializeComponent();

            // Retrieve and store logged user information from the "Authentication" class
            User loggedUser = Authentication.LoggedUser;

            // Set member information in profile view panel
            label_name.Text = $"{loggedUser.FirstName} {loggedUser.LastName}";
            label_email.Text = loggedUser.Email;

            // Retrieve and set the membership plan using the planId from "loggedUser" object
            label_membership_type.Text = Membership.GetPlanNameById(loggedUser.PlanID);

            // Set an avatar based on the user's gender
            if (loggedUser.Gender == Utils.Types.Gender.Male)
                pictureBox_avatar.BackgroundImage = Resources.avatar_male;

            else
                pictureBox_avatar.BackgroundImage = Resources.avatar_female;
        }

        // Helper Method: Creates a rounded rectangle path
        private GraphicsPath GetRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;

            // Add rounded corners
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90); // Top-left
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90); // Top-right
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90); // Bottom-right
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90); // Bottom-left

            path.CloseFigure();
            return path;
        }

        // Applies rounded corners around selected panels
        private void ApplyRoundedCorners()
        {
            // Initialize a list of pannels to apply rounded corners
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
        private void DashboardView_Load(object sender, EventArgs e)
        {
            ApplyRoundedCorners();
        }

        // ** Event: When the form is being resized
        private void DashboardView_Resize(object sender, EventArgs e)
        {
            // Here, we re-calculate the size of the panels with rounded corners as our control is resized
            ApplyRoundedCorners();
        }
    }
}
