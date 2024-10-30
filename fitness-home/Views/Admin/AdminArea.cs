using AnimateDemo;
using fitness_home.Services;
using fitness_home.Views.Admin.Tabs;
using fitness_home.Views.Member.Components;
using System;
using System.Windows.Forms;

namespace fitness_home.Views.Admin
{
    public partial class AdminArea : Form
    {
        // We use these fields to store the views after initializing them using the "new" keyword
        // This avoids unnecessary re-instantiations, and allows us to keep data passed to those views
        private Dashboard Dashboard;

        // Sidebar buttons
        SidebarButton DashboardButton;

        // Store the session start time
        public static DateTime SessionStart;

        public AdminArea()
        {
            InitializeComponent();

            // Initialize all fields containing the tabs of admin area
            Dashboard = new Dashboard();
        }

        // ** Method to initialize all sidebar buttons
        private void InitializeButtons()
        {
            // Initialize the dashboard button, add it to the sidebar, and set it as the currently active button
            DashboardButton = new SidebarButton(buttonType: ButtonType.Dashboard, activeButton: true);
            tableLayoutPanel_sidebar.Controls.Add(DashboardButton, 1, 1);
            DashboardButton.Anchor = AnchorStyles.Left | AnchorStyles.Right; // Align the button
        }

        // ** Method to switch the main panel's content by loading a new tab
        private void ChangeContent(Control newTab)
        {
            // Clear any existing controls from the content panel
            panel_content.Controls.Clear();

            // Configure the new tab to fill the entire content panel
            newTab.Dock = DockStyle.Fill;

            // Add the new tab to the content panel
            panel_content.Controls.Add(newTab);
        }

        // ** Method to switch the sidebar's active button
        private void SetActiveButton(SidebarButton ActiveButton)
        {
            // Mark all other buttons as inactive
            DashboardButton.ActiveButton = false;

            // Mark the button passed as a parameter as active
            ActiveButton.ActiveButton = true;
        }

        // ** Method assigned as the Load event of admin area
        private void AdminArea_Load(object sender, System.EventArgs e)
        {
            // Form transition
            WinAPI.AnimateWindow(this.Handle, 700, WinAPI.BLEND);

            // Set the session start time
            SessionStart = DateTime.Now;

            SuspendLayout();

            // Mount the dashboard view
            Dashboard dashboardView = new Dashboard();
            panel_content.Controls.Add(dashboardView);
            dashboardView.Dock = DockStyle.Fill;

            // Initialize all sidebar buttons
            InitializeButtons();

            // Display the admin name to welcome them
            label_heading_2.Text = $"{Authentication.LoggedUser.FirstName}!";

            ResumeLayout();
        }
    }
}
