using coreDox.Core.CodeModel.Base;
using Mono.Cecil;
using Mono.Cecil.Rocks;

namespace coreDox.Core.CodeModel.Members
{
    public sealed class DoxEvent : DoxCodeModel
    {
        public DoxEvent(EventDefinition eventDefinition)
        {
            Id = DocCommentId.GetDocCommentId(eventDefinition);
            Name = eventDefinition.Name;
            EventDefinition = eventDefinition;
        }
        
        public EventDefinition EventDefinition { get; }
    }
}
