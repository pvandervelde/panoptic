//-----------------------------------------------------------------------
// <copyright company="Panoptic">
//     Copyright 2013 Panoptic. Licensed under the Apache License, Version 2.0.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Panoptic.UI.Web.Common.Areas;
using Panoptic.UI.Web.Common.Routes;
using Panoptic.UI.Web.Composition;
using Panoptic.UI.Web.Configuration;
using Panoptic.UI.Web.Nuclei.Fusion;

namespace Panoptic.UI.Web
{
    /// <summary>
    /// The entry point of the web application.
    /// </summary>
    public class PanopticApplication : HttpApplication
    {
        private static IEnumerable<Lazy<IAreaDescription, IAreaDescriptionMetadata>> s_ActionVerbs;

        /// <summary>
        /// Gets the <see cref="Composer" /> used to compose parts.
        /// </summary>
        public static Composer Composer
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the available descriptions for the given category.
        /// </summary>
        /// <param name="category">The category of descriptions to get.</param>
        /// <returns>A collection containing the requested descriptions.</returns>
        public static IEnumerable<IAreaDescription> GetDescriptionsForCategory(string category)
        {
            {
                Lokad.Enforce.Argument(() => category);
                Lokad.Enforce.Argument(() => category, Lokad.Rules.StringIs.NotEmpty);
            }

            return s_ActionVerbs
                .Where(l => l.Metadata.Category.Equals(category, StringComparison.InvariantCultureIgnoreCase))
                .Select(l => l.Value);
        }

        /// <summary>
        /// Provides the initialization code for the application.
        /// </summary>
        protected void Application_Start()
        {
            // Perform any tasks required before composition.
            PreCompose();

            // Create the composer used for composition.
            Composer = CreateComposer();

            // Compose the application.
            Compose();

            // Set the controller factory.
            ControllerBuilder.Current.SetControllerFactory(ControllerFactory);

            // Initialises the application.
            Initialize();

            // Register all areas.
            RegisterAreas();

            // Register MVC routes.
            RegisterRoutes();
        }

        /// <summary>
        /// Gets or sets the collection that contains the area registration instances.
        /// </summary>
        [ImportMany]
        public IEnumerable<AreaRegistration> AreaRegistrars
        {
            get;
            set;
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

        /// <summary>
        /// Creates a <see cref="Composer" /> used to compose parts.
        /// </summary>
        /// <returns>The new composer</returns>
        private Composer CreateComposer()
        {
            var composer = new Composer();

            composer.AddCatalog(new AssemblyCatalog(Assembly.GetExecutingAssembly()));

            var otherPath = @"C:\Users\Petrik\Documents\software\panoptic\src\src\Panoptic.UI.Web\bin\Panoptic.Plugins.UI.Ops.dll";
            composer.AddCatalog(new AssemblyCatalog(otherPath));

            GetDirectoryCatalogs()
                .ForEach(composer.AddCatalog);

            composer.AddExportProvider(
                new DynamicInstantiationExportProvider(),
                (provider, container) => ((DynamicInstantiationExportProvider)provider).SourceProvider = container);

            return composer;
        }

        /// <summary>
        /// Composes the application.
        /// </summary>
        private void Compose()
        {
            if (Composer == null)
            {
                return;
            }

            Composer.Compose(this);

            s_ActionVerbs = Composer.ResolveAll<IAreaDescription, IAreaDescriptionMetadata>();
        }

        /// <summary>
        /// Gets or sets the controller factory.
        /// </summary>
        [Import]
        public ImportControllerFactory ControllerFactory
        {
            get;
            set;
        }

        /// <summary>
        /// Gets an list of <see cref="DirectoryCatalog" />s of configured directories.
        /// </summary>
        /// <returns>An lsit of <see cref="DirectoryCatalog" />s of configured directories.</returns>
        private List<DirectoryCatalog> GetDirectoryCatalogs()
        {
            var list = new List<DirectoryCatalog>();

            foreach (var path in AssemblySearchPaths())
            {
                foreach (var catalog in GetDirectoryCatalogs(path))
                {
                    // list.Add(catalog);
                }
            }

            return list;
        }

        /// <summary>
        /// Gets a set of <see cref="DirectoryCatalog" /> for the specified path and it's immediate child directories.
        /// </summary>
        /// <param name="path">The starting path.</param>
        /// <returns>An <see cref="IEnumerable{DirectoryCatalog}" /> of directory catalogs.</returns>
        protected IEnumerable<DirectoryCatalog> GetDirectoryCatalogs(string path)
        {
            {
                Lokad.Enforce.Argument(() => path);
                Lokad.Enforce.Argument(() => path, Lokad.Rules.StringIs.NotEmpty);
            }

            List<DirectoryCatalog> list = new List<DirectoryCatalog>();

            // list.Add(new DirectoryCatalog(path));

            // list.AddRange(
            // Directory.GetDirectories(path).Select(directory => new DirectoryCatalog(directory)));
            return list;
        }

        private void Initialize()
        {
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        /// <summary>
        /// Maps the specified virtual path.
        /// </summary>
        /// <param name="virtualPath">The virtual path to map.</param>
        /// <returns>The specified virtual path as a mapped path.</returns>
        protected string MapPath(string virtualPath)
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
        private void PreCompose()
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

        private void RegisterAreas()
        {
            if ((AreaRegistrars == null) || (AreaRegistrars.Count() == 0))
            {
                return;
            }

            // Stolen from the dissassembled code of the AreaRegistration class
            foreach (var registrar in AreaRegistrars)
            {
                var context = new AreaRegistrationContext(registrar.AreaName, RouteTable.Routes, null);
                var ns = registrar.GetType().Namespace;
                context.Namespaces.Add(ns + ".*");
                registrar.RegisterArea(context);
            }
        }

        /// <summary>
        /// Registers any routes required by the application.
        /// </summary>
        private void RegisterRoutes()
        {
            if (RouteRegistrars == null || RouteRegistrars.Count() == 0)
            {
                return;
            }

            var routes = RouteTable.Routes;

            var registrars = RouteRegistrars
                .OrderBy(lazy => lazy.Metadata.Order)
                .Select(lazy => lazy.Value);

            registrars.ForEach(r => r.RegisterIgnoreRoutes(routes));
            registrars.ForEach(r => r.RegisterRoutes(routes));
        }

        /// <summary>
        /// Gets or sets the collection that contains the route registration instances.
        /// </summary>
        [ImportMany]
        public IEnumerable<Lazy<IRouteRegistrar, IRouteRegistrarMetadata>> RouteRegistrars
        {
            get;
            set;
        }
    }
}
