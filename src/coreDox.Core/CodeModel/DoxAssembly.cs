using coreDox.Core.CodeModel.Base;
using Mono.Cecil;
using System.Collections.Generic;
using System.Linq;

namespace coreDox.Core.CodeModel
{
    public sealed class DoxAssembly : DoxCodeModel
    {
        public DoxAssembly(string assemblyPath)
        {
            AssemblyPath = assemblyPath;
            AssemblyDefinition = ModuleDefinition.ReadModule(assemblyPath, new ReaderParameters { ReadSymbols = true });

            Name = AssemblyDefinition.Name;
            FullName = AssemblyDefinition.FileName;
            TargetFramework = AssemblyDefinition.RuntimeVersion;

            ParseAssembly();
        }

        private void ParseAssembly()
        {
            var namespacesWithPublicTypesList = AssemblyDefinition.Types.Where(t => t.IsPublic).GroupBy(t => t.Namespace);
            foreach (var namespaceWithPublicTypes in namespacesWithPublicTypesList)
            {
                DoxNamespaceSet.Add(new DoxNamespace(namespaceWithPublicTypes.Key, namespaceWithPublicTypes.ToList()));
            }
        }

        public string AssemblyPath { get; }
        public string TargetFramework { get; }
        public ModuleDefinition AssemblyDefinition { get; }
        public List<DoxNamespace> DoxNamespaceSet { get; } = new List<DoxNamespace>();
    }
}