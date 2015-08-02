//-----------------------------------------------------------------------
// <copyright company="Panoptic">
//     Copyright 2013 Panoptic. Licensed under the Apache License, Version 2.0.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Panoptic.UI.Web.Areas.Services.Models;

namespace Panoptic.UI.Web.Areas.Services.Controllers
{
    /// <summary>
    /// Provides the index page for the services area.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// GET: Services/Home
        /// </summary>
        /// <returns>The index view.</returns>
        public ActionResult Index()
        {
            var model = new ServicesModel
            {
                Name = "Services",
                Description = "Providing your services.",
            };
            return View(model);
        }
    }
}