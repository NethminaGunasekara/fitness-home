using System;
using System.Windows.Forms;

namespace fitness_home.Views.Messages
{
    public partial class InputError : Form
    {
        public InputError(string errorType = "Form Submission Error!", string errorTitle = "We couldn't process your submission", string errorMessage = "Ensure all fields are filled correctly")
        {
            InitializeComponent();

            // Set error details
            label_error.Text = errorType;
            label_title.Text = errorTitle;
            label_message.Text = errorMessage;
        }

        private void button_try_again_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the message once the "Try Again" button is clicked
        }
    }
}
