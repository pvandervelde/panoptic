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
    [ExportController(typeof(PlatformEnvironmentController))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("api/v1/teams/platform")]
    public class PlatformEnvironmentController : ApiController
    {
        /// <summary>
        /// Returns information about the different environments.
        /// </summary>
        /// <returns>An HTTP action result containing the information about the different environments.</returns>
        [ResponseType(typeof(IHttpActionResult))]
        [Route("environment")]
        public IHttpActionResult Get()
        {
            var list = new List<object>();

            var productionServices = new List<object>
            {
                new
                {
                    Name = "Service 1",
                    Status = "Ok",
                    Machines = (new List<object>
                    {
                        new
                        {
                            Name = "Machine1a",
                            Status = "Ok"
                        },
                        new
                        {
                            Name = "Machine1b",
                            Status = "Ok"
                        }
                    }).ToArray(),
                },
                new
                {
                    Name = "Service 2",
                    Status = "Warning",
                    Machines = (new List<object>
                    {
                        new
                        {
                            Name = "Machine2a",
                            Status = "Ok"
                        },
                        new
                        {
                            Name = "Machine2b",
                            Status = "Ok"
                        }
                    }).ToArray(),
                },
                new
                {
                    Name = "Service 3",
                    Status = "Error",
                    Machines = (new List<object>
                    {
                        new
                        {
                            Name = "Machine3a",
                            Status = "Ok"
                        },
                        new
                        {
                            Name = "Machine3b",
                            Status = "Ok"
                        }
                    }).ToArray(),
                },
                new
                {
                    Name = "Service 4",
                    Status = "Ok",
                    Machines = (new List<object>
                    {
                        new
                        {
                            Name = "Machine4a",
                            Status = "Ok"
                        },
                        new
                        {
                            Name = "Machine4b",
                            Status = "Ok"
                        }
                    }).ToArray(),
                },
                new
                {
                    Name = "Service 5",
                    Status = "Ok",
                    Machines = (new List<object>
                    {
                        new
                        {
                            Name = "Machine5a",
                            Status = "Ok"
                        },
                        new
                        {
                            Name = "Machine5b",
                            Status = "Ok"
                        }
                    }).ToArray(),
                },
            };
            var productionEnvironment = new
            {
                Name = "Production",
                Description = "This is the production environment",
                Services = productionServices.ToArray(),
                Url = "platformteam/environment/production",
            };
            list.Add(productionEnvironment);

            var stagingServices = new List<object>
            {
                new
                {
                    Name = "Service 1",
                    Status = "Ok",
                    Machines = (new List<object>
                    {
                        new
                        {
                            Name = "Machine6a",
                            Status = "Ok"
                        },
                        new
                        {
                            Name = "Machine6b",
                            Status = "Ok"
                        }
                    }).ToArray(),
                },
                new
                {
                    Name = "Service 2",
                    Status = "Ok",
                    Machines = (new List<object>
                    {
                        new
                        {
                            Name = "Machine7a",
                            Status = "Ok"
                        },
                        new
                        {
                            Name = "Machine7b",
                            Status = "Ok"
                        }
                    }).ToArray(),
                },
                new
                {
                    Name = "Service 3",
                    Status = "Ok",
                    Machines = (new List<object>
                    {
                        new
                        {
                            Name = "Machine8a",
                            Status = "Ok"
                        },
                        new
                        {
                            Name = "Machine8b",
                            Status = "Ok"
                        }
                    }).ToArray(),
                },
                new
                {
                    Name = "Service 4",
                    Status = "Ok",
                    Machines = (new List<object>
                    {
                        new
                        {
                            Name = "Machine9a",
                            Status = "Ok"
                        },
                        new
                        {
                            Name = "Machine9b",
                            Status = "Ok"
                        }
                    }).ToArray(),
                },
                new
                {
                    Name = "Service 5",
                    Status = "Ok",
                    Machines = (new List<object>
                    {
                        new
                        {
                            Name = "Machine10a",
                            Status = "Ok"
                        },
                        new
                        {
                            Name = "Machine10b",
                            Status = "Ok"
                        }
                    }).ToArray(),
                },
            };
            var stagingEnvironment = new
            {
                Name = "Staging",
                Description = "This is the staging environment",
                Services = stagingServices.ToArray(),
                Url = "platformteam/environment/staging",
            };

            list.Add(stagingEnvironment);

            return Ok(list.ToArray());
        }

        /// <summary>
        /// Returns information about the different environments.
        /// </summary>
        /// <returns>An HTTP action result containing the information about the different environments.</returns>
        [ResponseType(typeof(IHttpActionResult))]
        [Route("environment/{id}")]
        public IHttpActionResult Get(string id)
        {
            var productionServices = new List<object>
            {
                new
                {
                    Name = "Service 1",
                    Status = "Ok",
                    Machines = (new List<object>
                    {
                        new
                        {
                            Name = "Machine1a",
                            Status = "Ok"
                        },
                        new
                        {
                            Name = "Machine1b",
                            Status = "Ok"
                        }
                    }).ToArray(),
                },
                new
                {
                    Name = "Service 2",
                    Status = "Warning",
                    Machines = (new List<object>
                    {
                        new
                        {
                            Name = "Machine2a",
                            Status = "Ok"
                        },
                        new
                        {
                            Name = "Machine2b",
                            Status = "Ok"
                        }
                    }).ToArray(),
                },
                new
                {
                    Name = "Service 3",
                    Status = "Error",
                    Machines = (new List<object>
                    {
                        new
                        {
                            Name = "Machine3a",
                            Status = "Ok"
                        },
                        new
                        {
                            Name = "Machine3b",
                            Status = "Ok"
                        }
                    }).ToArray(),
                },
                new
                {
                    Name = "Service 4",
                    Status = "Ok",
                    Machines = (new List<object>
                    {
                        new
                        {
                            Name = "Machine4a",
                            Status = "Ok"
                        },
                        new
                        {
                            Name = "Machine4b",
                            Status = "Ok"
                        }
                    }).ToArray(),
                },
                new
                {
                    Name = "Service 5",
                    Status = "Ok",
                    Machines = (new List<object>
                    {
                        new
                        {
                            Name = "Machine5a",
                            Status = "Ok"
                        },
                        new
                        {
                            Name = "Machine5b",
                            Status = "Ok"
                        }
                    }).ToArray(),
                },
            };
            var productionEnvironment = new
            {
                Name = id,
                Description = string.Format("This is the {0} environment", id),
                Services = productionServices.ToArray(),
                Url = string.Format("~/api/v1/teams/platform/environment/{0}", id),
            };

            return Ok(productionEnvironment);
        }
    }
}
