using System.IO;

namespace coreDox.Core.Contracts
{
    public interface IConfigSection
    {
        void SetDefaultValues(FileInfo configFileInfo);
    }
}
