using coreDox.Core.Contracts;
using coreDox.Core.Projects.Config;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace coreDox.Core
{
    public sealed class PluginRegistry
    {
        private List<Type> _registeredTargetTypesList;
        private List<Type> _registeredConfigSectionTypesList;

        private readonly ILogger _logger = LogManager.GetLogger("PluginRegistry");
        private readonly string _targetsFolderPath = Path.Combine(Path.GetDirectoryName(typeof(PluginRegistry).GetTypeInfo().Assembly.Location), "Targets");
        private readonly string[] _possibleTargetDllFileArray;

        public PluginRegistry()
        {
            _possibleTargetDllFileArray = Directory.GetFiles(_targetsFolderPath, "*.dll", SearchOption.AllDirectories);
        }
        
        public List<ITarget> GetAllTargetPlugins()
        {
            if(_registeredTargetTypesList == null)
            {
                _registeredTargetTypesList = new List<Type>();
                foreach (var possibleTargetDllFile in _possibleTargetDllFileArray)
                {
                    try
                    {
                        var possibleTargetAssembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(possibleTargetDllFile);
                        _registeredTargetTypesList.AddRange(GetTypesWithInterface<ITarget>(possibleTargetAssembly));
                    }
                    catch (Exception)
                    {
                        _logger.Debug($"Couldn't load assemby: {possibleTargetDllFile}");
                    }
                }
            }
            return _registeredTargetTypesList.Select(r => (ITarget) Activator.CreateInstance(r)).ToList();
        }

        public List<IConfigSection> GetAllConfigSections()
        {
            if(_registeredConfigSectionTypesList == null)
            {
                if (_registeredTargetTypesList == null) GetAllTargetPlugins();

                _registeredConfigSectionTypesList = new List<Type>();
                _registeredConfigSectionTypesList.Add(typeof(DoxConfigSection));
                foreach (var targetType in _registeredTargetTypesList)
                {
                    var targetInterface = targetType
                        .GetInterfaces()
                        .SingleOrDefault(i => i.Name.StartsWith(typeof(ITarget).Name) && i.GenericTypeArguments.Length > 0);
                    if (targetInterface != null)
                    {
                        var configType = targetInterface.GenericTypeArguments.FirstOrDefault();
                        if (configType != null) _registeredConfigSectionTypesList.Add(configType);
                    }
                }
            }
            return _registeredConfigSectionTypesList.Select(r => (IConfigSection)Activator.CreateInstance(r)).ToList();
        }

        private List<Type> GetTypesWithInterface<T>(Assembly assembly)
        {
            return assembly.GetTypes()
                .Where(t => t.GetInterfaces().Any(i => i == typeof(T)))
                .ToList();
        }
    }
}
