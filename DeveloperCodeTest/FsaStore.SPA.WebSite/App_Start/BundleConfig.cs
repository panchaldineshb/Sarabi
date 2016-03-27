using System.Web.Optimization;

namespace FsaStore.SPA.WebSite
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                // jQuery
                        "~/Scripts/libs/jquery-{version}.js",
                       "~/Scripts/libs/jquery-ui-{version}.min.js",
                // Select2
                        "~/Scripts/libs/select2/select2.js",
                // AngularJS
                        "~/Scripts/libs/angular-{version}.js",
                        "~/Scripts/libs/angular-resource-{version}.js",
                        "~/Scripts/libs/angular-cookies-{version}.js",
                        "~/Scripts/libs/angular-route-{version}.js",
                        "~/Scripts/libs/angular-animate-{version}.js",
                // AngularJS-UI
                        "~/Scripts/libs/angular-ui/select2.js",
                // Semantic
                        "~/Scripts/libs/semantic/semantic.js",
                // ng-table
                        "~/Scripts/libs/ng-table/ng-table.js",
                // Application
                        "~/Scripts/app/config.js",
                        "~/Scripts/app/app.js",
                        "~/Scripts/app/controllers/shared/resourcemngrcontroller.js",
                        "~/Scripts/app/services/shared/resourcemngrservice.js",
                        "~/Scripts/app/directives/shared/datepicker.js",
                         "~/Scripts/app/directives/shared/modal.js",
                        "~/Scripts/app/directives/shared/confirmmodal.js",
                        "~/Scripts/app/directives/shared/topmenu.js",
                        "~/Scripts/app/directives/shared/loadingoverlay.js",
                        "~/Scripts/app/services/shared/servicehelper.js",
                        "~/Scripts/app/controllers/locations/locationscontroller.js",
                        "~/Scripts/app/controllers/locations/locationcontroller.js",
                        "~/Scripts/app/services/locations/locationservice.js",
                        "~/Scripts/app/controllers/resources/resourcescontroller.js",
                        "~/Scripts/app/controllers/resources/resourceeditcontroller.js",
                        "~/Scripts/app/controllers/resources/resourcecontroller.js",
                        "~/Scripts/app/services/resources/resourceservice.js",
                        "~/Scripts/app/directives/activities/resourceactivitylist.js",
                        "~/Scripts/app/controllers/activities/activityaddcontroller.js",
                        "~/Scripts/app/services/activities/activityservice.js",
                        "~/Scripts/app/controllers/activities/activitiescontroller.js",
                        "~/Scripts/app/controllers/home/homecontroller.js",
                        "~/Scripts/app/helpers/authorizationinterceptor.js"));

            // Styles
            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/themes/semantic/semantic.css",
                        "~/Content/themes/ng-table/ng-table.css",
                        "~/Content/themes/Site.css",
                        "~/Content/themes/smoothness/jquery-ui.min.css",
                        "~/Content/themes/select2/select2.css"));
        }
    }
}