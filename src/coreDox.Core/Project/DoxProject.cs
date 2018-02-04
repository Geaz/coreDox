using coreDox.Core.Contracts;
using coreDox.Core.Project.Common;
using coreDox.Core.Project.Config;
using System.IO;
using System.Linq;

namespace coreDox.Core.Project
{
    public sealed class DoxProject : IProject
    {
        public const string ConfigFileName  = "config.json";
        public const string AssetFolderName = "assets";
        public const string PagesFolderName = "pages";
        public const string LayoutFolderName = "layout";

        private DoxProjectLoadResultList _projectLoadResultList;
        
        private readonly DoxDirectoryInfo _rootProjectDirectory;
        private readonly DoxDirectoryInfo _assetDirectory;
        private readonly DoxDirectoryInfo _pagesDirectory;
        private readonly DoxDirectoryInfo _layoutDirectory;

        public DoxProject(DoxProjectConfig projectConfig)
        {
            _rootProjectDirectory = new DoxDirectoryInfo(projectConfig.ParentDirectory.FullName);
            _assetDirectory = new DoxDirectoryInfo(Path.Combine(projectConfig.ParentDirectory.FullName, AssetFolderName));
            _pagesDirectory = new DoxDirectoryInfo(Path.Combine(projectConfig.ParentDirectory.FullName, PagesFolderName));
            _layoutDirectory = new DoxDirectoryInfo(Path.Combine(projectConfig.ParentDirectory.FullName, LayoutFolderName));

            Config = projectConfig;
        }

        public DoxProjectLoadResultList Load()
        {
            _projectLoadResultList = new DoxProjectLoadResultList();
            _projectLoadResultList.Add(_rootProjectDirectory.FullName, _rootProjectDirectory.Exists, _rootProjectDirectory.Created, _rootProjectDirectory.Created || _rootProjectDirectory.Existed);
            _projectLoadResultList.Add(_assetDirectory.FullName, _assetDirectory.Exists, _assetDirectory.Created, _assetDirectory.Created || _assetDirectory.Existed);
            _projectLoadResultList.Add(_pagesDirectory.FullName, _pagesDirectory.Exists, _pagesDirectory.Created, _pagesDirectory.Created || _pagesDirectory.Existed);
            _projectLoadResultList.Add(_layoutDirectory.FullName, _layoutDirectory.Exists, _layoutDirectory.Created, _layoutDirectory.Created || _layoutDirectory.Existed);
            _projectLoadResultList.Add(Config.Load());

            return _projectLoadResultList;
        }

        private void CreateDefaultPages()
        {
            var codeProjectFileList = Directory.GetFiles(Config.ParentDirectory.Parent.FullName, "*.csproj").ToList();
            foreach (var codeProjectFile in codeProjectFileList)
            {
            }
        }

        public DoxProjectConfig Config { get; private set; }
    }
}
