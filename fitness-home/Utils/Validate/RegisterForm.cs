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

        public static void PresenceCheck(object sender, EventArgs e, int minimumLength = 1)
        {
            TextBox textBox = sender as TextBox;

            // If textbox still contains the initial value (placeholder)
            if(textBox.Text == Placeholder.placeholders[textBox.Name])
            {
                Register.HasEntered[textBox.Name] = false;
                SetBackColorDefault(textBox);
            }

            else if(textBox.Text.Length >= minimumLength)
            {
                Register.HasEntered[textBox.Name] = true;
                SetBackColorDefault(textBox);
            }

            else
            {
                Register.HasEntered[textBox.Name] = false;
                SetBackColorRed(textBox);
            }
        }

        public static void ValidateDOB(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string dob = textBox.Text;

            // If textbox still contains the initial value (placeholder)
            if (dob == "YYYY/MM/DD")
            {
                SetBackColorDefault(textBox);
                Register.HasEntered["textBox_dob"] = false;
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
                            Register.HasEntered["textBox_dob"] = true;
                            return;
                        }
                    }
                }
            }

            // If validation fails
            SetBackColorRed(textBox);
            Register.HasEntered["textBox_dob"] = false;
        }

        public static void ValidateNIC(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string nic = textBox.Text;

            // If textbox still contains the initial value (placeholder)
            if (nic == "XXXXXXXXXXXX")
            {
                SetBackColorDefault(textBox);
                Register.HasEntered["textBox_nic"] = false;
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
                Register.HasEntered["textBox_nic"] = true;
            }

            // If validation fails
            else
            {
                SetBackColorRed(textBox);
                Register.HasEntered["textBox_nic"] = false;
            }
        }

        public static void ValidateEmail(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string email = textBox.Text;

            // Regex pattern for validating email
            // ^        - Start of the string
            // [^@\s]+  - One or more characters that are not "@" or whitespace
            // @        - Exactly one "@" symbol
            // [^@\s]+  - One or more characters that are not "@" or whitespace
            // \.       - Exactly one "." symbol
            // [^@\s]+  - One or more characters that are not "@" or whitespace
            // $        - End of the strin
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            // If textbox still contains the initial value (placeholder)
            if (email == "E-mail")
            {
                Register.HasEntered["textBox_email"] = false;
                SetBackColorDefault(textBox);
            }

            // Determine input state based on regex match
            else if (Regex.IsMatch(email, emailPattern))
            {
                Register.HasEntered["textBox_email"] = true;
                SetBackColorDefault(textBox);
            }
            else
            {
                Register.HasEntered["textBox_email"] = false;
                SetBackColorRed(textBox);
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
