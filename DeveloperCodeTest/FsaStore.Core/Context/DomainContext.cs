using System.Data.Entity;

using FsaStore.Core.Models;

namespace FsaStore.Core.Context
{
    public class DomainContext : DbContext
    {
        //
        // Constructor
        public DomainContext()
        {
            // Available Database Initializers
            // CreateDatabaseIfNotExists
            // DropCreateDatabaseWhenModelChanges
            // DropCreateDatabaseAlways
            Database.SetInitializer(new CreateDatabaseIfNotExists<DomainContext>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<DomainContext>());

            // Enable proxy creation.
            Configuration.ProxyCreationEnabled = true;
        }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<PromotionCode> PromotionCodes { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<AccountProfile> Profiles { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        public DbSet<SystemSetting> SystemSettings { get; set; }
    }
}