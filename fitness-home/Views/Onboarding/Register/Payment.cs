using AnimateDemo;
using fitness_home.Services;
using fitness_home.Utils;
using fitness_home.Utils.Validate;
using fitness_home.Views.Messages;
using fitness_home.Views.Onboarding.Register.Services;
using fitness_home.Views.Onboarding.Register.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace fitness_home.Views.Onboarding.Register
{
    public partial class Payment : Form
    {
        private decimal _MembershipFee; // Total amout to pay
        private decimal AdmissionFee = 2700;
        private decimal TotalAmount;

        // Stores the list of textbox names, followed by a boolean value indicating validity of their inputs
        // Later, we can check all these values to decide whether to enable the "Pay Now" button
        public static Dictionary<string, bool> HasEntered = new Dictionary<string, bool>();

        public Payment()
        {
            InitializeComponent();

            // Initialize fields to check
            // Format: key (textBox name) : state (boolean indicating availability of data)
            HasEntered.Add("textBox_card_holder", false);
            HasEntered.Add("textBox_card_number", false);
            HasEntered.Add("textBox_cvc", false);
            HasEntered.Add("textBox_exp_month", false);
            HasEntered.Add("textBox_exp_year", false);
        }

        public decimal MembershipFee
        {
            get { return _MembershipFee; }

            set
            {
                _MembershipFee = value;

                // Set the total amount
                TotalAmount = AdmissionFee + _MembershipFee;

                // Update membership fee, admission fee, and total amount labels
                label_membership_fee_amount.Text = AmountToDisplay(_MembershipFee);
                label_admission_fee_amount.Text = AmountToDisplay(AdmissionFee);
                label_membership_total_amount.Text = AmountToDisplay(TotalAmount);
            }
        }


        // Formats a decimal amount into a string with commas separating thousands.
        // Adds the "LKR" currency code at the end of the formatted string.
        public string AmountToDisplay(decimal amount)
        {
            string formattedAmount;

            // If the amount has a decimal part
            if (amount % 1 != 0)
            {
                // Format it with up to two decimal places.
                formattedAmount = amount.ToString("#,##0.##");
            }
            else
            {
                // If not, convert it to an integer and format it without decimals.
                formattedAmount = Convert.ToInt32(amount).ToString("#,##0");
            }

            // Return the formatted string followed by "LKR" to indicate currency
            return $"{formattedAmount} LKR";
        }

        // Enable or disable the "Pay Now" button based on whether all form fields are entered.
        public static void UpdatePayNowButtonState(Button payNowButton)
        {
            // Check if all values in HasEntered are true
            payNowButton.Enabled = HasEntered.Values.All(value => value);
        }


        // Add placeholder text when the focus leaves
        private void AddPlaceholder(object sender, EventArgs e) => Placeholder.Add(ref sender);

        // Remove placeholder text when the focus enters
        private void RemovePlaceholder(object sender, EventArgs e) => Placeholder.Remove(ref sender);

        // ** Event: Validate the cardholder name
        private void textBox_card_holder_TextChanged(object sender, EventArgs e)
        {
            PaymentForm.PresenceCheck(sender, e, 4);

            // Enable or disble the "Pay Now" button based on the input's validity
            UpdatePayNowButtonState(button_pay);
        }

        // ** Event: Validate the cvc
        // ** This method runs each time a character of cvc has changed 
        private void textBox_cvc_TextChanged(object sender, EventArgs e)
        {
            PaymentForm.PresenceCheck(sender, e, 3);

            // Enable or disble the "Pay Now" button based on the input's validity
            UpdatePayNowButtonState(button_pay);
        }

        // ** Event: Validate the expiry month
        // ** This method runs each time a character of expiry month has changed 
        private void textBox_exp_month_TextChanged(object sender, EventArgs e)
        {
            PaymentForm.PresenceCheck(sender, e, 2);

            // Enable or disble the "Pay Now" button based on the input's validity
            UpdatePayNowButtonState(button_pay);
        }

        // ** Event: Validate the expiry year
        // ** This method runs each time a character of expiry year has changed 
        private void textBox_exp_year_TextChanged(object sender, EventArgs e)
        {
            PaymentForm.PresenceCheck(sender, e, 2);

            // Enable or disble the "Pay Now" button based on the input's validity
            UpdatePayNowButtonState(button_pay);

        }

        // ** Event: Format the card number while user enters it
        private void textBox_card_number_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // Perform a presence check to find out if the card number has 16 digits (and 3 dashes)
            PaymentForm.PresenceCheck(sender, e, 19);

            // Switch card type based on the card number entered
            if (textBox.Text.Length >= 1)
            {
                radioButton_visa.Checked = textBox.Text[0] == '4';
                radioButton_mc.Checked = textBox.Text[0] == '5';
            }

            // Temporarily remove the event to avoid recursive calls.
            textBox_card_number.TextChanged -= textBox_card_number_TextChanged;

            // Save the current cursor position.
            int cursorPosition = textBox_card_number.SelectionStart;

            // Remove all dashes from the input to work with raw numbers.
            string rawText = textBox_card_number.Text.Replace("-", "");

            // Limit the input to 16 digits (without dashes).
            if (rawText.Length > 16)
            {
                rawText = rawText.Substring(0, 16);  // Truncate if longer than 16 digits.
            }

            // Reformat the text to include dashes after every 4 digits.
            string formattedText = "";
            for (int i = 0; i < rawText.Length; i++)
            {
                if (i > 0 && i % 4 == 0)  // Add a dash after every 4 digits.
                {
                    formattedText += "-";
                }
                formattedText += rawText[i];
            }

            // Update the textbox with the formatted text.
            textBox_card_number.Text = formattedText;

            // Calculate the new cursor position accounting for dashes added before the cursor position.
            int dashCountBeforeCursor = formattedText.Take(cursorPosition).Count(c => c == '-');
            cursorPosition += dashCountBeforeCursor;

            // Ensure the cursor position doesn't exceed the length of the formatted text.
            if (cursorPosition > textBox_card_number.Text.Length)
            {
                cursorPosition = textBox_card_number.Text.Length;
            }

            // Restore the cursor position.
            textBox_card_number.SelectionStart = cursorPosition;

            // Reattach the event handler.
            textBox_card_number.TextChanged += textBox_card_number_TextChanged;

            // Enable or disble the "Pay Now" button based on the input's validity
            UpdatePayNowButtonState(button_pay);

        }

        // ** Event: This method runs when our form is first loaded 
        private void OnLoad(object sender, EventArgs e)
        {
            // Form transition
            WinAPI.AnimateWindow(this.Handle, 700, WinAPI.BLEND);

            Refresh(); // Redraw textbox borders after being hidden by the transition

            // Set the background image
            this.BackgroundImage = Properties.Resources.Background;

            // Set the background image layout to zoom
            this.BackgroundImageLayout = ImageLayout.Zoom;
        }

        // ** Event: Only allow digits and control keys for required fields
        // ** Each textbox that has this as their "KeyPress" event will only allow digits and control keys
        private void NumericOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar));
        }

        // ** Event: Return to previous form
        private void button_previous_Click(object sender, EventArgs e)
        {
            // Create or retrieve an instance of the "Membership" form.
            // - If "Membership" is null, a new "Membership" form is instantiated and assigned to "FormProvider.Membership".
            // - If "Membership" is not null (already created and hidden), the existing form is reused.
            Membership MembershipForm = FormProvider.Membership ?? (FormProvider.Membership = new Membership());

            // Use the "Helpers.ShowForm()" method to display the "MembershipForm".
            // - The first argument is the form to be shown ("MembershipForm").
            // - The second argument is "this", which refers to the current form
            // - The current form will be hidden after "MembershipForm" has shown.
            Helpers.ShowForm(MembershipForm, this);
        }

        // ** Event: Pay the membership amount
        private void PayNow(object sender, EventArgs e)
        {
            // Initialize an instance of PaymentProcessor
            PaymentProcessor PaymentProcessor = new PaymentProcessor();

            // Function to process a card payment
            PaymentProcessor.PaymentStatus CardPayment() => PaymentProcessor.CardPayment(
                cardHolder: textBox_card_holder.Text,
                cardNumber: textBox_card_number.Text,
                cvc: textBox_cvc.Text,
                expiryMonth: textBox_exp_month.Text,
                expiryYear: textBox_exp_year.Text);

            // Function to process a cash payment
            PaymentProcessor.PaymentStatus CashPayment() => PaymentProcessor.PaymentStatus.Pending;

            // Determine and store the type of payment method based on the selected radio button
            // ** If the "Visa" radio button is checked, assigns PaymentMethod.VISA
            // ** If the "MasterCard" radio button is checked, assigns PaymentMethod.MasterCard
            // ** If neither is checked (i.e. user has decided to pay in cash), defaults to PaymentMethod.Cash
            PaymentMethod paymentMethod = radioButton_visa.Checked ? PaymentMethod.VISA : radioButton_mc.Checked ? PaymentMethod.MasterCard : PaymentMethod.Cash;
//
            // Make card or cash payment, based on the type of payment user has chosen
            PaymentProcessor.PaymentStatus paymentStatus = paymentMethod == PaymentMethod.Cash ? CashPayment() : CardPayment();

            // If the user has paid using VISA/Mastercard, and the payment is failed
            if (paymentStatus == PaymentProcessor.PaymentStatus.Failed)
            {
                // Display "PaymentFailed" message
                new PaymentFailed().ShowDialog();

                return; // Exit the method
            }

            // Save transaction information and retrieve the transaction id
            int transactionId = PaymentProcessor.StoreTransactionInfo(
                transactionDate: DateTime.Now,
                paymentMethod: paymentMethod,
                amount: AdmissionFee + _MembershipFee,
                remarks: "Registration",
                status: paymentStatus);

            // Display the payment successful message
            new PaymentSuccess(
                paymentAmount: AmountToDisplay(AdmissionFee + _MembershipFee),
                transactionReference: transactionId,
                cashPayment: paymentStatus == PaymentProcessor.PaymentStatus.Pending).ShowDialog();

            // Finish the member registration
            fitness_home.Register.FinishRegistration(transactionId);
        }

        // Event handler triggered when the "Cash" radio button's checked state changes.
        // This method enables or disables the card input fields and the "Pay Now" button 
        // based on whether the user selects to pay in cash or not.
        private void radioButton_cash_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton cash = (RadioButton)sender;

            // Toggle the enabled state of all card input fields based on whether the cash radio button is checked.
            // If the user chooses "Cash" (cash.Checked is true), card input fields are disabled.
            // If the user unchecks "Cash" (cash.Checked is false), card input fields are enabled for input.
            textBox_card_holder.Enabled = !cash.Checked;
            textBox_card_number.Enabled = !cash.Checked;
            textBox_exp_month.Enabled = !cash.Checked;
            textBox_exp_year.Enabled = !cash.Checked;
            textBox_cvc.Enabled = !cash.Checked;


            // Enable the "Pay Now" button if the user selects to pay in cash (cash.Checked is true).
            // Otherwise, the button is disabled if the cash option is not selected.
            button_pay.Enabled = cash.Checked;

            // If the user deselects the "Cash" option (cash.Checked is false),
            // check whether all required card input fields have been filled.
            // If all card details are entered, re-enable the "Pay Now" button.
            if (!cash.Checked)
            {
                button_pay.Enabled = HasEntered.Values.All(value => value);
            }
        }
    }
}
