using CommandLine;
using CommandLine.Text;

namespace coreDox
{
    [Verb("new", HelpText = "Create a new coreDox project.")]
    internal class NewOptions 
    {
        [Option("doc", Required = true, HelpText = "The target folder of the documentation project.")]
        public string DocFolder { get; set; }

        [Option("exporter", HelpText = "Adds the given exporter to the fiven documentation project.")]
        public string Exporter { get; set; }
    }

    [Verb("build", HelpText = "Build the coreDox project in the current or given directory.")]
    internal class BuildOptions 
    {
    }
    
    [Verb("watch", HelpText = "Builds and watches the coreDox project in the current or given directory.")]
    internal class WatchOptions 
    {
    }
}