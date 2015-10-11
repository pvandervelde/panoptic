using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Panoptic.Web.Server.Common.Controllers;

namespace Panoptic.Web.Server.Areas.Teams.Dev.Controllers
{
    /// <summary>
    /// The controller that provides information about the platform team.
    /// </summary>
    [ExportController(typeof(DevelopmentDescriptionController))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("api/v1/teams/development")]
    public class DevelopmentDescriptionController : ApiController
    {
        /// <summary>
        /// Returns the name and description for the development team.
        /// </summary>
        /// <param name="id">The name of the development team for which the description should be retrieved.</param>
        /// <returns>An HTTP action result containing the name and description for the development team.</returns>
        [ResponseType(typeof(IHttpActionResult))]
        [Route("description/{id}")]
        [HttpGet]
        public IHttpActionResult Description(string id)
        {
            var descr = new
            {
                Name = id,
                Description = string.Format("An instant overview of the status of the work done by the {0} team.", id),
            };

            return Ok(descr);
        }
    }
}
