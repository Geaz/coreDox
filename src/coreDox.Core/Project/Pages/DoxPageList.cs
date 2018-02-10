using coreDox.Core.Project.Code;
using coreDox.Core.Project.Common;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace coreDox.Core.Project.Pages
{
    public sealed class DoxPageList
    {
        private readonly DoxDirectoryInfo _pagesDirectory;

        public DoxPageList(DoxDirectoryInfo pagesDirectory)
        {
            _pagesDirectory = pagesDirectory;
        }

        public bool Any()
        {
            return Directory
                .GetFiles(_pagesDirectory.FullName, "*.md")
                .Any();
        }

        public IReadOnlyList<DoxPage> GetPages()
        {
            return Directory
                .GetFiles(_pagesDirectory.FullName, "*.md")
                .Select(p => new DoxPage(new DoxFileInfo(p)))
                .ToList();
        }

        public IReadOnlyList<DoxPage> CreateDefaultCodePages(DoxCodeProjectList doxCodeProjectList)
        {
            var codeProjectFileList = doxCodeProjectList.GetProjectList();
            var codeSolutionFileList = doxCodeProjectList.GetSolutionList();
            var relevantFilesList = codeSolutionFileList.Any() ? codeSolutionFileList : codeProjectFileList;
            foreach (var relevantFile in relevantFilesList)
            {
                var newPage = new DoxPage(new DoxFileInfo(Path.Combine(relevantFile.ProjectFileInfo.Directory.FullName, relevantFile.ProjectFileInfo.Name, ".md")));
                newPage.WritePage(relevantFile.ProjectFileInfo.Name, string.Empty, relevantFile.ProjectFileInfo.FullName);
            }
            return GetPages();
        }
    }
}
