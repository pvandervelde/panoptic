using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Web.Http;
using System.Web.Http.Description;
using Panoptic.UI.Web.Common.Areas;

namespace Panoptic.Web.Server.Controllers
{
    /// <summary>
    /// The entry point controller for the application.
    /// </summary>
    public class HomeController : ApiController
    { 
        [ImportMany]
        internal IEnumerable<Lazy<IAreaDescription, IAreaDescriptionMetadata>> AreaDescriptions
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
                        Name = description.Value.Name,
                        Description = description.Value.Description,
                        Version = description.Value.Version,
                        Controller = description.Value.Controller,
                        Action = description.Value.Action,
                    };

                list.Add(descr);
            }

            var result = new
            {
                Product = "",
                Description = "",
                Areas = list.ToArray(),
            };
            
            return Ok(result);
        }
    }
}
