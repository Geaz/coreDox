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
                DoxType doxType => GetTypeSyntax(doxType),
                DoxMethod doxMethod => GetMethodSyntax(doxMethod),
                DoxEvent doxEvent => GetEventSyntax(doxEvent),
                DoxField doxField => GetFieldSyntax(doxField),
                DoxProperty doxProperty => GetPropertySyntax(doxProperty),
                _ => null
            };
            return model;
        }

        private SyntaxModel GetTypeSyntax(DoxType doxType)
        {
            return new SyntaxModel { Syntax = "**test**" };
        }

        private SyntaxModel GetMethodSyntax(DoxMethod doxMethod)
        {
            var returnType = new DoxTypeRef(doxMethod.MethodDefinition.ReturnType);
            return new SyntaxModel();
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
    }
}
