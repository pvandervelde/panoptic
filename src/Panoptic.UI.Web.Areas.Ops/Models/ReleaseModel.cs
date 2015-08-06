//-----------------------------------------------------------------------
// <copyright company="Panoptic">
//     Copyright 2013 Panoptic. Licensed under the Apache License, Version 2.0.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;

namespace Panoptic.UI.Web.Areas.Ops.Models
{
    /// <summary>
    /// Stores information about a release.
    /// </summary>
    public sealed class ReleaseModel
    {
        /// <summary>
        /// Gets or sets the date on which the release was made.
        /// </summary>
        [DisplayFormat(DataFormatString = "yyyy-MM-dd")]
        public DateTimeOffset Date
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        public Version Version
        {
            get;
            set;
        }
    }
}
