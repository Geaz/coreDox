using coreDox.Core.CodeModel.Base;
using Mono.Cecil;

namespace coreDox.Core.CodeModel.Members
{
    public sealed class DoxMethod : DoxCodeModel
    {
        public DoxMethod(MethodDefinition methodDefinition)
        {
            Name = methodDefinition.Name;
            FullName = $"{methodDefinition.DeclaringType.FullName}.{Name}";
            MethodDefinition = methodDefinition;
        }
        
        public MethodDefinition MethodDefinition { get; }
    }
}
