//-----------------------------------------------------------------------
// <copyright company="Panoptic">
//     Copyright 2013 Panoptic. Licensed under the Apache License, Version 2.0.
// </copyright>
//-----------------------------------------------------------------------

namespace Panoptic.UI.Web.Areas.Ops.Models
{
    /// <summary>
    /// Defines the status for a service.
    /// </summary>
    public enum ServiceStatus
    {
        /// <summary>
        /// The service status is OK.
        /// </summary>
        Ok,

        /// <summary>
        /// The service status is warning.
        /// </summary>
        Warning,

        /// <summary>
        /// The service status is error.
        /// </summary>
        Error
    }
}
