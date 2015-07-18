//-----------------------------------------------------------------------
// <copyright company="Panoptic">
//     Copyright 2013 Panoptic. Licensed under the Apache License, Version 2.0.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Panoptic.Areas.HelpPage.ModelDescriptions
{
    /// <summary>
    /// Provides an annotation for parameters.
    /// </summary>
    public class ParameterAnnotation
    {
        /// <summary>
        /// Gets or sets the annotation attribute.
        /// </summary>
        /// <value>The annotation attribute.</value>
        public Attribute AnnotationAttribute
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the documenation for the annotation.
        /// </summary>
        /// <value>
        /// The documentation for the annotation.
        /// </value>
        public string Documentation { get; set; }
    }
}
