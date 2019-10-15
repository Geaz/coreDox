using coreDox.Core.Project;

namespace coreDox.Core.Contracts
{
    public interface ITarget
    {
        void Write(string outputPath);

        DoxProject Project { get; set; }

        string Name { get; }
    }

    public interface ITarget<TConfig> : ITarget where TConfig : IConfigSection
    {
        TConfig Config { get; set; }
    }
}