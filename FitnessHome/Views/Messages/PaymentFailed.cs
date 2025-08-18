using AnimateDemo;
using System;
using System.Windows.Forms;

namespace fitness_home.Views.Messages
{
    public partial class PaymentFailed : Form
    {
        public PaymentFailed()
        {
            InitializeComponent();
        }

        private void button_try_again_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PaymentFailed_Load(object sender, EventArgs e)
        {
            WinAPI.AnimateWindow(this.Handle, 200, WinAPI.BLEND);
        }
    }
}
