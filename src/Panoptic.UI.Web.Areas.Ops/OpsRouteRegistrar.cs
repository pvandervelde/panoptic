//-----------------------------------------------------------------------
// <copyright company="Panoptic">
//     Copyright 2013 Panoptic. Licensed under the Apache License, Version 2.0.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel.Composition;
using System.Web.Mvc;
using System.Web.Routing;
using Panoptic.UI.Web.Common.Routes;

namespace Panoptic.UI.Web.Areas.Ops
{
    /// <summary>
    /// Registers the MVC routes for the Ops area.
    /// </summary>
    [Export(typeof(IRouteRegistrar)), ExportMetadata("Order", 50)]
    public sealed class OpsRouteRegistrar : IRouteRegistrar
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
                name: "Ops_default",
                url: "Ops/{controller}/{action}/{id}",
                defaults: new { area = "Ops", controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Panoptic.UI.Web.Areas.Ops.Controllers" });
        }
    }
}