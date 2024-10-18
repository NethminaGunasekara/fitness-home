using AnimateDemo;
using System;
using System.Drawing;
using System.Windows.Forms;
using fitness_home.Views.Dashboard.Member.Components;
using fitness_home.Views.Dashboard.Member.Components.Views;
using fitness_home.Services;

namespace fitness_home.Views.Dashboard
{
    public partial class MemberDashboard : Form
    {
        // We use these fields to store the views after initializing them using the "new" keyword
        // This avoids unnecessary re-instantiations, and allows us to keep data passed to those views
        private DashboardView DashboardView;
        private ScheduleView ScheduleView;
        private MembershipView MembershipView;
        private PaymentsView PaymentsView;
        private ContactUsView ContactUsView;

       public MemberDashboard()
        {
            InitializeComponent();
        }

        private void ChangeView(Control view)
        {
            // Exit the method if the control of the content panel is "view" (It's unnecessary to reload it)
            if (panel_content.Controls[0] == view) return;

            // Remove the control assigned to content panel
            panel_content.Controls.RemoveAt(0);

            // Set the dock style of the newly added view to fill
            view.Dock = DockStyle.Fill;

            // Assign the new control to our content panel
            panel_content.Controls.Add(view);
        }

        private void Member_Load(object sender, EventArgs e)
        {
            // Form transition
            WinAPI.AnimateWindow(this.Handle, 700, WinAPI.BLEND);

            SuspendLayout();

            // Mount the dashboard view
            DashboardView dashboardView = new DashboardView();
            panel_content.Controls.Add(dashboardView);
            dashboardView.Dock = DockStyle.Fill;

            // Display the member name to welcome them
            label_heading_2.Text = $"{Authentication.LoggedUser.FirstName}!";

            // Add sidebar button controls
            SidebarButton dashboardButton = new SidebarButton(buttonType: ButtonType.Dashboard, activeButton: true);
            tableLayoutPanel_sidebar.Controls.Add(dashboardButton, 1, 1);
            dashboardButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;

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

            // ** Set the click events for all buttons
            dashboardButton.BtnClick = delegate {
                // Here, we first check if the "DashboardView" field is null, or undefined using the Nullish Coalescing Operator (??)
                // Read: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-coalescing-operator
                // If it's, we create a new instance of the "DashboardView" control using the "new" keyword, assign it to "DashboardView"
                // field and pass it as the parameter to the "ChangeView" method to change the view to dashboard when the button is clicked
                ChangeView(DashboardView ?? (DashboardView = new DashboardView()));

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
                ChangeView(ScheduleView ?? (ScheduleView = new ScheduleView()));

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
                ChangeView(MembershipView ?? (MembershipView = new MembershipView()));

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
                ChangeView(PaymentsView ?? (PaymentsView = new PaymentsView()));

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
                ChangeView(ContactUsView ?? (ContactUsView = new ContactUsView()));

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
    }
}
