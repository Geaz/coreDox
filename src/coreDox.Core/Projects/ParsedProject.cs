using coreDox.Core.Contracts;

namespace coreDox.Core.Projects
{
    public sealed class ParsedProject : IProject
    {
        private Project _project;

        public ParsedProject(Project project)
        {
            _project = project;
        }

        public void Parse()
        {

        }
    }
}
