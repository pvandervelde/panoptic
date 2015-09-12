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
        /// Gets the name of the angular controller that will be used to display
        /// the area information.
        /// </summary>
        string AngularController
        {
            get;
        }

        /// <summary>
        /// Gets the path to the html template that will be used by the angular controller
        /// to display the area information.
        /// </summary>
        string AngularTemplateUri
        {
            get;
        }

        /// <summary>
        /// Gets the relative path to the area.
        /// </summary>
        string AreaPath
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
        /// Gets the name.
        /// </summary>
        string Name
        {
            get;
        }
    }
}
