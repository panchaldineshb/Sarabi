namespace FsaStore.SampleWebSite.V1.Modules
{
    using System.Data.Entity;
    using System.Web.Security;
    using FsaStore.Core.Abstracts;
    using FsaStore.Core.Concrete;
    using FsaStore.Core.Context;
    using FsaStore.Core.Models;
    using Ninject.Modules;

    /// <summary>
    /// The ninject module for the account service.
    /// </summary>
    public class AccountModule : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            Bind<DbContext>().To<FsaStoreContext>();

            Bind<IRepository<Account>>().To<Repository<Account>>().InTransientScope();
            Bind<IRepository<Role>>().To<Repository<Role>>().InTransientScope();

            Bind<IRepository<Company>>().To<Repository<Company>>().InTransientScope();

            Bind<IRepository<ProductGroup>>().To<Repository<ProductGroup>>().InTransientScope();
            Bind<IRepository<Product>>().To<Repository<Product>>().InTransientScope();
            Bind<MembershipProvider>().ToMethod(ctx => Membership.Provider).InTransientScope();
        }
    }
}