using coreDox.Core.Model.Code.Base;
using System.Reflection;

namespace coreDox.Core.Model.Code
{
    public class DoxAssembly : DoxCodeModel
    {
        public DoxAssembly(Assembly assembly, string target)
        {
            Assembly = assembly;
            Target = target;
            Name = assembly.GetName().Name;
            FullName = assembly.GetName().FullName;
        }

        public Assembly Assembly { get; }

        public string Target { get; }
    }
}
