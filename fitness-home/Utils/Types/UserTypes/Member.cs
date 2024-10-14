using System;
using System.Data.SqlClient;
using fitness_home.Views.Messages;
using fitness_home.Services;

namespace fitness_home.Utils.Types.UserTypes
{
    internal class Member : User
    {
        public int ID { get; }
        public Role Role { get; }
        private string _FirstName;
        private string _LastName;
        private DateTime _DateOfBirth;
        private string _NIC;
        private Gender _Gender;
        private string _Email;
        private string _Phone;
        private string _Address;
        private string _EmergencyContactName;
        private string _EmergencyContactPhone;
        private int _PlanID;
        private DateTime _PlanExpiry;

        public Member(int id)
        {
            ID = id;
            Role = Role.Member;

            // Retrieve member data from the database
            RetrieveMemberData();
        }

        // Method to retrieve member data from the database based on the member ID
        private void RetrieveMemberData()
        {
            using (SqlConnection conn = new SqlConnection(Authentication.Instance.ConnectionString))
            {
                conn.Open();  // Open the connection

                // SQL query to select all relevant fields from the "member" table
                string query = @"SELECT first_name, last_name, dob, nic, gender, email, phone, address, ec_name, ec_phone, plan_id, plan_expiry 
                                FROM member 
                                WHERE member_id = @ID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", ID); // Add the ID parameter

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
                            _EmergencyContactName = reader["ec_name"].ToString();
                            _EmergencyContactPhone = reader["ec_phone"].ToString();
                            _PlanID = reader.GetInt32(reader.GetOrdinal("plan_id"));
                            _PlanExpiry = reader.GetDateTime(reader.GetOrdinal("plan_expiry"));
                        }
                        else
                        {
                            // Handle case where no member is found
                            throw new Exception("Member not found with the given ID.");
                        }
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
                    string query = $"UPDATE member SET {column} = @Value WHERE member_id = @ID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Value", value);
                        cmd.Parameters.AddWithValue("@ID", ID);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }


            // Catch SQL errors
            catch (SqlException sqlEx)
            {
                // Log the error for debugging purposes
                Console.WriteLine($"SQL Error: ${sqlEx.Message}");

                // Display database error message
                new ApplicationError(ErrorType.DatabaseError).ShowDialog();
            }

            // Catch any other errors
            catch (Exception e)
            {
                // Log the error for debugging purposes
                Console.WriteLine($"Unexpected Error: ${e.Message}");

                // Display application error message
                new ApplicationError(ErrorType.UnexpectedError).ShowDialog();
            }
        }

        public override string FirstName
        {
            get { return _FirstName; }
            set
            {
                _FirstName = value;
                UpdateDatabase("first_name", value);  // Update the "first_name" in the database
            }
        }

        public override string LastName
        {
            get { return _LastName; }
            set
            {
                _LastName = value;
                UpdateDatabase("last_name", value);  // Update the "last_name" in the database
            }
        }

        public override DateTime DateOfBirth
        {
            get { return _DateOfBirth; }
            set
            {
                _DateOfBirth = value;
                UpdateDatabase("dob", value);  // Update the "dob" in the database
            }
        }

        public override string NIC
        {
            get { return _NIC; }
            set
            {
                _NIC = value;
                UpdateDatabase("nic", value);  // Update the "nic" in the database
            }
        }

        public override Gender Gender
        {
            get { return _Gender; }
            set
            {
                _Gender = value;
                UpdateDatabase("gender", value.ToString());  // Update the "gender" in the database (stored as string)
            }
        }

        public override string Email
        {
            get { return _Email; }
            set
            {
                _Email = value;
                UpdateDatabase("email", value);  // Update the "email" in the database
            }
        }

        public override string Phone
        {
            get { return _Phone; }
            set
            {
                _Phone = value;
                UpdateDatabase("phone", value);  // Update the "phone" in the database
            }
        }

        public override string Address
        {
            get { return _Address; }
            set
            {
                _Address = value;
                UpdateDatabase("address", value);  // Update the "address" in the database
            }
        }

        public override string EmergencyContactName
        {
            get { return _EmergencyContactName; }
            set
            {
                _EmergencyContactName = value;
                UpdateDatabase("ec_name", value);  // Update the "ec_name" in the database
            }
        }

        public override string EmergencyContactPhone
        {
            get { return _EmergencyContactPhone; }
            set
            {
                _EmergencyContactPhone = value;
                UpdateDatabase("ec_phone", value);  // Update the "ec_phone" in the database
            }
        }

        public override int PlanID
        {
            get { return _PlanID; }
            set
            {
                _PlanID = value;
                UpdateDatabase("plan_id", value);  // Update the "plan_id" in the database
            }
        }

        public override DateTime PlanExpiry
        {
            get { return _PlanExpiry; }
            set
            {
                _PlanExpiry = value;
                UpdateDatabase("plan_expiry", value);  // Update the "plan_expiry" in the database
            }
        }
    }
}
