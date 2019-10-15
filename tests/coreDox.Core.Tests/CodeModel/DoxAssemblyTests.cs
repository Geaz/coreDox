using coreDox.Core.Model.Code;
using coreDox.Core.Project;
using coreDox.Core.Project.Config;
using coreDox.Core.Project.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

namespace coreDox.Core.Tests.CodeModel
{
    [TestClass]
    public class DoxAssemblyTests
    {
        // This folder gets copied into the assembly location by the post build event of the test project
        private string _testDoxProjectFolder = Path.Combine(Path.GetDirectoryName(typeof(PluginRegistry).Assembly.Location), "doxProject");

        [TestMethod]
        public void ShouldOpenAssemblySuccessfully()
        {
            //Arrange
            var pluginRegistry = new PluginRegistry();
            var projectConfig = new DoxProjectConfig(pluginRegistry, _testDoxProjectFolder);
            var project = new DoxProject(projectConfig);
            var assemblyPage = project.Pages.GetPages().First(p => p.PageType == DoxPageType.Assembly);

            //Act
            var doxAssembly = new DoxAssembly(assemblyPage.AssemblyFileInfo.FullName);

            //Assert
            Assert.IsTrue(doxAssembly.DoxNamespaceSet.Count > 0);
        }
    }
}
