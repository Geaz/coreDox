﻿using coreDox.Core.Model.Code.Base;

namespace coreDox.Core.Contracts
{
    public interface IModelProvider
    {
        object AmendModel(DoxCodeModel doxModel);
    }

    public interface IModelProvider<TModel> : IModelProvider where TModel : new() { }
}
