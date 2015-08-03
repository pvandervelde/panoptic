//-----------------------------------------------------------------------
// <copyright company="Panoptic">
//     Copyright 2013 Panoptic. Licensed under the Apache License, Version 2.0.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using Panoptic.UI.Web.Common;

namespace Panoptic.UI.Web.Composition
{
    /// <summary>
    /// Provides a common mechanism for composing parts.
    /// </summary>
    public class Composer : IComposer
    {
        private bool m_IsModified;

        private readonly IDictionary<ExportProvider, Action<ExportProvider, CompositionContainer>> m_PostContainerModifiers
            = new Dictionary<ExportProvider, Action<ExportProvider, CompositionContainer>>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Composer" /> class.
        /// </summary>
        public Composer()
        {
            ExportProviders = new List<ExportProvider>();
            ExportSelf = true;
        }

        /// <summary>
        /// Gets the catalog to use for composition.
        /// </summary>
        public ComposablePartCatalog Catalog
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the container to use for composition.
        /// </summary>
        public CompositionContainer Container
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the export provider to use for composition.
        /// </summary>
        public IList<ExportProvider> ExportProviders
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the composer should export itself.
        /// </summary>
        public bool ExportSelf
        {
            get;
            set;
        }

        /// <summary>
        /// Adds the specified catalog to the composer.
        /// </summary>
        /// <param name="catalog">The catalog to add to the composer.</param>
        public void AddCatalog(ComposablePartCatalog catalog)
        {
            {
                Lokad.Enforce.Argument(() => catalog);
            }

            if (Catalog == null)
            {
                Catalog = catalog;
            }
            else
            {
                var aggregate = Catalog as AggregateCatalog;
                if (aggregate != null)
                {
                    aggregate.Catalogs.Add(catalog);
                }
                else
                {
                    aggregate = new AggregateCatalog();
                    aggregate.Catalogs.Add(Catalog);
                    aggregate.Catalogs.Add(catalog);

                    Catalog = aggregate;
                }
            }

            m_IsModified = true;
        }

        /// <summary>
        /// Adds the specific export provider to the composer.
        /// </summary>
        /// <param name="provider">The export provider add to the composer.</param>
        /// <param name="postContainerModifier">A modifier action called after the container has been created.</param>
        public void AddExportProvider(
            ExportProvider provider,
            Action<ExportProvider,
                CompositionContainer> postContainerModifier = null)
        {
            {
                Lokad.Enforce.Argument(() => provider);
            }

            ExportProviders.Add(provider);
            if (postContainerModifier != null)
            {
                m_PostContainerModifiers.Add(provider, postContainerModifier);
            }
        }

        /// <summary>
        /// Composes the specified object.
        /// </summary>
        /// <param name="instance">The object to be composed.</param>
        public void Compose(object instance)
        {
            {
                Lokad.Enforce.Argument(() => instance);
            }

            if (Catalog == null)
            {
                return;
            }

            EnsureContainer();
            Container.ComposeParts(instance);
        }

        /// <summary>
        /// Gets an instance of the specified type from the <see cref="Composer" />.
        /// </summary>
        /// <typeparam name="T">The type of instance to resolve.</typeparam>
        /// <returns>The resolved instance.</returns>
        public T Resolve<T>()
        {
            return Resolve<T>(null);
        }

        /// <summary>
        /// Gets an instance of the specified type from the <see cref="Composer" />.
        /// </summary>
        /// <typeparam name="T">The type of instance to resolve.</typeparam>
        /// <param name="contractName">The contract name the type was exported with.</param>
        /// <returns>The resolved instance.</returns>
        public T Resolve<T>(string contractName)
        {
            if (Catalog == null)
            {
                return default(T);
            }

            EnsureContainer();
            return Container.GetExportedValue<T>(contractName);
        }

        /// <summary>
        /// Gets an instance of <see cref="Lazy{T,TMetadata}" /> for the specified trip from the <see cref="Composer" />.
        /// </summary>
        /// <typeparam name="T">The type of instance to resolve.</typeparam>
        /// <typeparam name="TMetadata">The metadata type to resolve.</typeparam>
        /// <returns>A <see cref="Lazy{T,TMetadata}" /> that allows lazy-loading.</returns>
        public Lazy<T, TMetadata> Resolve<T, TMetadata>()
        {
            return Resolve<T, TMetadata>(null);
        }

        /// <summary>
        /// Gets an instance of <see cref="Lazy{T,TMetadata}" /> for the specified trip from the <see cref="Composer" />.
        /// </summary>
        /// <typeparam name="T">The type of instance to resolve.</typeparam>
        /// <typeparam name="TMetadata">The metadata type to resolve.</typeparam>
        /// <param name="contractName">The contract name the type was exported with.</param>
        /// <returns>A <see cref="Lazy{T,TMetadata}" /> that allows lazy-loading.</returns>
        public Lazy<T, TMetadata> Resolve<T, TMetadata>(string contractName)
        {
            if (Catalog == null)
            {
                return null;
            }

            EnsureContainer();
            return Container.GetExport<T, TMetadata>(contractName);
        }

        /// <summary>
        /// Gets all instances of the specified type from the <see cref="Composer" />.
        /// </summary>
        /// <typeparam name="T">The type of instance to resolve.</typeparam>
        /// <returns>An enumerable of resolved instances.</returns>
        public IEnumerable<T> ResolveAll<T>()
        {
            return ResolveAll<T>(null);
        }

        /// <summary>
        /// Gets all instances of the specified type from the <see cref="Composer" />.
        /// </summary>
        /// <typeparam name="T">The type of instance to resolve.</typeparam>
        /// <param name="contractName">The contract name the type was exported with.</param>
        /// <returns>An enumerable of resolved instances.</returns>
        public IEnumerable<T> ResolveAll<T>(string contractName)
        {
            if (Catalog == null)
            {
                return new T[0];
            }

            EnsureContainer();
            return Container.GetExportedValues<T>(contractName);
        }

        /// <summary>
        /// Gets all instances of <see cref="Lazy{T,TMetadata}" /> of the specified type from the <see cref="Composer" />.
        /// </summary>
        /// <typeparam name="T">The type of instance to resolve.</typeparam>
        /// <typeparam name="TMetadata">The metadata type to resolve.</typeparam>
        /// <returns>An enumerable of <see cref="Lazy{T,TMetadata}" />.</returns>
        public IEnumerable<Lazy<T, TMetadata>> ResolveAll<T, TMetadata>()
        {
            return ResolveAll<T, TMetadata>(null);
        }

        /// <summary>
        /// Gets all instances of <see cref="Lazy{T,TMetadata}" /> of the specified type from the <see cref="Composer" />.
        /// </summary>
        /// <typeparam name="T">The type of instance to resolve.</typeparam>
        /// <typeparam name="TMetadata">The metadata type to resolve.</typeparam>
        /// <param name="contractName">The contract name the type was exported with.</param>
        /// <returns>An enumerable of <see cref="Lazy{T,TMetadata}" />.</returns>
        public IEnumerable<Lazy<T, TMetadata>> ResolveAll<T, TMetadata>(string contractName)
        {
            if (Catalog == null)
            {
                return null;
            }

            EnsureContainer();
            return Container.GetExports<T, TMetadata>(contractName);
        }

        /// <summary>
        /// Ensures the Container has been instantiated/re-instantiated if the Composer has been modified.
        /// </summary>
        private void EnsureContainer()
        {
            if (m_IsModified || Container == null)
            {
                if (Container != null)
                {
                    Container.Dispose();
                }

                Container = new CompositionContainer(Catalog, ExportProviders.ToArray());

                foreach (var provider in m_PostContainerModifiers.Keys)
                {
                    m_PostContainerModifiers[provider](provider, Container);
                }

                if (ExportSelf)
                {
                    var batch = new CompositionBatch();
                    batch.AddExportedValue<IComposer>(this);
                    Container.Compose(batch);
                }

                m_IsModified = false;
            }
        }
    }
}
