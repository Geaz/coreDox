using NLog;

namespace coreDox.Verbs
{
    internal class BuildVerb
    {
        public ILogger _logger = LogManager.GetLogger("BuildVerb");

        public BuildVerb(BuildOptions buildOptions)
        {
            _logger.Info($"Building project in folder '{buildOptions.DocFolder}' ...");

            //var project = new DoxProject(buildOptions.DocFolder);


        }
    }
}
