using coreDox.Core.Contracts;
using coreDox.Core.Model.Project;
using System;
using System.Collections.Generic;

namespace coreDox.Core.Services
{
    public class ExporterService
    {
        private readonly PluginDiscoveryService _pluginDiscoveryService;

        public ExporterService()
        {
            _pluginDiscoveryService = ServiceLocator.GetService<PluginDiscoveryService>();
            GetExporters();
            CreateExporterInstances();
        }

        public void ExportDocumentation(DoxProject doxProject)
        {
            foreach(var exporter in ExporterInstances)
            {
                exporter.Export(doxProject.Config.OutputFolder);
            }
        }

        private void GetExporters()
        {
            RegisteredExporterTypes = _pluginDiscoveryService.GetAllExporterPlugins();
        }

        private void CreateExporterInstances()
        {
            foreach (var exporterType in RegisteredExporterTypes)
            {
                ExporterInstances.Add((IExporter)Activator.CreateInstance(exporterType));
            }
        }
        
        public List<Type> RegisteredExporterTypes { get; private set; }

        public List<IExporter> ExporterInstances { get; } = new List<IExporter>();
    }
}
