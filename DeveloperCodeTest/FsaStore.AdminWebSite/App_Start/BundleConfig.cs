using System.Web.Optimization;

namespace FsaStore.AdminWebSite.App_Start
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/js").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery-migrate-{version}.js",
                "~/Scripts/jquery-unobtrusive-{version}.js",
                "~/Scripts/jquery-validate-{version}.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/angular.js",
                "~/Scripts/app.js",
                "~/Scripts/accountController.js",
                "~/Scripts/accountService.js",
                "~/Scripts/angular-cookies.js",
                "~/Scripts/angular-route.js",
                "~/Scripts/angular-resource.js"
                ));

            bundles.Add(new StyleBundle("~/content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/body.css",
                "~/Content/bootstrap-theme.css",
                "~/Content/styles.css"
                ));
        }
    }
}
