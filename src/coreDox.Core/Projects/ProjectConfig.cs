using coreDox.Core.Contracts;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;

namespace coreDox.Core.Configuration
{
    public sealed class ProjectConfig
    {
      /*  private List<Type> _configTypes = new List<Type>();
        private List<object> _loadedConfigSections = new List<object>();

        public ProjectConfig(string configFilePath)
        {
            ConfigFilePath = configFilePath;
        }

        /// <summary>
        /// Loads the given config file into the found config types.
        /// The generic type paramter of the <seealso cref="Contracts.IExporter{TConfig}"/> is the config type used by a exporter.
        /// The name of the config type is the key of the section in the config file.
        /// </summary>
        /// <param name="configPath">The config file to load</param>
        public void LoadConfig(string configPath)
        {
            _loadedConfigSections = new List<object>();

            var converter = new ExpandoObjectConverter();
            var jsonConfig = JsonConvert.DeserializeObject<ExpandoObject>(File.ReadAllText(configPath), converter);
            foreach (var config in jsonConfig)
            {
                var configType = _configTypes.SingleOrDefault(c => c.Name.Equals(config.Key, StringComparison.OrdinalIgnoreCase));
                if (configType != null)
                {
                    var serializedSubConfig = JsonConvert.SerializeObject(config.Value);
                    _loadedConfigSections.Add(JsonConvert.DeserializeObject(serializedSubConfig, configType));
                }
            }
        }

        private void FindConfigTypes()
        {
            _configTypes.Add(typeof(DoxConfig));
            foreach (var exporterType in _exporterService.RegisteredExporterTypes)
            {
                var exporterInterface = exporterType.GetInterfaces().SingleOrDefault(i => i.Name == "IExporter");
                if (exporterInterface != null)
                {
                    var configType = exporterInterface.GenericTypeArguments.FirstOrDefault();
                    if (configType != null) _configTypes.Add(configType);
                }
            }
        }

        public string ConfigFilePath { get; }

        public string ProjectName { get; set; }

        public string OutputFolder { get; set; } */
    }
}
