using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using FsaStore.Core.Abstracts;
using FsaStore.Core.Models;

namespace FsaStore.WebSite.Filters
{
    public class DefaultRoleAttribute : AuthorizeAttribute
    {
        private IRepository<AccountProfile> AccountProfileRepository;
        private IRepository<Account> AccountRepository;

        public DefaultRoleAttribute()
        {
            // Refer -- http://stackoverflow.com/questions/6519720/using-ninject-with-a-custom-role-provider-in-an-mvc3-app
            AccountRepository = DependencyResolver.Current.GetService<IRepository<Account>>(); ;
            AccountProfileRepository = DependencyResolver.Current.GetService<IRepository<AccountProfile>>();
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var isLocal = httpContext.Request.IsLocal;

            var isAuthorized = base.AuthorizeCore(httpContext);
            if (isAuthorized)
            {
                var authCookie = httpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie != null)
                {
                    var authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                    var identity = new GenericIdentity(authTicket.Name, "Forms");
                    var principal = new GenericPrincipal(identity, new string[] { });
                    httpContext.User = principal;
                }
            }
            return isAuthorized;
        }
    }
}