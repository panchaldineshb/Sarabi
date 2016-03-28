using Autofac;
using Autofac.Integration.WebApi;
using CICD.Infrastructure.Abstraction;
using CICD.Infrastructure.Database;
using CICD.Infrastructure.Domain;
using CICD.Infrastructure.Implementation;
using System.Reflection;
using System.Web.Http;

namespace CICD.API2
{
    public class AutofacConfig
    {
        public static void RegisterResolvers()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<CryptoService>().As<ICryptoService>().As<IService>();
            builder.RegisterType<RegistrationsService>().As<IRegistrationsService>().As<IService>();

            builder.RegisterType<VideoRepository>().As<IRepository<Video>>();
            builder.RegisterType<UserRepository>().As<IUserRepository>().As<IRepository<User>>();
            builder.RegisterType<ApplicationRepository>().As<IApplicationRepository>().As<IRepository<Application>>()
                .WithParameter("context", new InfrastructureContext());

            var container = builder.Build();

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}