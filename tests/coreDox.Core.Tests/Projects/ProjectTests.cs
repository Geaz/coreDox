using coreDox.Core.Project;
using coreDox.Core.Project.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace coreDox.Core.Tests.Projects
{
    [TestClass]
    public class ProjectTests
    {
        private string _tmpPath = Path.Combine(Path.GetTempPath(), "testProject");

        [TestCleanup]
        public void TestCleanUp()
        {
            Directory.Delete(_tmpPath, true);
        }

        [TestMethod]
        public void ShouldCreateNewDefaultProjectOnLoadSuccessfully()
        {
            //Arrange
            var pluginRegistry = new PluginRegistry();
            var projectConfig = new DoxProjectConfig(pluginRegistry, Path.Combine(_tmpPath, DoxProject.ConfigFileName));
            var project = new DoxProject(projectConfig);

            //Act
            var loadResult = project.Load();

            //Assert
            Assert.IsTrue(loadResult.AllSucceeded());

            Assert.IsTrue(Directory.Exists(Path.Combine(_tmpPath, DoxProject.AssetFolderName)));
            Assert.IsTrue(Directory.Exists(Path.Combine(_tmpPath, DoxProject.LayoutFolderName)));
            Assert.IsTrue(Directory.Exists(Path.Combine(_tmpPath, DoxProject.PagesFolderName)));
            Assert.IsTrue(File.Exists(Path.Combine(_tmpPath, DoxProject.ConfigFileName)));
        }
    }
}
