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
            TypeDefinition.Properties.ToList().ForEach(p => PropertyList.Add(new DoxProperty(p)));

            TypeDefinition.Fields
                .Where(f => f.IsPublic)
                .ToList()
                .ForEach(f => FieldList.Add(new DoxField(f)));

            // Add Methods, but not auto generated getters/setters, add/remove
            TypeDefinition.Methods
                .Where(m => m.IsPublic && !m.IsSetter && !m.IsGetter && !m.IsAddOn && !m.IsRemoveOn)
                .ToList()
                .ForEach(m => MethodList.Add(new DoxMethod(m)));

            TypeDefinition.NestedTypes
                .Where(n => n.IsPublic)
                .ToList()
                .ForEach(t => NestedTypeList.Add(new DoxType(t)));
        }

        public TypeDefinition TypeDefinition { get; }

        public List<DoxEvent> EventList { get; } = new List<DoxEvent>();
        public List<DoxField> FieldList { get; } = new List<DoxField>();
        public List<DoxMethod> MethodList { get; } = new List<DoxMethod>();
        public List<DoxProperty> PropertyList { get; } = new List<DoxProperty>();
        public List<DoxType> NestedTypeList { get; } = new List<DoxType>();
    }
}
