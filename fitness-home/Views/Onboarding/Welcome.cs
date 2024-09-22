using AnimateDemo;
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
        }

        // Navigate user to the Login view once they click "Get Started" button
        private void GetStarted(object sender, EventArgs e)
        {
            // Create a new instance of Login form, or pass the existing one
            Login LoginForm = FormProvider.Login ?? (FormProvider.Login = new Login());
            Helpers.ShowForm(LoginForm, this);
        }

        private void OnLoad(object sender, EventArgs e)
        {
            // Form transition
            WinAPI.AnimateWindow(this.Handle, 400, WinAPI.BLEND);
        }
    }
}
