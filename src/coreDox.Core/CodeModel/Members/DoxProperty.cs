using coreDox.Core.Model.Code.Base;
using System.Reflection;

namespace coreDox.Core.Model.Code.Members
{
    public class DoxProperty : DoxCodeModel
    {
        public DoxProperty(PropertyInfo propertyInfo)
        {
            PropertyInfo = propertyInfo;
            Name = propertyInfo.Name;
            FullName = $"{propertyInfo.DeclaringType.FullName}.{Name}";
        }

        /// <summary>
        /// The reflection <see cref="PropertyInfo"/> for this code model property.
        /// </summary>
        public PropertyInfo PropertyInfo { get; }
    }
}
