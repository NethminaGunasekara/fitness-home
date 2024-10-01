﻿using AnimateDemo;
using fitness_home.Utils;
using fitness_home.Utils.Validate;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Windows.Forms;

namespace fitness_home
{
    public partial class Register : Form
    {
        public static Dictionary<string, bool> HasEntered = new Dictionary<string, bool>();
        private static bool HasRequiredChars;
        private static bool HasRequiredLength;
        private static bool PasswordsMatch;

        public Register()
        {
            InitializeComponent();

            // Initialize fields to check
            HasEntered.Add("textBox_fname", false);
            HasEntered.Add("textBox_lname", false);
            HasEntered.Add("textBox_dob", false);
            HasEntered.Add("textBox_nic", false);
            HasEntered.Add("gender", false);
            HasEntered.Add("textBox_email", false);
            HasEntered.Add("textBox_phone", false);
            HasEntered.Add("textBox_address", false);
            HasEntered.Add("password", false);
            HasEntered.Add("textBox_ec_name", false);
            HasEntered.Add("textBox_ec_phone", false);
        }

        private void OnLoad(object sender, EventArgs e)
        {
            // Form transition
            WinAPI.AnimateWindow(this.Handle, 700, WinAPI.BLEND);

            Refresh();

            // Update the margin right value of heading
            label_page_heading.Margin = new Padding(0, 0, panel_previous.Width, 0);
        }

        private void OnResize(object sender, EventArgs e)
        {
            label_page_heading.Margin = new Padding(0, 0, panel_previous.Width, 0);
        }

        // Add placeholder text when the focus leaves
        private void AddPlaceholder(object sender, EventArgs e) => Placeholder.Add(ref sender);

        // Remove placeholder text when the focus enters
        private void RemovePlaceholder(object sender, EventArgs e) => Placeholder.Remove(ref sender);

        // Only allow digits and control keys
        private void NumericOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar));
        }

        // ** Event: Validate first name
        private void textBox_fname_TextChanged(object sender, EventArgs e)
        {
            RegisterForm.PresenceCheck(sender, e);
            RegisterForm.UpdateSignUpButtonState(button_sign_up);
        }

        // ** Event: Validate last name
        private void textBox_lname_TextChanged(object sender, EventArgs e)
        {
            RegisterForm.PresenceCheck(sender, e);
            RegisterForm.UpdateSignUpButtonState(button_sign_up);
        }

        // ** Event: Validate date of birth
        private void textBox_dob_TextChanged(object sender, EventArgs e)
        {
            RegisterForm.ValidateDOB(sender, e);
            RegisterForm.UpdateSignUpButtonState(button_sign_up);
        }

        // ** Event: Validate NIC number
        private void textBox_nic_TextChanged(object sender, EventArgs e)
        {
            RegisterForm.ValidateNIC(sender, e);
            RegisterForm.UpdateSignUpButtonState(button_sign_up);
        }

        // ** Event: Validate Gender
        private void radioButton_gender_CheckedChanged(object sender, EventArgs e)
        {
            // No checks are needed as the gender cannot be unchecked
            HasEntered["gender"] = true;
            RegisterForm.UpdateSignUpButtonState(button_sign_up);
        }

        // ** Event: Validate Email
        private void textBox_email_TextChanged(object sender, EventArgs e)
        {
            RegisterForm.ValidateEmail(sender, e);
            RegisterForm.UpdateSignUpButtonState(button_sign_up);
        }

        // ** Event: Validate Phone Number
        private void textBox_phone_TextChanged(object sender, EventArgs e)
        {
            RegisterForm.PresenceCheck(sender, e, 10);
            RegisterForm.UpdateSignUpButtonState(button_sign_up);
        }

        // ** Event: Validate Address
        private void textBox_address_TextChanged(object sender, EventArgs e)
        {
            RegisterForm.PresenceCheck(sender, e, 12);
            RegisterForm.UpdateSignUpButtonState(button_sign_up);
        }

        // ** Event: Validate New Password
        private void textBox_password_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string password = textBox.Text;

            // Conditions for password validation
            bool hasUpperCase = password.Any(char.IsUpper);
            bool hasLowerCase = password.Any(char.IsLower);
            bool hasDigit = password.Any(char.IsDigit);
            
            HasRequiredChars = hasUpperCase && hasLowerCase && hasDigit;
            HasRequiredLength = password.Length >= 8 && password.Length <= 24 && textBox.PasswordChar == '*';
            PasswordsMatch = textBox_confirm_password.Text.Equals(password);

            // Display password policy pannel (if hidden)
            if (!panel_pw_policy.Visible) 
                panel_pw_policy.Visible = true;

            // Set password policy status
            SetPasswordValidity(HasRequiredChars, HasRequiredLength, PasswordsMatch);

            // Mark password as entered if it follows the password policy
            HasEntered["password"] = HasRequiredChars && HasRequiredLength && PasswordsMatch;
        }

        private void textBox_confirm_password_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string password = textBox.Text;

            PasswordsMatch = textBox_new_password.Text.Equals(password);

            // Set password policy status
            SetPasswordValidity(HasRequiredChars, HasRequiredLength, PasswordsMatch);

            // Mark password as entered if it follows the password policy
            HasEntered["password"] = HasRequiredChars && HasRequiredLength && PasswordsMatch;
        }

        private void SetPasswordValidity(bool hasRequiredChars = false, bool hasRequiredLength = false, bool passwordsMatch = false)
        {
            Color clrRed = Color.FromArgb(255, 34, 0);
            Color clrGreen = Color.FromArgb(161, 210, 0);

            Bitmap crossIcon = Properties.Resources.pw_policy_cross;
            Bitmap tickIcon = Properties.Resources.pw_policy_tick;

            // Set label colors based on parameters provided
            label_char_rqmt.ForeColor = hasRequiredChars ? clrGreen : clrRed;
            label_length_rqmt.ForeColor = hasRequiredLength ? clrGreen : clrRed;
            label_passwords_match.ForeColor = passwordsMatch ? clrGreen : clrRed;

            // Set icons based on parameters provided
            icon_char_rqmt.BackgroundImage = hasRequiredChars ? tickIcon : crossIcon;
            icon_length_rqmt.BackgroundImage = hasRequiredLength ? tickIcon : crossIcon;
            icon_passwords_match.BackgroundImage = passwordsMatch ? tickIcon : crossIcon;
        }

        private void textBox_ec_name_TextChanged(object sender, EventArgs e)
        {
            RegisterForm.PresenceCheck(sender, e);
            RegisterForm.UpdateSignUpButtonState(button_sign_up);
        }

        private void textBox_ec_phone_TextChanged(object sender, EventArgs e)
        {
            RegisterForm.PresenceCheck(sender, e, 10);
            RegisterForm.UpdateSignUpButtonState(button_sign_up);
        }
    }
}