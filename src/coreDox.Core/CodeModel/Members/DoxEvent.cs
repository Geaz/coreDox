using coreDox.Core.CodeModel.Base;
using Mono.Cecil;

namespace coreDox.Core.CodeModel.Members
{
    public sealed class DoxEvent : DoxCodeModel
    {
        public DoxEvent(EventDefinition eventDefinition)
        {
            Name = eventDefinition.Name;
            FullName = $"{eventDefinition.DeclaringType.FullName}.{Name}";
            EventDefinition = eventDefinition;
        }
        
        public EventDefinition EventDefinition { get; }
    }
}
