using fitness_home.Helpers;
using fitness_home.Services;
using fitness_home.Utils.Types;
using fitness_home.Views.Messages;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace fitness_home.Views.Member.Components.Views
{
    public partial class MembershipPayment : UserControl
    {
        // Code required to create rounded rectangle panels
        // Source: https://stackoverflow.com/questions/38632035/winforms-smooth-the-rounded-edges-for-panel
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        // Id of the plan to purchase
        public int PlanId;

        // Field to store the previous view (membership selection) and member area
        public Membership MembershipView;

        public MembershipPayment()
        {
            InitializeComponent();
        }

        // Adds placeholder text back to input fields when they lose focus
        // and contain no user input (i.e. the TextBox is empty)
        private void AddPlaceholder(object sender, EventArgs e)
        {
            // Cast the sender (control that triggered the event) to a TextBox
            TextBox textBox = sender as TextBox;

            // If the TextBox is empty, add the appropriate placeholder text
            if (textBox.Text.Length == 0)
            {
                // Use a switch statement to compare the TextBox name
                // If a match is found, the corresponding placeholder is added
                switch (textBox.Name)
                {
                    case "textBox_card_holder":
                        textBox.Text = "Card holder’s name";
                        break;

                    case "textBox_card_number":
                        textBox.Text = "XXXX XXXX XXXX XXXX";
                        break;

                    case "textBox_cvc":
                        textBox.Text = "CVC";
                        break;

                    case "textBox_exp_month":
                        textBox.Text = "Month";
                        break;

                    case "textBox_exp_year":
                        textBox.Text = "Year";
                        break;
                }
            }
        }

        // Removes placeholder text when the input field gains focus.
        // If the field contains a placeholder value, it is cleared to allow user input.
        private void RemovePlaceholder(object sender, EventArgs e)
        {
            // Cast the sender to a TextBox.
            TextBox textBox = sender as TextBox;

            // Use a switch statement to check if the current text matches a placeholder.
            // If it matches, clear the TextBox to allow user input.
            // This ensures the user doesn’t need to manually delete placeholder text.
            switch (textBox.Text)
            {
                case "Card holder’s name":
                    textBox.Text = string.Empty; // Clear placeholder.
                    break;

                case "XXXX XXXX XXXX XXXX":
                    textBox.Text = string.Empty;
                    break;

                case "CVC":
                    textBox.Text = string.Empty;
                    break;

                case "Month":
                    textBox.Text = string.Empty;
                    break;

                case "Year":
                    textBox.Text = string.Empty;
                    break;
            }
        }

        // ** Event: method attached to the TextChanged property of the card number TextBox
        private void textBox_card_number_TextChanged(object sender, EventArgs e)
        {
            // Remove any existing spaces before formatting
            string cardNumber = textBox_card_number.Text.Replace(" ", "");

            // String we use to append characters and build the formatted card number
            string formattedCardNumber = "";

            for (int i = 0; i < cardNumber.Length; i++)
            {
                formattedCardNumber += cardNumber[i];

                // Add a space after every 4 digits (but not at the end)
                if ((i + 1) % 4 == 0 && i + 1 != cardNumber.Length)
                {
                    formattedCardNumber += " ";
                }
            }

            // Apply the formatted string to the Text property of card number textbox
            textBox_card_number.Text = formattedCardNumber;

            // By default, the textBox brings back its cursor to the beginning of the
            // text content each time we change its text in code (i.e. the line above) 
            // In the following line, we bring the cursor to the end to allow continuous typing
            textBox_card_number.SelectionStart = textBox_card_number.Text.Length;
        }

        // ** Event: When the control is first loaded
        private void MembershipPayment_Load(object sender, EventArgs e)
        {
            // Apply rounded corners to the main panel
            panel_content.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel_content.Width, panel_content.Height, 12, 12));
        }

        // ** Event: When the form is being resized
        private void MembershipPayment_Resize(object sender, EventArgs e)
        {
            // Redraw the rounded corners of the main panel
            panel_content.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel_content.Width, panel_content.Height, 12, 12));
        }

        // ** Event: When the pay now button is clicked
        private void button_pay_now_Click(object sender, EventArgs e)
        {
            // Retrieve information of the plan to purchase
            MembershipPlanDetails membershipPlanDetails = MembershipPlan.Instance.GetPlanById(PlanId);

            // If the user has chosen to pay using cash
            if (radioButton_cash.Checked)
            {
                // Store the payment information as a successful transaction
                int transactionId = PaymentProcessor.StoreTransactionInfo(DateTime.Now.Date, "Cash", membershipPlanDetails.MonthlyFee, "Membership", Helpers.PaymentStatus.Pending, Authentication.LoggedUser.ID);

                PaymentSuccess paymentSuccess = new PaymentSuccess($"LKR {membershipPlanDetails.MonthlyFee}", transactionId);
                paymentSuccess.ShowDialog();

                // Assign the new membership plan to the user
                MembershipPlan.Instance.Assign(membershipPlanDetails.PlanId);

                // Return to the membership selection view
                MembershipView.Show();

                // Invalidate the MembershipView, so that it can display the latest membership data
                MembershipView.Invalidate();

                this.Hide();

                return; // Exit the method
            }

            // If any of the card information fields still contains its placeholder value
            if (textBox_card_holder.Text == "Card holder’s name" || textBox_card_number.Text == "XXXX XXXX XXXX XXXX" || textBox_cvc.Text == "CVC" || textBox_exp_month.Text == "Month" || textBox_exp_year.Text == "Year")
            {
                // Initialize and display the InputError message form as a dialog box
                InputError inputError = new InputError();
                inputError.ShowDialog();

                // Exit the method as we don't wanna procceed without user inputs
                return;
            }

            // Variables to store card data after parsing them
            string cardHolder;
            long cardNumber;
            short cvcNumber;
            short expMonth;
            short expYear;

            // Try to parse the inputs and store them
            try
            {
                cardHolder = textBox_card_holder.Text;

                // Try to convert the string input of card number textbox
                // after removing any existing spaces before formatting
                // All these conversions generate a FormatException if
                // the conversion fails, which we handle in the catch block
                cardNumber = long.Parse(textBox_card_number.Text.Replace(" ", ""));
                cvcNumber = short.Parse(textBox_cvc.Text);
                expMonth = short.Parse(textBox_exp_month.Text);
                expYear = short.Parse(textBox_exp_year.Text);
            }

            catch (FormatException)
            {
                // Initialize and display the InputError message form as a dialog box
                InputError inputError = new InputError();
                inputError.ShowDialog();

                // Exit the method as we don't wanna procceed without valid inputs
                return;
            }

            // Continue to purchase the selected plan and assign it
            // to the member, if none of the errors have occured

            // If the user has chosen to pay using VISA/MasterCard
            if(radioButton_visa.Checked || radioButton_mc.Checked)
            {
                // Make the payment, and store the payment status
                bool cardPaymentStatus = PaymentProcessor.CardPayment(textBox_card_holder.Text, textBox_card_number.Text, textBox_cvc.Text, textBox_exp_month.Text, textBox_exp_year.Text);

                // Decide the payment method to store, based on the radio button checked
                string paymentMethod = radioButton_visa.Checked ? "VISA" : "MasterCard";

                // Exit the method and display an error message if payment fails
                if (cardPaymentStatus == false)
                {
                    PaymentFailed paymentFailed = new PaymentFailed();
                    paymentFailed.ShowDialog();

                    // Store the payment information as a failed transaction
                    PaymentProcessor.StoreTransactionInfo(DateTime.Now.Date, paymentMethod, membershipPlanDetails.MonthlyFee, "Membership", Helpers.PaymentStatus.Failed, Authentication.LoggedUser.ID);
                }

                // If the payment is success, assign the new membership plan to the user
                else
                {
                    // Store the payment information as a successful transaction
                    int transactionId = PaymentProcessor.StoreTransactionInfo(DateTime.Now.Date, paymentMethod, membershipPlanDetails.MonthlyFee, "Membership", Helpers.PaymentStatus.Success, Authentication.LoggedUser.ID);

                    FormProvider.MemberArea.Refresh();

                    PaymentSuccess paymentSuccess = new PaymentSuccess($"LKR {membershipPlanDetails.MonthlyFee}", transactionId);
                    paymentSuccess.ShowDialog();

                    // Assign the new membership plan to the user
                    MembershipPlan.Instance.Assign(membershipPlanDetails.PlanId);

                    // Return to the membership selection view
                    MembershipView.Show();

                    this.Hide();
                }
            }
        }

        // This method enables or disables the card input fields
        // based on whether the user selects to pay in cash or not.
        private void radioButton_cash_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle the enabled state of all card input fields based on whether the cash radio button is checked.
            // If the user chooses "Cash" (radioButton_cash.Checked is true), card input fields are disabled.
            // If the user unchecks "Cash" (radioButton_cash.Checked is false), card input fields are enabled for input.
            textBox_card_holder.Enabled = !radioButton_cash.Checked;
            textBox_card_number.Enabled = !radioButton_cash.Checked;
            textBox_exp_month.Enabled = !radioButton_cash.Checked;
            textBox_exp_year.Enabled = !radioButton_cash.Checked;
            textBox_cvc.Enabled = !radioButton_cash.Checked;
        }

        // Event: Cancel the payment if the "Cancel" button is clicked
        private void btn_cancel_payment_Click(object sender, EventArgs e)
        {
            // Return to the membership selection view
            MembershipView.Show();

            // Hide the current view
            this.Hide();
        }
    }
}
