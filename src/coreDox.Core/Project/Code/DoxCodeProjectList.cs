using coreDox.Core.Project.Common;
using coreDox.Core.Project.Pages;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace coreDox.Core.Project.Code
{
    public sealed class DoxCodeProjectList
    {
        private readonly DoxDirectoryInfo _projectSearchDirectory;

        public DoxCodeProjectList(DoxDirectoryInfo projectSearchDirectory)
        {
            _projectSearchDirectory = projectSearchDirectory;
        }

        public IReadOnlyList<DoxCodeProject> GetSolutionList()
        {
            return Directory
                .GetFiles(_projectSearchDirectory.FullName, "*.sln")
                .Select(p => new DoxCodeProject(p))
                .ToList();
        }

        public IReadOnlyList<DoxCodeProject> GetProjectList()
        {
            return Directory
                .GetFiles(_projectSearchDirectory.FullName, "*.csproj")
                .Select(p => new DoxCodeProject(p))
                .ToList();
        }

        public IReadOnlyList<DoxCodeProject> GetAllCodeProjects()
        {
            var codeSolutionFileList = GetSolutionList();
            var codeProjectFileList = GetProjectList();

            var completeFileList = new List<DoxCodeProject>();
            completeFileList.AddRange(codeSolutionFileList);
            completeFileList.AddRange(codeProjectFileList);

            return completeFileList.ToList();
        }

        public IReadOnlyList<DoxCodeProject> GetAllReferencedCodeProjectsParsed(DoxPageList pageList)
        {
            var allCodeProjects = GetAllCodeProjects();
            return null;
        }
    }
}
