using AnimateDemo;
using fitness_home.Utils;
using fitness_home.Utils.Validate;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace fitness_home
{
    public partial class Register : Form
    {
        public static Dictionary<string, bool> HasEntered = new Dictionary<string, bool>();

        public Register()
        {
            InitializeComponent();

            // Initialize fields to check
            HasEntered.Add("first-name", false);
            HasEntered.Add("last-name", false);
            HasEntered.Add("dob", false);
            HasEntered.Add("nic", false);
            HasEntered.Add("gender", false);
            HasEntered.Add("email", false);
            HasEntered.Add("phone", false);
            HasEntered.Add("address", false);
            HasEntered.Add("password", false);
            HasEntered.Add("ecname", false);
            HasEntered.Add("ecphone", false);
        }

        private void OnLoad(object sender, EventArgs e)
        {
            // Form transition
            WinAPI.AnimateWindow(this.Handle, 400, WinAPI.BLEND);

            // Update the margin right value of heading
            label_page_heading.Margin = new System.Windows.Forms.Padding(0, 0, panel_previous.Width, 0);
        }

        private void OnResize(object sender, EventArgs e)
        {
            // Update the margin right value of heading
            label_page_heading.Margin = new System.Windows.Forms.Padding(0, 0, panel_previous.Width, 0);
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
            RegisterForm.ValidateFirstName(sender, e);
            RegisterForm.UpdateSignUpButtonState(button_sign_up);
        }

        // ** Event: Validate last name
        private void textBox_lname_TextChanged(object sender, EventArgs e)
        {
            RegisterForm.ValidateLastName(sender, e);
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
    }
}
