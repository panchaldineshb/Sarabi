using CICD.Infrastructure.Domain;
using System.Collections.Generic;

namespace CICD.Infrastructure.Abstraction
{
    public interface ICryptoService : IService
    {
        Video GetById(int id);

        IEnumerable<Video> GetAll();

        void Add(Video v);
    }

    public interface IApplicationRepository : IRepository<Application>
    {
    }

    public interface IUserRepository : IRepository<User>
    {
    }

    public interface IDeploymentsService : IService
    {
        void BoardApplication(Application v);

        void StoreBuildArtifacts(Build v);

        void Scan(Build v);

        void Deploy(Build v);
    }

    public interface IRegistrationsService : IService
    {
        void Register(User v);

        void Register(Application v);

        void UnRegister(int id);

        void UnRegister(Application v);

        void UnRegister(User v);
    }
}