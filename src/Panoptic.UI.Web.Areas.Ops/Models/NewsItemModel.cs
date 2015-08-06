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
    /// Stores information about a news item.
    /// </summary>
    public class NewsItemModel
    {
        /// <summary>
        /// Gets or sets the date of the news item.
        /// </summary>
        [DisplayFormat(DataFormatString = "yyyy-MM-dd")]
        public DateTimeOffset Date
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the description of the news item.
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the summary of the news item.
        /// </summary>
        public string Summary
        {
            get;
            set;
        }
    }
}
