using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fitness_home.Views.Messages
{
    public partial class FeedbackReceived : Form
    {
        public FeedbackReceived()
        {
            InitializeComponent();
        }

        private void button_continue_Click(object sender, EventArgs e)
        {
            // Close the message box
            this.Close();
        }
    }
}
