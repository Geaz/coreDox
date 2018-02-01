using coreDox.Core.Model.Code.Base;

namespace coreDox.Core.Contracts
{
    public interface IModelProvider
    {
        IModel AmendModel(DoxCodeModel doxModel);

    }
}
