using System;
using System.IO;

namespace coreDox.Core.Project.Common
{
    public sealed class DoxFileInfo
    {
        private bool _created;
        private readonly FileInfo _fileInfo;

        public DoxFileInfo(string filePath)
        {
            _fileInfo = new FileInfo(filePath);
            Directory = new DoxDirectoryInfo(_fileInfo.Directory.FullName);
        }

        public bool EnsureFile()
        {
            _fileInfo.Refresh();
            if (!_fileInfo.Exists)
            {
                _fileInfo.Create().Close();
                _created = true;
            }
            return _created;
        }

        public string GetRelativePath(DoxDirectoryInfo doxDirectoryInfo)
        {
            var uriFrom = new Uri(FullName);
            var uriTo = new Uri(doxDirectoryInfo.FullName);
            return uriTo.MakeRelativeUri(uriFrom).ToString();
        }

        public string Name => _fileInfo.Name;
        public string NameWithOutExtension => Path.GetFileNameWithoutExtension(_fileInfo.FullName);
        public string FullName => _fileInfo.FullName;

        public bool Exists { get { _fileInfo.Refresh(); return _fileInfo.Exists; } }
        public bool Created => _created;
        public bool Existed => !_created && Exists;
        public DateTime LastWriteTimeUtc { get { _fileInfo.Refresh(); return _fileInfo.LastWriteTimeUtc; } }

        public DoxDirectoryInfo Directory { get; }
    }
}
