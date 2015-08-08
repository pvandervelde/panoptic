using System;

namespace Panoptic.Web.Server.Common.Controllers
{
    /// <summary>
    /// Provides helper methods for dealing with controllers.
    /// </summary>
    public static class ControllerHelpers
    {
        /// <summary>
        /// Returns the name of the controller.
        /// </summary>
        /// <param name="controllerType">The type of the controller.</param>
        /// <returns>The name of the controller.</returns>
        public static string ControllerName(this Type controllerType)
        {
            return controllerType.Name.Substring(
                0,
                controllerType.Name.IndexOf("Controller"));
        }
    }
}
