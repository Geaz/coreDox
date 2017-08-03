using coreDox.Core.Model.Code.Base;
using coreDox.Core.Contracts;

namespace coreDox.ModelProvider.Syntax
{
    public class SyntaxModelProvider
    {
        public IModel AmendModel(DoxCodeModel doxModel)
        {
            return new SyntaxModel();
        }
    }
}
