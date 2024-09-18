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
        }
    }
}
