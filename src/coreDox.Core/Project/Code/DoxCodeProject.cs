using coreDox.Core.Exceptions;
using coreDox.Core.Model.Code;
using coreDox.Core.Project.Common;

namespace coreDox.Core.Project.Code
{
    public sealed class DoxCodeProject
    {
        private Microsoft.Build.Evaluation.Project _project;
        private DoxAssembly _doxAssembly;

        public DoxCodeProject(string projectFilePath)
        {
            ProjectFileInfo = new DoxFileInfo(projectFilePath);
        }

        public void Load()
        {
            if (!ProjectFileInfo.Exists) throw new CoreDoxException($"Project file at path '{ProjectFileInfo.FullName}' does not exist.");
            if (_project == null)
            {
                _project = new Microsoft.Build.Evaluation.Project(ProjectFileInfo.FullName);
            }
        }

        public DoxAssembly GetParsedAssembly()
        {
            if(_doxAssembly == null)
            {

            }
            return _doxAssembly;
        }


        public DoxFileInfo ProjectFileInfo { get; }
    }
}
