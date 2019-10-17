using coreDox.Core.Exceptions;
using coreDox.Core.Project.Config;
using coreDox.Core.Project.Pages;
using System.IO;

namespace coreDox.Core.Project
{
    public sealed class DoxProject
    {
        public const string AssetFolderName = "assets";
        public const string PagesFolderName = "pages";
        public const string LayoutFolderName = "layout";

        public void Load(string docFolder)
        {
            if(!Directory.Exists(docFolder)) throw new CoreDoxException($"No folder found at '{docFolder}'!");
            
            SetDirectoryInfos(docFolder);

            PageRoot = new DoxPageFolder(PagesDirectory);

            Config = new DoxProjectConfig();
            Config.Load(docFolder);
        }

        public void Create(string docFolder)
        {
            SetDirectoryInfos(docFolder);
            EnsureDirectory(RootProjectDirectory);
            EnsureDirectory(AssetDirectory);
            EnsureDirectory(PagesDirectory);
            EnsureDirectory(LayoutDirectory);
            
            Config = new DoxProjectConfig();
            Config.Save(docFolder);
        }

        private void SetDirectoryInfos(string docFolder)
        {
            RootProjectDirectory = new DirectoryInfo(docFolder);
            AssetDirectory = new DirectoryInfo(Path.Combine(RootProjectDirectory.FullName, AssetFolderName));
            PagesDirectory = new DirectoryInfo(Path.Combine(RootProjectDirectory.FullName, PagesFolderName));
            LayoutDirectory = new DirectoryInfo(Path.Combine(RootProjectDirectory.FullName, LayoutFolderName));
        }

        private void EnsureDirectory(DirectoryInfo directoryInfo)
        {
            directoryInfo.Refresh();
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }
        }

        public DoxPageFolder PageRoot { get; private set; } 
        public DoxProjectConfig Config { get; private set; }

        public DirectoryInfo RootProjectDirectory { get; private set; }
        public DirectoryInfo AssetDirectory { get; private set; }
        public DirectoryInfo PagesDirectory { get; private set; }
        public DirectoryInfo LayoutDirectory { get; private set; }
    }
}
