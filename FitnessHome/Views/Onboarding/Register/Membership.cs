using fitness_home.Helpers;
using fitness_home.Services;
using fitness_home.Services.Actions;
using fitness_home.Utils;
using fitness_home.Utils.Types;
using fitness_home.Views.Onboarding.Register.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace fitness_home.Views.Onboarding.Register
{
    public partial class Membership : Form
    {
        // All membership plans
        private List<MembershipPlanDetails> MembershipPlans;

        // Plans to display
        private List<MembershipPlanDetails> _PlansToDisplay = new List<MembershipPlanDetails>();

        // Selected membership plan
        private MembershipPlanDetails SelectedPlan;

        // Index to get next or previous three plans from
        private int StartIndex = 0;

        // Membership plan card components
        private MembershipCard card_1;
        private MembershipCard card_2;
        private MembershipCard card_3;

        private List<MembershipPlanDetails> PlansToDisplay
        {
            get { return _PlansToDisplay; }

            set
            {
                _PlansToDisplay = value;

                SuspendLayout();

                // Update membership plans assigned to cards
                card_1.MembershipPlan = PlansToDisplay[0];
                card_2.MembershipPlan = PlansToDisplay[1];
                card_3.MembershipPlan = PlansToDisplay[2];

                ResumeLayout();

                // Deselect previously selected plan when "PlansToDisplay" has changed
                SelectedPlan = null;

                // Disable the continue button to prevent user from
                // submitting the form without selecting a plan


                // Set border color of all cards to default
                ResetCardBorders();
            }
        }

        public Membership()
        {
            InitializeComponent();

            // Retrieve all membership plans
            MembershipPlans = MembershipPlan.Instance.GetAllPlans();

            // Set first three plans from "MembershipPlans" to display
            PlansToDisplay.AddRange(MembershipPlans.GetRange(StartIndex, 3));
        }

        private void Membership_Load(object sender, EventArgs e)
        {
            // Set the background image
            this.BackgroundImage = Properties.Resources.Background;

            // Set the background image layout to zoom
            this.BackgroundImageLayout = ImageLayout.Zoom;

            // Display first three plans
            SuspendLayout();

            // First card (on left)
            card_1 = new MembershipCard(PlansToDisplay[0], OnClickAction);
            card_1.Dock = DockStyle.Fill;
            card_1.Anchor = AnchorStyles.Left;
            panel_plan_1.Controls.Add(card_1);
            
            // Second card (on middle)
            card_2 = new MembershipCard(PlansToDisplay[1], OnClickAction);
            card_2.Dock = DockStyle.Fill;
            card_2.Anchor = AnchorStyles.Left;
            panel_plan_2.Controls.Add(card_2);

            // Third card (on right)
            card_3 = new MembershipCard(PlansToDisplay[2], OnClickAction);
            card_3.Dock = DockStyle.Fill;
            card_3.Anchor = AnchorStyles.Left;
            panel_plan_3.Controls.Add(card_3);

            // Set card names for identifying them
            card_1.Name = "card_1";
            card_2.Name = "card_2";
            card_3.Name = "card_3";

            // Set "Hand" as the cursor for clickable cards
            card_1.Cursor = card_2.Cursor = card_3.Cursor = Cursors.Hand;

            ResumeLayout();

            // The second card will be selected by default
            SelectedPlan = card_1.MembershipPlan;

            // Set border color of the selected plan
            card_1.BorderColor = Color.FromArgb(204, 255, 255, 255);
        }

        // Applies default border color to all cards
        private void ResetCardBorders()
        {
            card_1.BorderColor = card_2.BorderColor = card_3.BorderColor = Color.FromArgb(70, 70, 70);
        }

        // Method to invoke when a membership card is clicked
        private void OnClickAction(string planName)
        {
            // Compare "planName" with plan names of all cards to find the clicked card
            MembershipCard card = planName == "card_1" ? card_1 : planName == "card_2" ? card_2 : card_3;

            SuspendLayout();

            // Set border color of all cards to default
            ResetCardBorders();

            // Set the clicked plan as "SelectedPlan"
            SelectedPlan = card.MembershipPlan;

            // Apply the border color of selected plan
            card.BorderColor = Color.FromArgb(204, 255, 255, 255);

            ResumeLayout();
        }

        // ** Event: Return to previous form
        private void button_previous_Click(object sender, EventArgs e)
        {
            fitness_home.Register RegisterForm = FormProvider.Register ?? (FormProvider.Register = new fitness_home.Register());
            FormProvider.ShowForm(RegisterForm, this);
        }

        // ** Event: Continue to pay the membership fee
        private void ContinueToPay(object sender, EventArgs e)
        {
            // Assign the membership plan to registration info
            fitness_home.Register.RegistrationInfo.MembershipPlan = SelectedPlan;

            // Proceed to the payment page
            Payment PaymentForm = FormProvider.Payment ?? (FormProvider.Payment = new Payment());

            // Set the membership fee
            PaymentForm.MembershipFee = fitness_home.Register.RegistrationInfo.MembershipPlan.MonthlyFee;

            FormProvider.ShowForm(PaymentForm, this);
        }

        private void pictureBox_previous_Click(object sender, EventArgs e)
        {
            // If StartIndex is 0, keep the plans as they're
            if (StartIndex == 0) return;

            StartIndex--;

            // Update "PlansToDisplay" with the previous three plans
            PlansToDisplay = MembershipPlans.GetRange(StartIndex, 3);
        }

        private void pictureBox_next_Click(object sender, EventArgs e)
        {
            if (MembershipPlans.Count - (StartIndex + 1) < 3) return;

            StartIndex++;

            // Update "PlansToDisplay" with the previous three plans
            PlansToDisplay = MembershipPlans.GetRange(StartIndex, 3);
        }
    }
}
