using AnimateDemo;
using System;
using System.Windows.Forms;

namespace fitness_home.Utils
{
    internal class Helpers
    {
        private static int TransitionDuration = 400;

        public static void ShowForm(Form targetForm, Form currentForm, bool setSize = true, bool setPosition = true, bool transition = true, int duration = 700)
        {
            TransitionDuration = duration;

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

            if (transition) {
                // Set form transition
                targetForm.Load += FormTransition;
                targetForm.VisibleChanged += FormTransition;
            }

            targetForm.Show();
            currentForm.Hide();
        }

        private static void FormTransition(object sender, EventArgs e)
        {
            Form form = sender as Form;

            if (form.Visible)
            {
                // Form transition shown either when the form is loaded or shown after being hidden
                WinAPI.AnimateWindow(form.Handle, TransitionDuration, WinAPI.BLEND);
            }
        }
    }
}
