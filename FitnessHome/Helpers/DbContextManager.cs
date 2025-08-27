using FitnessHome.Data;

namespace FitnessHome.Helpers
{
    public sealed class DbContextManager
    {
        private static readonly DbContextManager _instance = new DbContextManager(); // Singleton instance
        private FitnessHomeContext _context;

        private DbContextManager() { }

        public static DbContextManager Instance
        {
            get { return _instance; }
        }

        /// <summary>
        /// Initializes the DbContext with the provided options.
        /// </summary>
        public void Initialize()
        {
            
        }

        /// <summary>
        /// Gets the single DbContext instance.
        /// </summary>
        public FitnessHomeContext GetContext()
        {
            if (_context == null)
            {
                throw new InvalidOperationException("DbContext has not been initialized. Call DbContextManager.Instance.Initialize() first.");
            }
            return _context;
        }
    }
}
