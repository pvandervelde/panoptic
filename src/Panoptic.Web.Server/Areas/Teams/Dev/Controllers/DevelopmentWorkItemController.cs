using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Web.Http;
using System.Web.Http.Description;
using Panoptic.Web.Server.Common.Controllers;

namespace Panoptic.Web.Server.Areas.Teams.Dev.Controllers
{
    /// <summary>
    /// The controller that provides information about the work items for the platform team.
    /// </summary>
    [ExportController(typeof(DevelopmentWorkItemController))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("api/v1/teams/development/work")]
    public class DevelopmentWorkItemController : ApiController
    {
        /// <summary>
        /// Returns information about the different work items.
        /// </summary>
        /// <param name="id">The name of the development team for which the work items should be retrieved.</param>
        /// <returns>An HTTP action result containing the information about the different work items.</returns>
        [ResponseType(typeof(IHttpActionResult))]
        [Route("items/{id}")]
        [HttpGet]
        public IHttpActionResult WorkItems(string id)
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

        /// <summary>
        /// Returns information about the burndown for the given development team.
        /// </summary>
        /// <param name="id">The name of the development team for which the burn down information should be retrieved.</param>
        /// <returns>An HTTP action result containing the information about the burn down.</returns>
        [ResponseType(typeof(IHttpActionResult))]
        [Route("burndown/{id}")]
        [HttpGet]
        public IHttpActionResult BurnDown(string id)
        {
            var burnDown = new
            {
                Name = id,
                BurnDown = new object[]
                    {
                        new
                        {
                            Time = 0,
                            Count = 100
                        },
                        new
                        {
                            Time = 10,
                            Count = 95
                        },
                        new
                        {
                            Time = 20,
                            Count = 55
                        },
                        new
                        {
                            Time = 30,
                            Count = 45
                        },
                        new
                        {
                            Time = 40,
                            Count = 15
                        }
                    }
            };

            return Ok(burnDown);
        }
    }
}
