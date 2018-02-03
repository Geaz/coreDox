using coreDox.Core.Configuration;
using coreDox.Core.Contracts;
using coreDox.Core.Projects;
using System.IO;

namespace coreDox.Core
{
    public sealed class Project : IProject
    {
        public const string ConfigFileName  = "config.json";
        public const string AssetFolderName = "assets";
        public const string PagesFolderName = "pages";
        public const string LayoutFolderName = "layout";

        private ProjectLoadResultList _projectLoadResultList;
        
        private readonly ProjectDirectory _rootProjectDirectory;
        private readonly ProjectDirectory _assetDirectory;
        private readonly ProjectDirectory _pagesDirectory;
        private readonly ProjectDirectory _layoutDirectory;

        public Project(ProjectConfig projectConfig)
        {
            _rootProjectDirectory = new ProjectDirectory(projectConfig.ParentDirectory.FullName);
            _assetDirectory = new ProjectDirectory(Path.Combine(projectConfig.ParentDirectory.FullName, AssetFolderName));
            _pagesDirectory = new ProjectDirectory(Path.Combine(projectConfig.ParentDirectory.FullName, PagesFolderName));
            _layoutDirectory = new ProjectDirectory(Path.Combine(projectConfig.ParentDirectory.FullName, LayoutFolderName));

            Config = projectConfig;
        }

        public ProjectLoadResultList Load()
        {
            _projectLoadResultList = new ProjectLoadResultList();
            _projectLoadResultList.Add(_rootProjectDirectory.FullName, _rootProjectDirectory.Exists, _rootProjectDirectory.Created, _rootProjectDirectory.Created || _rootProjectDirectory.Existed);
            _projectLoadResultList.Add(_assetDirectory.FullName, _assetDirectory.Exists, _assetDirectory.Created, _assetDirectory.Created || _assetDirectory.Existed);
            _projectLoadResultList.Add(_pagesDirectory.FullName, _pagesDirectory.Exists, _pagesDirectory.Created, _pagesDirectory.Created || _pagesDirectory.Existed);
            _projectLoadResultList.Add(_layoutDirectory.FullName, _layoutDirectory.Exists, _layoutDirectory.Created, _layoutDirectory.Created || _layoutDirectory.Existed);
            _projectLoadResultList.Add(Config.Load());

            return _projectLoadResultList;
        }

        public ProjectConfig Config { get; private set; }
    }
}
