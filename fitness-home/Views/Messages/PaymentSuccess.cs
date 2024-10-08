using AnimateDemo;
using System.Windows.Forms;

namespace fitness_home.Views.Messages
{
    public partial class PaymentSuccess : Form
    {
        public PaymentSuccess(string paymentAmount, bool cashPayment = false)
        {
            InitializeComponent();

            // Set the title text to indicate the type of payment
            label_title.Text = cashPayment ? $"Payment Pending: {paymentAmount}" : $"Amount Charged: {paymentAmount}";
        }

        private void PaymentSuccess_Load(object sender, System.EventArgs e)
        {
            WinAPI.AnimateWindow(this.Handle, 200, WinAPI.BLEND);
        }

        // Redirect user to their dashboard
        private void ShowDashboard(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
