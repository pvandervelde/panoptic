using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using Panoptic.Web.Server.Composition;

namespace Panoptic.Web.Server
{
    /// <summary>
    /// Configures the MEF part of the web site.
    /// </summary>
    public static class MefConfig
    {
        /// <summary>
        /// Gets a set of <see cref="DirectoryCatalog" /> for the specified path and it's immediate child directories.
        /// </summary>
        /// <param name="path">The starting path.</param>
        /// <returns>An <see cref="IEnumerable{DirectoryCatalog}" /> of directory catalogs.</returns>
        private static IEnumerable<DirectoryCatalog> GetDirectoryCatalogs(string path)
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

        /// <summary>
        /// Registers the MEF section of the web site.
        /// </summary>
        /// <param name="assemblySearchPaths">The collection of assembly search paths.</param>
        /// <returns>The composition container that will be used to resolve all dependencies.</returns>
        public static CompositionContainer RegisterMef(IEnumerable<string> assemblySearchPaths)
        {
            var aggregate = new AggregateCatalog();
            var asmCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            aggregate.Catalogs.Add(asmCatalog);

            foreach (var searchPath in assemblySearchPaths)
            {
                var catalogs = GetDirectoryCatalogs(searchPath);
                catalogs.ForEach(aggregate.Catalogs.Add);
            }

            var container = new CompositionContainer(aggregate);
            var resolver = new MefDependencyResolver(container);

            // Install MEF dependency resolver for MVC
            DependencyResolver.SetResolver(resolver);

            // Install MEF dependency resolver for Web API
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
            ControllerBuilder.Current.SetControllerFactory(new MefControllerFactory(container));

            GlobalConfiguration.Configuration.Services.Replace(
                typeof(IAssembliesResolver), 
                new MefAssemblyResolver(assemblySearchPaths));

            return container;
        }
    }
}