using coreDox.Core.Contracts;
using coreDox.Core.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;

namespace coreDox.Core.Project.Config
{
    public sealed class DoxProjectConfig
    {
        public const string ConfigFileName = "config.json";

        private readonly List<IConfigSection> _loadedConfigSections;
        private readonly PluginRegistry _pluginRegistry = new PluginRegistry();

        public DoxProjectConfig()
        {
            _loadedConfigSections = _pluginRegistry.GetAllConfigSections();
        }

        public T GetConfigSection<T>()
        {
            return (T)_loadedConfigSections.Single(l => l.GetType() == typeof(T));
        }

        public void Load(string docFolder)
        {
            var configPath = Path.Combine(docFolder, ConfigFileName);
            if (!File.Exists(configPath)) throw new CoreDoxException($"No config file found at '{configPath}'!");

            var converter = new ExpandoObjectConverter();
            var jsonConfig = JsonConvert.DeserializeObject<ExpandoObject>(File.ReadAllText(configPath), converter);
            foreach (var config in jsonConfig)
            {
                var configSection = _loadedConfigSections.SingleOrDefault(c => c.GetType().Name.Equals(config.Key, StringComparison.OrdinalIgnoreCase));
                if (configSection != null)
                {
                    var serializedConfigSection = JsonConvert.SerializeObject(config.Value);
                    configSection = (IConfigSection) JsonConvert.DeserializeObject(serializedConfigSection, configSection.GetType());
                }
            }
        }

        public void Save(string docFolder)
        {
            var configPath = Path.Combine(docFolder, ConfigFileName);

            var completeJObject = new JObject();
            foreach(var configSection in _loadedConfigSections)
            {
                var sectionJObject = JObject.FromObject(configSection);

                var jObjectWithName = new JObject();
                jObjectWithName.Add(configSection.GetType().Name, sectionJObject);

                completeJObject.Merge(jObjectWithName);
            }

            var serializedObject = JsonConvert.SerializeObject(completeJObject);
            File.WriteAllText(configPath, serializedObject);
        }
    }
}
