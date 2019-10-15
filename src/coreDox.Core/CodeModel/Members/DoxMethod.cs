using coreDox.Core.Model.Code.Base;
using Mono.Cecil;

namespace coreDox.Core.Model.Code.Members
{
    public class DoxMethod : DoxCodeModel
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
