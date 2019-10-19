using coreDox.Core.CodeModel.Base;
using coreDox.Core.CodeModel.Members;
using Mono.Cecil;
using System.Collections.Generic;
using System.Linq;

namespace coreDox.Core.CodeModel
{
    public sealed class DoxType : DoxCodeModel
    {
        public DoxType(TypeDefinition typeDefinition)
        {
            Id = DoxCodeId.GetCodeId(typeDefinition);
            Name = typeDefinition.Name;
            TypeDefinition = typeDefinition;

            ParseType();
        }

        private void ParseType()
        {
            TypeDefinition.Events.ToList().ForEach(e => EventList.Add(new DoxEvent(e)));
            TypeDefinition.Fields.ToList().ForEach(f => FieldList.Add(new DoxField(f)));
            TypeDefinition.Methods.ToList().ForEach(m => MethodList.Add(new DoxMethod(m)));
            TypeDefinition.Properties.ToList().ForEach(p => PropertyList.Add(new DoxProperty(p)));
        }

        public TypeDefinition TypeDefinition { get; }
        public List<DoxEvent> EventList { get; } = new List<DoxEvent>();
        public List<DoxField> FieldList { get; } = new List<DoxField>();
        public List<DoxMethod> MethodList { get; } = new List<DoxMethod>();
        public List<DoxProperty> PropertyList { get; } = new List<DoxProperty>();
    }
}
