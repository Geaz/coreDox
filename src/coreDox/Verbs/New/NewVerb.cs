using coreDox.Core.Project;
using NLog;

namespace coreDox.New
{
    internal class NewVerb
    {
        public ILogger _logger = LogManager.GetLogger("NewVerb");

        public NewVerb(NewOptions newOptions)
        {
            _logger.Info($"Creating a new project in folder '{newOptions.DocFolder}' ...");

            var project = new DoxProject();
            project.Create(newOptions.DocFolder);

            _logger.Info("Project created successfully!");
        }
    }
}
