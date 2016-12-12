using System.Web.Optimization;

namespace Framework.UI
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/Libraries/jquery-3.1.0.min.js",
                        "~/Scripts/Libraries/jquery-ui.min.js",
                        "~/Scripts/Libraries/jquery.dataTables.js",
                        "~/Scripts/Libraries/dataTables.buttons.js",
                        "~/Scripts/Libraries/buttons.print.js",
                        "~/Scripts/Libraries/buttons.bootstrap.js",
                        "~/Scripts/Libraries/buttons.html5.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/Libraries/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/Libraries/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/Libraries/bootstrap.js",
                      "~/Scripts/Libraries/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/modules").Include(
                "~/Scripts/Modules/Helpers/helpers.module.js",
                "~/Scripts/Modules/Helpers/navigation.module.js",
                "~/Scripts/Modules/Helpers/grid.module.js",
                "~/Scripts/Modules/Helpers/exception.log.module.js",
                "~/Scripts/Modules/Helpers/editor.module.js",
                "~/Scripts/Modules/Helpers/change.tracker.module.js",
                "~/Scripts/Modules/Helpers/application.module.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/jquery.dataTables.css",
                      "~/Content/buttons.bootstrap.css",
                      "~/Content/buttons.dataTables.css",
                      "~/Content/site.css"));
        }
    }
}
