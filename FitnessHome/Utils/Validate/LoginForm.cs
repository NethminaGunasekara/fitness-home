using fitness_home.Utils.Types;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace fitness_home.Utils.Validate
{
    internal class LoginForm
    {

        /// <summary>
        /// Validates the email and updates the UI
        /// </summary>
        /// <param name="sender">TextBox containing the email</param>
        /// <param name="loginButton">Login button which is enabled only when both email and password are valid</param>
        public static void ValidateEmail(ref object sender, ref Button loginButton)
        {
            TextBox textBox = sender as TextBox;
            string email = textBox.Text;

            // Regex pattern for validating email
            // ^        - Start of the string
            // [^@\s]+  - One or more characters that are not "@" or whitespace
            // @        - Exactly one "@" symbol
            // [^@\s]+  - One or more characters that are not "@" or whitespace
            // \.       - Exactly one "." symbol
            // [^@\s]+  - One or more characters that are not "@" or whitespace
            // $        - End of the strin
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            // If textbox still contains the initial value (placeholder)
            if (email == "E-mail")
            {
                Login.hasEmailEntered = false;
                RegisterForm.SetBackColorDefault(textBox);
            }

            // Determine input state based on regex match
            else if (Regex.IsMatch(email, emailPattern))
            {
                Login.hasEmailEntered = true;
                RegisterForm.SetBackColorDefault(textBox);
            }
            else
            {
                Login.hasEmailEntered = false;
                RegisterForm.SetBackColorRed(textBox);
            }

            // Update the login button state
            SetLoginButtonState(ref loginButton);
        }

        /// <summary>
        /// Validates the password and updates the UI
        /// </summary>
        /// <param name="sender">TextBox containing the password</param>
        /// <param name="loginButton">Get Started button which is enabled only when both email and password are valid</param>
        public static void ValidatePassword(ref object sender, ref Button loginButton)
        {
            TextBox textBox = sender as TextBox;
            string password = textBox.Text;

            // If textbox still contains the initial value (placeholder)
            if (password == "Password")
            {
                Login.hasPasswordEntered = false;
                RegisterForm.SetBackColorDefault(textBox);
            }
            // If a valid password has been entered
            else if (!string.IsNullOrEmpty(password))
            {
                Login.hasPasswordEntered = true;
                RegisterForm.SetBackColorDefault(textBox);
            }
            // If the password field is empty
            else
            {
                Login.hasPasswordEntered = false;
                RegisterForm.SetBackColorRed(textBox);
            }

            // Update the state of the login button
            SetLoginButtonState(ref loginButton);
        }

        private static void SetLoginButtonState(ref Button loginButton)
        {
            // Enable the login button if both username and password is present
            if (Login.hasEmailEntered && Login.hasPasswordEntered) loginButton.Enabled = true;
            // Or, disable if any of the inputs is missing
            else loginButton.Enabled = false;
        }
    }
}
