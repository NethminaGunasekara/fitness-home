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
            Benefits.Add(new List<Control> { pictureBox_bullet_1, label_benefit_1 });
            Benefits.Add(new List<Control> { pictureBox_bullet_2, label_benefit_2 });
            Benefits.Add(new List<Control> { pictureBox_bullet_3, label_benefit_3 });
            Benefits.Add(new List<Control> { pictureBox_bullet_4, label_benefit_4 });
            Benefits.Add(new List<Control> { pictureBox_bullet_5, label_benefit_5 });
            Benefits.Add(new List<Control> { pictureBox_bullet_6, label_benefit_6 });
            Benefits.Add(new List<Control> { pictureBox_bullet_7, label_benefit_7 });
            Benefits.Add(new List<Control> { pictureBox_bullet_8, label_benefit_8 });
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

            // Add all benefits and bullets to the TableLayoutPanel
            for (int i = 0; i < benefitCount; i++)
            {
                PictureBox bullet = Benefits[i][0] as PictureBox;
                Label label = Benefits[i][1] as Label;
                label.Text = _MembershipPlan.Benefits[i];

                bullet.Visible = true;
                label.Visible = true;

                // Hide the previous benefits before adding the new ones
                if (benefitCount == i + 1)
                {
                    Benefits.ForEach((List<Control> control) =>
                    {
                        if (Benefits.IndexOf(control) >= i + 1)
                        {
                            control[0].Visible = false;
                            control[1].Visible = false;
                        }
                    });
                }
            }

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

        private void panel_plan_fee_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_plan_name_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel_fee_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel_content_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_plan_fee_currency_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_plan_fee_per_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_benefits_title_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_benefits_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
