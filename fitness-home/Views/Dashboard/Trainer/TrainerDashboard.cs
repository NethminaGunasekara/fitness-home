using AnimateDemo;
using fitness_home.Services;
using fitness_home.Views.Dashboard.Member.Components;
using fitness_home.Views.Dashboard.Trainer.Views;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace fitness_home.Views.Dashboard.Trainer
{
    public partial class TrainerDashboard : Form
    {
        // We use these fields to store the views after initializing them using the "new" keyword
        // This avoids unnecessary re-instantiations, and allows us to keep data passed to those views
        private DashboardView DashboardView;

        public TrainerDashboard()
        {
            InitializeComponent();

            // Initialize all fields containing the tabs of member area
            DashboardView = new DashboardView();
        }

        private void TrainerDashboard_Load(object sender, EventArgs e)
        {
            // Form transition
            WinAPI.AnimateWindow(this.Handle, 700, WinAPI.BLEND);

            SuspendLayout();

            // Mount the dashboard view
            DashboardView dashboardView = new DashboardView();
            panel_content.Controls.Add(dashboardView);
            dashboardView.Dock = DockStyle.Fill;

            // Display the trainer name to welcome them
            label_heading_2.Text = $"{"Trainer"}!";

            // Add sidebar button controls
            SidebarButton dashboardButton = new SidebarButton(buttonType: ButtonType.Dashboard, activeButton: true);
            tableLayoutPanel_sidebar.Controls.Add(dashboardButton, 1, 1);
            dashboardButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            SidebarButton scheduleButton = new SidebarButton(buttonType: ButtonType.Classes);
            tableLayoutPanel_sidebar.Controls.Add(scheduleButton, 1, 3);
            scheduleButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            SidebarButton membershipButton = new SidebarButton(buttonType: ButtonType.Students);
            tableLayoutPanel_sidebar.Controls.Add(membershipButton, 1, 5);
            membershipButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            SidebarButton paymentsButton = new SidebarButton(buttonType: ButtonType.Feedbacks);
            tableLayoutPanel_sidebar.Controls.Add(paymentsButton, 1, 7);
            paymentsButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            SidebarButton contactUsButton = new SidebarButton(buttonType: ButtonType.Assessements);
            tableLayoutPanel_sidebar.Controls.Add(contactUsButton, 1, 9);
            contactUsButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            ResumeLayout();

            // ** Set the click events for all buttons
            dashboardButton.BtnClick = delegate
            {
                // Remove all previous controls added to the content panel
                panel_content.Controls.Clear();

                // Set the dock style of the newly added view to fill
                DashboardView.Dock = DockStyle.Fill;

                // Assign the new control to our content panel
                panel_content.Controls.Add(DashboardView);

                // Set the first part of the form heading and its font
                label_heading_1.Text = "Welcome,";
                label_heading_1.Font = new Font("Noto Sans", 18, FontStyle.Regular);

                // Set the second part of the form heading and its font
                label_heading_2.Text = $"{Authentication.LoggedUser.FirstName}!";
                label_heading_2.Font = new Font("Noto Sans", 18, FontStyle.Bold);

                // Mark the dashboard button as active
                dashboardButton.ActiveButton = true;

                // Mark all other buttons as inactive
                scheduleButton.ActiveButton = membershipButton.ActiveButton = paymentsButton.ActiveButton = contactUsButton.ActiveButton = false;
            };
        }

            // ** Event: When the view profile button is clicked
            private void button_edit_profile_Click(object sender, EventArgs e)
            {
                // Remove all previous controls added to the content panel
                panel_content.Controls.Clear();

                // Set the dock style of the newly added view to fill
                DashboardView.Dock = DockStyle.Fill;

                // Assign the new control to our content panel
                panel_content.Controls.Add(DashboardView);
            }
        } 
}
