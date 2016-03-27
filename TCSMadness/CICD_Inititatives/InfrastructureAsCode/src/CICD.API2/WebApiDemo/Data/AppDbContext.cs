using CICD.Infrastructure.Domain;
using System.Data.Entity;

namespace CICD.API2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("DefaultConnection")
        { }

        public DbSet<User> Users { get; set; }
    }
}