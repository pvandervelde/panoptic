using System.Collections.Generic;
using System.ComponentModel.Composition;
using Panoptic.Web.Server.Common;
using Panoptic.Web.Server.Common.Areas;

namespace Panoptic.Web.Server.Areas.Admin
{
    /// <summary>
    /// The area description for the admin area.
    /// </summary>
    [Export(typeof(IAreaDescription))]
    [Export(typeof(IRouteDescriptionStorage))]
    public sealed class AdminAreaDescription : IAreaDescription, IRouteDescriptionStorage
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
                return "admin/views/admin.html";
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

        /// <summary>
        /// Returns the collection containing all the route descriptions for the current storage.
        /// </summary>
        /// <returns>The collection of route descriptions.</returns>
        public IEnumerable<IRouteDescription> Descriptions()
        {
            return new List<IRouteDescription> { this };
        }
    }
}