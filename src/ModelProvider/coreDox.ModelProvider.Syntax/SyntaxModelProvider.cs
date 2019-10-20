using coreDox.Core.CodeModel;
using coreDox.Core.CodeModel.Base;
using coreDox.Core.CodeModel.Members;
using coreDox.Core.Contracts;

namespace coreDox.ModelProvider.Syntax
{
    public class SyntaxModelProvider : IModelProvider<SyntaxModel>
    {
        public object AmendModel(DoxCodeModel doxModel)
        {
            var model = doxModel switch
            {
                DoxEvent doxEvent => GetEventSyntax(doxEvent),
                DoxField doxField => GetFieldSyntax(doxField),
                DoxProperty doxProperty => GetPropertySyntax(doxProperty),
                DoxMethod doxMethod => GetMethodSyntax(doxMethod),
                DoxType doxType => GetTypeSyntax(doxType),
                _ => null
            };
            return model;
        }

        private SyntaxModel GetEventSyntax(DoxEvent doxEvent)
        {
            return new SyntaxModel();
        }

        private SyntaxModel GetFieldSyntax(DoxField doxField)
        {
            return new SyntaxModel();
        }

        private SyntaxModel GetPropertySyntax(DoxProperty doxProperty)
        {
            return new SyntaxModel();
        }

        private SyntaxModel GetMethodSyntax(DoxMethod doxMethod)
        {
            return new SyntaxModel();
        }

        private SyntaxModel GetTypeSyntax(DoxType doxType)
        {
            return new SyntaxModel { Syntax = "**test**" };
        }
    }
}
