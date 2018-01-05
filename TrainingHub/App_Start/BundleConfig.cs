using System.Web;
using System.Web.Optimization;

namespace TrainingHub
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui-1.12.1.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/respond.js",
                        "~/Scripts/jtable/external/json2.js",
                        "~/Scripts/datatables/jquery.datatables.js",
                        "~/Scripts/datatables/datatables.bootstrap.js",
                        "~/Scripts/jtable/jquery.jtable.js",
                        "~/Scripts/jtable/extensions/jquery.jtable.aspnetpagemethods.js",
                        "~/Scripts/toastr.js",
                        "~/Scripts/bootbox.js"));


            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/datatables/css/datatables.bootstap.css",
                "~/Content/toastr.css",
                "~/Content/site.css",
                "~/Content/themes/base/jquery-ui.css",
                "~/Scripts/jtable/themes/lightcolor/blue/jtable.css",
                "~/Content/bootstrap.css"));
        }
    }
}
