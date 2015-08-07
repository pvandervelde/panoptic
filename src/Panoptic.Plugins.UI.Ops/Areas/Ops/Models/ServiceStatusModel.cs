//-----------------------------------------------------------------------
// <copyright company="Panoptic">
//     Copyright 2013 Panoptic. Licensed under the Apache License, Version 2.0.
// </copyright>
//-----------------------------------------------------------------------

namespace Panoptic.Plugins.UI.Ops.Areas.Ops.Models
{
    /// <summary>
    /// Stores information about the status of a service.
    /// </summary>
    public sealed class ServiceStatusModel
    {
        /// <summary>
        /// Gets or sets the name of the service.
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the notification text.
        /// </summary>
        public string Notification
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the status text.
        /// </summary>
        public ServiceStatus Status
        {
            get;
            set;
        }
    }
}
