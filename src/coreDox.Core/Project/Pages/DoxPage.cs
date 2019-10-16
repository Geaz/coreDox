using coreDox.Core.Exceptions;
using System;
using System.IO;
using System.Linq;

namespace coreDox.Core.Project.Pages
{
    public enum DoxPageType
    {
        Page,
        Assembly,
    }

    /// <summary>
    /// Represents a *.md file in the 'pages' folder of the documentation project.
    /// </summary>
    /// <remarks>
    /// I don't think the code of this class is very 'elegant'. So feel free to submit a pull request!
    /// </remarks>
    public sealed class DoxPage
    {
        private readonly FileInfo _doxPageFileInfo;

        public DoxPage(FileInfo doxPageFileInfo)
        {
            _doxPageFileInfo = doxPageFileInfo;
            Parse();
        }

        public DoxPage(DirectoryInfo doxPageDirectoryInfo)
        {
            Title = doxPageDirectoryInfo.Name;
            SubPages = new DoxPageList(doxPageDirectoryInfo);
        }

        private void Parse()
        {
            if (!_doxPageFileInfo.Exists) throw new CoreDoxException($"No page file found at '{_doxPageFileInfo.FullName}'!");
            var content = File.ReadAllText(_doxPageFileInfo.FullName);
            var splittedContent = content.Split("---", StringSplitOptions.RemoveEmptyEntries);

            ParseHeader(splittedContent[0].Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries));
            if (splittedContent.Length == 2)
            {
                Content = splittedContent[1].Trim();
            }

            // If the file is a index file and no title was given,
            // set the title of the page to the parent directory name
            if(string.IsNullOrEmpty(Title) && _doxPageFileInfo.Name == "index.md")
            {
                Title = _doxPageFileInfo.Directory.Name;
            }
        }

        private void ParseHeader(string[] lines)
        {
            var line = lines.First();
            if(line.StartsWith("- assembly:"))
            {
                var assemblyPath = Path.Combine(_doxPageFileInfo.Directory.FullName, line.Substring("- assembly:".Length).Trim());
                AssemblyFileInfo = new FileInfo(assemblyPath);

                if(!AssemblyFileInfo.Exists)
                {
                    throw new CoreDoxException($"Assembly '{AssemblyFileInfo.FullName}', defined in '{_doxPageFileInfo.Name}',  does not exist!");
                }                    
            }
            else if (line.StartsWith("- title:"))
            {
                Title = line.Substring("- title:".Length).Trim();
            }

            if (lines.Length > 1) ParseHeader(lines.Skip(1).ToArray());
        }

        public string Title { get; private set; }
        public string Content { get; private set; }
        public FileInfo AssemblyFileInfo { get; private set; }
        public DoxPageType PageType
        {
            get
            {
                if (AssemblyFileInfo != null) return DoxPageType.Assembly;
                else return DoxPageType.Page;
            }
        }

        public DoxPageList SubPages { get; }
    }
}
