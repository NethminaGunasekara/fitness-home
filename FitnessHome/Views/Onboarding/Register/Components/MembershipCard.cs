using fitness_home.Utils.Types;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace fitness_home.Views.Onboarding.Register.Components
{
    public partial class MembershipCard : UserControl
    {
        private Color _borderColor = Color.FromArgb(70, 70, 70);
        private MembershipPlanDetails _MembershipPlan;
        private Action<string> OnClickAction;

        // Holds all bullets and labels for displaying the list of plan benefits
        private readonly List<List<Control>> Benefits = new List<List<Control>>();

        public MembershipCard(MembershipPlanDetails membershipPlan, Action<string> onClickAction = null)
        {
            InitializeComponent();

            _MembershipPlan = membershipPlan;
            OnClickAction = onClickAction;

            // Add all benefits and bullets to "Benefits"
        }

        // Get or set MembershipPlan
        public MembershipPlanDetails MembershipPlan
        {
            get { return _MembershipPlan; }

            set
            {
                _MembershipPlan = value;

                UpdateInfo();
            }
        }
        public List<string> PlanBenefits { get; set; }

        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;

                // Redraw the control to apply a new border color
                Invalidate();
            }
        }

        private void SetPlanBenefits(bool refresh = false)
        {
            // Suspend layout updates to avoid flickering
            this.SuspendLayout();

            // Limit the number of benefits displayed to 8, even if the database has more
            int benefitCount = Math.Min(_MembershipPlan.Benefits.Count, 8);

            // Initialize an empty string to build the text for the benefits label.
            string benefits = String.Empty;

            // Loop through each benefit in the plan's benefits list
            // and append it to the 'benefits' string with a bullet point and a new line.
            MembershipPlan.Benefits.ForEach(benefit => benefits += $"⦿ {benefit}\n");

            // Assign the built string to the benefits label to display the plan's benefits.
            plan_benefits.Text = benefits;

            // Resume layout updates
            this.ResumeLayout();
        }

        private void UpdateInfo()
        {
            // Suspend layout updates
            this.SuspendLayout();

            label_plan_name.Text = _MembershipPlan.PlanName;

            // If "membershipPlan.MonthlyFee" has a decimal part, display it, else display the whole number
            label_plan_fee.Text = _MembershipPlan.MonthlyFee % 1 != 0 ?
                Convert.ToString(_MembershipPlan.MonthlyFee) :
                Convert.ToString((int)_MembershipPlan.MonthlyFee);

            // Update the plan benefits
            SetPlanBenefits();

            // Resume layout updates
            this.ResumeLayout();
        }

        // -- Event: On Load
        private void MembershipCard_Load(object sender, EventArgs e)
        {
            UpdateInfo();
        }

        // -- Event: On Click
        private void OnClick(object sender, EventArgs e)
        {
            // Invoke the callback passed
            OnClickAction?.Invoke(Name);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (Pen pen = new Pen(BorderColor, 3))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
            }
        }
    }
}
