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
        /// Gets the action that is the entry action.
        /// </summary>
        public string Action
        {
            get
            {
                return nameof(AdminController.Get);
            }
        }

        /// <summary>
        /// Gets the controller that provides the entry point.
        /// </summary>
        public string Controller
        {
            get
            {
                return typeof(AdminController).ControllerName();
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
        /// Gets the version.
        /// </summary>
        public string Version
        {
            get
            {
                return "v1";
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