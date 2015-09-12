using System.Web.Routing;

namespace Panoptic.Web.Server.Common.Initialization
{
    /// <summary>
    /// Defines the interface for classes that define ASP MVC routes.
    /// </summary>
    public interface IRouteConfig
    {
        /// <summary>
        /// Registers the routes with the route collection.
        /// </summary>
        /// <param name="routes">The collection of routes.</param>
        void RegisterRoutes(RouteCollection routes);
    }
}
