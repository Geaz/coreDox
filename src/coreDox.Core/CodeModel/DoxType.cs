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
            Name = typeDefinition.Name;
            FullName = typeDefinition.FullName;
            TypeDefinition = typeDefinition;

            ParseType();
        }

        private void ParseType()
        {
            TypeDefinition.Events.ToList().ForEach(e => DoxEventSet.Add(new DoxEvent(e)));
            TypeDefinition.Fields.ToList().ForEach(f => DoxFieldSet.Add(new DoxField(f)));
            TypeDefinition.Methods.ToList().ForEach(m => DoxMethodSet.Add(new DoxMethod(m)));
            TypeDefinition.Properties.ToList().ForEach(p => DoxPropertySet.Add(new DoxProperty(p)));
        }

        public TypeDefinition TypeDefinition { get; }
        public List<DoxEvent> DoxEventSet { get; } = new List<DoxEvent>();
        public List<DoxField> DoxFieldSet { get; } = new List<DoxField>();
        public List<DoxMethod> DoxMethodSet { get; } = new List<DoxMethod>();
        public List<DoxProperty> DoxPropertySet { get; } = new List<DoxProperty>();
    }
}
