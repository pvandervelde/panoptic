//-----------------------------------------------------------------------
// <copyright company="Panoptic">
//     Copyright 2013 Panoptic. Licensed under the Apache License, Version 2.0.
// </copyright>
//-----------------------------------------------------------------------

using System.Web.Routing;

namespace Panoptic.UI.Web.Common.Routes
{
    /// <summary>
    /// Defines the contract for implementing a registrar to publish routes.
    /// </summary>
    public interface IRouteRegistrar
    {
        /// <summary>
        /// Registers any routes to be ignored by the routing system.
        /// </summary>
        /// <param name="routes">The collection of routes to add to.</param>
        void RegisterIgnoreRoutes(RouteCollection routes);

        /// <summary>
        /// Registers any routes to be used by the routing system.
        /// </summary>
        /// <param name="routes">The collection of routes to add to.</param>
        void RegisterRoutes(RouteCollection routes);
    }
}
