using System.IO;

namespace coreDox.Core.Projects
{
    public sealed class ProjectLoadResult
    {
        private string _path;
        private bool _existed;
        private bool _created;
        private bool _loaded;

        public ProjectLoadResult(string path, bool existed, bool created, bool loaded)
        {
            _path = path;
            _existed = existed;
            _created = created;
            _loaded = loaded;
        }

        public bool Succeeded()
        {
            return _loaded;
        }
    }
}
