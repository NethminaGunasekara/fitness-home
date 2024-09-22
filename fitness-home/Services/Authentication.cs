using System;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography;
using fitness_home.Services.Types;
using fitness_home.Utils.Types;
using fitness_home.Utils.Types.User;
using fitness_home.Utils;
using fitness_home.Views.Dashboard;
using System.Windows.Forms;

namespace fitness_home.Services
{
    internal class Authentication
    {
        public static IUser LoggedUser;
        private static Authentication instance;
        private static readonly object _lock = new object();
        private readonly string ConnectionString;

        private Authentication()
        {
            string dbHost = ConfigurationManager.AppSettings["DB_HOST"];
            string dbUser = ConfigurationManager.AppSettings["DB_USER"];
            string dbPass = ConfigurationManager.AppSettings["DB_PASS"];
            string dbName = ConfigurationManager.AppSettings["DB_NAME"];

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = dbHost;
            builder.UserID = dbUser;
            builder.Password = dbPass;
            builder.InitialCatalog = dbName;


            this.ConnectionString = builder.ConnectionString;
        }
        public static Authentication Instance
        {
            get
            {
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
        /// Provides login functionality
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
                    string query = "SELECT id, role, password FROM account WHERE email = @Email";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Email", email);

                    conn.Open();

                    // Execute the query and read the results
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // If no record is found, return InvalidEmail
                        if (!reader.HasRows)
                        {
                            return LoginStatus.InvalidEmail;
                        }

                        // Move to the first row
                        reader.Read();

                        // Get the id, role and password from the result
                        int id = Convert.ToInt32(reader["id"]);
                        int role = Convert.ToInt32(reader["role"]);
                        string storedHash = reader["password"].ToString();

                        // Verify the entered password with the stored hash
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
                // Log the error (for debugging purposes)
                Console.WriteLine($"DB Connection Error: {err.Data}");


                // Return login status indicating a database error
                return LoginStatus.DatabaseError;
            }
        }

        /// <summary>
        /// Redirects user to their dashboard after a successful login
        /// </summary>
        /// <param name="currentForm">Where the user is redirected from</param>
        public void ShowDashboard(Form currentForm)
        {
            // Show the Member Dashboard
            if (Authentication.LoggedUser is Member)
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
        /// Hash the password using SHA-256
        /// </summary>
        /// <param name="password">Password as a plain string</param>
        /// <returns></returns>
        public string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // password -> byte array -> string
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();

                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        /// <summary>
        /// Verify if the entered password matches the stored hash
        /// </summary>
        /// <param name="enteredPassword">Password entered by the user</param>
        /// <param name="storedHash">Password hashed using SHA-256 from the database</param>
        /// <returns>`True` if the entered password matches the stored hash</returns>
        public bool VerifyPassword(string enteredPassword, string storedHash)
        {
            string enteredPasswordHash = HashPassword(enteredPassword);

            return enteredPasswordHash == storedHash;
        }
    }
}