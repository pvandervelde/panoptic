using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Panoptic.Web.Server
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            MefConfig.RegisterMef();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }
    }
}
