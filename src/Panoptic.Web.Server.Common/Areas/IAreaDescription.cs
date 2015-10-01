//-----------------------------------------------------------------------
// <copyright company="Panoptic">
//     Copyright 2013 Panoptic. Licensed under the Apache License, Version 2.0.
// </copyright>
//-----------------------------------------------------------------------

namespace Panoptic.Web.Server.Common.Areas
{
    /// <summary>
    /// Describes an area of capabilities.
    /// </summary>
    public interface IAreaDescription : IRouteDescription
    {
        /// <summary>
        /// Gets the description.
        /// </summary>
        string Description
        {
            get;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        string Name
        {
            get;
        }
    }
}
