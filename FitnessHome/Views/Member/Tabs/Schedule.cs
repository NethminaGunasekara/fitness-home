using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using fitness_home.Services;
using fitness_home.Views.Messages;
using System.Data.SqlClient;
using fitness_home.Helpers;
using fitness_home.Utils.Types.UserTypes;

namespace fitness_home.Views.Member.Components.Views
{
    public partial class Schedule : UserControl
    {
        // Field to store the dates for each day of the current week
        // e.g. 2024/10/28 for Monday, 2024/10/29 for Tuesday
        private DaysOfWeek daysOfWeek;

        public Schedule()
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

        // ** Event: When the control is first loaded
        private void ScheduleView_Load(object sender, EventArgs e)
        {
            // Apply rouunded corners to selected panels
            RoundedCorners.Apply(panel_monday, panel_tuesday, panel_wednesday, panel_thursday, panel_friday, panel_saturday, panel_sunday, panel_schedule_for_day);
        }

        // ** Event: When the form is being resized
        private void ScheduleView_Resize(object sender, EventArgs e)
        {
            // Here, we re-calculate the size of the panels with rounded corners as our control is resized
            RoundedCorners.Apply(panel_monday, panel_tuesday, panel_wednesday, panel_thursday, panel_friday, panel_saturday, panel_sunday, panel_schedule_for_day);
        }

        private void DisplayClassDetails(DateTime date)
        {
            // Retrieve the list of classes for the given day to display
            List<ClassDetails> classDetails = Schedule.GetScheduleForDay(date, Authentication.LoggedUser.ID, Authentication.LoggedUser.PlanID);

            // Array of label sets for the 8 rows
            List<Label> classNameLabels = new List<Label> { label_name_1, label_name_2, label_name_3, label_name_4, label_name_5, label_name_6, label_name_7, label_name_8 };
            List<Label> trainerLabels = new List<Label> { label_trainer_1, label_trainer_2, label_trainer_3, label_trainer_4, label_trainer_5, label_trainer_6, label_trainer_7, label_trainer_8 };
            List<Label> timeLabels = new List<Label> { label_time_1, label_time_2, label_time_3, label_time_4, label_time_5, label_time_6, label_time_7, label_time_8 };
            List<Label> statusLabels = new List<Label> { label_status_1, label_status_2, label_status_3, label_status_4, label_status_5, label_status_6, label_status_7, label_status_8 };

            // Loop through the first 8 class details or the available number of details
            for (int i = 0; i < 8; i++)
            {
                if (i < classDetails.Count)
                {
                    // Make the labels visible
                    classNameLabels[i].Visible = true;
                    trainerLabels[i].Visible = true;
                    timeLabels[i].Visible = true;
                    statusLabels[i].Visible = true;
            
                    // Set the class details for the current row
                    SetClassDetails(classDetails[i], classNameLabels[i], trainerLabels[i], timeLabels[i], statusLabels[i]);
                }
                else
                {
                    // Hide the labels if there are no more class details to display
                    classNameLabels[i].Visible = false;
                    trainerLabels[i].Visible = false;
                    timeLabels[i].Visible = false;
                    statusLabels[i].Visible = false;
                }
            }
        }

        private void SetClassDetails(ClassDetails classDetails, Label class_name, Label class_trainer, Label class_time, Label class_status)
        {
            // Make labels visible if they're hidden
            class_name.Visible = class_trainer.Visible = class_time.Visible = class_status.Visible = true;

            // Set class name
            class_name.Text = classDetails.Name;

            // Retrieve the trainer name by id and display it
            class_trainer.Text = TrainerData.GetTrainerNameById(classDetails.TrainerId);

            // Convert class start and end times to the 24h format
            string classStartTime = classDetails.ClassStart.ToString("HH.mm");
            string classEndTime = classDetails.ClassEnd.ToString("HH.mm");

            // Set the class time
            class_time.Text = $"{classStartTime} - {classEndTime}";

            // Check attendance for the class
            string attendance = Schedule.CheckAttendance(Authentication.LoggedUser.ID, classDetails.ClassId);

            // If the trainer has marked the user's attendence as "Attended"
            if (attendance == "Attended")
            {
                class_status.Text = "Attended";
                class_status.BackColor = Color.FromArgb(35, 51, 48);
                class_status.ForeColor = Color.FromArgb(21, 179, 146);
            }

            // If the trainer has marked the user's attendence as "Ansent"
            else if (attendance == "Absent")
            {
                class_status.Text = "Absent";
                class_status.BackColor = Color.FromArgb(57, 44, 44);
                class_status.ForeColor = Color.FromArgb(255, 87, 87);
            }

            // If either the trainer hasn't marked the user's attendence or the class hasn't started yet
            else
            {
                class_status.Text = "No Information";
                class_status.BackColor = Color.FromArgb(46, 44, 57);
                class_status.ForeColor = Color.FromArgb(118, 87, 255);
            }
        }

        public static List<ClassDetails> GetScheduleForDay(DateTime date, int memberId, int planId)
        {
            List<ClassDetails> classes = new List<ClassDetails>();

            try
            {
                using (SqlConnection conn = new SqlConnection(Authentication.Instance.ConnectionString))
                {
                    conn.Open();

                    // Retrieve the group_number from the member_group table for the given memberId
                    int groupNumber = 0;

                    string groupQuery = "SELECT group_number FROM member_group WHERE member_id = @MemberId";

                    using (SqlCommand groupCmd = new SqlCommand(groupQuery, conn))
                    {
                        groupCmd.Parameters.AddWithValue("@MemberId", memberId);
                        object result = groupCmd.ExecuteScalar();

                        if (result != null)
                        {
                            groupNumber = Convert.ToInt32(result);
                        }
                        else
                        {
                            // Return an empty list if the group number isn't found
                            return classes;
                        }
                    }

                    // Retrieve the class details from the schedule table
                    string classQuery = @"SELECT class_id, class_name, trainer_id, start_time, end_time
                                            FROM schedule
                                            WHERE plan_id = @PlanId 
                                            AND [group] = @GroupNumber 
                                            AND date = @Date";

                    using (SqlCommand classCmd = new SqlCommand(classQuery, conn))
                    {
                        classCmd.Parameters.AddWithValue("@PlanId", planId);
                        classCmd.Parameters.AddWithValue("@GroupNumber", groupNumber);
                        classCmd.Parameters.AddWithValue("@Date", date.Date);

                        using (SqlDataReader reader = classCmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int classId = reader.GetInt32(0);
                                string className = reader.GetString(1);
                                int trainerId = reader.GetInt32(2);
                                TimeSpan startTime = reader.GetTimeSpan(3);
                                TimeSpan endTime = reader.GetTimeSpan(4);

                                // Construct start and end DateTime values by combining the date with the times
                                DateTime classStart = date.Date.Add(startTime);
                                DateTime classEnd = date.Date.Add(endTime);

                                // Create a ClassDetails object and add it to the list
                                classes.Add(new ClassDetails(classId, className, trainerId, classStart, classEnd));
                            }
                        }
                    }
                }
            }

            catch (SqlException)
            {
                // Handle database-related errors
                new ApplicationError(ErrorType.DatabaseError);
            }

            return classes;
        }

        // Helper method to check if the member has attended a specified class
        public static string CheckAttendance(int memberId, int classId)
        {
            string query = "SELECT attendance FROM attendance WHERE member_id = @MemberId AND class_id = @ClassId";

            using (SqlConnection conn = new SqlConnection(Authentication.Instance.ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Set parameters for member_id and class_id
                    cmd.Parameters.AddWithValue("@MemberId", memberId);
                    cmd.Parameters.AddWithValue("@ClassId", classId);

                    object result = cmd.ExecuteScalar();

                    // Check if a result was found
                    if (result != null && result is int attendance)
                    {
                        // Return "Attended" if attendance is 1, "Absent" if 0
                        return attendance == 1 ? "Attended" : "Absent";
                    }
                }
            }

            // Return "No Information" if no record is found
            return "No Information";
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

        private void label43_Click(object sender, EventArgs e)
        {

        }

        private void label42_Click(object sender, EventArgs e)
        {

        }

        private void label41_Click(object sender, EventArgs e)
        {

        }
    }

    // Structure to represent details of a class
    public class ClassDetails
    {
        public int ClassId;
        public string Name;
        public int TrainerId;
        public DateTime ClassStart;
        public DateTime ClassEnd;

        public ClassDetails(int classId, string name, int trainerId, DateTime classStart, DateTime classEnd)
        {
            ClassId = classId;
            Name = name;
            TrainerId = trainerId;
            ClassStart = classStart;
            ClassEnd = classEnd;
        }
    }
}
