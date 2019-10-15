using coreDox.Core.Model.Code.Base;
using Mono.Cecil;

namespace coreDox.Core.Model.Code.Members
{
    public class DoxField : DoxCodeModel
    {
        public DoxField(FieldDefinition fieldDefinition)
        {
            Name = fieldDefinition.Name;
            FullName = $"{fieldDefinition.DeclaringType.FullName}.{Name}";
            FieldDefinition = fieldDefinition;
        }
        
        public FieldDefinition FieldDefinition { get; }
    }
}
