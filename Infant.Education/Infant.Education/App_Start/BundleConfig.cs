using System.Web;
using System.Web.Optimization;

namespace Infant.Education
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = true;
            bundles.IgnoreList.Clear();
            bundles.Add(
               new StyleBundle("~/Bundles/App/vendor/css")
               .Include("~/Content/style.css", new CssRewriteUrlTransform())
               .Include("~/Content/assets/global/plugins/font-awesome/css/font-awesome.min.css", new CssRewriteUrlTransform())
               .Include("~/Content/assets/global/plugins/simple-line-icons/simple-line-icons.min.css", new CssRewriteUrlTransform())
               .Include("~/Content/assets/global/plugins/bootstrap/css/bootstrap.min.css", new CssRewriteUrlTransform())
               .Include("~/Content/assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css", new CssRewriteUrlTransform())

              
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
                    
                    "~/Content/assets/global/scripts/app.min.js",
                    "~/Content/assets/layouts/layout/scripts/layout.min.js",
                    "~/Content/assets/layouts/layout/scripts/demo.min.js",
                    "~/Content/assets/layouts/global/scripts/quick-sidebar.min.js"
                )
            );
        }
    }
}
