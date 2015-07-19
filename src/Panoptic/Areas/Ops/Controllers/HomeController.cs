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
using Panoptic.Areas.Ops.Models;

namespace Panoptic.Areas.Ops.Controllers
{
    /// <summary>
    /// Provides the index page for the ops area.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// GET: Ops/Home
        /// </summary>
        /// <returns>The index view.</returns>
        public ActionResult Index()
        {
            var environments = new List<EnvironmentStatusModel>
            {
                new EnvironmentStatusModel
                {
                    Name = "Production",
                    Services = new List<ServiceStatusModel>
                    {
                        new ServiceStatusModel
                        {
                            Name = "Service 1",
                            Status = "OK",
                            Notification = string.Empty,
                        },
                        new ServiceStatusModel
                        {
                            Name = "Service 2",
                            Status = "Warning",
                            Notification = "Eheeehehehehe",
                        },
                        new ServiceStatusModel
                        {
                            Name = "Service 3",
                            Status = "Error",
                            Notification = "Panic!",
                        },
                    },
                },
                new EnvironmentStatusModel
                {
                    Name = "Staging",
                    Services = new List<ServiceStatusModel>
                    {
                        new ServiceStatusModel
                        {
                            Name = "Service 1",
                            Status = "OK",
                            Notification = string.Empty,
                        },
                        new ServiceStatusModel
                        {
                            Name = "Service 2",
                            Status = "Warning",
                            Notification = "Eheeehehehehe",
                        },
                        new ServiceStatusModel
                        {
                            Name = "Service 3",
                            Status = "Error",
                            Notification = "Panic!",
                        },
                    },
                },
            };
            var model = new OpsModel
            {
                Name = "Ops",
                Description = "Watching your servers",
                EnvironmentStatus = environments,
            };

            return View(model);
        }
    }
}
