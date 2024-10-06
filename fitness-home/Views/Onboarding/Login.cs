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
                // Redirect logged user to a dashboard based on the user type
                Authentication.Instance.ShowDashboard(this);
            }

            // If there's a database connection error
            else if (loginStatus == LoginStatus.DatabaseError)
            {
                DatabaseError databaseError = new DatabaseError();
                
                // Set error message position
                databaseError.StartPosition = FormStartPosition.Manual;

                Point messageLocation = new Point(
                    x: this.Location.X + (this.Width / 2) - databaseError.Width / 2,
                    y: this.Location.Y + (this.Height / 2) - databaseError.Height / 2); 

                databaseError.Location = messageLocation;

                // Display the error message
                databaseError.ShowDialog();
            }

            // If either email isn't found or password is incorrect
            else
            {
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
            Helpers.ShowForm(
                targetForm: FormProvider.Register ?? (FormProvider.Register = new Register()),
                currentForm: this, 
                setSize: false, 
                setPosition: false);
        }

        private void panel_previous_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_logo_Paint(object sender, PaintEventArgs e)
        {

        }

        // ** Event: Return to previous form
        private void button_previous_form_Click(object sender, EventArgs e)
        {
            Welcome WelcomeForm = FormProvider.Welcome ?? (FormProvider.Welcome = new Welcome());
            Helpers.ShowForm(WelcomeForm, this, setSize: false, setPosition: false);
        }
    }
}
