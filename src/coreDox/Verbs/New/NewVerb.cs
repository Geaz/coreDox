using coreDox.Core.Model.Project;
using NLog;

namespace coreDox.New
{
    internal class NewVerb
    {
        public ILogger _logger = LogManager.GetLogger("NewVerb");

        public NewVerb(NewOptions newOptions)
        {
            _logger.Info($"Creating a new project in folder '{newOptions.DocFolder}' ...");
            DoxProject.New(newOptions.DocFolder);
            _logger.Info("Project created successfully!");
        }
    }
}
