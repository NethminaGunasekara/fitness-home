using AnimateDemo;
using System;
using System.Drawing;
using System.Windows.Forms;
using fitness_home.Views.Member.Components;
using fitness_home.Views.Member.Components.Views;
using fitness_home.Services;

namespace fitness_home.Views
{
    public partial class MemberArea : Form
    {
        // We use these fields to store the views after initializing them using the "new" keyword
        // This avoids unnecessary re-instantiations, and allows us to keep data passed to those views
        private Dashboard DashboardView;
        private Schedule ScheduleView;
        private Membership MembershipView;
        private MembershipPayment MembershipPayment;
        private Payments PaymentsView;
        private ContactUs ContactUsView;
        private ProfileView ProfileView;

        // Initialize the list of sidebar buttons
        SidebarButton DashboardButton;
        SidebarButton ScheduleButton;
        SidebarButton MembershipButton;
        SidebarButton PaymentsButton;
        SidebarButton ContactUsButton;

        public MemberArea()
        {
            InitializeComponent();

            // Initialize all fields containing the tabs of member area
            DashboardView = new Dashboard();
            ScheduleView = new Schedule();
            MembershipPayment = new MembershipPayment();
            MembershipView = new Membership(MembershipPayment);
            PaymentsView = new Payments();
            ContactUsView = new ContactUs();
            ProfileView = new ProfileView();
        }

        // ** Helper method used to invalidate a selected control and refresh its data
        public void RefreshData(Control control) {

            // Invalidate the control and schedule it for repainting
            control.Invalidate();

            // Refresh the member area to force redraw the control
            Refresh();
        }

        // ** Method to initialize all sidebar buttons
        private void InitializeButtons()
        {
            SuspendLayout();

            // Initialize the dashboard button, add it to the sidebar, and set it as the currently active button
            DashboardButton = new SidebarButton(buttonType: ButtonType.Dashboard, activeButton: true);
            tableLayoutPanel_sidebar.Controls.Add(DashboardButton, 1, 1);
            DashboardButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            // Initialize the schedule button, add it to the sidebar, and set it as the currently active button
            ScheduleButton = new SidebarButton(buttonType: ButtonType.Schedule);
            tableLayoutPanel_sidebar.Controls.Add(ScheduleButton, 1, 3);
            ScheduleButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            // Initialize the membership button, add it to the sidebar, and set it as the currently active button
            MembershipButton = new SidebarButton(buttonType: ButtonType.Membership);
            tableLayoutPanel_sidebar.Controls.Add(MembershipButton, 1, 5);
            MembershipButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            // Initialize the payments button, add it to the sidebar, and set it as the currently active button
            PaymentsButton = new SidebarButton(buttonType: ButtonType.Payments);
            tableLayoutPanel_sidebar.Controls.Add(PaymentsButton, 1, 7);
            PaymentsButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            // Initialize the contact us button, add it to the sidebar, and set it as the currently active button
            ContactUsButton = new SidebarButton(buttonType: ButtonType.ContactUs);
            tableLayoutPanel_sidebar.Controls.Add(ContactUsButton, 1, 9);
            ContactUsButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            ResumeLayout();
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
            DashboardButton.ActiveButton = ScheduleButton.ActiveButton = MembershipButton.ActiveButton = PaymentsButton.ActiveButton = ContactUsButton.ActiveButton = false;

            // Mark the button passed as a parameter as active
            ActiveButton.ActiveButton = true;
        }

        private void Member_Load(object sender, EventArgs e)
        {
            // Form transition
            WinAPI.AnimateWindow(this.Handle, 700, WinAPI.BLEND);

            // Initialize all sidebar buttons
            InitializeButtons();

            SuspendLayout();

            // Mount the dashboard view as the default tab (which is displayed when the member area is loaded)
            panel_content.Controls.Add(DashboardView);
            DashboardView.Dock = DockStyle.Fill;

            // Display the member name to welcome them
            label_heading_2.Text = $"{Authentication.LoggedUser.FirstName}!";

            ResumeLayout();

            // ** Set the click events for all buttons
            DashboardButton.BtnClick = delegate {
                // Show the dashboard tab
                ChangeContent(DashboardView);

                // Refresh the content on dashboard before switching back to it
                RefreshData(DashboardView);

                // Set the dashboard button as the active button
                SetActiveButton(DashboardButton);

                // Set the first part of the form heading and its font
                label_heading_1.Text = "Welcome,";
                label_heading_1.Font = new Font("Noto Sans", 18, FontStyle.Regular);

                // Set the second part of the form heading and its font
                label_heading_2.Text = $"{Authentication.LoggedUser.FirstName}!";
                label_heading_2.Font = new Font("Noto Sans", 18, FontStyle.Bold);
            };

            ScheduleButton.BtnClick = delegate {
                // Show the schedule tab
                ChangeContent(ScheduleView);

                // Set the schedule button as the active button
                SetActiveButton(ScheduleButton);

                // Set the first part of the form heading and its font
                label_heading_1.Text = "Weekly Schedule";
                label_heading_1.Font = new Font("Noto Sans", 18, FontStyle.Bold);

                // Set the second part of the form heading to blank
                label_heading_2.Text = "";
             };

            MembershipButton.BtnClick = delegate {
                // Remove all previous controls added to the content panel
                panel_content.Controls.Clear();

                // Set the dock style of the newly added view to fill
                MembershipView.Dock = DockStyle.Fill;

                // Assign the new control to our content panel
                // In this case, we must add both MembershipView and MembershipPayment controls
                panel_content.Controls.Add(MembershipView);
                panel_content.Controls.Add(MembershipPayment);

                // Set the membership button as the active button
                SetActiveButton(MembershipButton);

                // Invalidate the MembershipView, so that it can display the latest membership data
                MembershipView.Invalidate();

                // Set the first part of the form heading and its font
                label_heading_1.Text = "Membership";
                label_heading_1.Font = new Font("Noto Sans", 18, FontStyle.Bold);

                // Set the second part of the form heading to blank
                label_heading_2.Text = "";
            };

            PaymentsButton.BtnClick = delegate {
                // Show the payments tab
                ChangeContent(PaymentsView);

                // Set the payments button as the active button
                SetActiveButton(PaymentsButton);

                // Invalidate the PaymentsView, so that it can display the latest transaction data
                PaymentsView.Invalidate();

                // Set the first part of the form heading and its font
                label_heading_1.Text = "Payments History";
                label_heading_1.Font = new Font("Noto Sans", 18, FontStyle.Bold);

                // Set the second part of the form heading to blank
                label_heading_2.Text = "";
            };

            ContactUsButton.BtnClick = delegate {
                // Show the contact us tab
                ChangeContent(ContactUsView);

                // Set the contact us button as the active button
                SetActiveButton(ContactUsButton);

                // Set the first part of the form heading and its font
                label_heading_1.Text = "Contact Us";
                label_heading_1.Font = new Font("Noto Sans", 18, FontStyle.Bold);

                // Set the second part of the form heading to blank
                label_heading_2.Text = "";
            };
        }

        // ** Event: When the view profile button is clicked
        private void button_edit_profile_Click(object sender, EventArgs e)
        {
            // Remove all previous controls added to the content panel
            panel_content.Controls.Clear();

            // Set the dock style of the newly added view to fill
            ProfileView.Dock = DockStyle.Fill;

            // Assign the new control to our content panel
            panel_content.Controls.Add(ProfileView);
        }
    }
}
