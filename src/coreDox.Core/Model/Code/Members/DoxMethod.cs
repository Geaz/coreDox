using System.Reflection;
using coreDox.Core.Model.Code.Base;

namespace coreDox.Core.Model.Code.Members
{
    public class DoxMethod : DoxCodeModel
    {
        public DoxMethod(MethodInfo method)
        {
            Method = method;
            Name = method.Name;
            FullName = $"{method.DeclaringType.FullName}.{Name}";
        }

        /// <summary>
        /// The reflection <see cref="MethodInfo"/> for this code model method.
        /// </summary>
        public MethodInfo Method { get; }
    }
}
