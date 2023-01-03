using EmailDominios.Models;
using Microsoft.EntityFrameworkCore;

namespace EmailDominios.Data
{
    public class EmailContext : DbContext
    {
        private readonly string _connectionString;

        public EmailContext()
        {
        }

        //public EmailContext(string connectionString)
        //{
        //    this._connectionString = connectionString;
        //}

        public EmailContext(DbContextOptions options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(this._connectionString);
        //}

        public virtual DbSet<EnviarEmail> EnviarEmail { get; set; }
    }
}
