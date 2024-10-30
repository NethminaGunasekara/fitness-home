using fitness_home.Helpers;
using fitness_home.Services;
using fitness_home.Utils.Types.UserTypes;
using fitness_home.Views.Messages;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace fitness_home.Views.Member.Components.Views
{
    public partial class ProfileView : UserControl
    {
        // Code required to create rounded rectangle panels
        // Source: https://stackoverflow.com/questions/38632035/winforms-smooth-the-rounded-edges-for-panel
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        // Boolean value to determine if the user can update their profile (i.e. data entered are valid)
        bool CanUpdate = true;

        // Retrieve and store the details about the logged in member
        User memberData = Authentication.LoggedUser;

        public ProfileView()
        {
            InitializeComponent();

            // Assign member data to the fields within the profile view interface
            textBox_first_name.Text = memberData.FirstName;
            textBox_last_name.Text = memberData.LastName;
            textBox_dob.Text = memberData.DateOfBirth.ToString("yyyy/MM/dd");
            textBox_phone.Text = memberData.Phone;
            textBox_address.Text = memberData.Address;
            textBox_ec_name.Text = memberData.EmergencyContactName;
            textBox_ec_phone.Text = memberData.EmergencyContactPhone;
            textBox_email.Text = memberData.Email;

            // Display the member's full name in profile overview section
            label_member_name.Text = $"{memberData.FirstName} {memberData.LastName}";

            // Retrieve the membership plan name in the profile overview section using the "GetPlanById()" helper method
            string membershipPlanName = MembershipPlan.Instance.GetPlanNameById(memberData.PlanID);

            // Retrieve the group number for the current member, null if no group is found
            int? groupNumber = MembershipPlan.Instance.GetGroupNumberForMember(memberData.ID, memberData.PlanID);


            if (groupNumber != null)
            {
                // Display the retrieved membership plan name along with the group number
                label_membership_plan.Text = $"{membershipPlanName} (Group {groupNumber})";

                return; // Exit the method, otherwise the application proceed to overwrite the value of "label_membership_plan.Text"
            }

            // Display the retrieved membership plan name
            label_membership_plan.Text = membershipPlanName;
        }

        // ** Event: Triggered when the control is first loaded. 
        private void ProfileView_Load(object sender, EventArgs e)
        {
            // Apply rounded corners to the main panel
            panel_content.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel_content.Width, panel_content.Height, 12, 12));
        }

        // ** Event: Triggered when the form is resized.
        private void ProfileView_Resize(object sender, EventArgs e)
        {
            // Redraw rounded corners of the main panel as it's being resized
            panel_content.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel_content.Width, panel_content.Height, 12, 12));
        }

        // ** Event: Triggered when the form is resized.
        private void button_update_profile_Click(object sender, EventArgs e)
        {
            // Try to parse phone and emergency contact phone numbers to long to ensure that they only contain numeric values
            try
            {
                long phone = long.Parse(textBox_phone.Text);
                long ecPhone = long.Parse(textBox_ec_phone.Text);
            }
            catch (FormatException)
            {
                // Show error message dialog for invalid phone number
                InputError phoneError = new InputError(
                    errorType: "Invalid Input",
                    errorTitle: "Invalid Phone Number Format",
                    errorMessage: "Please enter a valid phone number with digits only"
                );
                phoneError.ShowDialog();
                return; // Exit the method
            }

            // If no errors are occurred, proceed to update the profile
            memberData.Phone = textBox_phone.Text;
            memberData.Address = textBox_address.Text;
            memberData.EmergencyContactName = textBox_ec_name.Text;
            memberData.EmergencyContactPhone = textBox_ec_phone.Text;

            // Errpr handling for password update process
            try
            {
                // If the user has entered a new password, proceed to update it
                if (textBox_password.Text.Length >= 1)
                {
                    // Hash the password before storing it in the database
                    string hashedPassword = Authentication.Instance.HashPassword(textBox_password.Text);

                    // Update the password in the "account" table
                    using (var connection = new SqlConnection(Authentication.Instance.ConnectionString))
                    {
                        string query = "UPDATE account SET password = @Password WHERE email = @Email";
                        using (var command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Password", hashedPassword);
                            command.Parameters.AddWithValue("@Email", memberData.Email);

                            connection.Open();
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }

            // Catch connection error
            catch (SqlException)
            {
                // Display the database error message
                ApplicationError applicationError = new ApplicationError(ErrorType.DatabaseError);

                applicationError.ShowDialog();
            }

            // Show success message dialog for profile update
            SuccessMessage profileUpdateSuccess = new SuccessMessage(
                heading: "Profile Updated!",
                title: "Your profile information has been successfully updated.",
                reference: "All changes have been saved."
            );
            profileUpdateSuccess.ShowDialog();
        }

        // ** Event: When the password is being typed
        private void textBox_password_TextChanged(object sender, EventArgs e)
        {
            string password = textBox_password.Text;

            // Conditions for password validation
            bool hasUpperCase = password.Any(char.IsUpper);
            bool hasLowerCase = password.Any(char.IsLower);
            bool hasDigit = password.Any(char.IsDigit);

            bool hasRequiredChars = hasUpperCase && hasLowerCase && hasDigit;
            bool hasRequiredLength = password.Length >= 16 && password.Length <= 24;

            // Display password policy pannel (if hidden)
            if (!panel_pw_policy.Visible)
                panel_pw_policy.Visible = true;

            // Colors used for password policy messages
            Color clrRed = Color.FromArgb(255, 34, 0);
            Color clrGreen = Color.FromArgb(161, 210, 0);

            // Icons used for password policy messages
            Bitmap crossIcon = Properties.Resources.pw_policy_cross;
            Bitmap tickIcon = Properties.Resources.pw_policy_tick;

            // Enable or disable the "Update Profile" button
            // If both conditions are true, the button gets enabled. Otherwise keeps disabled
            button_update_profile.Enabled = hasRequiredChars && hasRequiredLength;

            // Set password policy status: if the password has required characters
            if (hasRequiredChars)
            {
                // Set label color of the character requirement to green
                label_char_rqmt.ForeColor = clrGreen;

                // Set icon of the character requirement to tick
                icon_char_rqmt.BackgroundImage = tickIcon;

                // Enable the "Update Profile" button
            }

            // Set password policy status: if the password doesn't have required characters
            else
            {
                // Set label color of the character requirement to red
                label_char_rqmt.ForeColor = clrRed;

                // Set icon of the character requirement to cross
                icon_char_rqmt.BackgroundImage = crossIcon;
            }

            // Set password policy status: if the password has required length
            if (hasRequiredLength)
            {
                // Set label color of the length requirement to green
                label_length_rqmt.ForeColor = clrGreen;

                // Set icon of the length requirement to tick
                icon_length_rqmt.BackgroundImage = tickIcon;
            }

            // Set password policy status: if the password doesn't have required length
            else
            {
                // Set label color of the length requirement to red
                label_length_rqmt.ForeColor = clrRed;

                // Set icon of the length requirement to cross
                icon_length_rqmt.BackgroundImage = crossIcon;
            }
        }

        // ** Event: When the textbox for entering password loses user focus
        private void textBox_password_Leave(object sender, EventArgs e)
        {
            // If the user left it empty
            if(textBox_password.Text.Length == 0)
            {
                // Enable the "Update Profile" button by assuming that they wanted to abort changing password
                // However, the rest of fields get changed except the password field
                button_update_profile.Enabled = true;

                // Hide the password policy panel as we don't want it until the user focuses on the password textbox again
                panel_pw_policy.Visible = false;
            }
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

            // Assign "null" to the "LoggedUser" property of the "Authentication" class
            Authentication.LoggedUser = null;

            // Return the user to the login page
            FormProvider.ShowForm(targetForm: FormProvider.Login ?? (FormProvider.Login = new Login()), currentForm: FormProvider.MemberArea);
        }
    }
}
