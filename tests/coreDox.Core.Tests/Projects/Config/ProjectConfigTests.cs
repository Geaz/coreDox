using coreDox.Core.Exceptions;
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
            if(Directory.Exists(_tmpPath))
                Directory.Delete(_tmpPath, true);
        }

        [TestMethod]
        public void ShouldCreateDefaultConfigSuccessfully()
        {
            //Arrange
            Directory.CreateDirectory(_tmpPath);
            var projectConfig = new DoxProjectConfig(_pluginRegistry, Path.Combine(_tmpPath, DoxProject.ConfigFileName));

            //Act
            projectConfig.CreateDefaultConfig();

            //Assert
            Assert.IsTrue(projectConfig.Exists);
        }

        [TestMethod]
        public void ShouldGetDoxConfigSuccessfully()
        {
            //Arrange
            Directory.CreateDirectory(_tmpPath);
            var projectConfig = new DoxProjectConfig(_pluginRegistry, Path.Combine(_tmpPath, DoxProject.ConfigFileName));
            projectConfig.CreateDefaultConfig();

            //Act
            var doxConfig = projectConfig.GetConfigSection<DoxConfigSection>();

            //Assert
            Assert.IsNotNull(doxConfig);
        }

        [TestMethod]
        [ExpectedException(typeof(CoreDoxException))]
        public void ShouldThrowIfConfigFileNotPresentSuccessfully()
        {
            //Arrange
            var projectConfig = new DoxProjectConfig(_pluginRegistry, Path.Combine(_tmpPath, DoxProject.ConfigFileName));

            //Act
            var doxConfig = projectConfig.GetConfigSection<DoxConfigSection>();

            //Assert - Expects Exception
        }
    }
}
