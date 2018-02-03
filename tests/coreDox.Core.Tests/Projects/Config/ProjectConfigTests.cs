using coreDox.Core.Configuration;
using coreDox.Core.Projects.Config;
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
            var projectConfig = new ProjectConfig(_pluginRegistry, Path.Combine(_tmpPath, Project.ConfigFileName));
            var project = new Project(projectConfig);
            project.Load();

            //Act
            var doxConfig = project.Config.GetConfigSection<DoxConfigSection>();

            //Assert
            Assert.IsNotNull(doxConfig);
        }
    }
}
