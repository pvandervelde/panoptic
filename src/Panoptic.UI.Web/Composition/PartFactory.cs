//-----------------------------------------------------------------------
// <copyright company="Panoptic">
//     Copyright 2013 Panoptic. Licensed under the Apache License, Version 2.0.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Diagnostics.CodeAnalysis;

namespace Panoptic.UI.Web.Composition
{
    /// <summary>
    /// Provides dynamic creation of parts.
    /// </summary>
    /// <typeparam name="TPart">The type of part to create.</typeparam>
    [SuppressMessage(
        "StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "The classes are the same except with different type parameters.")]
    public class PartFactory<TPart>
    {
        private readonly Func<PartLifetimeContext<TPart>> m_Delegate;

        /// <summary>
        /// Initializes a new instance of the <see cref="PartFactory{T}" /> class.
        /// </summary>
        /// <param name="delegate">The delegate used to create the part.</param>
        public PartFactory(Func<PartLifetimeContext<TPart>> @delegate)
        {
            {
                Lokad.Enforce.Argument(() => @delegate);
            }

            m_Delegate = @delegate;
            PartType = typeof(TPart);
        }

        /// <summary>
        /// Gets the <see cref="Type" /> if the part.
        /// </summary>
        public Type PartType
        {
            get;
        }

        /// <summary>
        /// Creates an instance of the <see cref="PartLifetimeContext{T}" /> used for managing the part.
        /// </summary>
        /// <returns>The context.</returns>
        public PartLifetimeContext<TPart> CreatePartLifetimeContext()
        {
            return m_Delegate();
        }

        /// <summary>
        /// Creates an instance of the part.
        /// </summary>
        /// <returns>The part.</returns>
        public TPart CreatePart()
        {
            return CreatePartLifetimeContext().ExportedValue;
        }
    }

    /// <summary>
    /// Provides dynamic creation of parts.
    /// </summary>
    /// <typeparam name="TPart">The type of part to create.</typeparam>
    /// <typeparam name="TMetadata">The type of metadata for the part.</typeparam>
    [SuppressMessage(
        "StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "The classes are the same except with different type parameters.")]
    public sealed class PartFactory<TPart, TMetadata> : PartFactory<TPart>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PartFactory{TPart,TMetadata}" /> class.
        /// </summary>
        /// <param name="delegate">The delegate used to create the part.</param>
        /// <param name="metadata">The metadata for the part.</param>
        public PartFactory(Func<PartLifetimeContext<TPart>> @delegate, TMetadata metadata)
            : base(@delegate)
        {
            Metadata = metadata;
        }

        /// <summary>
        /// Gets the metadata for the part.
        /// </summary>
        public TMetadata Metadata
        {
            get;
        }
    }
}
