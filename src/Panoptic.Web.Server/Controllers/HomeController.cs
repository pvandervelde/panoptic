using System;
using System.Collections.Generic;
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
    [ExportController(typeof(HomeController))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class HomeController : ApiController
    { 
        [ImportMany]
        internal IEnumerable<IAreaDescription> AreaDescriptions
        {
            get;
            set;
        }

        /// <summary>
        /// /api/v1/home
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
                        Version = description.Version,
                        Controller = description.Controller,
                        Action = description.Action,
                    };

                list.Add(descr);
            }

            var result = new
            {
                Product = "Panoptic",
                Description = "Stuff",
                Areas = list.ToArray(),
            };
            
            return Ok(result);
        }
    }
}
