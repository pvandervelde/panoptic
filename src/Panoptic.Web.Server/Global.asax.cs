using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Panoptic.Web.Server.Common.Initialization;
using Panoptic.Web.Server.Configuration;
using Panoptic.Web.Server.Nuclei.Fusion;

namespace Panoptic.Web.Server
{
    /// <summary>
    /// Defines the entry point for the Web API application.
    /// </summary>
    public class WebApiApplication : HttpApplication
    {
        /// <summary>
        /// The entry point for the web application.
        /// </summary>
        protected void Application_Start()
        {
            PreInitialize();

            var container = MefConfig.RegisterMef(AssemblySearchPaths());
            container.ComposeParts(this);

            AreaRegistration.RegisterAllAreas();
            if (WebApiConfig != null)
            {
                foreach (var apiConfig in WebApiConfig)
                {
                    GlobalConfiguration.Configure(apiConfig.Register);
                }
            }

            if (Filters != null)
            {
                foreach (var filter in Filters)
                {
                    filter.RegisterGlobalFilters(GlobalFilters.Filters);
                }
            }

            if (Routes != null)
            {
                foreach (var route in Routes)
                {
                    route.RegisterRoutes(RouteTable.Routes);
                }
            }

            if (Bundles != null)
            {
                foreach (var bundle in Bundles)
                {
                    bundle.RegisterBundles(BundleTable.Bundles);
                }
            }
        }

        private IEnumerable<string> AssemblySearchPaths()
        {
            var list = new List<string>();
            /*
            var config = CompositionConfigurationSection.GetInstance();
            if (config != null && config.Catalogs != null)
            {
                config.Catalogs
                    .Cast<CatalogConfigurationElement>()
                    .ForEach(c =>
                    {
                        if (!string.IsNullOrEmpty(c.Path))
                        {
                            string path = c.Path;
                            if (path.StartsWith("~") || path.StartsWith("/"))
                            {
                                path = MapPath(path);
                            }

                            list.Add(path);
                        }
                    });
            }
            */

            return list;
        }

        [ImportMany]
        internal IEnumerable<IBundleConfig> Bundles
        {
            get;
            set;
        }

        [ImportMany]
        internal IEnumerable<IFilterConfig> Filters
        {
            get;
            set;
        }

        private string MapPath(string virtualPath)
        {
            {
                Lokad.Enforce.Argument(() => virtualPath);
                Lokad.Enforce.Argument(() => virtualPath, Lokad.Rules.StringIs.NotEmpty);
            }

            return HttpContext.Current.Server.MapPath(virtualPath);
        }

        /// <summary>
        /// Fired before the application is composed.
        /// </summary>
        private void PreInitialize()
        {
            var domain = AppDomain.CurrentDomain;
            {
                var helper = new FusionHelper(
                    () => AssemblySearchPaths().SelectMany(
                        dir => Directory.GetFiles(
                            dir,
                            "*.dll",
                            SearchOption.AllDirectories)));
                domain.AssemblyResolve += helper.LocateAssemblyOnAssemblyLoadFailure;
            }
        }

        [ImportMany]
        internal IEnumerable<IRouteConfig> Routes
        {
            get;
            set;
        }

        [ImportMany]
        internal IEnumerable<IWebApiConfig> WebApiConfig
        {
            get;
            set;
        }
    }
}
