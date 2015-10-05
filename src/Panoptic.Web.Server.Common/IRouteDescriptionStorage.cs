using System.Collections.Generic;

namespace Panoptic.Web.Server.Common
{
    /// <summary>
    /// Stores one or more <see cref="IRouteDescription"/> instances.
    /// </summary>
    public interface IRouteDescriptionStorage
    {
        /// <summary>
        /// Returns the collection containing all the route descriptions for the current storage.
        /// </summary>
        /// <returns>The collection of route descriptions.</returns>
        IEnumerable<IRouteDescription> Routes();
    }
}
