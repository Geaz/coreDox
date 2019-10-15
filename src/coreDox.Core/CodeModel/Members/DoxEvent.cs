using coreDox.Core.Model.Code.Base;
using Mono.Cecil;

namespace coreDox.Core.Model.Code.Members
{
    public class DoxEvent : DoxCodeModel
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
