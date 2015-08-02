//-----------------------------------------------------------------------
// <copyright company="Panoptic">
//     Copyright 2013 Panoptic. Licensed under the Apache License, Version 2.0.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Reflection;

namespace Panoptic.Areas.HelpPage.ModelDescriptions
{
    /// <summary>
    /// Defines the members for an instance that provides documentation for a given API member.
    /// </summary>
    public interface IModelDocumentationProvider
    {
        /// <summary>
        /// Returns the documentation for the given API member.
        /// </summary>
        /// <param name="member">The member.</param>
        /// <returns>The documenation for the given member.</returns>
        string GetDocumentation(MemberInfo member);

        /// <summary>
        /// Returns the documentation for a given type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>The documentation for the given type.</returns>
        string GetDocumentation(Type type);
    }
}
