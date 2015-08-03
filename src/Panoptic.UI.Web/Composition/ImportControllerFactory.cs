//-----------------------------------------------------------------------
// <copyright company="Panoptic">
//     Copyright 2013 Panoptic. Licensed under the Apache License, Version 2.0.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web.Mvc;
using Panoptic.UI.Web.Common.Controllers;

namespace Panoptic.UI.Web.Composition
{
    /// <summary>
    /// Provides creation of controllers using imports.
    /// </summary>
    [Export]
    public sealed class ImportControllerFactory : DefaultControllerFactory
    {
        /// <summary>
        /// Gets or sets the collection containing the controllers and their meta data.
        /// </summary>
        [ImportMany]
        public IEnumerable<PartFactory<IController, IControllerMetadata>> ControllerFactories
        {
            get;
            set;
        }

        /// <summary>
        /// Creates an instance of a controller for the specified name.
        /// </summary>
        /// <param name="requestContext">The current request context.</param>
        /// <param name="controllerName">The name of the controller.</param>
        /// <returns>An instance of a controller for the specified name.</returns>
        public override IController CreateController(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            var factory = ControllerFactories
                .Where(f => f.Metadata.Name.Equals(controllerName, StringComparison.InvariantCultureIgnoreCase))
                .FirstOrDefault();

            if (factory != null)
            {
                return factory.CreatePart();
            }

            return base.CreateController(requestContext, controllerName);
        }
    }
}