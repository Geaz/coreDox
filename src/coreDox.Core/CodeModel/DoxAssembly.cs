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

            Id = AssemblyDefinition.Assembly.Name.Name;
            Name = AssemblyDefinition.Name;

            ParseAssembly();
        }

        private void ParseAssembly()
        {
            var namespacesWithPublicTypesList = AssemblyDefinition.Types.Where(t => t.IsPublic).GroupBy(t => t.Namespace);
            foreach (var namespaceWithPublicTypes in namespacesWithPublicTypesList)
            {
                NamespaceList.Add(new DoxNamespace(namespaceWithPublicTypes.Key, namespaceWithPublicTypes.ToList()));
            }
        }

        public string AssemblyPath { get; }
        public ModuleDefinition AssemblyDefinition { get; }
        public List<DoxNamespace> NamespaceList { get; } = new List<DoxNamespace>();
    }
}