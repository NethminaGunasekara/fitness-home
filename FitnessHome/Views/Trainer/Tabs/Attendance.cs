using fitness_home.Helpers;
using fitness_home.Services;
using fitness_home.Utils.Types.UserTypes;
using fitness_home.Views.Messages;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace fitness_home.Views.Trainer.Tabs
{
    public partial class Attendance : UserControl
    {
        // Id of the member being assessed by the trainer (we'll later use this to update assessments for them)
        private int MemberId = 0;

        // Field to store an instance of MemberData class, used to retrieve and edit information about a member
        MemberData MemberData;

        // Field to store list of class name labels for the 8 rows
        List<Label> ClassNameLabels = new List<Label>();

        // Field to store list of class time labels for the 8 rows
        List<Label> TimeLabels = new List<Label>();

        // Field to store list of attendnce labels for the 8 rows
        List<Label> AttendanceLabels = new List<Label>();

        // Field to store list of mark attended buttons for the 8 rows
        List<Button> AttendedButtons = new List<Button>();

        // Field to store list of mark absent buttons for the 8 rows
        List<Button> AbsentButtons = new List<Button>();

        public Attendance()
        {
            InitializeComponent();

            InitializeLabels();

            ClearClassDetails();
        }

        // Method used to initialize all fields used to store labels for displaying classes and action buttons
        private void InitializeLabels()
        {
            // Initialize the list of class name labels for the 8 rows
            ClassNameLabels = new List<Label> { class_name_1, class_name_2, class_name_3, class_name_4, class_name_5, class_name_6, class_name_7, class_name_8 };

            // Initialize the list of class time labels for the 8 rows
            TimeLabels = new List<Label> { class_time_1, class_time_2, class_time_3, class_time_4, class_time_5, class_time_6, class_time_7, class_time_8 };

            // Initialize the list of attendance labels for the 8 rows
            AttendanceLabels = new List<Label> { attendance_1, attendance_2, attendance_3, attendance_4, attendance_5, attendance_6, attendance_7, attendance_8 };

            // Initialize the list of mark attended buttons for the 8 rows
            AttendedButtons = new List<Button> { mark_attended_1, mark_attended_2, mark_attended_3, mark_attended_4, mark_attended_5, mark_attended_6, mark_attended_7, mark_attended_8 };

            // Initialize the list of mark absent buttons for the 8 rows
            AbsentButtons = new List<Button> { mark_absent_1, mark_absent_2, mark_absent_3, mark_absent_4, mark_absent_5, mark_absent_6, mark_absent_7, mark_absent_8 };
        }

        // ** Helper Method: Hides any existing class data before showing the newly updated ones
        private void ClearClassDetails()
        {
            for (int i = 0; i < 8; i++)
            {
                // Hide all lables and buttons before displaying a new set of classes
                ClassNameLabels[i].Visible = false;
                TimeLabels[i].Visible = false;
                AttendanceLabels[i].Visible = false;
                AttendedButtons[i].Visible = false;
                AbsentButtons[i].Visible = false;
            }
        }

        // ** Make a row of controls visible using the index of the list they're assigned to
        private void DisplayRow(int i)
        {
            ClassNameLabels[i].Visible = true;
            TimeLabels[i].Visible = true;
            AttendanceLabels[i].Visible = true;
            AttendedButtons[i].Visible = true;
            AbsentButtons[i].Visible = true;
        }

        // ** Event: When the search button is clicked
        private void button_search_member_Click(object sender, System.EventArgs e)
        {
            string userInput = textBox_search.Text;

            // Try to parse the entered member ID to an integer (actual member id within the database: e.g. 3)
            try
            {
                // Extract the numeric part of the entered member id after removing "M" from it. e.g. "M001" becomes "001"
                string numericPart = userInput.Replace("M", "");

                int memberId = int.Parse(numericPart);

                // Set the id of member being assessed
                MemberId = memberId;
            }

            // If any error occurs while parsing
            catch (Exception)
            {
                // Initialize an input error message to display
                InputError inputError = new InputError(
                    errorType: "Invalid Member ID Format",
                    errorTitle: "Member ID format you've entered is invalid",
                    errorMessage: "Please check your input and try again");

                // Display the error message
                inputError.ShowDialog();

                return; // Exit the method as we don't want to continue after an exception occurs
            }

            // Retrieve the information about a member
            try
            {
                // Retrieve personal information of the searched member
                MemberData = new MemberData(MemberId);
            }

            // If the custom exception thrown when no user is found with the given id occurs
            catch (MemberNotFoundException)
            {
                // Initialize a member not found error message to display
                InputError inputError = new InputError(
                    errorType: "Member Not Found",
                    errorTitle: "No Member Found with Given ID",
                    errorMessage: "Please check the ID and try again.");

                // Display the error message
                inputError.ShowDialog();

                return; // Exit the method as we don't want to continue after an exception occurs
            }

            // If none of the errors above occured, proceed to display class information
            // and page title when the user has entered something to search
            flowLayoutPanel_title.Visible = tableLayoutPanel_schedule.Visible = true;

            UpdateTitle();

            DisplayClasses();
        }

        // Update the "assessments for" title (e.g. "Assessments For: Shehan Anushka (M002)")
        private void UpdateTitle()
        {
            // Step 1: Convert the integer memberId to a string first
            string memberIdString = MemberId.ToString();

            // Step 2: Add a padding left of "0"s to have a minimum length of 3 digits for the numeric part of the member id
            string paddedMemberId = memberIdString.PadLeft(3, '0');

            // Step 3: Combine the padded numeric part of the member id (e.g. "003") with the letter "M" and display it as the id of the member being assessed
            string formattedMemberId = $"M{paddedMemberId}";

            // Step 4: Combine the formatted member id with the member's name and display
            label_assessments_for.Text = $"{MemberData.FirstName} {MemberData.LastName} ({formattedMemberId})";
        }

        // Retrieve and display the list of classes for today
        private void DisplayClasses()
        {
            // Initialize an instance of ScheduleManager helper class, in order to use helper methods from it
            ScheduleManager scheduleManager = new ScheduleManager();

            // Retrieve and store the list of classes for the member
            List<ClassDetails> classes = scheduleManager.GetScheduleForMemberToday(MemberData.PlanID);

            // Hide the placeholder values, or any existing controls that are already present on the form
            ClearClassDetails();

            // ** Purpose: Display the first 8 classes, or available number of classes (if less than 8) for the day
            for (int i = 0; i < Math.Min(8, classes.Count); i++)
            {
                // Proceed to add values for the current row of daily schedule table layout panel

                // Display the current row for assigning class details
                DisplayRow(i);

                // Retrieve the details of class at current index
                ClassDetails classDetails = classes[i];

                // Convert class start and end times to the 24h format
                string classStartTime = classDetails.ClassStart.ToString("HH.mm");
                string classEndTime = classDetails.ClassEnd.ToString("HH.mm");

                // Set the class data for current row
                ClassNameLabels[i].Text = classDetails.Name;
                TimeLabels[i].Text = $"{classStartTime} - {classEndTime}";

                // Set attendance status for a given class
                string attendance = ScheduleManager.CheckAttendance(MemberId, classDetails.ClassId);
                // If the trainer has marked the user's attendence as "Attended"
                if (attendance == "Attended")
                {
                    AttendanceLabels[i].Text = "Attended";
                    AttendanceLabels[i].BackColor = Color.FromArgb(35, 51, 48);
                    AttendanceLabels[i].ForeColor = Color.FromArgb(21, 179, 146);
                }

                // If the trainer has marked the user's attendence as "Ansent"
                else if (attendance == "Absent")
                {
                    AttendanceLabels[i].Text = "Absent";
                    AttendanceLabels[i].BackColor = Color.FromArgb(57, 44, 44);
                    AttendanceLabels[i].ForeColor = Color.FromArgb(255, 87, 87);
                }

                // If either the trainer hasn't marked the user's attendence or the class hasn't started yet
                else
                {
                    AttendanceLabels[i].Text = "No Information";
                    AttendanceLabels[i].BackColor = Color.FromArgb(46, 44, 57);
                    AttendanceLabels[i].ForeColor = Color.FromArgb(118, 87, 255);
                }


                AttendedButtons[i].Click += delegate
                {
                    // Mark the user as attended
                    UpdateAttendance(MemberId, classDetails.ClassId, DateTime.Now.Date, 1);

                    // Display a success message
                    SuccessMessage successMessage = new SuccessMessage(
                        heading: "Attendance Marked!",
                        title: $"You have successfully recorded attendance for {MemberData.ID.ToString().PadLeft(3, '0')}",
                        reference: "Search for the member id to view updated data");

                    successMessage.Show();
                };

                AbsentButtons[i].Click += delegate
                {   
                    // Mark the user as absent
                    UpdateAttendance(MemberId, classDetails.ClassId, DateTime.Now.Date, 0);
                };
            }
        }


        public void UpdateAttendance(int memberId, int classId, DateTime date, int attendance)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Authentication.Instance.ConnectionString))
                {
                    conn.Open();

                    // Check if an attendance record for the given member, class, and date already exists
                    string checkQuery = @"SELECT COUNT(*) FROM attendance 
                                  WHERE member_id = @MemberId AND class_id = @ClassId AND date = @Date";

                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@MemberId", memberId);
                        checkCmd.Parameters.AddWithValue("@ClassId", classId);
                        checkCmd.Parameters.AddWithValue("@Date", date.Date);

                        int recordCount = (int)checkCmd.ExecuteScalar();

                        if (recordCount > 0)
                        {
                            // Update existing attendance record
                            string updateQuery = @"UPDATE attendance 
                                           SET attendance = @Attendance 
                                           WHERE member_id = @MemberId AND class_id = @ClassId AND date = @Date";

                            using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                            {
                                updateCmd.Parameters.AddWithValue("@Attendance", attendance);
                                updateCmd.Parameters.AddWithValue("@MemberId", memberId);
                                updateCmd.Parameters.AddWithValue("@ClassId", classId);
                                updateCmd.Parameters.AddWithValue("@Date", date.Date);

                                updateCmd.ExecuteNonQuery();
                            }
                        }

                        else
                        {
                            // Insert new attendance record
                            string insertQuery = @"INSERT INTO attendance (member_id, class_id, date, attendance) 
                                           VALUES (@MemberId, @ClassId, @Date, @Attendance)";

                            using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                            {
                                insertCmd.Parameters.AddWithValue("@MemberId", memberId);
                                insertCmd.Parameters.AddWithValue("@ClassId", classId);
                                insertCmd.Parameters.AddWithValue("@Date", date.Date);
                                insertCmd.Parameters.AddWithValue("@Attendance", attendance);

                                insertCmd.ExecuteNonQuery();
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
        }

    }
}
