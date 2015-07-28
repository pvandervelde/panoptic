//-----------------------------------------------------------------------
// <copyright company="Panoptic">
//     Copyright 2013 Panoptic. Licensed under the Apache License, Version 2.0.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.ObjectModel;

namespace Panoptic.Areas.HelpPage.ModelDescriptions
{
    /// <summary>
    /// The model description for complex types.
    /// </summary>
    public class ComplexTypeModelDescription : ModelDescription
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComplexTypeModelDescription"/> class.
        /// </summary>
        public ComplexTypeModelDescription()
        {
            Properties = new Collection<ParameterDescription>();
        }

        /// <summary>
        /// Gets the properties for the description.
        /// </summary>
        /// <value>
        /// The properties for the description.
        /// </value>
        public Collection<ParameterDescription> Properties
        {
            get;
            private set;
        }
    }
}
