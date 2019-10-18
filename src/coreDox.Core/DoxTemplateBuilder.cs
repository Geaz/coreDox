using CommonMark;
using coreDox.Core.Model.Code;
using coreDox.Core.Model.Code.Members;
using DotLiquid;
using System.Linq;

namespace coreDox.Core
{
    public sealed class DoxTemplateBuilder
    {
        public DoxTemplateBuilder()
        {
            // Register the DoxCodeModel as save types
            Template.RegisterSafeType(typeof(DoxAssembly), typeof(DoxAssembly).GetMembers().Select(m => m.Name).ToArray());
            Template.RegisterSafeType(typeof(DoxNamespace), typeof(DoxNamespace).GetMembers().Select(m => m.Name).ToArray());
            Template.RegisterSafeType(typeof(DoxType), typeof(DoxType).GetMembers().Select(m => m.Name).ToArray());
            Template.RegisterSafeType(typeof(DoxEvent), typeof(DoxEvent).GetMembers().Select(m => m.Name).ToArray());
            Template.RegisterSafeType(typeof(DoxField), typeof(DoxField).GetMembers().Select(m => m.Name).ToArray());
            Template.RegisterSafeType(typeof(DoxMethod), typeof(DoxMethod).GetMembers().Select(m => m.Name).ToArray());
            Template.RegisterSafeType(typeof(DoxProperty), typeof(DoxProperty).GetMembers().Select(m => m.Name).ToArray());

            // Register Models
            foreach(var modelType in PluginRegistry.Instance().GetAllModelTypes())
            {
                Template.RegisterSafeType(modelType, modelType.GetMembers().Select(m => m.Name).ToArray());
            }

            // Register Filters
            Template.RegisterFilter(typeof(DotLiquidFilters));
        }

        public string Render(string template, object data)
        {
            return Template.Parse(template).Render(Hash.FromAnonymousObject(new { data }));
        }
    }

    internal static class DotLiquidFilters
    {
        public static string Html(string input)
        {
            return CommonMarkConverter.Convert(input);
        }
    }
}
