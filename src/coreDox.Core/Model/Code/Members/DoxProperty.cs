using coreDox.Core.Model.Code.Base;
using System.Reflection;

namespace coreDox.Core.Model.Code.Members
{
    public class DoxProperty : DoxCodeModel
    {
        public DoxProperty(PropertyInfo property)
        {
            Property = property;
            Name = property.Name;
            FullName = $"{property.DeclaringType.FullName}.{Name}";
        }

        /// <summary>
        /// The reflection <see cref="PropertyInfo"/> for this code model property.
        /// </summary>
        public PropertyInfo Property { get; }
    }
}
