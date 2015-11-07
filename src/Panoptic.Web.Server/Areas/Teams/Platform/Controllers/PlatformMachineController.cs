using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Web.Http;
using System.Web.Http.Description;
using Panoptic.Web.Server.Common.Controllers;

namespace Panoptic.Web.Server.Areas.Teams.Platform.Controllers
{
    /// <summary>
    /// The controller that provides information about the platform team environments for the application.
    /// </summary>
    [ExportController(typeof(PlatformMachineController))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("api/v1/teams/platform")]
    public class PlatformMachineController : ApiController
    {
        /// <summary>
        /// Returns information about the different environments.
        /// </summary>
        /// <returns>An HTTP action result containing the information about the different environments.</returns>
        [ResponseType(typeof(IHttpActionResult))]
        [Route("machines/{environment}")]
        [HttpGet]
        public IHttpActionResult Machines(string environment)
        {
            var machines = new List<object>
            {
                new
                {
                    Name = "Machine1a",
                    Status = "Ok",
                    CurrentCpu = 15.0,
                    CpuHistory = new object[] 
                    {
                        new
                        {
                            Time = 0,
                            Load = 15
                        },
                        new
                        {
                            Time = 10,
                            Load = 45
                        },
                        new
                        {
                            Time = 20,
                            Load = 75
                        },
                        new
                        {
                            Time = 30,
                            Load = 65
                        },
                        new
                        {
                            Time = 40,
                            Load = 35
                        }
                    },
                    MemoryInUseInMb = 2300,
                    TotalMemoryInMb = 8192,
                    Storage = (new List<object>
                    {
                        new
                        {
                            Name = "c",
                            StorageInUseInGb = 27.0,
                            TotalStorageInGb = 40,
                        },
                        new
                        {
                            Name = "d",
                            StorageInUseInGb = 67.0,
                            TotalStorageInGb = 100.0,
                        }
                    }).ToArray(),
                },
                new
                {
                    Name = "Machine1b",
                    Status = "Ok",
                    CurrentCpu = 15.0,
                    CpuHistory = new object[]
                    {
                        new
                        {
                            Time = 0,
                            Load = 15
                        },
                        new
                        {
                            Time = 10,
                            Load = 45
                        },
                        new
                        {
                            Time = 20,
                            Load = 75
                        },
                        new
                        {
                            Time = 30,
                            Load = 65
                        },
                        new
                        {
                            Time = 40,
                            Load = 35
                        }
                    },
                    MemoryInUseInMb = 2300,
                    TotalMemoryInMb = 8192,
                    Storage = (new List<object>
                    {
                        new
                        {
                            Name = "c",
                            StorageInUseInGb = 27.0,
                            TotalStorageInGb = 40,
                        },
                        new
                        {
                            Name = "d",
                            StorageInUseInGb = 67.0,
                            TotalStorageInGb = 100.0,
                        }
                    }).ToArray(),
                },
                new
                {
                    Name = "Machine2a",
                    Status = "Ok",
                    CurrentCpu = 15.0,
                    CpuHistory = new object[]
                    {
                        new
                        {
                            Time = 0,
                            Load = 15
                        },
                        new
                        {
                            Time = 10,
                            Load = 45
                        },
                        new
                        {
                            Time = 20,
                            Load = 75
                        },
                        new
                        {
                            Time = 30,
                            Load = 65
                        },
                        new
                        {
                            Time = 40,
                            Load = 35
                        }
                    },
                    MemoryInUseInMb = 2300,
                    TotalMemoryInMb = 8192,
                    Storage = (new List<object>
                    {
                        new
                        {
                            Name = "c",
                            StorageInUseInGb = 27.0,
                            TotalStorageInGb = 40,
                        },
                        new
                        {
                            Name = "d",
                            StorageInUseInGb = 67.0,
                            TotalStorageInGb = 100.0,
                        }
                    }).ToArray(),
                },
                new
                {
                    Name = "Machine2b",
                    Status = "Ok",
                    CurrentCpu = 15.0,
                    CpuHistory = new object[]
                    {
                        new
                        {
                            Time = 0,
                            Load = 15
                        },
                        new
                        {
                            Time = 10,
                            Load = 45
                        },
                        new
                        {
                            Time = 20,
                            Load = 75
                        },
                        new
                        {
                            Time = 30,
                            Load = 65
                        },
                        new
                        {
                            Time = 40,
                            Load = 35
                        }
                    },
                    MemoryInUseInMb = 2300,
                    TotalMemoryInMb = 8192,
                    Storage = (new List<object>
                    {
                        new
                        {
                            Name = "c",
                            StorageInUseInGb = 27.0,
                            TotalStorageInGb = 40,
                        },
                        new
                        {
                            Name = "d",
                            StorageInUseInGb = 67.0,
                            TotalStorageInGb = 100.0,
                        }
                    }).ToArray(),
                },
                new
                {
                    Name = "Machine3a",
                    Status = "Ok",
                    CurrentCpu = 15.0,
                    CpuHistory = new object[]
                    {
                        new
                        {
                            Time = 0,
                            Load = 15
                        },
                        new
                        {
                            Time = 10,
                            Load = 45
                        },
                        new
                        {
                            Time = 20,
                            Load = 75
                        },
                        new
                        {
                            Time = 30,
                            Load = 65
                        },
                        new
                        {
                            Time = 40,
                            Load = 35
                        }
                    },
                    MemoryInUseInMb = 2300,
                    TotalMemoryInMb = 8192,
                    Storage = (new List<object>
                    {
                        new
                        {
                            Name = "c",
                            StorageInUseInGb = 27.0,
                            TotalStorageInGb = 40,
                        },
                        new
                        {
                            Name = "d",
                            StorageInUseInGb = 67.0,
                            TotalStorageInGb = 100.0,
                        }
                    }).ToArray(),
                },
            };

            return Ok(machines.ToArray());
        }

        /// <summary>
        /// Returns information about the different environments.
        /// </summary>
        /// <returns>An HTTP action result containing the information about the different environments.</returns>
        [ResponseType(typeof(IHttpActionResult))]
        [Route("machine/{machineId}")]
        [HttpGet]
        public IHttpActionResult Machine(string machineId)
        {
            return NotFound();
        }
    }
}
