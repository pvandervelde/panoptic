//-----------------------------------------------------------------------
// <copyright company="Panoptic">
//     Copyright 2013 Panoptic. Licensed under the Apache License, Version 2.0.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace Panoptic.Areas.HelpPage.ModelDescriptions
{
    /// <summary>
    /// Provides helper methods for model naming.
    /// </summary>
    internal static class ModelNameHelper
    {
        /// <summary>
        /// Gets the name of the model.
        /// </summary>
        /// <param name="type">The model type.</param>
        /// <returns>The name of the model.</returns>
        public static string GetModelName(Type type)
        {
            // Modify this to provide custom model name mapping.
            ModelNameAttribute modelNameAttribute = type.GetCustomAttribute<ModelNameAttribute>();
            if (modelNameAttribute != null && !string.IsNullOrEmpty(modelNameAttribute.Name))
            {
                return modelNameAttribute.Name;
            }

            string modelName = type.Name;
            if (type.IsGenericType)
            {
                // Format the generic type name to something like: GenericOfAgurment1AndArgument2
                Type genericType = type.GetGenericTypeDefinition();
                Type[] genericArguments = type.GetGenericArguments();
                string genericTypeName = genericType.Name;

                // Trim the generic parameter counts from the name
                genericTypeName = genericTypeName.Substring(0, genericTypeName.IndexOf('`'));
                string[] argumentTypeNames = genericArguments.Select(t => GetModelName(t)).ToArray();
                modelName = string.Format(CultureInfo.InvariantCulture, "{0}Of{1}", genericTypeName, string.Join("And", argumentTypeNames));
            }

            return modelName;
        }
    }
}
