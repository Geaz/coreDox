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

        private readonly ProjectDirectory _projectDirectory;
        private readonly ProjectDirectory _assetDirectory;
        private readonly ProjectDirectory _pagesDirectory;
        private readonly ProjectDirectory _layoutDirectory;
        private readonly ProjectConfig _projectConfig;

        //public Project(string projectFolderPath) : this(projectFolderPath, new ProjectConfig(Path.Combine(projectFolderPath, ConfigFileName))) { }

        public Project(string projectFolderPath, ProjectConfig projectConfig)
        {
            _projectDirectory = new ProjectDirectory(projectFolderPath);
            _assetDirectory = new ProjectDirectory(Path.Combine(projectFolderPath, AssetFolderName));
            _pagesDirectory = new ProjectDirectory(Path.Combine(projectFolderPath, PagesFolderName));
            _layoutDirectory = new ProjectDirectory(Path.Combine(projectFolderPath, LayoutFolderName));
            _projectConfig = projectConfig;
        }

        public ProjectLoadResultList Load(bool createDefault)
        {
            _projectLoadResultList = new ProjectLoadResultList();
            _projectLoadResultList.Add(_projectDirectory.FullName, _projectDirectory.Exists, _projectDirectory.Created, _projectDirectory.Created || _projectDirectory.Existed);
            _projectLoadResultList.Add(_assetDirectory.FullName, _assetDirectory.Exists, _assetDirectory.Created, _assetDirectory.Created || _assetDirectory.Existed);
            _projectLoadResultList.Add(_pagesDirectory.FullName, _pagesDirectory.Exists, _pagesDirectory.Created, _pagesDirectory.Created || _pagesDirectory.Existed);
            _projectLoadResultList.Add(_layoutDirectory.FullName, _layoutDirectory.Exists, _layoutDirectory.Created, _layoutDirectory.Created || _layoutDirectory.Existed);
            //_projectLoadResultList.Add(_projectConfig.Load());

            return _projectLoadResultList;
        }
        
        private bool EnsureDirectory(DirectoryInfo directory)
        {
            var created = false;
            if (!directory.Exists)
            {
                directory.Create();
                created = true;
            }
            return created;
        }
    }
}
