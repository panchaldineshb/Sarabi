using System.Web.Http;

namespace Deployment.API2
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(Deployment.API2.WebApiConfig.Register);
        }
    }
}
