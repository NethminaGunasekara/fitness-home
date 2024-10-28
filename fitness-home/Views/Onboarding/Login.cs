using AnimateDemo;
using fitness_home.Services;
using fitness_home.Utils;
using fitness_home.Utils.Types;
using fitness_home.Utils.Validate;
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

        private void OnLoad(object sender, System.EventArgs e)
        {
            // Set the background image
            this.BackgroundImage = Properties.Resources.Background;

            // Set the background image layout to zoom
            this.BackgroundImageLayout = ImageLayout.Zoom;
        }

        // Add placeholder text when the focus leaves
        private void AddPlaceholder(object sender, EventArgs e) => Placeholder.Add(ref sender);

        // Remove placeholder text when the focus enters
        private void RemovePlaceholder(object sender, EventArgs e) => Placeholder.Remove(ref sender);

        private void LoginButton_Click(object sender, EventArgs e)
        {
            LoginStatus loginStatus = Authentication.Instance.Login(email: textBox_email.Text, password: textbox_password.Text);
 
            // Display login status
            if (loginStatus == LoginStatus.Success)
            {
                // Redirect logged user to a dashboard based on the user type
                Authentication.Instance.ShowDashboard(this);
            }

            // If there's a database connection error
            else if (loginStatus == LoginStatus.DatabaseError)
            {
                // Display the error message
                new ApplicationError(ErrorType.DatabaseError).ShowDialog();
            }

            // If either email isn't found or password is incorrect
            else
            {
                // Login failed message
                LoginFailed loginError = new LoginFailed();

                loginError.title =
                    loginStatus == LoginStatus.InvalidEmail ?
                        "The email you entered is not found" : "The password you entered is incorrect";

                loginError.message =
                    loginStatus == LoginStatus.InvalidEmail ?
                        "Please check your email and try again" : "Please check your password and try again";

                loginError.ShowDialog();
            }
        }

        private void Email_TextChanged(object sender, EventArgs e)
        {
            LoginForm.ValidateEmail(
                sender: ref sender,
                loginButton: ref btn_get_started);
        }

        private void Password_TextChanged(object sender, EventArgs e)
        {
            LoginForm.ValidatePassword(
                sender: ref sender,
                loginButton: ref btn_get_started);
        }

        private void link_sign_up_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormProvider.ShowForm(
                targetForm: FormProvider.Register ?? (FormProvider.Register = new Register()),
                currentForm: this, 
                setSize: false, 
                setPosition: false);
        }

        // ** Event: Return to previous form
        private void button_previous_form_Click(object sender, EventArgs e)
        {
            Welcome WelcomeForm = FormProvider.Welcome ?? (FormProvider.Welcome = new Welcome());
            FormProvider.ShowForm(WelcomeForm, this, setSize: false, setPosition: false);
        }
    }
}
