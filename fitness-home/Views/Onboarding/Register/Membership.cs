﻿using fitness_home.Services.Actions;
using fitness_home.Utils.Types;
using fitness_home.Views.Onboarding.Register.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace fitness_home.Views.Onboarding.Register
{
    public partial class Membership : Form
    {
        // All membership plans
        private List<MembershipPlan> MembershipPlans;

        // Plans to display
        private List<MembershipPlan> _PlansToDisplay = new List<MembershipPlan>();

        // Selected membership plan ID
        private int SelectedPlanId;

        // Index to get next or previous three plans from
        private int StartIndex = 0;

        // Membership plan card components
        private MembershipCard card_1;
        private MembershipCard card_2;
        private MembershipCard card_3;

        private List<MembershipPlan> PlansToDisplay
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

                // Set id of the second card as "SelectedPlanId"
                SelectedPlanId = card_2.MembershipPlan.PlanId;
            }
        }

        public Membership()
        {
            InitializeComponent();

            // Retrieve all membership plans
            MembershipPlans = MembershipInfo.GetAllPlans();

            // Set first three plans from "MembershipPlans" to display
            PlansToDisplay.AddRange(MembershipPlans.GetRange(StartIndex, 3));
        }

        private void Membership_Load(object sender, EventArgs e)
        {
            // Display first three plans
            SuspendLayout();

            // First card (on left)
            card_1 = new MembershipCard(PlansToDisplay[0], OnClick);
            card_1.Dock = DockStyle.Fill;
            card_1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tableLayoutPanel_content.Controls.Add(card_1, 0, 1);

            // Second card (on middle)
            card_2 = new MembershipCard(PlansToDisplay[1]);
            card_2.Dock = DockStyle.Fill;
            card_2.Anchor = AnchorStyles.Top;
            tableLayoutPanel_content.Controls.Add(card_2, 1, 1);

            // Third card (on right)
            card_3 = new MembershipCard(PlansToDisplay[2], OnClick);
            card_3.Dock = DockStyle.Fill;
            card_3.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            tableLayoutPanel_content.Controls.Add(card_3, 2, 1);

            // Set border color of the selected plan
            card_2.BorderColor = Color.FromArgb(204, 255, 255, 255);

            // Set card names for identifying them
            card_1.Name = "card_1";
            card_2.Name = "card_2";
            card_3.Name = "card_3";

            // Set "Hand" as the cursor for clickable cards
            card_1.Cursor = card_3.Cursor = Cursors.Hand;

            ResumeLayout();

            // Set id of the second card as "SelectedPlanId"
            SelectedPlanId = card_2.MembershipPlan.PlanId;
        }

        // Passed as the "onClickAction" action of clickable cards
        public void OnClick(string cardName)
        {
            // If the user has clicked "card_1"
            if (cardName == "card_1")
            {
                // If StartIndex is 0, keep the plans as they're
                if (StartIndex == 0) return;

                StartIndex--;

                // Update "PlansToDisplay" with the previous three plans
                PlansToDisplay = MembershipPlans.GetRange(StartIndex, 3);

                return; // Exit the method
            }

            // The rest of this method will run only if user has clicked "card_2"

            // If less than three plans left from "StartIndex", keep the plans as they're
            if (MembershipPlans.Count - (StartIndex + 1) < 3) return;

            StartIndex++;

            // Update "PlansToDisplay" with the previous three plans
            PlansToDisplay = MembershipPlans.GetRange(StartIndex, 3);
        }

        private void button_previous_Click(object sender, EventArgs e)
        {

        }
    }
}
