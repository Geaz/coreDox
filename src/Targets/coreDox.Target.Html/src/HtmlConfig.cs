using coreDox.Core.Contracts;

namespace coreDox.Target.Html
{
    public class HtmlConfig : IConfigSection
    {
        public bool ShowCode { get; set; } = false;
    }
}
