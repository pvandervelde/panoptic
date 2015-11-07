using System.ComponentModel.Composition;
using System.Web.Mvc;
using System.Web.Routing;
using Panoptic.Web.Server.Common.Initialization;

namespace Panoptic.Web.Server
{
    /// <summary>
    /// Defines the configuration for ASP MVC routes.
    /// </summary>
    [Export(typeof(IRouteConfig))]
    public sealed class RouteConfig : IRouteConfig
    {
        /// <summary>
        /// Registers the routes with the route collection.
        /// </summary>
        /// <param name="routes">The collection of routes.</param>
        public void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("views/*");

            routes.MapRoute(
                name: "Default",
                url: "{*url}",
                defaults: new { controller = "Home", action = "Index" }
            );
        }
    }
}
