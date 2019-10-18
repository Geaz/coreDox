using coreDox.Core.CodeModel.Base;
using Mono.Cecil;

namespace coreDox.Core.CodeModel.Members
{
    public sealed class DoxProperty : DoxCodeModel
    {
        public DoxProperty(PropertyDefinition propertyDefinition)
        {
            Name = propertyDefinition.Name;
            FullName = $"{propertyDefinition.DeclaringType.FullName}.{Name}";
            PropertyDefinition = propertyDefinition;
        }

        public PropertyDefinition PropertyDefinition { get; }
    }
}
