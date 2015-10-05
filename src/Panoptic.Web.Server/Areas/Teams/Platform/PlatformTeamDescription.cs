using System.Collections.Generic;
using System.ComponentModel.Composition;
using Panoptic.Web.Server.Common;
using Panoptic.Web.Server.Common.Teams;

namespace Panoptic.Web.Server.Areas.Teams.Platform
{
    /// <summary>
    /// The area description for the ops area.
    /// </summary>
    [Export(typeof(ITeamDescriptionStorage))]
    [Export(typeof(IRouteDescriptionStorage))]
    public class PlatformTeamDescription : ITeamDescription, ITeamDescriptionStorage, IRouteDescriptionStorage
    {
        /// <summary>
        /// Gets the name of the angular controller that will be used to display
        /// the area information.
        /// </summary>
        public string AngularController
        {
            get
            {
                return "PlatformTeamController";
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
                return "teams/platform/views/platformteam.html";
            }
        }

        /// <summary>
        /// Gets the relative path to the area.
        /// </summary>
        public string AreaPath
        {
            get
            {
                return "platformteam";
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
                return "Platform team";
            }
        }

        /// <summary>
        /// Returns the collection containing all the team descriptions for the current storage.
        /// </summary>
        /// <returns>The collection of team descriptions.</returns>
        public IEnumerable<ITeamDescription> Teams()
        {
            return new List<ITeamDescription> { this };
        }

        /// <summary>
        /// Returns the collection containing all the route descriptions for the current storage.
        /// </summary>
        /// <returns>The collection of route descriptions.</returns>
        public IEnumerable<IRouteDescription> Routes()
        {
            return new List<IRouteDescription> { this };
        }
    }
}