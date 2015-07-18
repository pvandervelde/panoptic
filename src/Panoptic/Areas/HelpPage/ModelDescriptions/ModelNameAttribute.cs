//-----------------------------------------------------------------------
// <copyright company="Panoptic">
//     Copyright 2013 Panoptic. Licensed under the Apache License, Version 2.0.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Panoptic.Areas.HelpPage.ModelDescriptions
{
    /// <summary>
    /// Use this attribute to change the name of the <see cref="ModelDescription"/> generated for a type.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum, AllowMultiple = false, Inherited = false)]
    public sealed class ModelNameAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelNameAttribute"/> class.
        /// </summary>
        /// <param name="name">The name of the model.</param>
        public ModelNameAttribute(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Gets the name of the model.
        /// </summary>
        /// <value>The name of the model.</value>
        public string Name
        {
            get;
            private set;
        }
    }
}
