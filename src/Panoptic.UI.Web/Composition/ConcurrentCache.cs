//-----------------------------------------------------------------------
// <copyright company="Panoptic">
//     Copyright 2013 Panoptic. Licensed under the Apache License, Version 2.0.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

namespace Panoptic.UI.Web.Composition
{
    /// <summary>
    /// Defines a thread-safe cache of objects.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TValue">The value for the specified key.</typeparam>
    internal class ConcurrentCache<TKey, TValue>
    {
        private readonly Dictionary<TKey, TValue> m_Cache = new Dictionary<TKey, TValue>();
        private readonly object m_Lock = new object();

        /// <summary>
        /// Gets the set of cached values.
        /// </summary>
        public IEnumerable<TValue> Values
        {
            get
            {
                lock (m_Lock)
                {
                    return m_Cache.Values.ToArray();
                }
            }
        }

        /// <summary>
        /// Fetches the value with the specified key.  If the value does not exist, create it.
        /// </summary>
        /// <param name="key">The key of the value.</param>
        /// <param name="creator">The delegate used to create the instance.</param>
        /// <returns>The value with the specified key.  If the value does not exist, create it.</returns>
        public TValue Fetch(TKey key, Func<TValue> creator)
        {
            lock (m_Lock)
            {
                TValue value;
                if (!m_Cache.TryGetValue(key, out value))
                {
                    m_Cache[key] = value = creator();
                }

                return value;
            }
        }
    }
}
