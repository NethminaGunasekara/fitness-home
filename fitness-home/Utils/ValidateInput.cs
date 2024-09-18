using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace fitness_home.Utils
{
    internal class ValidateInput
    {
        /// <summary>
        /// Validates the email and updates the UI
        /// </summary>
        /// <param name="sender">TextBox containing the email</param>
        /// <param name="loginButton">Login button which is enabled only when both email and password are valid</param>
        /// <param name="inputPanel">Panel containing the email TextBox and icon</param>
        /// <param name="inputTextBox">TextBox for entering the user's email</param>
        public static void Email(ref object sender, ref Button loginButton, ref Panel inputPanel, ref TextBox inputTextBox)
        {
            TextBox textBox = sender as TextBox;

            string[] emailParts = textBox.Text.Split('@');

            // If TextBox contains the placeholder ("Email")
            InputState state = textBox.Text == "Email" ? InputState.Initial :
                // If email contains "@" symbol, followed by ".", and no whitespaces
                emailParts.Length >= 2 && emailParts[1].Contains(".") && !textBox.Text.Contains(" ") ? InputState.Valid :
                    // If email is incomplete
                    InputState.Invalid;

            // Update UI based on state
            if (state == ValidateInput.InputState.Valid)
            {
                // Enable login button and set panel background to normal
                Login.hasEmailEntered = true;
                inputPanel.BackColor = Color.FromArgb(41, 41, 41);
                inputTextBox.BackColor = Color.FromArgb(41, 41, 41);

            }

            else if (state == ValidateInput.InputState.Invalid)
            {
                // Disable login button and set panel background to error
                Login.hasEmailEntered = false;
                inputPanel.BackColor = Color.FromArgb(70, 41, 41);
                inputTextBox.BackColor = Color.FromArgb(70, 41, 41);
            }

            else
            {
                // Reset to default background and disable login button
                Login.hasEmailEntered = false;
                inputPanel.BackColor = Color.FromArgb(41, 41, 41);
                inputTextBox.BackColor = Color.FromArgb(41, 41, 41);
            }

            // Update the state of the login button
            SetLoginButtonState(ref loginButton);
        }

        /// <summary>
        /// Validates the password and updates the UI
        /// </summary>
        /// <param name="sender">TextBox containing the password</param>
        /// <param name="loginButton">Get Started button which is enabled only when both email and password are valid</param>
        /// <param name="inputPanel">Panel containing the password TextBox and icon</param>
        /// <param name="inputTextBox">TextBox for entering the user's password</param>
        public static void Password(ref object sender, ref Button loginButton, ref Panel inputPanel, ref TextBox inputTextBox)
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
            if (state == ValidateInput.InputState.Valid)
            {
                // Enable login button and set panel background to normal
                Login.hasPasswordEntered = true;
                inputPanel.BackColor = Color.FromArgb(41, 41, 41);
                inputTextBox.BackColor = Color.FromArgb(41, 41, 41);

            }
            else if (state == ValidateInput.InputState.Invalid)
            {
                // Disable login button and set panel background to error
                Login.hasPasswordEntered = false;
                inputPanel.BackColor = Color.FromArgb(70, 41, 41);
                inputTextBox.BackColor = Color.FromArgb(70, 41, 41);
            }
            else
            {
                // Reset to default background and disable login button
                Login.hasPasswordEntered = false;
                inputPanel.BackColor = Color.FromArgb(41, 41, 41);
                inputTextBox.BackColor = Color.FromArgb(41, 41, 41);
            }

            SetLoginButtonState(ref loginButton);
        }

        public enum InputState
        {
            Valid,
            Invalid,
            Initial, // Initial value (placeholder)
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