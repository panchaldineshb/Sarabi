using Autofac;
using Autofac.Integration.Mvc;
using Blog.Samples.MVCEF6.Data.DataAcess;
using Blog.Samples.MVCEF6.Data.DatabaseModel;
using System.Web.Mvc;
using Blog.Samples.MVCEF6.Domain.Services;

namespace Blog.Samples.MVCEF6.Web.App_Start
{
    public class DependencyConfig
    {
        public static void Configure(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(ProductsServices).Assembly).AsImplementedInterfaces().InstancePerHttpRequest();

            builder.RegisterControllers(typeof(MvcApplication).Assembly)
                   .PropertiesAutowired();

            builder.RegisterAssemblyTypes(typeof(ContextAdaptor).Assembly)
                .AsImplementedInterfaces()
                .InstancePerHttpRequest();

            builder.RegisterType<AdventureWorks2012Entities>()
                .As<IDbContext>()
                .InstancePerHttpRequest();

            builder.RegisterType<ContextAdaptor>()
                .As<IObjectSetFactory, IObjectContext>()
                .InstancePerHttpRequest();

            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerHttpRequest();


            builder.RegisterGeneric(typeof(Repository<>))
                .As(typeof(IRepository<>))
                .InstancePerHttpRequest();

            var container = builder.Build();
            var dependencyResolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(dependencyResolver);
        }
    }
}