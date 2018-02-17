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
        Code,
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

        public void WritePage(string title, string content, string projectPath)
        {
            var pageBuilder = new StringBuilder();
            pageBuilder.AppendLine($"---");
            pageBuilder.AppendLine($"- title: {title}");

            if(!string.IsNullOrEmpty(projectPath))
                pageBuilder.AppendLine($"- project: {projectPath}");

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
                if(splittedContent.Length == 2)
                {
                    ParseHeader(splittedContent[0].Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries));
                    _content = splittedContent[1].Trim();
                }
                else
                {
                    throw new CoreDoxException($"DoxPage '{_doxPageFileInfo.FullName}' is not in the correct format!");
                }
                _lastLoadTimeUtc = _doxPageFileInfo.LastWriteTimeUtc;
            }
        }

        private void ParseHeader(string[] lines)
        {
            var line = lines.First();
            if(line.StartsWith("- project:"))
            {
                _codeProjectPath = line.Substring("- project:".Length).Trim();
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

        private string _codeProjectPath;
        public string CodeProjectPath
        {
            get { CheckLoad(); return _codeProjectPath; }
        }

        public DoxPageType PageType
        {
            get
            {
                CheckLoad();
                if (!string.IsNullOrEmpty(CodeProjectPath)) return DoxPageType.Code;
                else return DoxPageType.Page;
            }
        }
    }
}
