using System.Collections.Generic;
using FsaStore.Core.Abstracts;
using FsaStore.Core.Modules;
using FsaStore.AdminWebSite.Modules;
using Ninject.Modules;

namespace FsaStore.AdminWebSite.App_Start
{
    public class BootstrapHelper : INinjectModuleBootstrapper
    {
        public IList<INinjectModule> GetModules()
        {
            //this is where you will be considering priority of your modules.
            return new List<INinjectModule>()
                   {
                       new DbContextModule(),
                       new WebAPIModule(),
                       new MembershipProviderModule(),
                       new AuthorizationModule(),
                       new AccountModule()
                   };
            //RepositoryModule cannot be loaded until DataObjectModule is loaded
            //as it is depended on DataObjectModule and DbConnectionModule has
            //dependency on RepositoryModule
        }
    }
}