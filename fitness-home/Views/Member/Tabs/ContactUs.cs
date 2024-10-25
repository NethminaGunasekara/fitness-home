using System;
using System.Drawing;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using fitness_home.Services;
using fitness_home.Views.Messages;
using System.Data.SqlClient;
using fitness_home.Helpers;

namespace fitness_home.Views.Member.Components.Views
{
    public partial class ContactUs : UserControl
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

        // Applies rounded corners around selected panels
        private void ApplyRoundedCorners()
        {
            // Initialize a list of pannels to apply rounded corners
            List<Panel> panelsToDraw = new List<Panel> { panel_send_message, panel_provide_feedback, panel_message };

            SuspendLayout();

            // Apply rounded corners to all panels of the list above
            panelsToDraw.ForEach((Panel panel) =>
            {
                panel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel.Width, panel.Height, 12, 12));
            });

            ResumeLayout();
        }

        string MessageTo = "TRAINER";

        public ContactUs()
        {
            InitializeComponent();
        }

        // ** Event: When the control is first loaded
        private void ContactUsView_Load(object sender, EventArgs e)
        {
            // Apply rounded corners to relevant panels for a smooth UI appearance
            ApplyRoundedCorners();

            // Retrieve the logged-in user's details from the authentication class
            int memberId = Authentication.LoggedUser.ID;
            string firstName = Authentication.LoggedUser.FirstName;
            string lastName = Authentication.LoggedUser.LastName;

            // Display the logged-in user's full name as the sender (e.g., "Dulanja Nimesh")
            label_from.Text = $"{firstName} {lastName}";
            label_feedback_from.Text = $"{firstName} {lastName}";

            // Format the member ID by prefixing it with 'M' and padding with leading zeros
            // Example: If memberId = 1, the result will be "M001"
            //
            // Methods used: 
            // ** ToString() converts the integer memberId to a string.
            // ** PadLeft(3, '0') ensures that the string is at least 3 characters long by 
            //   adding '0' characters to the left if necessary. If the ID is already 
            //   3 or more digits, no padding is applied.
            label_from_id.Text = $"M{memberId.ToString().PadLeft(3, '0')}";
            label_feedback_from_id.Text = $"M{memberId.ToString().PadLeft(3, '0')}";
        }

        // ** Event: When the control is being resized
        private void ContactUsView_Resize(object sender, EventArgs e)
        {
            ApplyRoundedCorners();
        }

        private void button_select_trainer_Click(object sender, EventArgs e)
        {
            // Prepare the message to be sent to the trainer
            MessageTo = "TRAINER";

            // Set default background color to the Admin button
            button_select_admin.BackColor = Color.FromArgb(49, 49, 49);
            button_select_admin.ForeColor = Color.FromArgb(148, 148, 148);

            // Set active background color to the Trainer button
            button_select_trainer.BackColor = Color.FromArgb(46, 44, 57);
            button_select_trainer.ForeColor = Color.FromArgb(118, 87, 255);
        }

        private void button_select_admin_Click(object sender, EventArgs e)
        {
            // Prepare the message to be sent to the admin
            MessageTo = "ADMIN";

            // Set active background color to the Admin button
            button_select_admin.BackColor = Color.FromArgb(46, 44, 57);
            button_select_admin.ForeColor = Color.FromArgb(118, 87, 255);

            // Set default background color to the Trainer button
            button_select_trainer.BackColor = Color.FromArgb(49, 49, 49);
            button_select_trainer.ForeColor = Color.FromArgb(148, 148, 148);
        }

        // ** Event: When the send feedback button has clicked
        private void button_send_feedback_Click(object sender, EventArgs e)
        {
            // Ensure the feedback message isn't empty
            if (!string.IsNullOrWhiteSpace(textBox_feedback_message.Text))
            {
                // Store the feedback in the database
                FeedbackManager.Instance.SaveFeedback(textBox_feedback_message.Text);
            }
            else
            {
                MessageBox.Show("Please enter a message before sending.", "Empty Feedback", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ** Event: When the send message button has clicked
        private void button_send_message_Click(object sender, EventArgs e)
        {
            // If both subject and message are present
            if(textBox_message_subject.Text.Length > 0 && textBox_message.Text.Length > 0)
            {
                // Initialize the message sent dialog to let the user know that their message is received
                // Convert the value of MessageTo (ADMIN/TRAINER) to lowercase before passing it to the dialog box
                MessageSent messageSent = new MessageSent(MessageTo.ToLower());

                // Display the message sent dialog box
                messageSent.ShowDialog();
            }
        }
    }
}
