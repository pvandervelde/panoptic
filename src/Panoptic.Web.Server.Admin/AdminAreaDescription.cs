using System.ComponentModel.Composition;
using Panoptic.Web.Server.Common.Areas;
using Panoptic.Web.Server.Admin.Controllers;
using Panoptic.Web.Server.Common.Controllers;

namespace Panoptic.Web.Server.Admin
{
    /// <summary>
    /// The area description for the admin controller.
    /// </summary>
    [Export(typeof(IAreaDescription))]
    public class AdminAreaDescription : IAreaDescription
    {
        /// <summary>
        /// Gets the name of the angular controller that will be used to display
        /// the area information.
        /// </summary>
        public string AngularController
        {
            get
            {
                return "AdminController";
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
                return "admin";
            }
        }

        /// <summary>
        /// Gets the description.
        /// </summary>
        public string Description
        {
            get
            {
                return "Provides access to the administration part of the site.";
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name
        {
            get
            {
                return "Admin";
            }
        }
    }
}