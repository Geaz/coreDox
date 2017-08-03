using System.Collections.Generic;

namespace coreDox.Core.Model.Config
{
    public class DoxConfig
    {
        public string ProjectName { get; set; }

        public string OutputFolder { get; set; }

        public List<DoxConfigAssemblyInfo> Assemblies { get; set; }
    }
}
