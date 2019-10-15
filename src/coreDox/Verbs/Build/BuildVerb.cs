using coreDox.Core;
using coreDox.Core.Project;
using coreDox.Core.Project.Config;
using NLog;

namespace coreDox.Build
{
    internal class BuildVerb
    {
        public ILogger _logger = LogManager.GetLogger("BuildVerb");

        public BuildVerb(BuildOptions buildOptions)
        {
            _logger.Info($"Building project in folder '{buildOptions.DocFolder}' ...");

            var pluginRegistry = new PluginRegistry();
            var projectConfig = new DoxProjectConfig(pluginRegistry, buildOptions.DocFolder);
            var project = new DoxProject(projectConfig);
        }
    }
}
