//-----------------------------------------------------------------------
// <copyright company="Panoptic">
//     Copyright 2013 Panoptic. Licensed under the Apache License, Version 2.0.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using System.Web.Mvc;
using Panoptic.UI.Web.Areas.Ops.Models;
using Panoptic.UI.Web.Common.Controllers;

namespace Panoptic.UI.Web.Areas.Ops.Controllers
{
    /// <summary>
    /// Provides the status pages for the different services in the available environments.
    /// </summary>
    [ExportController(typeof(StatusController))]
    public class StatusController : Controller
    {
        /// <summary>
        /// GET: Ops/Status
        /// </summary>
        /// <param name="environment">The environment status model name.</param>
        /// <returns>The index view</returns>
        public ActionResult Index(string environment)
        {
            var model = new EnvironmentStatusModel
            {
                Name = environment,
                Description = string.Format("Lots of information about the {0} environment.", environment),
                Machines = new List<MachineStatusModel>
                    {
                        new MachineStatusModel
                        {
                            Name = "Server 1",
                            Status = ServiceStatus.Ok,
                            CpuPercentage = 15,
                            MemoryTotalInGb = 4,
                            MemoryInUseInGb = 3.25,
                            Notification = string.Empty,
                        },
                        new MachineStatusModel
                        {
                            Name = "Server 2",
                            Status = ServiceStatus.Ok,
                            CpuPercentage = 15,
                            MemoryTotalInGb = 4,
                            MemoryInUseInGb = 3.25,
                            Notification = string.Empty,
                        },
                        new MachineStatusModel
                        {
                            Name = "Server 3",
                            Status = ServiceStatus.Ok,
                            CpuPercentage = 15,
                            MemoryTotalInGb = 4,
                            MemoryInUseInGb = 3.25,
                            Notification = string.Empty,
                        },
                        new MachineStatusModel
                        {
                            Name = "Server 4",
                            Status = ServiceStatus.Ok,
                            CpuPercentage = 15,
                            MemoryTotalInGb = 4,
                            MemoryInUseInGb = 3.25,
                            Notification = string.Empty,
                        },
                        new MachineStatusModel
                        {
                            Name = "Server 5",
                            Status = ServiceStatus.Ok,
                            CpuPercentage = 15,
                            MemoryTotalInGb = 4,
                            MemoryInUseInGb = 3.25,
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
            };

            return View(model);
        }
    }
}
