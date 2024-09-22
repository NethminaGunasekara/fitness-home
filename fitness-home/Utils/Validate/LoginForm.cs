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

            // Determine input state based on regex match
            InputState state = email == "Email" ? InputState.Initial :
                Regex.IsMatch(email, emailPattern) ? InputState.Valid : InputState.Invalid;

            // Update UI and login state
            if (state == InputState.Valid)
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
        /// <param name="inputPanel">Panel containing the password TextBox and icon</param>
        /// <param name="inputTextBox">TextBox for entering the user's password</param>
        public static void ValidatePassword(ref object sender, ref Button loginButton)
        {
            TextBox textBox = sender as TextBox;
            string password = textBox.Text;

            // If TextBox contains the placeholder ("Password")
            InputState state = textBox.Text == "Password" ? InputState.Initial :
                // If password has been entered (length > 0)
                password.Length > 0 ? InputState.Valid :
                    // If password is empty
                    InputState.Invalid;

            // Update UI based on state
            if (state == InputState.Valid)
            {
                // Enable login button and set panel background to normal
                Login.hasPasswordEntered = true;
                RegisterForm.SetBackColorDefault(textBox);

            }
            else if (state == InputState.Invalid)
            {
                // Disable login button and set panel background to error
                Login.hasPasswordEntered = false;
                RegisterForm.SetBackColorRed(textBox);
            }
            else
            {
                // Reset to default background and disable login button
                Login.hasPasswordEntered = false;
                RegisterForm.SetBackColorDefault(textBox);
            }

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
