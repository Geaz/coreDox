using System.Reflection;
using coreDox.Core.Model.Code.Base;

namespace coreDox.Core.Model.Code.Members
{
    public class DoxField : DoxCodeModel
    {
        public DoxField(FieldInfo field)
        {
            Field = field;
            Name = field.Name;
            FullName = $"{field.DeclaringType.FullName}.{Name}";
        }

        /// <summary>
        /// The reflection <see cref="FieldInfo"/> for this code model field.
        /// </summary>
        public FieldInfo Field { get; }
    }
}
