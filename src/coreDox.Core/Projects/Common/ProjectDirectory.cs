using System.IO;

namespace coreDox.Core.Projects
{
    public sealed class ProjectDirectory
    {
        private bool _created;

        private DirectoryInfo _directoryInfo;

        public ProjectDirectory(string directoryPath)
        {
            _directoryInfo = new DirectoryInfo(directoryPath);
            EnsureDirectory();
        }

        private void EnsureDirectory()
        {
            if (!_directoryInfo.Exists)
            {
                _directoryInfo.Create();
                _created = true;
            }
        }

        public string Name => _directoryInfo.Name;
        public string FullName => _directoryInfo.FullName;

        public bool Created => _created;
        public bool Existed => !_created;
        public bool Exists => _directoryInfo.Exists;
    }
}
