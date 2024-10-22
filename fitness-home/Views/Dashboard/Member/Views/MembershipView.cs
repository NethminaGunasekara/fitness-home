using System;
using System.Drawing;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using fitness_home.Helpers;
using fitness_home.Services;

namespace fitness_home.Views.Dashboard.Member.Components.Views
{
    public partial class MembershipView : UserControl
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

        private List<MembershipPlanDetails> MembershipPlans; // Stores all fetched membership plans
        private int currentStartIndex = 0; // Keeps track of the first plan being displayed

        // Membership payment view, which we'll use later to process the payment
        private MembershipPayment MembershipPayment;

        public MembershipView(MembershipPayment membershipPaymentView)
        {
            InitializeComponent();

            MembershipPayment = membershipPaymentView;
        }

        // Applies rounded corners to selected panels.
        private void ApplyRoundedCorners()
        {
            // Initialize a list of panels to apply rounded corners
            List<Panel> panelsToDraw = new List<Panel> { panel_current_plan, panel_plan_1, panel_plan_2, panel_plan_3 };

            SuspendLayout();
            
            // Apply rounded corners to all panels in the list
            panelsToDraw.ForEach(panel =>
            {
                panel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel.Width, panel.Height, 12, 12));
            });

            ResumeLayout();
        }

        // ** Event: Triggered when the control is first loaded. 
        // Fetches membership plans and displays the first set of plans.
        private void MembershipView_Load(object sender, EventArgs e)
        {
            ApplyRoundedCorners();

            // Retrieve and store all membership plans
            MembershipPlans = MembershipPlan.Instance.GetAllPlans();

            // Display the first three plans on load
            DisplayPlans();

            // Display information about current membership plan assigned to the user
            DisplayCurrentPlan();
        }

        // ** Event: Update the values when the control needs to be repainted
        // (i.e. After we called the Refresh() method)
        private void MembershipView_Paint(object sender, PaintEventArgs e)
        {
            // Update information about current membership plan assigned to the user
            DisplayCurrentPlan();
        }

        // ** Event: Triggered when the form is resized.
        private void MembershipView_Resize(object sender, EventArgs e)
        {
            ApplyRoundedCorners();
        }

        // Displays the user's current membership plan information
        private void DisplayCurrentPlan()
        {
            MembershipPlanDetails currentPlan = MembershipPlan.Instance.GetPlanById(Authentication.LoggedUser.PlanID);

            // Calculate the difference between the current date and the plan expiry date
            TimeSpan difference = Authentication.LoggedUser.PlanExpiry - DateTime.Now;

            // Get the difference in days (0 is displayed if this results a negative value)
            int daysDifference = difference.Days >=0 ? difference.Days : 0;

            // Display the current membership plan information
            label_current_plan_name.Text = currentPlan.Name;
            label_current_plan_fee.Text = $"LKR {currentPlan.MonthlyFee}";
            label_current_plan_purchase.Text = Authentication.LoggedUser.PlanExpiry.ToString("dd/MM//yyyy");
            label_current_plan_days.Text = daysDifference.ToString();
        }

        // Helper method to display each plan's content
        private void DisplayPlan(int index, Label nameLabel, Label feeLabel, Label benefitsLabel)
        {
            // Check if the provided index is within the bounds of the MembershipPlans list
            if (index < MembershipPlans.Count)
            {
                // Retrieve the membership plan at the specified index
                var plan = MembershipPlans[index];

                // Set the name label to display the plan's name
                nameLabel.Text = plan.Name;

                // If the fee has no decimal part, show it as an integer
                // Otherwise, display two decimal places for precision
                feeLabel.Text = plan.MonthlyFee % 1 == 0
                    ? $"LKR {plan.MonthlyFee:0}"
                    : $"LKR {plan.MonthlyFee:0.00}";

                // Initialize an empty string to build the text for the benefits label.
                string benefits = String.Empty;

                // Loop through each benefit in the plan's benefits list
                // and append it to the 'benefits' string with a bullet point and a new line.
                plan.benefits.ForEach(benefit => benefits += $"⦿ {benefit}\n");

                // Assign the built string to the benefits label to display the plan's benefits.
                benefitsLabel.Text = benefits;
            }

            else
            {
                // Set default placeholders if no plan is available at the index
                nameLabel.Text = "-";
                feeLabel.Text = "-";
                benefitsLabel.Text = "-";
            }
        }

        // Displays three plans starting from the current index.
        // If fewer than three plans are available, fills with dashes.
        private void DisplayPlans()
        {
            // Display the first, second, and third plans
            DisplayPlan(currentStartIndex, label_plan_name_1, label_plan_fee_1, plan_benefits_1);
            DisplayPlan(currentStartIndex + 1, label_plan_name_2, label_plan_fee_2, plan_benefits_2);
            DisplayPlan(currentStartIndex + 2, label_plan_name_3, label_plan_fee_3, plan_benefits_3);
        }

        // ** Event: Triggered when the 'Next' button is clicked. 
        // Displays the next set of plans if available.
        private void pictureBox_next_Click(object sender, EventArgs e)
        {
            if (currentStartIndex + 3 < MembershipPlans.Count)
            {
                currentStartIndex++;
                DisplayPlans();
            }
        }

        // ** Event: Triggered when the 'Previous' button is clicked.
        // Displays the previous set of plans if available.
        private void pictureBox_previous_Click(object sender, EventArgs e)
        {
            if (currentStartIndex > 0)
            {
                currentStartIndex--;
                DisplayPlans();
            }
        }

        // ** Event: Triggered when the 'Purchase' button for the first plan is clicked.
        // Displays a confirmation message with the selected plan's details.
        private void button_purchase_plan_1_Click(object sender, EventArgs e)
        {
            if (currentStartIndex < MembershipPlans.Count)
            {
                var plan = MembershipPlans[currentStartIndex];

                // Proceed to purchase the selected membership plan
                MembershipPayment.PlanId = plan.PlanId;

                // Assign this control (membership view) to the membership payment control, so that it
                // can redirect the member back to the membership view after the payment is done
                MembershipPayment.MembershipView = this;

                // Show the payment view
                MembershipPayment.Show();

                // Hide the current view (MembershipView)
                this.Hide();                
            }
        }

        // Event: Triggered when the 'Purchase' button for the second plan is clicked.
        private void button_purchase_plan_2_Click(object sender, EventArgs e)
        {
            if (currentStartIndex + 1 < MembershipPlans.Count)
            {
                var plan = MembershipPlans[currentStartIndex + 1];

                // Proceed to purchase the selected membership plan
                MembershipPayment.PlanId = plan.PlanId;

                // Assign this control (membership view) to the membership payment control, so that it
                // can redirect the member back to the membership view after the payment is done
                MembershipPayment.MembershipView = this;

                // Show the payment view
                MembershipPayment.Show();

                // Hide the current view (MembershipView)
                this.Hide();
            }
        }

        // Event: Triggered when the 'Purchase' button for the third plan is clicked.
        private void button_purchase_plan_3_Click(object sender, EventArgs e)
        {
            if (currentStartIndex + 2 < MembershipPlans.Count)
            {
                var plan = MembershipPlans[currentStartIndex + 2];

                // Proceed to purchase the selected membership plan
                MembershipPayment.PlanId = plan.PlanId;

                // Assign this control (membership view) to the membership payment control, so that it
                // can redirect the member back to the membership view after the payment is done
                MembershipPayment.MembershipView = this;

                // Show the payment view
                MembershipPayment.Show();

                // Hide the current view (MembershipView)
                this.Hide();
            }
        }
    }
}