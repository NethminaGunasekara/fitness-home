using AnimateDemo;
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
    public partial class LoginFailed : Form
    {
        public string title;
        public string message;

        public LoginFailed(string title = "", string message = "")
        {
            InitializeComponent();
            this.title = title;
            this.message = message; 
        }

        private void LoginFailed_Load(object sender, EventArgs e)
        {
            label_title.Text = title;
            label_message.Text = message;

            WinAPI.AnimateWindow(this.Handle, 200, WinAPI.BLEND);
        }

        private void button_try_again_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
