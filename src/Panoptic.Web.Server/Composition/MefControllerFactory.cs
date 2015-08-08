using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Panoptic.Web.Server.Composition
{
    /// <summary>
    /// Defines a <see cref="IControllerFactory"/> that uses MEF for the
    /// resolution of <see cref="IController"/> instances.
    /// </summary>
    public class MefControllerFactory : DefaultControllerFactory
    {
        private readonly CompositionContainer compositionContainer;

        /// <summary>
        /// Initializes a new instance of the <see cref="MefControllerFactory"/> class.
        /// </summary>
        /// <param name="compositionContainer">The composition container.</param>
        public MefControllerFactory(CompositionContainer compositionContainer)
        {
            this.compositionContainer = compositionContainer;
        }

        /// <summary>
        /// Retrieves the controller instance for the specified request context and 
        /// controller type.
        /// </summary>
        /// <param name="requestContext">The context of the HTTP request, which includes the HTTP context and route data.</param>
        /// <param name="controllerType">The type of the controller.</param>
        /// <returns>The controller instance.</returns>
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            var export = compositionContainer.GetExports(controllerType, null, null).SingleOrDefault();

            IController result;

            if (null != export)
            {
                result = export.Value as IController;
            }
            else
            {
                result = base.GetControllerInstance(requestContext, controllerType);
                compositionContainer.ComposeParts(result);
            }

            return result;
        }
    }
}