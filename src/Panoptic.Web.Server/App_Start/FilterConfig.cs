using System.ComponentModel.Composition;
using System.Web.Mvc;
using Panoptic.Web.Server.Common.Initialization;

namespace Panoptic.Web.Server
{
    /// <summary>
    /// Configures the filters.
    /// </summary>
    [Export(typeof(IFilterConfig))]
    public sealed class FilterConfig : IFilterConfig
    {
        /// <summary>
        /// Registers the global filters.
        /// </summary>
        /// <param name="filters">The global filter collection.</param>
        public void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
