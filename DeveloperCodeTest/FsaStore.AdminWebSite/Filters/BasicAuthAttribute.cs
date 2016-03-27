using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FsaStore.AdminWebSite.Filters
{
    public class BasicAuthAttribute : AuthorizeAttribute
    {
        public BasicAuthAttribute(bool allowedABTesting)
        {
            AllowedABTesting = allowedABTesting;
        }

        private bool AllowedABTesting { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var user = httpContext.User;
            return Membership.ValidateUser("1", "2");
        }
    }

    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
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