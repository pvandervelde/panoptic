using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using Panoptic.Web.Server.Common.Areas;

namespace Panoptic.Web.Server.Ops
{
    /// <summary>
    /// The area description for the ops area.
    /// </summary>
    [Export(typeof(IAreaDescription))]
    public class OpsAreaDescription : IAreaDescription
    {
        /// <summary>
        /// Gets the name of the angular controller that will be used to display
        /// the area information.
        /// </summary>
        public string AngularController
        {
            get
            {
                return "OpsController";
            }
        }

        /// <summary>
        /// Gets the path to the html template that will be used by the angular controller
        /// to display the area information.
        /// </summary>
        public string AngularTemplateUri
        {
            get
            {
                return "";
            }
        }

        /// <summary>
        /// Gets the relative path to the area.
        /// </summary>
        public string AreaPath
        {
            get
            {
                return "ops";
            }
        }

        /// <summary>
        /// Gets the description.
        /// </summary>
        public string Description
        {
            get
            {
                return "Provides an overview of the status of the infrastructure and the work being done by the Platform team.";
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name
        {
            get
            {
                return "Ops";
            }
        }
    }
}