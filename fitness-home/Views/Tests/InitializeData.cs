using fitness_home.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace fitness_home.Views.Tests
{
    public partial class InitializeData : Form
    {
        public InitializeData()
        {
            InitializeComponent();
        }

        private void button_add_plans_Click(object sender, EventArgs e)
        {
            // Define plan names and associated benefits
            var plans = new Dictionary<string, List<string>>
            {
                {"Individual", new List<string> { "Access to cardio and weight training areas", "Group fitness classes included", "Locker room access", "Personalized fitness assessment", "Including diet plans", "Monthly progress report" }},
                {"Couple", new List<string> { "Access to 2 people", "Access to cardio and weight training areas", "Group fitness classes included", "Locker room access", "On-time supervision", "Personalized fitness assessment for each party", "Including diet plans", "Monthly progress report" }},
                {"Family", new List<string> { "Access to 3-5 people", "Access to cardio and weight training areas", "Group fitness classes included", "Locker room access", "On-time supervision", "Personalized fitness assessment for each party", "Including diet plans", "Monthly progress report", "Parking lot accessibility" }},
                {"Basic", new List<string> { "Access to cardio and weight training areas", "Group fitness classes included", "Locker room access", "Personalized fitness assessment", "Including diet plans (exceptional)", "Monthly progress report" }},
                {"Premium", new List<string> { "Access to cardio and weight training areas", "Group fitness classes included", "Locker room access", "Personalized fitness assessment", "Including diet plans (exceptional)", "Monthly progress report", "Access to sauna and steam room", "Towel service", "Priority booking for group fitness classes" }},
                {"VIP", new List<string> { "Access to cardio and weight training areas", "Group fitness classes included", "Locker room access", "Personalized fitness assessment", "Including diet plans (exceptional)", "Monthly progress report", "Access to sauna and steam room", "Towel service", "Priority booking for group fitness classes", "Unlimited guest passes", "Complimentary personal training session", "Discount on supplements & gym equipment (straps/gloves/belt,…etc.)" }}
            };

            using (SqlConnection conn = new SqlConnection(Authentication.Instance.ConnectionString))
            {
                conn.Open();
                foreach (var plan in plans)
                {
                    // Generate a random monthly fee between 3200.00 and 16000.00
                    decimal monthlyFee = new Random().Next(3200, 16001);

                    // Insert the membership plan into the membership_plan table
                    string insertPlanQuery = "INSERT INTO membership_plan (trainer_id, plan_name, monthly_fee) OUTPUT INSERTED.plan_id VALUES (@trainer_id, @plan_name, @monthly_fee)";
                    SqlCommand insertPlanCmd = new SqlCommand(insertPlanQuery, conn);
                    insertPlanCmd.Parameters.AddWithValue("@trainer_id", 1);
                    insertPlanCmd.Parameters.AddWithValue("@plan_name", plan.Key);
                    insertPlanCmd.Parameters.AddWithValue("@monthly_fee", monthlyFee);

                    // Execute the insert command and retrieve the new plan_id
                    int planId = (int)insertPlanCmd.ExecuteScalar();

                    // Insert each benefit into the plan_benefits table
                    foreach (string benefit in plan.Value)
                    {
                        string insertBenefitQuery = "INSERT INTO plan_benefits (plan_id, benefit) VALUES (@plan_id, @benefit)";
                        SqlCommand insertBenefitCmd = new SqlCommand(insertBenefitQuery, conn);
                        insertBenefitCmd.Parameters.AddWithValue("@plan_id", planId);
                        insertBenefitCmd.Parameters.AddWithValue("@benefit", benefit);
                        insertBenefitCmd.ExecuteNonQuery();
                    }
                }
                conn.Close();
            }

            MessageBox.Show("Membership plans and benefits have been added successfully!");
        }
    }
}
