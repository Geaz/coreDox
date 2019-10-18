using coreDox.Core.Model.Code.Base;
using coreDox.Core.Contracts;
using coreDox.Core.Model.Code;

namespace coreDox.ModelProvider.Syntax
{
    public class SyntaxModelProvider : IModelProvider<SyntaxModel>
    {
        public object AmendModel(DoxCodeModel doxModel)
        {
            SyntaxModel model = null;
            if(doxModel is DoxType doxType)
            {
                model = new SyntaxModel { Syntax = "**test**" };
            }
            return model;
        }
    }
}
