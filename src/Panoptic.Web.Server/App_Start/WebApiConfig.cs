using System.ComponentModel.Composition;
using System.Net.Http.Headers;
using System.Web.Http;
using Panoptic.Web.Server.Common.Initialization;
using Panoptic.Web.Server.Formatters;

namespace Panoptic.Web.Server
{
    /// <summary>
    /// Provides the configuration of the Web API part of the website.
    /// </summary>
    [Export(typeof(IWebApiConfig))]
    public sealed class WebApiConfig : IWebApiConfig
    {
        /// <summary>
        /// Registers the web API methods.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            config.Formatters.Add(new BrowserJsonFormatter());
        }
    }
}
