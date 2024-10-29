// ----------------------------------------------------------------------------
// MembershipPlan.cs - Developed by Nethmina Gunasekara
// Repository: https://github.com/NethminaGunasekara/fitness-home
// 
// This class is responsible for retrieving, managing, and 
// editing membership plan information. It also handles purchasing membership 
// plans within the Fitness Home gym management system.
// 
// This code is part of the Fitness Home project.
// ----------------------------------------------------------------------------
using fitness_home.Services;
using fitness_home.Utils.Types;
using fitness_home.Views.Messages;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace fitness_home.Helpers
{
    public class MembershipPlan
    {
        // Singleton instance of the class
        private static MembershipPlan instance;

        // Lock object used to ensure thread safety
        private static readonly object _lock = new object();

        // Private constructor to prevent direct instantiation
        private MembershipPlan() { }

        // Gets the singleton instance of the MembershipPlan class.
        // This ensures thread safety with double-check locking.
        // 
        // Read more about the Singleton Design Pattern (Java):
        // https://www.digitalocean.com/community/tutorials/java-singleton-design-pattern-best-practices-examples
        public static MembershipPlan Instance
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
                            instance = new MembershipPlan();
                        }
                    }
                }
                return instance;
            }
        }

        // Retrieves all membership plans from the membership_plan table
        // and returns tem as a List of plans as instances of "MembershipPlanDetails"
        public List<MembershipPlanDetails> GetAllPlans()
        {
            List<MembershipPlanDetails> plans = new List<MembershipPlanDetails>();

            try
            {
                // Create a connection by reusing the connection string from the Authentication class
                using (SqlConnection conn = new SqlConnection(Authentication.Instance.ConnectionString))
                {
                    conn.Open();

                    // Query to retrieve all membership plans
                    string query = "SELECT plan_id, trainer_id, plan_name, monthly_fee FROM membership_plan";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Read each row and add it to the list of plans
                            while (reader.Read())
                            {
                                MembershipPlanDetails plan = new MembershipPlanDetails
                                {
                                    // Retrieve the value of "plan_id" column
                                    PlanId = reader.GetInt32(0),
                                    // Retrieve the value of "trainer_id" column
                                    TrainerId = reader.GetInt32(1),
                                    // Retrieve the value of "plan_name" column
                                    PlanName = reader.GetString(2),
                                    // Retrieve the value of "monthly_fee" column
                                    MonthlyFee = reader.GetDecimal(3)
                                };

                                plans.Add(plan);
                            }
                        }
                    }


                    // Fetch the benefits for each plan and assign them to the "benefits" property
                    foreach (MembershipPlanDetails plan in plans)
                    {
                        plan.Benefits = GetBenefitsForPlan(conn, plan.PlanId);
                    }
                }
            }

            catch (SqlException)
            {
                // Handle database connection errors
                new ApplicationError(ErrorType.DatabaseError).ShowDialog();
            }

            return plans;
        }

        // Retrieves the list of benefits for a given plan from the database.
        public List<string> GetBenefitsForPlan(SqlConnection conn, int planId)
        {
            List<string> benefits = new List<string>(); // Initialize a list to hold the benefits

            // Query to retrieve the list of benefits associated with a plan
            string query = "SELECT benefit FROM plan_benefits WHERE plan_id = @planId";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // Add plan_id as a parameter to retrieve benefits for the correct plan
                cmd.Parameters.AddWithValue("@planId", planId);

                // Execute the query and obtain a "SqlDataReader" for reading the results
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Add each benefit to the benefits list
                        benefits.Add(reader.GetString(0));
                    }
                }
            }

            return benefits; // Return the list of benefits
        }

        // Assign a new membership plan to the user
        public void Assign(int planId)
        {
            // Change the membership plan for the user
            Authentication.LoggedUser.PlanID = planId;

            // Set the plan expiry
            Authentication.LoggedUser.PlanExpiry = DateTime.Now.AddMonths(1);

            // Create a connection to the database as a connection is required by the AssignMemberToGroup method
            using (SqlConnection conn = new SqlConnection(Authentication.Instance.ConnectionString))
            {
                conn.Open();

                // Remove the user from existing plan's group (if he's already a member)
                string query = "DELETE FROM member_group WHERE member_id = @MemberID AND plan_id = @PlanID";

                try
                {
                    using (SqlCommand cmdDelete = new SqlCommand(query, conn))
                    {
                        cmdDelete.Parameters.AddWithValue("@MemberID", Authentication.LoggedUser.ID);
                        cmdDelete.Parameters.AddWithValue("@PlanID", planId);
                        cmdDelete.ExecuteNonQuery();
                    }

                    // Assign the member to a new group based on the planId
                    Register.AssignMemberToGroup(conn, Authentication.LoggedUser.ID, planId);
                }

                // Handle any potential database errors
                catch (SqlException)
                {
                    new ApplicationError(ErrorType.DatabaseError).ShowDialog();
                }
            }
        }
     
        // Retrieves the details of a specific membership plan based on its plan_id.
        // If no matching plan is found, it returns null.
        public MembershipPlanDetails GetPlanById(int planId)
        {
            MembershipPlanDetails plan = null;

            try
            {
                // Create a connection by reusing the connection string from the Authentication class
                using (SqlConnection conn = new SqlConnection(Authentication.Instance.ConnectionString))
                {
                    conn.Open();

                    // Query to retrieve the plan details by plan_id
                    string query = "SELECT plan_id, trainer_id, plan_name, monthly_fee FROM membership_plan WHERE plan_id = @planId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Set the value of @planId parameter to the provided planId
                        cmd.Parameters.AddWithValue("@planId", planId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Create a new MembershipPlanDetails instance
                                plan = new MembershipPlanDetails
                                {
                                    // Retrieve the value of "plan_id" column
                                    PlanId = reader.GetInt32(0),
                                    // Retrieve the value of "trainer_id" column
                                    TrainerId = reader.GetInt32(1),
                                    // Retrieve the value of "plan_name" column
                                    PlanName = reader.GetString(2),
                                    // Retrieve the value of "monthly_fee" column
                                    MonthlyFee = reader.GetDecimal(3)
                                };
                            }
                        }

                        // Fetch and assign the list of benefits for the current plan
                        plan.Benefits = GetBenefitsForPlan(conn, plan.PlanId);
                    }
                }
            }
            catch (SqlException)
            {
                // Handle database connection errors
                new ApplicationError(ErrorType.DatabaseError).ShowDialog();
            }

            return plan;
        }

        /// <summary>
        /// Retrieves the plan name of a given plan ID.
        /// </summary>
        /// <param name="planId">ID of the plan to retrieve the name of.</param>
        /// <returns>The name of the plan as a string, or null if not found.</returns>
        public string GetPlanNameById(int planId)
        {
            string planName = null;

            // Query to retrieve the plan name from the "membership_plan" table
            string query = "SELECT plan_name FROM membership_plan WHERE plan_id = @planId";

            try
            {
                using (SqlConnection conn = new SqlConnection(Authentication.Instance.ConnectionString)) // Use the same connection string
                {
                    conn.Open(); // Open the connection

                    using (SqlCommand cmd = new SqlCommand(query, conn)) // Prepare the SQL command
                    {
                        // Add the "planId" parameter
                        cmd.Parameters.AddWithValue("@planId", planId);

                        using (SqlDataReader reader = cmd.ExecuteReader()) // Execute the query
                        {
                            if (reader.Read()) // If a result is found
                            {
                                planName = reader.GetString(0); // Assign the plan name to the variable
                            }
                        }
                    }
                }
            }

            // Handle database connection errors
            catch (SqlException e)
            {
                new ApplicationError(errorType: ErrorType.DatabaseError).ShowDialog();

                Console.WriteLine($"DB Error: {e.Message}");
            }

            return planName; // Return the plan name or null if not found
        }
    }
}
