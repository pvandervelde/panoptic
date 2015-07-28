//-----------------------------------------------------------------------
// <copyright company="Panoptic">
//     Copyright 2013 Panoptic. Licensed under the Apache License, Version 2.0.
// </copyright>
//-----------------------------------------------------------------------

using System.Web.Mvc;

namespace Panoptic.Controllers
{
    /// <summary>
    /// The controller that handles the index page web calls.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Returns the index page.
        /// </summary>
        /// <returns>The index page.</returns>
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
