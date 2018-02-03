namespace coreDox.Core.Contracts
{
    public interface ITarget
    {
        void Write(string outputPath);

        IProject Project { get; set; }

        string Name { get; }
    }

    public interface ITarget<TConfig> : ITarget where TConfig : IConfigSection
    {
        TConfig Config { get; set; }
    }
}