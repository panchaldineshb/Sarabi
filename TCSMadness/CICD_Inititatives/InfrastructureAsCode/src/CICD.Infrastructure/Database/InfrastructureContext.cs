using CICD.Infrastructure.Domain;
using System.Data.Entity;

namespace CICD.Infrastructure.Database
{
    public class InfrastructureContext : DbContext
    {
        // Not needed - EF will use DbConfiguration class automatically
        static InfrastructureContext()
        {
            DbConfiguration.SetConfiguration(new InfrastructureConfiguration());
        }

        // Call base ctor passing database name or connection string name
        public InfrastructureContext()
            : base("name=InfrastructureContext") //base("HelloCodeFirst")
        {
            // Enable lazy loading
            Configuration.LazyLoadingEnabled = true;
        }

        // Entity sets
        public DbSet<Domain.Infrastructure> Infrastructures { get; set; }

        public DbSet<LineOfBusiness> LineOfBusinesses { get; set; }

        public DbSet<Capability> Capabilities { get; set; }

        public DbSet<Release> Releases { get; set; }

        public DbSet<Environment> Environments { get; set; }

        public DbSet<Node> Nodes { get; set; }

        public DbSet<Application> Applications { get; set; }

        public DbSet<User> Users { get; set; }
    }
}