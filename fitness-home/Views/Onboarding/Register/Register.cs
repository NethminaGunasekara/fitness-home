using AnimateDemo;
using fitness_home.Services;
using fitness_home.Utils;
using fitness_home.Utils.Types;
using fitness_home.Utils.Validate;
using fitness_home.Views.Messages;
using fitness_home.Views.Onboarding.Register;
using fitness_home.Views.Onboarding.Register.Services;
using fitness_home.Views.Onboarding.Register.Types;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace fitness_home
{
    public partial class Register : Form
    {
        // Store the information provided by the user untill registration process completes
        public static RegistrationInfo RegistrationInfo;

        // Validate inputs provided by the user
        public static Dictionary<string, bool> HasEntered = new Dictionary<string, bool>();
        private static bool HasRequiredChars;
        private static bool HasRequiredLength;
        private static bool PasswordsMatch;

        public Register()
        {
            InitializeComponent();

            // Initialize fields to check
            HasEntered.Add("textBox_fname", false);
            HasEntered.Add("textBox_lname", false);
            HasEntered.Add("textBox_dob", false);
            HasEntered.Add("textBox_nic", true); // NIC is optional
            HasEntered.Add("gender", false);
            HasEntered.Add("textBox_email", false);
            HasEntered.Add("textBox_phone", false);
            HasEntered.Add("textBox_address", false);
            HasEntered.Add("password", false);
            HasEntered.Add("textBox_ec_name", false);
            HasEntered.Add("textBox_ec_phone", false);
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

            // Update the margin right value of heading
            label_page_heading.Margin = new Padding(0, 0, panel_previous.Width, 0);

        }

        private void OnResize(object sender, EventArgs e)
        {
            label_page_heading.Margin = new Padding(0, 0, panel_previous.Width, 0);
        }

        // Add placeholder text when the focus leaves
        private void AddPlaceholder(object sender, EventArgs e) => Placeholder.Add(ref sender);

        // Remove placeholder text when the focus enters
        private void RemovePlaceholder(object sender, EventArgs e) => Placeholder.Remove(ref sender);

        // Only allow digits and control keys for required fields
        private void NumericOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar));
        }

        // ** Event: Validate first name
        private void textBox_fname_TextChanged(object sender, EventArgs e)
        {
            RegisterForm.PresenceCheck(sender, e);
            RegisterForm.UpdateSignUpButtonState(button_sign_up);
        }

        // ** Event: Validate last name
        private void textBox_lname_TextChanged(object sender, EventArgs e)
        {
            RegisterForm.PresenceCheck(sender, e);
            RegisterForm.UpdateSignUpButtonState(button_sign_up);
        }

        // ** Event: Validate date of birth
        private void textBox_dob_TextChanged(object sender, EventArgs e)
        {
            RegisterForm.ValidateDOB(sender, e);
            RegisterForm.UpdateSignUpButtonState(button_sign_up);
        }

        // ** Event: Validate NIC number
        private void textBox_nic_TextChanged(object sender, EventArgs e)
        {
            RegisterForm.ValidateNIC(sender, e);
            RegisterForm.UpdateSignUpButtonState(button_sign_up);
        }

        // ** Event: Validate Gender
        private void radioButton_gender_CheckedChanged(object sender, EventArgs e)
        {
            // No checks are needed as the gender cannot be unchecked
            HasEntered["gender"] = true;
            RegisterForm.UpdateSignUpButtonState(button_sign_up);
        }

        // ** Event: Validate Email
        private void textBox_email_TextChanged(object sender, EventArgs e)
        {
            RegisterForm.ValidateEmail(sender, e);
            RegisterForm.UpdateSignUpButtonState(button_sign_up);
        }

        // ** Event: Validate Phone Number
        private void textBox_phone_TextChanged(object sender, EventArgs e)
        {
            RegisterForm.PresenceCheck(sender, e, 10);
            RegisterForm.UpdateSignUpButtonState(button_sign_up);
        }

        // ** Event: Validate Address
        private void textBox_address_TextChanged(object sender, EventArgs e)
        {
            RegisterForm.PresenceCheck(sender, e, 12);
            RegisterForm.UpdateSignUpButtonState(button_sign_up);
        }

        // ** Event: Validate New Password
        private void textBox_password_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string password = textBox.Text;

            // Conditions for password validation
            bool hasUpperCase = password.Any(char.IsUpper);
            bool hasLowerCase = password.Any(char.IsLower);
            bool hasDigit = password.Any(char.IsDigit);

            HasRequiredChars = hasUpperCase && hasLowerCase && hasDigit;
            HasRequiredLength = password.Length >= 8 && password.Length <= 24 && textBox.PasswordChar == '*';
            PasswordsMatch = textBox_confirm_password.Text.Equals(password);

            // Display password policy pannel (if hidden)
            if (!panel_pw_policy.Visible)
                panel_pw_policy.Visible = true;

            // Set password policy status
            SetPasswordValidity(HasRequiredChars, HasRequiredLength, PasswordsMatch);

            // Mark password as entered if it follows the password policy
            HasEntered["password"] = HasRequiredChars && HasRequiredLength && PasswordsMatch;
        }

        private void textBox_confirm_password_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string password = textBox.Text;

            PasswordsMatch = textBox_new_password.Text.Equals(password);

            // Set password policy status
            SetPasswordValidity(HasRequiredChars, HasRequiredLength, PasswordsMatch);

            // Mark password as entered if it follows the password policy
            HasEntered["password"] = HasRequiredChars && HasRequiredLength && PasswordsMatch;
        }

        private void SetPasswordValidity(bool hasRequiredChars = false, bool hasRequiredLength = false, bool passwordsMatch = false)
        {
            Color clrRed = Color.FromArgb(255, 34, 0);
            Color clrGreen = Color.FromArgb(161, 210, 0);

            Bitmap crossIcon = Properties.Resources.pw_policy_cross;
            Bitmap tickIcon = Properties.Resources.pw_policy_tick;

            // Set label colors based on parameters provided
            label_char_rqmt.ForeColor = hasRequiredChars ? clrGreen : clrRed;
            label_length_rqmt.ForeColor = hasRequiredLength ? clrGreen : clrRed;
            label_passwords_match.ForeColor = passwordsMatch ? clrGreen : clrRed;

            // Set icons based on parameters provided
            icon_char_rqmt.BackgroundImage = hasRequiredChars ? tickIcon : crossIcon;
            icon_length_rqmt.BackgroundImage = hasRequiredLength ? tickIcon : crossIcon;
            icon_passwords_match.BackgroundImage = passwordsMatch ? tickIcon : crossIcon;
        }

        private void textBox_ec_name_TextChanged(object sender, EventArgs e)
        {
            RegisterForm.PresenceCheck(sender, e);
            RegisterForm.UpdateSignUpButtonState(button_sign_up);
        }

        private void textBox_ec_phone_TextChanged(object sender, EventArgs e)
        {
            RegisterForm.PresenceCheck(sender, e, 10);
            RegisterForm.UpdateSignUpButtonState(button_sign_up);
        }

        // ** Event: Return to previous form
        private void button_previous_form_Click(object sender, EventArgs e)
        {
            Login LoginForm = FormProvider.Login ?? (FormProvider.Login = new Login());
            Helpers.ShowForm(LoginForm, this, setSize: false, setPosition: false);
        }

        private bool CheckKeyFields()
        {
            bool proceedToRegister = false;

            // Create a connection to the database
            using (SqlConnection conn = new SqlConnection(Authentication.Instance.ConnectionString))
            {
                conn.Open();

                // Check if the email already exists in the account table and the role is "Member"
                string query = "SELECT COUNT(*) FROM account WHERE email = @Email AND role = @Role";

                using (SqlCommand checkEmailCmd = new SqlCommand(query, conn))
                {
                    checkEmailCmd.Parameters.AddWithValue("@Email", RegistrationInfo.Email);
                    checkEmailCmd.Parameters.AddWithValue("@Role", Role.Member.ToString());
                    int emailCount = (int)checkEmailCmd.ExecuteScalar();

                    // If email already exists, display an error message
                    if (emailCount > 0)
                    {
                        MessageBox.Show("The email is already registered. Please use a different email.", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        proceedToRegister = true;
                    }
                }

                // Check if the NIC already exists in the member table
                query = "SELECT COUNT(*) FROM member WHERE nic = @NIC";

                using (SqlCommand checkNICCmd = new SqlCommand(query, conn))
                {
                    checkNICCmd.Parameters.AddWithValue("@NIC", RegistrationInfo.NIC);
                    int nicCount = (int)checkNICCmd.ExecuteScalar();

                    // If NIC already exists, display an error message
                    if (nicCount > 0)
                    {
                        MessageBox.Show("The NIC is already registered. Please use a different NIC.", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        proceedToRegister = false;
                    }
                }
            }

            return proceedToRegister;
        }

        private void button_sign_up_Click(object sender, EventArgs e)
        {
            // Parse the input and get a "DateTime" object
            DateTime dob = DateTime.ParseExact(textBox_dob.Text, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture);
            // Determine the gender based on which radio button ic checked
            Gender gender = radioButton_male.Checked ? Gender.Male : Gender.Female;

            // Retrieve all inputs and store them as an instance of "RegistrationInfo"
            RegistrationInfo = new RegistrationInfo(
                firstName: textBox_fname.Text,
                lastName: textBox_lname.Text,
                dob, // Parsed date of birth
                nic: textBox_nic.Text,
                gender,
                email: textBox_email.Text,
                phone: textBox_phone.Text,
                address: textBox_address.Text,
                password: textBox_new_password.Text,
                ecName: textBox_ec_name.Text,
                ecPhone: textBox_ec_phone.Text
            );

            // Proceed to the membership selection page
            Membership Membership = FormProvider.Membership ?? (FormProvider.Membership = new Membership());
            Helpers.ShowForm(Membership, this, false, false);
        }

        public static void FinishRegistration(int transactionId)
        {
            try
            {
                // Create a connection to the database
                using (SqlConnection conn = new SqlConnection(Authentication.Instance.ConnectionString))
                {
                    conn.Open();

                    // If both email and NIC are available, continue to register the new member
                    string query = @"INSERT INTO member (first_name, last_name, dob, nic, gender, email, phone, address, ec_name, ec_phone, plan_id, plan_expiry) 
                            VALUES (@FirstName, @LastName, @Dob, @Nic, @Gender, @Email, @Phone, @Address, @EcName, @EcPhone, @PlanId, @PlanExpiry);
                            SELECT SCOPE_IDENTITY();";

                    int newMemberId = 0; // Variable to store the new member's ID

                    // Insert the new member's details to the "member" table
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", RegistrationInfo.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", RegistrationInfo.LastName);
                        cmd.Parameters.AddWithValue("@Dob", RegistrationInfo.DOB);
                        cmd.Parameters.AddWithValue("@Nic", RegistrationInfo.NIC);
                        cmd.Parameters.AddWithValue("@Gender", RegistrationInfo.Gender.ToString());
                        cmd.Parameters.AddWithValue("@Email", RegistrationInfo.Email);
                        cmd.Parameters.AddWithValue("@Phone", RegistrationInfo.Phone);
                        cmd.Parameters.AddWithValue("@Address", RegistrationInfo.Address);
                        cmd.Parameters.AddWithValue("@EcName", RegistrationInfo.ECName);
                        cmd.Parameters.AddWithValue("@EcPhone", RegistrationInfo.ECPhone);

                        // Assign the selected membership plan and set the expiry date to one month from the current date.
                        cmd.Parameters.AddWithValue("@PlanId", RegistrationInfo.MembershipPlan.PlanId);
                        cmd.Parameters.AddWithValue("@PlanExpiry", DateTime.Now.AddMonths(1));

                        // Execute the query and retrieve the new member ID
                        // SCOPE_IDENTITY() function retrieves the last inserted identity value
                        newMemberId = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // Insert the new member's login details into the account table
                    query = @"INSERT INTO account (role, email, password) 
                            VALUES (@Role, @Email, @Password)";
                    using (SqlCommand insertAccountCmd = new SqlCommand(query, conn))
                    {
                        insertAccountCmd.Parameters.AddWithValue("@Role", Role.Member.ToString());
                        insertAccountCmd.Parameters.AddWithValue("@Email", RegistrationInfo.Email);
                        insertAccountCmd.Parameters.AddWithValue("@Password", Authentication.Instance.HashPassword(RegistrationInfo.Password));

                        insertAccountCmd.ExecuteNonQuery();
                    }

                    // Assign new member to the selected group
                    AssignMemberToGroup(conn, newMemberId, RegistrationInfo.MembershipPlan.PlanId);

                    // Update the transaction record by assigning it the new member's ID
                    query = @"UPDATE [transaction]
                            SET member_id = @MemberId
                            WHERE transaction_id = @TransactionId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MemberId", newMemberId);
                        cmd.Parameters.AddWithValue("@TransactionId", transactionId);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Catch SQL errors
            catch (SqlException sqlEx)
            {
                // Log the error for debugging purposes
                Console.WriteLine($"SQL Error: ${sqlEx.Message}");

                // Display database error message
                new ApplicationError(ErrorType.DatabaseError).ShowDialog();
            }

            // Catch any other errors
            catch (Exception e)
            {
                // Log the error for debugging purposes
                Console.WriteLine($"Unexpected Error: ${e.Message}");

                // Display application error message
                new ApplicationError(ErrorType.UnexpectedError).ShowDialog();
            }
        }

        // Assign members to a group within the "member_group" table based on their membership plan id
        public static void AssignMemberToGroup(SqlConnection conn, int memberId, int planId)
        {
            // Query to get the maximum group number for a given plan_id
            using (SqlCommand cmd = new SqlCommand("SELECT MAX(group_number) FROM member_group WHERE plan_id = @planId", conn))
            {
                // Assign a planId to the query
                cmd.Parameters.AddWithValue("@planId", planId);

                // Execute the query and store the result (highest group_number)
                object maxGroupNumber = cmd.ExecuteScalar();

                // If a group exists, increment the group number, otherwise, start at group 1
                int groupNumber = maxGroupNumber != DBNull.Value ? (int)maxGroupNumber + 1 : 1;

                // Check if the current group (groupNumber) already has 24 members
                using (SqlCommand checkGroupCount = new SqlCommand("SELECT COUNT(*) FROM member_group WHERE group_number = @groupNumber AND plan_id = @planId", conn))
                {
                    // Add groupNumber and planId as parameters to the query
                    checkGroupCount.Parameters.AddWithValue("@groupNumber", groupNumber);
                    checkGroupCount.Parameters.AddWithValue("@planId", planId);

                    // Execute the query and store the number of members in the group
                    int groupCount = (int)checkGroupCount.ExecuteScalar();

                    // While the group is full (24 members), increment groupNumber and check the next group
                    while (groupCount >= 24)
                    {
                        groupNumber++; // Move to the next group number
                        
                        // Update the query parameter to check the new group number
                        checkGroupCount.Parameters["@groupNumber"].Value = groupNumber;
                        
                        // Re-execute the query to get the member count of the new group
                        groupCount = (int)checkGroupCount.ExecuteScalar();
                    }
                }

                // Insert the new member into the determined group (groupNumber)
                using (SqlCommand insertCmd = new SqlCommand("INSERT INTO member_group (member_id, plan_id, group_number) VALUES (@memberId, @planId, @groupNumber)", conn))
                {
                    // Add memberId, planId, and groupNumber as parameters to the insert query
                    insertCmd.Parameters.AddWithValue("@memberId", memberId);
                    insertCmd.Parameters.AddWithValue("@planId", planId);
                    insertCmd.Parameters.AddWithValue("@groupNumber", groupNumber);

                    // Execute the insert command to add the new member to the member_group table
                    insertCmd.ExecuteNonQuery();
                }
            }
        }

        private void button_fill_data_Click(object sender, EventArgs e)
        {
            textBox_fname.Text = "Nethmina";
            textBox_lname.Text = "Gunasekara";
            textBox_dob.Text = "2003/09/15";
            textBox_nic.Text = "200325911491";
            textBox_email.Text = "gunasekaraditn@gmail.com";
            textBox_phone.Text = "0778168232";
            textBox_address.Text = "158, Doranagoda, Udugampola";
            textBox_new_password.PasswordChar = '*';
            textBox_confirm_password.PasswordChar = '*';
            textBox_new_password.Text = "Nethmina2003530";
            textBox_confirm_password.Text = "Nethmina2003530";
            textBox_ec_name.Text = "Ruwanthika Gunasekara";
            textBox_ec_phone.Text = "0763241947";
        }
    }
}
