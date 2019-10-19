using coreDox.Core.CodeModel.Base;
using Mono.Cecil;

namespace coreDox.Core.CodeModel.Members
{
    public sealed class DoxMethod : DoxCodeModel
    {
        public DoxMethod(MethodDefinition methodDefinition)
        {
            Id = DoxCodeId.GetCodeId(methodDefinition);
            Name = methodDefinition.Name;
            MethodDefinition = methodDefinition;
        }

        public MethodDefinition MethodDefinition { get; }
    }
}
