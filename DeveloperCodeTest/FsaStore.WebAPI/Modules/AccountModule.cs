using FsaStore.Core.Abstracts;
using FsaStore.Core.Concrete;
using FsaStore.Core.Models;

using Ninject.Modules;

namespace FsaStore.WebAPI.Modules
{
    public class AccountModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<Company>>().To<Repository<Company>>();
            Bind<IRepository<SystemSetting>>().To<Repository<SystemSetting>>();

            Bind<IRepository<AccountProfile>>().To<Repository<AccountProfile>>();
            Bind<IRepository<Account>>().To<Repository<Account>>();
            Bind<IRepository<Role>>().To<Repository<Role>>();

            Bind<IRepository<ProductGroup>>().To<Repository<ProductGroup>>();
            Bind<IRepository<Product>>().To<Repository<Product>>();
        }
    }
}