using System.Web.Optimization;

namespace PowerCoWebSite.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/styles")
                .Include("~/Content/Styles/bootstrap.css")
                .Include("~/Content/Styles/Site.css")
                .Include("~/Content/Styles/font-awesome.min.css"));

            bundles.Add(new ScriptBundle("~/scripts")
                .Include("~/Scripts/jquery-3.1.1.js")
                .Include("~/Scripts/bootstrap.js")
                .Include("~/Scripts/MyScr.js"));
        }
    }
}