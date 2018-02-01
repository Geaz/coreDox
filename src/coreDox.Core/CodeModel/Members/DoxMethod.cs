using System.Reflection;
using coreDox.Core.Model.Code.Base;

namespace coreDox.Core.Model.Code.Members
{
    public class DoxMethod : DoxCodeModel
    {
        public DoxMethod(MethodInfo methodInfo)
        {
            MethodInfo = methodInfo;
            Name = methodInfo.Name;
            FullName = $"{methodInfo.DeclaringType.FullName}.{Name}";
        }

        /// <summary>
        /// The reflection <see cref="MethodInfo"/> for this code model method.
        /// </summary>
        public MethodInfo MethodInfo { get; }
    }
}
