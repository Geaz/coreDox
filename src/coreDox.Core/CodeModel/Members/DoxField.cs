using coreDox.Core.CodeModel.Base;
using Mono.Cecil;

namespace coreDox.Core.CodeModel.Members
{
    public sealed class DoxField : DoxCodeModel
    {
        public DoxField(FieldDefinition fieldDefinition)
        {
            Id = DoxCodeId.GetCodeId(fieldDefinition);
            Name = fieldDefinition.Name;
            FieldDefinition = fieldDefinition;
        }
        
        public FieldDefinition FieldDefinition { get; }
    }
}
