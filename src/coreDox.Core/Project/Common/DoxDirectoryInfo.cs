using System;
using System.IO;

namespace coreDox.Core.Project.Common
{
    public sealed class DoxDirectoryInfo
    {
        private bool _created;
        private readonly DirectoryInfo _directoryInfo;

        public DoxDirectoryInfo(string directoryPath)
        {
            _directoryInfo = new DirectoryInfo(directoryPath);
        }

        public bool EnsureDirectory()
        {
            _directoryInfo.Refresh();
            if (!_directoryInfo.Exists)
            {
                _directoryInfo.Create();
                _created = true;
            }
            return _created;
        }

        public string Name => _directoryInfo.Name;
        public string FullName => _directoryInfo.FullName;

        public bool Exists { get { _directoryInfo.Refresh(); return _directoryInfo.Exists; } }
        public bool Created => _created;
        public bool Existed => !_created && Exists;
        public DateTime LastWriteTimeUtc { get { _directoryInfo.Refresh(); return _directoryInfo.LastWriteTimeUtc; } }

        private DoxDirectoryInfo _parentDirectory;
        public DoxDirectoryInfo ParentDirectory => _parentDirectory ?? (_parentDirectory = new DoxDirectoryInfo(_directoryInfo.Parent.FullName));
    }
}
