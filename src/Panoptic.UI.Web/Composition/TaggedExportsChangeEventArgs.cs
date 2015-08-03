//-----------------------------------------------------------------------
// <copyright company="Panoptic">
//     Copyright 2013 Panoptic. Licensed under the Apache License, Version 2.0.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;

namespace Panoptic.UI.Web.Composition
{
    /// <summary>
    /// Defines the event arguments used for <see cref="ExportProvider" /> events.
    /// </summary>
    internal class TaggedExportsChangeEventArgs : ExportsChangeEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TaggedExportsChangeEventArgs" /> class.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="added">The set of added exports.</param>
        /// <param name="removed">The set of removed exports.</param>
        /// <param name="atomicComposition">The atomic composition of the exports.</param>
        public TaggedExportsChangeEventArgs(object sender, IEnumerable<ExportDefinition> added, IEnumerable<ExportDefinition> removed, AtomicComposition atomicComposition)
            : base(added, removed, atomicComposition)
        {
            Sender = sender;
        }

        /// <summary>
        /// Gets the sender of the event.
        /// </summary>
        public object Sender
        {
            get;
        }
    }
}