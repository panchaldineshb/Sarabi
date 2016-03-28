using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace CICD.Infrastructure.Database
{
    public class InfrastructureConfiguration : DbConfiguration
    {
        public InfrastructureConfiguration()
        {
            SetDefaultConnectionFactory(new LocalDbConnectionFactory("v11.0"));
        }
    }
}