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
            var namespaceModelList = this.SelectMany(a => a.DoxNamespaceSet);
            var typeModelList = namespaceModelList.SelectMany(n => n.DoxTypeSet);

            var doxModelList = new List<DoxCodeModel>(this);
            doxModelList.AddRange(namespaceModelList);
            doxModelList.AddRange(typeModelList);
            doxModelList.AddRange(typeModelList.SelectMany(t => t.DoxEventSet));
            doxModelList.AddRange(typeModelList.SelectMany(t => t.DoxFieldSet));
            doxModelList.AddRange(typeModelList.SelectMany(t => t.DoxMethodSet));
            doxModelList.AddRange(typeModelList.SelectMany(t => t.DoxPropertySet));

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
            return GetParsedType(doxTypeRef.TypeFullname);
        }

        public DoxType GetParsedType(string fullname)
        {
            return this
                .SelectMany(a => a.DoxNamespaceSet)
                .SelectMany(n => n.DoxTypeSet)
                .SingleOrDefault(t => t.FullName == fullname);
        }
    }
}
