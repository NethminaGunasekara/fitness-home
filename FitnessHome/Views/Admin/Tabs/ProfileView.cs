using System;
using System.Configuration;
using System.Windows.Forms;
using fitness_home.Services;
using fitness_home.Utils.Types.UserTypes;

namespace fitness_home.Views.Admin.Tabs
{
    public partial class ProfileView : UserControl
    {
        public ProfileView()
        {
            InitializeComponent();

            // Retrieve admin information and store them in a variable
            User adminData = new AdminData(Authentication.LoggedUser.ID); // Use the logged in user's id

            // Initialize the fields displaying admin information
            textBox_first_name.Text = adminData.FirstName;
            textBox_last_name.Text = adminData.LastName;
            textBox_phone.Text = adminData.Phone;
            textBox_email.Text = adminData.Email;
            textBox_nic.Text = adminData.NIC;
            textBox_admin_id.Text = FormatAdminId(adminData.ID);

            // Set the name and id of the administrator
            label_admin_name.Text = $"{adminData.FirstName} {adminData.LastName}";
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

        // Format the admin id by adding a padding of 0s to fill 3 digits
        public string FormatAdminId(int adminId)
        {
            // Convert the numeric admin id to a string
            string adminIdString = adminId.ToString();

            // Add a padding left of 0s to make three digits
            string formattedAdminID = adminIdString.PadLeft(3, '0');

            // Display the formatted admin id
            return $"A{formattedAdminID}";
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
