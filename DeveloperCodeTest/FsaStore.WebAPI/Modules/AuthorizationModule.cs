using System.Web.Mvc;
using FsaStore.WebAPI.Filters;
using Ninject.Modules;
using Ninject.Web.Common;

namespace FsaStore.WebAPI.Modules
{
    public class AuthorizationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<AuthorizeAttribute>().To<DefaultRoleAttribute>().InRequestScope();
        }
    }
}