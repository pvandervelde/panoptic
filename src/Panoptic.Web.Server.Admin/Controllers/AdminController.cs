using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Web.Http;
using Panoptic.Web.Server.Common.Controllers;

namespace Panoptic.Web.Server.Admin.Controllers
{
    /// <summary>
    /// Defines the controller for the administration area.
    /// </summary>
    [Authorize]
    [ExportController(typeof(AdminController))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AdminController : ApiController
    {
        /// <summary>
        /// GET api/values
        /// </summary>
        /// <returns>The entry data for the admin area.</returns>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
