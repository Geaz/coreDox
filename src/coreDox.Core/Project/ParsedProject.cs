using coreDox.Core.Contracts;

namespace coreDox.Core.Project
{
    public sealed class ParsedProject : IProject
    {
        private DoxProject _project;

        public ParsedProject(DoxProject project)
        {
            _project = project;
        }

        public void Parse()
        {

        }
    }
}
