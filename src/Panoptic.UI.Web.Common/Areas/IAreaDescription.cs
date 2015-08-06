//-----------------------------------------------------------------------
// <copyright company="Panoptic">
//     Copyright 2013 Panoptic. Licensed under the Apache License, Version 2.0.
// </copyright>
//-----------------------------------------------------------------------

namespace Panoptic.UI.Web.Common.Areas
{
    /// <summary>
    /// Defines an action verb.
    /// </summary>
    public interface IAreaDescription
    {
        /// <summary>
        /// Gets the action.
        /// </summary>
        string Action
        {
            get;
        }

        /// <summary>
        /// Gets the controller that provides the entry point for the area.
        /// </summary>
        string Controller
        {
            get;
        }

        /// <summary>
        /// Gets the description of the area.
        /// </summary>
        string Description
        {
            get;
        }

        /// <summary>
        /// Gets the ID of the area.
        /// </summary>
        string Id
        {
            get;
        }

        /// <summary>
        /// Gets the name of the area.
        /// </summary>
        string Name
        {
            get;
        }
    }
}
