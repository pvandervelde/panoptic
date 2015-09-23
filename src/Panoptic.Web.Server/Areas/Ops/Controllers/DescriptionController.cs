using System.ComponentModel.Composition;
using System.Web.Http;
using System.Web.Http.Description;
using Panoptic.Web.Server.Common.Controllers;

namespace Panoptic.Web.Server.Areas.Ops.Controllers
{
    /// <summary>
    /// The controller that provides information about ops area for the application.
    /// </summary>
    [ExportController(typeof(DescriptionController))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("api/v1/ops/description")]
    public class DescriptionController : ApiController
    {
        /// <summary>
        /// Returns the name and description for the ops area.
        /// </summary>
        /// <returns>An HTTP action result containing the name and description for the ops area.</returns>
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
