using coreDox.Core.CodeModel.Base;
using Mono.Cecil;
using Mono.Cecil.Rocks;

namespace coreDox.Core.CodeModel.Members
{
    public sealed class DoxMethod : DoxCodeModel
    {
        public DoxMethod(MethodDefinition methodDefinition)
        {
            Id = DocCommentId.GetDocCommentId(methodDefinition);
            Name = methodDefinition.Name;
            MethodDefinition = methodDefinition;
        }

        public MethodDefinition MethodDefinition { get; }
    }
}
