using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using fitness_home.Services;
using fitness_home.Utils.Types.UserTypes;
using fitness_home.Properties;
using System.Data.SqlClient;
using fitness_home.Views.Messages;
using fitness_home.Helpers;
using fitness_home.Utils.Types;

namespace fitness_home.Views.Member.Components.Views
{
    public partial class Dashboard : UserControl
    {
        // Field to store an instance of the Assessments helper class to use "CalculateBMR", "CalculateBFP", and "CalculateLBMPercentage" methods
        AssessmentsForMember Assessments;

        public Dashboard()
        {
            InitializeComponent();

            // Retrieve and store logged user information from the "Authentication" class
            User loggedUser = Authentication.LoggedUser;

            // Set an avatar based on the user's gender
            pictureBox_avatar.BackgroundImage = loggedUser.Gender == Utils.Types.Gender.Male ? Resources.avatar_male : Resources.avatar_female;

            // Display the assessments for the user
            // DisplayMemberAssessments(loggedUser.ID);

            // Retrieve and display the first three classes for the current date
            List<ClassDetails> classDetails = Schedule.GetScheduleForDay(DateTime.Now.Date, loggedUser.ID, loggedUser.PlanID);

            // Set the first class details if the retrieved list of classes has at least one class
            if(classDetails.Count >= 1)
                SetClassDetails(classDetails[0], class_name_1, class_trainer_1, class_time_1, class_status_1);

            // Set the second class details if the retrieved list of classes has at least two classes
            if (classDetails.Count >= 2)
                SetClassDetails(classDetails[1], class_name_2, class_trainer_2, class_time_2, class_status_2);

            // Set the third class details if the retrieved list of classes has at least three classes
            if (classDetails.Count >= 3)
                SetClassDetails(classDetails[2], class_name_3, class_trainer_3, class_time_3, class_status_3);
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

        // Retrieves and display information about the currently logged in member
        private void DisplayMemberInformation(int memberId)
        {
            // Retrieve and store logged user information from the "Authentication" class
            User loggedUser = Authentication.LoggedUser;

            // Set the member's name in profile view panel
            label_name.Text = $"{loggedUser.FirstName} {loggedUser.LastName}";

            // Set the member's email in profile view panel
            label_email.Text = loggedUser.Email;

            // Retrieve and set the membership plan using the planId from "loggedUser" object
            label_membership_type.Text = MembershipPlan.Instance.GetPlanNameById(loggedUser.PlanID);

            // Retrieve the membership plan id of the currently logged in user
            int userPlanId = Authentication.LoggedUser.PlanID;

            // Get the name of the membership plan associated with the user by using its id
            string membershipPlanName = MembershipPlan.Instance.GetPlanById(userPlanId).PlanName;

            // Set the user's membership plan name
            label_membership_type.Text = membershipPlanName;

            try
            {
                // Create a new SQL connection using the connection string from the Authentication class
                using (SqlConnection conn = new SqlConnection(Authentication.Instance.ConnectionString))
                {
                    conn.Open();

                    // SQL query to retrieve height, weight, activity_level, and calorie_goal based on the member_id
                    string query = "SELECT height, weight, activity_level, calorie_goal FROM assessments WHERE member_id = @MemberId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MemberId", memberId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Check if the query returned any results
                            if (reader.Read())
                            {
                                // Retrieve and store the 'MemberHeight' value from the first column (index 0)
                                short MemberHeight = reader.GetInt16(0);

                                // Retrieve and store the 'MemberWeight' value from the second column (index 1)
                                short MemberWeight = reader.GetInt16(1);

                                // Retrieve and store the 'activity_level' value from the third column (index 2)
                                string ActivityFactor = reader.GetString(2);

                                // Retrieve and store the 'calorie_goal' value from the fourth column (index 3)
                                short CalorieGoal = reader.GetInt16(3);

                                // Set the user's height
                                label_height.Text = MemberHeight.ToString();

                                // Set the user's weight
                                label_weight.Text = MemberWeight.ToString();

                                // Set the user's daily calorie goal value
                                label_calorie_goal.Text = $"{CalorieGoal} kcal";

                                // Calculate and set the user's BMR value using a helper method
                                label_bmr.Text = $"{((int)Assessments.CalculateBMR(MemberHeight, MemberWeight, Authentication.LoggedUser.DateOfBirth, ActivityFactor))} kcal";

                                // Calculate the user's BFP value using a helper method
                                double bodyFatPercentage = Assessments.CalculateBFP(MemberHeight, MemberWeight, Authentication.LoggedUser.DateOfBirth, Authentication.LoggedUser.Gender);

                                // Set the user's BFP value
                                label_bfp.Text = $"{bodyFatPercentage:F1}%";

                                // Calculate and set the user's LBM value using a helper method
                                label_lbm.Text = $"{Assessments.CalculateLBMPercentage(MemberWeight, bodyFatPercentage):F1}%";
                            }

                            // If the query returned no results, display dashes indicating that no assessments are made for the user
                            else
                            {
                                // Set the user's height
                                label_height.Text = "-";

                                // Set the user's weight
                                label_weight.Text = "-";

                                // Set the user's daily calorie goal value
                                label_calorie_goal.Text = "-";

                                // Calculate and set the user's BMR value
                                label_bmr.Text = "-";

                                // Set the user's BFP value
                                label_bfp.Text = "-";

                                // Calculate and set the user's LBM value
                                label_lbm.Text = "-";
                            }
                        }
                    }
                }
            }
            catch (SqlException)
            {
                // Display a database error if the query fails
                new ApplicationError(ErrorType.DatabaseError);
            }
        }

        // ** Event: When the control is first loaded
        private void DashboardView_Load(object sender, EventArgs e)
        {
            // Apply rounded corners to a list of selected panels
            RoundedCorners.Apply(panel_schedule, panel_calorie_goal, panel_lbm, panel_bmr, panel_bfp, panel_profile_view, panel_user_stats, panel_table_heading);
        }

        // ** Event: When the control is being resized
        private void DashboardView_Resize(object sender, EventArgs e)
        {
            // Here, we re-calculate the size of the panels with rounded corners as our control is resized
            RoundedCorners.Apply(panel_schedule, panel_calorie_goal, panel_lbm, panel_bmr, panel_bfp, panel_profile_view, panel_user_stats, panel_table_heading);
        }

        // ** Event: When the control needs to be repainted
        private void Dashboard_Paint(object sender, PaintEventArgs e)
        {
            // Retrieve the id of currently logged in user
            int loggedUserId = Authentication.LoggedUser.ID;

            // Display information about the currently logged in member
            DisplayMemberInformation(loggedUserId);
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void class_trainer_3_Click(object sender, EventArgs e)
        {

        }

        private void class_time_3_Click(object sender, EventArgs e)
        {

        }

        private void class_name_3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void class_time_2_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void btn_edit_profile_Click(object sender, EventArgs e)
        {

        }
    }
}
