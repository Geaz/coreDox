using CommandLine;
using coreDox.Core.Exceptions;
using coreDox.Verbs;
using NLog;
using System;

namespace coreDox
{
    public class CLI
    {
        static int Main(string[] args)
        {
            var exitCode = ExitCode.Success;
            try
            {
                Parser.Default.ParseArguments<NewOptions, BuildOptions, WatchOptions>(args)
                    .WithParsed<NewOptions>(opts => new NewVerb(opts))
                    .WithParsed<BuildOptions>(opts => new BuildVerb(opts))
                    .WithParsed<WatchOptions>(opts => new WatchVerb(opts))
                    .WithNotParsed(errs => {
                        exitCode = ExitCode.InvalidArgs;
                    });
            }
            catch(CoreDoxException ex)
            {
                LogManager.GetLogger("coreDox CLI").Error(ex.Message);
                exitCode = ExitCode.CoreException;
            }
            catch(Exception ex)
            {
                LogManager.GetLogger("coreDox CLI").Error(ex, ex.Message);
                exitCode = ExitCode.UnknownError;
            }
            return (int)exitCode;
        }
    }
}
