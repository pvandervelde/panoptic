//-----------------------------------------------------------------------
// <copyright company="Panoptic">
//     Copyright 2013 Panoptic. Licensed under the Apache License, Version 2.0.
// </copyright>
//-----------------------------------------------------------------------

namespace Panoptic.UI.Web.Common.Areas
{
    /// <summary>
    /// Defines metadata associated with an action verb.
    /// </summary>
    public interface IAreaDescriptionMetadata
    {
        /// <summary>
        /// Gets the category for the verb.
        /// </summary>
        string Category
        {
            get;
        }
    }
}
