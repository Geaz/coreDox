using coreDox.Core.Exceptions;
using coreDox.Core.Services;
using System.Collections.Generic;
using System.IO;

namespace coreDox.Core.Model.Project
{
    /// <summary>
    /// The <c>DoxProject</c> is the root object of a documentation project.
    /// It contains references to all elements in a project.
    /// </summary>
    public class DoxProject
    {
        public const string ConfigFileName  = "config.yaml";
        public const string TOCFileName = "toc.md";
        public const string AssetFolderName = "assets";
        public const string PagesFolderName = "pages";
        public const string LayoutFolderName = "layout";

        public readonly ConfigService _configService = ServiceLocator.GetService<ConfigService>();
        public readonly ContentService _contentService = ServiceLocator.GetService<ContentService>();

        public DoxProject(string docFolder)
        {
            DocFolder = docFolder;
            CheckFiles();
            LoadConfig();
        }

        /// <summary>
        /// Creates a new documentation project in the given folder.
        /// </summary>
        /// <param name="docFolder">The folder for the new documentation project.</param>
        /// <returns>The created <c>DocProject</c>.</returns>
        public static DoxProject New(string docFolder)
        {
            if(!Directory.Exists(docFolder))
            {
                throw new CoreDoxException($"Folder '{docFolder}' not found!");
            }
            Directory.CreateDirectory(Path.Combine(docFolder, AssetFolderName));
            Directory.CreateDirectory(Path.Combine(docFolder, PagesFolderName));
            Directory.CreateDirectory(Path.Combine(docFolder, LayoutFolderName));

            return new DoxProject(docFolder);
        }

        public void GetParsedCodeDocumentations()
        {

        }

        private void CheckFiles()
        {
            if(!File.Exists(ConfigFilePath) || !File.Exists(TOCFilePath))
            {
                throw new CoreDoxException($"Config file or TOC is missing in documentation folder! ({DocFolder})");
            }
        }

        private void LoadConfig()
        {
            _configService.LoadConfig(ConfigFilePath);
        }

        /// <summary>
        /// The folder containing the documentation project.
        /// </summary>
        public string DocFolder { get; private set; }

        /// <summary>
        /// The file path to the config.yaml file
        /// </summary>
        public string ConfigFilePath => Path.Combine(DocFolder, ConfigFileName);

        /// <summary>
        /// The file path to the toc.md file
        /// </summary>
        public string TOCFilePath => Path.Combine(DocFolder, TOCFileName);

        /// <summary>
        /// The documentation config.
        /// </summary>
        private DoxConfig _config;
        public DoxConfig Config => _config ?? (_config = _configService.GetConfig<DoxConfig>());

        /// <summary>
        /// The table of contents of the documentation.
        /// </summary>
        private DoxTOC _toc;
        public DoxTOC TOC => _toc ?? (_toc = _contentService.LoadTOC(TOCFilePath));

        /// <summary>
        /// All additional pages of the documentation.
        /// </summary>
        private List<DoxPage> _docPages;
        public List<DoxPage> DocPages => _docPages ?? (_docPages = _contentService.LoadPages(Path.Combine(DocFolder, PagesFolderName)));

        /// <summary>
        /// Contains all parsed code information.
        /// </summary>
        public Dictionary<string, DoxAssembly> Assemblies { get; } = new Dictionary<string, DoxAssembly>();
    }
}
