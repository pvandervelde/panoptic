﻿//-----------------------------------------------------------------------
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
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Panoptic.UI.Web.Common.Routes;
using Panoptic.UI.Web.Common.Verbs;
using Panoptic.UI.Web.Composition;
using Panoptic.UI.Web.Configuration;

namespace Panoptic.UI.Web
{
    /// <summary>
    /// The entry point of the web application.
    /// </summary>
    public class WebApiApplication : HttpApplication
    {
        private static IEnumerable<Lazy<IActionVerb, IActionVerbMetadata>> s_ActionVerbs;

        /// <summary>
        /// Gets the <see cref="Composer" /> used to compose parts.
        /// </summary>
        public static Composer Composer
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the available verbs for the given category.
        /// </summary>
        /// <param name="category">The category of verbs to get.</param>
        /// <returns>An enumerable of verbs.</returns>
        public static IEnumerable<IActionVerb> GetVerbsForCategory(string category)
        {
            {
                Lokad.Enforce.Argument(() => category);
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

            // Register MVC routes.
            RegisterRoutes();
        }

        /// <summary>
        /// Creates a <see cref="Composer" /> used to compose parts.
        /// </summary>
        /// <returns>The new composer</returns>
        private Composer CreateComposer()
        {
            var composer = new Composer();

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

            s_ActionVerbs = Composer.ResolveAll<IActionVerb, IActionVerbMetadata>();
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
            string applicationPath = MapPath("~/");

            foreach (var catalog in GetDirectoryCatalogs(MapPath("~/bin")))
            {
                list.Add(catalog);
            }

            foreach (var catalog in GetDirectoryCatalogs(MapPath("~/Areas")))
            {
                list.Add(catalog);
                RegisterPath(catalog.FullPath);
            }

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

                            foreach (var catalog in GetDirectoryCatalogs(path))
                            {
                                list.Add(catalog);
                                RegisterPath(catalog.FullPath);
                            }
                        }
                    });
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
            list.Add(new DirectoryCatalog(path));

            list.AddRange(
                Directory.GetDirectories(path).Select(directory => new DirectoryCatalog(directory)));

            return list;
        }

        private void Initialize()
        {
            AreaRegistration.RegisterAllAreas();
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
        }

        /// <summary>
        /// Registers the specified path for probing.
        /// </summary>
        /// <param name="path">The probable path.</param>
        private void RegisterPath(string path)
        {
            AppDomain.CurrentDomain.AppendPrivatePath(path);
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
