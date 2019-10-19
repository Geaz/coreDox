using coreDox.Core.CodeModel.Base;
using Mono.Cecil;
using System.Collections.Generic;

namespace coreDox.Core.CodeModel
{
    public sealed class DoxNamespace : DoxCodeModel
    {
        public DoxNamespace(string name, List<TypeDefinition> typeList)
        {
            Id = name;
            Name = name;

            ParseNamespace(typeList);
        }

        private void ParseNamespace(List<TypeDefinition> typeList)
        {
            typeList.ForEach(t => TypeList.Add(new DoxType(t)));
        }

        public List<DoxType> TypeList { get; } = new List<DoxType>();
    }
}
