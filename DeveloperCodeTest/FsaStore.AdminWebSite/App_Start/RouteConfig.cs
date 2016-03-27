using System.Web.Mvc;
using System.Web.Routing;

namespace FsaStore.AdminWebSite.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "DefaultMapRoute",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            //http://stackoverflow.com/questions/11077554/controller-in-separate-assembly-and-routing
            routes.MapRoute(
                name: "DefaultAPIDefault",
                url: "api/{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "FsaStore.WebAPI.Controllers" }
            );

        }
    }
}