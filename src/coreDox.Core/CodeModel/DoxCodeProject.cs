using coreDox.Core.Exceptions;
using coreDox.Core.Model.Code;
using System.IO;

namespace coreDox.Core.CodeModel
{
    public sealed class DoxCodeProject
    {
        private Microsoft.Build.Evaluation.Project _project;
        private DoxAssembly _doxAssembly;

        private readonly FileInfo _projectFileInfo;

        public DoxCodeProject(string projectFilePath)
        {
            _projectFileInfo = new FileInfo(projectFilePath);
        }

        public void Load()
        {
            if (!_projectFileInfo.Exists) throw new CoreDoxException($"Project file at path '{_projectFileInfo.FullName}' does not exist.");
            if (_project == null)
            {
                _project = new Microsoft.Build.Evaluation.Project(_projectFileInfo.FullName);
            }
        }

        public DoxAssembly GetParsedAssembly()
        {
            if(_doxAssembly == null)
            {

            }
            return _doxAssembly;
        }
    }
}
