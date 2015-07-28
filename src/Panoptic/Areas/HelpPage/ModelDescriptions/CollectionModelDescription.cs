//-----------------------------------------------------------------------
// <copyright company="Panoptic">
//     Copyright 2013 Panoptic. Licensed under the Apache License, Version 2.0.
// </copyright>
//-----------------------------------------------------------------------

namespace Panoptic.Areas.HelpPage.ModelDescriptions
{
    /// <summary>
    /// The description for the collection model.
    /// </summary>
    public class CollectionModelDescription : ModelDescription
    {
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public ModelDescription ElementDescription
        {
            get;
            set;
        }
    }
}
