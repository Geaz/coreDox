using coreDox.Core.CodeModel.Base;
using Mono.Cecil;

namespace coreDox.Core.CodeModel.Members
{
    public sealed class DoxEvent : DoxCodeModel
    {
        public DoxEvent(EventDefinition eventDefinition)
        {
            Id = DoxCodeId.GetCodeId(eventDefinition);
            Name = eventDefinition.Name;
            EventDefinition = eventDefinition;
        }
        
        public EventDefinition EventDefinition { get; }
    }
}
