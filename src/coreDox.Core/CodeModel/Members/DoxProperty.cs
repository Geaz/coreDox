using coreDox.Core.Model.Code.Base;
using Mono.Cecil;

namespace coreDox.Core.Model.Code.Members
{
    public class DoxProperty : DoxCodeModel
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
