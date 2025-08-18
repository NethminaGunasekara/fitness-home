using System;
using System.Windows.Forms;

namespace fitness_home.Views.Messages
{
    public partial class SuccessMessage : Form
    {
        // Constructor with default parameter values
        public SuccessMessage(
            string heading = "Class Added!",
            string title = "Your class has been added to the schedule!",
            string reference = "Members will now see this class on their schedule"
        )
        {
            InitializeComponent();

            // Set labels with parameter values
            label_heading.Text = heading;
            label_title.Text = title;
            label_reference.Text = reference;
        }

        // Close the message dialog when the "Done" button is clicked
        private void button_dashboard_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
