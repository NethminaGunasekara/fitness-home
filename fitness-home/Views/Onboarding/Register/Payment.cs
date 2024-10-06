using AnimateDemo;
using System.Windows.Forms;

namespace fitness_home.Views.Onboarding.Register
{
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }

        private void textBox_card_holder_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void textBox_card_number_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void textBox_cvc_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void OnLoad(object sender, System.EventArgs e)
        {
            // Form transition
            WinAPI.AnimateWindow(this.Handle, 700, WinAPI.BLEND);

            Refresh(); // Redraw textbox borders after being hidden by the transition

            // Set the background image
            this.BackgroundImage = Properties.Resources.Background;

            // Set the background image layout to zoom
            this.BackgroundImageLayout = ImageLayout.Zoom;
        }
    }
}
