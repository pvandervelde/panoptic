namespace Panoptic.Web.Server.Common.Teams
{
    /// <summary>
    /// Describes a team.
    /// </summary>
    public interface ITeamDescription : IRouteDescription
    {
        /// <summary>
        /// Gets the description.
        /// </summary>
        string Description
        {
            get;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        string Name
        {
            get;
        }
    }
}
