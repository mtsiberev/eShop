using System.Web.Optimization;

namespace OrganizationsWebApplication
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            var scriptBundle = new ScriptBundle("~/commonBundle");

            scriptBundle.Include("~/Scripts/jquery-{version}.js");
            scriptBundle.Include("~/Scripts/jquery.unobtrusive*");
            scriptBundle.Include("~/Scripts/jquery.validate*");

            var styleBundle = new StyleBundle("~/styleBundle");
            styleBundle.Include("~/Css/styles.css");

            bundles.Add(scriptBundle);
            bundles.Add(styleBundle);
            //////////////////////////////
            var angularBundle = new ScriptBundle("~/angularBundle");

            scriptBundle.Include("~/Scripts/angular.js");
            scriptBundle.Include("~/Scripts/angular-route.js");

            bundles.Add(angularBundle);
        }
    }
}