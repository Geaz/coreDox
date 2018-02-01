namespace coreDox.Core.Contracts
{
    public interface IExporter
    {
        void Export(string outputPath);

        IProject Project { get; set; }

        string ExporterName { get; }
    }

    public interface IExporter<TConfig> : IExporter
    {
        TConfig Config { get; set; }
    }
}