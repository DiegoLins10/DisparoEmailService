using EmailDominios.Models;
using Microsoft.EntityFrameworkCore;

namespace EmailDominios.Data
{
    public class EmailContext : DbContext
    {
        private string _connectionString;

        public EmailContext(DbContextOptions options) : base(options)
        {
        }

        public EmailContext()
        {
        }

        public EmailContext(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public DbSet<EnviarEmail> EnviarEmail { get; set; }
    }
}
