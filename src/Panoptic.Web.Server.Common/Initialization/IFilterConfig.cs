using System.Web.Mvc;

namespace Panoptic.Web.Server.Common.Initialization
{
    /// <summary>
    /// Defines the interface for classes that configure filters.
    /// </summary>
    public interface IFilterConfig
    {
        /// <summary>
        /// Registers the global filters.
        /// </summary>
        /// <param name="filters">The global filter collection.</param>
        void RegisterGlobalFilters(GlobalFilterCollection filters);
    }
}
