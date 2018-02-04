using coreDox.Core.Contracts;
using coreDox.Core.Exceptions;
using System.IO;

namespace coreDox.Core.Project.Pages
{
    public sealed class DoxPage
    {
        private bool _loaded;

        private readonly FileInfo _doxPageFile;

        public DoxPage(string pagePath, string title = "", string project = "")
        {
            _doxPageFile = new FileInfo(pagePath);
            Title = title;
            Project = project;
        }

        public void Load()
        {
            if (!Exists) CreateDefaultPage();
            //return new DoxPage(_doxPageFile.FullName) { Content = "" };
        }

        private void CreateDefaultPage()
        {

        }

        public bool Exists => _doxPageFile.Exists;

        public string Title { get; private set; }

        public string Project { get; private set; }

        public string Content { get; private set; }
    }
}
