using coreDox.Core;
using coreDox.Core.Contracts;

namespace coreDox.Exporter.Html
{
    public class HtmlExporter : IExporter<HtmlConfig>
    {
        public void Export(string outputPath)
        {
            
        }

        public IProject Project { get; set; }

        public HtmlConfig Config { get; set; }

        public string ExporterName => "Html";
    }
}
