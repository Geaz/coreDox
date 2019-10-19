using coreDox.Core.CodeModel.Base;
using Mono.Cecil;

namespace coreDox.Core.CodeModel.Members
{
    public sealed class DoxProperty : DoxCodeModel
    {
        public DoxProperty(PropertyDefinition propertyDefinition)
        {
            Id = DoxCodeId.GetCodeId(propertyDefinition);
            Name = propertyDefinition.Name;
            PropertyDefinition = propertyDefinition;
        }

        public PropertyDefinition PropertyDefinition { get; }
    }
}
