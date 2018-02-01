using coreDox.Core.Model.Code.Base;
using System.Collections.Generic;
using System.Reflection;

namespace coreDox.Core.Model.Code
{
    public class DoxNamespace : DoxCodeModel
    {
        public DoxNamespace(string fullname)
        {
            Name = FullName = fullname;
        }

        public DoxType GetOrAddType(TypeInfo typeInfo)
        {
            return DoxTypeSet.GetOrAdd(new DoxType(typeInfo));
        }

        public HashSet<DoxType> DoxTypeSet { get; } = new HashSet<DoxType>();
    }
}
