using fitness_home.Services;
using fitness_home.Utils;
using System;
using System.Windows.Forms;

namespace fitness_home
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();

            // Set the background image
            this.BackgroundImage = Properties.Resources.Background;

            // Set the background image layout to zoom
            this.BackgroundImageLayout = ImageLayout.Zoom;
        }

        // Navigate user to the Login view once they click "Get Started" button
        private void GetStarted(object sender, EventArgs e)
        {
            // Create a new instance of Login form, or pass the existing one
            Login LoginForm = FormProvider.Login ?? (FormProvider.Login = new Login());
            Helpers.ShowForm(LoginForm, this);
        }
    }
}
