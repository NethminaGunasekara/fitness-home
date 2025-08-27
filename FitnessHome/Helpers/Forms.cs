using fitness_home;
using FitnessHome.Views.Onboarding;
using System.Diagnostics;
using static FitnessHome.Helpers.Forms;

namespace FitnessHome.Helpers
{
    /// <summary>
    /// Provides access to predefined static forms.
    /// </summary>
    public class Forms
    {
        private static Welcome? _welcome;

        private static int TransitionDuration;

        // Onboarding Views: Login
        public static Welcome Welcome
        {
            get => _welcome ??= new Welcome();
        }

        public static Form GetForm(FormType formType)
        {
            return formType switch
            {
                FormType.Welcome => Welcome,
                _ => throw new ArgumentOutOfRangeException(nameof(formType), $"Form type '{formType}' is not supported.")
            };
        }

        /// <summary>
        /// Shows the specified form by hiding the current form (optional).
        /// The application will exit when the target form is closed.
        /// </summary>
        /// <param name="formToShow">The type of the form to display.</param>
        /// <param name="currentForm">The currently active form to hide (optional).</param>
        /// <param name="transitionDuration">Custom duration (ms) for the transition (default: 400ms).</param>
        public static void ShowForm(FormType formToShow, Form? currentForm = null, bool transition = true, int transitionDuration = 400)
        {
            TransitionDuration = transitionDuration;

            var _formToShow = GetForm(formToShow);

            // Close the application once the user has closed the target form
            _formToShow.FormClosing += delegate { Application.Exit(); };

            // Show the target form and hide the current
            _formToShow.BringToFront();

            if(transition)
            {
                EventHandler FormTransition = (sender, e) =>
                {
                    if (sender is Form form && form.Visible)
                    {
                        // Form transition shown either when the form is loaded or shown after being hidden
                        WinAPI.AnimateWindow(form.Handle, TransitionDuration, WinAPI.BLEND);
                    }
                };

                // Apply transition animation when the form is loaded or shown
                _formToShow.Load += FormTransition;
                _formToShow.VisibleChanged += FormTransition;
            }

            // Show the new form
            _formToShow.Show();

            // Hide the current form if it exists
            currentForm?.Hide();
        }

        /// <summary>
        /// Available application forms that can be navigated to.
        /// </summary>
        public enum FormType
        {
            Welcome,
            Login,
            Register,
            Membership,
            Payment,
        }

    }
}
