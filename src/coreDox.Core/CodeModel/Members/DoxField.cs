using coreDox.Core.CodeModel.Base;
using Mono.Cecil;

namespace coreDox.Core.CodeModel.Members
{
    public sealed class DoxField : DoxCodeModel
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
