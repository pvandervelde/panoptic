//-----------------------------------------------------------------------
// <copyright company="Panoptic">
//     Copyright 2013 Panoptic. Licensed under the Apache License, Version 2.0.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel.Composition;
using System.Web.Mvc;

namespace Panoptic.Plugins.UI.Ops.Areas.Ops
{
    /// <summary>
    /// Defines the registration methods for the Ops area.
    /// </summary>
    [Export(typeof(AreaRegistration))]
    public class OpsAreaRegistration : AreaRegistration
    {
        /// <summary>
        /// Gets the name of the area.
        /// </summary>
        public override string AreaName
        {
            get
            {
                return "Ops";
            }
        }

        /// <summary>
        /// Registers the routes for the area.
        /// </summary>
        /// <param name="context">The area registration context.</param>
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                name: "Ops",
                url: "Ops/{controller}/{action}/{id}",
                defaults: new { area = "Ops", controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Panoptic.Plugins.UI.Ops.Areas.Ops.Controllers" });
        }
    }
}