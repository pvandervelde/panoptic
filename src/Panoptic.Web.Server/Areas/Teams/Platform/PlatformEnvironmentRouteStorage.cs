using System.Collections.Generic;
using System.ComponentModel.Composition;
using Panoptic.Web.Server.Common;

namespace Panoptic.Web.Server.Areas.Teams.Platform
{
    /// <summary>
    /// The route description for the platform team environment pages.
    /// </summary>
    [Export(typeof(IRouteDescriptionStorage))]
    public class PlatformEnvironmentRouteStorage : IRouteDescriptionStorage
    {
        private sealed class PlatformEvironmentRouteDescription : IRouteDescription
        {
            /// <summary>
            /// Gets the name of the angular controller that will be used to display
            /// the area information.
            /// </summary>
            public string AngularController
            {
                get
                {
                    return "PlatformTeamEnvironmentController";
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
                    return "teams/platform/views/environment.html";
                }
            }

            /// <summary>
            /// Gets the relative path to the area.
            /// </summary>
            public string AngularRouteTemplate
            {
                get
                {
                    return "platformteam/environment/:id";
                }
            }
        }

        /// <summary>
        /// Returns the collection containing all the route descriptions for the current storage.
        /// </summary>
        /// <returns>The collection of route descriptions.</returns>
        public IEnumerable<IRouteDescription> Routes()
        {
            return new List<IRouteDescription> { new PlatformEvironmentRouteDescription() };
        }
    }
}