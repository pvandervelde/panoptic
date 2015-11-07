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
    [ExportController(typeof(DevelopmentBuildController))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("api/v1/teams/development")]
    public class DevelopmentBuildController : ApiController
    {
        /// <summary>
        /// Returns information about the different builds for the given development team.
        /// </summary>
        /// <param name="id">The name of the development team for which the builds should be retrieved.</param>
        /// <returns>An HTTP action result containing the information about the different builds.</returns>
        [ResponseType(typeof(IHttpActionResult))]
        [Route("build/{id}")]
        [HttpGet]
        public IHttpActionResult Builds(string id)
        {
            var list = new List<object>();

            for (var i = 0; i < 10; i++)
            {
                var status = "";
                switch (i % 3)
                {
                    case 0:
                        status = "Success";
                        break;
                    case 1:
                        status = "PartialSuccess";
                        break;
                    case 2:
                        status = "Failed";
                        break;
                    default:
                        break;
                }

                var build = new
                {
                    Name = string.Format("Build {0}", i + 1),
                    Status = status,
                    Url = "http://google.com"
                };
                list.Add(build);
            }

            return Ok(list.ToArray());
        }
    }
}
