using System.Collections.Generic;
using System.ComponentModel.Composition;
using Panoptic.Web.Server.Common;
using Panoptic.Web.Server.Common.Teams;

namespace Panoptic.Web.Server.Areas.Teams.Platform
{
    /// <summary>
    /// The area description for the platform team area.
    /// </summary>
    [Export(typeof(ITeamDescriptionStorage))]
    public class PlatformTeamDescriptionStorage : ITeamDescriptionStorage
    {
        private sealed class PlatformTeamDescription : ITeamDescription
        {
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
            /// Gets the relative URL to the team index page.
            /// </summary>
            public string IndexRelativeUrl
            {
                get
                {
                    return "platformteam";
                }
            }
        }

        /// <summary>
        /// Returns the collection containing all the team descriptions for the current storage.
        /// </summary>
        /// <returns>The collection of team descriptions.</returns>
        public IEnumerable<ITeamDescription> Teams()
        {
            return new List<ITeamDescription> { new PlatformTeamDescription() };
        }
    }
}