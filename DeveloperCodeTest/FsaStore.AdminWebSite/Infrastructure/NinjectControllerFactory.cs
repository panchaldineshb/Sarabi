using System.Web.Mvc;

using FsaStore.Core.Abstracts;
using FsaStore.Core.Concrete;
using FsaStore.Core.Models;

using FsaStore.Core.Providers;

using Ninject;
using Ninject.Web.Common;

namespace FsaStore.WebSite.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel _ninjectKernel;

        public NinjectControllerFactory()
        {
            _ninjectKernel = new StandardKernel();
            AddBindings();
        }

        private void AddBindings()
        {
            _ninjectKernel.Bind<IRepository<Account>>().To<Repository<Account>>();
            _ninjectKernel.Bind<IRepository<AccountProfile>>().To<Repository<AccountProfile>>();
            _ninjectKernel.Bind<IRepository<Company>>().To<Repository<Company>>();

            _ninjectKernel.Bind<IRepository<ProductGroup>>().To<Repository<ProductGroup>>();
            _ninjectKernel.Bind<IRepository<Product>>().To<Repository<Product>>();

            _ninjectKernel.Bind<System.Web.Security.MembershipProvider>().To<AccountMembershipProvider>().InRequestScope();
            _ninjectKernel.Bind<System.Web.Security.RoleProvider>().To<AccountRoleProvider>().InSingletonScope();
        }
    }
}