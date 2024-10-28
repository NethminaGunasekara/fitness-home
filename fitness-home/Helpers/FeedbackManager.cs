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
using System.Collections.Generic;

namespace fitness_home.Helpers
{
    internal class FeedbackManager
    {
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

        /// <summary>
        /// Retrieves all feedback associated with the specified trainerId.
        /// </summary>
        /// <param name="trainerId">The ID of the trainer to retrieve feedback for.</param>
        /// <returns>A list of Feedback objects with member name and feedback message.</returns>
        public List<Feedback> GetFeedbackForTrainer(int trainerId)
        {
            List<Feedback> feedbackList = new List<Feedback>();

            using (SqlConnection conn = new SqlConnection(Authentication.Instance.ConnectionString))
            {
                conn.Open();

                // Step 1: Retrieve all feedback entries for the specified trainerId
                string feedbackQuery = "SELECT member_id, message FROM feedback WHERE trainer_id = @TrainerId ORDER BY date DESC";

                using (SqlCommand feedbackCmd = new SqlCommand(feedbackQuery, conn))
                {
                    feedbackCmd.Parameters.AddWithValue("@TrainerId", trainerId);

                    using (SqlDataReader feedbackReader = feedbackCmd.ExecuteReader())
                    {
                        // List to store feedback data before retrieving member details
                        List<(int memberId, string message)> feedbackData = new List<(int, string)>();

                        while (feedbackReader.Read())
                        {
                            int memberId = feedbackReader.GetInt32(0);
                            string message = feedbackReader.GetString(1);
                            feedbackData.Add((memberId, message));
                        }

                        feedbackReader.Close();

                        // Step 2: Retrieve member details for each unique memberId
                        foreach (var (memberId, message) in feedbackData)
                        {
                            string memberQuery = "SELECT first_name, last_name FROM member WHERE member_id = @MemberId";

                            using (SqlCommand memberCmd = new SqlCommand(memberQuery, conn))
                            {
                                memberCmd.Parameters.AddWithValue("@MemberId", memberId);

                                using (SqlDataReader memberReader = memberCmd.ExecuteReader())
                                {
                                    if (memberReader.Read())
                                    {
                                        string firstName = memberReader.GetString(0);
                                        string lastName = memberReader.GetString(1);

                                        // Format the member name to look like: Chanuka Dilhara (M001)
                                        string paddedMemberId = $"M{memberId.ToString().PadLeft(3, '0')}";
                                        string memberName = $"{firstName} {lastName} ({paddedMemberId})";

                                        // Create a new Feedback object and add it to the list
                                        Feedback feedback = new Feedback(memberName, message);
                                        feedbackList.Add(feedback);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return feedbackList;
        }
    }

    // Data structure to represent a feedback
    class Feedback
    {
        public string Member;
        public string Message;

        public Feedback(string member, string message)
        {
            Member = member;
            Message = message;
        }
    }
}
