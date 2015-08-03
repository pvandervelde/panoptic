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
        /// Initialises a new instance of the <see cref="ExportControllerAttribute"/> class.
        /// </summary>
        /// <param name="name">The name of the controller.</param>
        public ExportControllerAttribute(string name) : base(typeof(IController))
        {
            {
                Lokad.Enforce.Argument(() => name);
                Lokad.Enforce.Argument(() => name, Lokad.Rules.StringIs.NotEmpty);
            }

            Name = name;
        }

        /// <summary>
        /// Gets the name of the controller.
        /// </summary>
        public string Name
        {
            get;
        }
    }
}
