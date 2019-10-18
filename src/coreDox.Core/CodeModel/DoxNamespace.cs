using coreDox.Core.CodeModel.Base;
using Mono.Cecil;
using System.Collections.Generic;

namespace coreDox.Core.CodeModel
{
    public sealed class DoxNamespace : DoxCodeModel
    {
        public DoxNamespace(string fullname, List<TypeDefinition> typeList)
        {
            Name = FullName = fullname;
            ParseNamespace(typeList);
        }

        private void ParseNamespace(List<TypeDefinition> typeList)
        {
            typeList.ForEach(t => DoxTypeSet.Add(new DoxType(t)));
        }

        public List<DoxType> DoxTypeSet { get; } = new List<DoxType>();
    }
}
