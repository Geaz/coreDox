using coreDox.Core.Exceptions;
using System;
using System.IO;
using System.Linq;

namespace coreDox.Core.Project.Pages
{
    public sealed class DoxPage
    {
        public DoxPage(FileInfo doxPageFileInfo)
        {
            Parse(doxPageFileInfo);
        }

        private void Parse(FileInfo doxPageFileInfo)
        {
            if (!doxPageFileInfo.Exists) throw new CoreDoxException($"No page file found at '{doxPageFileInfo.FullName}'!");

            Content = File.ReadAllText(doxPageFileInfo.FullName);
            if (Content.StartsWith("---"))
            {
                var splittedContent = Content.Split("---", StringSplitOptions.RemoveEmptyEntries);

                ParseHeader(splittedContent[0].Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries), doxPageFileInfo);
                if (splittedContent.Length == 2)
                {
                    Content = splittedContent[1].Trim();
                }
            }      
        }

        private void ParseHeader(string[] lines, FileInfo doxPageFileInfo)
        {
            var line = lines.First();
            if(line.StartsWith("- assembly:"))
            {
                var assemblyPath = Path.Combine(doxPageFileInfo.Directory.FullName, line.Substring("- assembly:".Length).Trim());
                AssemblyFileInfo = new FileInfo(assemblyPath);

                if(!AssemblyFileInfo.Exists)
                {
                    throw new CoreDoxException($"Assembly '{AssemblyFileInfo.FullName}', defined in '{doxPageFileInfo.Name}',  does not exist!");
                }                    
            }
            else if (line.StartsWith("- title:"))
            {
                Title = line.Substring("- title:".Length).Trim();
                throw new Exception(line + " ### " + Title);
            }

            if (lines.Length > 1) ParseHeader(lines.Skip(1).ToArray(), doxPageFileInfo);
        }

        public string Title { get; private set; }
        public string Content { get; private set; }
        public FileInfo AssemblyFileInfo { get; private set; }
    }
}
