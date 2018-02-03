using System.Linq;
using System.Collections.Generic;

namespace coreDox.Core.Projects
{
    public sealed class ProjectLoadResultList
    {
        private List<ProjectLoadResult> _projectLoadResultList = new List<ProjectLoadResult>();

        public void Add(ProjectLoadResult projectLoadResult)
        {
            _projectLoadResultList.Add(projectLoadResult);
        }

        public void Add(string path, bool existed, bool created, bool loaded)
        {
            _projectLoadResultList.Add(new ProjectLoadResult(path, existed, created, loaded));
        }

        public bool AllSucceeded()
        {
            return _projectLoadResultList.All(r => r.Succeeded);
        }
    }
}
