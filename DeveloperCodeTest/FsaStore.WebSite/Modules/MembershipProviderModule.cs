using System.Web.Security;
using FsaStore.WebSite.Providers;
using Ninject.Modules;
using Ninject.Web.Common;

namespace FsaStore.Core.Modules
{
    public class MembershipProviderModule : NinjectModule
    {
        public override void Load()
        {
            Bind<MembershipProvider>().To<AccountMembershipProvider>().InRequestScope();
            Bind<RoleProvider>().To<AccountRoleProvider>().InRequestScope();
        }
    }
}