//-----------------------------------------------------------------------
// <copyright company="Panoptic">
//     Copyright 2013 Panoptic. Licensed under the Apache License, Version 2.0.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Panoptic.UI.Web.Composition
{
    /// <summary>
    /// Defines a context that manages the lifetime of a part.
    /// </summary>
    /// <typeparam name="T">The type of part.</typeparam>
    public class PartLifetimeContext<T> : IDisposable
    {
        /// <summary>
        /// Gets or sets the <see cref="Action" /> used for disposal.
        /// </summary>
        private readonly Action m_DisposeAction;

        /// <summary>
        /// Initializes a new instance of the <see cref="PartLifetimeContext{T}" /> class.
        /// </summary>
        /// <param name="exportedValue">The instance of the exported value.</param>
        /// <param name="dispose">The delegate used for disposal.</param>
        public PartLifetimeContext(T exportedValue, Action dispose)
        {
            ExportedValue = exportedValue;
            m_DisposeAction = dispose;
        }

        /// <summary>
        /// Gets the exported value.
        /// </summary>
        public T ExportedValue
        {
            get;
        }

        /// <summary>
        /// Releases managed resources used by this instance.
        /// </summary>
        void IDisposable.Dispose()
        {
            if (m_DisposeAction != null)
            {
                m_DisposeAction();
            }
        }
    }
}
