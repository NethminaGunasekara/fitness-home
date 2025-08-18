using AnimateDemo;
using System;
using System.Windows.Forms;

namespace fitness_home.Views.Messages
{
    public partial class ApplicationError : Form
    {
        public ApplicationError(ErrorType errorType)
        {
            InitializeComponent();

            // Set the error title based on the errorType provided
            switch (errorType)
            {
                case ErrorType.DatabaseError:
                    label_title.Text = "Unable to connect to the database";
                    break;

                default:
                    label_title.Text = "An unexpected error has occurred";
                    break;
            }
        }

        private void button_try_again_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DatabaseError_Load(object sender, EventArgs e)
        {
            WinAPI.AnimateWindow(this.Handle, 200, WinAPI.BLEND);
        }
    }

    public enum ErrorType
    {
        DatabaseError,
        UnexpectedError,
        RegistrationError,
    }
}
