using System.ComponentModel.Composition;
using System.Web.Http;
using System.Web.Http.Description;
using Panoptic.Web.Server.Common.Controllers;

namespace Panoptic.Web.Server.Areas.Teams.Platform.Controllers
{
    /// <summary>
    /// The controller that provides information about the platform team.
    /// </summary>
    [ExportController(typeof(PlatformDescriptionController))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("api/v1/teams/platform/description")]
    public class PlatformDescriptionController : ApiController
    {
        /// <summary>
        /// Returns the name and description for the platform team.
        /// </summary>
        /// <returns>An HTTP action result containing the name and description for the platform team.</returns>
        [ResponseType(typeof(IHttpActionResult))]
        [Route("")]
        public IHttpActionResult Get()
        {
            var descr = new
            {
                Name = "Ops",
                Description = "An instant overview of the status of the different services" +
                    " and the status of the work done by the Platform team.",
            };

            return Ok(descr);
        }
    }
}
