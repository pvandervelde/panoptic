//-----------------------------------------------------------------------
// <copyright company="Panoptic">
//     Copyright 2013 Panoptic. Licensed under the Apache License, Version 2.0.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel.Composition;
using Panoptic.UI.Web.Areas.Ops.Controllers;
using Panoptic.UI.Web.Areas.Ops.Properties;
using Panoptic.UI.Web.Common.Areas;

namespace Panoptic.UI.Web.Areas.Ops
{
    /// <summary>
    /// Provides the area description for the Ops area.
    /// </summary>
    [Export(typeof(IAreaDescription))]
    [ExportMetadata(AreaCategories.Category, AreaCategories.Description)]
    public class OpsAreaDescription : IAreaDescription
    {
        /// <summary>
        /// Gets the action.
        /// </summary>
        public string Action
        {
            get
            {
                return "Index";
            }
        }

        /// <summary>
        /// Gets the controller that provides the entry point for the area.
        /// </summary>
        public string Controller
        {
            get
            {
                return nameof(HomeController).Substring(
                    0,
                    nameof(HomeController).IndexOf("Controller"));
            }
        }

        /// <summary>
        /// Gets the description of the area.
        /// </summary>
        public string Description
        {
            get
            {
                return Resources.AreaDescription_Description;
            }
        }

        /// <summary>
        /// Gets the ID of the area.
        /// </summary>
        public string Id
        {
            get
            {
                return "Ops";
            }
        }

        /// <summary>
        /// Gets the name of the area.
        /// </summary>
        public string Name
        {
            get
            {
                return Resources.AreaDescription_Name;
            }
        }
    }
}