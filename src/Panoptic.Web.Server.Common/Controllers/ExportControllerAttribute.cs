//-----------------------------------------------------------------------
// <copyright company="Panoptic">
//     Copyright 2013 Panoptic. Licensed under the Apache License, Version 2.0.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.ComponentModel.Composition;
using System.Web.Mvc;

namespace Panoptic.UI.Web.Common.Controllers
{
    /// <summary>
    /// Exports a controller.
    /// </summary>
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ExportControllerAttribute : ExportAttribute, IControllerMetadata
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExportControllerAttribute"/> class.
        /// </summary>
        /// <param name="controllerType">The type of the controller.</param>
        public ExportControllerAttribute(Type controllerType) : base(typeof(IController))
        {
            {
                Lokad.Enforce.Argument(() => controllerType);
            }

            ControllerName = controllerType.Name.Substring(
                0,
                controllerType.Name.IndexOf("Controller"));
            TypeName = controllerType.Name;
            TypeNamespace = controllerType.Namespace;
        }

        /// <summary>
        /// Gets the name of the controller.
        /// </summary>
        public string ControllerName
        {
            get;
        }

        /// <summary>
        /// Gets the type name of the controller type.
        /// </summary>
        public string TypeName
        {
            get;
        }

        /// <summary>
        /// Gets the namespace of the controller type.
        /// </summary>
        public string TypeNamespace
        {
            get;
        }
    }
}
