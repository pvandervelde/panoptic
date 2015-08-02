//-----------------------------------------------------------------------
// <copyright company="Panoptic">
//     Copyright 2013 Panoptic. Licensed under the Apache License, Version 2.0.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Panoptic.UI.Web.Areas.Services.Models
{
    /// <summary>
    /// Stores information about the available services.
    /// </summary>
    public sealed class ServicesModel
    {
        /// <summary>
        /// Gets or sets the description for the model.
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name of the model.
        /// </summary>
        public string Name
        {
            get;
            set;
        }
    }
}
