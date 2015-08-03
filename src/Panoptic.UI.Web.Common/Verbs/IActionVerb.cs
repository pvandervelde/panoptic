//-----------------------------------------------------------------------
// <copyright company="Panoptic">
//     Copyright 2013 Panoptic. Licensed under the Apache License, Version 2.0.
// </copyright>
//-----------------------------------------------------------------------

namespace Panoptic.UI.Web.Common.Verbs
{
    /// <summary>
    /// Defines an action verb.
    /// </summary>
    public interface IActionVerb
    {
        /// <summary>
        /// Gets the action.
        /// </summary>
        string Action
        {
            get;
        }

        /// <summary>
        /// Gets the controller.
        /// </summary>
        string Controller
        {
            get;
        }

        /// <summary>
        /// Gets the description of the verb.
        /// </summary>
        string Description
        {
            get;
        }

        /// <summary>
        /// Gets the name of the verb.
        /// </summary>
        string Name
        {
            get;
        }
    }
}
