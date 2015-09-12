﻿using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Web.Http;
using System.Web.Http.Description;
using Panoptic.Web.Server.Common.Areas;
using Panoptic.Web.Server.Common.Controllers;

namespace Panoptic.Web.Server.Controllers
{
    /// <summary>
    /// The entry point controller for the application.
    /// </summary>
    [ExportController(typeof(AreaController))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AreaController : ApiController
    { 
        [ImportMany]
        internal IEnumerable<IAreaDescription> AreaDescriptions
        {
            get;
            set;
        }

        /// <summary>
        /// /api/v1/area
        /// </summary>
        /// <returns>An HTTP action result containing the list of all areas for the application.</returns>
        [ResponseType(typeof(string))]
        public IHttpActionResult Get()
        {
            var list = new List<object>();
            foreach (var description in AreaDescriptions)
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
