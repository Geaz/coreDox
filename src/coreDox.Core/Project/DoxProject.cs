using coreDox.Core.Exceptions;
using coreDox.Core.Model.Code;
using coreDox.Core.Model.Code.Base;
using coreDox.Core.Project.Config;
using coreDox.Core.Project.Pages;
using NLog;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace coreDox.Core.Project
{
    public sealed class DoxProject
    {
        public const string AssetFolderName = "assets";
        public const string PagesFolderName = "pages";
        public const string LayoutFolderName = "layout";

        private readonly ILogger _logger = LogManager.GetLogger("DoxProject");
        private readonly PluginRegistry _pluginRegistry = new PluginRegistry();

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

        public void ParseAssemblies()
        {
            ParsedAssemblyList = PageRoot
                    .GetAllAssemblyPages()
                    .Select(ap => new DoxAssembly(ap.AssemblyFileInfo.FullName))
                    .ToList();
            
            var namespaceModelList = ParsedAssemblyList.SelectMany(a => a.DoxNamespaceSet);
            var typeModelList = namespaceModelList.SelectMany(n => n.DoxTypeSet);

            var doxModelList = new List<DoxCodeModel>(ParsedAssemblyList);
            doxModelList.AddRange(namespaceModelList);
            doxModelList.AddRange(typeModelList);
            doxModelList.AddRange(typeModelList.SelectMany(t => t.DoxEventSet));
            doxModelList.AddRange(typeModelList.SelectMany(t => t.DoxFieldSet));
            doxModelList.AddRange(typeModelList.SelectMany(t => t.DoxMethodSet));
            doxModelList.AddRange(typeModelList.SelectMany(t => t.DoxPropertySet));

            _logger.Info($"Amending {doxModelList.Count} models ...");
            foreach (var modelProvider in _pluginRegistry.GetAllModelProviders())
            {
                _logger.Info($"Running Model Provider: {modelProvider.GetType().Name} ...");
                doxModelList.ForEach(m => { var model = modelProvider.AmendModel(m); if (model != null) m.Models.Add(model); });
            }
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

        public List<DoxAssembly> ParsedAssemblyList { get; private set; }
        public DoxPageFolder PageRoot { get; private set; } 
        public DoxProjectConfig Config { get; private set; }

        public DirectoryInfo RootProjectDirectory { get; private set; }
        public DirectoryInfo AssetDirectory { get; private set; }
        public DirectoryInfo PagesDirectory { get; private set; }
        public DirectoryInfo LayoutDirectory { get; private set; }
    }
}
