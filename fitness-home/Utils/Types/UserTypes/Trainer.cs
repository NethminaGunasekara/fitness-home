using System;
using System.Data.SqlClient;
using fitness_home.Views.Messages;
using fitness_home.Services;

namespace fitness_home.Utils.Types.UserTypes
{
    internal class Trainer : User
    {
        private readonly int _ID;
        public Role Role { get; }
        private string _FirstName;
        private string _LastName;
        private DateTime _DateOfBirth;
        private string _NIC;
        private Gender _Gender;
        private string _Email;
        private string _Phone;
        private string _Address;
        private decimal _Salary;
        private string _Specialization;
        private DateTime _HiredDate;
        private int _PlanID;

        public Trainer(int id)
        {
            _ID = id;
            Role = Role.Trainer;

            // Retrieve trainer data and plan data from the database
            RetrieveTrainerData();
            RetrievePlanID();
        }

        // Method to retrieve trainer data from the database based on the trainer ID
        private void RetrieveTrainerData()
        {
            using (SqlConnection conn = new SqlConnection(Authentication.Instance.ConnectionString))
            {
                conn.Open();  // Open the connection

                // SQL query to select all relevant fields from the "trainer" table
                string query = @"SELECT first_name, last_name, dob, nic, gender, email, phone, address, 
                                salary, specialization, hired_date 
                                FROM trainer 
                                WHERE trainer_id = @ID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", _ID); // Add the ID parameter

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) // If a matching record is found
                        {
                            // Initialize all fields from the database values
                            _FirstName = reader["first_name"].ToString();
                            _LastName = reader["last_name"].ToString();
                            _DateOfBirth = reader.GetDateTime(reader.GetOrdinal("dob"));
                            _NIC = reader["nic"].ToString();
                            _Gender = (Gender)Enum.Parse(typeof(Gender), reader["gender"].ToString());
                            _Email = reader["email"].ToString();
                            _Phone = reader["phone"].ToString();
                            _Address = reader["address"].ToString();
                            _Salary = reader.GetDecimal(reader.GetOrdinal("salary"));
                            _Specialization = reader["specialization"].ToString();
                            _HiredDate = reader.GetDateTime(reader.GetOrdinal("hired_date"));
                        }
                        else
                        {
                            // Handle case where no trainer is found
                            new ApplicationError(ErrorType.UnexpectedError).ShowDialog();
                        }
                    }
                }
            }
        }

        // Method to retrieve the PlanID associated with the trainer from the membership_plan table
        private void RetrievePlanID()
        {
            using (SqlConnection conn = new SqlConnection(Authentication.Instance.ConnectionString))
            {
                conn.Open(); // Open the connection

                string query = @"SELECT plan_id 
                                FROM membership_plan 
                                WHERE trainer_id = @ID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", _ID); // Add the ID parameter

                    var result = cmd.ExecuteScalar(); // Execute the query

                    if (result != null) // If a matching plan is found
                    {
                        _PlanID = Convert.ToInt32(result); // Store the plan ID
                    }

                    else
                    {
                        _PlanID = -1; // Indicate no plan found
                    }
                }
            }
        }

        // Method to update the database
        private void UpdateDatabase(string column, object value)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Authentication.Instance.ConnectionString))
                {
                    string query = $"UPDATE trainer SET {column} = @Value WHERE trainer_id = @ID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Value", value);
                        cmd.Parameters.AddWithValue("@ID", _ID);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            // Handle SQL errors
            catch (SqlException)
            {
                new ApplicationError(ErrorType.DatabaseError).ShowDialog();
            }
 
            // Catch any other errors
            catch (Exception)
            {
                new ApplicationError(ErrorType.UnexpectedError).ShowDialog();
            }
        }

        // Property for Trainer ID
        public override int ID => _ID;

        // Property for First Name
        public override string FirstName
        {
            get => _FirstName;
            set
            {
                _FirstName = value;
                UpdateDatabase("first_name", value);
            }
        }

        // Property for Last Name
        public override string LastName
        {
            get => _LastName;
            set
            {
                _LastName = value;
                UpdateDatabase("last_name", value);
            }
        }

        // Property for Date of Birth
        public override DateTime DateOfBirth
        {
            get => _DateOfBirth;
            set
            {
                _DateOfBirth = value;
                UpdateDatabase("dob", value);
            }
        }

        // Property for NIC
        public override string NIC
        {
            get => _NIC;
            set
            {
                _NIC = value;
                UpdateDatabase("nic", value);
            }
        }

        // Property for Gender
        public override Gender Gender
        {
            get => _Gender;
            set
            {
                _Gender = value;
                UpdateDatabase("gender", value.ToString());
            }
        }

        // Property for Email
        public override string Email
        {
            get => _Email;
            set
            {
                _Email = value;
                UpdateDatabase("email", value);
            }
        }

        // Property for Phone
        public override string Phone
        {
            get => _Phone;
            set
            {
                _Phone = value;
                UpdateDatabase("phone", value);
            }
        }

        // Property for Address
        public override string Address
        {
            get => _Address;
            set
            {
                _Address = value;
                UpdateDatabase("address", value);
            }
        }

        // Property for Salary
        public decimal Salary
        {
            get => _Salary;
            set
            {
                _Salary = value;
                UpdateDatabase("salary", value);
            }
        }

        // Property for Specialization
        public string Specialization
        {
            get => _Specialization;
            set
            {
                _Specialization = value;
                UpdateDatabase("specialization", value);
            }
        }

        // Property for Hired Date
        public DateTime HiredDate
        {
            get => _HiredDate;
            set
            {
                _HiredDate = value;
                UpdateDatabase("hired_date", value);
            }
        }

        // Special Setter for Plan ID
        public override int PlanID
        {
            get => _PlanID;
        }
    }
}
