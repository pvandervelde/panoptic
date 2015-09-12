using System.Web.Http;

namespace Panoptic.Web.Server.Common.Initialization
{
    /// <summary>
    /// Defines the interface for classes that configure Web API routes.
    /// </summary>
    public interface IWebApiConfig
    {
        /// <summary>
        /// Registers the web API methods.
        /// </summary>
        /// <param name="config">The configuration.</param>
        void Register(HttpConfiguration config);
    }
}
