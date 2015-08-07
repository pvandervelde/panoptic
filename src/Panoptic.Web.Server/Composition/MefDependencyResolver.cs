using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Web.Http.Dependencies;

namespace Panoptic.Web.Server.Composition
{
    /// <summary>
    /// Resolve dependencies for MVC / Web API using MEF.
    /// </summary>
    public class MefDependencyResolver : System.Web.Http.Dependencies.IDependencyResolver, System.Web.Mvc.IDependencyResolver
    {
        private readonly CompositionContainer _container;

        /// <summary>
        /// Initializes a new instance of the <see cref="MefDependencyResolver"/> class.
        /// </summary>
        /// <param name="container">The composition container for the application.</param>
        public MefDependencyResolver(CompositionContainer container)
        {
            _container = container;
        }

        /// <summary>
        /// Starts a resolution scope.
        /// </summary>
        /// <returns>The dependency scope.</returns>
        public IDependencyScope BeginScope()
        {
            return this;
        }

        /// <summary>
        /// Called to request a service implementation.
        /// 
        /// Here we call upon MEF to instantiate implementations of dependencies.
        /// </summary>
        /// <param name="serviceType">Type of service requested.</param>
        /// <returns>Service implementation or null.</returns>
        public object GetService(Type serviceType)
        {
            if (serviceType == null)
                throw new ArgumentNullException("serviceType");

            var name = AttributedModelServices.GetContractName(serviceType);
            var export = _container.GetExportedValueOrDefault<object>(name);
            return export;
        }

        /// <summary>
        /// Called to request service implementations.
        /// 
        /// Here we call upon MEF to instantiate implementations of dependencies.
        /// </summary>
        /// <param name="serviceType">Type of service requested.</param>
        /// <returns>Service implementations.</returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (serviceType == null)
                throw new ArgumentNullException("serviceType");

            var exports = _container.GetExportedValues<object>(AttributedModelServices.GetContractName(serviceType));
            return exports;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, 
        /// or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
        }
    }
}