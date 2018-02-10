using coreDox.Core.Project.Common;
using System;

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

        }
        
        private void CheckLoad()
        {
            if (_lastLoadTimeUtc < _doxPageFileInfo.LastWriteTimeUtc)
            {
                _lastLoadTimeUtc = _doxPageFileInfo.LastWriteTimeUtc;
            }
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
