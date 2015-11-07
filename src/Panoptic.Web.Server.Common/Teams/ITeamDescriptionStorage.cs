using System.Collections.Generic;

namespace Panoptic.Web.Server.Common.Teams
{
    /// <summary>
    /// Stores one or more team descriptions.
    /// </summary>
    public interface ITeamDescriptionStorage
    {
        /// <summary>
        /// Returns the collection containing all the team descriptions for the current storage.
        /// </summary>
        /// <returns>The collection of team descriptions.</returns>
        IEnumerable<ITeamDescription> Teams();
    }
}
