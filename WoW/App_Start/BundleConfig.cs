using System.Web;
using System.Web.Optimization;

namespace WoW
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            //end default bundles

            //metronic
            // BEGIN CORE PLUGINS
            bundles.Add(new ScriptBundle("~/bundles/metronic-core").Include(
                "~/Content/metronic/theme/assets/global/plugins/jquery.min.js",
                "~/Content/metronic/theme/assets/global/plugins/jquery-migrate.min.js",
                "~/Content/metronic/theme/assets/global/plugins/jquery-ui/jquery-ui.min.js",
                    "~/Content/metronic/theme/assets/global/plugins/bootstrap/js/bootstrap.min.js",
                    "~/Content/metronic/theme/assets/global/plugins/bootstrap-hover-dropdown/bootstrap-hover-dropdown.min.js",
                    "~/Content/metronic/theme/assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js",
                    "~/Content/metronic/theme/assets/global/plugins/jquery.blockui.min.js",
                    "~/Content/metronic/theme/assets/global/plugins/jquery.cokie.min.js",
                    "~/Content/metronic/theme/assets/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js"
                    ));
            // END CORE PLUGINS

            // BEGIN THEME GLOBAL SCRIPTS
            bundles.Add(new ScriptBundle("~/bundles/metronic-global").Include(
                     "~/Content/metronic/theme/assets/global/scripts/app.min.js"
                     ));
            // END THEME GLOBAL SCRIPTS

            // BEGIN THEME LAYOUT SCRIPTS
            bundles.Add(new ScriptBundle("~/bundles/metronic-layout").Include(
                     "~/Content/metronic/theme/assets/layouts/layout3/scripts/layout.min.js",
                     "~/Content/metronic/theme/assets/layouts/global/scripts/quick-sidebar.min.js",
                     "~/Content/metronic/theme/assets/layouts/global/scripts/quick-nav.min.js"
                     ));
            // END THEME LAYOUT SCRIPTS
            // BEGIN GLOBAL MANDATORY STYLES
            bundles.Add(new StyleBundle("~/Content/metronic-global-mandatory").Include(
                      "~/Content/metronic/theme/assets/global/plugins/font-awesome/css/font-awesome.min.css",
                      "~/Content/metronic/theme/assets/global/plugins/simple-line-icons/simple-line-icons.min.css",
                     "~/Content/metronic/theme/assets/global/plugins/bootstrap/css/bootstrap.min.css",
                      "~/Content/metronic/theme/assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css"
                      ));
            // END GLOBAL MANDATORY STYLES

            // BEGIN THEME GLOBAL STYLES
            bundles.Add(new StyleBundle("~/Content/metronic-global").Include(
                      "~/Content/metronic/theme/assets/global/css/components-rounded.min.css",
                      "~/Content/metronic/theme/assets/global/css/plugins.min.css"));
            // END THEME GLOBAL STYLES

            // BEGIN THEME LAYOUT STYLES
            bundles.Add(new StyleBundle("~/Content/metronic-layout").Include(
                      "~/Content/metronic/theme/assets/global/css/components.min.css",
                      "~/Content/metronic/theme/assets/global/css/plugins.min.css",
                      "~/Content/metronic/theme/assets/layouts/layout/css/layout.css",
                      "~/Content/metronic/theme/assets/layouts/layout3/css/layout.css",
                      "~/Content/metronic/theme/assets/layouts/layout3/css/custom.css"));
            // END THEME LAYOUT STYLES

        }
    }
}
