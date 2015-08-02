﻿// <copyright company="Panoptic">
//     Copyright 2013 Panoptic. Licensed under the Apache License, Version 2.0.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;

namespace Panoptic.UI.Web.Areas.Ops.Models
{
    /// <summary>
    /// Stores information about the status of the operations area.
    /// </summary>
    public sealed class OpsModel
    {
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the collection of environments.
        /// </summary>
        public IEnumerable<EnvironmentStatusModel> EnvironmentStatus
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the collection containing the issue information.
        /// </summary>
        public IEnumerable<IssueSetModel> Issues
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
        /// Gets or sets the collection containing the news items.
        /// </summary>
        public IEnumerable<NewsItemModel> NewsItems
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the collection of releases
        /// </summary>
        public IEnumerable<ReleaseModel> Releases
        {
            get;
            set;
        }
    }
}
