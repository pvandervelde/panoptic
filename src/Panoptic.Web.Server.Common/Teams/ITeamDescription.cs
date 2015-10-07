namespace Panoptic.Web.Server.Common.Teams
{
    /// <summary>
    /// Describes a team.
    /// </summary>
    public interface ITeamDescription
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

        /// <summary>
        /// Gets the relative URL to the team index page.
        /// </summary>
        string IndexRelativeUrl
        {
            get;
        }
    }
}
