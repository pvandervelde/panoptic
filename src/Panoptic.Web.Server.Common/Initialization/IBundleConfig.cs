using System.Web.Optimization;

namespace Panoptic.Web.Server.Common.Initialization
{
    /// <summary>
    /// Defines the interface for classes that register bundles.
    /// </summary>
    public interface IBundleConfig
    {
        /// <summary>
        /// Registers the bundle configurations with the bundle collection.
        /// </summary>
        /// <param name="bundles">The bundle collection.</param>
        void RegisterBundles(BundleCollection bundles);
    }
}
