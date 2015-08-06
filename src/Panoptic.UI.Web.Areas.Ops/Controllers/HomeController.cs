//-----------------------------------------------------------------------
// <copyright company="Panoptic">
//     Copyright 2013 Panoptic. Licensed under the Apache License, Version 2.0.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Panoptic.UI.Web.Areas.Ops.Models;
using Panoptic.UI.Web.Common.Controllers;

namespace Panoptic.UI.Web.Areas.Ops.Controllers
{
    /// <summary>
    /// Provides the index page for the ops area.
    /// </summary>
    [ExportController(typeof(HomeController))]
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
                    Machines = new List<MachineStatusModel>
                    {
                        new MachineStatusModel
                        {
                            Name = "Server 1",
                            Status = ServiceStatus.Ok,
                            Notification = string.Empty,
                        },
                        new MachineStatusModel
                        {
                            Name = "Server 2",
                            Status = ServiceStatus.Ok,
                            Notification = string.Empty,
                        },
                        new MachineStatusModel
                        {
                            Name = "Server 3",
                            Status = ServiceStatus.Ok,
                            Notification = string.Empty,
                        },
                        new MachineStatusModel
                        {
                            Name = "Server 4",
                            Status = ServiceStatus.Ok,
                            Notification = string.Empty,
                        },
                        new MachineStatusModel
                        {
                            Name = "Server 5",
                            Status = ServiceStatus.Ok,
                            Notification = string.Empty,
                        },
                    },
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
                    Machines = new List<MachineStatusModel>
                    {
                        new MachineStatusModel
                        {
                            Name = "Server 1",
                            Status = ServiceStatus.Ok,
                            Notification = string.Empty,
                        },
                        new MachineStatusModel
                        {
                            Name = "Server 2",
                            Status = ServiceStatus.Ok,
                            Notification = string.Empty,
                        },
                        new MachineStatusModel
                        {
                            Name = "Server 3",
                            Status = ServiceStatus.Ok,
                            Notification = string.Empty,
                        },
                        new MachineStatusModel
                        {
                            Name = "Server 4",
                            Status = ServiceStatus.Ok,
                            Notification = string.Empty,
                        },
                        new MachineStatusModel
                        {
                            Name = "Server 5",
                            Status = ServiceStatus.Ok,
                            Notification = string.Empty,
                        },
                    },
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

            var issues = new List<IssueSetModel>
            {
                new IssueSetModel
                {
                    Name = "Open",
                    Count = 85,
                },
                new IssueSetModel
                {
                    Name = "In progress",
                    Count = 7,
                },
                new IssueSetModel
                {
                    Name = "Closed",
                    Count = 50,
                },
            };

            var newsItems = new List<NewsItemModel>
            {
                new NewsItemModel
                {
                    Date = new DateTimeOffset(2015, 5, 15, 10, 35, 0, new TimeSpan(13, 0, 0)),
                    Summary = "Tool 1 released",
                    Description = "An awesome new version of this tool was released.",
                },
                new NewsItemModel
                {
                    Date = new DateTimeOffset(2015, 5, 15, 10, 35, 0, new TimeSpan(13, 0, 0)),
                    Summary = "Tool 2 released",
                    Description = "An awesome new version of this tool was released.",
                },
                new NewsItemModel
                {
                    Date = new DateTimeOffset(2015, 5, 15, 10, 35, 0, new TimeSpan(13, 0, 0)),
                    Summary = "Tool 3 released",
                    Description = "An awesome new version of this tool was released.",
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
                Issues = issues,
                NewsItems = newsItems,
                Releases = releases,
            };

            return View(model);
        }
    }
}
