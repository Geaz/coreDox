using coreDox.Core.Model.Code.Base;
using System.Reflection;

namespace coreDox.Core.Model.Code
{
    public class DoxType : DoxCodeModel
    {
        public DoxType(TypeInfo typeInfo)
        {
            TypeInfo = typeInfo;
            Name = typeInfo.Name;
            FullName = typeInfo.FullName;
        }

        private void ParseMembers()
        {
            foreach(var member in TypeInfo.DeclaredConstructors)
            {
            }
        }

        /// <summary>
        /// The reflection type for this code model type.
        /// </summary>
        public TypeInfo TypeInfo { get; }
    }
}
