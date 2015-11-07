using System.Collections.Generic;
using System.ComponentModel.Composition;
using Panoptic.Web.Server.Common.Teams;

namespace Panoptic.Web.Server.Areas.Teams.Dev
{
    /// <summary>
    /// The area description for the ops area.
    /// </summary>
    [Export(typeof(ITeamDescriptionStorage))]
    public class DevelopmentTeamDescriptionStorage : ITeamDescriptionStorage
    {
        private sealed class DevelopmentTeamDescription : ITeamDescription
        {
            private readonly string m_TeamName;

            public DevelopmentTeamDescription(string teamName)
            {
                m_TeamName = teamName;
            }

            /// <summary>
            /// Gets the description.
            /// </summary>
            public string Description
            {
                get
                {
                    return string.Format("Provides an overview of the status of the builds for the {0} team.", m_TeamName);
                }
            }

            /// <summary>
            /// Gets the name.
            /// </summary>
            public string Name
            {
                get
                {
                    return string.Format("{0} team", m_TeamName);
                }
            }

            /// <summary>
            /// Gets the relative URL to the team index page.
            /// </summary>
            public string IndexRelativeUrl
            {
                get
                {
                    return string.Format("developmentteam/{0}", m_TeamName);
                }
            }
        }

        /// <summary>
        /// Returns the collection containing all the team descriptions for the current storage.
        /// </summary>
        /// <returns>The collection of team descriptions.</returns>
        public IEnumerable<ITeamDescription> Teams()
        {
            return new List<ITeamDescription>
            {
                new DevelopmentTeamDescription("A"),
                new DevelopmentTeamDescription("B"),
                new DevelopmentTeamDescription("C")
            };
        }

        
    }
}