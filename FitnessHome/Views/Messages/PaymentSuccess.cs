using AnimateDemo;
using System.Windows.Forms;

namespace fitness_home.Views.Messages
{
    public partial class PaymentSuccess : Form
    {
        private string TransactionReference;

        public PaymentSuccess(string paymentAmount, int transactionReference, bool cashPayment = false)
        {
            InitializeComponent();

            // Set the title text to indicate the type of payment
            label_title.Text = cashPayment ? $"Payment Pending: {paymentAmount}" : $"Amount Charged: {paymentAmount}";

            // Set the transaction reference (add a padding left of 0s if it has less than 3 digits)
            TransactionReference = transactionReference.ToString().PadLeft(3, '0');

            // Set the transaction reference message text
            label_reference.Text = $"Transaction Reference: {TransactionReference}";
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

        // Copy the transaction reference to clipboard
        private void pictureBox_clipboard_Click(object sender, System.EventArgs e)
        {
            // Convert "TransactionReference" to string and copy it to the clipboard
            Clipboard.SetText(TransactionReference);
        }
    }
}
