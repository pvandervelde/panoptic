using System.ComponentModel.Composition;
using System.Web.Optimization;
using Panoptic.Web.Server.Common.Initialization;

namespace Panoptic.Web.Server
{
    /// <summary>
    /// Defines the configuration for bundles.
    /// </summary>
    [Export(typeof(IBundleConfig))]
    public sealed class BundleConfig : IBundleConfig
    {
        /// <summary>
        /// Registers the bundle configurations with the bundle collection.
        /// </summary>
        /// <param name="bundles">The bundle collection.</param>
        public void RegisterBundles(BundleCollection bundles)
        {
            // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr")
                .Include("~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap")
                .Include(
                    "~/Scripts/bootstrap.js",
                    "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular")
                .Include(
                    "~/Scripts/lodash.js",
                    "~/Scripts/angular.js",
                    "~/Scripts/angular-route.js",
                    "~/Scripts/restangular.js"));

            bundles.Add(new ScriptBundle("~/bundles/panoptic")
                .IncludeDirectory("~/Client/core", "*.js", true)
                .IncludeDirectory("~/Client/shared", "*.js", true)
                .IncludeDirectory("~/Client/home", "*.js", true)
                .IncludeDirectory("~/Client/ops", "*.js", true)
                .Include("~/Client/panoptic.js"));

            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/bootstrap.css"));
        }
    }
}
