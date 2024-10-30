using fitness_home.Helpers;
using fitness_home.Services;
using fitness_home.Utils.Types.UserTypes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace fitness_home.Views.Admin.Tabs
{
    public partial class Dashboard : UserControl
    {
        // Field to store list of class name labels for the 7 rows
        List<Label> ClassNameLabels = new List<Label>();

        // Field to store list of class time labels for the 7 rows
        List<Label> TimeLabels = new List<Label>();

        // Field to store list of students count labels for the 7 rows
        List<Label> StudentsCountLabels = new List<Label>();

        // Field to store list of class status labels for the 7 rows
        List<Label> StatusLabels = new List<Label>();

        // Initialize an instance of the "AttendanceManager" helper class
        AttendanceManager attendanceManager = new AttendanceManager();

        public Dashboard()
        {
            InitializeComponent();
        
            // Retrieve information about the logged in admin
            User adminData = Authentication.LoggedUser;

            // Set admin full name (using string interpolation) on dashboard where his profile data is displayed
            label_name.Text = $"{adminData.FirstName} {adminData.LastName}";

            // Set admin email on dashboard where his profile data is displayed
            label_email.Text = adminData.Email;

            // Display the number of students attended for the current date using the "CountDailyAttendance" method from "AttendanceManager" helper class
            label_member_attendance.Text = attendanceManager.CountDailyAttendance(DateTime.Now);

            // Display the total revenue for the last month using the "CalculateMonthlyTransactionTotal" helper method from the "TransactionInfo" class
            label_monthly_revenue.Text = TransactionInfo.CalculateMonthlyTransactionTotal();

            // Display admin id after formatting it to have a minimum length of 3 digits
            label_admin_id.Text = AdminData.FormatAdminId(adminData.ID);

            // Display the session start time in the "HH:MM AM/PM" format
            label_session_start.Text = AdminArea.SessionStart.ToString("hh:mm tt");

            // Initialize the lists of labels
            InitializeLabels();

            // Clear the list of classes already displayed
            ClearClassDetails();

            // Display the list of classes for today
            DisplayClasses();
        }

        // Method used to initialize all fields used to store labels for displaying classes
        private void InitializeLabels()
        {
            // Initialize the list of class name labels for the 8 rows
            ClassNameLabels = new List<Label> { label_name_1, label_name_2, label_name_3, label_name_4, label_name_5, label_name_6, label_name_7 };

            // Initialize the list of class time labels for the 8 rows
            TimeLabels = new List<Label> { label_time_1, label_time_2, label_time_3, label_time_4, label_time_5, label_time_6, label_time_7 };

            // Initialize the list of students count labels for the 8 rows
            StudentsCountLabels = new List<Label> { label_students_1, label_students_2, label_students_3, label_students_4, label_students_5, label_students_6, label_students_7 };

            // Initialize the list of class status labels for the 8 rows
            StatusLabels = new List<Label> { label_status_1, label_status_2, label_status_3, label_status_4, label_status_5, label_status_6, label_status_7 };
        }

        // ** Helper Method: Clears the text content of all labels
        private void ClearClassDetails()
        {
            for (int i = 0; i < 7; i++)
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

        // Retrieve and display the list of classes for today
        private void DisplayClasses()
        {
            // Initialize an instance of ScheduleManager helper class, in order to use helper methods from it
            ScheduleManager scheduleManager = new ScheduleManager();

            // Retrieve and store the list of classes (trainers add upto 8 classes for day)
            List<ClassDetails> classes = scheduleManager.GetScheduleForDay(DateTime.Now);

            // Clear the placeholder values already present on the form
            ClearClassDetails();

            // ** Purpose: Display the first 7 classes, or available number of classes (if less than 7) for the day
            for (int i = 0; i < 7; i++)
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
                    StudentsCountLabels[i].Text = ScheduleManager.GetNumberOfStudents(classDetails.ClassId);

                    // Set class status ("Not Started", "Finished", or "Canceled")
                    scheduleManager.SetClassStatus(StatusLabels[i], classDetails.ClassId, classDetails.ClassStart);

                    StatusLabels[i].Text = "Not Started"; ;
                }
            }
        }
    }
}
