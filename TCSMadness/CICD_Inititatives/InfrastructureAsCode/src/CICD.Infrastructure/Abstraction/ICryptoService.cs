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

    public interface IApplicationValidator : IValidator<Application>
    {
    }

    public interface IApplicationRepository : IRepository<Application>
    {
    }
    public interface ITokenRepository : IRepository<Token>
    {
    }

    public interface IUserRepository : IRepository<User>
    {
    }

    public interface IUserValidator : IValidator<User>
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
        bool ValidateToken(string token);

        void Register(User v);

        void Register(Application v);

        void UnRegister(int id);

        void UnRegister(Application v);

        void UnRegister(User v);
    }
}