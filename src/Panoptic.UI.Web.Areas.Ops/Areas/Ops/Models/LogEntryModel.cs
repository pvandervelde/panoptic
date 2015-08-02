//-----------------------------------------------------------------------
// <copyright company="Panoptic">
//     Copyright 2013 Panoptic. Licensed under the Apache License, Version 2.0.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Panoptic.UI.Web.Areas.Ops.Models
{
    /// <summary>
    /// Stores information about a log entry.
    /// </summary>
    public class LogEntryModel
    {
        /// <summary>
        /// Gets or sets the date and time the log entry was made.
        /// </summary>
        public DateTimeOffset Date
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the text for the log entry.
        /// </summary>
        public string Text
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the type of the log entry.
        /// </summary>
        public string Type
        {
            get;
            set;
        }
    }
}
