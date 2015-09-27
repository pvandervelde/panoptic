using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoptic.Web.Server.Common.Teams
{
    /// <summary>
    /// Describes a team.
    /// </summary>
    public interface ITeamDescription
    {
        /// <summary>
        /// Gets the name of the angular controller that will be used to display
        /// the team information.
        /// </summary>
        string AngularController
        {
            get;
        }

        /// <summary>
        /// Gets the path to the html template that will be used by the angular controller
        /// to display the team information.
        /// </summary>
        string AngularTemplateUri
        {
            get;
        }

        /// <summary>
        /// Gets the relative path to the team area.
        /// </summary>
        string AreaPath
        {
            get;
        }

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
