//-----------------------------------------------------------------------
// <copyright company="Panoptic">
//     Copyright 2013 Panoptic. Licensed under the Apache License, Version 2.0.
// </copyright>
//-----------------------------------------------------------------------

using System.Configuration;

namespace Panoptic.UI.Web.Configuration
{
    /// <summary>
    /// Represets the composition configuration.
    /// </summary>
    public class CompositionConfigurationSection : ConfigurationSection
    {
        private const string SectionPath = "mef/composition";
        private const string CatalogsElement = "catalogs";

        /// <summary>
        /// Gets the collection of catalog configurations.
        /// </summary>
        [ConfigurationProperty(CatalogsElement, IsDefaultCollection = true)]
        public CatalogConfigurationElementCollection Catalogs
        {
            get
            {
                return (CatalogConfigurationElementCollection)this[CatalogsElement];
            }

            set
            {
                this[CatalogsElement] = value;
            }
        }

        /// <summary>
        /// Gets an instance of <see cref="CompositionConfigurationSection" /> that represents the current configuration.
        /// </summary>
        /// <returns>An instance of <see cref="CompositionConfigurationSection" />, or null.</returns>
        public static CompositionConfigurationSection GetInstance()
        {
            return ConfigurationManager.GetSection(SectionPath) as CompositionConfigurationSection;
        }
    }
}