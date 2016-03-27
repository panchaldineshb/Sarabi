using System.Web.Http;

namespace CICD.API2
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Attribute routing.
            config.MapHttpAttributeRoutes();

            // Convention-based routing.
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/cicd/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}