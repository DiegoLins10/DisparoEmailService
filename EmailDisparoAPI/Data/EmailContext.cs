using EmailDisparoAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmailDisparoAPI.Data
{
    public class EmailContext : DbContext
    {
        public EmailContext(DbContextOptions options) : base(options)
        {
        }

        public EmailContext()
        {
        }

        public DbSet<EnviarEmail> EnviarEmail { get; set; }
    }
}
