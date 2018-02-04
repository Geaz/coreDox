using System.Linq;
using System.Collections.Generic;

namespace coreDox.Core.Project.Common
{
    public sealed class DoxProjectLoadResultList
    {
        private List<DoxProjectLoadResult> _projectLoadResultList = new List<DoxProjectLoadResult>();

        public void Add(DoxProjectLoadResult projectLoadResult)
        {
            _projectLoadResultList.Add(projectLoadResult);
        }

        public void Add(string path, bool existed, bool created, bool loaded)
        {
            _projectLoadResultList.Add(new DoxProjectLoadResult(path, existed, created, loaded));
        }

        public bool AllSucceeded()
        {
            return _projectLoadResultList.All(r => r.Succeeded);
        }
    }
}
