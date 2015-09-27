﻿using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Web.Http;
using System.Web.Http.Description;
using Panoptic.Web.Server.Common.Controllers;
using Panoptic.Web.Server.Common.Teams;

namespace Panoptic.Web.Server.Areas.Home.Controllers
{
    /// <summary>
    /// The controller that provides information about the different teams for the application.
    /// </summary>
    [ExportController(typeof(TeamController))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("api/v1/home/team")]
    public class TeamController : ApiController
    {
        [ImportMany]
        internal IEnumerable<ITeamDescription> TeamDescriptions
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
        public IHttpActionResult Teams()
        {
            var list = new List<object>();
            foreach (var description in TeamDescriptions)
            {
                var descr = new
                {
                    Name = description.Name,
                    Description = description.Description,
                    Path = description.AreaPath,
                    Controller = description.AngularController,
                    TemplateUri = description.AngularTemplateUri,
                };

                list.Add(descr);
            }

            return Ok(list.ToArray());
        }
    }
}
