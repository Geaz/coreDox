using coreDox.Core.CodeModel.Base;
using coreDox.Core.Project.Pages;
using NLog;
using System.Collections.Generic;
using System.Linq;

namespace coreDox.Core.CodeModel
{
    public sealed class DoxAssemblyList : List<DoxAssembly>
    {
        private readonly ILogger _logger = LogManager.GetLogger("DoxAssemblyList");
        private readonly PluginRegistry _pluginRegistry = PluginRegistry.Instance();

        public DoxAssemblyList(DoxPageFolder pageFolder)
        {
            AddRange(pageFolder
                    .GetAllAssemblyPages()
                    .Select(ap => new DoxAssembly(ap.AssemblyFileInfo.FullName))
                    .ToList());
        }

        public void AmendModels()
        {
            var namespaceModelList = this.SelectMany(a => a.NamespaceList);
            var typeModelList = namespaceModelList.SelectMany(n => n.TypeList);

            var doxModelList = new List<DoxCodeModel>(this);
            doxModelList.AddRange(namespaceModelList);
            doxModelList.AddRange(typeModelList);
            doxModelList.AddRange(typeModelList.SelectMany(t => t.EventList));
            doxModelList.AddRange(typeModelList.SelectMany(t => t.FieldList));
            doxModelList.AddRange(typeModelList.SelectMany(t => t.MethodList));
            doxModelList.AddRange(typeModelList.SelectMany(t => t.PropertyList));

            _logger.Info($"Amending {doxModelList.Count} models ...");
            foreach (var modelProvider in _pluginRegistry.GetAllModelProviders())
            {
                _logger.Info($"Running Model Provider: {modelProvider.GetType().Name} ...");
                doxModelList.ForEach(m => {
                    var model = modelProvider.AmendModel(m);
                    if (model != null) m.Models.Add(model.GetType().Name, model);
                });
            }
        }

        public DoxType GetParsedType(DoxTypeRef doxTypeRef)
        {
            return GetParsedType(doxTypeRef.TypeId);
        }

        public DoxType GetParsedType(string typeId)
        {
            return this
                .SelectMany(a => a.NamespaceList)
                .SelectMany(n => n.TypeList)
                .SingleOrDefault(t => t.Id == typeId);
        }
    }
}
