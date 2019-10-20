using coreDox.Core.CodeModel.Base;
using Mono.Cecil;
using System.Collections.Generic;
using System.Linq;

namespace coreDox.Core.CodeModel
{
    public sealed class DoxNamespace : DoxCodeModel
    {
        public DoxNamespace(string name, List<TypeDefinition> typeList)
        {
            Id = $"N:{name}";
            Name = name;

            ParseNamespace(typeList);
        }

        public DoxType GetTypeById(string id)
        {
            return TypeList.SingleOrDefault(t => t.Id == id);
        }

        private void ParseNamespace(List<TypeDefinition> typeList)
        {
            typeList.ForEach(t =>
            {
                TypeList.Add(new DoxType(t));
                ParseNamespace(t.NestedTypes.ToList());
            });
        }

        public List<DoxType> TypeList { get; } = new List<DoxType>();
    }
}
