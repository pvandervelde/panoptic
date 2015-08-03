//-----------------------------------------------------------------------
// <copyright company="Panoptic">
//     Copyright 2013 Panoptic. Licensed under the Apache License, Version 2.0.
// </copyright>
//-----------------------------------------------------------------------

using System.Configuration;

namespace Panoptic.UI.Web.Configuration
{
    /// <summary>
    /// Represents a configuration of a singular catalog.
    /// </summary>
    public sealed class CatalogConfigurationElement : ConfigurationElement
    {
        private const string NameAttribute = "name";
        private const string PathAttribute = "path";

        /// <summary>
        /// Gets or sets the name of the catalog.
        /// </summary>
        [ConfigurationProperty(NameAttribute, IsRequired = true, IsKey = true)]
        public string Name
        {
            get
            {
                return (string)this[NameAttribute];
            }

            set
            {
                this[NameAttribute] = value;
            }
        }

        /// <summary>
        /// Gets or sets the path of the catalog.
        /// </summary>
        [ConfigurationProperty(PathAttribute, IsRequired = true)]
        public string Path
        {
            get
            {
                return (string)this[PathAttribute];
            }

            set
            {
                this[PathAttribute] = value;
            }
        }
    }
}
