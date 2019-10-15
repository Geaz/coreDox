using coreDox.Core.Contracts;
using coreDox.Core.Project.Common;

namespace coreDox.Core.Project.Config
{
    public sealed class DoxConfigSection : IConfigSection
    {
        public void SetDefaultValues(DoxFileInfo configFileInfo)
        {
            ProjectName = configFileInfo.Directory.ParentDirectory.Name;
            OutputFolder = "build";
        }

        public string ProjectName { get; set; }

        public string OutputFolder { get; set; }
    }
}
