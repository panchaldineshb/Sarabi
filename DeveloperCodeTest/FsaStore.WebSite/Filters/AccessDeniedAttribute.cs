using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FsaStore.WebSite.Filters
{
    public class AccessDeniedAttribute : AuthorizeAttribute
    {
        public string Groups { get; set; }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectResult("~/Account/Logon");
                return;
            }

            if (filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectResult("~/Account/Denied");
            }
        }
    }

}