using System.Web;
using System.Web.Optimization;

namespace HomefulAPI
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/materialdesignjs", "https://code.getmdl.io/1.3.0/material.min.js").Include(
                    "~/Scripts/material.min.js"));
            bundles.Add(new StyleBundle("~/bundles/materialdesigncss", "https://code.getmdl.io/1.3.0/material.blue-cyan.min.css").Include(
                    "~/Content/material.blue-cyan.min.css"));
            bundles.Add(new StyleBundle("~/bundles/materialicon", "https://fonts.googleapis.com/icon?family=Material+Icons").Include(
                    "~/Content/materialicon"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
           //           "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/bundles/materializecss", "https://cdnjs.cloudflare.com/ajax/libs/materialize/0.98.0/css/materialize.min.css").Include(
                    "~/Content/materializecss"));
            bundles.Add(new ScriptBundle("~/bundles/materializejs", "https://cdnjs.cloudflare.com/ajax/libs/materialize/0.98.0/js/materialize.min.js").Include(
                    "~/Scripts/materializejs"));

            BundleTable.EnableOptimizations = true;
            bundles.UseCdn = true;
        }
    }
}
