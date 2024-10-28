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
                    string query = @"SELECT class_id, class_name, start_time, end_time
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
                                TimeSpan startTime = reader.GetTimeSpan(2);
                                TimeSpan endTime = reader.GetTimeSpan(3);

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

        // ** Sets the status of a class ("Not Started", "Finished", or "Canceled")
        public void SetClassStatus(Label statusLabel, int classId, DateTime classDate)
        {
            // Class status can be any of the values: "Not Started", "Finished", or "Canceled"        

            // Compare the scheduled class date with the current date and time
            if (classDate > DateTime.Now)
            {
                // Update the class status if the class has not started yet
                statusLabel.Text = "Not Started";

                Console.WriteLine($"Class scheduled for {classDate} has not started yet.");

                // Set status label background and foreground colors
                statusLabel.BackColor = Color.FromArgb(46, 44, 57);
                statusLabel.ForeColor = Color.FromArgb(118, 87, 255);
            }
            else if (classDate < DateTime.Now)
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

                        if (attendanceCount > 0)
                        {
                            // Update the class status if the class has been canceled
                            statusLabel.Text = "Canceled";

                            // Set status label background and foreground colors
                            statusLabel.BackColor = Color.FromArgb(46, 44, 57);
                            statusLabel.ForeColor = Color.FromArgb(118, 87, 255);

                            return;
                        }
                    }
                }

                // If there are no attendance records and the date is in the past, set status to "Finished"
                statusLabel.Text = "Finished";
            }
        }

        // ** Helper Method: Displays the list of classes associated with the trainer for a given date
        public List<ClassDetails> GetScheduleOfTrainer(DateTime date)
        {
            List<ClassDetails> classDetailsList = new List<ClassDetails>();

            Console.WriteLine($"Retrieving schedule for the day {date.ToString("dd MMMM, yyyy")}");

            int trainerId = Authentication.LoggedUser.ID;

            // SQL query to retrieve classes for the given trainer and date
            string query = "SELECT class_id, class_name, trainer_id, start_time, end_time FROM schedule WHERE trainer_id = @TrainerId AND CAST(date AS DATE) = @Date";

            try
            {
                using (SqlConnection conn = new SqlConnection(Authentication.Instance.ConnectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TrainerId", trainerId);
                        cmd.Parameters.AddWithValue("@Date", date.Date);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int classId = reader.GetInt32(0);
                                string className = reader.GetString(1);
                                int retrievedTrainerId = reader.GetInt32(2);
                                DateTime classStart = reader.GetDateTime(3);
                                DateTime classEnd = reader.GetDateTime(4);

                                // Initialize with a default status of "Canceled"
                                ClassDetails classDetails = new ClassDetails(classId, className, retrievedTrainerId, classStart, classEnd);

                                // Add to the list
                                classDetailsList.Add(classDetails);
                            }
                        }
                    }
                }
            }
            catch (SqlException)
            {
                // Handle SQL errors, maybe log or show a message
            }

            return classDetailsList;
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

        // ** Helper Method: Displays the schedule for a given date
        public void DisplayScheduleFor(DateTime date)
        {

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
        public DateTime ClassStart;
        public DateTime ClassEnd;
        public string ClassStatus; // "Not Started", "Finished", or "Canceled"

        public ClassDetails(int classId, string name, int trainerId, DateTime classStart, DateTime classEnd, string classStatus = "Cancelled")
        {
            ClassId = classId;
            Name = name;
            TrainerId = trainerId;
            ClassStart = classStart;
            ClassEnd = classEnd;
            ClassStatus = classStatus;
        }
    }
}
