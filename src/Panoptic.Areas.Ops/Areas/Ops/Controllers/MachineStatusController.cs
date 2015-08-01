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
    /// Provides the status page for a specific machine.
    /// </summary>
    public class MachineStatusController : Controller
    {
        /// <summary>
        /// GET: Ops/MachineStatus
        /// </summary>
        /// <param name="machine">The name of the machine.</param>
        /// <returns>The view.</returns>
        public ActionResult Index(string machine)
        {
            var model = new MachineStatusModel
            {
                Name = machine,
                Description = "This is the server that does stuff.",
                Status = ServiceStatus.Ok,
                Logs = new List<LogEntryModel>
                {
                    new LogEntryModel
                    {
                        Date = new DateTimeOffset(2015, 5, 15, 10, 35, 6, new TimeSpan(13, 0, 0)),
                        Type = "WARN",
                        Text = "Something went wrong here"
                    },
                    new LogEntryModel
                    {
                        Date = new DateTimeOffset(2015, 5, 15, 10, 35, 5, new TimeSpan(13, 0, 0)),
                        Type = "WARN",
                        Text = "Something went wrong here"
                    },
                    new LogEntryModel
                    {
                        Date = new DateTimeOffset(2015, 5, 15, 10, 35, 4, new TimeSpan(13, 0, 0)),
                        Type = "WARN",
                        Text = "Something went wrong here"
                    },
                    new LogEntryModel
                    {
                        Date = new DateTimeOffset(2015, 5, 15, 10, 35, 3, new TimeSpan(13, 0, 0)),
                        Type = "WARN",
                        Text = "Something went wrong here"
                    },
                    new LogEntryModel
                    {
                        Date = new DateTimeOffset(2015, 5, 15, 10, 35, 2, new TimeSpan(13, 0, 0)),
                        Type = "WARN",
                        Text = "Something went wrong here"
                    },
                    new LogEntryModel
                    {
                        Date = new DateTimeOffset(2015, 5, 15, 10, 35, 1, new TimeSpan(13, 0, 0)),
                        Type = "WARN",
                        Text = "Something went wrong here"
                    },
                    new LogEntryModel
                    {
                        Date = new DateTimeOffset(2015, 5, 15, 10, 35, 0, new TimeSpan(13, 0, 0)),
                        Type = "WARN",
                        Text = "Something went wrong here"
                    },
                },
                CpuPercentage = 15,
                MemoryTotalInGb = 4,
                MemoryInUseInGb = 3.25,
                Notification = string.Empty,
            };

            return View(model);
        }
    }
}
