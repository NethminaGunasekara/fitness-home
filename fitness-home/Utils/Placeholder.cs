using System.Windows.Forms;

namespace fitness_home.Utils
{
    internal class Placeholder
    {
        public static void Remove(ref object sender)
        {
            TextBox textBox = sender as TextBox;

            if(textBox.Name == "textbox_email" && textBox.Text == ("Email"))
                textBox.Text = "";

            else if (textBox.Name == "textbox_password" && textBox.Text == ("Password"))
            {
                textBox.Text = "";
                textBox.PasswordChar = '*';
            }

            else if (textBox.Name == "textBox_fname" && textBox.Text == ("First name"))
                textBox.Text = "";

            else if (textBox.Name == "textBox_lname" && textBox.Text == ("Last name"))
                textBox.Text = "";
        }

        public static void Add(ref object sender) {
            TextBox textBox = sender as TextBox;

            if (textBox.Name == "textbox_email" && textBox.Text.Length == 0)
                textBox.Text = "Email";

            else if (textBox.Name == "textbox_password" && textBox.Text.Length == 0)
            {
                textBox.PasswordChar = '\0';
                textBox.Text = "Password";
            }

            else if (textBox.Name == "textBox_fname" && textBox.Text.Length == 0)
                textBox.Text = "First name";

            else if (textBox.Name == "textBox_lname" && textBox.Text.Length == 0)
                textBox.Text = "Last name";
        }
    }
}
