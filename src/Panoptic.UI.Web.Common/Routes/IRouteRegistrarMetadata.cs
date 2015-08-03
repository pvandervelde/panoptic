//-----------------------------------------------------------------------
// <copyright company="Panoptic">
//     Copyright 2013 Panoptic. Licensed under the Apache License, Version 2.0.
// </copyright>
//-----------------------------------------------------------------------

namespace Panoptic.UI.Web.Common.Routes
{
    /// <summary>
    /// Defines the contract for providing metadata for a route registrar.
    /// </summary>
    public interface IRouteRegistrarMetadata
    {
        /// <summary>
        /// Gets the order in which the registrar must be processed.
        /// </summary>
        int Order
        {
            get;
        }
    }
}
