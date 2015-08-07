using System.ComponentModel.Composition.Hosting;
using System.Reflection;
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
        /// Registers the MEF section of the web site.
        /// </summary>
        public static void RegisterMef()
        {
            var asmCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var container = new CompositionContainer(asmCatalog);
            var resolver = new MefDependencyResolver(container);

            // Install MEF dependency resolver for MVC
            DependencyResolver.SetResolver(resolver);
            
            // Install MEF dependency resolver for Web API
            System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}