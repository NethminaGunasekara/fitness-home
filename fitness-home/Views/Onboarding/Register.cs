using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fitness_home
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            // Update the margin right value of heading
            label_sign_up.Margin = new System.Windows.Forms.Padding(0, 0, panel_previous.Width, 0);
        }

        private void OnResize(object sender, EventArgs e)
        {
            // Update the margin right value of heading
            label_sign_up.Margin = new System.Windows.Forms.Padding(0, 0, panel_previous.Width, 0);
        }

        private void button_sign_up_Click(object sender, EventArgs e)
        {

        }

        private void textbox_email_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void table_registration_page_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label_sign_up_Click(object sender, EventArgs e)
        {

        }
    }
}
