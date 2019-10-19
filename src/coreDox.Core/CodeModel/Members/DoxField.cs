using coreDox.Core.CodeModel.Base;
using Mono.Cecil;
using Mono.Cecil.Rocks;

namespace coreDox.Core.CodeModel.Members
{
    public sealed class DoxField : DoxCodeModel
    {
        public DoxField(FieldDefinition fieldDefinition)
        {
            Id = DocCommentId.GetDocCommentId(fieldDefinition);
            Name = fieldDefinition.Name;
            FieldDefinition = fieldDefinition;
        }
        
        public FieldDefinition FieldDefinition { get; }
    }
}
