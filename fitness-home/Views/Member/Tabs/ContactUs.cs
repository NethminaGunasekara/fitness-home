using System;
using System.Drawing;
using System.Windows.Forms;
using fitness_home.Services;
using fitness_home.Helpers;

namespace fitness_home.Views.Member.Components.Views
{
    public partial class ContactUs : UserControl
    {
        public ContactUs()
        {
            InitializeComponent();
        }

        // ** Event: When the control is first loaded
        private void ContactUsView_Load(object sender, EventArgs e)
        {
            // Retrieve the logged-in user's details from the authentication class
            int memberId = Authentication.LoggedUser.ID; // Retrieve the logged in member's id
            string firstName = Authentication.LoggedUser.FirstName; // Retrieve the logged in member's first name
            string lastName = Authentication.LoggedUser.LastName; // Retrieve the logged in member's last name

            // Display the logged-in user's full name as the sender (e.g., "Dulanja Nimesh")
            label_from.Text = $"{firstName} {lastName}";
            label_feedback_from.Text = $"{firstName} {lastName}";

            // Apply rounded corners to selected panels
            RoundedCorners.Apply(panel_send_message, panel_provide_feedback, panel_message, panel_feedback_message);
        }

        // ** Click Event: When the button to select trainer as the message receiver is being clicked
        private void button_select_trainer_Click(object sender, EventArgs e)
        {
            // Set default background color to the Admin button
            button_select_admin.BackColor = Color.FromArgb(49, 49, 49);
            // Set the default foreground color to the Admin button (text color)
            button_select_admin.ForeColor = Color.FromArgb(148, 148, 148);

            // Set active button background color to the Trainer button (blue)
            button_select_trainer.BackColor = Color.FromArgb(46, 44, 57);
            // Set active button foreground color to the Trainer button (text color)
            button_select_trainer.ForeColor = Color.FromArgb(118, 87, 255);
        }

        // ** Click Event: When the button to select admin as the message receiver is being clicked
        private void button_select_admin_Click(object sender, EventArgs e)
        {
            // Set active button background color to the Admin button
            button_select_admin.BackColor = Color.FromArgb(46, 44, 57);
            // Set active button foreground color to the Admin button (text color)
            button_select_admin.ForeColor = Color.FromArgb(118, 87, 255);

            // Set default background color to the Trainer button
            button_select_trainer.BackColor = Color.FromArgb(49, 49, 49);
            // Set default foreground color to the Trainer button (text color)
            button_select_trainer.ForeColor = Color.FromArgb(148, 148, 148);
        }

        // ** Click Event: When the send feedback button has clicked
        private void button_send_feedback_Click(object sender, EventArgs e)
        {
            // Ensure the feedback message isn't empty
            if (!string.IsNullOrWhiteSpace(textBox_feedback_message.Text))
            {
                // Initialize an instance of FeedbackManager helper class, in order to use "SaveFeedback" helper method from it
                FeedbackManager feedbackManager = new FeedbackManager();

                // Store the feedback in the database 
                feedbackManager.SaveFeedback(textBox_feedback_message.Text);
            }
        }

        // ** Event: When the control is being resized
        private void ContactUsView_Resize(object sender, EventArgs e)
        {
            // Redraw the rounded corners of selected panels
            RoundedCorners.Apply(panel_send_message, panel_provide_feedback, panel_message, panel_feedback_message);
        }
    }
}
