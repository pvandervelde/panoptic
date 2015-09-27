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
    [ExportController(typeof(PlatformEnvironmentController))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("api/v1/teams/platform/environment")]
    public class PlatformEnvironmentController : ApiController
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

            var productionServices = new List<object>
            {
                new
                {
                    Name = "Service 1",
                    Status = "Ok"
                },
                new
                {
                    Name = "Service 2",
                    Status = "Warning"
                },
                new
                {
                    Name = "Service 3",
                    Status = "Error"
                },
                new
                {
                    Name = "Service 4",
                    Status = "Ok"
                },
                new
                {
                    Name = "Service 5",
                    Status = "Ok"
                },
            };
            var productionEnvironment = new
            {
                Name = "Production",
                Services = productionServices.ToArray(),
            };
            list.Add(productionEnvironment);

            var stagingServices = new List<object>
            {
                new
                {
                    Name = "Service 1",
                    Status = "Ok"
                },
                new
                {
                    Name = "Service 2",
                    Status = "Ok"
                },
                new
                {
                    Name = "Service 3",
                    Status = "Ok"
                },
                new
                {
                    Name = "Service 4",
                    Status = "Ok"
                },
                new
                {
                    Name = "Service 5",
                    Status = "Ok"
                },
            };
            var stagingEnvironment = new
            {
                Name = "Staging",
                Services = stagingServices.ToArray(),
            };

            list.Add(stagingEnvironment);

            return Ok(list.ToArray());
        }
    }
}
