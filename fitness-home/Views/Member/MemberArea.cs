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

       public MemberArea()
        {
            InitializeComponent();

            // Initialize all fields containing the tabs of member area
            DashboardView = new Member.Components.Views.Dashboard();
            ScheduleView = new Schedule();
            MembershipPayment = new MembershipPayment(MembershipView);
            MembershipView = new Membership(MembershipPayment);
            PaymentsView = new Payments();
            ContactUsView = new ContactUs();
            ProfileView = new ProfileView();
        }

        // ** Method to initialize all sidebar buttons
        private void InitializeButtons()
        {
            SuspendLayout();

            // Initialize the dashboard button, add it to the sidebar, and set it as the currently active button
            SidebarButton dashboardButton = new SidebarButton(buttonType: ButtonType.Dashboard, activeButton: true);
            tableLayoutPanel_sidebar.Controls.Add(dashboardButton, 1, 1);
            dashboardButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            // Initialize the schedule button, add it to the sidebar, and set it as the currently active button
            SidebarButton scheduleButton = new SidebarButton(buttonType: ButtonType.Schedule);
            tableLayoutPanel_sidebar.Controls.Add(scheduleButton, 1, 3);
            scheduleButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            SidebarButton membershipButton = new SidebarButton(buttonType: ButtonType.Membership);
            tableLayoutPanel_sidebar.Controls.Add(membershipButton, 1, 5);
            membershipButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            SidebarButton paymentsButton = new SidebarButton(buttonType: ButtonType.Payments);
            tableLayoutPanel_sidebar.Controls.Add(paymentsButton, 1, 7);
            paymentsButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            SidebarButton contactUsButton = new SidebarButton(buttonType: ButtonType.ContactUs);
            tableLayoutPanel_sidebar.Controls.Add(contactUsButton, 1, 9);
            contactUsButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;

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

        private void Member_Load(object sender, EventArgs e)
        {
            // Form transition
            WinAPI.AnimateWindow(this.Handle, 700, WinAPI.BLEND);

            SuspendLayout();

            // Mount the dashboard view
            Member.Components.Views.Dashboard dashboardView = new Member.Components.Views.Dashboard();
            panel_content.Controls.Add(dashboardView);
            dashboardView.Dock = DockStyle.Fill;

            // Display the member name to welcome them
            label_heading_2.Text = $"{Authentication.LoggedUser.FirstName}!";

            // ** Set the click events for all buttons
            dashboardButton.BtnClick = delegate {
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

            scheduleButton.BtnClick = delegate {
                // Remove all previous controls added to the content panel
                panel_content.Controls.Clear();

                // Set the dock style of the newly added view to fill
                ScheduleView.Dock = DockStyle.Fill;

                // Assign the new control to our content panel
                panel_content.Controls.Add(ScheduleView);

                // Set the first part of the form heading and its font
                label_heading_1.Text = "Weekly Schedule";
                label_heading_1.Font = new Font("Noto Sans", 18, FontStyle.Bold);

                // Set the second part of the form heading to blank
                label_heading_2.Text = "";

                // Mark the schedule button as active
                scheduleButton.ActiveButton = true;

                // Mark all other buttons as inactive
                dashboardButton.ActiveButton = membershipButton.ActiveButton = paymentsButton.ActiveButton = contactUsButton.ActiveButton = false;
             };

            membershipButton.BtnClick = delegate {
                // Remove all previous controls added to the content panel
                panel_content.Controls.Clear();

                // Set the dock style of the newly added view to fill
                MembershipView.Dock = DockStyle.Fill;

                // Assign the new control to our content panel
                // In this case, we must add both MembershipView and MembershipPayment controls
                panel_content.Controls.Add(MembershipView);
                panel_content.Controls.Add(MembershipPayment);

                // Invalidate the MembershipView, so that it can display the latest membership data
                MembershipView.Invalidate();

                // Set the first part of the form heading and its font
                label_heading_1.Text = "Membership";
                label_heading_1.Font = new Font("Noto Sans", 18, FontStyle.Bold);

                // Set the second part of the form heading to blank
                label_heading_2.Text = "";

                // Mark the membership button as active
                membershipButton.ActiveButton = true;

                // Mark all other buttons as inactive
                scheduleButton.ActiveButton = dashboardButton.ActiveButton = paymentsButton.ActiveButton = contactUsButton.ActiveButton = false;
            };

            paymentsButton.BtnClick = delegate {
                // Remove all previous controls added to the content panel
                panel_content.Controls.Clear();

                // Set the dock style of the newly added view to fill
                PaymentsView.Dock = DockStyle.Fill;

                // Assign the new control to our content panel
                panel_content.Controls.Add(PaymentsView);

                // Invalidate the PaymentsView, so that it can display the latest transaction data
                PaymentsView.Invalidate();

                // Set the first part of the form heading and its font
                label_heading_1.Text = "Payments History";
                label_heading_1.Font = new Font("Noto Sans", 18, FontStyle.Bold);

                // Set the second part of the form heading to blank
                label_heading_2.Text = "";

                // Mark the payments button as active
                paymentsButton.ActiveButton = true;

                // Mark all other buttons as inactive
                scheduleButton.ActiveButton = dashboardButton.ActiveButton = membershipButton.ActiveButton = contactUsButton.ActiveButton = false;
            };

            contactUsButton.BtnClick = delegate {
                // Remove all previous controls added to the content panel
                panel_content.Controls.Clear();

                // Set the dock style of the newly added view to fill
                ContactUsView.Dock = DockStyle.Fill;

                // Assign the new control to our content panel
                panel_content.Controls.Add(ContactUsView);

                // Set the first part of the form heading and its font
                label_heading_1.Text = "Contact Us";
                label_heading_1.Font = new Font("Noto Sans", 18, FontStyle.Bold);

                // Set the second part of the form heading to blank
                label_heading_2.Text = "";

                // Mark the contact us button as active
                contactUsButton.ActiveButton = true;

                // Mark all other buttons as inactive
                scheduleButton.ActiveButton = dashboardButton.ActiveButton = membershipButton.ActiveButton = paymentsButton.ActiveButton = false;
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
