using fitness_home.Services;
using fitness_home.Utils.Types.UserTypes;
using fitness_home.Views.Messages;
using System;
using System.Data.SqlClient;

namespace fitness_home.Utils.Types
{
    internal class AssessmentsForMember
    {
        // Member id to retrieve values for
        private int MemberId;

        // Fields to store retrieved information about member
        private short _MemberHeight;
        private short _MemberWeight;
        private ActivityLevel _ActivityLevel = ActivityLevel.NotSpecified;
        private short _CalorieGoal;

        public AssessmentsForMember(int memberId) {
            // Initialize the MemberId field using the parameter value
            MemberId = memberId;

            // Initialize the field used to store member information (MemberHeight, MemberWeight, ActivityLevel, and CalorieGoal)
            InitializeFields();
        }

        // Get and set the member's height property
        public short MemberHeight
        {
            get { return _MemberHeight; }

            set
            {
                if (_MemberHeight != value)
                {
                    _MemberHeight = value; // Update the value of _MemberHeight field
                }
            }
        }

        // Get and set the member's weight property
        public short MemberWeight
        {
            get { return _MemberWeight; }

            set
            {
                if (_MemberWeight != value)
                {
                    _MemberWeight = value; // Update the value of _MemberWeight field
                }
            }
        }

        // Get and set the member's activity level property
        public ActivityLevel ActivityLevel
        {
            get { return _ActivityLevel; }

            set
            {
                if (_ActivityLevel != value)
                {
                    _ActivityLevel = value; // Update the value of _ActivityLevel field
                }
            }
        }

        // Get and set the member's calorie goal property
        public short CalorieGoal
        {
            get { return _CalorieGoal; }

            set
            {
                if (_CalorieGoal != value)
                {
                    _CalorieGoal = value; // Update the value of _CalorieGoal field
                }
            }
        }

        // Update or create a set of assessments for a member
        public static void Update(int memberId, int height, int weight, string activityLevel, int calorieGoal)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Authentication.Instance.ConnectionString))
                {
                    conn.Open();

                    // Step 1: Delete any existing records for the given member ID
                    string deleteQuery = "DELETE FROM assessments WHERE member_id = @MemberId";
                    using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn))
                    {
                        deleteCmd.Parameters.AddWithValue("@MemberId", memberId);
                        deleteCmd.ExecuteNonQuery();
                    }

                    // Step 2: Insert the new record
                    string insertQuery = "INSERT INTO assessments (member_id, height, weight, activity_level, calorie_goal) VALUES (@MemberId, @Height, @Weight, @ActivityLevel, @CalorieGoal)";

                    using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@MemberId", memberId);
                        insertCmd.Parameters.AddWithValue("@Height", height);
                        insertCmd.Parameters.AddWithValue("@Weight", weight);
                        insertCmd.Parameters.AddWithValue("@ActivityLevel", activityLevel);
                        insertCmd.Parameters.AddWithValue("@CalorieGoal", calorieGoal);

                        insertCmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // Log the error for debugging purposes
                Console.WriteLine($"SQL Error: {sqlEx.Message}");

                // Display a database error message
                new ApplicationError(ErrorType.DatabaseError).ShowDialog();
            }
        }


            // Retrieves information about a member and initialize fields used to store member information
            private void InitializeFields()
        {
                // Create a new SQL connection using the connection string from the Authentication class
                using (SqlConnection conn = new SqlConnection(Authentication.Instance.ConnectionString))
                {
                    conn.Open();

                    // SQL query to retrieve height, weight, activity_level, and calorie_goal based on the member_id
                    string query = "SELECT height, weight, activity_level, calorie_goal FROM assessments WHERE member_id = @MemberId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MemberId", MemberId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Check if the query returned any results
                            if (reader.Read())
                            {
                                // Retrieve and store the 'MemberHeight' value from the first column (index 0)
                                _MemberHeight = reader.GetInt16(0);

                                // Retrieve and store the 'MemberWeight' value from the second column (index 1)
                                _MemberWeight = reader.GetInt16(1);

                                // Retrieve and store the 'activity_level' value from the third column (index 2)
                                _ActivityLevel = (ActivityLevel) Enum.Parse(typeof(ActivityLevel), reader.GetString(2));

                                // Retrieve and store the 'calorie_goal' value from the fourth column (index 3)
                                _CalorieGoal = reader.GetInt16(3);
                            }
                        }
                    }
                }
        }


        // Calculate the BMR based on the user's height, weight, age, and activity level
        public double CalculateBMR(short height, short weight, DateTime dateOfBirth, string activityFactor)
        {
            // Calculate the user's age
            int userAge = DateTime.Today.Year - dateOfBirth.Year;

            // BMR Formula (Mifflin-St Jeor Equation)
            double result = (Authentication.LoggedUser.Gender == Gender.Male) ?
                (10 * weight) + (6.25 * height) - (5 * userAge) + 5 :
                (10 * weight) + (6.25 * height) - (5 * userAge) - 161;

            // Return a BMR value based on the user's activity factor

            // TDEE (Total Daily Energy Expenditure) = BMR × Activity Factor

            // "Sedentary" (little to no exercise): BMR × 1.2
            if (activityFactor == ActivityLevel.Sedentary.ToString())
            {
                return result * 1.2;
            }

            // "LightlyActive" (1-3 days of exercise per week): BMR × 1.375
            else if (activityFactor == ActivityLevel.LightlyActive.ToString())
            {
                return result * 1.375;
            }

            // "ModeratelyActive" (3-5 days of exercise per week): BMR × 1.55
            else if (activityFactor == ActivityLevel.ModeratelyActive.ToString())
            {
                return result * 1.55;
            }

            // "VeryActive" (6-7 days of intense exercise per week): BMR × 1.725
            else if (activityFactor == ActivityLevel.VeryActive.ToString())
            {
                return result * 1.725;
            }

            // "SuperActive" (intense exercise twice a day): BMR × 1.9
            else
            {
                return result * 1.9;
            }
        }

        // Calculate the Body Fat Percentage (BFP)
        public double CalculateBFP(short height, short weight, DateTime dateOfBirth, Gender gender)
        {
            // Formula: BFP = 1.20 * BMI + 0.23 * Age - 10.8 * Gender - 5.4

            // Calculate the user's BMI
            double heightInMeters = height / 100.0;
            double bmi = weight / (heightInMeters * heightInMeters);

            // Get the user's age
            int userAge = DateTime.Today.Year - dateOfBirth.Year;

            // Set the gender factor (1 for male, 0 for female)
            int genderFactor = (gender == Gender.Male) ? 1 : 0;

            // Apply the BFP formula
            return (1.20 * bmi) + (0.23 * userAge) - (10.8 * genderFactor) - 5.4;
        }

        // Calculate the Lean Body Mass (LBM) percentage based on the user's weight and body fat percentage
        public double CalculateLBMPercentage(short weight, double bodyFatPercentage)
        {
            // Calculate Lean Body Mass (LBM)
            double lbm = weight * (1 - (bodyFatPercentage / 100));

            // Calculate LBM percentage: LBM% = (LBM / Weight) × 100
            return (lbm / weight) * 100; // Return the LBM percentage
        }
    }

    public enum ActivityLevel
    {
        Sedentary, // Sedentary (little to no exercise)
        LightlyActive, // Lightly Active (1-3 days of exercise/week)
        ModeratelyActive, // Moderately Active (3-5 days of exercise/week)
        VeryActive, // Very Active (6-7 days of exercise/week)
        SuperActive, // Super Active (intense exercise twice a day)
        NotSpecified, // If the activity level is not assigned
    }
}
