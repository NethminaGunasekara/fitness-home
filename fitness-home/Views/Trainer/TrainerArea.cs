using AnimateDemo;
using fitness_home.Services;
using fitness_home.Views.Member.Components;
using fitness_home.Views.Trainer.Tabs;
using System;
using System.Windows.Forms;

namespace fitness_home.Views.Trainer
{
    public partial class TrainerArea : Form
    {
        // We use these fields to store the views after initializing them using the "new" keyword
        // This avoids unnecessary re-instantiations, and allows us to keep data passed to those views
        private Dashboard Dashboard;
        private Schedule Schedule;
        private Initialize Attendance;

        // Sidebar buttons
        SidebarButton DashboardButton;
        SidebarButton ScheduleButton;
        SidebarButton AttendanceButton;
        SidebarButton AssessmentsButton;
        SidebarButton PaymentsButton;

        public TrainerArea()
        {
            InitializeComponent();

            HttpServer httpServer = new HttpServer();

            httpServer.Start();

            // Initialize all fields containing the tabs of member area
            Dashboard = new Dashboard();
            Schedule = new Schedule();
            Attendance = new Initialize();
        }

        // ** Method to initialize all sidebar buttons
        private void InitializeButtons()
        {
            // Initialize the dashboard button, add it to the sidebar, and set it as the currently active button
            DashboardButton = new SidebarButton(buttonType: ButtonType.Dashboard, activeButton: true);
            tableLayoutPanel_sidebar.Controls.Add(DashboardButton, 1, 1);
            DashboardButton.Anchor = AnchorStyles.Left | AnchorStyles.Right; // Align the button

            // Initialize the schedule button and add it to the sidebar
            ScheduleButton = new SidebarButton(buttonType: ButtonType.Schedule);
            tableLayoutPanel_sidebar.Controls.Add(ScheduleButton, 1, 3);
            ScheduleButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            // Initialize the attendance button and add it to the sidebar
            AttendanceButton = new SidebarButton(buttonType: ButtonType.Attendance);
            tableLayoutPanel_sidebar.Controls.Add(AttendanceButton, 1, 5);
            AttendanceButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            // Initialize the assessments button and add it to the sidebar
            AssessmentsButton = new SidebarButton(buttonType: ButtonType.Assessments);
            tableLayoutPanel_sidebar.Controls.Add(AssessmentsButton, 1, 7);
            AssessmentsButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            // Initialize the payments button and add it to the sidebar
            PaymentsButton = new SidebarButton(buttonType: ButtonType.Payments);
            tableLayoutPanel_sidebar.Controls.Add(PaymentsButton, 1, 9);
            PaymentsButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
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
            DashboardButton.ActiveButton = ScheduleButton.ActiveButton = AttendanceButton.ActiveButton = AssessmentsButton.ActiveButton = PaymentsButton.ActiveButton = false;

            // Mark the button passed as a parameter as active
            ActiveButton.ActiveButton = true;
        }

        // ** Method assigned as the Load event of trainer area
        private void TrainerArea_Load(object sender, EventArgs e)
        {
            // Form transition
            WinAPI.AnimateWindow(this.Handle, 700, WinAPI.BLEND);

            SuspendLayout();

            // Mount the dashboard view
            Dashboard dashboardView = new Dashboard();
            panel_content.Controls.Add(dashboardView);
            dashboardView.Dock = DockStyle.Fill;

            // Initialize all sidebar buttons
            InitializeButtons();

            // Display the trainer name to welcome them
            label_heading_2.Text = $"{"Trainer"}!";

            ResumeLayout();

            // Code to run when the dashboard button is clicked
            DashboardButton.BtnClick = delegate
            {
                // Show the dashboard tab
                ChangeContent(Dashboard);

                // Set the dashboard button as the active button
                SetActiveButton(DashboardButton);

                // Set the first part of the form heading
                label_heading_1.Text = "Welcome,";

                // Set the second part of the form heading
                label_heading_2.Text = $"{Authentication.LoggedUser.FirstName}!";
            };

            // Code to run when the schedule button is clicked
            ScheduleButton.BtnClick = delegate
            {
                // Show the schedule tab
                ChangeContent(Schedule);

                // Set the schedule button as the active button
                SetActiveButton(ScheduleButton);

                // Clear the text content of both parts of the heading
                label_heading_1.Text = label_heading_2.Text = "";

                // Set the second part of the form heading
                label_heading_2.Text = "Schedule";
            };

            // Code to run when the attendance button is clicked
            AttendanceButton.BtnClick = delegate
            {
                // Show the schedule tab
                ChangeContent(Attendance);

                // Set the schedule button as the active button
                SetActiveButton(AttendanceButton);

                // Clear the text content of both parts of the heading
                label_heading_1.Text = label_heading_2.Text = "";
            };
        }

        // ** Event: When the view profile button is clicked
        private void button_edit_profile_Click(object sender, EventArgs e)
        {
            // Mark all sidebar buttons as inactive
            DashboardButton.ActiveButton = ScheduleButton.ActiveButton = AttendanceButton.ActiveButton = AssessmentsButton.ActiveButton = PaymentsButton.ActiveButton = false;

            // Display the profile view
            ChangeContent(Dashboard);
        }
    }
}
