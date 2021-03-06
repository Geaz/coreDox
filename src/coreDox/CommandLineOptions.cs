using CommandLine;

namespace coreDox
{
    [Verb("new", HelpText = "Create a new coreDox project.")]
    internal class NewOptions
    {
        [Value(0, Required = true, HelpText = "The target folder of the documentation project.")]
        public string DocFolder { get; set; }
    }

    [Verb("build", HelpText = "Build the coreDox project in the current or given directory.")]
    internal class BuildOptions 
    {
        [Value(0, Required = true, HelpText = "The folder of the documentation project.")]
        public string DocFolder { get; set; }
    }
    
    [Verb("watch", HelpText = "Builds and watches the coreDox project in the current or given directory.")]
    internal class WatchOptions 
    {
        [Value(0, Required = true, HelpText = "The folder of the documentation project.")]
        public string DocFolder { get; set; }
    }
}