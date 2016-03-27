using System.Web.Http;

namespace Registration.API2
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(Registration.API2.WebApiConfig.Register);
        }
    }
}
