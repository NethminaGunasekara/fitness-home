using System;
using System.Windows.Forms;

namespace fitness_home.Views.Messages
{
    public partial class MessageSent : Form
    {
        public MessageSent(string receiver)
        {
            InitializeComponent();

            // Set the message
            label_message.Text = $"The {receiver} will get back to you soon.";
        }

        private void button_continue_Click(object sender, EventArgs e)
        {
            // Close the message box
            this.Close();
        }
    }
}
