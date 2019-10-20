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

        public T GetById<T>(string id) where T : DoxCodeModel
        {
            return id.Substring(0, 2) switch
            {
                "A:" => this.SingleOrDefault(a => a.Id == id) as T,
                "N:" => this
                    .SelectMany(a => a.NamespaceList)
                    .SingleOrDefault(n => n.Id == id) as T,
                "T:" => this
                    .SelectMany(a => a.NamespaceList)
                    .Select(n => n.GetTypeById(id))
                    .Where(t => t != null)
                    .SingleOrDefault() as T,
                _ => this
                    .SelectMany(a => a.NamespaceList)
                    .SelectMany(n => n.TypeList)
                    .Select(t => t.GetMemberById(id))
                    .Where(m => m != null)
                    .SingleOrDefault() as T
            };
        }
    }
}
