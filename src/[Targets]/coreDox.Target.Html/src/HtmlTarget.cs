using coreDox.Core.Contracts;
using coreDox.Core.Project;

namespace coreDox.Target.Html
{
    public sealed class HtmlTarget : ITarget<HtmlConfig>
    {
        public void Write(string outputPath)
        {
            throw new System.NotImplementedException();
        }

        public DoxProject Project { get; set; }

        public HtmlConfig Config { get; set; }

        public string Name => "Html";
    }
}
