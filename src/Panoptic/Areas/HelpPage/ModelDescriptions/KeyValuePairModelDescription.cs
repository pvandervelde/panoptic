//-----------------------------------------------------------------------
// <copyright company="Panoptic">
//     Copyright 2013 Panoptic. Licensed under the Apache License, Version 2.0.
// </copyright>
//-----------------------------------------------------------------------

namespace Panoptic.Areas.HelpPage.ModelDescriptions
{
    /// <summary>
    /// The model descriptor for key-value pairs.
    /// </summary>
    public class KeyValuePairModelDescription : ModelDescription
    {
        /// <summary>
        /// Gets or sets the description for the key.
        /// </summary>
        /// <value>
        /// The description for the key.
        /// </value>
        public ModelDescription KeyModelDescription
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the description for the value.
        /// </summary>
        /// <value>
        /// The description for the value.
        /// </value>
        public ModelDescription ValueModelDescription
        {
            get;
            set;
        }
    }
}
