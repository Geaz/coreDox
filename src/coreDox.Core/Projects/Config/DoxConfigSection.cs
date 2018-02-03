using System.IO;
using coreDox.Core.Contracts;

namespace coreDox.Core.Projects.Config
{
    public sealed class DoxConfigSection : IConfigSection
    {
        public void SetDefaultValues(FileInfo configFileInfo)
        {
            ProjectName = configFileInfo.Directory.Parent.Name;
            OutputFolder = Path.Combine(configFileInfo.Directory.FullName, "build");
        }

        public string ProjectName { get; set; }

        public string OutputFolder { get; set; }
    }
}
