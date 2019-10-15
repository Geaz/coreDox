using coreDox.Core.Model.Code.Base;
using Mono.Cecil;
using System.Collections.Generic;

namespace coreDox.Core.Model.Code
{
    public class DoxNamespace : DoxCodeModel
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
