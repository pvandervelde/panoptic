using System.Net.Http.Headers;
using System.Web.Http;
using Panoptic.Web.Server.Formatters;

namespace Panoptic.Web.Server
{
    /// <summary>
    /// Provides the configuration of the Web API part of the website.
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Registers the web API methods.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{version}/{controller}/{id}",
                defaults: new { version = "v1", id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            config.Formatters.Add(new BrowserJsonFormatter());
        }
    }
}
