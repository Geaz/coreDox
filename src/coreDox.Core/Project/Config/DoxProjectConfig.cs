using coreDox.Core.Exceptions;
using coreDox.Core.Project.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;

namespace coreDox.Core.Project.Config
{
    public sealed class DoxProjectConfig
    {
        private DateTime _lastLoadTimeUtc;
        private List<Object> _loadedConfigSections;

        private readonly PluginRegistry _pluginRegistry;
        private readonly DoxFileInfo _configFileInfo;

        public DoxProjectConfig(PluginRegistry pluginRegistry, string configFilePath)
        {
            _pluginRegistry = pluginRegistry;
            _configFileInfo = new DoxFileInfo(configFilePath);
        }

        public T GetConfigSection<T>()
        {
            if (!_configFileInfo.Exists) throw new CoreDoxException($"No config file found at '{_configFileInfo.FullName}'!");
            if (_lastLoadTimeUtc < _configFileInfo.LastWriteTimeUtc)
            {
                Load();
            }            
            return (T)_loadedConfigSections.Single(l => l.GetType() == typeof(T));
        }

        public void CreateDefaultConfig()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("{");

            var configSectionTypesList = _pluginRegistry.GetAllConfigSections();
            for(var i = 0; i < configSectionTypesList.Count; i++)
            {
                var configSection = configSectionTypesList[i];

                configSection.SetDefaultValues(_configFileInfo);
                var serializedConfigSection = JsonConvert.SerializeObject(configSection, Formatting.Indented);
                serializedConfigSection = "\t" + serializedConfigSection.Replace(Environment.NewLine, $"{Environment.NewLine}\t");

                stringBuilder.AppendLine($"\t\"{configSection.GetType().Name}\":");
                if(i != configSectionTypesList.Count - 1)
                {
                    stringBuilder.Append(serializedConfigSection);
                    stringBuilder.AppendLine(",");
                }
                else
                {
                    stringBuilder.AppendLine(serializedConfigSection);
                }
            }
            stringBuilder.AppendLine("}");

            File.WriteAllText(_configFileInfo.FullName, stringBuilder.ToString());
        }

        private void Load()
        {
            _loadedConfigSections = new List<object>();
            var configSectionList = _pluginRegistry.GetAllConfigSections();

            var converter = new ExpandoObjectConverter();
            var jsonConfig = JsonConvert.DeserializeObject<ExpandoObject>(File.ReadAllText(_configFileInfo.FullName), converter);
            foreach (var config in jsonConfig)
            {
                var configSection = configSectionList.SingleOrDefault(c => c.GetType().Name.Equals(config.Key, StringComparison.OrdinalIgnoreCase));
                if (configSection != null)
                {
                    var serializedConfigSection = JsonConvert.SerializeObject(config.Value);
                    _loadedConfigSections.Add(JsonConvert.DeserializeObject(serializedConfigSection, configSection.GetType()));
                }
            }
            _lastLoadTimeUtc = DateTime.Now;
        }

        public DoxDirectoryInfo ParentDirectory => _configFileInfo.Directory;
        public bool Exists => _configFileInfo.Exists;
    }
}
