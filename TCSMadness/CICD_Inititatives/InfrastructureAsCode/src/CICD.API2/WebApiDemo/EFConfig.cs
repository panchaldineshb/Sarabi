using CICD.API2.Data;
using System.Data.Entity;

namespace CICD.API2
{
    public static class EFConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<AppDbContext>());
        }
    }
}