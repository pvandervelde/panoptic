using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Panoptic.Web.Server
{
    /// <summary>
    /// Defines the entry point for the Web API application.
    /// </summary>
    public class WebApiApplication : HttpApplication
    {
        /// <summary>
        /// The entry point for the web application.
        /// </summary>
        protected void Application_Start()
        {
            MefConfig.RegisterMef();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }
    }
}
