using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace CICD.Initialize.Database
{
    public class SampleConfiguration : DbConfiguration
    {
        public SampleConfiguration()
        {
            SetDefaultConnectionFactory(new LocalDbConnectionFactory("v11.0"));
        }
    }
}