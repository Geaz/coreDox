using coreDox.Core.Project;
using coreDox.Core.Project.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace coreDox.Core.Tests.Projects
{
    [TestClass]
    public class ProjectConfigTests
    {
        private string _tmpPath = Path.Combine(Path.GetTempPath(), "testProject");
        private PluginRegistry _pluginRegistry = new PluginRegistry();

        [TestCleanup]
        public void TestCleanUp()
        {
            Directory.Delete(_tmpPath, true);
        }

        [TestMethod]
        public void ShouldGetDoxConfigSuccessfully()
        {
            //Arrange
            var projectConfig = new DoxProjectConfig(_pluginRegistry, Path.Combine(_tmpPath, DoxProject.ConfigFileName));
            var project = new DoxProject(projectConfig);
            project.Load();

            //Act
            var doxConfig = project.Config.GetConfigSection<DoxConfigSection>();

            //Assert
            Assert.IsNotNull(doxConfig);
        }
    }
}
