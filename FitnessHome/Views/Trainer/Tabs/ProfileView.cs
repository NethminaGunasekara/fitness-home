using System;
using System.Configuration;
using System.Windows.Forms;
using fitness_home.Services;
using fitness_home.Utils.Types.UserTypes;

namespace fitness_home.Views.Trainer.Tabs
{
    public partial class ProfileView : UserControl
    {
        public ProfileView()
        {
            InitializeComponent();

            // Retrieve information about the logged trainer
            User trainerTata = Authentication.LoggedUser;

            // Display trainer data
            textBox_first_name.Text = trainerTata.FirstName;
            textBox_last_name.Text = trainerTata.LastName;
            textBox_dob.Text = trainerTata.DateOfBirth.ToString("yyyy/MM/dd");
            textBox_phone.Text = trainerTata.Phone;
            textBox_address.Text = trainerTata.Address;
            textBox_salary.Text = $"{trainerTata.Salary} LKR";
            textBox_email.Text = trainerTata.Email;
            textBox_nic.Text = trainerTata.NIC;
            textBox_joined_date.Text = trainerTata.HiredDate.ToString("yyyy/MM/dd");

            // Add a padding left of 0s to make the trainer id 3 digits long
            string formattedId = trainerTata.ID.ToString().PadLeft(3, '0');

            // Set the main heading (Trainer Name)
            label_trainer_name.Text = $"{trainerTata.FirstName} {trainerTata.LastName} (T{formattedId})";
        }

        // ** Event: When the logout button is clicked
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

            // Return the user to the login page
            FormProvider.ShowForm(targetForm: FormProvider.Login ?? (FormProvider.Login = new Login()), currentForm: FormProvider.TrainerArea);

            // Assign "null" to the "LoggedUser" property of the "Authentication" class
            Authentication.LoggedUser = null;
        }
    }
}
