using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Web.Http;
using System.Web.Http.Description;
using Panoptic.Web.Server.Common.Controllers;

namespace Panoptic.Web.Server.Areas.Teams.Platform.Controllers
{
    /// <summary>
    /// The controller that provides information about the work items for the platform team.
    /// </summary>
    [ExportController(typeof(PlatformWorkItemController))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("api/v1/teams/platform/work")]
    public class PlatformWorkItemController : ApiController
    {
        /// <summary>
        /// Returns information about the different work items.
        /// </summary>
        /// <returns>An HTTP action result containing the information about the different work items.</returns>
        [ResponseType(typeof(IHttpActionResult))]
        [Route("")]
        public IHttpActionResult Get()
        {
            var list = new List<object>();

            var openItems = new
            {
                Name = "Open",
                Total = 15,
                QueryUrl = "http://google.com"
            };
            list.Add(openItems);

            var inProgressItems = new
            {
                Name = "In Progress",
                Total = 15,
                QueryUrl = "http://google.com"
            };
            list.Add(inProgressItems);

            var closedItems = new
            {
                Name = "Done",
                Total = 135,
                QueryUrl = "http://google.com"
            };
            list.Add(closedItems);

            return Ok(list.ToArray());
        }
    }
}
