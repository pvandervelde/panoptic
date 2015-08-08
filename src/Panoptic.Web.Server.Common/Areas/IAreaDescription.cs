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
    public interface IAreaDescription
    {
        /// <summary>
        /// Gets the action that is the entry action.
        /// </summary>
        string Action
        {
            get;
        }

        /// <summary>
        /// Gets the controller that provides the entry point.
        /// </summary>
        string Controller
        {
            get;
        }

        /// <summary>
        /// Gets the description.
        /// </summary>
        string Description
        {
            get;
        }

        /// <summary>
        /// Gets the version.
        /// </summary>
        string Version
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
