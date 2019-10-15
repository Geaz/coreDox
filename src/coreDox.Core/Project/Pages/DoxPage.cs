using coreDox.Core.Exceptions;
using coreDox.Core.Project.Common;
using System;
using System.Linq;
using System.IO;
using System.Text;

namespace coreDox.Core.Project.Pages
{
    public enum DoxPageType
    {
        Placeholder,
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
        private DateTime _lastLoadTimeUtc;

        private readonly DoxFileInfo _doxPageFileInfo;

        public DoxPage(DoxFileInfo doxPageFileInfo)
        {
            _doxPageFileInfo = doxPageFileInfo;
        }

        public void WritePage(string title, string content, string assemblyPath = null)
        {
            var pageBuilder = new StringBuilder();
            pageBuilder.AppendLine($"---");
            pageBuilder.AppendLine($"- title: {title}");

            if(!string.IsNullOrEmpty(assemblyPath))
                pageBuilder.AppendLine($"- assembly: {assemblyPath}");

            pageBuilder.AppendLine($"---");
            pageBuilder.AppendLine(content);

            File.WriteAllText(_doxPageFileInfo.FullName, pageBuilder.ToString());
        }
        
        private void CheckLoad()
        {
            if (!_doxPageFileInfo.Exists) throw new CoreDoxException($"No page file found at '{_doxPageFileInfo.FullName}'!");
            if (_lastLoadTimeUtc < _doxPageFileInfo.LastWriteTimeUtc)
            {
                var content = File.ReadAllText(_doxPageFileInfo.FullName);
                var splittedContent = content.Split("---", StringSplitOptions.RemoveEmptyEntries);

                ParseHeader(splittedContent[0].Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries));
                if (splittedContent.Length == 2)
                {                    
                    _content = splittedContent[1].Trim();
                }
                _lastLoadTimeUtc = _doxPageFileInfo.LastWriteTimeUtc;
            }
        }

        private void ParseHeader(string[] lines)
        {
            var line = lines.First();
            if(line.StartsWith("- assembly:"))
            {
                var assemblyPath = Path.Combine(_doxPageFileInfo.Directory.FullName, line.Substring("- assembly:".Length).Trim());
                _assemblyFileInfo = new DoxFileInfo(assemblyPath);

                if(!_assemblyFileInfo.Exists)
                {
                    throw new CoreDoxException($"Assembly '{_assemblyFileInfo.FullName}' does not exist!");
                }                    
            }
            else if (line.StartsWith("- title:"))
            {
                _title = line.Substring("- title:".Length).Trim();
            }

            if (lines.Length > 1) ParseHeader(lines.Skip(1).ToArray());
        }

        private string _title;
        public string Title
        {
            get { CheckLoad(); return _title; }
        }

        private string _content;
        public string Content
        {
            get { CheckLoad(); return _content; }
        }

        private DoxFileInfo _assemblyFileInfo;
        public DoxFileInfo AssemblyFileInfo
        {
            get { CheckLoad(); return _assemblyFileInfo; }
        }

        public DoxPageType PageType
        {
            get
            {
                CheckLoad();
                if (AssemblyFileInfo != null) return DoxPageType.Assembly;
                else return DoxPageType.Page;
            }
        }
    }
}
