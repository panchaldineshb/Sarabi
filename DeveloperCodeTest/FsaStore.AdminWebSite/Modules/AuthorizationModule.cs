using System.Web.Mvc;
using FsaStore.AdminWebSite.Filters;
using Ninject.Modules;
using Ninject.Web.Common;

namespace FsaStore.Core.Modules
{
    public class AuthorizationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<AuthorizeAttribute>().To<DefaultRoleAttribute>().InRequestScope();
        }
    }
}