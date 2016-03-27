using Ninject.Modules;

using FsaStore.Core.Models;

namespace FsaStore.CreateTestData
{
    internal class CreateTestDataModule : NinjectModule
    {
        public override void Load()
        {
            /*
            Bind<IRepository<Company>>().To<CompanyRepository>();
            Bind<IRepository<Currency>>().To<CurrencyRepository>();

            Bind<ILogger>().To<ConsoleLogger>().InSingletonScope();
            Bind<MailServerConfig>().ToSelf().InRequestScope();
            */
        }
    }
}