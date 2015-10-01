using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Panoptic.Web.Server.Common;
using Panoptic.Web.Server.Common.Controllers;

namespace Panoptic.Web.Server.Areas.Home.Controllers
{
    /// <summary>
    /// The controller that provides information about the different routes for the application.
    /// </summary>
    [ExportController(typeof(RouteController))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("api/v1/home/route")]
    public class RouteController : ApiController
    {
        [ImportMany]
        internal IEnumerable<IRouteDescriptionStorage> RouteDescriptions
        {
            get;
            set;
        }

        /// <summary>
        /// Provides a way to get all known teams.
        /// </summary>
        /// <returns>An HTTP action result containing the list of all teams for the application.</returns>
        [ResponseType(typeof(IHttpActionResult))]
        [Route("")]
        [HttpGet]
        public IHttpActionResult Routes()
        {
            var list = new List<object>();
            foreach (var storage in RouteDescriptions)
            {
                foreach (var description in storage.Descriptions())
                {
                    var descr = new
                    {
                        Path = description.AreaPath,
                        Controller = description.AngularController,
                        TemplateUri = description.AngularTemplateUri,
                    };

                    list.Add(descr);
                }
            }

            return Ok(list.ToArray());
        }
    }
}
