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
                            Status = ServiceStatus.Ok,
                            Notification = string.Empty,
                        },
                        new ServiceStatusModel
                        {
                            Name = "Service 2",
                            Status = ServiceStatus.Warning,
                            Notification = "Eheeehehehehe",
                        },
                        new ServiceStatusModel
                        {
                            Name = "Service 3",
                            Status = ServiceStatus.Error,
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
                            Status = ServiceStatus.Ok,
                            Notification = string.Empty,
                        },
                        new ServiceStatusModel
                        {
                            Name = "Service 2",
                            Status = ServiceStatus.Warning,
                            Notification = "Eheeehehehehe",
                        },
                        new ServiceStatusModel
                        {
                            Name = "Service 3",
                            Status = ServiceStatus.Error,
                            Notification = "Panic!",
                        },
                    },
                },
            };

            var releases = new List<ReleaseModel>
            {
                new ReleaseModel
                {
                    Name = "Tool 1",
                    Version = new Version(1, 2, 3),
                    Date = new DateTimeOffset(2015, 5, 15, 10, 35, 0, new TimeSpan(13, 0, 0)),
                },
                new ReleaseModel
                {
                    Name = "Tool 2",
                    Version = new Version(1, 2, 3),
                    Date = new DateTimeOffset(2015, 5, 15, 10, 35, 0, new TimeSpan(13, 0, 0)),
                },
                new ReleaseModel
                {
                    Name = "Tool 3",
                    Version = new Version(1, 2, 3),
                    Date = new DateTimeOffset(2015, 5, 15, 10, 35, 0, new TimeSpan(13, 0, 0)),
                },
            };

            var model = new OpsModel
            {
                Name = "Ops",
                Description = "Watching your servers",
                EnvironmentStatus = environments,
                Releases = releases,
            };

            return View(model);
        }
    }
}
