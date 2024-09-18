using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fitness_home.Utils
{
    internal class Helpers
    {
        public static void ShowForm(Form targetForm, Form currentForm, bool setSize = true, bool setPosition = true)
        {
            if (setPosition)
            {
                // Set target form position
                targetForm.StartPosition = FormStartPosition.Manual;
                targetForm.Location = currentForm.Location;
            }

            if (setSize)
            {
                // Set target form size
                targetForm.Size = currentForm.Size;
            }

            // Close the application once the user has closed the target form
            targetForm.FormClosing += delegate { Application.Exit(); };

            // Show the target form and hide the current
            targetForm.BringToFront();
            targetForm.Show();
            currentForm.Hide();
        }
    }
}
