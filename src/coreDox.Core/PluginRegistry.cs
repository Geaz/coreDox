using coreDox.Core.Contracts;
using coreDox.Core.Project.Config;
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
        private List<Type> _registeredModelProviderTypeList;
        private List<Type> _registeredTargetTypeList;
        private List<Type> _registeredConfigSectionTypeList;

        private readonly List<string> _possibleTargetDllFileArray = new List<string>();
        private readonly List<string> _possibleModelProviderDllFileArray = new List<string>();
        private readonly string _targetsFolderPath = Path.Combine(Path.GetDirectoryName(typeof(PluginRegistry).Assembly.Location), "Targets");
        private readonly string _modelProvidersFolderPath = Path.Combine(Path.GetDirectoryName(typeof(PluginRegistry).Assembly.Location), "ModelProviders");

        public PluginRegistry()
        {
            if(Directory.Exists(_targetsFolderPath))
            {
                _possibleTargetDllFileArray = Directory
                    .GetFiles(_targetsFolderPath, "*.dll", SearchOption.AllDirectories)
                    .ToList();
                _possibleModelProviderDllFileArray = Directory
                    .GetFiles(_modelProvidersFolderPath, "*.dll", SearchOption.AllDirectories)
                    .ToList();
            }
        }

        public List<IModelProvider> GetAllModelProviders()
        {
            if(_registeredModelProviderTypeList == null)
            {
                _registeredModelProviderTypeList = new List<Type>();
                foreach(var possibleModelProviderDllFile in _possibleModelProviderDllFileArray)
                {
                    var possibleModelProviderAssembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(possibleModelProviderDllFile);
                    _registeredModelProviderTypeList.AddRange(GetTypesWithInterface<IModelProvider>(possibleModelProviderAssembly));
                }
            }
            return _registeredModelProviderTypeList.Select(r => (IModelProvider)Activator.CreateInstance(r)).ToList();
        }

        public List<ITarget> GetAllTargetPlugins()
        {
            if(_registeredTargetTypeList == null)
            {
                _registeredTargetTypeList = new List<Type>();
                foreach (var possibleTargetDllFile in _possibleTargetDllFileArray)
                {
                    var possibleTargetAssembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(possibleTargetDllFile);
                    _registeredTargetTypeList.AddRange(GetTypesWithInterface<ITarget>(possibleTargetAssembly));
                }
            }
            return _registeredTargetTypeList.Select(r => (ITarget) Activator.CreateInstance(r)).ToList();
        }

        public List<IConfigSection> GetAllConfigSections()
        {
            if(_registeredConfigSectionTypeList == null)
            {
                if (_registeredTargetTypeList == null) GetAllTargetPlugins();

                _registeredConfigSectionTypeList = new List<Type>();
                _registeredConfigSectionTypeList.Add(typeof(DoxConfigSection));
                foreach (var targetType in _registeredTargetTypeList)
                {
                    var targetInterface = targetType
                        .GetInterfaces()
                        .SingleOrDefault(i => i.Name.StartsWith(typeof(ITarget).Name) && i.GenericTypeArguments.Length > 0);
                    if (targetInterface != null)
                    {
                        var configType = targetInterface.GenericTypeArguments.FirstOrDefault();
                        if (configType != null) _registeredConfigSectionTypeList.Add(configType);
                    }
                }
            }
            return _registeredConfigSectionTypeList.Select(r => (IConfigSection)Activator.CreateInstance(r)).ToList();
        }

        private List<Type> GetTypesWithInterface<T>(Assembly assembly)
        {
            return assembly.GetTypes()
                .Where(t => t.GetInterfaces().Any(i => i == typeof(T)))
                .ToList();
        }
    }
}
