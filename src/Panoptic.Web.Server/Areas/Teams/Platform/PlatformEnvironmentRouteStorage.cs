using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using Panoptic.Web.Server.Common;

namespace Panoptic.Web.Server.Areas.Teams.Platform
{
    /// <summary>
    /// The area description for the ops area.
    /// </summary>
    [Export(typeof(IRouteDescriptionStorage))]
    public class PlatformEnvironmentRouteStorage : IRouteDescriptionStorage
    {
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