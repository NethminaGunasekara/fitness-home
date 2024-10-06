using System;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography;
using fitness_home.Utils.Types;
using fitness_home.Utils.Types.User;
using fitness_home.Utils;
using fitness_home.Views.Dashboard;
using System.Windows.Forms;

namespace fitness_home.Services
{
    /// <summary>
    /// Singleton class for managing authentication operations, including login and redirecting users to their dashboard.
    /// </summary>
    internal class Authentication
    {
        // Stores logged user info
        public static IUser LoggedUser;

        // Singleton instance of the class
        private static Authentication instance;

        // Lock object used to ensure thread safety
        private static readonly object _lock = new object();

        // Connection string to the database
        public readonly string ConnectionString;

        /// <summary>
        /// Private constructor to prevent direct instantiation.
        /// </summary>
        private Authentication()
        {
            // Build the connection string when an instance of the class is being created
            ConnectionString = GetConnectionString();
        }

        /// <summary>
        /// Builds and returns the SQL connection string from the configuration settings.
        /// </summary>
        /// <returns>SQL connection string</returns>
        private string GetConnectionString()
        {
            // Fetch database connection details from configuration
            string dbHost = ConfigurationManager.AppSettings["DB_HOST"];
            string dbUser = ConfigurationManager.AppSettings["DB_USER"];
            string dbPass = ConfigurationManager.AppSettings["DB_PASS"];
            string dbName = ConfigurationManager.AppSettings["DB_NAME"];

            // Build the SQL connection string
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = dbHost;
            builder.UserID = dbUser;
            builder.Password = dbPass;
            builder.InitialCatalog = dbName;

            return builder.ConnectionString;
        }

        /// <summary>
        /// Checks if a connection to the database can be established.
        /// </summary>
        /// <returns>True if the connection is successful, otherwise false</returns>
        public bool CheckConnection()
        {
            // Open a new SQL connection
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    return true;
                }
                catch (SqlException)
                {
                    // Return false if the connection fails
                    return false;
                }
            }
        }

        /// <summary>
        /// Gets the singleton instance of the Authentication class.
        /// Ensures thread safety with double-check locking.
        /// </summary>
        public static Authentication Instance
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
                            instance = new Authentication();
                        }
                    }
                }
                return instance;
            }
        }

        /// <summary>
        /// Provides login functionality.
        /// </summary>
        /// <param name="email">Email entered by the user</param>
        /// <param name="password">Password entered by the user</param>
        /// <returns>True if login is successful, otherwise false</returns>
        public LoginStatus Login(string email, string password)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    // SQL query to fetch the user details
                    string query = "SELECT id, role, password FROM account WHERE email = @Email";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Email", email);

                    conn.Open();

                    // Execute query and read the results
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // If no record is found, return InvalidEmail
                        if (!reader.HasRows)
                        {
                            return LoginStatus.InvalidEmail;
                        }

                        // Move to the first row
                        reader.Read();

                        // Get the id, role, and password from the result
                        int id = Convert.ToInt32(reader["id"]);
                        int role = Convert.ToInt32(reader["role"]);
                        string storedHash = reader["password"].ToString();

                        // Verify the hased version of entered password against the stored hash
                        bool isPasswordValid = VerifyPassword(password, storedHash);

                        // If login is successful
                        if (isPasswordValid)
                        {
                            // Assign the user with role based on the database result
                            if (role == 0)
                                LoggedUser = new Admin(id);
                            else if (role == 1)
                                LoggedUser = new Trainer(id);
                            else
                                LoggedUser = new Member(id);

                            // Store login details upon a successful login
                            string storedEmail = ConfigurationManager.AppSettings["USER_EMAIL"];
                            string storedPassword = ConfigurationManager.AppSettings["USER_PASSWORD"];

                            // Update configuration if necessary
                            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                            if (!storedEmail.Equals(email)) config.AppSettings.Settings["USER_EMAIL"].Value = email;
                            if (!storedPassword.Equals(password)) config.AppSettings.Settings["USER_PASSWORD"].Value = password;

                            config.Save(ConfigurationSaveMode.Modified);
                        }

                        return isPasswordValid ? LoginStatus.Success : LoginStatus.InvalidPassword;
                    }
                }
            }
            catch (SqlException err)
            {
                // Log the error for debugging purposes
                Console.WriteLine($"DB Connection Error: {err.Data}");

                // Return login status indicating a database error
                return LoginStatus.DatabaseError;
            }
        }

        /// <summary>
        /// Redirects the user to their dashboard after a successful login.
        /// </summary>
        /// <param name="currentForm">Form from which the user is redirected</param>
        public void ShowDashboard(Form currentForm)
        {
            // Redirect to the Member Dashboard if the logged-in user is a member
            if (LoggedUser is Member)
            {
                // Show the Member Dashboard
                MemberDashboard MemberDashboard = FormProvider.MemberDashboard ?? (FormProvider.MemberDashboard = new MemberDashboard());

                Helpers.ShowForm(
                    targetForm: MemberDashboard,
                    currentForm: currentForm,
                    setSize: false,
                    setPosition: false);
            }
        }

        /// <summary>
        /// Hashes the given password using the SHA-256 algorithm.
        /// </summary>
        /// <param name="password">Plain-text password</param>
        /// <returns>SHA-256 hash of the password as a string</returns>
        public string HashPassword(string password)
        {
            // Create a SHA-256 hash object
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Convert password to a byte array and compute its hash
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert byte array to a hex string
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        /// <summary>
        /// Verifies if the entered password matches the stored hash.
        /// </summary>
        /// <param name="enteredPassword">Password entered by the user</param>
        /// <param name="storedHash">SHA-256 hashed password from the database</param>
        /// <returns>True if the entered password matches the stored hash</returns>
        public bool VerifyPassword(string enteredPassword, string storedHash)
        {
            // Hash the entered password and compare it to the stored hash
            string enteredPasswordHash = HashPassword(enteredPassword);

            return enteredPasswordHash == storedHash;
        }
    }
}
