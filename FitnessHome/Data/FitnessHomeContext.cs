using FitnessHome.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessHome.Data
{
    public class FitnessHomeContext : DbContext
    {
        public FitnessHomeContext(DbContextOptions<FitnessHomeContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
