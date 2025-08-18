// ----------------------------------------------------------------------------
// MembershipPlan.cs - Developed by Nethmina Gunasekara
// Repository: https://github.com/NethminaGunasekara/fitness-home
// 
// This class is responsible for retrieving, managing, and 
// editing schedule informmation for the trainer area
// within the Fitness Home gym management system.
// 
// This code is part of the Fitness Home project.
// ----------------------------------------------------------------------------
using fitness_home.Services;
using fitness_home.Views.Messages;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace fitness_home.Helpers
{
    internal class ScheduleManager
    {
        // ** Retrieves the list of classes conducted by a trainer for a given date
        public List<ClassDetails> GetScheduleForTrainer(DateTime date, int trainerId)
        {
            // A list of objects that contain every property of ClassDetails class
            List<ClassDetails> classes = new List<ClassDetails>();

            try
            {
                using (SqlConnection conn = new SqlConnection(Authentication.Instance.ConnectionString))
                {
                    conn.Open();

                    // Retrieve the class details from the schedule table
                    string query = @"SELECT class_id, class_name, [group], start_time, end_time
                                            FROM schedule
                                            WHERE trainer_id = @TrainerId 
                                            AND date = @Date";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Add parameters to the command ("trainer id" and the date to retrieve the plans for)
                        cmd.Parameters.AddWithValue("@TrainerId", Authentication.LoggedUser.ID);
                        cmd.Parameters.AddWithValue("@Date", date.Date);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int classId = reader.GetInt32(0);
                                string className = reader.GetString(1);
                                int groupNumber = reader.GetInt32(2);
                                TimeSpan startTime = reader.GetTimeSpan(3);
                                TimeSpan endTime = reader.GetTimeSpan(4);

                                // Construct start and end DateTime values by combining the date with the times
                                DateTime classStart = date.Date.Add(startTime);
                                DateTime classEnd = date.Date.Add(endTime);

                                // Create a ClassDetails object and add it to the list
                                classes.Add(new ClassDetails(classId, className, trainerId, groupNumber, classStart, classEnd));
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
            string query = "SELECT attendance_status FROM attendance WHERE member_id = @MemberId AND class_id = @ClassId";

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


        // ** Retrieves the list of class names and times for the current date for a given member
        public List<ClassDetails> GetScheduleForMemberToday(int planId)
        {
            List<ClassDetails> classes = new List<ClassDetails>();

            try
            {
                using (SqlConnection conn = new SqlConnection(Authentication.Instance.ConnectionString))
                {
                    conn.Open();

                    // Query to retrieve class name, start time, and end time for today
                    string query = "SELECT class_id, class_name, start_time, end_time FROM schedule WHERE plan_id = @PlanId AND date = @Today";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@PlanId", planId);
                        cmd.Parameters.AddWithValue("@Today", DateTime.Today);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int classId = reader.GetInt32(0);
                                string className = reader.GetString(1);
                                TimeSpan startTime = reader.GetTimeSpan(2);
                                TimeSpan endTime = reader.GetTimeSpan(3);

                                // Add the class details to the list
                                classes.Add(new ClassDetails(classId, className, 0, 0, DateTime.Today.Add(startTime), DateTime.Today.Add(endTime)
                                ));
                            }
                        }
                    }
                }
            }
            catch (SqlException)
            {
                new ApplicationError(ErrorType.DatabaseError);
            }

            return classes;
        }


        // ** Retrieves the list of classes for a given date
        public List<ClassDetails> GetScheduleForDay(DateTime date)
        {
            // A list of objects that contain every property of ClassDetails class
            List<ClassDetails> classes = new List<ClassDetails>();

            try
            {
                using (SqlConnection conn = new SqlConnection(Authentication.Instance.ConnectionString))
                {
                    conn.Open();

                    // Retrieve the class details from the schedule table
                    string query = @"SELECT class_id, class_name, trainer_id, [group], start_time, end_time
                                            FROM schedule
                                            WHERE date = @Date";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Add the date to retrieve the plans for as a parameter to the command
                        cmd.Parameters.AddWithValue("@Date", date.Date);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int classId = reader.GetInt32(0);
                                string className = reader.GetString(1);
                                int groupNumber = reader.GetInt32(2);
                                int trainerId = reader.GetInt32(3);
                                TimeSpan startTime = reader.GetTimeSpan(4);
                                TimeSpan endTime = reader.GetTimeSpan(5);

                                // Construct start and end DateTime values by combining the date with the times
                                DateTime classStart = date.Date.Add(startTime);
                                DateTime classEnd = date.Date.Add(endTime);

                                // Create a ClassDetails object and add it to the list
                                classes.Add(new ClassDetails(classId, className, trainerId, groupNumber, classStart, classEnd));
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

        // ** Helper Method: Retrieves the number of students involved in a class
        public static string GetNumberOfStudents(int classId)
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

        // ** Sets the status of a class ("Not Started", "Finished", or "Canceled")
        public void SetClassStatus(Label statusLabel, int classId, DateTime classDate)
        {
            // Class status can be any of the values: "Not Started", "Finished", or "Canceled"        

            // Compare the scheduled class date with the current date and time
            if (classDate <= DateTime.Now)
            {
                // Update the class status if the class has not started yet
                statusLabel.Text = "Not Started";

                // Set status label background and foreground colors
                statusLabel.BackColor = Color.FromArgb(43, 47, 63);
                statusLabel.ForeColor = Color.FromArgb(118, 87, 255);
            }

            else if (classDate > DateTime.Now)
            {
                // Check if there are any attendance records associated with this class ID
                using (SqlConnection connection = new SqlConnection(Authentication.Instance.ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM attendance WHERE class_id = @ClassId";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ClassId", classId);

                        int attendanceCount = (int)cmd.ExecuteScalar();

                        if (attendanceCount == 0)
                        {
                            // Update the class status if the class has been canceled
                            statusLabel.Text = "Canceled";

                            // Set status label background and foreground colors
                            statusLabel.BackColor = Color.FromArgb(63, 43, 43);
                            statusLabel.ForeColor = Color.FromArgb(255, 87, 87);
                        }

                        else
                        {
                            // If there are no attendance records and the date is in the past, set status to "Finished"
                            statusLabel.Text = "Finished";

                            // Set status label background and foreground colors
                            statusLabel.BackColor = Color.FromArgb(63, 43, 43);
                            statusLabel.ForeColor = Color.FromArgb(255, 87, 87);
                        }
                    }
                }
            }
        }

        // ** Helper Method: Clears text content of labels
        public void ClearTextContent(List<Label> labels)
        {
            // Clear the text content and reset tbe background color of each label from the list of labels passed
            labels.ForEach(label =>
            {
                // Clear the text content
                label.Text = "";

                // Reset the background color of the label
                label.BackColor = Color.Transparent;
            });
        }
    }

    // ** Structure to store the dates for each day of the current week
    class DaysOfWeek
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

    // Structure to represent details of a class
    public class ClassDetails
    {
        public int ClassId;
        public string Name;
        public int TrainerId;
        public int GroupNumber;
        public DateTime ClassStart;
        public DateTime ClassEnd;
        public string ClassStatus; // "Not Started", "Finished", or "Canceled"

        public ClassDetails(int classId, string name, int trainerId, int groupNumber, DateTime classStart, DateTime classEnd, string classStatus = "Cancelled")
        {
            ClassId = classId;
            Name = name;
            TrainerId = trainerId;
            GroupNumber = groupNumber;
            ClassStart = classStart;
            ClassEnd = classEnd;
            ClassStatus = classStatus;
        }
    }
}
