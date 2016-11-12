using System.Web;
using System.Web.Optimization;

namespace EMSystem
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/plugins").Include(
                        "~/Scripts/jquery.mark.js",
                        "~/Scripts/datatable/js/jquery.dataTables.js",
                        "~/Scripts/datatable/js/dataTables.material.js",
                        "~/Scripts/datatable/js/datatables.mark.js",
                        "~/Scripts/bootstrap-datepicker.js",
                        "~/Scripts/autoNumeric.js",
                        "~/Scripts/jquery.validate.js",
                        "~/Scripts/additional-methods.js",
                        "~/Scripts/datatable/js/datatables.responsive.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/font-awesome.css",
                    "~/Content/bootstrap-theme.css",
                     "~/Scripts/datatable/css/dataTables.material.css",
                     "~/Scripts/datatable/css/datatables.responsive.css",
                      "~/Content/datepicker.css",
                      "~/Content/site.css"));
        }
    }
}
