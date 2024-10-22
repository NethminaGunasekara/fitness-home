using System.Windows.Forms;

namespace fitness_home.Views.Messages
{
    public partial class RegistrationError : Form
    {
        public RegistrationError(InputErrorType inputErrorType)
        {
            InitializeComponent();

            // Set the error name, title, and message based on the errorType provided
            switch (inputErrorType)
            {
                case InputErrorType.DuplicateEmail:
                    label_message.Text = "Email Already Registered";
                    break;

                case InputErrorType.DuplicateNIC:
                    label_message.Text = "NIC Already Registered";
                    break;

                case InputErrorType.DuplicateEmailAndNIC:
                    label_message.Text = "NIC and Email already registered";
                    break;

                default:
                    label_title.Text = "An unexpected error has occurred";
                    break;
            }
        }

        private void button_try_again_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }

    public enum InputErrorType
    {
        None,
        DuplicateEmail,
        DuplicateNIC,
        DuplicateEmailAndNIC,
    }
}
