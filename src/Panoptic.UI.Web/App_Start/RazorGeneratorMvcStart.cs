//-----------------------------------------------------------------------
// <copyright company="Panoptic">
//     Copyright 2013 Panoptic. Licensed under the Apache License, Version 2.0.
// </copyright>
//-----------------------------------------------------------------------

using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using RazorGenerator.Mvc;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(Panoptic.UI.Web.App_Start.RazorGeneratorMvcStart), "Start")]

namespace Panoptic.UI.Web.App_Start
{
    /// <summary>
    /// Provides the methods to handle the pre-compiled views.
    /// </summary>
    public static class RazorGeneratorMvcStart
    {
        /// <summary>
        /// Starts the handling of views by the razor generator.
        /// </summary>
        public static void Start()
        {
            var engine = new PrecompiledMvcEngine(typeof(RazorGeneratorMvcStart).Assembly)
            {
                UsePhysicalViewsIfNewer = HttpContext.Current.Request.IsLocal
            };

            ViewEngines.Engines.Insert(0, engine);

            // StartPage lookups are done by WebPages.
            VirtualPathFactoryManager.RegisterVirtualPathFactory(engine);
        }
    }
}
