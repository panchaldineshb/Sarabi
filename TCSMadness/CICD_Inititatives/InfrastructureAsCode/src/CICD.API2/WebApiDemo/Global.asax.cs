using System.Web.Http;

namespace CICD.API2
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutofacConfig.RegisterResolvers();
            EFConfig.Initialize();
            SeedData.Init();
        }
    }
}