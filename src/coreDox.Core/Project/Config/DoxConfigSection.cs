using coreDox.Core.Contracts;
using System.Collections.Generic;

namespace coreDox.Core.Project.Config
{
    public sealed class DoxConfigSection : IConfigSection
    {
        public string ProjectName { get; set; } = "Doc Project";

        public string OutputFolder { get; set; } = "build";

        public List<string> Targets { get; set; } = new List<string> { "HtmlTarget" };
    }
}
