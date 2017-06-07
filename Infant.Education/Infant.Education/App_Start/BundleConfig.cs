using System.Web;
using System.Web.Optimization;

namespace Infant.Education
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();
            bundles.Add(
               new StyleBundle("~/Bundles/App/vendor/css")
               .Include("~/Content/style.css", new CssRewriteUrlTransform())
               .Include("~/Content/assets/global/plugins/font-awesome/css/font-awesome.min.css", new CssRewriteUrlTransform())
               .Include("~/Content/assets/global/plugins/simple-line-icons/simple-line-icons.min.css", new CssRewriteUrlTransform())
               .Include("~/Content/assets/global/plugins/bootstrap/css/bootstrap.min.css", new CssRewriteUrlTransform())
               .Include("~/Content/assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css", new CssRewriteUrlTransform())
               .Include("~/Content/assets/global/plugins/bootstrap-daterangepicker/daterangepicker.min.css", new CssRewriteUrlTransform())
               .Include("~/Content/assets/global/plugins/morris/morris.css", new CssRewriteUrlTransform())
               .Include("~/Content/assets/global/plugins/fullcalendar/fullcalendar.min.css", new CssRewriteUrlTransform())
               .Include("~/Content/assets/global/plugins/jqvmap/jqvmap/jqvmap.css", new CssRewriteUrlTransform())
               .Include("~/Content/assets/global/css/components.min.css", new CssRewriteUrlTransform())
               .Include("~/Content/assets/global/css/plugins.min.css", new CssRewriteUrlTransform())
               .Include("~/Content/assets/layouts/layout/css/layout.min.css", new CssRewriteUrlTransform())
               .Include("~/Content/assets/layouts/layout/css/themes/darkblue.min.css", new CssRewriteUrlTransform())
               .Include("~/Content/assets/layouts/layout/css/custom.min.css", new CssRewriteUrlTransform())
            );


            //~/Bundles/App/vendor/js
            bundles.Add(
                new ScriptBundle("~/Bundles/App/vendor/js").Include(
                    "~/Content/assets/global/plugins/jquery.min.js",
                    "~/Content/assets/global/plugins/bootstrap/js/bootstrap.min.js",
                    "~/Content/assets/global/plugins/js.cookie.min.js",
                    "~/Content/assets/global/plugins/bootstrap-hover-dropdown/bootstrap-hover-dropdown.min.js",
                    "~/Content/assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js",
                    "~/Content/assets/global/plugins/jquery.blockui.min.js",
                    "~/Content/assets/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js",
                    "~/Content/assets/global/plugins/moment.min.js",
                    "~/Content/assets/global/plugins/bootstrap-daterangepicker/daterangepicker.min.js",
                    "~/Content/assets/global/plugins/morris/morris.min.js",
                    "~/Content/assets/global/plugins/morris/raphael-min.js",
                    "~/Content/assets/global/plugins/counterup/jquery.waypoints.min.js",
                    "~/Content/assets/global/plugins/counterup/jquery.counterup.min.js",
                    "~/Content/assets/global/plugins/amcharts/amcharts/amcharts.js",
                    "~/Content/assets/global/plugins/amcharts/amcharts/serial.js",
                    "~/Content/assets/global/plugins/amcharts/amcharts/pie.js",
                    "~/Content/assets/global/plugins/amcharts/amcharts/radar.js",
                    "~/Content/assets/global/plugins/amcharts/amcharts/themes/light.js",
                    "~/Content/assets/global/plugins/amcharts/amcharts/themes/patterns.js",
                    "~/Content/assets/global/plugins/amcharts/amcharts/themes/chalk.js",
                    "~/Content/assets/global/plugins/amcharts/ammap/ammap.js",
                    "~/Content/assets/global/plugins/amcharts/ammap/maps/js/worldLow.js",
                    "~/Content/assets/global/plugins/amcharts/amstockcharts/amstock.js",
                    "~/Content/assets/global/plugins/fullcalendar/fullcalendar.min.js",
                    "~/Content/assets/global/plugins/horizontal-timeline/horozontal-timeline.min.js",
                    "~/Content/assets/global/plugins/flot/jquery.flot.min.js",
                    "~/Content/assets/global/plugins/flot/jquery.flot.resize.min.js",
                    "~/Content/assets/global/plugins/flot/jquery.flot.categories.min.js",
                    "~/Content/assets/global/plugins/jquery-easypiechart/jquery.easypiechart.min.js",
                    "~/Content/assets/global/plugins/jquery.sparkline.min.js",
                    "~/Content/assets/global/plugins/jqvmap/jqvmap/jquery.vmap.js",
                    "~/Content/assets/global/plugins/jqvmap/jqvmap/maps/jquery.vmap.russia.js",
                    "~/Content/assets/global/plugins/jqvmap/jqvmap/maps/jquery.vmap.world.js",
                    "~/Content/assets/global/plugins/jqvmap/jqvmap/maps/jquery.vmap.europe.js",
                    "~/Content/assets/global/plugins/jqvmap/jqvmap/maps/jquery.vmap.germany.js",
                    "~/Content/assets/global/plugins/jqvmap/jqvmap/maps/jquery.vmap.usa.js",
                    "~/Content/assets/global/plugins/jqvmap/jqvmap/data/jquery.vmap.sampledata.js",
                    "~/Content/assets/global/scripts/app.min.js",
                    "~/Content/assets/pages/scripts/dashboard.min.js",
                    "~/Content/assets/layouts/layout/scripts/layout.min.js",
                    "~/Content/assets/layouts/layout/scripts/demo.min.js",
                    "~/Content/assets/layouts/global/scripts/quick-sidebar.min.js"
                )
            );
        }
    }
}
