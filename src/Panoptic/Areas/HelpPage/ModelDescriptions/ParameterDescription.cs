//-----------------------------------------------------------------------
// <copyright company="Panoptic">
//     Copyright 2013 Panoptic. Licensed under the Apache License, Version 2.0.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Panoptic.Areas.HelpPage.ModelDescriptions
{
    /// <summary>
    /// Defines a description of a parameter.
    /// </summary>
    public class ParameterDescription
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterDescription"/> class.
        /// </summary>
        public ParameterDescription()
        {
            Annotations = new Collection<ParameterAnnotation>();
        }

        /// <summary>
        /// Gets the annotation collection.
        /// </summary>
        public Collection<ParameterAnnotation> Annotations
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the documentation.
        /// </summary>
        public string Documentation
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the type description.
        /// </summary>
        public ModelDescription TypeDescription
        {
            get;
            set;
        }
    }
}
