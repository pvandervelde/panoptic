//-----------------------------------------------------------------------
// <copyright company="Panoptic">
//     Copyright 2013 Panoptic. Licensed under the Apache License, Version 2.0.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel.Composition;
using System.Web.Mvc;
using System.Web.Routing;
using Panoptic.UI.Web.Common.Routes;

namespace Panoptic.UI.Web.App_Start
{
    /// <summary>
    /// Registers the default MVC routes.
    /// </summary>
    [Export(typeof(IRouteRegistrar)), ExportMetadata("Order", 100)]
    public class DefaultRouteRegistrar : IRouteRegistrar
    {
        /// <summary>
        /// Registers any routes to be ignored by the routing system.
        /// </summary>
        /// <param name="routes">The collection of routes to add to.</param>
        public void RegisterIgnoreRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{resource}.ico/{*pathInfo}");
        }

        /// <summary>
        /// Registers any routes to be used by the routing system.
        /// </summary>
        /// <param name="routes">The collection of routes to add to.</param>
        public void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Panoptic.UI.Web.Controllers" });
        }
    }
}
