using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using Panoptic.Web.Server.Common;
using Panoptic.Web.Server.Common.Teams;

namespace Panoptic.Web.Server.Areas.Teams.Dev
{
    /// <summary>
    /// The area description for the ops area.
    /// </summary>
    [Export(typeof(ITeamDescriptionStorage))]
    [Export(typeof(IRouteDescriptionStorage))]
    public class DevelopmentTeamDescriptionStorage : ITeamDescriptionStorage, IRouteDescriptionStorage
    {
        private sealed class DevelopmentTeamDescription : ITeamDescription
        {
            private readonly string m_TeamName;

            public DevelopmentTeamDescription(string teamName)
            {
                m_TeamName = teamName;
            }

            /// <summary>
            /// Gets the name of the angular controller that will be used to display
            /// the area information.
            /// </summary>
            public string AngularController
            {
                get
                {
                    return "DevelopmentTeamController";
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
                    return "teams/development/views/developmentteam.html";
                }
            }

            /// <summary>
            /// Gets the relative path to the area.
            /// </summary>
            public string AreaPath
            {
                get
                {
                    return "developmentteam/:id";
                }
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

        /// <summary>
        /// Returns the collection containing all the route descriptions for the current storage.
        /// </summary>
        /// <returns>The collection of route descriptions.</returns>
        public IEnumerable<IRouteDescription> Routes()
        {
            return new List<IRouteDescription> { };
        }
    }
}