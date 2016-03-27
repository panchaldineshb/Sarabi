using System.Data.Entity;

using TemplateApp.Data.Models;

namespace TemplateApp.Data.Context
{
    public class SarabiContext : DbContext
    {
        //
        // Static Constructor
        static SarabiContext()
        {
            // Available Database Initializers
            // CreateDatabaseIfNotExists
            // DropCreateDatabaseWhenModelChanges
            // DropCreateDatabaseAlways
            Database.SetInitializer(new DropCreateDatabaseAlways<SarabiContext>());
        }

        //
        // Constructor
        public SarabiContext()
        {
            // Enable proxy creation.
            Configuration.ProxyCreationEnabled = true;

            // Enable lazy loading.
            Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<Company> Companies { get; set; }

        public DbSet<CostCenter> CostCenters { get; set; }

        public DbSet<Currency> Currencies { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Division> Divisions { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Permission> Permissions { get; set; }

        public DbSet<PersonalInfo> PersonalInfo { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<SecurityInfo> SecurityInfo { get; set; }

        public DbSet<Subsidiary> Subsidiaries { get; set; }

        public DbSet<User> Users { get; set; }
    }
}