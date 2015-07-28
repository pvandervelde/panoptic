//-----------------------------------------------------------------------
// <copyright company="Panoptic">
//     Copyright 2013 Panoptic. Licensed under the Apache License, Version 2.0.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.ObjectModel;

namespace Panoptic.Areas.HelpPage.ModelDescriptions
{
    /// <summary>
    /// The model description for enums.
    /// </summary>
    public class EnumTypeModelDescription : ModelDescription
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnumTypeModelDescription"/> class.
        /// </summary>
        public EnumTypeModelDescription()
        {
            Values = new Collection<EnumValueDescription>();
        }

        /// <summary>
        /// Gets the enum values.
        /// </summary>
        /// <value>
        /// The enum values.
        /// </value>
        public Collection<EnumValueDescription> Values
        {
            get;
            private set;
        }
    }
}
