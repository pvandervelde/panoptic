using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Web.Http;
using System.Web.Http.Description;
using Panoptic.Web.Server.Common.Controllers;

namespace Panoptic.Web.Server.Areas.Teams.Platform.Controllers
{
    /// <summary>
    /// The controller that provides information about the platform team environments for the application.
    /// </summary>
    [ExportController(typeof(PlatformReleaseController))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("api/v1/teams/platform/release")]
    public class PlatformReleaseController : ApiController
    {
        /// <summary>
        /// Returns information about the different environments.
        /// </summary>
        /// <returns>An HTTP action result containing the information about the different environments.</returns>
        [ResponseType(typeof(IHttpActionResult))]
        [Route("")]
        public IHttpActionResult Get()
        {
            var list = new List<object>();

            for (var i = 0; i < 10; i++)
            {
                var releaseItem = new
                {
                    Name = string.Format("Tool {0}", i),
                    Version = string.Format("1.{0}.7", i),
                    ReleaseDate = new DateTime(2015, i + 1, 25).ToShortDateString(),
                    DeployDate = new DateTime(2015, i + 1, 26).ToShortDateString(),
                };

                list.Add(releaseItem);
            }

            return Ok(list.ToArray());
        }
    }
}
