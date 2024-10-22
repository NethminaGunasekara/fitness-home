// ----------------------------------------------------------------------------
// FeedbackManager.cs - Developed by Nethmina Gunasekara
// Repository: https://github.com/NethminaGunasekara/fitness-home
// 
// This class is responsible for retrieving feedback data from the feedback 
// table and providing functionalities to display feedback in the trainer 
// and admin dashboards, as well as submit feedback from the member dashboard 
// within the Fitness Home gym management system.
// 
// This code is part of the Fitness Home project.
// ----------------------------------------------------------------------------
using fitness_home.Services;
using fitness_home.Views.Messages;
using System.Data.SqlClient;
using System;

namespace fitness_home.Helpers
{
    internal class FeedbackManager
    {
        // Singleton instance of the class
        private static FeedbackManager instance;

        // Lock object used to ensure thread safety
        private static readonly object _lock = new object();

        // Private constructor to prevent direct instantiation
        private FeedbackManager() { }

        // Gets the singleton instance of the FeedbackManager class.
        // This ensures thread safety with double-check locking.
        // 
        // Read more about the Singleton Design Pattern (Java):
        // https://www.digitalocean.com/community/tutorials/java-singleton-design-pattern-best-practices-examples
        public static FeedbackManager Instance
        {
            get
            {
                // Ensure thread-safe singleton initialization
                if (instance == null)
                {
                    lock (_lock)
                    {
                        if (instance == null)
                        {
                            instance = new FeedbackManager();
                        }
                    }
                }
                return instance;
            }
        }

        /// <summary>
        /// Saves a feedback message to the database.
        /// Retrieves the relevant trainer's ID based on the logged-in user's membership plan
        /// and inserts the feedback message into the feedback table.
        /// </summary>
        /// <param name="message">The feedback message provided by the member.</param>
        public void SaveFeedback(string message)
        {
            // SQL query to retrieve the trainer_id based on the member's plan_id
            string query = "SELECT trainer_id FROM membership_plan WHERE plan_id = @PlanID";

            try
            {
                // Create a connection by reusing the connection string from the Authentication class
                using (SqlConnection conn = new SqlConnection(Authentication.Instance.ConnectionString))
                {
                    conn.Open();

                    // Retrieve the trainer_id for the logged-in user's plan
                    int trainerId;
                    using (SqlCommand cmdGetTrainerId = new SqlCommand(query, conn))
                    {
                        // Add the plan_id parameter to the query
                        cmdGetTrainerId.Parameters.AddWithValue("@PlanID", Authentication.LoggedUser.PlanID);

                        // Execute the query and retrieve the trainer_id as an integer
                        trainerId = (int)cmdGetTrainerId.ExecuteScalar(); // Assumes plan_id exists
                    }

                    // SQL query to insert the feedback into the feedback table
                    query = "INSERT INTO feedback (member_id, trainer_id, message, date) VALUES (@MemberID, @TrainerID, @Message, @Date)";

                    // Insert the feedback message along with member and trainer details
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Add parameters for member_id, trainer_id, message, and date
                        cmd.Parameters.AddWithValue("@MemberID", Authentication.LoggedUser.ID);
                        cmd.Parameters.AddWithValue("@TrainerID", trainerId);
                        cmd.Parameters.AddWithValue("@Message", message);
                        cmd.Parameters.AddWithValue("@Date", DateTime.Now);

                        // Execute the query to save the feedback
                        cmd.ExecuteNonQuery();
                    }
                }

                // Show a dialog indicating the feedback has been successfully received
                FeedbackReceived feedbackReceived = new FeedbackReceived();
                feedbackReceived.ShowDialog();
            }

            catch (SqlException)
            {
                // Display an error dialog if a database error occurs
                new ApplicationError(ErrorType.DatabaseError).ShowDialog();
            }
        }
    }
}
