using coreDox.Core.Contracts;
using coreDox.Core.Project.Code;
using coreDox.Core.Project.Common;
using coreDox.Core.Project.Config;
using coreDox.Core.Project.Pages;
using System.Collections.Generic;
using System.IO;

namespace coreDox.Core.Project
{
    public sealed class DoxProject : IProject
    {
        public const string ConfigFileName  = "config.json";
        public const string AssetFolderName = "assets";
        public const string PagesFolderName = "pages";
        public const string LayoutFolderName = "layout";
        
        private readonly DoxDirectoryInfo _rootProjectDirectory;
        private readonly DoxDirectoryInfo _assetDirectory;
        private readonly DoxDirectoryInfo _pagesDirectory;
        private readonly DoxDirectoryInfo _layoutDirectory;

        public DoxProject(DoxProjectConfig projectConfig)
        {
            _rootProjectDirectory = new DoxDirectoryInfo(projectConfig.ParentDirectory.FullName);
            _assetDirectory = new DoxDirectoryInfo(Path.Combine(_rootProjectDirectory.FullName, AssetFolderName));
            _pagesDirectory = new DoxDirectoryInfo(Path.Combine(_rootProjectDirectory.FullName, PagesFolderName));
            _layoutDirectory = new DoxDirectoryInfo(Path.Combine(_rootProjectDirectory.FullName, LayoutFolderName));

            Pages = new DoxPageList(_pagesDirectory);
            Config = projectConfig;
            CodeProjects = new DoxCodeProjectList(_rootProjectDirectory.ParentDirectory);
        }

        public IReadOnlyList<DoxProjectValidationResult> IsProjectValid()
        {
            var validationResults = new List<DoxProjectValidationResult>();
            validationResults.Add(new DoxProjectValidationResult(_rootProjectDirectory.FullName, _rootProjectDirectory.Exists, "NOT EXISTING"));
            validationResults.Add(new DoxProjectValidationResult(_assetDirectory.FullName, _rootProjectDirectory.Exists, "NOT EXISTING"));
            validationResults.Add(new DoxProjectValidationResult(_pagesDirectory.FullName, _rootProjectDirectory.Exists, "NOT EXISTING"));
            validationResults.Add(new DoxProjectValidationResult(_layoutDirectory.FullName, _rootProjectDirectory.Exists, "NOT EXISTING"));
            return validationResults;
        }

        public void CreateMissingElements()
        {
            _rootProjectDirectory.EnsureDirectory();
            _assetDirectory.EnsureDirectory();
            _pagesDirectory.EnsureDirectory();
            _layoutDirectory.EnsureDirectory();

            if(!Config.Exists) Config.CreateDefaultConfig();
            if(!Pages.Any()) Pages.CreateDefaultCodePages(CodeProjects);
        }

        public DoxPageList Pages { get; }
        public DoxProjectConfig Config { get; }
        public DoxCodeProjectList CodeProjects { get; }
    }
}
