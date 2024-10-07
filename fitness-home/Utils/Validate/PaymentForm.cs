using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace fitness_home.Utils.Validate
{
    /// <summary>
    /// A class for validating card information provided by the user.
    /// Developed by Shanuka Ravishan.
    /// GitHub: https://github.com/Shanu-001
    /// </summary>
    internal class PaymentForm
    {
        // Stores the list of textbox names, followed by their placeholders
        private readonly Dictionary<string, string> Placeholders = new Dictionary<string, string>();

        // Stores the list of textbox names, followed by a boolean value indicating validity of their inputs
        // Later, we can check all these values to decide whether to enable the "Pay Now" button
        private readonly Dictionary<string, string> HasEntered = new Dictionary<string, string>();

        public PaymentForm() {
            // Format: key (textBox name) : value (placeholder text)
            Placeholders.Add("textBox_card_holder", "Card holder’s name");
            Placeholders.Add("textBox_card_number", "XXXX-XXXX-XXXX-XXXX");
            Placeholders.Add("textBox_cvc", "CVC");
            Placeholders.Add("textBox_exp_month", "Month");
            Placeholders.Add("textBox_exp_year", "Year");
        }

        // Checks if the given textbox has a number of characters (minimumLength)
        // If not change the background color to red, indicating an invalid input
        public static void PresenceCheck(object sender, EventArgs e, int minimumLength = 1)
        {
            TextBox textBox = sender as TextBox;

            // If textbox still contains the initial value (placeholder)
            if (textBox.Text == Placeholder.placeholders[textBox.Name])
            {
                RegisterForm.SetBackColorDefault(textBox);
                
            }

            // If the input has required length (minimumLength)
            else if (textBox.Text.Length >= minimumLength)
            {
                RegisterForm.SetBackColorDefault(textBox);
            }

            else
            {
                RegisterForm.SetBackColorRed(textBox);
            }
        }
    }
}
