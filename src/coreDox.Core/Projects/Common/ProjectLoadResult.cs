using System;

namespace coreDox.Core.Projects
{
    public sealed class ProjectLoadResult
    {
        private readonly string _path;
        private readonly bool _existed;
        private readonly bool _created;
        private readonly bool _loaded;
        private readonly Exception _ex;

        public ProjectLoadResult(string path, bool existed, bool created, bool loaded)
            : this(path, existed, created, loaded, null) { }

        public ProjectLoadResult(string path, bool existed, bool created, bool loaded, Exception ex)
        {
            _path = path;
            _existed = existed;
            _created = created;
            _loaded = loaded;
            _ex = ex;
        }

        public override string ToString()
        {
            return
                $"Load {(Succeeded ? "SUCCEEDED" : "FAILED")} for '{_path}'. "
              + $"The element {(_existed ? "EXISTED" : "DID NOT exist")} and "
              + $"got {(_created ? "CREATED" : "NOT created")}.";
        }

        public bool Succeeded => _loaded;
    }
}
