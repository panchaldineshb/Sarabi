using System.Data.Entity;

namespace CICD.Initialize.Database
{
    internal class SampleContext : DbContext
    {
        // Not needed - EF will use DbConfiguration class automatically
        //static SampleContext()
        //{
        //    DbConfiguration.SetConfiguration(new SampleConfiguration());
        //}

        // Call base ctor passing database name or connection string name
        public SampleContext()
            : base("name=SampleContext") //base("HelloCodeFirst")
        {
            // Enable lazy loading
            Configuration.LazyLoadingEnabled = true;
        }

        // Entity sets
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        // Entity sets
        public DbSet<CICD.Infrastructure.Domain.Infrastructure> Infrastructures { get; set; }

        public DbSet<CICD.Infrastructure.Domain.LineOfBusiness> LineOfBusinesses { get; set; }

        public DbSet<CICD.Infrastructure.Domain.Capability> Capabilities { get; set; }

        public DbSet<CICD.Infrastructure.Domain.Release> Releases { get; set; }

        public DbSet<CICD.Infrastructure.Domain.Environment> Environments { get; set; }

        public DbSet<CICD.Infrastructure.Domain.Node> Nodes { get; set; }

        public DbSet<CICD.Infrastructure.Domain.Application> Applications { get; set; }

        public DbSet<CICD.Infrastructure.Domain.User> Users { get; set; }
    }
}