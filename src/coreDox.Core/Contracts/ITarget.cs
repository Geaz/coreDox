using coreDox.Core.Project;

namespace coreDox.Core.Contracts
{
    public interface ITarget
    {
        void Export(DoxProject project, string outputPath);
    }

    public interface ITarget<TConfig> : ITarget where TConfig : IConfigSection { }
}