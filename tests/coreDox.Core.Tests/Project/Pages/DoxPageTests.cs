using coreDox.Core.Project;
using coreDox.Core.Project.Common;
using coreDox.Core.Project.Config;
using coreDox.Core.Project.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

namespace coreDox.Core.Tests.Projects.Pages
{
    [TestClass]
    public class DoxPageTests
    {
        private string _tmpFile = Path.GetTempFileName();
        // This folder gets copied into the assembly location by the post build event of the test project
        private string _testDoxProjectFolder = Path.Combine(Path.GetDirectoryName(typeof(PluginRegistry).Assembly.Location), "doxProject");
        
        [TestCleanup]
        public void TestCleanUp()
        {
            if (File.Exists(_tmpFile)) File.Delete(_tmpFile);
        }

        [TestMethod]
        public void ShouldCreateDoxPageSuccessfully()
        {
            //Arrange
            var doxPage = new DoxPage(new DoxFileInfo(_tmpFile));

            //Act
            doxPage.WritePage("Test Title", "Test Content");

            //Assert
            Assert.IsTrue(File.Exists(_tmpFile));
        }

        [TestMethod]
        public void ShouldParsePageSuccessfully()
        {
            //Arrange
            var pluginRegistry = new PluginRegistry();
            var projectConfig = new DoxProjectConfig(pluginRegistry, _testDoxProjectFolder);
            var project = new DoxProject(projectConfig);

            var assemblyPage = project.Pages.GetPages().First(p => p.PageType == DoxPageType.Assembly);

            //Act - Is Done During Assert

            //Assert
            Assert.AreEqual(DoxPageType.Assembly, assemblyPage.PageType);
            Assert.AreEqual("API", assemblyPage.Title);
            Assert.IsTrue(assemblyPage.AssemblyFileInfo.FullName.EndsWith("SharpDox.TestProject\\bin\\Debug\\SharpDox.TestProject.dll"));
            Assert.IsNull(assemblyPage.Content);
        }
    }
}
