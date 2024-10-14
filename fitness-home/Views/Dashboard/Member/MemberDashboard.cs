using AnimateDemo;
using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
using fitness_home.Views.Dashboard.Member.Components;

namespace fitness_home.Views.Dashboard
{
    public partial class MemberDashboard : Form
    {
       public MemberDashboard()
        {
            InitializeComponent();
        }

        private void Panel_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;

            // Adjust the radius as needed
            int cornerRadius = 7;

            // Create a rounded rectangle path based on the panel's size
            using (GraphicsPath path = GetRoundedRectanglePath(panel.ClientRectangle, cornerRadius))
            {
                // Set smoothing mode for smoother rendering
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                // Clear background and draw the rounded path
                e.Graphics.Clear(panel.BackColor);
                e.Graphics.FillPath(new SolidBrush(panel.BackColor), path);

                // Apply the rounded shape to the panel region
                panel.Region = new Region(path);
            }
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

        private void Member_Load(object sender, EventArgs e)
        {
            // Form transition
            WinAPI.AnimateWindow(this.Handle, 400, WinAPI.BLEND);

            // Add sidebar button controls
            SidebarButton dashboardButton = new SidebarButton(activeButton: true);
            tableLayoutPanel_sidebar.Controls.Add(dashboardButton, 1, 1);
            dashboardButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        }
    }
}
