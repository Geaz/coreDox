using coreDox.Core.Model.Code.Base;
using System.Collections.Generic;
using System.Reflection;

namespace coreDox.Core.Model.Code
{
    public class DoxAssembly : DoxCodeModel
    {
        public DoxAssembly(string targetFramework, Assembly assembly)
        {
            Assembly = assembly;
            TargetFramework = targetFramework;
            Name = assembly.GetName().Name;
            FullName = assembly.GetName().FullName;
        }

        public DoxNamespace GetOrAddNamespace(string namespaceIdentifier)
        {
            return DoxNamespaceSet.GetOrAdd(new DoxNamespace(namespaceIdentifier));
        }

        public string TargetFramework { get; }

        public Assembly Assembly { get; }

        public HashSet<DoxNamespace> DoxNamespaceSet { get; } = new HashSet<DoxNamespace>();
    }
}

/*
 * if (!File.Exists(assemblyLocation))
            {
                throw new CoreDoxException($"No assembly found at '{assemblyLocation}'! Please check your configuration file.");
            }

            var assemblyName = AssemblyLoadContext.GetAssemblyName(assemblyLocation);
            Assembly = Assembly.Load(assemblyName);

            Target = target;
            Location = assemblyLocation;
            Name = assemblyName.Name;
            FullName = assemblyName.FullName;
*/