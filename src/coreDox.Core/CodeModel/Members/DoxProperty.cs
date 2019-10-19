using coreDox.Core.CodeModel.Base;
using Mono.Cecil;
using Mono.Cecil.Rocks;

namespace coreDox.Core.CodeModel.Members
{
    public sealed class DoxProperty : DoxCodeModel
    {
        public DoxProperty(PropertyDefinition propertyDefinition)
        {
            Id = DocCommentId.GetDocCommentId(propertyDefinition);
            Name = propertyDefinition.Name;
            PropertyDefinition = propertyDefinition;
        }

        public PropertyDefinition PropertyDefinition { get; }
    }
}
