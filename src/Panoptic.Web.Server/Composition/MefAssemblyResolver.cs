using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http.Dispatcher;

namespace Panoptic.Web.Server.Composition
{
    /// <summary>
    /// Provides an implementation of System.Web.Http.Dispatcher.IAssembliesResolver 
    /// with no external dependencies.
    /// </summary>
    public class MefAssemblyResolver : DefaultAssembliesResolver
    {
        private readonly List<string> m_AssemblyPaths
            = new List<string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="MefAssemblyResolver"/> class.
        /// </summary>
        /// <param name="assemblyPaths">The collection of directories in which the assemblies are placed.</param>
        public MefAssemblyResolver(IEnumerable<string> assemblyPaths)
        {
            {
                Lokad.Enforce.Argument(() => assemblyPaths);
            }

            m_AssemblyPaths.AddRange(assemblyPaths);
        }

        /// <summary>
        /// Returns a list of assemblies available for the application.
        /// </summary>
        /// <returns>A collection of assemblies.</returns>
        public override ICollection<Assembly> GetAssemblies()
        {
            ICollection<Assembly> baseAssemblies = base.GetAssemblies();
            List<Assembly> assemblies = new List<Assembly>(baseAssemblies);

            foreach (var path in m_AssemblyPaths)
            {
                var assemblyPaths = Directory.GetFiles(path, "*.dll", SearchOption.AllDirectories);
                foreach (var assemblyPath in assemblyPaths)
                {
                    var assembly = LoadAssembly(assemblyPath);
                    if (assembly != null)
                    {
                        baseAssemblies.Add(assembly);
                    }
                }
            }

            return assemblies;
        }

        private Assembly LoadAssembly(string file)
        {
            if (file == null)
            {
                return null;
            }

            if (file.Length == 0)
            {
                return null;
            }

            // Check if the file exists.
            if (!File.Exists(file))
            {
                return null;
            }

            // Try to load the assembly. If we can't load the assembly
            // we log the exception / problem and return a null reference
            // for the assembly.
            string fileName = Path.GetFileNameWithoutExtension(file);
            try
            {
                // Only use the file name of the assembly
                return Assembly.Load(fileName);
            }
            catch (FileNotFoundException)
            {
                // The file does not exist. Only possible if somebody removes the file
                // between the check and the loading.
                return null;
            }
            catch (FileLoadException)
            {
                // Could not load the assembly.
                return null;
            }
            catch (BadImageFormatException)
            {
                // incorrectly formatted assembly.
                return null;
            }
        }
    }
}