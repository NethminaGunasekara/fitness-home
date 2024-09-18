using fitness_home.Services;
using fitness_home.Services.Types;
using fitness_home.Utils;
using fitness_home.Views.Messages;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace fitness_home
{
    public partial class Login : Form
    {
        public static bool hasEmailEntered = false;
        public static bool hasPasswordEntered = false;

        public Login()
        {
            InitializeComponent();

            // Prevent focusing on email textbox on form load
            this.ActiveControl = label_sign_up;
        }

        // Add placeholder text when the focus leaves
        private void AddPlaceholder(object sender, EventArgs e) => Placeholder.Add(ref sender);

        // Remove placeholder text when the focus enters
        private void RemovePlaceholder(object sender, EventArgs e) => Placeholder.Remove(ref sender);

        private void LoginButton_Click(object sender, EventArgs e)
        {
            LoginStatus loginStatus = Authentication.Instance.Login(email: textbox_email.Text, password: textbox_password.Text);

            // Login failed message
            LoginFailed loginError = new LoginFailed();
            loginError.StartPosition = FormStartPosition.Manual;

            int x = this.Location.X + (this.Width / 2) - loginError.Width / 2;
            int y = this.Location.Y + (this.Height / 2) - loginError.Height / 2;

            Point location = new Point(x, y);

            loginError.Location = location;

            // Display login status
            if (loginStatus == LoginStatus.Success)
            {
                MessageBox.Show("Login Successful!");
            }

            else
            {
                loginError.title =
                    loginStatus == LoginStatus.InvalidEmail ?
                        "The email you entered is not found" : "The password you entered is incorrect";

                loginError.message =
                    loginStatus == LoginStatus.InvalidPassword ?
                        "Please check your email and try again" : "Please check your password and try again";

                loginError.ShowDialog();
            }
        }

        private void Email_TextChanged(object sender, EventArgs e)
        {
            ValidateInput.Email(
                sender: ref sender,
                loginButton: ref btn_get_started,
                inputPanel: ref panel_email,
                inputTextBox: ref textbox_email);
        }

        private void Password_TextChanged(object sender, EventArgs e)
        {
            ValidateInput.Password(
                sender: ref sender,
                loginButton: ref btn_get_started,
                inputPanel: ref panel_password,
                inputTextBox: ref textbox_password);
        }
    }
}
