using coreDox.Core.Model.Code.Base;

namespace coreDox.Core.Model.Code
{
    public class DoxNamespace : DoxCodeModel
    {
        public DoxNamespace(string fullname)
        {
            Name = FullName = fullname;
        }
    }
}
