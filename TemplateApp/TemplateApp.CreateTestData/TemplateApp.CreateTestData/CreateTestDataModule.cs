using Ninject.Modules;

using TemplateApp.Data.Models;
using TemplateApp.Data.Repositories;

namespace TemplateApp.CreateTestData
{
    internal class CreateTestDataModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<Company>>().To<CompanyRepository>();
            Bind<IRepository<Currency>>().To<CurrencyRepository>();

            /*
            Bind<ILogger>().To<ConsoleLogger>().InSingletonScope();
            Bind<MailServerConfig>().ToSelf().InRequestScope();
            */
        }
    }
}