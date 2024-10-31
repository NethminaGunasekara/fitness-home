using System;
using System.Configuration;
using System.Windows.Forms;
using fitness_home.Services;

namespace fitness_home.Views.Admin.Tabs
{
    public partial class ProfileView : UserControl
    {
        public ProfileView()
        {
            InitializeComponent();
        }

        // ** Event: When the view profile button is clicked
        private void button_logout_Click(object sender, EventArgs e)
        {
            // Logout flow: Clear the saved login credentials -> Assign null to the logged user -> Return the user to login page

            // Retrieve login details from the config (App.config)
            string storedEmail = ConfigurationManager.AppSettings["USER_EMAIL"];
            string storedPassword = ConfigurationManager.AppSettings["USER_PASSWORD"];

            // Open the configuration file
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // Update configuration if necessary and set an empty value to saved email and password
            config.AppSettings.Settings["USER_EMAIL"].Value = "";
            config.AppSettings.Settings["USER_PASSWORD"].Value = "";

            // Save the config file
            config.Save(ConfigurationSaveMode.Modified);

            // Assign "null" to the "LoggedUser" property of the "Authentication" class
            Authentication.LoggedUser = null;

            // Return the user to the login page
            FormProvider.ShowForm(targetForm: FormProvider.Login ?? (FormProvider.Login = new Login()), currentForm: FormProvider.AdminArea);
        }
    }
}
