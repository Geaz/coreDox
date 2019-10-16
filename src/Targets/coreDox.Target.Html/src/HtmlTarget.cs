using coreDox.Core.Contracts;
using coreDox.Core.Project;

namespace coreDox.Target.Html
{
    public sealed class HtmlTarget : ITarget<HtmlConfigSection>
    {
        public void Export(DoxProject project, string outputPath)
        {
            var htmlConfig = project.Config.GetConfigSection<HtmlConfigSection>();

        }
    }
}
