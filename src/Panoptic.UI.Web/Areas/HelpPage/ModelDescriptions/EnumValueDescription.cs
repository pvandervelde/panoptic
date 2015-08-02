//-----------------------------------------------------------------------
// <copyright company="Panoptic">
//     Copyright 2013 Panoptic. Licensed under the Apache License, Version 2.0.
// </copyright>
//-----------------------------------------------------------------------

namespace Panoptic.Areas.HelpPage.ModelDescriptions
{
    /// <summary>
    /// The description of an enum value.
    /// </summary>
    public class EnumValueDescription
    {
        /// <summary>
        /// Gets or sets the documentation text.
        /// </summary>
        /// <value>
        /// The documentation text.
        /// </value>
        public string Documentation
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name of the value.
        /// </value>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public string Value
        {
            get;
            set;
        }
    }
}
