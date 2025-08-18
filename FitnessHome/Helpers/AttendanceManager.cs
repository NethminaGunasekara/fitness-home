using fitness_home.Services;
using fitness_home.Views.Messages;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitness_home.Helpers
{
    internal class AttendanceManager
    {
        /// <summary>
        /// Counts the number of members who attended on a given date.
        /// </summary>
        /// <param name="date">The date to check attendance for.</param>
        /// <returns>A string representing the count of members attended on the given date.</returns>
        public string CountDailyAttendance(DateTime date)
        {
            int attendanceCount = 0; // Initialize a counter to hold the count of attendance records

            // SQL query to count distinct member_id rows in the "attendance" table where the date matches the provided date
            string query = "SELECT COUNT(DISTINCT member_id) FROM attendance WHERE CAST(date AS DATE) = @date";

            try
            {
                // Create a new SQL connection using the connection string from the Authentication class
                using (SqlConnection conn = new SqlConnection(Authentication.Instance.ConnectionString))
                {
                    conn.Open(); // Open the connection to the database

                    // Prepare the SQL command with the query and the connection
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Add the date parameter to the SQL command
                        cmd.Parameters.AddWithValue("@date", date.Date); // Use .Date to extract the date part

                        // Execute the query and get the result as an integer
                        attendanceCount = (int)cmd.ExecuteScalar();
                    }
                }
            }

            catch (SqlException)
            {
                // Handle database connection errors by showing an application error dialog
                new ApplicationError(ErrorType.DatabaseError).ShowDialog();
            }

            // If the number of members attended for the day is 0
            if (attendanceCount > 0)
            {
                // Convert the attendance count to a string with a minimum length of 3 characters to match the return type and return it
                return attendanceCount.ToString().PadLeft(3, '0');
            }

            // Convert the attendance count to a string with to match the return type and return it
            return attendanceCount.ToString();
        }

    }
}
