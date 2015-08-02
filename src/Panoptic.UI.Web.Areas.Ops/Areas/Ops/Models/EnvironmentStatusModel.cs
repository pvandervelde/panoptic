//-----------------------------------------------------------------------
// <copyright company="Panoptic">
//     Copyright 2013 Panoptic. Licensed under the Apache License, Version 2.0.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;

namespace Panoptic.UI.Web.Areas.Ops.Models
{
    /// <summary>
    /// Stores information about an operation environment.
    /// </summary>
    public sealed class EnvironmentStatusModel
    {
        /// <summary>
        /// Gets or sets the description of the environment.
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the collection containing the machine statuses.
        /// </summary>
        public IEnumerable<MachineStatusModel> Machines
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name of the environment.
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the collection containing the service statuses.
        /// </summary>
        public IEnumerable<ServiceStatusModel> Services
        {
            get;
            set;
        }
    }
}
