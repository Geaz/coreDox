using NLog;
using coreDox.Core;
using coreDox.Core.Project;
using coreDox.Core.Project.Config;

namespace coreDox.New
{
    internal class NewVerb
    {
        public ILogger _logger = LogManager.GetLogger("NewVerb");

        public NewVerb(NewOptions newOptions)
        {
            _logger.Info($"Creating a new project in folder '{newOptions.DocFolder}' ...");

            var pluginRegistry = new PluginRegistry();
            var projectConfig = new DoxProjectConfig(pluginRegistry, newOptions.DocFolder);
            var project = new DoxProject(projectConfig);
            project.CreateMissingElements();

            _logger.Info("Project created successfully!");
        }
    }
}
