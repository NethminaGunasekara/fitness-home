using fitness_home.Utils.Types;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace fitness_home.Services.Actions
{
    /// <summary>
    /// Provides methods for retrieving and editing membership plan information.
    /// </summary>
    internal class MembershipInfo
    {
        /// <summary>
        /// Retrieves all membership plans from the database.
        /// </summary>
        /// <returns>A list of MembershipPlan objects containing all membership plans.</returns>
        public static List<MembershipPlan> GetAllPlans()
        {
            List<MembershipPlan> plans = new List<MembershipPlan>(); // Initialize a list to hold the membership plans

            // Initialize a SQL connection using the connection string from "Authentication" class
            using (SqlConnection conn = new SqlConnection(Authentication.Instance.ConnectionString))
            {
                conn.Open(); // Open the database connection

                // Query to retrieve all plans from the "plan" table
                string query = "SELECT plan_id, trainer_id, plan_name, monthly_fee FROM membership_plan";

                // Step 1: Retrieve all membership plans
                using (SqlCommand cmd = new SqlCommand(query, conn)) // Prepare the SQL command
                {
                    using (SqlDataReader reader = cmd.ExecuteReader()) // Execute the query and obtain a "SqlDataReader" for reading the results
                    {
                        // Read each row from the query result
                        while (reader.Read())
                        {
                            int planId = reader.GetInt32(0); // Retrieve plan_id (first column)
                            int trainerId = reader.GetInt32(1); // Retrieve trainer_id (second column)
                            string planName = reader.GetString(2); // Retrieve plan_name (third column)
                            decimal monthlyFee = reader.GetDecimal(3); // Retrieve monthly_fee (fourth column)

                            // Add the plan details to the "plans" list
                            plans.Add(new MembershipPlan(planId, trainerId, planName, monthlyFee));
                        }
                    }
                }

                // Step 2: Retrieve benefits for each plan
                foreach (var plan in plans) // Loop through each plan in the list
                {
                    // Fetch the benefits for each plan and assign them to the "benefits" property
                    plan.Benefits = GetBenefitsForPlan(conn, plan.PlanId);
                }
            }

            return plans; // Return the list of membership plans we prepared
        }

        /// <summary>
        /// Retrieves the list of benefits for a given plan from the database.
        /// </summary>
        /// <param name="conn">SQL connection used to execute the previous query.</param>
        /// <param name="planId">ID of the plan to retrieve benefits.</param>
        /// <returns>A list of benefits associated with the specified plan.</returns>
        private static List<string> GetBenefitsForPlan(SqlConnection conn, int planId)
        {
            List<string> benefits = new List<string>(); // Initialize a list to hold the benefits

            // Query to retrieve the benefits associated with a particular plan from the "plan_benefits" table
            string query = "SELECT benefit FROM plan_benefits WHERE plan_id = @planId";

            using (SqlCommand cmd = new SqlCommand(query, conn)) // Prepare the SQL command
            {
                // Add "planId" parameter to the query to retrieve benefits for the correct plan
                cmd.Parameters.AddWithValue("@planId", planId);

                using (SqlDataReader reader = cmd.ExecuteReader()) // Execute the query and obtain a "SqlDataReader" for reading the results
                {
                    // Read each benefit associated with the "planId"
                    while (reader.Read())
                    {
                        // Add the benefit to "benefits" list
                        benefits.Add(reader.GetString(0));
                    }
                }
            }

            return benefits; // Return the list of benefits
        }
    }
}
