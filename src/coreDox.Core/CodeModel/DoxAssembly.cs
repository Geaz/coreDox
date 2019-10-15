using coreDox.Core.Model.Code.Base;
using Mono.Cecil;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace coreDox.Core.Model.Code
{
    public class DoxAssembly : DoxCodeModel
    {
        public DoxAssembly(string assemblyPath)
        {
            AssemblyPath = assemblyPath;
            AssemblyDefinition = ModuleDefinition.ReadModule(assemblyPath);
            Name = AssemblyDefinition.Name;
            FullName = AssemblyDefinition.FileName;
            TargetFramework = AssemblyDefinition.RuntimeVersion;
        }

        public DoxNamespace GetOrAddNamespace(string namespaceIdentifier)
        {
            return DoxNamespaceSet.GetOrAdd(new DoxNamespace(namespaceIdentifier));
        }

        public string AssemblyPath { get; }

        public string TargetFramework { get; }

        public ModuleDefinition AssemblyDefinition { get; }

        public HashSet<DoxNamespace> DoxNamespaceSet { get; } = new HashSet<DoxNamespace>();
    }
}