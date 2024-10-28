using fitness_home.Helpers;
using fitness_home.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace fitness_home.Views.Trainer.Tabs
{
    public partial class Dashboard : UserControl
    {
        // Field to store list of class name labels for the 8 rows
        List<Label> ClassNameLabels = new List<Label>();

        // Field to store list of class time labels for the 8 rows
        List<Label> TimeLabels = new List<Label>();

        // Field to store list of students count labels for the 8 rows
        List<Label> StudentsCountLabels = new List<Label>();

        // Field to store list of class status labels for the 8 rows
        List<Label> StatusLabels = new List<Label>();

        public Dashboard()
        {
            InitializeComponent();

            // Initialize the list of class name labels for the 8 rows
            ClassNameLabels = new List<Label> { label_name_1, label_name_2, label_name_3, label_name_4, label_name_5, label_name_6, label_name_7, label_name_8 };

            // Initialize the list of class time labels for the 8 rows
            TimeLabels = new List<Label> { label_time_1, label_time_2, label_time_3, label_time_4, label_time_5, label_time_6, label_time_7, label_time_8 };

            // Initialize the list of students count labels for the 8 rows
            StudentsCountLabels = new List<Label> { label_students_1, label_students_2, label_students_3, label_students_4, label_students_5, label_students_6, label_students_7, label_students_8 };

            // Initialize the list of class status labels for the 8 rows
            StatusLabels = new List<Label> { label_status_1, label_status_2, label_status_3, label_status_4, label_status_5, label_status_6, label_status_7, label_status_8 };
        }

        // ** Helper Method: Clears the text content of all labels
        private void ClearClassDetails()
        {
            for (int i = 0; i < 8; i++)
            {
                // Set the text content of all four labels within the row to empty
                ClassNameLabels[i].Text = "";
                TimeLabels[i].Text = "";
                StudentsCountLabels[i].Text = "";
                StatusLabels[i].Text = "";

                // Set the background color of the status label to transparent
                StatusLabels[i].BackColor = Color.Transparent;
            }
        }

        // ** Helper Method: Retrieves the number of students involved in a class
        private string GetNumberOfStudents(int classId)
        {
            // Initialize variables to store "plan_id" and "group" from the schedule table
            int planId = 0;
            int groupId = 0;

            // Set up the database connection using the connection string from "Authentication" class
            using (SqlConnection connection = new SqlConnection(Authentication.Instance.ConnectionString))
            {
                connection.Open();

                // Step 1: Retrieve "plan_id" and "group" from the schedule table where "class_id" matches
                string scheduleQuery = "SELECT plan_id, [group] FROM schedule WHERE class_id = @ClassId";

                using (SqlCommand scheduleCommand = new SqlCommand(scheduleQuery, connection))
                {
                    // Bind required values as parameters to the query before execution
                    scheduleCommand.Parameters.AddWithValue("@ClassId", classId);

                    // Execute the command and read the results
                    using (SqlDataReader reader = scheduleCommand.ExecuteReader())
                    {
                        // If any matching rows are found
                        if (reader.Read())
                        {
                            // Retrieve "plan_id" and "group" values from the result set
                            planId = reader.GetInt32(0);
                            groupId = reader.GetInt32(1);
                        }

                        else
                        {
                            // Return "0" if no matching record is found in the schedule table
                            return "0";
                        }
                    }
                }

                // Step 2: Count the number of rows in the "member_group" table where "plan_id" and "group" match
                string countQuery = "SELECT COUNT(*) FROM member_group WHERE plan_id = @PlanId AND group_number = @Group";

                using (SqlCommand countCommand = new SqlCommand(countQuery, connection))
                {
                    // Parameterize the query with the retrieved `plan_id` and `group` values
                    countCommand.Parameters.AddWithValue("@PlanId", planId);
                    countCommand.Parameters.AddWithValue("@Group", groupId);

                    // Execute the count query and retrieve the number of matching rows
                    int studentCount = (int)countCommand.ExecuteScalar();

                    // Return the count as a string
                    return studentCount.ToString();
                }
            }
        }

        // Retrieve and display last two feedbacks received by the logged in trainer
        private void LoadLatestFeedbacks()
        {
            // Initialize an instance of FeedbackManager helper class, in order to use "GetFeedbackForTrainer" helper method from it
            FeedbackManager feedbackManager = new FeedbackManager();

            // Use "GetFeedbackForTrainer" helper method to retrieve the list of feedbacks for the trainer
            List<Feedback> feedbacks = feedbackManager.GetFeedbackForTrainer(Authentication.LoggedUser.ID);
        
            // If the feedbacks list has at least two items
            if(feedbacks.Count >= 2)
            {
                // Make feedback panels visible before displaying them
                panel_feedback_1.Visible = true;
                panel_feedback_2.Visible = true;

                // Retrieve the feedbacks individually from the feedbacks list
                Feedback feedback1 = feedbacks[0];
                Feedback feedback2 = feedbacks[1];

                // Set feedback titles
                label_feedback_1_title.Text = $"{feedback1.Member} says:";
                label_feedback_2_title.Text = $"{feedback2.Member} says:";

                // Set feedback messages
                label_feedback_1.Text = feedback1.Message;
                label_feedback_2.Text = feedback2.Message;
            }

            // If the feedbacks list has exactly one item
            if (feedbacks.Count == 1)
            {
                // Make the first feedback panel visible before displaying the feedback
                panel_feedback_1.Visible = true;

                // Feedback to display
                Feedback feedback = feedbacks[0];

                // Set feedback title
                label_feedback_1_title.Text = $"{feedback.Member} says:";

                // Set feedback message
                label_feedback_1.Text = feedback.Message;
            }
        }

        // Retrieve and display the list of classes for today
        private void DisplayClasses()
        {
            // Initialize an instance of ScheduleManager helper class, in order to use helper methods from it
            ScheduleManager scheduleManager = new ScheduleManager();

            // Retrieve and store the list of classes (trainers add upto 8 classes for day)
            List<ClassDetails> classes = scheduleManager.GetScheduleForTrainer(DateTime.Now, Authentication.LoggedUser.ID);

            // Clear the placeholder values already present on the form
            ClearClassDetails();

            // ** Purpose: Display the first 8 classes, or available number of classes (if less than 8) for the day
            for (int i = 0; i < 8; i++)
            {
                // Check the list of classes contain an item with the current value of "i" as its index
                if (classes.Count > i)
                {
                    // Proceed to add values for the current row of daily schedule table layout panel

                    // Retrieve the details of class at current index
                    ClassDetails classDetails = classes[i];

                    // Convert class start and end times to the 24h format
                    string classStartTime = classDetails.ClassStart.ToString("HH.mm");
                    string classEndTime = classDetails.ClassEnd.ToString("HH.mm");

                    // Set the class data for current row
                    ClassNameLabels[i].Text = classDetails.Name;
                    TimeLabels[i].Text = $"{classStartTime} - {classEndTime}";
                    StudentsCountLabels[i].Text = GetNumberOfStudents(classDetails.ClassId);

                    // Set class status ("Not Started", "Finished", or "Canceled")
                    scheduleManager.SetClassStatus(StatusLabels[i], classDetails.ClassId, classDetails.ClassStart);

                    StatusLabels[i].Text = "Not Started";;
                }
            }
        }

        // Displays basic information about a trainer (trainer name, email, id, specialization and hired date)
        private void DisplayTrainerInfo()
        {
            // Set trainer name, email, id, specialization and hired date in the profile section of the dashboard
            label_name.Text = $"{Authentication.LoggedUser.FirstName} {Authentication.LoggedUser.LastName}";
            label_email.Text = Authentication.LoggedUser.Email;
            label_hired_date.Text = Authentication.LoggedUser.HiredDate.ToString("MM/dd/yyyy");

            // Retrieve the logged in trainer's id from the Authentication class
            int trainerId = Authentication.LoggedUser.ID;

            // Format the trainer ID by prefixing it with 'T' and padding with leading zeros
            // Example: If trainerId is 1, the result will be "T001"
            //
            // Methods used: 
            // ** ToString() converts the integer memberId to a string.
            // ** PadLeft(3, '0') ensures that the string is at least 3 characters long by 
            //   adding '0' characters to the left if necessary. If the ID is already 
            //   3 or more digits, no padding is applied.
            string formattedId = trainerId.ToString().PadLeft(3, '0');

            label_trainer_id.Text = $"T{formattedId}";
        }

        // ** Event: When the control is first loaded
        private void Dashboard_Load(object sender, EventArgs e)
        {
            // Apply rounded corners to selected panels
            RoundedCorners.Apply(panel_schedule, panel_calorie_goal, panel_profile_view, panel_user_stats, panel_table_heading, panel_feedback_1, panel_feedback_2);

            // Display the list of classes for today
            DisplayClasses();

            // Retrieve and display last two feedbacks received by the logged in trainer
            LoadLatestFeedbacks();

            // Display basic information about a trainer
            DisplayTrainerInfo();
        }

        // ** Event: When the control needs to be repainted (i.e. When we call the Invalidate() method on this form to update data)
        private void Dashboard_Paint(object sender, PaintEventArgs e)
        {
            // Clear the list of classes already displayed
            ClearClassDetails();

            // Display the list of classes for today
            DisplayClasses();
        }

        // ** Event: When the control is being resized
        private void Dashboard_Resize(object sender, EventArgs e)
        {
            // Here, we re-calculate the size of the panels with rounded corners as our control is resized
            RoundedCorners.Apply(panel_schedule, panel_calorie_goal, panel_profile_view, panel_user_stats, panel_table_heading, panel_feedback_1, panel_feedback_2);
        }
    }
}
