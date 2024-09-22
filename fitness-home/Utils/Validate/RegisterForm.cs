using fitness_home.Utils.Types;
using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace fitness_home.Utils.Validate
{
    internal class RegisterForm
    {
        public static void SetBackColorDefault(TextBox textBox)
        {
            textBox.BackColor = Color.FromArgb(41, 41, 41);
            textBox.Parent.BackColor = Color.FromArgb(41, 41, 41);
        }

        public static void SetBackColorRed(TextBox textBox, bool isInvalid = false)
        {
            textBox.BackColor = Color.FromArgb(70, 41, 41);
            textBox.Parent.BackColor = Color.FromArgb(70, 41, 41);

        }

        public static void ValidateFirstName(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // If textbox still contains the initial value (placeholder)
            if (textBox.Text == "First name")
                SetBackColorDefault(textBox);

            else if (textBox.Text.Length >= 1)
                SetBackColorDefault(textBox);

            else
                SetBackColorRed(textBox);

            Register.HasEntered["first-name"] = textBox.Text.Length >= 1 && textBox.Text != "First name";
        }

        public static void ValidateLastName(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // If textbox still contains the initial value (placeholder)
            if (textBox.Text == "Last name")
                SetBackColorDefault(textBox);

            else if (textBox.Text.Length >= 1)
                SetBackColorDefault(textBox);

            else
                SetBackColorRed(textBox);

            Register.HasEntered["last-name"] = textBox.Text.Length >= 1 && textBox.Text != "Last name";
        }

        public static void ValidateDOB(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string dob = textBox.Text;

            // If textbox still contains the initial value (placeholder)
            if (dob == "YYYY/MM/DD")
            {
                SetBackColorDefault(textBox);
                Register.HasEntered["dob"] = false;
                return;
            }

            // Regular expression pattern for date validation: YYYY/MM/DD
            // ^        : asserts the start of the string
            // \d{4}    : specifies that exactly 4 digits are expected (year)
            // /        : slash character that separates year, and month
            // \d{2}    : specifies that exactly 2 digits are expected (month)
            // /        : slash character that separates month, and date
            // \d{2}    : specifies that exactly 2 digits are expected (day)
            // $        : asserts end of the string
            string pattern = @"^\d{4}/\d{2}/\d{2}$";

            // Check if the input matches the format "YYYY/MM/DD"
            if (Regex.IsMatch(dob, pattern))
            {
                // Extract year, month, and day parts from the text
                int year = int.Parse(dob.Substring(0, 4));
                int month = int.Parse(dob.Substring(5, 2));
                int day = int.Parse(dob.Substring(8, 2));

                // Validate year (1900 to current year)
                int currentYear = DateTime.Now.Year;
                if (year >= 1900 && year <= currentYear)
                {
                    // Validate month (01 to 12)
                    if (month >= 1 && month <= 12)
                    {
                        // Validate day (01 to 31)
                        if (day >= 1 && day <= DateTime.DaysInMonth(year, month))
                        {
                            SetBackColorDefault(textBox);
                            Register.HasEntered["dob"] = true;
                            return;
                        }
                    }
                }
            }

            // If validation fails
            SetBackColorRed(textBox);
            Register.HasEntered["dob"] = false;
        }

        public static void ValidateNIC(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string nic = textBox.Text;

            // If textbox still contains the initial value (placeholder)
            if (nic == "XXXXXXXXXXXX")
            {
                SetBackColorDefault(textBox);
                Register.HasEntered["dob"] = false;
                return;
            }

            // NIC can be either a nine or twelve digit number.
            // (?:expression) syntax denotes a non-capturing group, and
            // expression represents the regular expression pattern to be matched.
            // Reference: https://www.educative.io/answers/what-is-a-non-capturing-group-in-regular-expressions
            string pattern = @"^(?:\d{9}|\d{12})$";

            // If the entered value is valid
            if (Regex.IsMatch(nic, pattern))
            {
                SetBackColorDefault(textBox);
                Register.HasEntered["dob"] = true;
            }

            // If validation fails
            else
            {
                SetBackColorRed(textBox);
                Register.HasEntered["dob"] = false;
            }
        }

        /// <summary>
        /// Enables or disables the sign-up button based on whether all form fields are entered.
        /// </summary>
        public static void UpdateSignUpButtonState(Button signUpButton)
        {
            // Check if all values in HasEntered are true
            signUpButton.Enabled = Register.HasEntered.Values.All(value => value);
        }

    }
}
