using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using Panoptic.Web.Server.Common;

namespace Panoptic.Web.Server.Areas.Teams.Dev
{
    [Export(typeof(IRouteDescriptionStorage))]
    public sealed class DevelopmentTeamRouteDescriptionStorage : IRouteDescriptionStorage
    {
        private sealed class DevelopmentTeamRouteDescription : IRouteDescription
        {
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
            public string AngularRouteTemplate
            {
                get
                {
                    return "developmentteam/:id";
                }
            }
        }


        /// <summary>
        /// Returns the collection containing all the route descriptions for the current storage.
        /// </summary>
        /// <returns>The collection of route descriptions.</returns>
        public IEnumerable<IRouteDescription> Routes()
        {
            return new List<IRouteDescription>
            {
                new DevelopmentTeamRouteDescription()
            };
        }
    }
}