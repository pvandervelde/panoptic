//-----------------------------------------------------------------------
// <copyright company="Panoptic">
//     Copyright 2013 Panoptic. Licensed under the Apache License, Version 2.0.
// </copyright>
//-----------------------------------------------------------------------

namespace Panoptic.Plugins.UI.Ops.Areas.Ops.Models
{
    /// <summary>
    /// Stores information about a set of issues.
    /// </summary>
    public class IssueSetModel
    {
        /// <summary>
        /// Gets or sets the number of issues
        /// </summary>
        public int Count
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name of the issue set.
        /// </summary>
        public string Name
        {
            get;
            set;
        }
    }
}
