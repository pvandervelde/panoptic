//-----------------------------------------------------------------------
// <copyright company="Panoptic">
//     Copyright 2013 Panoptic. Licensed under the Apache License, Version 2.0.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using System.Web.Http;

namespace Panoptic.Controllers
{
    /// <summary>
    /// The controller that handles the values web calls.
    /// </summary>
    [Authorize]
    public class ValuesController : ApiController
    {
        /// <summary>
        /// GET api/values
        /// </summary>
        /// <returns>The value array.</returns>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// GET api/values/5
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <returns>The value at ID.</returns>
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// POST api/values
        /// </summary>
        /// <param name="value">The value.</param>
        public void Post([FromBody]string value)
        {
        }

        /// <summary>
        /// PUT api/values/5
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <param name="value">The value.</param>
        public void Put(int id, [FromBody]string value)
        {
        }

        /// <summary>
        /// DELETE api/values/5
        /// </summary>
        /// <param name="id">The ID.</param>
        public void Delete(int id)
        {
        }
    }
}
