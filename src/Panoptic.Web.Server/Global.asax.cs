using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
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

            MefConfig.RegisterMef(AssemblySearchPaths());
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }

        private IEnumerable<string> AssemblySearchPaths()
        {
            var list = new List<string>();
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

            return list;
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
    }
}
