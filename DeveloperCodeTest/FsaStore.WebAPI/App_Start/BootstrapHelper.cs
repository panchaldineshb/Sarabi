using System.Collections.Generic;
using FsaStore.Core.Abstracts;
using FsaStore.Core.Modules;
using FsaStore.WebAPI.Modules;
using Ninject.Modules;

namespace FsaStore.WebAPI.App_Start
{
    public class BootstrapHelper : INinjectModuleBootstrapper
    {
        public IList<INinjectModule> GetModules()
        {
            //this is where you will be considering priority of your modules.
            return new List<INinjectModule>()
                   {
                       new DbContextModule(),
                       new AuthorizationModule(),
                       new AccountModule()
                   };
            //RepositoryModule cannot be loaded until DataObjectModule is loaded
            //as it is depended on DataObjectModule and DbConnectionModule has
            //dependency on RepositoryModule
        }
    }
}