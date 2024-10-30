using System;
using System.Data.SqlClient;
using fitness_home.Views.Messages;
using fitness_home.Services;

namespace fitness_home.Utils.Types.UserTypes
{
    internal class AdminData : User
    {
        private readonly int _ID;
        public Role Role { get; }
        private string _FirstName;
        private string _LastName;
        private string _NIC;
        private Gender _Gender;
        private string _Email;
        private string _Phone;

        public AdminData(int id)
        {
            _ID = id;
            Role = Role.Administrator;

            // Retrieve admin data and plan data from the database
            RetrieveAdminData();
        }

        // Format the admin id by adding a padding of 0s to fill 3 digits
        public static string FormatAdminId(int adminId)
        {
            return $"A{adminId.ToString().PadLeft(3, '0')}";
        }

        // Helper method to retrieve the admin's name using the admin_id
        public static string GetAdminNameById(int adminId)
        {
            string query = "SELECT first_name, last_name FROM admin WHERE admin_id = @AdminId";

            // Default name if the admin isn't found
            string adminName = "Unknown Admin";

            using (SqlConnection conn = new SqlConnection(Authentication.Instance.ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@AdminId", adminId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Check if a row is returned
                        if (reader.Read())
                        {
                            string firstName = reader.GetString(0);
                            string lastName = reader.GetString(1);

                            // Construct the full name
                            adminName = $"{firstName} {lastName}";
                        }
                    }
                }
            }

            return adminName;
        }

        // Method to retrieve admin data from the database based on the admin ID
        private void RetrieveAdminData()
        {
            using (SqlConnection conn = new SqlConnection(Authentication.Instance.ConnectionString))
            {
                conn.Open();  // Open the connection

                // SQL query to select all relevant fields from the "admin" table
                string query = @"SELECT first_name, last_name, nic, gender, email, phone
                                FROM admin 
                                WHERE admin_id = @ID";

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
                            _NIC = reader["nic"].ToString();
                            _Gender = (Gender)Enum.Parse(typeof(Gender), reader["gender"].ToString());
                            _Email = reader["email"].ToString();
                            _Phone = reader["phone"].ToString();
                        }
                        else
                        {
                            // Handle case where no admin is found
                            new ApplicationError(ErrorType.UnexpectedError).ShowDialog();
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
                    string query = $"UPDATE admin SET {column} = @Value WHERE admin_id = @ID";
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

        // Property for Admin ID
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
    }
}
