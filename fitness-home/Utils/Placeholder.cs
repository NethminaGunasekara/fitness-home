using System.Collections.Generic;
using System.Windows.Forms;

namespace fitness_home.Utils
{
    internal class Placeholder
    {
        // TextBox names and their placeholder values
        public static readonly Dictionary<string, string> placeholders = new Dictionary<string, string>
        {
            { "textbox_email", "E-mail" },
            { "textBox_fname", "First name" },
            { "textBox_lname", "Last name" },
            { "textBox_dob", "YYYY/MM/DD" },
            { "textBox_nic", "XXXXXXXXXXXX" },
            { "textBox_email", "E-mail" },
            { "textBox_phone", "Phone" },
            { "textBox_address", "Address" },
            { "textBox_ec_name", "Emergency contact name" },
            { "textBox_ec_phone", "Emergency contact phone" }
        };

        public static void Remove(ref object sender)
        {
            TextBox textBox = sender as TextBox;

            // True if textBox refers to any of the password fields
            bool passwordField = textBox.Name == "textbox_password" || textBox.Name == "textBox_new_password" || textBox.Name == "textBox_confirm_password";

            // Handle password fields separately
            if (passwordField && textBox.PasswordChar != '*')
            {
                // PasswordChar check ensures that only the placeholder will be removed, not the password
                // entered by user (as we keep the PasswordChar '*' if user has typed anything)
                textBox.Text = "";
                textBox.PasswordChar = '*';
            }
            // Handle other fields
            else if (placeholders.ContainsKey(textBox.Name) && textBox.Text == placeholders[textBox.Name])
            {
                textBox.Text = "";
            }
        }

        public static void Add(ref object sender)
        {
            TextBox textBox = sender as TextBox;
            
            // True if textBox refers to any of the password fields
            bool isPasswordField = textBox.Name == "textBox_new_password" || textBox.Name == "textBox_confirm_password";

            if (textBox.Name == "textbox_password" && textBox.Text.Length == 0)
            {
                textBox.PasswordChar = '\0';
                textBox.Text = "Password";
            }

            else if (placeholders.ContainsKey(textBox.Name) && textBox.Text.Length == 0)
            {
                textBox.Text = placeholders[textBox.Name];
            }

            // Handle new password and confirm password fields
            else if (isPasswordField && textBox.Text.Length == 0)
            {
                string placeholder = textBox.Name == "textBox_new_password" ? "New password" : "Confirm password";

                textBox.PasswordChar = '\0';
                textBox.Text = placeholder;
            }
        }
    }
}
