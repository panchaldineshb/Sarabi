using CICD.Infrastructure.Abstraction;
using CICD.Infrastructure.Domain;

namespace CICD.Infrastructure.Implementation
{
    public class DeploymentsService : IDeploymentsService
    {
        private IApplicationRepository _applicationRepository;
        private IUserRepository _userRepository;

        public DeploymentsService(IUserRepository userRepository, IApplicationRepository applicationRepository)
        {
            this._applicationRepository = applicationRepository;
            this._userRepository = userRepository;
        }

        public void BoardApplication(Application v)
        {
        }

        public void StoreBuildArtifacts(Build v)
        {
        }

        public void Scan(Build v)
        {
        }

        public void Deploy(Build v)
        {
        }
    }
}