using coreDox.Core.Exceptions;
using coreDox.Core.Project.Common;
using System;
using System.Linq;
using System.IO;
using System.Text;

namespace coreDox.Core.Project.Pages
{
    public enum DoxPageType
    {
        Placeholder,
        Page,
        Code,
    }

    public sealed class DoxPage
    {
        private DateTime _lastLoadTimeUtc;

        private readonly DoxFileInfo _doxPageFileInfo;

        public DoxPage(DoxFileInfo doxPageFileInfo)
        {
            _doxPageFileInfo = doxPageFileInfo;
        }

        public void WritePage(string title, string content, string projectPath)
        {
            var pageBuilder = new StringBuilder();
            pageBuilder.AppendLine($"---");
            pageBuilder.AppendLine($"- title: {title}");

            if(!string.IsNullOrEmpty(projectPath))
                pageBuilder.AppendLine($"- project: {projectPath}");

            pageBuilder.AppendLine($"---");
            pageBuilder.AppendLine(content);

            File.WriteAllText(_doxPageFileInfo.FullName, pageBuilder.ToString());
        }
        
        private void CheckLoad()
        {
            if (!_doxPageFileInfo.Exists) throw new CoreDoxException($"No page file found at '{_doxPageFileInfo.FullName}'!");
            if (_lastLoadTimeUtc < _doxPageFileInfo.LastWriteTimeUtc)
            {
                var content = File.ReadAllText(_doxPageFileInfo.FullName);

                _lastLoadTimeUtc = _doxPageFileInfo.LastWriteTimeUtc;
            }
        }

        private void ParseLine(string line)
        {

        }

        private DoxPageType _pageType;
        public DoxPageType PageType
        {
            get { CheckLoad(); return _pageType; }
        }

        private string _title;
        public string Title
        {
            get { CheckLoad(); return _title; }
        }

        private string _content;
        public string Content
        {
            get { CheckLoad(); return _content; }
        }

        private string _codeProjectPath;
        public string CodeProjectPath
        {
            get { CheckLoad(); return _codeProjectPath; }
        }
    }
}
