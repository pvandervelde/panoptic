﻿//-----------------------------------------------------------------------
// <copyright company="Panoptic">
//     Copyright 2013 Panoptic. Licensed under the Apache License, Version 2.0.
// </copyright>
//-----------------------------------------------------------------------

namespace Panoptic.UI.Web.Common.Controllers
{
    /// <summary>
    /// Defines the contract for providing metadata for a controller.
    /// </summary>
    public interface IControllerMetadata
    {
        /// <summary>
        /// Gets the name of the controller.
        /// </summary>
        string Name
        {
            get;
        }
    }
}