using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Web.Mvc;
using Panoptic.Web.Server.Common;
using Panoptic.Web.Server.Common.Controllers;

namespace Panoptic.Web.Server.Controllers
{
    /// <summary>
    /// Defines the entry point controller.
    /// </summary>
    [ExportController(typeof(HomeController))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class HomeController : Controller
    {
        [ImportMany]
        internal IEnumerable<IRouteDescriptionStorage> RouteDescriptions
        {
            get;
            set;
        }

        /// <summary>
        /// GET: Index
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var list = new List<IRouteDescription>();
            foreach (var storage in RouteDescriptions)
            {
                foreach (var description in storage.Routes())
                {
                    list.Add(description);
                }
            }

            ViewBag.Title = "Panoptic";

            return View(list);
        }
    }
}