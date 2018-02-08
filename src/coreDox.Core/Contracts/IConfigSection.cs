using coreDox.Core.Project.Common;

namespace coreDox.Core.Contracts
{
    public interface IConfigSection
    {
        void SetDefaultValues(DoxFileInfo configFileInfo);
    }
}
