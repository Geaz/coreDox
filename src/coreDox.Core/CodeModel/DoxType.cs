using coreDox.Core.CodeModel.Base;
using coreDox.Core.CodeModel.Members;
using Mono.Cecil;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace coreDox.Core.CodeModel
{
    [DebuggerDisplay("{Id}")]
    public sealed class DoxType : DoxCodeModel
    {
        public DoxType(TypeDefinition typeDefinition)
        {
            Id = DoxCodeId.GetCodeId(typeDefinition);
            Name = typeDefinition.Name;
            TypeDefinition = typeDefinition;

            ParseType();
        }

        public DoxCodeModel GetMemberById(string id)
        {
            return id.Substring(0, 2) switch
            {
                "E:" => EventList.SingleOrDefault(e => e.Id == id),
                "F:" => FieldList.SingleOrDefault(e => e.Id == id),
                "M:" => MethodList.SingleOrDefault(e => e.Id == id),
                "P:" => PropertyList.SingleOrDefault(e => e.Id == id),
                _ => null
            };
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
        }

        public TypeDefinition TypeDefinition { get; }

        public List<DoxEvent> EventList { get; } = new List<DoxEvent>();
        public List<DoxField> FieldList { get; } = new List<DoxField>();
        public List<DoxMethod> MethodList { get; } = new List<DoxMethod>();
        public List<DoxProperty> PropertyList { get; } = new List<DoxProperty>();
    }
}
