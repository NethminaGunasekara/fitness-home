using Newtonsoft.Json;

namespace FitnessHome.Helpers
{
    /// <summary>
    /// Represents the full application configuration.
    /// </summary>
    public class ConfigData
    {
        public DatabaseConfig Database { get; set; } = new DatabaseConfig();
    }

    /// <summary>
    /// Represents the database configuration structure.
    /// </summary>
    public class DatabaseConfig
    {
        public string Host { get; set; } = "";
        public int Port { get; set; } = 1433;
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public string Name { get; set; } = "";
    }

    /// <summary>
    /// Custom exception thrown when config reading fails.
    /// </summary>
    public class ConfigReadException : Exception
    {
        public ConfigReadException(string message, Exception? inner = null)
            : base(message, inner) { }
    }

    /// <summary>
    /// Provides methods for reading and writing application configuration stored in JSON.
    /// Uses Newtonsoft.Json for serialization.
    /// </summary>
    public class ConfigManager
    {
        private readonly string _filePath;

        /// <summary>
        /// Creates a new ConfigManager for the given config file path.
        /// </summary>
        /// <param name="filePath">The path to the config file (default: "appsettings.json").</param>
        public ConfigManager(string filePath = "appsettings.json")
        {
            _filePath = filePath;
        }

        /// <summary>
        /// Reads the configuration file and returns a <see cref="ConfigData"/> object.
        /// If the file cannot be read or parsed, the method deletes the file (if present),
        /// creates a fresh one with default values, and then throws a <see cref="ConfigReadException"/>.
        /// </summary>
        /// <returns>The configuration as a <see cref="ConfigData"/> object.</returns>
        /// <exception cref="ConfigReadException">Thrown when the config could not be read or parsed.</exception>
        public ConfigData ReadConfig()
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    var defaultConfig = new ConfigData();

                    WriteConfig(defaultConfig.Database.Host,
                                defaultConfig.Database.Port,
                                defaultConfig.Database.Username,
                                defaultConfig.Database.Password,
                                defaultConfig.Database.Name);

                    throw new ConfigReadException($"Config file not found. A new one has been created at {_filePath}.");
                }

                string json = File.ReadAllText(_filePath);
                var config = JsonConvert.DeserializeObject<ConfigData>(json);

                if (config == null)
                    throw new Exception("Config deserialized to null.");

                return config;
            }

            catch (Exception ex)
            {
                // Delete corrupt file if it exists
                if (File.Exists(_filePath))
                {
                    File.Delete(_filePath);
                }

                // Create new default file
                var defaultConfig = new ConfigData();
                WriteConfig(defaultConfig.Database.Host,
                            defaultConfig.Database.Port,
                            defaultConfig.Database.Username,
                            defaultConfig.Database.Password,
                            defaultConfig.Database.Name);

                throw new ConfigReadException("Failed to read config file. A new one has been created.", ex);
            }
        }

        /// <summary>
        /// Writes configuration data to the file.
        /// </summary>
        /// <param name="host">Database host.</param>
        /// <param name="port">Database port.</param>
        /// <param name="username">Database username.</param>
        /// <param name="password">Database password.</param>
        /// <param name="name">Database name.</param>
        public void WriteConfig(string host, int port, string username, string password, string name)
        {
            var config = new ConfigData
            {
                Database = new DatabaseConfig
                {
                    Host = host,
                    Port = port,
                    Username = username,
                    Password = password,
                    Name = name
                }
            };

            string json = JsonConvert.SerializeObject(config, Formatting.Indented);
            File.WriteAllText(_filePath, json);
        }
    }
}
