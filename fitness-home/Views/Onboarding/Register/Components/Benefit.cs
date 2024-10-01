using System;
using System.Windows.Forms;

namespace fitness_home.Views.Onboarding.Register.Components
{
    public partial class Benefit : UserControl
    {
        private string Text;

        public Benefit(string text)
        {
            InitializeComponent();

            this.Text = text;
        }

        private void Benefit_Load(object sender, EventArgs e)
        {
            label_benefit.Text = Text;
        }
    }
}
