using System;
using System.Drawing;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using fitness_home.Services;

namespace fitness_home.Views.Dashboard.Member.Components.Views
{
    public partial class ScheduleView : UserControl
    {
        // Code required to create rounded rectangle panels
        // Source: https://stackoverflow.com/questions/38632035/winforms-smooth-the-rounded-edges-for-panel
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        // Field to store the dates for each day of the current week
        private DaysOfWeek daysOfWeek;

        public ScheduleView()
        {
            InitializeComponent();

            // Create a new "DaysOfWeek" object and store it within the "daysOfWeek" field
            daysOfWeek = new DaysOfWeek();

            // Assign the retrieved dates from Monday to Sunday into the buttons
            label_monday_date.Text = daysOfWeek.Monday.Day.ToString();
            label_tuesday_date.Text = daysOfWeek.Tuesday.Day.ToString();
            label_wednesday_date.Text = daysOfWeek.Wednesday.Day.ToString();
            label_thursday_date.Text = daysOfWeek.Thursday.Day.ToString();
            label_friday_date.Text = daysOfWeek.Friday.Day.ToString();
            label_saturday_date.Text = daysOfWeek.Saturday.Day.ToString();
            label_sunday_date.Text = daysOfWeek.Sunday.Day.ToString();

            // First of all, we need to retrieve and display the list of classes for today

            // Step 01: Update and display the list of classes for today
            // In this case, we can just pass today's day of week
            UpdateClassList(DateTime.Now.Date);

            // Step 02: Apply a new background color for the active card
            // Here, we need to decide a panel to apply the new background color
            // based on today's day of week (e.g. Sunday, Monday, Tuesday...) 

            // Let's get today's day of week, and convert it to a lowercase string
            string dayOfWeek = DateTime.Today.DayOfWeek.ToString().ToLower();

            // Then, use a switch statement choose the right panel to apply the background color for
            switch (dayOfWeek)
            {
                case "monday":
                    SetActiveCardBg(panel_monday);
                    break;

                case "tuesday":
                    SetActiveCardBg(panel_tuesday);
                    break;

                case "wednesday":
                    SetActiveCardBg(panel_wednesday);
                    break;

                case "thursday":
                    SetActiveCardBg(panel_thursday);
                    break;

                case "friday":
                    SetActiveCardBg(panel_friday);
                    break;

                case "saturday":
                    SetActiveCardBg(panel_saturday);
                    break;

                case "sunday":
                    SetActiveCardBg(panel_sunday);
                    break;
            }
        }

        // Structure to represent the dates for each day of the current week
        private class DaysOfWeek
        {
            // Properties for each day of the current week
            public DateTime Monday { get; }
            public DateTime Tuesday { get; }
            public DateTime Wednesday { get; }
            public DateTime Thursday { get; }
            public DateTime Friday { get; }
            public DateTime Saturday { get; }
            public DateTime Sunday { get; }

            // Constructor to initialize the dates for the current week
            public DaysOfWeek()
            {
                // Get the current date
                DateTime today = DateTime.Today;

                // Calculate the day of the week as an integer (Monday = 0, Sunday = 6)
                int daysSinceMonday = (int)today.DayOfWeek - 1;

                // In C#, the DayOfWeek enumeration gives the value 0 for Sunday (Sunday = 0, Saturday = 6)
                // If today is Sunday, the calculation above would result in "daysSinceMonday = 0 - 1 = -1;"
                // This means the logic will attempt to "go back" a non-existent day
                // Here, we correct this by setting daysSinceMonday to 6 if it becomes negative:
                if (daysSinceMonday < 0) daysSinceMonday = 6;

                // Calculate the Monday of the current week
                DateTime mondayOfCurrentWeek = today.AddDays(-daysSinceMonday);

                // Assign the dates for each day of the week
                Monday = mondayOfCurrentWeek;
                Tuesday = mondayOfCurrentWeek.AddDays(1);
                Wednesday = mondayOfCurrentWeek.AddDays(2);
                Thursday = mondayOfCurrentWeek.AddDays(3);
                Friday = mondayOfCurrentWeek.AddDays(4);
                Saturday = mondayOfCurrentWeek.AddDays(5);
                Sunday = mondayOfCurrentWeek.AddDays(6);
            }
        }

        // Applies rounded corners around selected panels
        private void ApplyRoundedCorners()
        {
            // Initialize a list of pannels to apply rounded corners
            List<Panel> panelsToDraw = new List<Panel> { panel_monday, panel_tuesday, panel_wednesday, panel_thursday, panel_friday, panel_saturday, panel_sunday, panel_schedule_for_day };

            SuspendLayout();

            // Apply rounded corners to all panels of the list above
            panelsToDraw.ForEach((Panel panel) =>
            {
                panel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel.Width, panel.Height, 12, 12));
            });

            ResumeLayout();
        }

        // ** Event: When the control is first loaded
        private void ScheduleView_Load(object sender, EventArgs e)
        {
            ApplyRoundedCorners();
        }

        // ** Event: When the form is being resized
        private void ScheduleView_Resize(object sender, EventArgs e)
        {
            // Here, we re-calculate the size of the panels with rounded corners as our control is resized
            ApplyRoundedCorners();
        }

        // Method to retrieve and display the list of classes for a given date
        private void UpdateClassList(DateTime date)
        {
            string _date = date.ToString("yyyy-MM-dd");

            Console.WriteLine($"Showing classes for {_date}");
        }

        // Method to set the background color of the clicked card's panel
        private void SetActiveCardBg(Panel panel)
        {
            // Initialize the list of panels that're used as card backgrounds
            List<Panel> cards = new List<Panel> { panel_monday, panel_tuesday, panel_wednesday, panel_thursday, panel_friday, panel_saturday, panel_sunday };

            // Iterate through the cards list we created before
            cards.ForEach((card) =>
            {
                // Apply default background color to all cards before applying the active card
                // background color (71, 71, 71) to the newly clicked card's container panel
                card.BackColor = Color.FromArgb(37, 37, 37);
            });

            // Finally, apply the active card background color to the newly clicked card
            panel.BackColor = Color.FromArgb(71, 71, 71);
        }

        // ** Event: When any of the controls (labels, or main panel) of the date cards is clicked
        private void OnClick(object sender, EventArgs e)
        {
            // As we've added this method as the Click event for multiple control types (labels and paneks)
            // we must use a common type here. Control can be used as a common type for storing a reference to a control
            Control clickedControl = sender as Control;

            // Detect the clicked day and proceed to show class schedule for that day
            // Control.Name returns the name we gave to a particular control from the winforms designer while designing the form
            // In this case, both panels and labels contain the day they're representing within their name
            // So, we can check the control's name to find out which one of the cards is invoked this method (on click)

            // If the clicked control's name contains "monday", 
            if (clickedControl.Name.Contains("monday"))
            {
                // Update and display the list of classes for "Monday"
                UpdateClassList(daysOfWeek.Monday);

                // Apply a new background color for the active card
                SetActiveCardBg(panel_monday);
            }

            // If the clicked control's name contains "tuesday", 
            else if (clickedControl.Name.Contains("tuesday"))
            {
                // Update and display the list of classes for "Tuesday"
                UpdateClassList(daysOfWeek.Tuesday);

                // Apply a new background color for the active card
                SetActiveCardBg(panel_tuesday);
            }

            // If the clicked control's name contains "wednesday", 
            else if (clickedControl.Name.Contains("wednesday"))
            {
                // Update and display the list of classes for "Wednesday"
                UpdateClassList(daysOfWeek.Wednesday);

                // Apply a new background color for the active card
                SetActiveCardBg(panel_wednesday);
            }

            // If the clicked control's name contains "thursday", 
            else if (clickedControl.Name.Contains("thursday"))
            {
                // Update and display the list of classes for "Thursday"
                UpdateClassList(daysOfWeek.Thursday);

                // Apply a new background color for the active card
                SetActiveCardBg(panel_thursday);
            }

            // If the clicked control's name contains "friday", 
            else if (clickedControl.Name.Contains("friday"))
            {
                // Update and display the list of classes for "Friday"
                UpdateClassList(daysOfWeek.Friday);

                // Apply a new background color for the active card
                SetActiveCardBg(panel_friday);
            }

            // If the clicked control's name contains "saturday", 
            else if (clickedControl.Name.Contains("saturday"))
            {
                // Update and display the list of classes for "Saturday"
                UpdateClassList(daysOfWeek.Saturday);

                // Apply a new background color for the active card
                SetActiveCardBg(panel_saturday);
            }

            // If the clicked control's name contains "sunday", 
            else if (clickedControl.Name.Contains("sunday"))
            {
                // Update and display the list of classes for "Sunday"
                UpdateClassList(daysOfWeek.Sunday);

                // Apply a new background color for the active card
                SetActiveCardBg(panel_sunday);
            }
        }
    }
}
