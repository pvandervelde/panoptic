using System.ComponentModel.Composition;
using System.Web.Http;
using System.Web.Http.Description;
using Panoptic.Web.Server.Common.Controllers;

namespace Panoptic.Web.Server.Areas.Home.Controllers
{
    /// <summary>
    /// The controller that provides information about home area for the application.
    /// </summary>
    [ExportController(typeof(HomeDescriptionController))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("api/v1/home/description")]
    public class HomeDescriptionController : ApiController
    {
        /// <summary>
        /// Returns the name and description for the home area.
        /// </summary>
        /// <returns>An HTTP action result containing the name and description for the home area.</returns>
        [ResponseType(typeof(IHttpActionResult))]
        [Route("")]
        [HttpGet]
        public IHttpActionResult Description()
        {
            var descr = new
            {
                Name = "Home",
                Description = "Welcome to the team dashboards." +
                    " Here you can find out more about the status of the different dev teams",
            };

            return Ok(descr);
        }
    }
}
