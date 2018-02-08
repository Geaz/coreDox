using coreDox.Core.Project.Common;

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
        private bool _loaded;
        private readonly DoxFileInfo _doxPageFileInfo;

        public DoxPage(DoxFileInfo doxPageFileInfo)
        {
            _doxPageFileInfo = doxPageFileInfo;
        }

        public bool Exists => _doxPageFileInfo.Exists;

        public void WritePage(string title, string content, string projectPath)
        {

        }
        
        private void LoadPage()
        {

        }

        public string Title { get; }

        public string Content { get; }

        public DoxPageType PageType { get; }

        public DoxFileInfo CodeProjectFileInfo { get; }
    }
}
