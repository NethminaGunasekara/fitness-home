using fitness_home.Helpers;
using fitness_home.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace fitness_home.Views.Trainer.Tabs
{
    public partial class Schedule : UserControl
    {
        List<Label> NameLabels, GroupLabels, StudentsCountLabels, TimeLabels, StatusLabels;

        // Field to store the dates for each day of the current week
        // e.g. 2024/10/28 for Monday, 2024/10/29 for Tuesday
        private DaysOfWeek daysOfWeek;

        // Initialize the ScheduleManager class to use its helper methods
        ScheduleManager scheduleManager = new ScheduleManager();

        // ** Event: When the control is first loaded
        private void Schedule_Load(object sender, System.EventArgs e)
        {
            // Apply rouunded corners to selected panels
            RoundedCorners.Apply(panel_monday, panel_tuesday, panel_wednesday, panel_thursday, panel_friday, panel_saturday, panel_sunday, panel_schedule_for_day);
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
                DisplayClassDetails(daysOfWeek.Monday);

                // Apply a new background color for the active card
                SetActiveCardBg(panel_monday);
            }

            // If the clicked control's name contains "tuesday", 
            else if (clickedControl.Name.Contains("tuesday"))
            {
                // Update and display the list of classes for "Tuesday"
                DisplayClassDetails(daysOfWeek.Tuesday);

                // Apply a new background color for the active card
                SetActiveCardBg(panel_tuesday);
            }

            // If the clicked control's name contains "wednesday", 
            else if (clickedControl.Name.Contains("wednesday"))
            {
                // Update and display the list of classes for "Wednesday"
                DisplayClassDetails(daysOfWeek.Wednesday);

                // Apply a new background color for the active card
                SetActiveCardBg(panel_wednesday);
            }

            // If the clicked control's name contains "thursday", 
            else if (clickedControl.Name.Contains("thursday"))
            {
                // Update and display the list of classes for "Thursday"
                DisplayClassDetails(daysOfWeek.Thursday);

                // Apply a new background color for the active card
                SetActiveCardBg(panel_thursday);
            }

            // If the clicked control's name contains "friday", 
            else if (clickedControl.Name.Contains("friday"))
            {
                // Update and display the list of classes for "Friday"
                DisplayClassDetails(daysOfWeek.Friday);

                // Apply a new background color for the active card
                SetActiveCardBg(panel_friday);
            }

            // If the clicked control's name contains "saturday", 
            else if (clickedControl.Name.Contains("saturday"))
            {
                // Update and display the list of classes for "Saturday"
                DisplayClassDetails(daysOfWeek.Saturday);

                // Apply a new background color for the active card
                SetActiveCardBg(panel_saturday);
            }

            // If the clicked control's name contains "sunday", 
            else if (clickedControl.Name.Contains("sunday"))
            {
                // Update and display the list of classes for "Sunday"
                DisplayClassDetails(daysOfWeek.Sunday);

                // Apply a new background color for the active card
                SetActiveCardBg(panel_sunday);
            }
        }

        // ** Event: When the form is being resized
        private void Schedule_Resize(object sender, EventArgs e)
        {
            // Here, we re-calculate the size of the panels with rounded corners as our control is resized
            RoundedCorners.Apply(panel_monday, panel_tuesday, panel_wednesday, panel_thursday, panel_friday, panel_saturday, panel_sunday, panel_schedule_for_day);
        }

        public Schedule()
        {
            InitializeComponent();

            // Create a new "DaysOfWeek" object and store it within the "daysOfWeek" field
            daysOfWeek = new DaysOfWeek();

            // Initialize the lists of labels used for displaying data
            NameLabels = new List<Label> { label_name_1, label_name_2, label_name_3, label_name_4, label_name_5, label_name_6, label_name_7, label_name_8 };
            GroupLabels = new List<Label> { label_group_1, label_group_2, label_group_3, label_group_4, label_group_5, label_group_6, label_group_7, label_group_8 };
            StudentsCountLabels = new List<Label> { label_students_1, label_students_2, label_students_3, label_students_4, label_students_5, label_students_6, label_students_7, label_students_8 };
            TimeLabels = new List<Label> { label_time_1, label_time_2, label_time_3, label_time_4, label_time_5, label_time_6, label_time_7, label_time_8 };
            StatusLabels = new List<Label> { label_status_1, label_status_2, label_status_3, label_status_4, label_status_5, label_status_6, label_status_7, label_status_8 };

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
            // In this case, we can just pass today's date
            DisplayClassDetails(DateTime.Now.Date);

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


        // ** Helper Method: Set the details of classes for a selected date
        private void DisplayClassDetails(DateTime date)
        {
            List<ClassDetails> classDetails = scheduleManager.GetScheduleForTrainer(date, Authentication.LoggedUser.ID);

            // Clear text content of all labels before displaying new values
            scheduleManager.ClearTextContent(NameLabels);
            scheduleManager.ClearTextContent(GroupLabels);
            scheduleManager.ClearTextContent(StudentsCountLabels);
            scheduleManager.ClearTextContent(TimeLabels);
            scheduleManager.ClearTextContent(StatusLabels);

            // Display the list of classes for the curreent date

        }
    }
}
