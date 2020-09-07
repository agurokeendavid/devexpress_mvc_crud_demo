using System.Web;
using System.Web.Optimization;

namespace Demo.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/scripts/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/styles/bootstrap").Include(
                      "~/Content/bootstrap.css"));

            bundles.Add(new ScriptBundle("~/scripts/packages").Include(
                "~/Scripts/toastr.js"));

            bundles.Add(new StyleBundle("~/styles/packages").Include(
                "~/Content/toastr.css"));

            bundles.Add(new ScriptBundle("~/scripts/toast").Include(
                "~/Scripts/Toast.js"));
        }
    }
}
