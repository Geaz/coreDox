using coreDox.Core.Contracts;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace coreDox.Core.Services
{
    /// <summary>
    /// This service is responsible for the discovery of all **coreDox** plugins.
    /// </summary>
    public class PluginDiscoveryService
    {
        private readonly ILogger _logger = LogManager.GetLogger("PluginDiscoveryService");
        private readonly string[] _possibleExporterDllFiles;
        private readonly string _exporterFolder = Path.Combine(Path.GetDirectoryName(typeof(ExporterService).GetTypeInfo().Assembly.Location), "Exporter");
        
        public PluginDiscoveryService()
        {
            _possibleExporterDllFiles = Directory.GetFiles(_exporterFolder, "*.dll", SearchOption.AllDirectories);
        }

        /// <summary>
        /// Gets a list of all available exporter types.
        /// </summary>
        /// <returns>List of exporter types</returns>
        public List<Type> GetAllExporterPlugins()
        {
            var exporter = new List<Type>();
            
            foreach (var possibleExporterDllFile in _possibleExporterDllFiles)
            {
                try
                {
                    var possibleExporterAssembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(possibleExporterDllFile);
                    exporter.AddRange(GetTypesWithInterface<IExporter>(possibleExporterAssembly));
                }
                catch(Exception)
                {
                    _logger.Warn($"Couldn't load assemby: {possibleExporterDllFile}");
                }
            }

            return exporter;
        }

        private List<Type> GetTypesWithInterface<T>(Assembly assembly)
        {
            return assembly.GetTypes()
                .Where(t => t.GetInterfaces().Any(i => i == typeof(T)))
                .ToList();
        }
    }
}
