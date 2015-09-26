using System.ComponentModel.Composition;
using System.Web.Mvc;
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
        /// <summary>
        /// GET: Index
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.Title = "Panoptic";
            return View();
        }
    }
}